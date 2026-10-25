import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/projects/[id] — بازسازی ProjectPreview + _PartialPrjPreview (ناوبری قبلی/بعدی، SLA اولین مطالعه)
 * GET → جزئیات کامل + مذاکرات + توافق‌نامه سرفصل + prev/next (داخل همان مخاطب و همان تب)
 * PUT → ویرایش (frmDefineProjects/actPost)
 * DELETE → حذف ساده — با وجود مذاکره رد می‌شود (RedundancyMessage خود محصول)
 */

const userSel = { select: { id: true, firstName: true, lastName: true } } as const;
const nameOf = (u: { firstName: string; lastName: string } | null) => (u ? `${u.firstName} ${u.lastName}` : null);

const PROJECT_INCLUDE = {
  priority: true,
  grade: true,
  group: true,
  titleGroup: true,
  category: true,
  statusGroup: { include: { statuses: { orderBy: { orderView: "asc" as const } } } },
  company: { select: { id: true, name: true, province: true, city: true } },
  starter: userSel,
  finishedUser: userSel,
  ticketStopUser: userSel,
  readUser: userSel,
  responseUser: userSel,
  firstDoingUser: userSel,
  registeredBy: userSel,
  lastEditedBy: userSel,
  conversations: {
    orderBy: { cnvsDate: "desc" as const },
    include: {
      status: true,
      referUser: userSel,
      registeredBy: userSel,
    },
  },
} as const;

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const user = await requirePerm("frmProjectPreview", "actView");
    const { id } = await params;

    let project = await db.project.findUnique({
      where: { id },
      include: PROJECT_INCLUDE,
    });
    if (!project) return apiError("پروژه یافت نشد.", 404);

    // SLA تیکت — اولین مطالعه (prjRead*): در اولین بازکردن پیش‌نمایش ثبت می‌شود
    if (!project.readDate) {
      const now = new Date();
      const base = project.startDate ?? now;
      await db.project.update({
        where: { id },
        data: {
          readDate: now,
          readUserId: user.id,
          readDurationSec: Math.max(0, Math.round((now.getTime() - base.getTime()) / 1000)),
        },
      });
      const fresh = await db.project.findUnique({ where: { id }, include: PROJECT_INCLUDE });
      if (fresh) project = fresh;
    }

    const last = project.conversations[0] ?? null;
    const totalDoingSec = project.conversations.reduce((s, c) => s + (c.doingTimeSec ?? 0), 0);

    // ناوبری قبلی/بعدی — داخل همان مخاطب و همان وضعیت جاری/آرشیو
    const [prev, next] = await Promise.all([
      db.project.findFirst({
        where: { companyId: project.companyId, isFinished: project.isFinished, number: { lt: project.number } },
        orderBy: { number: "desc" },
        select: { id: true },
      }),
      db.project.findFirst({
        where: { companyId: project.companyId, isFinished: project.isFinished, number: { gt: project.number } },
        orderBy: { number: "asc" },
        select: { id: true },
      }),
    ]);

    return json({
      project: {
        ...project,
        starterName: nameOf(project.starter),
        finishedUserName: nameOf(project.finishedUser),
        ticketStopUserName: nameOf(project.ticketStopUser),
        readUserName: nameOf(project.readUser),
        responseUserName: nameOf(project.responseUser),
        firstDoingUserName: nameOf(project.firstDoingUser),
        registeredByName: nameOf(project.registeredBy),
        lastEditedByName: nameOf(project.lastEditedBy),
        priorityName: project.priority?.name ?? null,
        priorityColor: project.priority?.color ?? null,
        gradeName: project.grade?.name ?? null,
        groupName: project.group?.name ?? null,
        titleGroupName: project.titleGroup?.name ?? null,
        categoryName: project.category?.name ?? null,
      },
      conversations: project.conversations.map((c) => ({
        ...c,
        statusName: c.status.name,
        statusPercent: c.status.progressPercent,
        statusColor: c.status.color ?? null,
        referUserName: nameOf(c.referUser),
        registeredByName: nameOf(c.registeredBy),
      })),
      lastStatus: last ? { id: last.status.id, name: last.status.name, percent: last.status.progressPercent, color: last.status.color ?? null } : null,
      progressPercent: last?.status.progressPercent ?? 0,
      totalDoingSec,
      prevId: prev?.id ?? null,
      nextId: next?.id ?? null,
    });
  });
}

export async function PUT(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const user = await requirePerm("frmDefineProjects", "actPost");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.project.findUnique({ where: { id } });
    if (!existing) return apiError("پروژه یافت نشد.", 404);

    const statusGroupId = str(body?.statusGroupId) ?? existing.statusGroupId;
    if (!statusGroupId) return apiError("مدل پیشرفت الزامی است.", 400);

    // تغییر آرشیو — نیازمند actCanSetArchive
    let isFinished = existing.isFinished;
    let finishedDate = existing.finishedDate;
    let finishedUserId = existing.finishedUserId;
    let finishedDurationSec = existing.finishedDurationSec;
    if (body?.isFinished !== undefined && Boolean(body.isFinished) !== existing.isFinished) {
      const { can } = await import("@/lib/auth");
      if (!can(user, "frmDefineProjects", "actCanSetArchive")) {
        return apiError("شما اجازه آرشیو پروژه را ندارید.", 403);
      }
      isFinished = Boolean(body.isFinished);
      if (isFinished) {
        finishedDate = new Date();
        finishedUserId = user.id;
        const base = existing.startDate ?? finishedDate;
        finishedDurationSec = Math.max(0, Math.round((finishedDate.getTime() - base.getTime()) / 1000));
      } else {
        finishedDate = null;
        finishedUserId = null;
        finishedDurationSec = null;
      }
    }

    // توقف تیکت — نیازمند actCanSetPrjIsTicket
    let ticketStop = existing.ticketStop;
    let ticketStopUserId = existing.ticketStopUserId;
    let ticketStopDate = existing.ticketStopDate;
    if (body?.ticketStop !== undefined && Boolean(body.ticketStop) !== existing.ticketStop) {
      const { can } = await import("@/lib/auth");
      if (!can(user, "frmDefineProjects", "actCanSetPrjIsTicket")) {
        return apiError("شما اجازه توقف تیکت را ندارید.", 403);
      }
      ticketStop = Boolean(body.ticketStop);
      if (ticketStop) {
        ticketStopUserId = user.id;
        ticketStopDate = new Date();
      } else {
        ticketStopUserId = null;
        ticketStopDate = null;
      }
    }

    const project = await db.project.update({
      where: { id },
      data: {
        title: str(body?.title) ?? existing.title,
        referenceNumber: str(body?.referenceNumber),
        postFix: str(body?.postFix),
        inquiryNumber: str(body?.inquiryNumber),
        subject: str(body?.subject),
        description: str(body?.description),
        descriptionAdditional: str(body?.descriptionAdditional),
        titleGroupId: str(body?.titleGroupId),
        groupId: str(body?.groupId),
        gradeId: str(body?.gradeId),
        priorityId: str(body?.priorityId),
        categoryId: str(body?.categoryId),
        statusGroupId,
        starterUserId: str(body?.starterUserId) ?? existing.starterUserId,
        startDate: dateVal(body?.startDate) ?? existing.startDate,
        startDay: str(body?.startDay),
        startTime: str(body?.startTime),
        isFinished,
        finishedDate,
        finishedDay: isFinished ? str(body?.finishedDay) : null,
        finishedTime: isFinished ? str(body?.finishedTime) : null,
        finishedUserId,
        finishedDurationSec,
        remindDate: dateVal(body?.remindDate),
        orderView: body?.orderView != null && body?.orderView !== "" ? Number(body.orderView) || null : null,
        isTicket: body?.isTicket !== undefined ? Boolean(body.isTicket) : existing.isTicket,
        ticketStop,
        ticketStopUserId,
        ticketStopDate,
        foCmpCanSee: body?.foCmpCanSee !== undefined ? Boolean(body.foCmpCanSee) : existing.foCmpCanSee,
        foCmpCanInsCnvs: body?.foCmpCanInsCnvs !== undefined ? Boolean(body.foCmpCanInsCnvs) : existing.foCmpCanInsCnvs,
        toDoTime: dateVal(body?.toDoTime),
        toDoTimeRegister: dateVal(body?.toDoTimeRegister),
        toDoTimeDone: dateVal(body?.toDoTimeDone),
        toDoTimeSec: body?.toDoTimeSec != null && body.toDoTimeSec !== "" ? Number(body.toDoTimeSec) || null : null,
        lastEditedById: user.id,
      },
    });
    return json(project);
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmProjectPreview", "actDelete");
    const { id } = await params;
    const existing = await db.project.findUnique({ where: { id }, include: { _count: { select: { conversations: true } } } });
    if (!existing) return apiError("پروژه یافت نشد.", 404);
    if (existing._count.conversations > 0) {
      // مثل RedundancyMessage خود محصول: پروژه دارای مذاکره به‌سادگی حذف نمی‌شود
      return apiError("این پروژه مذاکره ثبت‌شده دارد. از «حذف با وابستگی‌ها» استفاده کنید.", 409);
    }
    await db.project.delete({ where: { id } });
    return json({ deleted: true });
  });
}

function str(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}

function dateVal(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(v as string);
  return isNaN(d.getTime()) ? null : d;
}
