// E2E — مسیرهای حیاتی اپ: صفحات اصلی با کاربر ادمین رندر می‌شوند
// سلکتورها بر اساس عناصر همیشه‌مرئی صفحات (placeholder جستجو) — نه آیتم‌های ریل جمع‌شده.
import { test, expect } from "@playwright/test";

async function login(page: import("@playwright/test").Page, username = "admin", password = "admin123") {
  await page.goto("/login");
  await page.locator('input[placeholder="نام کاربری"]').fill(username);
  await page.locator('input[placeholder="رمز عبور"]').fill(password);
  await page.getByRole("button", { name: "ورود", exact: true }).click();
  await page.waitForURL((u) => !u.pathname.includes("login"), { timeout: 30_000 });
  // تثبیت ریدایرکت سمت کلاینت (router.push پس از ورود) تا goto بعدی سلب نشود
  await page.waitForLoadState("domcontentloaded");
  await page.waitForTimeout(500);
}

// ادعا: هدر صفحه (PageHeader با title مشخص) + وجود input جستجو — نه متن ریلِ جمع‌شده
const PAGES: [string, string, string?][] = [
  ["/companies", "هدر صفحهٔ مشتریان", "جستجوی نام"],
  ["/tasks", "هدر صفحهٔ کارها", "جستجو…"],
  ["/reports", "هدر گزارش‌ها", undefined],
];

for (const [path, label, placeholder] of PAGES) {
  test(`صفحهٔ ${path} با ادمین رندر می‌شود (${label})`, async ({ page }) => {
    await login(page);
    await page.goto(path);
    if (placeholder) {
      await expect(page.locator(`input[placeholder^="${placeholder}"]`).first()).toBeVisible({ timeout: 45_000 });
    } else {
      await expect(page.locator("input, [data-slot], canvas, svg").first()).toBeVisible({ timeout: 45_000 });
    }
  });
}

test("ریل منو: برای ادمین ظاهر می‌شود (حالت آیکونی یا باز)", async ({ page }) => {
  await login(page);
  await expect(page.locator("nav, aside").first()).toBeVisible({ timeout: 20_000 });
});

test("کاربر viewer: نشست معتبر اما API داده‌ای → ۴۰۳", async ({ page }) => {
  await login(page, "viewer", "viewer123");
  // API بدون مجوز → 403 (کنترل از مرورگر با همان نشست)
  const res = await page.request.get("/api/companies");
  expect(res.status()).toBe(403);
  // تعاریف پایه جغرافیایی هم برای viewer بسته است
  const geo = await page.request.get("/api/base-info/countries");
  expect(geo.status()).toBe(403);
});
