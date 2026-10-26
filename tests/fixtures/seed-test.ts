/**
 * Seed قطعی دیتابیس آزمایشی — فقط برای تست.
 * اجرا: bun tests/fixtures/seed-test.ts (DATABASE_URL باید به دیتابیس تست اشاره کند)
 *
 * اصول:
 *  - هیچ وابستگی به زمان «اکنون» برای سنجه‌های قطعی ندارد (تاریخ‌ها ثابت‌اند)
 *  - کاربران با مجوز شناخته‌شده: admin (isAdmin)، operator (مجوز تعاریف جغرافیایی)، viewer (فقط صفحهٔ اصلی)
 *  - دادهٔ جغرافیایی پایه: یک کشور/استان/شهر برای تست‌های وابستگی حذف
 */
import { PrismaClient } from "@prisma/client";
import { randomBytes, scryptSync } from "crypto";

const db = new PrismaClient();

function hashPassword(password: string): string {
  const salt = randomBytes(16).toString("hex");
  const hash = scryptSync(password, salt, 64).toString("hex");
  return `${salt}:${hash}`;
}

// تاریخ ثابت قطعی — 1404/07/15 (2025-10-06) — همهٔ رکوردهای seed همین تاریخ را دارند
const T0 = new Date("2025-10-06T10:00:00.000Z");

async function main() {
  // پاک‌سازی ترتیب‌دار (FK) — دیتابیس تازه است اما برای idempotency
  await db.user.deleteMany({});
  await db.role.deleteMany({});
  await db.rolePermission.deleteMany({});
  await db.country.deleteMany({});
  await db.province.deleteMany({});
  await db.city.deleteMany({});

  // ── نقش‌ها ──
  const roleFull = await db.role.create({
    data: { name: "تست-ادمین-کامل", description: "همهٔ مجوزها (معادل نقش ادمین غیر isAdmin)" },
  });
  const roleGeo = await db.role.create({
    data: { name: "تست-اپراتور-جغرافیا", description: "تعاریف جغرافیایی + فرم‌های پایه" },
  });
  const roleViewer = await db.role.create({
    data: { name: "تست-بازدید", description: "فقط صفحهٔ اصلی" },
  });

  const perms = (sets: [string, string[]][]) =>
    sets.flatMap(([formId, actions]) => actions.map((actionId) => ({ roleId: "", formId, actionId })));

  // اپراتور: فرم‌های پایه + تعاریف جغرافیایی (بازسازی گیت‌های CompanyInfoController:
  // مشاهدهٔ گرید = frmMain×actDefine{X}؛ ثبت/ویرایش = frmDefine{X}×actPost؛ حذف = actDelete)
  const geoPerms = perms([
    ["frmHomePage", ["actView"]],
    ["frmCompanyI", ["actView"]],
    ["frmMain", ["actDefineCountry", "actDefineProvince", "actDefineCity"]],
    ["frmDefineCountry", ["actInsert", "actPost", "actEdit", "actDelete"]],
    ["frmDefineProvince", ["actInsert", "actPost", "actEdit", "actDelete"]],
    ["frmDefineCity", ["actInsert", "actPost", "actEdit", "actDelete"]],
  ]).map((p) => ({ ...p, roleId: roleGeo.id }));
  await db.rolePermission.createMany({ data: geoPerms });

  const viewerPerms = perms([
    ["frmHomePage", ["actView"]],
  ]).map((p) => ({ ...p, roleId: roleViewer.id }));
  await db.rolePermission.createMany({ data: viewerPerms });

  const fullPerms = perms([
    ["frmHomePage", ["actView"]],
    ["frmMain", ["actDefineCountry", "actDefineProvince", "actDefineCity"]],
    ["frmDefineCountry", ["actInsert", "actPost", "actEdit", "actDelete"]],
    ["frmDefineProvince", ["actInsert", "actPost", "actEdit", "actDelete"]],
    ["frmDefineCity", ["actInsert", "actPost", "actEdit", "actDelete"]],
  ]).map((p) => ({ ...p, roleId: roleFull.id }));
  await db.rolePermission.createMany({ data: fullPerms });

  // ── کاربران ──
  const admin = await db.user.create({
    data: {
      username: "admin",
      passwordHash: hashPassword("admin123"),
      firstName: "مدیر",
      lastName: "سیستم",
      isAdmin: true,
      isActive: true,
      createdAt: T0,
    },
  });
  const operator = await db.user.create({
    data: {
      username: "operator",
      passwordHash: hashPassword("operator123"),
      firstName: "اپراتور",
      lastName: "تست",
      isAdmin: false,
      isActive: true,
      roleId: roleGeo.id,
      createdAt: T0,
    },
  });
  await db.user.create({
    data: {
      username: "viewer",
      passwordHash: hashPassword("viewer123"),
      firstName: "بازدید",
      lastName: "کننده",
      isAdmin: false,
      isActive: true,
      roleId: roleViewer.id,
      createdAt: T0,
    },
  });

  // ── دادهٔ جغرافیایی پایه (بازسازی ستون‌های اصلی Country/Province/City) ──
  // کشوری که استان دارد → حذفش باید Redundancy بخورد؛ استانِ بی‌شهر → قابل حذف
  // کد کشور عددی است مثل خود CRMIdeal (کد تلفنی کشور — چک checkIsNumber در CompanyInfoController)
  // ممیزی: rasta{First}RegisterUserId → cuid کاربر رستا (UserId اصلی int برای cuid جا ندارد)
  const iran = await db.country.create({
    data: {
      CountryCode: "98",
      Country: "ایران",
      CountryDescription: "جمهوری اسلامی ایران",
      UserId: 1,
      Year1: 1404,
      Month1: 7,
      RegisterDate: T0,
      RegisterDatePersian: "14040715",
      FirstRegisterUserId: 1,
      FirstRegisterDate: T0,
      FirstRegisterDatePersian: "14040715",
      rastaUserId: admin.id,
      rastaFirstRegisterUserId: admin.id,
    },
  });
  const orphanCountry = await db.country.create({
    data: {
      CountryCode: "999",
      Country: "کشور بی‌استان",
      UserId: 1,
      Year1: 1404,
      Month1: 7,
      RegisterDate: T0,
      RegisterDatePersian: "14040715",
      FirstRegisterUserId: 1,
      FirstRegisterDate: T0,
      FirstRegisterDatePersian: "14040715",
      rastaUserId: admin.id,
      rastaFirstRegisterUserId: admin.id,
    },
  });
  const aloneCountry = await db.country.create({
    data: {
      CountryCode: "888",
      Country: "کشور تنها",
      UserId: 1,
      Year1: 1404,
      Month1: 7,
      RegisterDate: T0,
      RegisterDatePersian: "14040715",
      FirstRegisterUserId: 1,
      FirstRegisterDate: T0,
      FirstRegisterDatePersian: "14040715",
      rastaUserId: admin.id,
      rastaFirstRegisterUserId: admin.id,
    },
  });
  const tehran = await db.province.create({
    data: {
      CountryId: iran.CountryID,
      ProvinceCode: "21",
      Province: "تهران",
      Description: "پایتخت",
      UserId: 1,
      Year1: 1404,
      Month1: 7,
      RegisterDate: T0,
      RegisterDatePersian: "14040715",
      FirstRegisterUserId: 1,
      FirstRegisterDate: T0,
      FirstRegisterDatePersian: "14040715",
      rastaUserId: admin.id,
      rastaFirstRegisterUserId: admin.id,
    },
  });
  await db.province.create({
    data: {
      CountryId: orphanCountry.CountryID,
      ProvinceCode: "911",
      Province: "استان یتیم",
      UserId: 1,
      Year1: 1404,
      Month1: 7,
      RegisterDate: T0,
      RegisterDatePersian: "14040715",
      FirstRegisterUserId: 1,
      FirstRegisterDate: T0,
      FirstRegisterDatePersian: "14040715",
      rastaUserId: admin.id,
      rastaFirstRegisterUserId: admin.id,
    },
  });
  await db.city.create({
    data: {
      ProvinceId: tehran.ProvinceID,
      CityCode: "21",
      City: "تهران",
      Description: "مرکز استان",
      UserId: 1,
      Year1: 1404,
      Month1: 7,
      RegisterDate: T0,
      RegisterDatePersian: "14040715",
      FirstRegisterUserId: 1,
      FirstRegisterDate: T0,
      FirstRegisterDatePersian: "14040715",
      rastaUserId: admin.id,
      rastaFirstRegisterUserId: admin.id,
    },
  });

  console.log(
    JSON.stringify({
      ok: true,
      users: { admin: admin.id, operator: operator.id },
      country: { iran: iran.CountryID, orphan: orphanCountry.CountryID, alone: aloneCountry.CountryID },
      provinceTehran: tehran.ProvinceID,
    })
  );
}

main()
  .catch((e) => {
    console.error(e);
    process.exit(1);
  })
  .finally(() => db.$disconnect());
