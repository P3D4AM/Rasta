// خواندن پارامترهای زمان اجرای سرور آزمایشی (تولیدشده در globalSetup)
// first: inject() از vitest — fallback: tests/.tmp/runtime.json
import { readFileSync, existsSync } from "node:fs";
import path from "node:path";

type Runtime = { baseURL: string; AUTH_SECRET: string };

let cached: Runtime | null = null;

export function runtime(): Runtime {
  if (cached) return cached;
  const file = path.resolve(__dirname, "../.tmp/runtime.json");
  if (existsSync(file)) {
    cached = JSON.parse(readFileSync(file, "utf8")) as Runtime;
    return cached;
  }
  return {
    baseURL: process.env.RASTA_TEST_BASE_URL ?? "http://127.0.0.1:3999",
    AUTH_SECRET: process.env.AUTH_SECRET ?? "rasta-test-secret-for-integration-only",
  };
}

export type TestClient = ReturnType<typeof makeClient>;

/** کلاینت HTTP مینیمال با نگه‌داشتن کوکی نشست */
export function makeClient(baseURL = runtime().baseURL) {
  let cookie = "";
  const c = {
    get cookie() {
      return cookie;
    },
    set cookie(v: string) {
      cookie = v;
    },
    async req(pathname: string, init: RequestInit = {}): Promise<{ status: number; data: unknown; text: string; cookie: string | null }> {
      const res = await fetch(baseURL + pathname, {
        ...init,
        headers: {
          ...(init.body ? { "Content-Type": "application/json" } : {}),
          ...(cookie ? { Cookie: cookie } : {}),
          ...(init.headers ?? {}),
        },
      });
      const setCookie = res.headers.get("set-cookie");
      if (setCookie) cookie = setCookie.split(";")[0];
      const text = await res.text();
      let data: unknown = null;
      try {
        data = JSON.parse(text);
      } catch {
        data = text;
      }
      return { status: res.status, data, text, cookie: setCookie };
    },
    login(username: string, password: string) {
      return c.req("/api/auth/login", { method: "POST", body: JSON.stringify({ username, password }) });
    },
  };
  return c;
}

// نمونهٔ سراسری برای راحتی (کوکی جدا بین فایل‌های تست لازم نیست دوباره لاگین شود اما مستقل هم می‌شود ساخت)
export const client = makeClient();

// ── کاربران seed قطعی (tests/fixtures/seed-test.ts) ──
export const ADMIN = { username: "admin", password: "admin123" }; // ادمین سیستم — همهٔ مجوزها (isAdmin)
export const OPERATOR = { username: "operator", password: "operator123" }; // کاربر عملیاتی: فرم‌های پایه + تعاریف جغرافیایی
export const VIEWER = { username: "viewer", password: "viewer123" }; // فقط frmHomePage:actView — هیچ فرم داده‌ای
