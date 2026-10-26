// E2E — جریان احراز هویت در مرورگر (بازسازی رفتار صفحهٔ ورود CRMIdeal)
import { test, expect } from "@playwright/test";

test.describe("ورود و نشست", () => {
  test("صفحهٔ ورود: فرم با فیلدهای نام کاربری/رمز رندر می‌شود", async ({ page }) => {
    await page.goto("/login");
    await expect(page.locator('input[placeholder="نام کاربری"]')).toBeVisible();
    await expect(page.locator('input[placeholder="رمز عبور"]')).toBeVisible();
    await expect(page.getByRole("button", { name: "ورود", exact: true })).toBeVisible();
  });

  test("ورود با اعتبار غلط → پیام خطا و ماندن در صفحهٔ ورود", async ({ page }) => {
    await page.goto("/login");
    await page.locator('input[placeholder="نام کاربری"]').fill("admin");
    await page.locator('input[placeholder="رمز عبور"]').fill("wrong-password");
    await page.getByRole("button", { name: "ورود", exact: true }).click();
    // پیام خطای سرور (خطا در احراز هویت) ظاهر می‌شود
    await expect(page.locator("text=/نام کاربری|رمز|خطا/i").first()).toBeVisible({ timeout: 15_000 });
    await expect(page).toHaveURL(/\/login/);
  });

  test("ورود موفق → هدایت به داشبورد و نمایش نام کاربر در پوسته", async ({ page }) => {
    await page.goto("/login");
    await page.locator('input[placeholder="نام کاربری"]').fill("admin");
    await page.locator('input[placeholder="رمز عبور"]').fill("admin123");
    await page.getByRole("button", { name: "ورود", exact: true }).click();
    await page.waitForURL((u) => !u.pathname.includes("login"), { timeout: 30_000 });
    // پوستهٔ اپ با نام کاربر «مدیر» رندر شده است
    await expect(page.getByText("مدیر", { exact: false }).first()).toBeVisible({ timeout: 20_000 });
  });

  test("کاربر بدون نشست به صفحهٔ محافظت‌شده → بازگشت به ورود", async ({ page }) => {
    await page.goto("/companies");
    await page.waitForURL((u) => u.pathname.includes("login"), { timeout: 20_000 });
  });

  test("خروج → نشست می‌بندد و مسیر محافظت‌شده دوباره به ورود می‌رود", async ({ page }) => {
    // ورود
    await page.goto("/login");
    await page.locator('input[placeholder="نام کاربری"]').fill("admin");
    await page.locator('input[placeholder="رمز عبور"]').fill("admin123");
    await page.getByRole("button", { name: "ورود", exact: true }).click();
    await page.waitForURL((u) => !u.pathname.includes("login"), { timeout: 30_000 });
    // خروج از منوی کاربر
    await page.request.post("/api/auth/logout");
    await page.goto("/companies");
    await page.waitForURL((u) => u.pathname.includes("login"), { timeout: 20_000 });
  });
});
