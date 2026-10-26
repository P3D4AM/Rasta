import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * عناوین پروژهٔ ممنوع برای کاربر — بازسازی جدول CrmProjectsForbiddenForUser خود CRMIdeal
 * (کاتالوگ SQL: SPهای CRMspSelectCrmProjectsForbiddenForUser / NotForbiddenForUser + کوئری فرم‌ها).
 *
 * نکتهٔ نگاشت: در اورجینال ستون اتصال CrmUserId از جنس int بود؛ در رستا کاربران cuid دارند
 * و ستون rastaUserId (فقط رستا) نقش اتصال را دارد. مجوز: در اورجینال این مدیریت داخل فرم
 * تعریف کاربر بود؛ نام action دقیق اورجینال حفظ نشده → actEditMoreInfo رستا (بدون جعل نام اورجینال).
 *
 * GET              → لیست عناوین ممنوع کاربر
 * POST {title}     → افزودن عنوان ممنوع
 * DELETE ?all=1    → حذف همه
 * DELETE ?title=…  → حذف یک عنوان
 */
export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actView");
    const { id } = await params;
    const rows = await db.crmProjectsForbiddenForUser.findMany({
      where: { rastaUserId: id },
      orderBy: { ProjectsForbiddenForUserID: "asc" },
    });
    return json({ rows });
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actEditMoreInfo");
    const { id } = await params;
    const user = await db.user.findUnique({ where: { id } });
    if (!user) return apiError("کاربر یافت نشد.", 404);
    const body = await req.json().catch(() => null);
    const title = String(body?.title ?? "").trim();
    if (!title) return apiError("عنوان الزامی است.", 400);

    const dup = await db.crmProjectsForbiddenForUser.findFirst({ where: { rastaUserId: id, ForbiddenProjectTitle: title } });
    if (dup) return apiError("این عنوان قبلاً برای کاربر ممنوع شده است.", 409);

    const now = new Date();
    const created = await db.crmProjectsForbiddenForUser.create({
      data: {
        rastaUserId: id,
        ForbiddenProjectTitle: title,
        // ستون‌های حسابرسی اورجینال — عیناً پر می‌شوند (NOT NULL در اسکیمای اورجینال)
        FirstRegisterDate: now,
        FirstRegisterDatePersian: "",
        FirstRegisterUserId: 0,
        UserId: 0,
        Year1: 0,
        Month1: 0,
        RegisterDate: now,
        RegisterDatePersian: "",
        GUId: crypto.randomUUID(),
      },
    });
    return json(created, 201);
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actEditMoreInfo");
    const { id } = await params;
    const url = new URL(req.url);
    const title = url.searchParams.get("title");
    if (url.searchParams.get("all") === "1") {
      const cnt = await db.crmProjectsForbiddenForUser.count({ where: { rastaUserId: id } });
      await db.crmProjectsForbiddenForUser.deleteMany({ where: { rastaUserId: id } });
      return json({ deleted: cnt });
    }
    if (title) {
      await db.crmProjectsForbiddenForUser.deleteMany({ where: { rastaUserId: id, ForbiddenProjectTitle: title } });
      return json({ deleted: 1 });
    }
    return apiError("پارامتر title یا all=1 لازم است.", 400);
  });
}
