#!/usr/bin/env node
/**
 * E2E رفتاری — بازسازی عیناً CRMspCheckUserLoginAllowedTimes (نسخهٔ نهایی V5 گام ۳۷۲۵ — whitelist):
 * «if there are some records for user in UserLoginAllowedTimes, then user can login to system by these records (just)»
 * سنجه‌ها:
 *  1. بدون قاعده → ورود آزاد
 *  2. قاعدهٔ ساعتِ پوشش‌دهندهٔ «اکنون» → ورود آزاد (پنجره = مجاز)
 *  3. قاعدهٔ ساعتِ خارج از «اکنون» → بلاک با دلیل Time (whitelist: تنها پنجره‌های ثبت‌شده)
 *  4. یک قاعده: روزِ فردا + پنجرهٔ ساعتِ آینده → هر دو بُعد رد → انباشت دلیل Day,Time
 *  5. استقلال ابعاد: روزِ امروز + ساعتِ آینده → فقط Time می‌بندد (Day باز)
 *  6. حذف همه → ورود آزاد
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
  return post("/api/auth/login", creds);
}

function errMsg(r) {
  if (typeof r.data === "string") return r.data;
  return (r.data && (r.data.error || r.data.message)) || JSON.stringify(r.data);
}

async function clearRules(base, cookie) {
  await fetch(BASE + `${base}?all=1`, { method: "DELETE", headers: { Cookie: cookie } });
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
  await clearRules(base, adminCookie);

  // ── ۱. بدون قاعده ──
  let t = await login(targetCreds);
  assert(t.status === 200, "۱) بدون قاعده → ورود آزاد");

  // ── ۲. پنجرهٔ مجازِ پوشش‌دهندهٔ اکنون (تمام‌روز) ──
  let r = await post(base, { fromTime: "00:00", toTime: "23:59" }, adminCookie);
  assert(r.status === 201, "۲-الف) ثبت قاعدهٔ ساعت مجاز ۰۰:۰۰-۲۳:۵۹");
  t = await login(targetCreds);
  assert(t.status === 200, "۲-ب) ورود داخل پنجرهٔ مجاز → آزاد (whitelist)");
  await clearRules(base, adminCookie);

  // ── ۳. پنجرهٔ مجازِ خارج از اکنون (۳۰ تا ۶۰ دقیقه بعد) ──
  const from = shiftHHmm(30);
  const to = shiftHHmm(60);
  r = await post(base, { fromTime: from, toTime: to }, adminCookie);
  assert(r.status === 201, `۳-الف) ثبت قاعدهٔ ${from}-${to} (آینده)`);
  t = await login(targetCreds);
  const blockedTime = t.status === 403;
  assert(blockedTime, "۳-ب) پنجرهٔ مجازِ خارج از اکنون → رد (403)");
  if (blockedTime) {
    const m = errMsg(t);
    assert(/Time/.test(m), `۳-ج) دلیل شامل Time است — پیام: «${m}»`);
  }
  await clearRules(base, adminCookie);

  // ── ۴. یک قاعده: روزِ فردا + پنجرهٔ ساعتِ آینده → هر دو بُعد رد → انباشت Day,Time ──
  const crmDay = (new Date().getDay() + 1) % 7; // شنبه=0 … جمعه=6 (امروز)
  const tomorrow = (crmDay + 1) % 7;
  r = await post(base, { dayOfWeek: tomorrow, fromTime: shiftHHmm(30), toTime: shiftHHmm(60) }, adminCookie);
  assert(r.status === 201, "۴-الف) ثبت قاعدهٔ روزِ فردا + ساعتِ آینده");
  t = await login(targetCreds);
  const m4 = errMsg(t);
  assert(t.status === 403 && /Day/.test(m4) && /Time/.test(m4), `۴-ب) انباشت دلیل Day+Time — «${m4}»`);
  await clearRules(base, adminCookie);

  // ── ۵. استقلال ابعاد: روزِ امروز + ساعتِ آینده → فقط بُعد ساعت می‌بندد (Day باز، Time بسته) ──
  r = await post(base, { dayOfWeek: crmDay, fromTime: shiftHHmm(30), toTime: shiftHHmm(60) }, adminCookie);
  assert(r.status === 201, "۵-الف) ثبت روزِ امروز + پنجرهٔ ساعتِ آینده");
  t = await login(targetCreds);
  const m5 = errMsg(t);
  assert(t.status === 403 && /Time/.test(m5) && !/Day/.test(m5), `۵-ب) فقط Time می‌بندد، Day باز است (استقلال ابعاد) — «${m5}»`);
  await clearRules(base, adminCookie);

  // ── ۶. حذف همه ──
  const del = await fetch(BASE + `${base}?all=1`, { method: "DELETE", headers: { Cookie: adminCookie } });
  assert(del.status === 200, "۶-الف) حذف همهٔ قواعد");
  t = await login(targetCreds);
  assert(t.status === 200, "۶-ب) پس از حذف → ورود آزاد");

  console.log(failures === 0 ? "\nALL PASS ✅" : `\n${failures} FAILURE(S) ❌`);
  process.exit(failures === 0 ? 0 : 1);
}

main().catch((e) => { console.error("CRASH:", e); process.exit(2); });
