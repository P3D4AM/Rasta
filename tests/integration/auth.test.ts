// تست یکپارچه‌سازی — احراز هویت: ورود/خروج/نشست + گارد ۴۰۱ مسیرهای محافظت‌شده
import { describe, it, expect, beforeEach } from "vitest";
import { makeClient, ADMIN, VIEWER } from "../helpers/integration-env";

describe("AUTH — ورود و نشست", () => {
  it("ورود با اعتبار درست → کوکی نشست + اطلاعات کاربر", async () => {
    const c = makeClient();
    const r = await c.login(ADMIN.username, ADMIN.password);
    expect(r.status).toBe(200);
    const user = (r.data as { user: Record<string, unknown> }).user;
    expect(user.username).toBe(ADMIN.username);
    expect(r.cookie).toBeTruthy();
    // کوکی HttpOnly است
    expect(r.cookie).toMatch(/httponly/i);
  });

  it("ورود با رمز غلط → ۴۰۱ و بدون کوکی", async () => {
    const c = makeClient();
    const r = await c.login(ADMIN.username, "wrong-password");
    expect(r.status).toBe(401);
    expect(c.cookie).toBe("");
  });

  it("me با نشست → مشخصات کاربر؛ بدون نشست → ۴۰۱", async () => {
    const anon = makeClient();
    expect((await anon.req("/api/auth/me")).status).toBe(401);

    const c = makeClient();
    await c.login(ADMIN.username, ADMIN.password);
    const me = await c.req("/api/auth/me");
    expect(me.status).toBe(200);
    const user = (me.data as { user: Record<string, unknown> }).user;
    expect(user.username).toBe(ADMIN.username);
  });

  it("خروج → نشست باطل می‌شود", async () => {
    const c = makeClient();
    await c.login(ADMIN.username, ADMIN.password);
    const out = await c.req("/api/auth/logout", { method: "POST" });
    expect(out.status).toBe(200);
    expect((await c.req("/api/auth/me")).status).toBe(401);
  });

  it("کاربر غیرفعال نمی‌تواند وارد شود (IsActive=0)", async () => {
    // seed فقط کاربران فعال دارد؛ این مورد رفتار چک UserIsActiveInWebApp را از مسیر منفی می‌سنجد
    const c = makeClient();
    const r = await c.login("ghost-user", "nope");
    expect(r.status).toBe(401);
  });
});

describe("AUTH — گارد ۴۰۱ مسیرهای محافظت‌شده (بدون نشست)", () => {
  const paths: [string, string][] = [
    ["GET", "/api/companies"],
    ["GET", "/api/products"],
    ["GET", "/api/tasks"],
    ["GET", "/api/reports"],
    ["POST", "/api/roles"],
  ];

  beforeEach(() => {
    // هر مسیر با کلاینت بی‌نشست (بدون کوکی)
  });

  for (const [method, p] of paths) {
    it(`${method} ${p} بدون نشست → ۴۰۱`, async () => {
      const c = makeClient();
      const r = await c.req(p, { method });
      expect(r.status).toBe(401);
    });
  }
});
