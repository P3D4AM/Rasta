import { db } from "@/lib/db";
import { handle, json, apiError } from "@/lib/http";
import { hashPassword, verifyPassword, getCurrentUser } from "@/lib/auth";

/** تغییر رمز عبور — ChangePassword خود محصول (رمز فعلی/جدید/تکرار) */
export async function POST(req: Request) {
  return handle(async () => {
    const me = await getCurrentUser();
    if (!me) return apiError("ابتدا وارد شوید.", 401);
    const body = await req.json().catch(() => null);
    const current = String(body?.currentPassword ?? "");
    const next = String(body?.newPassword ?? "");
    const repeat = String(body?.repeatPassword ?? "");

    if (!current || !next || !repeat) return apiError("هر سه فیلد الزامی است.", 400);
    if (next !== repeat) return apiError("تکرار رمز عبور جدید مطابقت ندارد.", 400);
    if (next.length < 6) return apiError("رمز عبور جدید باید حداقل ۶ کاراکتر باشد.", 400);

    const user = await db.user.findUnique({ where: { id: me.id } });
    if (!user || !verifyPassword(current, user.passwordHash)) {
      return apiError("رمز عبور فعلی نادرست است.", 400);
    }
    await db.user.update({ where: { id: me.id }, data: { passwordHash: hashPassword(next) } });
    return json({ changed: true });
  });
}
