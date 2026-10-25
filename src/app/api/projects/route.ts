import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/projects — بازسازی منطق CompanyInfoController (GetCompanyProjectInSummary / ProjectInsert)
 * GET  ?companyId=&tab=current|archive|ticket&ticketMode=all|current|archive&search=
 *      → درخت پروژه‌ها + شمارنده‌ها (مثل CRMspSelectCompanyProjectsCount)
 *      بدون companyId → لیست سراسری پروژه‌ها (کارتابل/گزارش)
 * POST → درج پروژه (ChkBeforeSubmitProject_Lang + شماره‌گذاری prjNumR)
 * DELETE ?companyId= → حذف همه پروژه‌های مخاطب با وابستگی‌ها (DeleteAllCmpProjectsWithDep)
 */

export async function GET(req: Request) {
  return handle(async () => {
    await requirePerm("frmProjectPreview", "actView");
    const url = new URL(req.url);
    const companyId = url.searchParams.get("companyId") ?? "";
    const tab = url.searchParams.get("tab") ?? "current"; // current | archive | ticket
    const ticketMode = url.searchParams.get("ticketMode") ?? "all"; // for tab=ticket
    const search = (url.searchParams.get("search") ?? "").trim();
    const page = Math.max(1, Number(url.searchParams.get("page") ?? 1) || 1);
    const pageSize = Math.min(200, Number(url.searchParams.get("pageSize") ?? 100) || 100);

    const isFinished = tab === "archive";
    const where: Record<string, unknown> = {};
    if (companyId) where.companyId = companyId;
    if (tab === "ticket") {
      where.isTicket = true;
      if (ticketMode === "current") where.isFinished = false;
      else if (ticketMode === "archive") where.isFinished = true;
    } else {
      where.isFinished = isFinished;
    }
    if (search) {
      where.OR = [
        { title: { contains: search } },
        { postFix: { contains: search } },
        { referenceNumber: { contains: search } },
        { subject: { contains: search } },
      ];
    }

    const [projects, count] = await Promise.all([
      db.project.findMany({
        where,
        orderBy: [{ orderView: "asc" as const }, { number: "asc" as const }],
        skip: (page - 1) * pageSize,
        take: pageSize,
        include: {
          priority: true,
          grade: true,
          group: true,
          titleGroup: true,
          starter: { select: { id: true, firstName: true, lastName: true } },
          company: { select: { id: true, name: true } },
          statusGroup: { select: { id: true, name: true } },
          conversations: {
            orderBy: { cnvsDate: "desc" },
            take: 1,
            include: { status: true },
          },
          _count: { select: { conversations: true } },
        },
      }),
      db.project.count({ where }),
    ]);

    // شمارنده‌های تب‌ها — مثل CRMspSelectCompanyProjectsCount
    const counterWhere = companyId ? { companyId } : {};
    const [projectActive, projectArchive, ticketActive, ticketArchive] = await Promise.all([
      db.project.count({ where: { ...counterWhere, isFinished: false, isTicket: false } }),
      db.project.count({ where: { ...counterWhere, isFinished: true, isTicket: false } }),
      db.project.count({ where: { ...counterWhere, isFinished: false, isTicket: true } }),
      db.project.count({ where: { ...counterWhere, isFinished: true, isTicket: true } }),
    ]);

    const now = new Date();
    const rows = projects.map((p) => {
      const last = p.conversations[0] ?? null;
      return {
        id: p.id,
        number: p.number,
        title: p.postFix ? `${p.title} - ${p.postFix}` : p.title,
        rawTitle: p.title,
        postFix: p.postFix,
        referenceNumber: p.referenceNumber,
        inquiryNumber: p.inquiryNumber,
        subject: p.subject,
        isFinished: p.isFinished,
        isTicket: p.isTicket,
        ticketStop: p.ticketStop,
        foCmpCanSee: p.foCmpCanSee,
        remindDate: p.remindDate,
        remindOverdue: !!(p.remindDate && !p.isFinished && p.remindDate < now),
        startDate: p.startDate,
        statusGroupId: p.statusGroupId,
        statusGroupName: p.statusGroup.name,
        lastStatusId: last?.statusId ?? null,
        lastStatusName: last?.status.name ?? null,
        lastStatusPercent: last?.status.progressPercent ?? 0,
        lastStatusColor: last?.status.color ?? null,
        lastCnvsDate: last?.cnvsDate ?? null,
        priorityId: p.priorityId,
        priorityName: p.priority?.name ?? null,
        priorityColor: p.priority?.color ?? null,
        gradeName: p.grade?.name ?? null,
        groupName: p.group?.name ?? null,
        titleGroupName: p.titleGroup?.name ?? null,
        starterName: p.starter ? `${p.starter.firstName} ${p.starter.lastName}` : null,
        registeredById: p.registeredById,
        companyId: p.companyId,
        companyName: p.company.name,
        conversationsCount: p._count.conversations,
      };
    });

    return json({ rows, total: count, page, pageSize, counters: { projectActive, projectArchive, ticketActive, ticketArchive } });
  });
}

export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePerm("frmDefineProjects", "actPost");
    const body = await req.json().catch(() => null);
    const title = String(body?.title ?? "").trim();
    const statusGroupId = String(body?.statusGroupId ?? "").trim();
    const companyId = String(body?.companyId ?? "").trim();
    if (!title || !statusGroupId || !companyId) {
      return apiError("عنوان، مدل پیشرفت و مخاطب الزامی است.", 400);
    }

    // چک‌های تکراری‌نبودن — مثل ChkBeforeSubmitProject (پسوند/توضیح/استعلام/عطف)
    const postFix = str(body?.postFix);
    const description = str(body?.description);
    const inquiryNumber = str(body?.inquiryNumber);
    const referenceNumber = str(body?.referenceNumber);
    const dups: [string, string | null, string][] = [
      ["postFix", postFix, "پسوند عنوان برای این مخاطب تکراری است."],
      ["description", description, "توضیح برای این مخاطب تکراری است."],
      ["inquiryNumber", inquiryNumber, "شماره استعلام برای این مخاطب تکراری است."],
      ["referenceNumber", referenceNumber, "شماره عطف تکراری است."],
    ];
    for (const [field, value, error] of dups) {
      if (!value) continue;
      const dup = await db.project.findFirst({ where: { companyId, [field]: value } });
      if (dup) return apiError(error, 409);
    }

    // شماره‌گذاری prjNumR — مثل CRMfnReturnProjectNumR + ActivePrjNumRWithTitle
    const titleDef = await db.projectTitle.findFirst({ where: { title } });
    let number: number;
    if (titleDef?.activeNumRWithTitle) {
      const last = await db.project.findFirst({ where: { title }, orderBy: { number: "desc" }, select: { number: true } });
      number = (last?.number ?? 1000) + 1;
    } else {
      const last = await db.project.findFirst({ orderBy: { number: "desc" }, select: { number: true } });
      number = (last?.number ?? 1000) + 1;
    }

    // آرشیو در درج — نیازمند actCanSetArchive (مثل CRMIdeal)
    const isFinished = Boolean(body?.isFinished);
    const startDate = dateVal(body?.startDate) ?? new Date();
    let finishedDate: Date | null = null;
    let finishedUserId: string | null = null;
    let finishedDurationSec: number | null = null;
    if (isFinished) {
      const { can } = await import("@/lib/auth");
      if (!can(user, "frmDefineProjects", "actCanSetArchive")) {
        return apiError("شما اجازه آرشیو پروژه را ندارید.", 403);
      }
      finishedDate = dateVal(body?.finishedDate) ?? new Date();
      finishedUserId = user.id;
      finishedDurationSec = Math.max(0, Math.round((finishedDate.getTime() - startDate.getTime()) / 1000));
    }

    const project = await db.project.create({
      data: {
        number,
        referenceNumber,
        postFix,
        inquiryNumber,
        title,
        subject: str(body?.subject),
        description,
        descriptionAdditional: str(body?.descriptionAdditional),
        titleGroupId: str(body?.titleGroupId),
        groupId: str(body?.groupId),
        gradeId: str(body?.gradeId),
        priorityId: str(body?.priorityId),
        categoryId: str(body?.categoryId),
        statusGroupId,
        companyId,
        starterUserId: str(body?.starterUserId) ?? user.id,
        startDate,
        startDay: str(body?.startDay),
        startTime: str(body?.startTime),
        isFinished,
        finishedDate,
        finishedDay: isFinished ? str(body?.finishedDay) : null,
        finishedTime: isFinished ? str(body?.finishedTime) : null,
        finishedUserId,
        finishedDurationSec,
        remindDate: dateVal(body?.remindDate),
        orderView: body?.orderView != null && body.orderView !== "" ? Number(body.orderView) || null : null,
        isTicket: Boolean(body?.isTicket),
        foCmpCanSee: Boolean(body?.foCmpCanSee),
        foCmpCanInsCnvs: body?.foCmpCanInsCnvs !== false,
        toDoTime: dateVal(body?.toDoTime),
        toDoTimeRegister: dateVal(body?.toDoTimeRegister),
        toDoTimeSec: body?.toDoTimeSec != null && body.toDoTimeSec !== "" ? Number(body.toDoTimeSec) || null : null,
        registeredById: user.id,
        lastEditedById: user.id,
      },
    });
    return json(project, 201);
  });
}

/** حذف همه پروژه‌های مخاطب با وابستگی‌ها — DeleteAllCmpProjectsWithDep */
export async function DELETE(req: Request) {
  return handle(async () => {
    await requirePerm("frmProjectPreview", "actDeleteAllCmpProjectsWithDep");
    const url = new URL(req.url);
    const companyId = url.searchParams.get("companyId") ?? "";
    if (!companyId) return apiError("شناسه مخاطب الزامی است.", 400);
    const cnt = await db.project.count({ where: { companyId } });
    if (!cnt) return apiError("این مخاطب پروژه‌ای ندارد.", 404);
    await db.projectConversation.deleteMany({ where: { companyId } });
    await db.project.deleteMany({ where: { companyId } });
    return json({ deleted: cnt });
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
