import { db } from "@/lib/db";
import { createSession, verifyPassword } from "@/lib/auth";
import { handle, json, apiError } from "@/lib/http";

/**
 * ورود — بازسازی چک‌های ترتیبی LoginI در AccountController خود CRMIdeal:
 *   رمز → فعال‌بودن در وب (UserIsActiveInWebApp=IsActive) → انقضای حساب (ExpireDate → msgErrorUsernameExpired)
 *   → داشتن نقش فعال (UsersPermission) → ساعت/روز/تاریخ/IP مجاز ورود (UserLoginAllowedTimes → CRMspCheckUserLoginAllowedTimes)
 * نکته: کپچا، سقف کاربر همزمان (لایسنس)، QR حضورغیاب هوشمند و شیفت‌بندی در رستا وجود ندارد (لایسنس/HRM فعال نیست).
 */

function toMinutes(hhmm: string): number {
  const [h, m] = hhmm.split(":").map((x) => Number(x) || 0);
  return h * 60 + m;
}

async function isLoginTimeAllowed(userId: string): Promise<boolean> {
  const rows = await db.userLoginAllowedTime.findMany({ where: { userId } });
  if (rows.length === 0) return true; // بدون ردیف = بدون محدودیت (مثل CRMIdeal)

  const now = new Date();
  // روز هفته شمسی: شنبه=0 … جمعه=6 — از UTC offset تهران (+3:30) محاسبه می‌شود
  const tehran = new Date(now.getTime() + 3.5 * 3600 * 1000);
  const jsDay = tehran.getUTCDay(); // 0=Sunday…6=Saturday
  const weekDay = (jsDay + 1) % 7; // شنبه=0
  const nowMinutes = tehran.getUTCHours() * 60 + tehran.getUTCMinutes();

  return rows.some((r) => {
    if (r.dayOfWeek != null && r.dayOfWeek !== weekDay) return false;
    if (r.fromDate && now < r.fromDate) return false;
    if (r.toDate && now > r.toDate) return false;
    if (nowMinutes < toMinutes(r.fromTime) || nowMinutes > toMinutes(r.toTime)) return false;
    return true;
  });
}

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
    // انقضای حساب — msgErrorUsernameExpired خود CRMIdeal
    if (user.expireDate && new Date() > user.expireDate) {
      return apiError("اعتبار حساب کاربری شما به پایان رسیده است. با مدیر سیستم تماس بگیرید.", 403);
    }
    // داشتن نقش فعال — چک UserRollId != 0 در LoginI (ادمین سیستم معاف است)
    if (!user.isAdmin && !user.roleId) {
      return apiError("نقشی برای این کاربر تعریف نشده است. با مدیر سیستم تماس بگیرید.", 403);
    }
    // ساعت/روز/تاریخ مجاز ورود
    if (!(await isLoginTimeAllowed(user.id))) {
      return apiError("در زمان فعلی اجازه ورود به سیستم را ندارید.", 403);
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
