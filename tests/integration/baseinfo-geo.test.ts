// تست یکپارچه‌سازی — بازسازی رفتار تعاریف جغرافیایی (Country/Province/City)
// ═══ منابع شواهد (غیرحدسی — هر ادعا به سند وصل است) ═══
//  S1) ApiBaseInfoController.cs (decompiled) — الگوی اکشن + پیام‌های ApiBaseInfo (fa-IR از satellite DLL):
//      ErrorItemIsNotEntered={0} وارد نگردیده است! / ErrorItemIdIsNotEntered=شناسه {0} وارد نشده است.
//  S2) ApispInsertProvince/ApispInsertCity/ApispUpdate* (statements.pack) — کدهای خطای
//      MissingCountryId/CountryNotFound و MissingProvinceId/ProvinceNotFound → درجِ فرزند با پدر ناموجود ممنوع.
//  S3) ApispSelect{Country,Province,City} — ستون‌های خروجی با ISNULL و نام‌های FirstRegisterUser/EditUser
//      (ISNULL(LName,'')+' '+ISNULL(FName,'')) و برای Province ستون Country/CountryCode؛ برای City
//      ستون Province/ProvinceCode/CountryID/Country/CountryCode.
//  S4) CompanyInfoController.CompanyDefine{Country,Province,City}Delete (decompiled) —
//      پیش از حذف وابستگی چک می‌شود:
//        Country: Province.Count>0 || CrmCompany.Count>0 || CrmCompanyPersons.Count>0
//        Province: City.Count>0 || CrmCompany.Count>0 || CrmCompanyPersons.Count>0
//        City: CrmCompany.Count>0 || CrmCompanyPersons.Count>0
//      اگر وابستگی باشد → Messages.RedundancyMessage =
//      «از این آیتم در جایی استفاده شده و شما اجازه حذف آن را ندارید» (استخراج‌شده از Resources.resources.dll fa-IR).
//      سپس CRMspDelete* (فقط رکورد + ردیف‌های _Lang را حذف می‌کند — رستا جدول _Lang ندارد: انحراف مستند).
//  S5) دسترسی: فرم‌های frmDefineCountry/frmDefineProvince/frmDefineCity × actView/actInsert/actEdit/actDelete
//      (DynamicAuthorize در CompanyInfoController) — در رستا با requirePerm همان کلیدها.
//  S6) ستون‌های ممیزی درج (ApispInsert* + CompanyDefineCountryInsert): UserId, Year1, Month1,
//      RegisterDate, RegisterDatePersian (yyyyMMdd شمسی), FirstRegisterUserId, FirstRegisterDate,
//      FirstRegisterDatePersian.
//  S7) اعتبارسنجی‌های رابط داخلی (CompanyInfoController.CompanyDefine{Country,Province,City}Insert/Edit —
//      چون رستا جایگزین اپ داخلی است، مسیر داخلی ملاک رفتار UI است):
//        کد تکراری → «کد {موجودیت} تکراری می باشد» (چک در ویرایش با استثنای خودِ رکورد)
//        کد غیرعددی → «کد {موجودیت} باید به صورت عددی وارد شود» (checkIsNumber — کد = پیش‌شمارهٔ تلفنی)
//        نام خالی → «{موجودیت} را وارد کنید.»
//      (پیام‌ها عیناً از Resources.resources.dll fa-IR استخراج شدند.)
import { describe, it, expect, beforeAll } from "vitest";
import { makeClient, ADMIN, OPERATOR } from "../helpers/integration-env";

const REDUNDANCY = "از این آیتم در جایی استفاده شده و شما اجازه حذف آن را ندارید";

type Row = Record<string, unknown>;

async function adminClient() {
  const c = makeClient();
  const r = await c.login(ADMIN.username, ADMIN.password);
  expect(r.status).toBe(200);
  return c;
}

let ids: Record<string, number | undefined> = {};

beforeAll(async () => {
  // شناسه‌های seed را از لیست می‌خوانیم (قطعی نسبت به seed، نه نسبت به ترتیب پاسخ)
  const c = await adminClient();
  const countries = (await c.req("/api/base-info/countries")).data as Row[];
  ids.iran = countries.find((x) => x.code === "98")?.id as number | undefined;
  ids.orphan = countries.find((x) => x.code === "999")?.id as number | undefined;
  ids.alone = countries.find((x) => x.code === "888")?.id as number | undefined;
  const provinces = (await c.req("/api/base-info/provinces")).data as Row[];
  ids.tehran = provinces.find((p) => p.name === "تهران")?.id as number | undefined;
  ids.orphanProvince = provinces.find((p) => p.name === "استان یتیم")?.id as number | undefined;
  const cities = (await c.req("/api/base-info/cities")).data as Row[];
  ids.tehranCity = cities.find((x) => x.name === "تهران")?.id as number | undefined;
});

describe("SELECT — شکل خروجی مطابق ApispSelect* (S3)", () => {
  it("کشورها: id/code/name/description + نام‌های ثبت/ویرایش‌کننده (S3/S6)", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/countries");
    expect(r.status).toBe(200);
    const rows = r.data as Row[];
    const iran = rows.find((x) => x.code === "98");
    expect(iran).toBeTruthy();
    expect(iran!.name).toBe("ایران");
    // S3: نام کامل ویرایش‌کننده = «نام خانوادگی + فاصله + نام» کاربر (seed: مدیر سیستم)
    expect(iran!.editUser).toBe("سیستم مدیر");
    expect(iran!.firstRegisterUser).toBe("سیستم مدیر");
    expect(iran!.registerDatePersian).toBe("14040715");
  });

  it("استان‌ها: ستون کشورِ پدر (country/countryCode) join می‌شود (S3)", async () => {
    const c = await adminClient();
    const rows = (await c.req("/api/base-info/provinces")).data as Row[];
    const tehran = rows.find((x) => x.name === "تهران");
    expect(tehran).toBeTruthy();
    expect(tehran!.country).toBe("ایران");
    expect(tehran!.countryCode).toBe("98");
  });

  it("شهرها: ستون استان و کشور (province/provinceCode/country) (S3)", async () => {
    const c = await adminClient();
    const rows = (await c.req("/api/base-info/cities")).data as Row[];
    const tehran = rows.find((x) => x.name === "تهران");
    expect(tehran).toBeTruthy();
    expect(tehran!.province).toBe("تهران");
    expect(tehran!.provinceCode).toBe("21");
    expect(tehran!.country).toBe("ایران");
  });

  it("فیلتر: استان‌های یک کشور ?countryId= (ApispSelectProvince WHERE CountryId)", async () => {
    const c = await adminClient();
    const rows = (await c.req(`/api/base-info/provinces?countryId=${ids.iran}`)).data as Row[];
    expect(rows.length).toBeGreaterThan(0);
    for (const p of rows) expect(p.country).toBe("ایران");
  });
});

describe("INSERT — اعتبارسنجی و ممیزی (S1/S2/S6/S7)", () => {
  it("کشور بدون نام → ۴۰۰ با پیام «کشور را وارد کنید.» (S7 — CheckEmptyCountry)", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/countries", { method: "POST", body: JSON.stringify({ code: "39" }) });
    expect(r.status).toBe(400);
    expect((r.data as Row).error).toBe("کشور را وارد کنید.");
  });

  it("کد کشور تکراری → ۴۰۰ (S7 — CheckDuplicateCountryCode)", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/countries", { method: "POST", body: JSON.stringify({ code: "98", name: "تکراری" }) });
    expect(r.status).toBe(400);
    expect((r.data as Row).error).toBe("کد کشور تکراری می باشد");
  });

  it("کد کشور غیرعددی → ۴۰۰ (S7 — CheckCountryCodeDigit: کد = پیش‌شمارهٔ تلفنی)", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/countries", { method: "POST", body: JSON.stringify({ code: "IT", name: "ایتالیا" }) });
    expect(r.status).toBe(400);
    expect((r.data as Row).error).toBe("کد کشور باید به صورت عددی وارد شود");
  });

  it("درج کشور موفق → رکورد با ستون‌های ممیزی (S6)", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/countries", {
      method: "POST",
      body: JSON.stringify({ code: "39", name: "ایتالیا", description: "تست درج" }),
    });
    expect(r.status).toBe(201);
    const row = r.data as Row;
    expect(row.name).toBe("ایتالیا");
    expect(row.registerDatePersian).toMatch(/^1[34]\d{6}$/); // yyyyMMdd شمسی
    expect(row.firstRegisterUser).toBe("سیستم مدیر");
    expect(row.editUser).toBe("سیستم مدیر");
    // پاک‌سازی
    await c.req(`/api/base-info/countries/${row.id}`, { method: "DELETE" });
  });

  it("استان بدون کشور → ۴۰۰ (MissingCountryId)؛ کشور ناموجود → ۴۰۰ (CountryNotFound) (S2)", async () => {
    const c = await adminClient();
    const noId = await c.req("/api/base-info/provinces", { method: "POST", body: JSON.stringify({ name: "بدون پدر" }) });
    expect(noId.status).toBe(400);
    expect((noId.data as Row).error).toContain("کشور");

    const badId = await c.req("/api/base-info/provinces", {
      method: "POST",
      body: JSON.stringify({ countryId: 99999999, name: "پدر غایب" }),
    });
    expect(badId.status).toBe(400);
    expect((badId.data as Row).error).toContain("کشور");
  });

  it("شهر با استان ناموجود → ۴۰۰ (ProvinceNotFound) (S2)", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/cities", {
      method: "POST",
      body: JSON.stringify({ provinceId: 99999999, name: "شهر بی‌استان" }),
    });
    expect(r.status).toBe(400);
    expect((r.data as Row).error).toContain("استان");
  });
});

describe("UPDATE — قواعد S2/S7", () => {
  it("شناسه ناموجود → ۴۰۴", async () => {
    const c = await adminClient();
    const r = await c.req("/api/base-info/countries/99999999", {
      method: "PUT",
      body: JSON.stringify({ name: "غایب" }),
    });
    expect(r.status).toBe(404);
  });

  it("ویرایش موفق → نام/کد جدید + به‌روزرسانی ممیزی ویرایش (S6)", async () => {
    const c = await adminClient();
    const created = (await c.req("/api/base-info/countries", {
      method: "POST",
      body: JSON.stringify({ code: "49", name: "آلمان" }),
    }).then((x) => x.data)) as Row;
    const upd = await c.req(`/api/base-info/countries/${created.id}`, {
      method: "PUT",
      body: JSON.stringify({ name: "آلمان فدرال", description: "ویرایش شد" }),
    });
    expect(upd.status).toBe(200);
    const row = upd.data as Row;
    expect(row.name).toBe("آلمان فدرال");
    expect(row.editUser).toBe("سیستم مدیر");
    await c.req(`/api/base-info/countries/${created.id}`, { method: "DELETE" });
  });

  it("ویرایش بدون تغییر کد → تکراری حساب نمی‌شود (استثنای خودِ رکورد — S7)", async () => {
    const c = await adminClient();
    const created = (await c.req("/api/base-info/countries", {
      method: "POST",
      body: JSON.stringify({ code: "33", name: "فرانسه" }),
    }).then((x) => x.data)) as Row;
    const upd = await c.req(`/api/base-info/countries/${created.id}`, {
      method: "PUT",
      body: JSON.stringify({ code: "33", description: "همان کد" }),
    });
    expect(upd.status).toBe(200);
    await c.req(`/api/base-info/countries/${created.id}`, { method: "DELETE" });
  });

  it("ویرایش با کدِ متعلق به کشور دیگر → ۴۰۰ تکراری (S7)", async () => {
    const c = await adminClient();
    const created = (await c.req("/api/base-info/countries", {
      method: "POST",
      body: JSON.stringify({ code: "7", name: "روسیه" }),
    }).then((x) => x.data)) as Row;
    const upd = await c.req(`/api/base-info/countries/${created.id}`, {
      method: "PUT",
      body: JSON.stringify({ code: "98" }),
    });
    expect(upd.status).toBe(400);
    expect((upd.data as Row).error).toBe("کد کشور تکراری می باشد");
    await c.req(`/api/base-info/countries/${created.id}`, { method: "DELETE" });
  });

  it("استان با کشورِ ناموجود در ویرایش → ۴۰۰ (CountryNotFound) (S2)", async () => {
    const c = await adminClient();
    const r = await c.req(`/api/base-info/provinces/${ids.orphanProvince}`, {
      method: "PUT",
      body: JSON.stringify({ countryId: 99999999 }),
    });
    expect(r.status).toBe(400);
  });
});

describe("DELETE — وابستگی‌ها (S4 — بازسازی CompanyInfoController)", () => {
  it("کشورِ دارای استان → ۴۰۹ + RedundancyMessage", async () => {
    const c = await adminClient();
    const r = await c.req(`/api/base-info/countries/${ids.iran}`, { method: "DELETE" });
    expect(r.status).toBe(409);
    expect((r.data as Row).error).toBe(REDUNDANCY);
  });

  it("کشور بی‌استان و بی‌وابستگی → حذف موفق", async () => {
    const c = await adminClient();
    const r = await c.req(`/api/base-info/countries/${ids.alone}`, { method: "DELETE" });
    expect(r.status).toBe(200);
    const rows = (await c.req("/api/base-info/countries")).data as Row[];
    expect(rows.find((x) => x.code === "888")).toBeUndefined();
  });

  it("استانِ دارای شهر → ۴۰۹ + RedundancyMessage", async () => {
    const c = await adminClient();
    const r = await c.req(`/api/base-info/provinces/${ids.tehran}`, { method: "DELETE" });
    expect(r.status).toBe(409);
    expect((r.data as Row).error).toBe(REDUNDANCY);
  });

  it("استانِ بی‌شهر → حذف موفق", async () => {
    const c = await adminClient();
    const del = await c.req(`/api/base-info/provinces/${ids.orphanProvince}`, { method: "DELETE" });
    expect(del.status).toBe(200);
  });

  it("شهرِ بدون وابستگی → حذف موفق", async () => {
    const c = await adminClient();
    const r = await c.req(`/api/base-info/cities/${ids.tehranCity}`, { method: "DELETE" });
    expect(r.status).toBe(200);
  });
});

describe("دسترسی — فرم‌های تعاریف جغرافیایی (S5)", () => {
  it("operator (دارای مجوز کامل جغرافیا) درج می‌کند؛ viewer → ۴۰۳", async () => {
    const op = makeClient();
    await op.login(OPERATOR.username, OPERATOR.password);
    const ok = await op.req("/api/base-info/countries", {
      method: "POST",
      body: JSON.stringify({ code: "971", name: "امارات" }),
    });
    expect(ok.status).toBe(201);
    await op.req(`/api/base-info/countries/${(ok.data as Row).id}`, { method: "DELETE" });

    const v = makeClient();
    await v.login("viewer", "viewer123");
    expect((await v.req("/api/base-info/countries", { method: "POST", body: JSON.stringify({ name: "x" }) })).status).toBe(403);
  });
});
