import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { gregorianToJalali } from "@/lib/jalali";

/**
 * تعیین ساعت ورود — بازسازی UserLoginAllowedTimes خود CRMIdeal.
 * هر قاعده یک پنجرهٔ «ممنوع» است (اعمال در ورود: CRMspCheckUserLoginAllowedTimes — تاریخ/روز/ساعت/IP مستقل).
 * GET  → لیست قواعد کاربر
 * POST → افزودن قاعده (روز هفته null = هر روز) — هم‌زمان FDatePersian/TDatePersian کلید شمسی YYYYMMDD مثل خود محصول
 * DELETE ?all=1 → حذف همه قواعد
 */

const reHHmm = /^([01]\d|2[0-3]):[0-5]\d$/;

/** کلید شمسی YYYYMMDD از Date — مثل FDatePersian خود CRMIdeal (فرم Delphi هم‌زمان هر دو را پر می‌کرد). */
function faDateKey(d: Date | null): string | null {
  if (!d || isNaN(d.getTime())) return null;
  const [jy, jm, jd] = gregorianToJalali(d.getFullYear(), d.getMonth() + 1, d.getDate());
  return `${jy}${String(jm).padStart(2, "0")}${String(jd).padStart(2, "0")}`;
}

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actLoginAllowedTimes");
    const { id } = await params;
    const rows = await db.userLoginAllowedTime.findMany({ where: { userId: id }, orderBy: { createdAt: "asc" } });
    return json({ rows });
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actLoginAllowedTimes");
    const { id } = await params;
    const user = await db.user.findUnique({ where: { id } });
    if (!user) return apiError("کاربر یافت نشد.", 404);
    const body = await req.json().catch(() => null);
    const fromTime = String(body?.fromTime ?? "").trim();
    const toTime = String(body?.toTime ?? "").trim();
    if (!reHHmm.test(fromTime) || !reHHmm.test(toTime)) {
      return apiError("ساعت‌ها باید به شکل HH:mm باشند.", 400);
    }
    if (fromTime >= toTime) return apiError("ساعت پایان باید بعد از ساعت شروع باشد.", 400);
    const dayOfWeek = body?.dayOfWeek != null && body.dayOfWeek !== "" ? Number(body.dayOfWeek) : null;
    if (dayOfWeek != null && (dayOfWeek < 0 || dayOfWeek > 6)) {
      return apiError("روز هفته نامعتبر است (۰=شنبه … ۶=جمعه).", 400);
    }
    const fromDate = dateVal(body?.fromDate);
    const toDate = dateVal(body?.toDate);
    const created = await db.userLoginAllowedTime.create({
      data: {
        userId: id,
        dayOfWeek,
        fromDate,
        toDate,
        fromTime,
        toTime,
        ipAddress: clean(body?.ipAddress),
        FDatePersian: faDateKey(fromDate),
        TDatePersian: faDateKey(toDate),
      },
    });
    return json(created, 201);
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actLoginAllowedTimes");
    const { id } = await params;
    const url = new URL(req.url);
    if (url.searchParams.get("all") === "1") {
      // AllRemoveUserLoginAllowedTimes خود محصول
      const cnt = await db.userLoginAllowedTime.count({ where: { userId: id } });
      await db.userLoginAllowedTime.deleteMany({ where: { userId: id } });
      return json({ deleted: cnt });
    }
    return apiError("شناسه قاعده یا all=1 لازم است.", 400);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}

function dateVal(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(v as string);
  return isNaN(d.getTime()) ? null : d;
}
