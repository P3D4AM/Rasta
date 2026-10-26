import { defineConfig, devices } from "@playwright/test";

/**
 * E2E مرورگر — رستا
 * سرور آزمایشی: scripts/e2e-server.mjs (دیتابیس تست + next dev روی پورت 3977 با distDir جدا)
 * دیتابیس توسعه هرگز لمس نمی‌شود.
 */
const PORT = Number(process.env.E2E_PORT ?? 3977);
const baseURL = `http://127.0.0.1:${PORT}`;

export default defineConfig({
  testDir: "./tests/e2e",
  timeout: 45_000,
  expect: { timeout: 10_000 },
  fullyParallel: false,
  workers: 1,
  retries: process.env.CI ? 1 : 0,
  reporter: process.env.CI ? [["list"], ["html", { open: "never" }]] : "list",
  use: {
    baseURL,
    trace: "retain-on-failure",
    screenshot: "only-on-failure",
    locale: "fa-IR",
  },
  projects: [
    { name: "chromium", use: { ...devices["Desktop Chrome"] } },
  ],
  webServer: {
    command: `node scripts/e2e-server.mjs ${PORT}`,
    url: `${baseURL}/api/auth/me`,
    reuseExistingServer: !process.env.CI,
    timeout: 180_000,
    stdout: "ignore",
    stderr: "pipe",
  },
});
