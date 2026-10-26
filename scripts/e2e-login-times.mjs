#!/usr/bin/env node
/**
 * E2E رفتاری — بازسازی عیناً CRMspCheckUserLoginAllowedTimes:
 * سنجه‌ها:
 *  1. بدون قاعده → ورود آزاد
 *  2. قاعدهٔ ساعتِ ممنوطِ پوشش‌دهندهٔ «اکنون» → بلاک با دلیل (Time)
 *  3. قاعدهٔ ساعتِ خارج از «اکنون» → ورود آزاد (اثبات چرخش معنا: پنجره = ممنوع، نه مجاز)
 *  4. قاعدهٔ روزِ امروز → بلاک با دلیل Day (انباشت دلیل: Day,Time)
 *  5. حذف همه → ورود آزاد
 */
const BASE = "http://localhost:3000";
const adminCreds = { username: "admin", password: "admin123" };
const targetCreds = { username: "sales1", password: "sales123" };

let failures = 0;
function assert(cond, label) {
  console.log(`${cond ? "PASS" : "FAIL"} — ${label}`);
  if (!cond) failures++;
}

function nowHHmm() {
  const d = new Date();
  return `${String(d.getHours()).padStart(2, "0")}:${String(d.getMinutes()).padStart(2, "0")}`;
}
function shiftHHmm(mins) {
  const d = new Date();
  d.setMinutes(d.getMinutes() + mins);
  return `${String(d.getHours()).padStart(2, "0")}:${String(d.getMinutes()).padStart(2, "0")}`;
}

async function post(path, body, cookie) {
  const res = await fetch(BASE + path, {
    method: "POST",
    headers: { "Content-Type": "application/json", ...(cookie ? { Cookie: cookie } : {}) },
    body: JSON.stringify(body),
  });
  const text = await res.text();
  let data = null;
  try { data = JSON.parse(text); } catch { data = text; }
  return { status: res.status, data, cookie: res.headers.get("set-cookie") };
}

async function login(creds) {
  const r = await post("/api/auth/login", creds);
  return r;
}

function errMsg(r) {
  if (typeof r.data === "string") return r.data;
  return (r.data && (r.data.error || r.data.message)) || JSON.stringify(r.data);
}

async function main() {
  // ── admin session ──
  const a = await login(adminCreds);
  assert(a.status === 200, `ورود ادمین 200 (got ${a.status})`);
  const adminCookie = (a.cookie || "").split(";")[0];

  // یافتن شناسهٔ sales1
  const usersRes = await fetch(BASE + "/api/users", { headers: { Cookie: adminCookie } });
  const users = await usersRes.json();
  const list = users.rows || users.users || users.data || users;
  const target = (Array.isArray(list) ? list : []).find((u) => u.username === "sales1");
  assert(!!target, "یافتن کاربر sales1");
  const uid = target.id;

  const base = `/api/users/${uid}/login-times`;
  // پاک‌سازی اولیه
  await fetch(BASE + `${base}?all=1`, { method: "DELETE", headers: { Cookie: adminCookie } });

  // ── ۱. بدون قاعده ──
  let t = await login(targetCreds);
  assert(t.status === 200, "۱) بدون قاعده → ورود آزاد");

  // ── ۲. پنجرهٔ ممنوعِ پوشش‌دهندهٔ اکنون (۲۴ ساعت) ──
  let r = await post(base, { fromTime: "00:00", toTime: "23:59" }, adminCookie);
  assert(r.status === 201, "۲-الف) ثبت قاعدهٔ ساعت ممنوع ۰۰:۰۰-۲۳:۵۹");
  t = await login(targetCreds);
  const blocked = t.status === 403;
  assert(blocked, "۲-ب) ورود داخل پنجرهٔ ممنوع → رد (403)");
  if (blocked) {
    const m = errMsg(t);
    const hasTime = m.includes("Time");
    assert(hasTime, `۲-ج) دلیل شامل Time است — پیام: «${m}»`);
  }
  await fetch(BASE + `${base}?all=1`, { method: "DELETE", headers: { Cookie: adminCookie } });

  // ── ۳. پنجرهٔ ممنوعِ خارج از اکنون (۲ ساعت بعد، ۳۰ دقیقه‌ای) ──
  const from = shiftHHmm(30);
  const to = shiftHHmm(60);
  r = await post(base, { fromTime: from, toTime: to }, adminCookie);
  assert(r.status === 201, `۳-الف) ثبت قاعدهٔ ${from}-${to} (آینده)`);
  t = await login(targetCreds);
  assert(t.status === 200, "۳-ب) پنجرهٔ ممنوعِ خارج از اکنون → ورود آزاد (معنا = ممنوع، نه مجاز)");
  await fetch(BASE + `${base}?all=1`, { method: "DELETE", headers: { Cookie: adminCookie } });

  // ── ۴. روز امروز + ساعت ممنوع هم‌زمان → انباشت دلیل ──
  const crmDay = (new Date().getDay() + 1) % 7; // شنبه=0 … جمعه=6
  r = await post(base, { dayOfWeek: crmDay, fromTime: "00:00", toTime: "23:59" }, adminCookie);
  assert(r.status === 201, "۴-الف) ثبت قاعدهٔ روزِ امروز + تمام‌روز");
  t = await login(targetCreds);
  const m4 = t.status === 403 ? errMsg(t) : "";
  assert(t.status === 403 && /Day/.test(m4) && /Time/.test(m4), `۴-ب) انباشت دلیل Day+Time — «${m4}»`);

  // ── ۵. حذف همه ──
  const del = await fetch(BASE + `${base}?all=1`, { method: "DELETE", headers: { Cookie: adminCookie } });
  assert(del.status === 200, "۵-الف) حذف همهٔ قواعد");
  t = await login(targetCreds);
  assert(t.status === 200, "۵-ب) پس از حذف → ورود آزاد");

  console.log(failures === 0 ? "\nALL PASS ✅" : `\n${failures} FAILURE(S) ❌`);
  process.exit(failures === 0 ? 0 : 1);
}

main().catch((e) => { console.error("CRASH:", e); process.exit(2); });
