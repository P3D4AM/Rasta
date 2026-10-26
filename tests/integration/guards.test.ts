// تست یکپارچه‌سازی — کنترل دسترسی: کاربر با نشستِ معتبر اما بدون مجوز فرم → ۴۰۳
// بازسازی معادل DynamicAuthorize خود CRMIdeal: نشست ≠ دسترسی؛ فرم×اکشن جدا چک می‌شود
import { describe, it, expect } from "vitest";
import { makeClient, OPERATOR, VIEWER } from "../helpers/integration-env";

describe("RBAC — تفکیک مجوز فرم×اکشن روی مسیرهای واقعی", () => {
  it("viewer (فقط frmHomePage) → ۴۰۳ روی مسیر داده‌ای", async () => {
    const c = makeClient();
    const login = await c.login(VIEWER.username, VIEWER.password);
    expect(login.status).toBe(200); // نشست دارد اما مجوز ندارد

    const r = await c.req("/api/companies");
    expect(r.status).toBe(403);
  });

  it("operator مجوز frmDefineCountry دارد → ۴۰۳ نمی‌خورد اما viewer می‌خورد", async () => {
    const op = makeClient();
    await op.login(OPERATOR.username, OPERATOR.password);
    const opR = await op.req("/api/base-info/countries");
    expect(opR.status).not.toBe(403); // ممکن است 200 باشد (لیست خالی/پر)

    const v = makeClient();
    await v.login(VIEWER.username, VIEWER.password);
    const vR = await v.req("/api/base-info/countries");
    expect(vR.status).toBe(403);
  });

  it("operator بدون مجوز فرم‌های مالی → ۴۰۳", async () => {
    const c = makeClient();
    await c.login(OPERATOR.username, OPERATOR.password);
    // operator فقط frmHomePage/frmCompanyI/تعاریف جغرافیایی دارد
    const r = await c.req("/api/roles");
    expect(r.status).toBe(403);
  });

  it("دسترسی سطح اکشن: operator فقط actView+actInsert+actEdit+actDelete جغرافیا دارد؛ viewer حتی actView ندارد", async () => {
    const v = makeClient();
    await v.login(VIEWER.username, VIEWER.password);
    for (const m of ["GET", "POST"] as const) {
      const r = await v.req("/api/base-info/countries", { method: m });
      expect(r.status).toBe(403);
    }
  });
});
