#!/usr/bin/env node
/**
 * E2E رفتاری — «عناوین پروژهٔ ممنوع» بازسازی CrmProjectsForbiddenForUser:
 *  ۱) لیست عناوین forMe بدون ممنوعیت → همهٔ عناوین
 *  ۲) ممنوع کردن یک عنوان برای sales2 → titles?forMe=1 (با نشست sales2) آن عنوان را ندارد
 *  ۳) لیست پروژه‌های sales2 → پروژه‌های با عنوان ممنوع حذف شده‌اند
 *  ۴) ساخت پروژه با عنوان ممنوع توسط sales2 → 403
 *  ۵) حذف ممنوعیت → همه‌چیز برمی‌گردد
 *  ۶) ادمین → ممنوعیت بی‌اثر (عناوین و پروژه‌ها کامل)
 */
const BASE = "http://localhost:3000";
let failures = 0;
function assert(cond, label) {
  console.log(`${cond ? "PASS" : "FAIL"} — ${label}`);
  if (!cond) failures++;
}

async function post(path, body, cookie) {
  const res = await fetch(BASE + path, {
    method: "POST",
    headers: { "Content-Type": "application/json", ...(cookie ? { Cookie: cookie } : {}) },
    body: JSON.stringify(body),
  });
  let data = null;
  try { data = await res.json(); } catch { /* text */ }
  return { status: res.status, data, cookie: res.headers.get("set-cookie") };
}
async function get(path, cookie) {
  const res = await fetch(BASE + path, { headers: cookie ? { Cookie: cookie } : {} });
  let data = null;
  try { data = await res.json(); } catch { /* text */ }
  return { status: res.status, data };
}

async function login(creds) { return post("/api/auth/login", creds); }

async function main() {
  const admin = await login({ username: "admin", password: "admin123" });
  assert(admin.status === 200, "ورود ادمین");
  const aCookie = (admin.cookie || "").split(";")[0];
  const s2 = await login({ username: "sales2", password: "sales123" });
  assert(s2.status === 200, "ورود sales2");
  const s2Cookie = (s2.cookie || "").split(";")[0];

  // یافتن sales2 و یک عنوان از تعاریف
  const users = await get("/api/users", aCookie);
  const s2row = (users.data.rows || []).find((u) => u.username === "sales2");
  assert(!!s2row, "یافتن sales2");
  const titlesAll = await get("/api/project-defs/titles", aCookie);
  const titles = (titlesAll.data.rows || []).map((t) => t.title);
  assert(titles.length > 0, `تعاریف عنوان موجود (${titles.length} عدد)`);

  // پاک‌سازی ممنوعیت‌های قبلی
  await fetch(`${BASE}/api/users/${s2row.id}/forbidden-titles?all=1`, { method: "DELETE", headers: { Cookie: aCookie } });

  // ۱) بدون ممنوعیت → forMe کامل
  let t = await get("/api/project-defs/titles?forMe=1", s2Cookie);
  const beforeCount = (t.data.rows || []).length;
  assert(beforeCount === titles.length, `۱) بدون ممنوعیت → همهٔ ${titles.length} عنوان`);

  // یک پروژه با عنوان اول برای شرکت موجود بسازیم تا سنجهٔ ۳ معنا داشته باشد
  const comps = await get("/api/companies", aCookie);
  const comp = (comps.data.rows || [])[0];
  assert(!!comp, "وجود شرکت seed");
  const sg = await get("/api/project-defs/statusGroups", aCookie);
  const sgId = (sg.data.rows || []).filter((g) => g.isActive)[0]?.id;
  const victimTitle = titles[0];
  const prj = await post("/api/projects", { title: victimTitle, statusGroupId: sgId, companyId: comp.id }, aCookie);
  assert(prj.status === 201, `ساخت پروژهٔ آزمایشی با عنوان «${victimTitle}»`);

  // ۲) ممنوع کردن عنوان
  const forbid = await post(`/api/users/${s2row.id}/forbidden-titles`, { title: victimTitle }, aCookie);
  assert(forbid.status === 201, "۲-الف) ثبت عنوان ممنوع برای sales2");
  t = await get("/api/project-defs/titles?forMe=1", s2Cookie);
  const after = (t.data.rows || []).map((r) => r.title);
  assert(!after.includes(victimTitle) && after.length === beforeCount - 1, "۲-ب) titles?forMe=1 عنوان ممنوع را ندارد");

  // ۳) لیست پروژه‌های sales2 بدون پروژهٔ ممنوع
  const prjs = await get("/api/projects", s2Cookie);
  const rawTitles = (prjs.data.rows || []).map((p) => p.rawTitle);
  assert(!rawTitles.includes(victimTitle), "۳) پروژهٔ عنوان ممنوع از لیست sales2 حذف شد");
  const prjsAdmin = await get("/api/projects", aCookie);
  const rawTitlesAdmin = (prjsAdmin.data.rows || []).map((p) => p.rawTitle);
  assert(rawTitlesAdmin.includes(victimTitle), "۶-الف) ادمین همان پروژه را می‌بیند");

  // ۴) ساخت پروژه با عنوان ممنوع توسط sales2 → 403
  const attempt = await post("/api/projects", { title: victimTitle, statusGroupId: sgId, companyId: comp.id }, s2Cookie);
  assert(attempt.status === 403, "۴) ساخت پروژه با عنوان ممنوع → 403");

  // ۵) حذف ممنوعیت → بازگشت
  const del = await fetch(`${BASE}/api/users/${s2row.id}/forbidden-titles?all=1`, { method: "DELETE", headers: { Cookie: aCookie } });
  assert(del.status === 200, "۵-الف) حذف ممنوعیت‌ها");
  t = await get("/api/project-defs/titles?forMe=1", s2Cookie);
  assert((t.data.rows || []).length === titles.length, "۵-ب) forMe دوباره کامل");

  // پاک‌سازی پروژهٔ آزمایشی
  const pid = prj.data?.id;
  if (pid) await fetch(`${BASE}/api/projects/${pid}`, { method: "DELETE", headers: { Cookie: aCookie } });

  console.log(failures === 0 ? "\nALL PASS ✅" : `\n${failures} FAILURE(S) ❌`);
  process.exit(failures === 0 ? 0 : 1);
}

main().catch((e) => { console.error("CRASH:", e); process.exit(2); });
