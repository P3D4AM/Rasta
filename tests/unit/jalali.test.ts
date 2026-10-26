// تست واحد — تقویم جلالی (src/lib/jalali.ts)
// نقاط مرجع: 1 فروردین 1404 = 21 مارس 2025؛ 15 مهر 1404 = 7 اکتبر 2025
import { describe, it, expect } from "vitest";
import {
  toPersianDigits,
  toEnglishDigits,
  gregorianToJalali,
  jalaliToGregorian,
  formatJalali,
  formatJalaliLong,
  parseJalali,
} from "@/lib/jalali";

describe("تبدیل رقم فارسی/انگلیسی", () => {
  it("ارقام فارسی می‌سازد و برمی‌گرداند", () => {
    expect(toPersianDigits(1404)).toBe("۱۴۰۴");
    expect(toEnglishDigits("۱۴۰۴")).toBe("1404");
  });
  it("رفت‌وبرشت", () => {
    expect(toEnglishDigits(toPersianDigits("9876543210"))).toBe("9876543210");
  });
});

describe("تبدیل تاریخ میلادی↔جلالی", () => {
  it("نقطهٔ مرجع: 1 فروردین 1404 = 21 مارس 2025", () => {
    expect(gregorianToJalali(2025, 3, 21)).toEqual([1404, 1, 1]);
    expect(jalaliToGregorian(1404, 1, 1)).toEqual([2025, 3, 21]);
  });
  it("نقطهٔ مرجع: 15 مهر 1404 = 7 اکتبر 2025", () => {
    expect(gregorianToJalali(2025, 10, 7)).toEqual([1404, 7, 15]);
    expect(jalaliToGregorian(1404, 7, 15)).toEqual([2025, 10, 7]);
  });
  it("آخر سال کبیسهٔ جلالی: 30 اسفند 1403 = 20 مارس 2025", () => {
    expect(jalaliToGregorian(1403, 12, 30)).toEqual([2025, 3, 20]);
  });
  it("دورِ کامل رفت‌وبرشت در یک سال", () => {
    for (let gd = 1; gd <= 365; gd++) {
      const d = new Date(Date.UTC(2025, 0, gd));
      const [jy, jm, jd] = gregorianToJalali(d.getUTCFullYear(), d.getUTCMonth() + 1, d.getUTCDate());
      const [gy, gm, gdd] = jalaliToGregorian(jy, jm, jd);
      expect([gy, gm, gdd]).toEqual([d.getUTCFullYear(), d.getUTCMonth() + 1, d.getUTCDate()]);
    }
  });
});

describe("قالب‌بندی و پارس", () => {
  it("formatJalali — قالب عددی yyyy/mm/dd با ارقام فارسی (رفتار مستند تابع)", () => {
    const d = new Date("2025-10-07T12:00:00Z");
    expect(formatJalali(d)).toBe("۱۴۰۴/۰۷/۱۵");
    expect(formatJalali(d, false)).toBe("1404/07/15");
    expect(formatJalali(null)).toBe("—");
  });
  it("formatJalaliLong — قالب «روز ماه سال» با نام ماه", () => {
    const d = new Date("2025-10-07T12:00:00Z");
    const s = formatJalaliLong(d);
    expect(s).toContain("۱۵");
    expect(s).toContain("مهر");
    expect(s).toContain("۱۴۰۴");
  });
  it("parseJalali ورودی معتبر را می‌پذیرد", () => {
    const d = parseJalali("1404/07/15");
    expect(d).not.toBeNull();
    // مستند تابع: ظهرِ محلی همان روز (فردِ منطقهٔ زمانی در تست‌های محلی)
    expect([d!.getFullYear(), d!.getMonth() + 1, d!.getDate()]).toEqual([2025, 10, 7]);
    expect(d!.getHours()).toBe(12);
  });
  it("parseJalali ورودی بی‌معنا را رد می‌کند", () => {
    expect(parseJalali("نامعتبر")).toBeNull();
    expect(parseJalali("1404/13/01")).toBeNull();
  });
});
