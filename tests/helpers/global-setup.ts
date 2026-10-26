/**
 * globalSetup تست یکپارچه‌سازی:
 *   1) دیتابیس آزمایشی ایزوله می‌سازد (SQLite تازه + prisma db push)
 *   2) seed قطعی و مستقل تست‌ها را می‌کارد (کاربران با مجوز شناخته‌شده)
 *   3) سرور Next را روی پورت آزاد با distDir جدا spawn می‌کند
 *   4) پایانی: سرور می‌بندد و فایل‌های موقت پاک می‌شوند
 *
 * هیچ‌وقت دیتابیس توسعه (custom.db) را لمس نمی‌کند — مسیر و URL از
 * tests/.tmp جدا می‌آید و به فرآیند سرور هم همان URL تزریق می‌شود.
 */
import { spawn, spawnSync, type ChildProcess } from "node:child_process";
import { mkdirSync, rmSync, existsSync, writeFileSync, readdirSync, readFileSync } from "node:fs";
import net from "node:net";
import path from "node:path";
import { fileURLToPath } from "node:url";

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), "../..");
const TMP = path.join(ROOT, "tests/.tmp");
const DB_PATH = path.join(TMP, "test.db");
const DB_URL = `file:${DB_PATH}`;
const AUTH_SECRET = "rasta-test-secret-for-integration-only";
const RUNTIME_JSON = path.join(TMP, "runtime.json");
// distDir یکتا-به-ازای-اجرای: قفل dev نکست (dev/lock) بین اجراها نمی‌ماند و
// اجرای هم‌زمان با سرور توسعه (.next) یا اجراهای قبلیِ نیمه‌کاره تداخل ندارد.
const DIST_DIR = `.next-test-${process.pid}`;

let server: ChildProcess | null = null;
let log: string[] = [];

function freePort(): Promise<number> {
  return new Promise((resolve, reject) => {
    const srv = net.createServer();
    srv.unref();
    srv.on("error", reject);
    srv.listen(0, "127.0.0.1", () => {
      const addr = srv.address();
      const port = typeof addr === "object" && addr ? addr.port : 0;
      srv.close(() => resolve(port));
    });
  });
}

function waitFor(url: string, timeoutMs = 90_000): Promise<void> {
  const started = Date.now();
  return new Promise((resolve, reject) => {
    const tick = async () => {
      if (Date.now() - started > timeoutMs) return reject(new Error(`server not ready at ${url}`));
      try {
        const res = await fetch(url);
        if (res.status > 0) return resolve();
      } catch {
        /* not up yet */
      }
      setTimeout(tick, 500);
    };
    tick();
  });
}

function killServer() {
  if (!server) return;
  const kids = spawnSync("bash", ["-c", `pgrep -P ${server.pid} || true`], { encoding: "utf8" });
  // درخت فرآیند را از پایین می‌بندیم (next dev → فرآیند‌های فرزند)
  if (kids.stdout) {
    for (const pid of kids.stdout.split("\n").filter(Boolean).reverse()) {
      try { process.kill(Number(pid), "SIGTERM"); } catch { /* already gone */ }
    }
  }
  try { server.kill("SIGTERM"); } catch { /* already gone */ }
  server = null;
}

export default async function globalSetup(ctx: { provide: (key: string, value: unknown) => void }) {
  try {
    return await globalSetupInner(ctx);
  } catch (err) {
    console.error("[global-setup] REAL ERROR:", err instanceof Error ? err.message : String(err));
    if (server) {
      console.error("[global-setup] server log tail:\n" + log.slice(-4000).join(""));
      killServer();
    }
    throw err;
  }
}

async function globalSetupInner(ctx: { provide: (key: string, value: unknown) => void }) {
  rmSync(TMP, { recursive: true, force: true });
  mkdirSync(TMP, { recursive: true });

  // 1) اسکیمای دیتابیس آزمایشی
  const push = spawnSync("bunx", ["prisma", "db", "push", "--skip-generate", "--accept-data-loss"], {
    cwd: ROOT,
    env: { ...process.env, DATABASE_URL: DB_URL },
    encoding: "utf8",
    timeout: 180_000,
  });
  if (push.status !== 0) {
    throw new Error(`prisma db push failed:\n${push.stdout}\n${push.stderr}`);
  }

  // 2) seed قطعی تست
  const seed = spawnSync("bun", ["tests/fixtures/seed-test.ts"], {
    cwd: ROOT,
    env: { ...process.env, DATABASE_URL: DB_URL },
    encoding: "utf8",
    timeout: 120_000,
  });
  if (seed.status !== 0) {
    throw new Error(`test seed failed:\n${seed.stdout}\n${seed.stderr}`);
  }

  // 3) سرور روی پورت آزاد + distDir جدا
  // نکتهٔ حیاتی: باید با node اجرا شود نه bun — موتور query پرایسما (ماژول نسخه‌دار
  // @prisma/client-<hash>) زیر runtime بون resolve نمی‌شود و همهٔ مسیرها ۵۰۰ می‌گیرند.
  const port = await freePort();
  const baseURL = `http://127.0.0.1:${port}`;
  // next dev فایل tsconfig.json را بازنویسی می‌کند (افزودن include دیست‌دیر) —
  // محتوای قبلی را نگه می‌داریم و در teardown بازگردانیم تا ردپا باقی نماند.
  const tsconfigPath = path.join(ROOT, "tsconfig.json");
  const tsconfigBefore = readFileSync(tsconfigPath, "utf8");
  server = spawn("node", ["node_modules/next/dist/bin/next", "dev", "-p", String(port)], {
    cwd: ROOT,
    env: {
      ...process.env,
      DATABASE_URL: DB_URL,
      AUTH_SECRET,
      RASTA_TEST_DIST_DIR: DIST_DIR,
      NEXT_TELEMETRY_DISABLED: "1",
    },
    stdio: ["ignore", "pipe", "pipe"],
    detached: true,
  });
  log = [];
  server.stdout?.on("data", (d) => log.push(String(d)));
  server.stderr?.on("data", (d) => log.push(String(d)));

  await waitFor(`${baseURL}/api/auth/me`, 120_000);
  // گرم‌کردن مسیرهای مورد تست: اولین کامپایل on-demand کند است و از تایم‌اوت تست‌ها می‌خورد
  for (const p of ["/api/auth/login", "/api/base-info/countries", "/api/base-info/provinces", "/api/base-info/cities", "/api/companies", "/api/roles"]) {
    try {
      await fetch(baseURL + p, { method: "POST", headers: { "Content-Type": "application/json" }, body: "{}" });
    } catch { /* ignore */ }
  }

  // 4) در اختیار تست‌ها
  ctx.provide("BASE_URL", baseURL);
  ctx.provide("AUTH_SECRET", AUTH_SECRET);
  if (existsSync(RUNTIME_JSON)) rmSync(RUNTIME_JSON, { force: true });
  writeFileSync(RUNTIME_JSON, JSON.stringify({ baseURL, AUTH_SECRET }));

  return () => {
    killServer();
    try {
      if (server) {
        const guard = spawnSync("bash", ["-c", `sleep 1; pgrep -f "next dev -p ${port}" | xargs -r kill -9 || true`], { encoding: "utf8" });
        void guard;
      }
    } catch { /* best effort */ }
    rmSync(TMP, { recursive: true, force: true });
    // بازگرداندن tsconfig (next dev آن را بازنویسی می‌کند)
    try { writeFileSync(tsconfigPath, tsconfigBefore); } catch { /* best effort */ }
    // پاک‌سازی distDir این اجرا + اجراهای قبلی نیمه‌کاره (الگوی مخصوص خود تست)
    for (const d of [DIST_DIR]) rmSync(path.join(ROOT, d), { recursive: true, force: true });
    try {
      for (const name of readdirSync(ROOT)) {
        if (/^\.next-test-\d+$/.test(name)) rmSync(path.join(ROOT, name), { recursive: true, force: true });
      }
    } catch { /* best effort */ }
  };
}
