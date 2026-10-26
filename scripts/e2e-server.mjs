/**
 * سرور E2E — آماده‌سازی دیتابیس آزمایشی + اجرای next dev روی پورت دلخواه.
 * usage: node scripts/e2e-server.mjs <port>
 * معادل همان خط لولهٔ tests/helpers/global-setup.ts ولی مستقل از vitest (برای playwright).
 */
import { spawnSync, spawn } from "node:child_process";
import { rmSync, mkdirSync, writeFileSync, readFileSync } from "node:fs";
import path from "node:path";
import { fileURLToPath } from "node:url";

const PORT = Number(process.argv[2] ?? 3977);
const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), "..");
const TMP = path.join(ROOT, "tests/.tmp");
const DB_PATH = path.join(TMP, "test.db");
const DB_URL = `file:${DB_PATH}`;
const AUTH_SECRET = "rasta-test-secret-for-integration-only";
const DIST_DIR = `.next-test-${process.pid}`;

rmSync(TMP, { recursive: true, force: true });
mkdirSync(TMP, { recursive: true });

const run = (cmd, args, extraEnv = {}) => {
  const r = spawnSync(cmd, args, {
    cwd: ROOT,
    env: { ...process.env, ...extraEnv },
    encoding: "utf8",
    stdio: "inherit",
    timeout: 240_000,
  });
  if (r.status !== 0) {
    console.error(`[e2e-server] ${cmd} ${args.join(" ")} failed (${r.status})`);
    process.exit(1);
  }
};

run("bunx", ["prisma", "db", "push", "--skip-generate", "--accept-data-loss"], { DATABASE_URL: DB_URL });
run("bun", ["tests/fixtures/seed-test.ts"], { DATABASE_URL: DB_URL });
writeFileSync(path.join(TMP, "runtime.json"), JSON.stringify({ baseURL: `http://127.0.0.1:${PORT}`, AUTH_SECRET }));

// نگه‌داشتن tsconfig اولیه و بازگرداندنش در خروج (next dev بازنویسیش می‌کند)
const tsconfigPath = path.join(ROOT, "tsconfig.json");
const tsconfigBefore = readFileSync(tsconfigPath, "utf8");
const cleanup = () => {
  try {
    writeFileSync(tsconfigPath, tsconfigBefore);
    rmSync(path.join(ROOT, DIST_DIR), { recursive: true, force: true });
  } catch { /* best effort */ }
};
process.on("exit", cleanup);
process.on("SIGINT", () => { cleanup(); process.exit(0); });
process.on("SIGTERM", () => { cleanup(); process.exit(0); });

// اجرای سرور (جایگزین فرآیند — سیگنال‌ها مستقیم می‌رسند)
const server = spawn("node", ["node_modules/next/dist/bin/next", "dev", "-p", String(PORT)], {
  cwd: ROOT,
  env: {
    ...process.env,
    DATABASE_URL: DB_URL,
    AUTH_SECRET,
    RASTA_TEST_DIST_DIR: DIST_DIR,
    NEXT_TELEMETRY_DISABLED: "1",
  },
  stdio: "inherit",
});
server.on("exit", (code) => process.exit(code ?? 0));
