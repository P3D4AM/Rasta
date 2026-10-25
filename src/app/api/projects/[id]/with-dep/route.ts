import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/** حذف پروژه با همه وابستگی‌ها — DeleteCmpProjectWithDep (مذاکرات هم حذف می‌شوند) */
export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmProjectPreview", "actDeleteCmpProjectWithDep");
    const { id } = await params;
    const project = await db.project.findUnique({ where: { id } });
    if (!project) return apiError("پروژه یافت نشد.", 404);
    await db.projectConversation.deleteMany({ where: { projectId: id } });
    await db.project.delete({ where: { id } });
    return json({ deleted: true });
  });
}
