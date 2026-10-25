import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/projects/[id]/conversations — بازسازی CnvsProjectConversations_Read + درج مذاکره
 * POST: نتیجه‌های وضعیت اعمال می‌شوند (مثل CRMIdeal):
 *   - NoCnvsDup: مذاکره تکراری با همان آخرین وضعیت رد می‌شود
 *   - SLA: اولین پاسخ (prjResponse*) و اولین اقدام با مدت انجام (prjFirstDoing*) ثبت می‌شوند
 *   - PrjFinished: وضعیتِ آرشیوکننده، پروژه را آرشیو می‌کند (مدت تا آرشیو محاسبه می‌شود)
 */

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmConversations", "actView");
    const { id } = await params;
    const rows = await db.projectConversation.findMany({
      where: { projectId: id },
      orderBy: { cnvsDate: "desc" },
      include: {
        status: true,
        referUser: { select: { id: true, firstName: true, lastName: true } },
        registeredBy: { select: { id: true, firstName: true, lastName: true } },
      },
    });
    return json({ rows });
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const user = await requirePerm("frmConversations", "actInsert");
    const { id } = await params;
    const body = await req.json().catch(() => null);

    const project = await db.project.findUnique({ where: { id } });
    if (!project) return apiError("پروژه یافت نشد.", 404);
    if (project.isFinished) return apiError("این پروژه آرشیو شده است؛ ابتدا از آرشیو خارج کنید.", 409);

    const statusId = String(body?.statusId ?? "").trim();
    const description = String(body?.description ?? "").trim();
    if (!statusId || !description) return apiError("وضعیت و متن مذاکره الزامی است.", 400);

    const status = await db.cnvsStatus.findUnique({ where: { id: statusId } });
    if (!status || status.groupId !== project.statusGroupId) {
      return apiError("وضعیت انتخاب‌شده به مدل پیشرفت این پروژه تعلق ندارد.", 400);
    }

    const last = await db.projectConversation.findFirst({
      where: { projectId: id },
      orderBy: { cnvsDate: "desc" },
    });
    if (status.noCnvsDup && last?.statusId === statusId) {
      return apiError("مذاکره تکراری با آخرین وضعیت ثبت نکردید؛ وضعیت را تغییر دهید.", 409);
    }

    const cnvsDate = body?.cnvsDate ? new Date(body.cnvsDate) : new Date();
    const doingTimeSec = body?.doingTimeSec ? Math.max(0, Number(body.doingTimeSec) || 0) : null;

    const conv = await db.projectConversation.create({
      data: {
        projectId: id,
        companyId: project.companyId,
        statusId,
        referUserId: str(body?.referUserId),
        cnvsDate: isNaN(cnvsDate.getTime()) ? new Date() : cnvsDate,
        cnvsTime: str(body?.cnvsTime),
        description,
        doingTimeSec,
        registeredById: user.id,
      },
    });

    // نتیجه‌های وضعیت — مثل CRMIdeal
    const now = new Date();
    const base = project.startDate ?? now;
    const sla: Record<string, unknown> = {};
    if (!project.responseDate) {
      sla.responseDate = now;
      sla.responseUserId = user.id;
      sla.responseDurationSec = Math.max(0, Math.round((now.getTime() - base.getTime()) / 1000));
    }
    if (doingTimeSec && !project.firstDoingDate) {
      sla.firstDoingDate = now;
      sla.firstDoingUserId = user.id;
      sla.firstDoingDurationSec = Math.max(0, Math.round((now.getTime() - base.getTime()) / 1000));
    }
    const archiveNow: Record<string, unknown> = {};
    if (status.prjFinished && !project.isFinished) {
      archiveNow.isFinished = true;
      archiveNow.finishedDate = now;
      archiveNow.finishedUserId = user.id;
      archiveNow.finishedDurationSec = Math.max(0, Math.round((now.getTime() - base.getTime()) / 1000));
    }
    if (Object.keys(sla).length || Object.keys(archiveNow).length) {
      await db.project.update({ where: { id }, data: { ...sla, ...archiveNow, lastEditedById: user.id } });
    } else {
      await db.project.update({ where: { id }, data: { lastEditedById: user.id } });
    }

    return json({ ...conv, archivedProject: Boolean(archiveNow.isFinished) }, 201);
  });
}

function str(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
