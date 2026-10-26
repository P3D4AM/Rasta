// Rasta CRM — سرویس تعاریف پایه (گروه جغرافیایی: کشور/استان/شهر)
// ═══════════════════════════════════════════════════════════════════════════
// بازسازی رفتاری بر اساس شواهد (نه حدس):
//  • ApiBaseInfoController.cs (دیکامپایل) — قرارداد اکشن‌ها، پیام‌ها، الگوی ServiceResult
//  • Apisp{Select,Insert,Update,Delete}{Country,Province,City} — متن کامل از statements.pack مالک
//  • CompanyInfoController.CompanyDefine{Country,Province,City}* (دیکامپایل) — رفتار اپ داخلی:
//    چک‌های کد تکراری/عددی/نام خالی + چک وابستگی حذف + گیت‌های DynamicAuthorize
//  • پیام‌های فارسی عیناً از satellite DLL (Resources.resources.dll / CRMIdealApi.resources.dll fa-IR)
//    استخراج شدند (اسکریپت scripts/dotnet_resx.py سند روش است).
// انحرافات مستند:
//  1) SPها جدول‌های *_Lang را هم می‌نویسند/پاک می‌کنند — رستا جدول ترجمه ندارد (فارسی-اول).
//  2) ستون‌های UserId/FirstRegisterUserId اصلی int هستند و cuid کاربر رستا را نگه نمی‌دارند؛
//     نگاشت با ستون‌های rasta{First}RegisterUserId (الگوی مستند CrmProjectsForbiddenForUser).
//  3) ApiBaseInfo احراز هویت user/pass در بدنه دارد — معادل رستا نشست + requirePerm است.
import { db } from "@/lib/db";
import type { SessionUser } from "@/lib/auth";
import { gregorianToJalali } from "@/lib/jalali";
import type { Prisma } from "@prisma/client";

// ── پیام‌های عیناً از منابع (fa-IR satellite) — هیچ‌کدوم بازنویسی/ترجمه مجدد نشده ──
export const LEGACY_MESSAGES = {
  redundancy: "از این آیتم در جایی استفاده شده و شما اجازه حذف آن را ندارید", // Messages.RedundancyMessage
  emptyName: (label: string) => `${label} را وارد کنید.`, // Messages.CheckEmpty{Country,Province,City}
  duplicateCode: (label: string) => `کد ${label} تکراری می باشد`, // Messages.CheckDuplicate{Country,Province,City}Code
  codeDigit: (label: string) => `کد ${label} باید به صورت عددی وارد شود`, // Messages.Check{Country,Province,City}CodeDigit
  missingId: (label: string) => `شناسه ${label} وارد نشده است.`, // ApiBaseInfo Messages.ErrorItemIdIsNotEntered
  notFound: (label: string) => `${label} یافت نشد.`, // نگاشت کد SP: {Country,Province}NotFound
  genericError: "خطا در انجام عملیات، لطفا مجددا سعی نمایید.", // Messages.ErrorDoneOperationTryAgain
} as const;

type GeoKind = "country" | "province" | "city";

type GeoMeta = {
  kind: GeoKind;
  /** برچسب فارسی موجودیت — از Labels.fa-IR (Country=کشور, Province=استان, City=شهر) */
  label: string;
  /** فرم مجوز CRUD (actPost/actDelete) */
  form: "frmDefineCountry" | "frmDefineProvince" | "frmDefineCity";
  /** اکشن گیتِ مشاهدهٔ گرید روی frmMain (CompanyDefineCountry(int type) → frmMain×actDefine*) */
  defineAct: "actDefineCountry" | "actDefineProvince" | "actDefineCity";
};

export const GEO_META: Record<GeoKind, GeoMeta> = {
  country: { kind: "country", label: "کشور", form: "frmDefineCountry", defineAct: "actDefineCountry" },
  province: { kind: "province", label: "استان", form: "frmDefineProvince", defineAct: "actDefineProvince" },
  city: { kind: "city", label: "شهر", form: "frmDefineCity", defineAct: "actDefineCity" },
};

// ── ابزار ممیزی (بازسازی ApispInsert*: RegisterDatePersian=yyyyMMdd شمسی، Year1، Month1) ──

function nowAudit() {
  const now = new Date();
  const [jy, jm, jd] = gregorianToJalali(now.getFullYear(), now.getMonth() + 1, now.getDate());
  return {
    year1: jy,
    month1: jm,
    registerDatePersian: `${jy}${String(jm).padStart(2, "0")}${String(jd).padStart(2, "0")}`,
  };
}

/** checkIsNumber خود CRMIdeal (CompanyInfoController): همهٔ نویسه‌ها رقم باشند. */
export function legacyIsNumericCode(code: string): boolean {
  if (!code) return false;
  for (const ch of code) if (!/[0-9]/.test(ch)) return false;
  return true;
}

function userName(user: { lastName: string; firstName: string } | null | undefined): string {
  // SP: ISNULL(LName,'') + ' ' + ISNULL(FName,'')
  if (!user) return "";
  return `${user.lastName ?? ""} ${user.firstName ?? ""}`.trim();
}

// ── اعتبارسنجی مشترک کد (S7): تکراری (با استثنای خود رکورد در ویرایش) + عددی ──

async function validateCode(
  kind: GeoKind,
  code: string,
  excludeId: number | null
): Promise<string | null> {
  const meta = GEO_META[kind];
  if (!code) return null; // کد اختیاری است — چک فقط وقتی وارد شده (رفتار اورجینال)
  const where: Prisma.CountryWhereInput | Prisma.ProvinceWhereInput | Prisma.CityWhereInput =
    kind === "country"
      ? { CountryCode: code, ...(excludeId ? { CountryID: { not: excludeId } } : {}) }
      : kind === "province"
        ? { ProvinceCode: code, ...(excludeId ? { ProvinceID: { not: excludeId } } : {}) }
        : { CityCode: code, ...(excludeId ? { CityID: { not: excludeId } } : {}) };
  const dup =
    kind === "country"
      ? await db.country.findFirst({ where: where as Prisma.CountryWhereInput })
      : kind === "province"
        ? await db.province.findFirst({ where: where as Prisma.ProvinceWhereInput })
        : await db.city.findFirst({ where: where as Prisma.CityWhereInput });
  if (dup) return LEGACY_MESSAGES.duplicateCode(meta.label);
  if (!legacyIsNumericCode(code)) return LEGACY_MESSAGES.codeDigit(meta.label);
  return null;
}

// ── SELECT — شکل خروجی مطابق ApispSelect* (ستون‌ها با ISNULL + نام‌های کاربران) ──

async function userNamesFor(rows: { rastaUserId?: string | null; rastaFirstRegisterUserId?: string | null }[]) {
  const uids = new Set<string>();
  for (const r of rows) {
    if (r.rastaUserId) uids.add(r.rastaUserId);
    if (r.rastaFirstRegisterUserId) uids.add(r.rastaFirstRegisterUserId);
  }
  const arr = [...uids];
  const users = arr.length
    ? await db.user.findMany({ where: { id: { in: arr } }, select: { id: true, lastName: true, firstName: true } })
    : [];
  return new Map(users.map((u) => [u.id, u]));
}

type GeoRow = {
  id: number;
  code: string;
  name: string;
  description: string;
  userId: number;
  registerDate: Date;
  registerDatePersian: string;
  firstRegisterDate: Date | null;
  firstRegisterDatePersian: string;
  firstRegisterUser: string;
  editUser: string;
  countryId?: number | null;
  country?: string;
  countryCode?: string;
  provinceId?: number;
  province?: string;
  provinceCode?: string;
};

export async function listGeo(
  kind: GeoKind,
  filters: { parentId?: number; id?: number } = {}
): Promise<GeoRow[]> {
  if (kind === "country") {
    const rows = await db.country.findMany({
      where: filters.id ? { CountryID: filters.id } : undefined,
      orderBy: { CountryID: "asc" },
    });
    const users = await userNamesFor(rows);
    return rows.map((r) => ({
      id: r.CountryID,
      code: r.CountryCode ?? "",
      name: r.Country ?? "",
      description: r.CountryDescription ?? "",
      userId: r.UserId,
      registerDate: r.RegisterDate,
      registerDatePersian: r.RegisterDatePersian ?? "",
      firstRegisterDate: r.FirstRegisterDate,
      firstRegisterDatePersian: r.FirstRegisterDatePersian ?? "",
      firstRegisterUser: userName(users.get(r.rastaFirstRegisterUserId ?? "")),
      editUser: userName(users.get(r.rastaUserId ?? "")),
    }));
  }

  if (kind === "province") {
    // join نام کشورِ پدر (ApispSelectProvince: ستون Country/CountryCode از جدول Country)
    const rows = await db.province.findMany({
      where: {
        ...(filters.id ? { ProvinceID: filters.id } : {}),
        ...(filters.parentId ? { CountryId: filters.parentId } : {}),
      },
      orderBy: { ProvinceID: "asc" },
    });
    const [users, countries] = await Promise.all([
      userNamesFor(rows),
      db.country.findMany({ select: { CountryID: true, Country: true, CountryCode: true } }),
    ]);
    const cMap = new Map(countries.map((c) => [c.CountryID, c]));
    return rows.map((r) => {
      const c = cMap.get(r.CountryId);
      return {
        id: r.ProvinceID,
        countryId: r.CountryId,
        code: r.ProvinceCode ?? "",
        name: r.Province ?? "",
        description: r.Description ?? "",
        country: c?.Country ?? "",
        countryCode: c?.CountryCode ?? "",
        userId: r.UserId,
        registerDate: r.RegisterDate,
        registerDatePersian: r.RegisterDatePersian ?? "",
        firstRegisterDate: r.FirstRegisterDate,
        firstRegisterDatePersian: r.FirstRegisterDatePersian ?? "",
        firstRegisterUser: userName(users.get(r.rastaFirstRegisterUserId ?? "")),
        editUser: userName(users.get(r.rastaUserId ?? "")),
      };
    });
  }

  // city — ApispSelectCity: Province/ProvinceCode + CountryID/Country/CountryCode (زنجیرهٔ دو سطحی)
  const rows = await db.city.findMany({
    where: {
      ...(filters.id ? { CityID: filters.id } : {}),
      ...(filters.parentId ? { ProvinceId: filters.parentId } : {}),
    },
    orderBy: { CityID: "asc" },
  });
  const provinces = await db.province.findMany({ select: { ProvinceID: true, Province: true, ProvinceCode: true, CountryId: true } });
  const pMap = new Map(provinces.map((p) => [p.ProvinceID, p]));
  const cIds = [...new Set(provinces.map((p) => p.CountryId))];
  const [users, countries] = await Promise.all([
    userNamesFor(rows),
    db.country.findMany({ where: { CountryID: { in: cIds } }, select: { CountryID: true, Country: true, CountryCode: true } }),
  ]);
  const cMap = new Map(countries.map((c) => [c.CountryID, c]));
  return rows.map((r) => {
    const p = pMap.get(r.ProvinceId);
    const c = p ? cMap.get(p.CountryId) : undefined;
    return {
      id: r.CityID,
      provinceId: r.ProvinceId,
      code: r.CityCode ?? "",
      name: r.City ?? "",
      description: r.Description ?? "",
      province: p?.Province ?? "",
      provinceCode: p?.ProvinceCode ?? "",
      countryId: p?.CountryId ?? null,
      country: c?.Country ?? "",
      countryCode: c?.CountryCode ?? "",
      userId: r.UserId,
      registerDate: r.RegisterDate,
      registerDatePersian: r.RegisterDatePersian ?? "",
      firstRegisterDate: r.FirstRegisterDate,
      firstRegisterDatePersian: r.FirstRegisterDatePersian ?? "",
      firstRegisterUser: userName(users.get(r.rastaFirstRegisterUserId ?? "")),
      editUser: userName(users.get(r.rastaUserId ?? "")),
    };
  });
}

// ── INSERT ──

export type GeoCreateInput = {
  name?: unknown;
  code?: unknown;
  description?: unknown;
  parentId?: unknown;
  countryId?: unknown;
  provinceId?: unknown;
};

export async function createGeo(kind: GeoKind, body: GeoCreateInput, user: SessionUser) {
  const meta = GEO_META[kind];
  const name = typeof body.name === "string" ? body.name.trim() : "";
  const code = typeof body.code === "string" ? body.code.trim() : "";
  const description = typeof body.description === "string" ? body.description.trim() : "";

  // نام الزامی (CheckEmpty{X} — پیام عیناً از منبع)
  if (!name) return { error: LEGACY_MESSAGES.emptyName(meta.label), status: 400 as const };

  // اعتبارسنجی کد (تکراری/عددی) — CompanyDefine{X}Insert
  const codeErr = await validateCode(kind, code, null);
  if (codeErr) return { error: codeErr, status: 400 as const };

  const audit = nowAudit();

  if (kind === "country") {
    const row = await db.country.create({
      data: {
        Country: name,
        CountryCode: code || null,
        CountryDescription: description || null,
        UserId: 0,
        Year1: audit.year1,
        Month1: audit.month1,
        RegisterDate: new Date(),
        RegisterDatePersian: audit.registerDatePersian,
        FirstRegisterUserId: 0,
        FirstRegisterDate: new Date(),
        FirstRegisterDatePersian: audit.registerDatePersian,
        rastaUserId: user.id,
        rastaFirstRegisterUserId: user.id,
      },
    });
    return { data: (await listGeo("country", { id: row.CountryID }))[0], status: 201 as const };
  }

  if (kind === "province") {
    // S2: MissingCountryId / CountryNotFound
    const countryId = Number(body.countryId ?? body.parentId);
    if (!Number.isFinite(countryId) || countryId <= 0) {
      return { error: LEGACY_MESSAGES.missingId(meta.label === "استان" ? "کشور" : meta.label), status: 400 as const };
    }
    const parent = await db.country.findUnique({ where: { CountryID: countryId } });
    if (!parent) return { error: LEGACY_MESSAGES.notFound("کشور"), status: 400 as const };
    const row = await db.province.create({
      data: {
        CountryId: countryId,
        Province: name,
        ProvinceCode: code || null,
        Description: description || null,
        UserId: 0,
        Year1: audit.year1,
        Month1: audit.month1,
        RegisterDate: new Date(),
        RegisterDatePersian: audit.registerDatePersian,
        FirstRegisterUserId: 0,
        FirstRegisterDate: new Date(),
        FirstRegisterDatePersian: audit.registerDatePersian,
        rastaUserId: user.id,
        rastaFirstRegisterUserId: user.id,
      },
    });
    return { data: (await listGeo("province", { id: row.ProvinceID }))[0], status: 201 as const };
  }

  // city
  const provinceId = Number(body.provinceId ?? body.parentId);
  if (!Number.isFinite(provinceId) || provinceId <= 0) {
    return { error: LEGACY_MESSAGES.missingId("استان"), status: 400 as const };
  }
  const parent = await db.province.findUnique({ where: { ProvinceID: provinceId } });
  if (!parent) return { error: LEGACY_MESSAGES.notFound("استان"), status: 400 as const };
  const row = await db.city.create({
    data: {
      ProvinceId: provinceId,
      City: name,
      CityCode: code || null,
      Description: description || null,
      UserId: 0,
      Year1: audit.year1,
      Month1: audit.month1,
      RegisterDate: new Date(),
      RegisterDatePersian: audit.registerDatePersian,
      FirstRegisterUserId: 0,
      FirstRegisterDate: new Date(),
      FirstRegisterDatePersian: audit.registerDatePersian,
      rastaUserId: user.id,
      rastaFirstRegisterUserId: user.id,
    },
  });
  return { data: (await listGeo("city", { id: row.CityID }))[0], status: 201 as const };
}

// ── UPDATE ──

export async function updateGeo(kind: GeoKind, id: number, body: GeoCreateInput, user: SessionUser) {
  const meta = GEO_META[kind];
  const name = typeof body.name === "string" ? body.name.trim() : "";
  const code = typeof body.code === "string" ? body.code.trim() : "";
  const description = typeof body.description === "string" ? body.description.trim() : "";

  const existingCountry = kind === "country" ? await db.country.findUnique({ where: { CountryID: id } }) : null;
  const existingProvince = kind === "province" ? await db.province.findUnique({ where: { ProvinceID: id } }) : null;
  const existingCity = kind === "city" ? await db.city.findUnique({ where: { CityID: id } }) : null;
  const exists = existingCountry ?? existingProvince ?? existingCity;
  if (!exists) return { error: LEGACY_MESSAGES.notFound(meta.label), status: 404 as const };

  if (name === "" && "name" in body) {
    return { error: LEGACY_MESSAGES.emptyName(meta.label), status: 400 as const };
  }

  const prevCode =
    existingCountry?.CountryCode ?? existingProvince?.ProvinceCode ?? existingCity?.CityCode ?? "";
  const effectiveCode = code || prevCode;
  const codeErr = await validateCode(kind, effectiveCode, id);
  if (codeErr) return { error: codeErr, status: 400 as const };

  const audit = nowAudit();

  if (kind === "country") {
    await db.country.update({
      where: { CountryID: id },
      data: {
        ...(name ? { Country: name } : {}),
        ...(code ? { CountryCode: code } : {}),
        ...(body.description !== undefined ? { CountryDescription: description || null } : {}),
        Year1: audit.year1,
        Month1: audit.month1,
        RegisterDate: new Date(),
        RegisterDatePersian: audit.registerDatePersian,
        rastaUserId: user.id,
      },
    });
    return { data: (await listGeo("country", { id }))[0], status: 200 as const };
  }

  if (kind === "province") {
    if (body.countryId !== undefined || body.parentId !== undefined) {
      const countryId = Number(body.countryId ?? body.parentId);
      if (!Number.isFinite(countryId) || countryId <= 0) {
        return { error: LEGACY_MESSAGES.missingId("کشور"), status: 400 as const };
      }
      const parent = await db.country.findUnique({ where: { CountryID: countryId } });
      if (!parent) return { error: LEGACY_MESSAGES.notFound("کشور"), status: 400 as const };
      await db.province.update({ where: { ProvinceID: id }, data: { CountryId: countryId } });
    }
    await db.province.update({
      where: { ProvinceID: id },
      data: {
        ...(name ? { Province: name } : {}),
        ...(code ? { ProvinceCode: code } : {}),
        ...(body.description !== undefined ? { Description: description || null } : {}),
        Year1: audit.year1,
        Month1: audit.month1,
        RegisterDate: new Date(),
        RegisterDatePersian: audit.registerDatePersian,
        rastaUserId: user.id,
      },
    });
    return { data: (await listGeo("province", { id }))[0], status: 200 as const };
  }

  // city
  if (body.provinceId !== undefined || body.parentId !== undefined) {
    const provinceId = Number(body.provinceId ?? body.parentId);
    if (!Number.isFinite(provinceId) || provinceId <= 0) {
      return { error: LEGACY_MESSAGES.missingId("استان"), status: 400 as const };
    }
    const parent = await db.province.findUnique({ where: { ProvinceID: provinceId } });
    if (!parent) return { error: LEGACY_MESSAGES.notFound("استان"), status: 400 as const };
    await db.city.update({ where: { CityID: id }, data: { ProvinceId: provinceId } });
  }
  await db.city.update({
    where: { CityID: id },
    data: {
      ...(name ? { City: name } : {}),
      ...(code ? { CityCode: code } : {}),
      ...(body.description !== undefined ? { Description: description || null } : {}),
      Year1: audit.year1,
      Month1: audit.month1,
      RegisterDate: new Date(),
      RegisterDatePersian: audit.registerDatePersian,
      rastaUserId: user.id,
    },
  });
  return { data: (await listGeo("city", { id }))[0], status: 200 as const };
}

// ── DELETE — وابستگی‌ها مطابق CompanyDefine{X}Delete (S4) ──

export async function deleteGeo(kind: GeoKind, id: number) {
  const meta = GEO_META[kind];

  if (kind === "country") {
    const row = await db.country.findUnique({ where: { CountryID: id } });
    if (!row) return { error: LEGACY_MESSAGES.notFound(meta.label), status: 404 as const };
    // Province.Count>0 || CrmCompany.Count>0 || CrmCompanyPersons.Count>0
    // (مدل‌های فعال رستا: Company.cmpCountryId و Contact.prsCountryId)
    const [provinces, companies, persons] = await Promise.all([
      db.province.count({ where: { CountryId: id } }),
      db.company.count({ where: { cmpCountryId: id } }),
      db.contact.count({ where: { prsCountryId: id } }),
    ]);
    if (provinces > 0 || companies > 0 || persons > 0) {
      return { error: LEGACY_MESSAGES.redundancy, status: 409 as const };
    }
    await db.country.delete({ where: { CountryID: id } });
    return { data: { deleted: true }, status: 200 as const };
  }

  if (kind === "province") {
    const row = await db.province.findUnique({ where: { ProvinceID: id } });
    if (!row) return { error: LEGACY_MESSAGES.notFound(meta.label), status: 404 as const };
    // City.Count>0 || CrmCompany.Count>0 || CrmCompanyPersons.Count>0
    const [cities, companies, persons] = await Promise.all([
      db.city.count({ where: { ProvinceId: id } }),
      db.company.count({ where: { cmpProvinceId: id } }),
      db.contact.count({ where: { prsProvinceId: id } }),
    ]);
    if (cities > 0 || companies > 0 || persons > 0) {
      return { error: LEGACY_MESSAGES.redundancy, status: 409 as const };
    }
    await db.province.delete({ where: { ProvinceID: id } });
    return { data: { deleted: true }, status: 200 as const };
  }

  // city — CrmCompany.Count>0 || CrmCompanyPersons.Count>0
  const row = await db.city.findUnique({ where: { CityID: id } });
  if (!row) return { error: LEGACY_MESSAGES.notFound(meta.label), status: 404 as const };
  const [companies, persons] = await Promise.all([
    db.company.count({ where: { cmpCityId: id } }),
    db.contact.count({ where: { prsCityId: id } }),
  ]);
  if (companies > 0 || persons > 0) {
    return { error: LEGACY_MESSAGES.redundancy, status: 409 as const };
  }
  await db.city.delete({ where: { CityID: id } });
  return { data: { deleted: true }, status: 200 as const };
}
