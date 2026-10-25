# ideal — بستهٔ اصلی CRMIdeal (مرجع فروزن)

این پوشه حاوی **دقیقاً همان فایلی** است که مالک پروژه در ابتدای کارِ بازنویسی «رستا» از طریق filebin آپلود کرد:

- **نام اصلی فایل:** `crm web full-187.zip`
- **محصول:** CRMIdeal نسخهٔ **3.1.18.187** (ساخت شرکت کارآفراز / KaraAfazar)
- **نوع بسته:** انتشار تولیدی (publish) از ASP.NET MVC 5.2.9 / .NET Framework 4.7 — شامل DLLهای کامپایل‌شده، ۱۴۴۶ ویوی Razor، پوشه‌های Content و Scripts و bin (بدون سورس C#)
- **حجم اصلی:** ۱۷۸ مگابایت (۱۸۶,۵۷۵,۲۵۲ بایت) — ۱۲,۵۶۴ فایل پس از استخراج

## چرا دو تکه؟

گیت‌هاب فایل‌های بزرگ‌تر از **۱۰۰ مگابایت** را نمی‌پذیرد؛ بنابراین زیپ اصلی با `split -b 95m` به دو بخش تقسیم شده است:

| بخش | نام فایل | حجم (بایت) |
|---|---|---|
| ۱ | `crm-web-full-187.zip.part-00` | 99,614,720 |
| ۲ | `crm-web-full-187.zip.part-01` | 86,960,532 |

## بازسازی فایل اصلی

**لینوکس / macOS:**
```bash
cat crm-web-full-187.zip.part-00 crm-web-full-187.zip.part-01 > "crm web full-187.zip"
```

**ویندوز (CMD):**
```cmd
copy /b crm-web-full-187.zip.part-00 + crm-web-full-187.zip.part-01 "crm web full-187.zip"
```

**ویندوز (PowerShell):**
```powershell
Get-Content crm-web-full-187.zip.part-00, crm-web-full-187.zip.part-01 -Encoding Byte -ReadCount 0 | Set-Content "crm web full-187.zip" -Encoding Byte
```

## صحت‌سنجی

SHA-256 فایل بازسازی‌شده باید دقیقاً این باشد:

```
664725f5c2e0c9844b76c8b29b3a5026ab030423eba4130b9e026c4e2196f8b9
```

```bash
sha256sum "crm web full-187.zip"
```

## نقش این پوشه در پروژهٔ رستا

این بسته **تنها منبع معتبر (source of truth)** برای بازسازی میلیمتری ظاهر و رفتار CRMIdeal است:
- ویوهای Razor واقعی، فایل‌های CSS و JS، فونت‌ها و تصاویر محصول برای همان‌اندازیِ UI
- DLLهای داخل `bin/` برای دیکامپایل و استخراج منطق کسب‌وکار (خروجی دیکامپایل در `project-analysis/decompiled/` روی شاخهٔ develop نگهداری می‌شود)
- این پوشه روی شاخهٔ **main** فروزن است و صرفاً مرجع است؛ کد رستا روی شاخهٔ **develop** توسعه می‌یابد
