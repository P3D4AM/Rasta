import { db } from "@/lib/db";
import { createSession, verifyPassword } from "@/lib/auth";
import { handle, json, apiError } from "@/lib/http";
import { gregorianToJalali } from "@/lib/jalali";

/**
 * ورود — بازسازی چک‌های ترتیبی LoginI در AccountController خود CRMIdeal:
 *   رمز → فعال‌بودن در وب (UserIsActiveInWebApp=IsActive) → انقضای حساب (ExpireDate → msgErrorUsernameExpired)
 *   → داشتن نقش فعال (UsersPermission) → ساعت/روز/تاریخ/IP مجاز ورود (UserLoginAllowedTimes → CRMspCheckUserLoginAllowedTimes)
 * نکته: کپچا، سقف کاربر همزمان (لایسنس)، QR حضورغیاب هوشمند و شیفت‌بندی در رستا وجود ندارد (لایسنس/HRM فعال نیست).
 */

/** تاریخ امروز به کلید شمسی YYYYMMDD — مثل FDatePersian خود CRMIdeal (بدون اسلش). */
function faDateKey(d: Date): string {
  const [jy, jm, jd] = gregorianToJalali(d.getFullYear(), d.getMonth() + 1, d.getDate());
  return `${jy}${String(jm).padStart(2, "0")}${String(jd).padStart(2, "0")}`;
}

/**
 * بازسازی عیناً CRMspCheckUserLoginAllowedTimes (کاتالوگ SQL — V3 گام ۷۲۵، متن کامل):
 * هر بُعد (تاریخ/روز/ساعت/IP) به‌صورت مستقل روی کل ردیف‌های کاربر چک می‌شود؛
 * اگر کاربر برای بُعدی قاعده‌ای ثبت کرده باشد و «اکنون» داخل پنجرهٔ آن قاعده بیفتد،
 * ورود رد می‌شود (ردیف‌ها پنجرهٔ ممنوع هستند، نه مجاز). بدون قاعده در یک بُعد = بدون محدودیت آن بُعد.
 * خروجی: AllowUserLogin + Reason (Date,Day,Time,IPAddress) دقیقاً مثل SP.
 */
async function checkUserLoginAllowedTimes(
  userId: string,
  ip: string | null,
): Promise<{ allow: boolean; reason: string }> {
  const rows = await db.userLoginAllowedTime.findMany({ where: { userId } });

  const now = new Date();
  const fa = faDateKey(now);
  // CRMIdeal DayNumber: ۰=شنبه … ۶=جمعه — از getDay جاوااسکریپت (۰=یکشنبه) تبدیل می‌شود
  const crmDay = (now.getDay() + 1) % 7; // شنبه=0 … جمعه=6
  const nowHHmm = `${String(now.getHours()).padStart(2, "0")}:${String(now.getMinutes()).padStart(2, "0")}`;

  let allow = true;
  let reason = "";

  // ── Date Control — @CurrDate BETWEEN FDatePersian AND TDatePersian ──
  const dateRows = rows.filter((r) => (r.FDatePersian ?? "").trim() !== "" || r.fromDate || r.toDate);
  if (dateRows.length > 0) {
    const hit = dateRows.some((r) => {
      if ((r.FDatePersian ?? "").trim() !== "") {
        const from = (r.FDatePersian ?? "").trim();
        const to = (r.TDatePersian ?? "").trim() || from;
        return fa >= from && fa <= to;
      }
      const { fromDate, toDate } = r;
      return (!fromDate || now >= fromDate) && (!toDate || now <= toDate);
    });
    if (hit) {
      allow = false;
      reason += "Date,";
    }
  }

  // ── Day Control — @CurrDay BETWEEN DayNumber AND DayNumber (=برابری روز) ──
  const dayRows = rows.filter((r) => r.dayOfWeek != null);
  if (dayRows.length > 0 && dayRows.some((r) => r.dayOfWeek === crmDay)) {
    allow = false;
    reason += "Day,";
  }

  // ── Time Control — @CurrTime BETWEEN FTime AND TTime ──
  const timeRows = rows.filter((r) => (r.fromTime ?? "").trim() !== "");
  if (timeRows.length > 0 && timeRows.some((r) => nowHHmm >= r.fromTime && nowHHmm <= r.toTime)) {
    allow = false;
    reason += "Time,";
  }

  // ── IP Control — @CurrIPAddress = IPAddress ──
  const ipRows = rows.filter((r) => (r.ipAddress ?? "").trim() !== "");
  if (ipRows.length > 0 && ip != null && ipRows.some((r) => r.ipAddress === ip)) {
    allow = false;
    reason += "IPAddress,";
  }

  return { allow, reason };
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
    // ساعت/روز/تاریخ/IP ممنوع — بازسازی عیناً CRMspCheckUserLoginAllowedTimes
    const ip =
      req.headers
        .get("x-forwarded-for")
        ?.split(",")[0]
        .trim() ?? req.headers.get("x-real-ip");
    const { allow, reason } = await checkUserLoginAllowedTimes(user.id, ip);
    if (!allow) {
      const why = reason.replace(/,$/, "");
      return apiError(
        why ? `در تاریخ/روز/ساعت یا نشانی فعلی، اجازهٔ ورود به سیستم را ندارید. (${why})` : "در زمان فعلی اجازهٔ ورود به سیستم را ندارید.",
        403,
      );
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
