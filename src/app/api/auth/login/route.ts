import { db } from "@/lib/db";
import { createSession, verifyPassword } from "@/lib/auth";
import { handle, json, apiError } from "@/lib/http";

export async function POST(req: Request) {
  return handle(async () => {
    const body = await req.json().catch(() => null);
    const username = String(body?.username ?? "").trim();
    const password = String(body?.password ?? "");
    if (!username || !password) {
      return apiError("نام کاربری و رمز عبور الزامی است.", 400);
    }

    const user = await db.user.findUnique({ where: { username } });
    if (!user || !verifyPassword(password, user.passwordHash)) {
      return apiError("نام کاربری یا رمز عبور نادرست است.", 401);
    }
    if (!user.isActive) {
      return apiError("حساب کاربری شما غیرفعال شده است. با مدیر سیستم تماس بگیرید.", 403);
    }

    await db.user.update({
      where: { id: user.id },
      data: { lastLoginAt: new Date() },
    });

    await createSession(user.id);

    return json({
      user: {
        id: user.id,
        username: user.username,
        firstName: user.firstName,
        lastName: user.lastName,
      },
    });
  });
}
