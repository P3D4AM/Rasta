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
