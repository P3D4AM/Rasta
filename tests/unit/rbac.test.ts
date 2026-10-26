// تست واحد — ماتریس مجوز فرم×اکشن (بازسازی UserLogin.IsUserAccess)
// منطق مرجع: src/lib/auth.ts → can(user, form, action)
import { describe, it, expect } from "vitest";
import { can, type SessionUser } from "@/lib/auth";

function userWith(perms: Record<string, string[]>, isAdmin = false): SessionUser {
  return {
    id: "u1",
    username: "tester",
    firstName: "",
    lastName: "",
    email: null,
    isAdmin,
    roleId: "r1",
    roleName: "r",
    permissions: perms,
  };
}

describe("can() — ماتریس مجوز", () => {
  it("ادمین سیستم همهٔ فرم/اکشن‌ها را دارد (معادل کاربر adm در CRMIdeal)", () => {
    const admin = userWith({}, true);
    expect(can(admin, "frmDefineCountry", "actDelete")).toBe(true);
    expect(can(admin, "whatever-form", "whatever-action")).toBe(true);
  });

  it("کاربر عادی فقط فرم‌های تخصیص‌یافته را دارد", () => {
    const u = userWith({ frmDefineCountry: ["actView", "actInsert"] });
    expect(can(u, "frmDefineCountry", "actView")).toBe(true);
    expect(can(u, "frmDefineCountry", "actInsert")).toBe(true);
    // اکشنِ خارج از فهرست همان فرم → رد
    expect(can(u, "frmDefineCountry", "actDelete")).toBe(false);
    // فرمِ تخصیص‌نیافته → رد
    expect(can(u, "frmDefineProvince", "actView")).toBe(false);
  });

  it("کاربر بدون هیچ مجوزی هیچ دسترسی‌ای ندارد", () => {
    const u = userWith({});
    expect(can(u, "frmHomePage", "actView")).toBe(false);
  });

  it("عدم دسترسی فرم ≠ دسترسی اکشن دیگر همان فرم (تفکیک دقیق فرم×اکشن)", () => {
    const u = userWith({ frmMain: ["actDefineProjectTitle"] });
    expect(can(u, "frmMain", "actDefineProjectTitle")).toBe(true);
    expect(can(u, "frmMain", "actDefinePrjGroup")).toBe(false);
  });
});
