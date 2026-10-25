import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * آرشیو/خروج از آرشیو پروژه — مثل چک‌باکس prjIsFinished در فرم ویرایش
 * (با پیام خود محصول: «به تب آرشیو منتقل و از نظر اول پنهان می‌شود»)
 */
export async function PATCH(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const user = await requirePerm("frmDefineProjects", "actCanSetArchive");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const project = await db.project.findUnique({ where: { id } });
    if (!project) return apiError("پروژه یافت نشد.", 404);

    const isFinished = Boolean(body?.isFinished);
    if (isFinished === project.isFinished) return json(project);

    const now = new Date();
    const data: Record<string, unknown> = { isFinished, lastEditedById: user.id };
    if (isFinished) {
      data.finishedDate = now;
      data.finishedUserId = user.id;
      const base = project.startDate ?? now;
      data.finishedDurationSec = Math.max(0, Math.round((now.getTime() - base.getTime()) / 1000));
    } else {
      data.finishedDate = null;
      data.finishedUserId = null;
      data.finishedDurationSec = null;
      data.finishedDay = null;
      data.finishedTime = null;
    }
    const updated = await db.project.update({ where: { id }, data });
    return json(updated);
  });
}
