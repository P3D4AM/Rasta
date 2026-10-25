import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/** حذف یک قاعده ساعت ورود — UserLoginAllowedTimesDelete */
export async function DELETE(req: Request, { params }: { params: Promise<{ id: string; timeId: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actLoginAllowedTimes");
    const { id, timeId } = await params;
    const row = await db.userLoginAllowedTime.findUnique({ where: { id: timeId } });
    if (!row || row.userId !== id) return apiError("قاعده یافت نشد.", 404);
    await db.userLoginAllowedTime.delete({ where: { id: timeId } });
    return json({ deleted: true });
  });
}
