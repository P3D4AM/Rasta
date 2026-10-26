# ابزارهای توسعه

| ابزار | کار |
|---|---|
| `gen_rasta_schema.py` | تولید `prisma/schema.prisma` — بخش ۲ (۳۵۴ مدل کاتالوگ اصلی CRMIdeal) را از `CRMTabel.ssdl` می‌سازد و به بخش ۱ دستی (`schema_head.prisma`) می‌چسباند |
| `schema_head.prisma` | بخش ۱ دستی — ۲۶ مدل فعال اپ با @@map/@map روی نام جدول/ستون اصلی + ستون‌های اصلی غایب |
| `verify_schema_vs_ssdl.py` | صحت‌سنجی: تک‌تک ستون‌های ۲۶ جدول اصلی باید دقیقاً و بدون تکرار در اسکیمای رستا حاضر باشند |
| `build_catalog_doc.py` | تولید `docs/analysis/02-original-db-catalog.md` از SSDL |

## بازتولید اسکیما

```bash
python3 scripts/gen_rasta_schema.py   # مسیرها داخل فایل تنظیم است
python3 scripts/verify_schema_vs_ssdl.py
npx prisma validate && npx prisma generate && npx prisma db push
bun prisma/seed.ts
```

## اسکریپت‌های فاز ۵ (زیرساخت تست + ApiBaseInfo)

| اسکریپت | کاربرد |
|---|---|
| `e2e-server.mjs` | سرور آزمایشی Playwright — DB تست تازه + seed + `next dev` روی پورت دلخواه (با node، distDir جدا) |
| `dotnet_resx.py` | استخراج پیام‌های فارسی عیناً از satellite DLLهای fa-IR نسخهٔ قدیم (پارس کامل فرمت .NET resources: هش h*33^c، نام‌های UTF-16، مقادیر UTF-8) — **روش سندشدهٔ استخراج پیام‌ها**؛ usage: `python3 dotnet_resx.py <path/to/fa-IR/X.resources.dll> Key1 Key2 …` |
| `extract_apibaseinfo.py` | استخراج ماشینی هر ۲۳۳ اکشن ApiBaseInfoController از دیکامپایل (امضا/عملیات/SP/اعتبارسنجی) |
| `render_matrix_doc.py` | تولید `docs/parity/apibaseinfo-matrix.md` از خروجی extract (با نگاشت مدل Prisma و اولویت P1..P6) — شواهد ورودی: `/tmp/apibaseinfo_inventory.json` |

نکتهٔ مهم `dotnet_resx.py`: پیام‌های ادعاشده در تست‌ها و کد باید از این مسیر استخراج شوند — ترجمهٔ مجدد/تقریبی ممنوع (قاعدهٔ فاز ۵).
