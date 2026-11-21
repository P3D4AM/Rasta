# سند مرجع تحویل دانش — ممیزی امنیتی API دیتابیس Ideal CRM (`crmideal`)

> **مسیر:** `ideal/IDEAL-API-SECURITY-AUDIT-HANDOFF.md`
> **مخزن:** `P3D4AM/Rasta` — شاخهٔ **`ideal`**
> **ماهیت سند:** مستندسازی و تثبیت دانش ممیزی — **هیچ تغییر عملکردی در API یا دیتابیس با این سند انجام نمی‌شود.**
> **مخاطب:** ادامهٔ کار ممیزی، طراحی API خواندنی نسخهٔ اول، و تصمیم‌گیری دربارهٔ عملیات نوشتنی.

---

## فهرست

- [۰. شناسنامهٔ سند و روش استفاده](#۰-شناسنامهٔ-سند-و-روش-استفاده)
- [۱. قوانین غیرقابل مذاکره](#۱-قوانین-غیرقابل-مذاکره)
- [۲. اطلاعات دیتابیس زنده (`crmideal`)](#۲-اطلاعات-دیتابیس-زنده-crmideal)
- [۳. نقشهٔ منابع ممیزی در مخزن (مسیرهای واقعی)](#۳-نقشهٔ-منابع-ممیزی-در-مخزن-مسیرهای-واقعی)
- [۴. ممیزی ۱۸ رویهٔ خواندنی](#۴-ممیزی-۱۸-رویهٔ-خواندنی)
- [۵. نامزدهای عملیات نوشتنی (فهرست اولیه)](#۵-نامزدهای-عملیات-نوشتنی-فهرست-اولیه)
- [۶. استخراج اول — ۱۹ ماژول](#۶-استخراج-اول--۱۹-ماژول)
- [۷. استخراج دوم — ۳۶ ماژول در فایل](#۷-استخراج-دوم--۳۶-ماژول-در-فایل)
- [۸. استخراج سوم — ۳۶۱ تعریف بازبینی‌شده / ۴۰۶ در فایل کامل](#۸-استخراج-سوم--۳۶۱-تعریف-بازبینی‌شده--۴۰۶-در-فایل-کامل)
- [۹. استخراج چهارم — ۱۳ قطعه](#۹-استخراج-چهارم--۱۳-قطعه)
- [۱۰. جدول تجمیعی یافته‌ها (Finding Registry)](#۱۰-جدول-تجمیعی-یافته‌ها-finding-registry)
- [۱۱. تصمیم معماری API نسخهٔ اول (خواندنی)](#۱۱-تصمیم-معماری-api-نسخهٔ-اول-خواندنی)
- [۱۲. سیاست عملیات نوشتنی (وضعیت فعلی: مسدود)](#۱۲-سیاست-عملیات-نوشتنی-وضعیت-فعلی-مسدود)
- [۱۳. کارهای باقی‌مانده به ترتیب اولویت](#۱۳-کارهای-باقی‌مانده-به-ترتیب-اولویت)
- [۱۴. قالب ثبت یافته‌های جدید](#۱۴-قالب-ثبت-یافته‌های-جدید)
- [۱۵. تعارض‌ها و موارد نیازمند تأیید (ثبت صریح و حل‌نشده)](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده)
- [۱۶. وضعیت نهایی و محدودیت شواهد](#۱۶-وضعیت-نهایی-و-محدودیت-شواهد)
- [۱۷. تاریخچهٔ Git مرتبط](#۱۷-تاریخچهٔ-git-مرتبط)

---

## ۰. شناسنامهٔ سند و روش استفاده

این سند **مرجع واحد** برای تمام دانش تولیدشده در ممیزی دیتابیس Ideal CRM است:

- اطلاعات دیتابیس زنده (بر پایهٔ گزارش `ideal-live-schema-report.json` اجراشده توسط مالک)
- نتایج چهار دور استخراج تعاریف ماژول‌ها (Stored Procedure / Function / View)
- یافته‌های امنیتی و صحت داده با **شواهد خطی از فایل‌های موجود در مخزن**
- تصمیم‌های معماری API نسخهٔ اول و سیاست عملیات نوشتنی
- کارهای باقی‌مانده به ترتیب اولویت

**اصول شواهد در این سند:**

| برچسب | معنا |
|---|---|
| `[تأیید-مخزن]` | مستقیماً از فایل‌های موجود در شاخهٔ `ideal` بازبینی و راستی‌آزمایی شده (فایل/شمارهٔ خط ذکر می‌شود) |
| `[بریفینگ]` | از جمع‌بندی مأموریت ممیزی (گزارش جلسات قبلی) نقل شده و سند مستقل در مخزن ندارد |
| `[زنده]` | از گزارش `ideal-live-schema-report.json` (اجرای مالک روی دیتابیس واقعی؛ فایل در مخزن نیست) |
| `[نیازمند-تأیید]` | مورد باز، تعارض‌دار یا نیازمند بررسی بیشتر — **حدس زده نشده** |

هر جا عدد بریفینگ با محتوای واقعی فایل‌های مخزن تفاوت دارد، **هر دو مقدار** ثبت و تعارض در [بخش ۱۵](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده) به‌صورت حل‌نشده اعلام شده است.

---

## ۱. قوانین غیرقابل مذاکره

این قوانین برای ادامهٔ کار الزامی‌اند:

1. فقط روی شاخهٔ `ideal` کار شود؛ به `main` دست زده نشود.
2. Force Push ممنوع.
3. **هیچ Stored Procedure روی دیتابیس واقعی اجرا نشود.**
4. **هیچ داده‌ای در دیتابیس واقعی تغییر نکند** — نه migration، نه `ALTER`/`UPDATE`/`DELETE`/`INSERT`، نه تغییر Schema.
5. در فاز فعلی فقط مستندات و ابزارهای آفلاین تحلیل تغییر کنند.
6. یافته‌های اثبات‌شده از فرضیه‌ها و موارد نیازمند بررسی جدا شوند.
7. نتیجهٔ جست‌وجوی متنی هرگز به‌عنوان اثبات قطعی آسیب‌پذیری یا نبود مجوز معرفی نشود.
8. تعارض اطلاعات با فایل‌های مخزن: هر دو ثبت، تعارض حل‌نشده اعلام، اطلاعات حدس زده نشود.
9. هیچ اطلاعات محرمانه، رمز عبور، دادهٔ تجاری یا اطلاعات شخصی مشتریان وارد سند نشود.

---

## ۲. اطلاعات دیتابیس زنده (`crmideal`)

منبع: گزارش `ideal-live-schema-report.json` — اجراشده توسط مالک با ابزار `IdeaSchemaDump` (حساب فقط-فرادادهٔ `ibk_schema_reader`). **فایل گزارش عمداً وارد Git نمی‌شود** (سیاست `.gitignore` مستند در `ideal/IdealBridge/docs/IDEAL_LIVE_SCHEMA_AUDIT.md` §۳ ردیف ۱۰). اعداد زیر وضعیت گزارش را بازتاب می‌دهند `[زنده]`.

### ۲.۱ مشخصات سرور و دیتابیس

| مورد | مقدار |
|---|---|
| SQL Server | 2019 Enterprise |
| Database | `crmideal` |
| Compatibility Level | 130 |
| Product Version | `15.0.2000.5` |
| Database Collation | `Arabic_CI_AS` |
| Server Collation | `Arabic_CI_AI` |

### ۲.۲ شمارش اشیاء

| شمارش | مقدار | شمارش | مقدار |
|---|---|---|---|
| Schema | 13 | Stored Procedure | 4,026 |
| Table | 681 | Function | 175 |
| Column | 11,991 | View | 12 |
| Primary Key | 672 | **Trigger** | **8** |
| Foreign Key | 3,033 | Identity Column | 615 |
| Default Constraint | 444 | Computed Column | 0 |
| Extraction Warning | 0 | | |

### ۲.۳ نکات معماری (پیامد برای همگام‌سازی)

- **RowVersion وجود ندارد.**
- **CDC و Change Tracking فعال نیستند.**
- **Temporal Table وجود ندارد.**
- سازوکار بومی قابل اتکایی برای **Incremental Sync** شناسایی نشده است.
- چند Foreign Key مهم **Untrusted** هستند.
- در طراحی همگام‌سازی باید راهکار مستقل برای تشخیص تغییرات و حذف‌ها در نظر گرفته شود.
- گزارش Schema فقط **Metadata** است؛ شامل داده‌های تجاری و تعریف کامل تمام ماژول‌ها نیست.

### ۲.۴ وضعیت استخراج تریگرها (پیشینهٔ مهم)

بر اساس `ideal/IdealBridge/docs/WORKLOG.md` (فاز ۱۲.۵.۲ و ۱۲.۵.۳):

- اجرای اول (بستهٔ `dev-12.5.2`): اتصال برقرار شد اما بلوک `triggers` به‌دلیل خطای 207 (ارجاع به ستون ناموجود `tr.schema_id` در `sys.triggers`) استخراج نشد و آرایه خالی ماند.
- فاز ۱۲.۵.۳ (کامیت `d5ee55b`، Release `dev-12.5.3`) خطا را با تغییر مسیر Join به `sys.objects`/`sys.schemas` رفع کرد.
- گزارش زندهٔ مبنا برای این سند **۸ تریگر با ۰ هشدار استخراج** نشان می‌دهد — این با اجرای موفق بستهٔ اصلاح‌شده سازگار است؛ اما این اجرای مجدد هنوز در WORKLOG ثبت نشده و ثبت آن یک کار باقی‌ماندهٔ کوچک است `[نیازمند-تأیید]`.

---

## ۳. نقشهٔ منابع ممیزی در مخزن (مسیرهای واقعی)

همهٔ مسیرها نسبت به ریشهٔ مخزن و روی شاخهٔ `ideal` `[تأیید-مخزن]`:

### ۳.۱ تعاریف ۱۸ رویهٔ خواندنی

| مسیر | توضیح |
|---|---|
| `ideal/procedure-definitions/dbo.*.sql` | ۱۸ فایل تعریف (هر رویه یک فایل) + `manifest.csv` با طول و SHA-256 هر تعریف |
| `ideal/procedure-definitions.zip` | بستهٔ ZIP همان پوشه |

### ۳.۲ اسکریپت‌ها و خروجی‌های چهار دور استخراج نوشتنی

| دور | اسکریپت استخراج | خروجی تعاریف | یادداشت |
|---|---|---|---|
| ۱ | `ideal/ideal-write-audit.sql` | `ideal/ideal-write-audit-definitions.txt` | ۱۹ ماژول (۱۶ SP + ۲ Function + ۱ View) |
| ۲ | — (در مخزن commit نشده) | `ideal/ideal-write-audit-next-definitions.txt` | ۳۶ ماژول در فایل |
| ۳ | `ideal/ideal-write-audit-third.sql` | `ideal/ideal-write-audit-third-definitions.txt` (۴۰۶ ماژول) + `ideal/ideal-write-audit-third-part-1.txt` تا `part-7.txt` (۳۶۱ ماژول یکتا — مجموعهٔ بازبینی‌شده) | ۷ قطعه |
| ۴ | `ideal/ideal-write-audit-fourth-fixed.sql` | `ideal/ideal-write-audit-fourth-definitions.txt` (فرادادهٔ ۱۳۵ ماژول، قالب UTF-16) + `ideal/ideal-write-audit-fourth-part-1.txt` تا `part-13.txt` (متن کامل تعاریف) | ۱۳ قطعه، مجموع ≈ ۳٬۷۷۲٬۹۵۰ کاراکتر / ۸۷٬۳۰۳ خط |

### ۳.۳ منابع مرجع دیگر

| مسیر | توضیح |
|---|---|
| `ideal/IdealBridge/` | سرویس پل فقط-خواندنی (.NET 10) — مستقل از کد رستا؛ شامل تست‌ها، CI و گارد فقط-خواندنی |
| `ideal/IdealBridge/docs/01..11-*.md` | مستندات فنی IdealBridge (معماری، endpointها، اتصال، نصب، اجرا، سازگاری، همگام‌سازی، Swagger) |
| `ideal/IdealBridge/docs/IDEAL_API_MAPPING.md` | نگاشت فیلد-به-فیلد API ⇄ دیتابیس Ideal (مبنای ستون‌ها: SSDL نسخهٔ ۱۸۷) |
| `ideal/IdealBridge/docs/IDEAL_DATABASE_MAP.md` | نقشهٔ جداول و روابط |
| `ideal/IdealBridge/docs/IDEAL_SCHEMA_AUDIT.md` | ممیزی اسکیمای ایستا (نام‌های غلط جدول/ستون در کد مخازن و…) |
| `ideal/IdealBridge/docs/IDEAL_LIVE_SCHEMA_AUDIT.md` | مدل امنیتی استخراج زنده + وضعیت صادقانهٔ شواهد |
| `ideal/IdealBridge/docs/IDEAL_PII_AUDIT.md` | ممیزی داده‌های شخصی |
| `ideal/IdealBridge/docs/IDEAL_QUERY_COMPATIBILITY_REPORT.md` | سازگاری کوئری‌ها با نسخهٔ نصب‌شده (3.1.16.169) |
| `ideal/IdealBridge/docs/IDEAL_SECURITY_ALLOWLIST.md` | فهرست مجاز امنیتی |
| `ideal/IdealBridge/docs/IDEAL_SYNC_CAPABILITY_AUDIT.md` | قابلیت‌های همگام‌سازی |
| `ideal/IdealBridge/docs/WORKLOG.md` | تاریخچهٔ کامل فازها با SHA کامیت‌ها |
| `ideal/SQL_Catalog_Word_v1.0.zip` | کاتالوگ ۵۹٬۱۲۴ دستور SQL نصاب (جلد ۰۰ تا ۱۰، مرجع مهاجرت 2.2.6.43 تا 4.4.3.213) |
| `ideal/data.zip` | مجموعهٔ خام کاتالوگ (`catalog.tsv`، `sources.json`، `statements.pack` — متن کامل ۳۶۱MB فشرده) |
| `ideal/README.md` | شناسنامهٔ بستهٔ فروزن `crm web full-187.zip` (منبع معتبر UI/رفتار CRMIdeal 3.1.18.187) |
| `ideal/README_SQL_Catalog.md` | راهنمای کاتالوگ SQL |
| `ideal/crm-web-full-187.zip.part-00/01` | بستهٔ انتشار تولیدی CRMIdeal (دو تکه، بازسازی با `cat`) |
| `ideal/6afd73bb-0a84-83eb-8858-93609d1d6fbc.htm` | صفحهٔ وب ذخیره‌شدهٔ کمکی (متعلق به دور چهارم؛ محتوای آن مبنای شواهد این سند نیست) |

**روش‌شناسی استخراج:** همهٔ اسکریپت‌های `ideal-write-audit*.sql` فقط `SELECT` روی نمای‌های کاتالوگ (`sys.sql_modules`، `sys.objects`، `sys.schemas`، `sys.sql_expression_dependencies` و…) هستند — اجرا با حساب فقط-فراداده توسط مالک، بدون اجرای هیچ SP و بدون خواندن هیچ دادهٔ تجاری.

---

## ۴. ممیزی ۱۸ رویهٔ خواندنی

۱۸ تعریف خواندنی استخراج و با Schema زنده تطبیق داده شدند. هر ۱۸ رویه در دیتابیس زنده وجود دارند و امضای پارامترهایشان با Schema گزارش‌شده مطابق است `[بریفینگ]`.

> **محدودهٔ اعتبار:** در این ۱۸ تعریف دستور مستقیم `INSERT`/`UPDATE`/`DELETE`/`MERGE` شناسایی نشد `[تأیید-مخزن]`. این نتیجه **فقط به همین ۱۸ فایل مربوط است** و نباید به کل دیتابیس تعمیم شود.

### ۴.۱ فهرست فایل‌ها (بر پایهٔ محتوای واقعی `ideal/procedure-definitions/`) `[تأیید-مخزن]`

| # | رویه | # | رویه |
|---|---|---|---|
| 1 | `ApispRpt_WareHouseStock` | 10 | `ApispSelectPreOrder` |
| 2 | `ApispSelectBuyOrder` | 11 | `ApispSelectPreOrderItems` |
| 3 | `ApispSelectBuyOrderItems` | 12 | `ApispSelectProductPrice` |
| 4 | `ApispSelectCompany` | 13 | `ApispSelectProducts` |
| 5 | `ApispSelectCompanyPersons` | 14 | `WSspReturnPrdQuantity` |
| 6 | `ApispSelectDoc` | 15 | `WSspRpt_WareHousePrdMinStock` |
| 7 | `ApispSelectDocItems` | 16 | `WSspSelectBuyOrderPayments` |
| 8 | `ApispSelectOrder` | 17 | `WSspSelectStockSupply` |
| 9 | `ApispSelectOrderItems` | 18 | `WSspSelectStockSupplyItems` |

> **اختلاف با فهرست بریفینگ:** بریفینگ بند ۱۸ را `WSspRpt_WareHouseStock` ثبت کرده؛ چنین رویه‌ای نه در `procedure-definitions/` وجود دارد و نه در هیچ‌یک از استخراج‌ها. فایل واقعی هجدهم `ApispSelectProducts` است. → [تعارض C-1](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده)

### ۴.۲ اطلاعات حساس

**F-001 — افشای فیلدهای نام کاربری/رمز عبور در `ApispSelectCompany`** `[تأیید-مخزن]`

- **شواهد:** `dbo.ApispSelectCompany.sql` خطوط ۱۰۱–۱۰۲ و ۲۱۷–۲۱۸:
  ```sql
  cmpUserName AS [ApiCmpUserName],
  cmpPassword AS [ApiCmpPassword],
  ```
- **شدت:** High (تا روشن شدن ماهیت این فیلدها) · **اثبات:** Confirmed (وجود در خروجی) — کاربرد واقعی فیلدها `نیازمند تأیید مالک` است.
- **اقدام:** این دو فیلد تا تعیین ماهیت، در DTO عمومی، لاگ یا خروجی API منتشر نشوند.

**F-002 — بازگشت اطلاعات شخصی گسترده در `ApispSelectCompanyPersons`** `[تأیید-مخزن]`

- **شواهد:** `dbo.ApispSelectCompanyPersons.sql` خطوط ۶۰–۹۷ (از جمله): `ApiPrsMobile` (۶۰)، `ApiPrsEmail`/`ApiPrsEmailII` (۶۲–۶۳)، `ApiPrsAddress` (۷۱)، `ApiPrsNationalCode` (۷۵)، `ApiPrsFatherName` (۷۷)، `ApiPrsBirthDate` (۷۸)، `ApiPrsIsMarried` (۸۰)، `ApiPrsBirthDateTime` (۹۷) و مختصات جغرافیایی.
- **شدت:** High · **اثبات:** Confirmed.
- **اقدام:** DTO حداقلی و مبتنی بر نقش/مجوز؛ PII سنگین فقط با مجوز صریح.

### ۴.۳ Dynamic SQL (خواندنی‌ها)

**F-004 تا F-007 — ساخت SQL پویا با اتصال رشته‌ای** `[تأیید-مخزن]`

| رویه | پارامترهای الحاق‌شده | شاهد (فایل: خط) |
|---|---|---|
| `ApispSelectCompany` | `@CmpCode` | `dbo.ApispSelectCompany.sql:270` — `SET @QRY = @QRY + ' AND CC.cmpCode = ''' + @CmpCode + ''''` |
| `ApispSelectProducts` | `@PrdCode` | `dbo.ApispSelectProducts.sql:231` — `SET @QRY = @QRY + ' AND PrdCode = ''' + @PrdCode + ''''` |
| `ApispRpt_WareHouseStock`، `WSspRpt_WareHousePrdMinStock` | `@PrdModel`، `@Tracing` | `dbo.WSspRpt_WareHousePrdMinStock.sql:106-107` (`@Tracing`) و `132-143` (`@PrdModel`) |
| `WSspSelectStockSupply` | شرط متنی ذخیره‌شده | `dbo.WSspSelectStockSupply.sql:59` — `SELECT @IndicatorTermTxt = Txt FROM dbo.CrmsysDBTempInfo WHERE TypeId = 90 AND UserId = @UserId` |

- **شدت:** High (الگوی تزریق بالقوه؛ قابلیت Exploit به مسیر فراخوانی و اعتبارسنجی ورودی بستگی دارد) · **اثبات:** Confirmed (الگو) / exploit مسیر به مسیر: Likely.
- **اقدام:** بازنویسی با `sp_executesql` و پارامترهای نوع‌دار.

### ۴.۴ کنترل دسترسی

- **F-010 — نبود تضمین Scope فروشنده در بدنهٔ رویه‌های خواندنی** (مشتری، شخص تماس، محصول، سفارش، پیش‌سفارش، سند): در بدنهٔ این ۱۸ رویه فراخوانی Helperهای مجوز (`MobspCheckCmpDataPermissionForUser` و غیره) مشاهده نشد `[تأیید-مخزن — اسکن فراخوانی]`. **محدودیت شواهد:** نبود فراخوانی در بدنهٔ SP به‌تنهایی اثبات نمی‌کند که در تمام مسیرهای فراخوانی هیچ مجوزی اعمال نمی‌شود (ممکن است لایهٔ بالاتر اعمال کند). اثبات: Likely.
- **F-011 — رویه‌های اقلام/پرداخت فقط شناسهٔ والد را دریافت می‌کنند:** دسترسی به Child Record باید فقط **بعد از Authorization والد** انجام شود `[بریفینگ + ساختار پارامترها]`.
- **F-008 — دور زدن مجوز انبار در `WSspRpt_WareHousePrdMinStock` وقتی انبار مشخص است** `[تأیید-مخزن]`:
  ```sql
  -- dbo.WSspRpt_WareHousePrdMinStock.sql:50-64
  IF @WHID > 0
  BEGIN
      SET @Term = @Term + ' And D.WHId = ' + CAST(@WHId AS VARCHAR(10))   -- بدون کنترل مجوز
  END
  ELSE
  BEGIN
      SET @Term = @Term + ' And D.WHId IN (SELECT WUP.[WHId]
          FROM [dbo].[WSWareHouseUserPermissions] WUP
          WHERE ISNULL(WUP.[CrmUserId],0) IN(0, ' + CAST(@UserId AS VARCHAR(10)) + ')) '
  END
  ```
  یعنی فیلتر مجوز انبار فقط در حالت «همهٔ انبارها» اعمال می‌شود؛ درخواست انبار مشخص از فیلتر مجوز عبور می‌کند. **شدت:** High · **اثبات:** Confirmed.
- **F-009 — `WSspReturnPrdQuantity` هیچ ارجاعی به جداول/مکانیزم مجوز انبار ندارد** `[تأیید-مخزن — اسکن]`. **شدت:** High · **اثبات:** Confirmed (نبود ارجاع در بدنه) / نیاز به بررسی مسیر فراخوانی.
- **F-016 — `UserId`/`CrmUserId`/شناسه‌های مالکیتی به‌عنوان پارامتر ورودی دریافت می‌شوند** (مثلاً `@UserId` در `WSspRpt_WareHousePrdMinStock` مستقیماً در SQL الحاق می‌شود). این شناسه‌ها نباید از ورودی قابل اعتماد کلاینت پذیرفته شوند؛ باید از هویت احراز‌شدهٔ سمت سرور تعیین شوند `[بریفینگ + شواهد خطی]`.

### ۴.۵ اشکالات معنایی و داده‌ای

- **F-003 — باگ اتصال نام در `ApispSelectCompanyPersons`** `[تأیید-مخزن]`: خطوط ۱۰۲، ۱۰۶، ۱۸۸، ۱۹۲ نام کاربر ثبت‌کننده/ویراستار را با **`FName + ' ' + FName`** می‌سازند (نام کوچک دو بار؛ `LName` هرگز ارجاع نمی‌شود):
  ```sql
  (SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.FName, '''') FROM Users U
   WHERE U.UserId = CCP.UserId) AS [ApiEditUser]
  ```
  **شدت:** Medium · **اثبات:** Confirmed.
- **F-012 — `ApispSelectDocItems`: زیرکوئری `ApiFirstRegisterUser` به `DI.UserId` جوین می‌شود نه `DI.FirstRegisterUserId`** `[تأیید-مخزن]` — خطوط ۵۰–۵۱ (و ۸۰–۸۱ در مسیر چندزبانه):
  ```sql
  FirstRegisterUserId AS [ApiFirstRegisterUserId],
  (SELECT ... FROM Users U WHERE U.UserId = DI.UserId) AS [ApiFirstRegisterUser],   -- باید DI.FirstRegisterUserId باشد
  ```
  **شدت:** Medium (صحت داده) · **اثبات:** Confirmed.
- **F-013 — `ApispSelectBuyOrderItems`: Alias واحد پول در نسخهٔ دوم (`...I`) شناسه برمی‌گرداند نه متن** `[تأیید-مخزن]` — خط ۱۰۷ (و ۲۱۰ در مسیر چندزبانه):
  ```sql
  (SELECT U.CurrencyUnitID FROM WSCurrencyUnits U
   WHERE U.CurrencyUnitID = BOI.bordICurrencyUnitIdI) AS [ApiBordICurrencyUnitI],  -- CurrencyUnitID به‌جای CurrencyUnit
  ```
  **شدت:** Low · **اثبات:** Confirmed.
- **F-014 — پارامترهای بلااستفاده** `[تأیید-مخزن]`: `@FPId` در `ApispRpt_WareHouseStock` و `WSspRpt_WareHousePrdMinStock`؛ `@Mode` در `WSspRpt_WareHousePrdMinStock`؛ `@FCR`/`@FCRI` در `WSspReturnPrdQuantity` (اعلان در خطوط ۳۳–۳۴؛ تمام مصرف‌ها در کامنت غیرفعال `/*RZ990210- Deactive FCR*/`). **شدت:** Informational.
- **F-015 — `WSspSelectStockSupplyItems`: تبدیل رشته به عدد بدون `TRY_CONVERT`** `[تأیید-مخزن]` — خطوط ۷۵، ۸۶، ۱۶۳، ۱۷۴:
  ```sql
  SELECT CAST(ISNULL(L.[value],'0') AS INT) FROM STRING_SPLIT([stsupIBuyOrderIds], ',') L ...
  ```
  `ISNULL(...,'0')` فقط NULL را می‌پوشاند؛ مقدار متنی خراب باعث خطای اجرای کل کوئری می‌شود. **شدت:** Medium · **اثبات:** Confirmed.
- معنای محاسبهٔ پیش‌سفارش‌های جزئی و لغوشده نیازمند تأیید **مالک کسب‌وکار** است `[نیازمند-تأیید]`.

### ۴.۶ Pagination

در این ۱۸ رویه، Pagination استاندارد مبتنی بر `OFFSET/FETCH` یا Cursor مشاهده نشد `[تأیید-مخزن — اسکن]`. الزامات API:

- سقف Page Size؛
- محدودسازی بازهٔ زمانی درخواست؛
- برای صفحات بزرگ، **Cursor پایدار** بر اساس Date/Number/ID (نه OFFSET خام).

---

## ۵. نامزدهای عملیات نوشتنی (فهرست اولیه)

بر پایهٔ بررسی Signatureهای دیتابیس `[بریفینگ]`:

| حوزه | رویه‌ها |
|---|---|
| مشتری و شخص تماس | `ApispInsertCompany` · `ApispUpdateCompany` · `ApispInsertCompanyPersons` · `ApispUpdateCompanyPerson` · `MobspInsertQuickCompany` · `MobspUpdateCompany` |
| محصول و قیمت | `ApispInsertProducts` · `ApispUpdateProducts` · `ApispInsertProductPrice` · `ApispUpdateProductPrice` |
| پیش‌سفارش | `ApispInsertPreOrder` · `ApispInsertPreOrderItems` · `ApispUpdatePreOrder` · `ApispUpdatePreOrderItems` · `MobspInsertPreOrderFull` |
| سفارش | `ApispInsertOrder` · `ApispInsertOrderItems` · `ApispUpdateOrder` · `ApispUpdateOrderItems` · `ApispInsertOrderPayments` |
| خرید | `ApispInsertBuyOrder` · `ApispInsertBuyOrderItem` · `ApispUpdateBuyOrder` · `ApispUpdateBuyOrderItems` |
| اسناد | `ApispIssueDoc` · `MobspInsertDocFull` · `MobspUpdateDoc` |
| تأمین موجودی | `WSspIssueStockSupplyFromPreOrder` |

> این فهرست **فقط نامزد اولیه** است؛ به معنی تأیید امنیت یا آمادگی برای API نیست.

---

## ۶. استخراج اول — ۱۹ ماژول

فایل: `ideal/ideal-write-audit-definitions.txt` — **۱۹ ماژول** `[تأیید-مخزن: شمارش سرصفحه‌ها = ۱۹]`: ۱۶ Stored Procedure + ۲ Function (`WSfnProductsInGroups`، `WSfnProductsInGroups_Lang`) + ۱ View (`CRMvwSelectCompanyPersons`).

### ۶.۱ یافته‌های کلیدی

**F-017 — شش رویهٔ Update با Dynamic SQL مبتنی بر اتصال رشته‌ای** `[تأیید-مخزن]`:

- `ApispUpdateCompany`
- `ApispUpdateCompanyPerson`
- `ApispUpdateOrder`
- `ApispUpdateOrderItems`
- `ApispUpdatePreOrder`
- `ApispUpdatePreOrderItems`

در هر شش مورد `sp_executesql` استفاده نشده و ساخت SQL با الحاق رشته‌ای (`+`) انجام می‌شود. **شدت:** Critical (الگو) — قابلیت Exploit هر مورد باید جداگانه اثبات شود. **اثبات:** Confirmed (الگو).

**F-019 — نبود کنترل مالکیت/مجوز صریح در رویه‌های Insert** `[تأیید-مخزن — اسکن فراخوانی Helperها]`:

- در `ApispInsertCompany`، `ApispInsertCompanyPersons`، `ApispInsertOrder`، `ApispInsertOrderItems`، `ApispInsertOrderPayments`، `ApispInsertPreOrder`، `ApispInsertPreOrderItems` و `MobspInsertPreOrderFull`: **صفر** فراخوانی Helper مجوز.
- **استثنای مهم:** `MobspInsertQuickCompany` پنج بار `dbo.MobspCheckCmpDataPermissionForUser` را فراخوانی می‌کند (خطوط ۲۱۸، ۲۴۹، ۲۹۱، ۴۴۷، ۴۷۸) — اما این Helper خودش دارای ایراد F-023 است. → [تعارض C-7](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده)
- `ApispInsertOrder`/`ApispInsertPreOrder` کنترل صریح مالکیت مشتری را در بدنهٔ بررسی‌شده ندارند؛ `ApispInsertCompanyPersons` کنترل دسترسی به شرکت والد را ندارد.
- `ApispInsertOrderItems` وضعیت Fixed بودن سفارش را بررسی می‌کند (خط ۱۷۶: `IF(ISNULL(@IsFixed,0) = 1)`) اما مالکیت سفارش را تضمین نمی‌کند.
- `ApispInsertOrderPayments` وجود سفارش را بررسی می‌کند اما مجوز مالکیت را اثبات نمی‌کند.
- `ApispInsertCompany` شناسهٔ Refer User دریافت می‌کند؛ اعتبار تخصیص مشتری به کاربر باید بررسی شود.
- **محدودیت شواهد:** «نبود فراخوانی در بدنه» ≠ «نبود هرگونه مجوز در کل مسیر فراخوانی». اثبات: Likely.

**F-020 — `MobspInsertPreOrderFull` از Delimiter سفارشی استفاده می‌کند، نه JSON** `[تأیید-مخزن]`:

```sql
IF PATINDEX('%|#|%', @PreOrder) > 0
SET @PordFieldName = SUBSTRING(@PordField, 1, CHARINDEX('=',@PordField)-1)
```

قرارداد JSON برای این رویه نباید فرض شود. **شدت:** Medium (طراحی قرارداد) · **اثبات:** Confirmed.

**F-021 — الگوی معیوب خواندن `@@ERROR`** `[تأیید-مخزن]` — نمونه از `ApispInsertOrder`:

```sql
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Insert Project' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END
```

`@@ERROR` دو بار خوانده می‌شود: بار دوم (در `SET @ErrorNumber=@@ERROR`) تقریباً همیشه ۰ است چون هر دستور مقدار قبلی را بازنشانی می‌کند؛ در بعضی مسیرها خواندن `@@ERROR` نیز بعد از دستورات `SET` انجام می‌شود و خطای اصلی از دست می‌رود. همین الگو در ۱۶ ماژول این استخراج دیده می‌شود. همچنین برخی مسیرها ممکن است `SELECT 1` را حتی در شرایط خطا برگردانند `[بریفینگ]`. **شدت:** Medium (تشخیص خطا) · **اثبات:** Confirmed (الگوی دو بار خواندن) / رفتار خروجی خطا: Likely.

**F-022 — نبود Idempotency** در عملیات بررسی‌شده به‌صورت روشن وجود ندارد؛ تراکنش‌های تو در تو و Rollback باید جداگانه تحلیل شوند `[بریفینگ]`.

---

## ۷. استخراج دوم — ۳۶ ماژول در فایل

فایل: `ideal/ideal-write-audit-next-definitions.txt` — **۳۶ ماژول** `[تأیید-مخزن: شمارش سرصفحه‌ها = ۳۶]`. بریفینگ عدد ۳۷ را ثبت کرده → [تعارض C-2](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده). اسکریپت استخراج این دور در مخزن commit نشده است → [C-6](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده).

### ۷.۱ یافته‌های کلیدی

**F-018 — چهار Update دیگر با Dynamic SQL/اتصال رشته‌ای** `[تأیید-مخزن]`:

- `ApispUpdateBuyOrder`
- `ApispUpdateBuyOrderItems`
- `ApispUpdateProducts`
- `ApispUpdateProductPrice`

**سه Helper نیازمند بازبینی جدی** `[تأیید-مخزن — وجود EXEC پویا در بدنه]`:

- `ApispCheckDuplicateCompany`
- `MobspCheckDuplicateCompany`
- `MobspCheckDuplicateCompanyForSetReason`

جمع یافته‌های F-017 و F-018: **دست‌کم ۱۰ رویهٔ Update با الگوی Dynamic SQL پرریسک** — اما قابلیت Exploit هر مورد باید جداگانه اثبات شود.

**سایر یافته‌ها `[بریفینگ + تعاریف موجود]`:**

- `ApispInsertBuyOrder` وجود مشتری، شخص تماس، پروژه و کاربر را بررسی می‌کند، اما ارتباط این شناسه‌ها با یکدیگر و مجوز دسترسی را کامل اثبات نمی‌کند.
- رویه‌های محصول و قیمت کنترل دسترسی کافی و صریحی در تعریف بررسی‌شده نشان نمی‌دهند.
- `MobspInsertDocFull` JSON دریافت می‌کند، اما کنترل Action Permission به‌تنهایی مجوز دسترسی به سند، انبار و والد را اثبات نمی‌کند.
- `MobspUpdateDoc` از نظر مالکیت سند و انبار باید بررسی شود.
- `WSspIssueStockSupplyFromPreOrder` عملیات جانبی ایجاد می‌کند و در برابر Retry بدون Idempotency می‌تواند خطرناک باشد (شواهد تکمیلی در بخش ۹: ۷ دستور INSERT، بدون TRY/CATCH، بدون نشانهٔ Idempotency).

---

## ۸. استخراج سوم — ۳۶۱ تعریف بازبینی‌شده / ۴۰۶ در فایل کامل

فایل‌ها:

- `ideal/ideal-write-audit-third-definitions.txt` — **۴۰۶ ماژول** (خروجی کامل اسکریپت) `[تأیید-مخزن]`
- `ideal/ideal-write-audit-third-part-1.txt` … `part-7.txt` — **۳۶۱ ماژول یکتا** (مجموعهٔ بازبینی‌شده) `[تأیید-مخزن]`

تفاوت دو فایل: ۴۵ ماژولِ فقط در فایل کامل، همگی از خانوادهٔ `WSsp*`اند (Verify/Fixed/Issue/… — مثل `WSspOrderVerify`، `WSspPreOrderGroupVerify`، `WSspIssueStockSupplyFromPreOrder`) و در مجموعهٔ ۳۶۱تایی نیستند؛ یک ماژول (`WSspIssueOrderFromPreOrder`) در هر دو هست با طول متفاوت (۱۴۱٬۰۵۴ در برابر ۱۳۹٬۱۳۷ کاراکتر). عدد «۳۶۱ تعریف بازبینی‌شده» بریفینگ با مجموعهٔ ۷ قطعه مطابق است `[تأیید-مخزن]` → جزئیات در [C-3](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده).

### ۸.۱ اسکن ابتدایی

- **۳۰۷ ماژول از ۳۶۱** شامل Tokenهای `INSERT`/`UPDATE`/`DELETE` تشخیص داده شدند `[تأیید-مخزن — بازتولید مستقل همان نتیجه: ۳۰۷/۳۶۱]`.
- این عدد **Heuristic** است و به معنی ۳۰۷ API نوشتنی نیست — برخی Tokenها در Comment، Helper یا محاسبات داخلی وجود دارند.

### ۸.۲ Helperهای مهم مجوز

| Helper | نقش | وضعیت |
|---|---|---|
| `MobspCheckActionForUser` | مجوز **Action** (Form/Action/Roll از طریق `CrmsysRollPermission`/`CrmsysForms`/`CrmsysFormActions`/`UsersPermission` با `PrjId=11`) | تعریف کامل در استخراج چهارم؛ الگوی درست مقداردهی خروجی (۱/۰ در دو شاخه) دارد؛ `@UserId` از فراخواننده می‌آید — باید از هویت احراز‌شدهٔ سرور تعیین شود |
| `MobspSetcmpDataPermission` | تولید شرط مجوز مشتری به‌صورت **متن SQL** و ذخیره در `CrmsysDBTempInfo` با **TypeId=20** | ریسک‌ها در F-024 |
| `CRMspSetcmpDataPermission` | مشابه فوق | ریسک‌ها در F-024 |
| `MobspCheckCmpDataPermissionForUser` | بررسی Row-Level مجوز مشتری (Province/… با جداول Forbidden/JustAccess) | ایراد F-023 |
| `MobspCheckCompanyDataPermissionForUser` | بررسی مجوز دادهٔ شرکت | نیازمند ممیزی کامل |

**F-023 — ایراد `MobspCheckCmpDataPermissionForUser`: خروجی `@IsAccess` در ابتدای Procedure صفر نمی‌شود** `[تأیید-مخزن]`:

```sql
@IsAccess BIT OUTPUT
...
IF(@CrmUserId = -10) /*user is site*/ SET @IsAccess = 1
-- ۹ مورد «SET @IsAccess = 1» در شاخه‌های مجاز؛ هیچ «SET @IsAccess = 0» در ابتدای بدنه وجود ندارد
```

در شاخه‌های رد دسترسی ممکن است مقدار قبلی متغیر فراخواننده باقی بماند (مقدار کهنه). **اصلاح پیشنهادی:** `SET @IsAccess = 0` در ابتدای Procedure و فقط پس از اثبات مجوز مقدار ۱. تمام فراخواننده‌های این Helper باید در کل دیتابیس بررسی شوند (اولویت ۱). **شدت:** High · **اثبات:** Confirmed (نبود مقداردهی اولیه).

### ۸.۳ Permission SQL Fragment (زنجیرهٔ TypeId=20)

**F-024 — `MobspSetcmpDataPermission` و `CRMspSetcmpDataPermission` شرط مجوز مشتری را به‌شکل متن SQL در `CrmsysDBTempInfo` تولید می‌کنند** `[تأیید-مخزن — DELETE با TypeId=20 سپس INSERT در بدنهٔ MobspSetcmpDataPermission]`:

ریسک‌ها: Dynamic SQL، طول محدود متغیرهای رشته‌ای، Race Condition، استفادهٔ هم‌زمان چند درخواست، احتمال باقی‌ماندن Permission قدیمی. **تا زمانی که این سازوکار کاملاً بررسی و اصلاح نشده، نباید مرجع امنیتی مستقل API باشد.** **شدت:** High · **اثبات:** Confirmed (سازوکار) / اثر عملی: نیازمند تست.

### ۸.۴ حذف فرم‌های پویا

**F-030 — `MobspDyDeleteFormFieldMasterValuesBySysPart` ورودی `@SysPart` را با ۱۴ مقدار ثابت مقایسه می‌کند** `[تأیید-مخزن]`:

```sql
IF(LOWER(@SysPart) = 'cmp') ... ELSE IF(LOWER(@SysPart) = 'prs') ...
-- مقادیر ثابت: cmp, prs, prj, cnvs, pord, ord, bord, ssec, rsec, whdoc, whdraft, whmovement, prd, cms
```

تزریق مستقیم از مقدار دلخواه در مسیر عادی اثبات نشده است. هر دو رویه (`Mobsp…` و `ApispDyDeleteFormFieldMasterValuesBySysPart`) باید با Whitelist صریح و پارامترگذاری بازبینی شوند.

> **نکتهٔ تعارض:** بریفینگ گفته بود تعریف کامل `ApispDyDeleteFormFieldMasterValuesBySysPart` در استخراج سوم موجود نبود؛ بررسی فایل‌ها نشان می‌دهد این تعریف **هم در استخراج سوم (۴٬۵۷۶ کاراکتر) و هم در استخراج چهارم (۴٬۵۹۱ کاراکتر) موجود است** → [تعارض C-4](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده).

### ۸.۵ حذف گروهی پیش‌سفارش

**F-026 — `WSspDeletePreOrderFromPreOrderIndicator`** `[تأیید-مخزن]`:

- شرط SQL را از `CrmsysDBTempInfo` با `TypeId=30` می‌خواند: `SELECT @IndicatorTermTxt = Txt FROM dbo.CrmsysDBTempInfo WHERE TypeId = 30 AND UserId = @UserId`
- متن شرط را **مستقیم به SQL اضافه می‌کند**؛ یک اجرای Dynamic SQL دارد؛ **۱۸ دستور DELETE** دارد.
- در بدنهٔ استخراج‌شده **تراکنش واحد یا TRY/CATCH وجود ندارد**.
- رکوردهای متصل به سفارش یا سند را کنار می‌گذارد، سپس اطلاعات وابسته و خود پیش‌سفارش را حذف می‌کند.
- کنترل صریح مجوز ردیف والد در بدنه مشاهده نشد.
- **شدت:** Critical · **اثبات:** Confirmed (ساختار) / مسیر مجوز: Likely.

### ۸.۶ صدور سفارش از روی خرید

**F-029 — `WSspIssueOrderFromBuyOrder`** `[تأیید-مخزن برای ساختار]`:

- چند شناسهٔ مستقل (BuyOrderId، CompanyId، Contact، Project، User، Warehouse) دریافت می‌کند — ارتباط همهٔ شناسه‌ها با یکدیگر باید کنترل شود.
- شناسهٔ اقلام از JSON دریافت می‌شود (۵ ارجاع OPENJSON/JSON_VALUE).
- در مسیر بررسی‌شده، شرط صریح تعلق هر `BuyOrderItemId` به `BuyOrderId` ورودی دیده نشد.
- کنترل Action Permission و Warehouse Permission در بدنه به‌صورت روشن پیدا نشد.
- ۳ `BEGIN TRAN` بدون TRY/CATCH.
- **تا بررسی کامل، فقط مدیر و آن هم پس از اصلاح و آزمون امنیتی باید به این عملیات دسترسی داشته باشد.** **شدت:** Critical · **اثبات:** Likely (نیازمند اثبات Exploit و مسیر مجوز).

### ۸.۷ Helperهای محاسباتی

موارد زیر عملیات نوشتنی داخلی دارند (شمارش `UPDATE` در بدنه) `[تأیید-مخزن]` و **نباید مستقیماً به API عمومی تبدیل شوند**؛ فقط باید از عملیات کنترل‌شدهٔ والد فراخوانی شوند:

- `ApispCalcAndUpdateBuyOrderAmounts`
- `ApispCalcAndUpdateOrderAmounts` (۱۰ UPDATE)
- `ApispCalcAndUpdatePreOrderAmounts` (۶ UPDATE)
- `MobspCalcAndUpdatePreOrderAmounts` (۶ UPDATE)
- `WSspCalcAndUpdateStockSupplyFields` (۱ UPDATE)

---

## ۹. استخراج چهارم — ۱۳ قطعه

- اسکریپت: `ideal/ideal-write-audit-fourth-fixed.sql` (فقط فراداده؛ ۵ Result Set: ستون‌های جدول، ایندکس‌ها، فهرست ماژول‌ها با علت انتخاب، وابستگی‌ها، متن کامل تعاریف)
- خروجی: `ideal/ideal-write-audit-fourth-definitions.txt` (فرادادهٔ ۱۳۵ ماژول، قالب UTF-16) + **۱۳ قطعه** `ideal/ideal-write-audit-fourth-part-1.txt` تا `part-13.txt`
- مجموع: **≈ ۳٬۷۷۲٬۹۵۰ کاراکتر / ۸۷٬۳۰۳ خط** `[تأیید-مخزن]` · **۱۳۵ ماژول یکتا** `[تأیید-مخزن]`
- تمام ۱۳ قطعه دریافت و به‌ترتیب بررسی شده‌اند `[بریفینگ]`.

**خطای Collation (451):** در Result Set 5 به‌دلیل تعارض Collation بین `Arabic_CI_AI` (سرور/tempdb) و `Arabic_CI_AS` (دیتابیس) خطای SQL Server 451 رخ داده بود و اصلاح با `COLLATE DATABASE_DEFAULT` روی اجزای متنی انجام شد `[بریفینگ]`. **نکته:** نسخهٔ commit‌شدهٔ اسکریپت هیچ عبارت `COLLATE` ندارد → [تعارض C-5](#۱۵-تعارض‌ها-و-موارد-نیازمند-تأیید-ثبت-صریح-و-حل‌نشده) — متن دقیق اسکریپتِ اصلاح‌شدهٔ اجراشده در مخزن موجود نیست؛ خروجی موفق (۱۳ قطعه) موجود است.

### ۹.۱ جدول `CrmsysDBTempInfo`

یافته‌های Metadata `[تأیید-مخزن — از Result Set 1 و 2]`:

- ستون‌ها (۱۳ ستون): `ID bigint (PK)`، `UserId int`، `Guid uniqueidentifier`، `TypeId int`، `TXT nvarchar(max)`، `AppType varchar(20)`، `LanguageID int`، `FirstRegisterUserId int`، `FirstRegisterDatePersian varchar(8)`، `FirstRegisterDate datetime`، `TXTObjType nvarchar(400)`، `TXTJsResult nvarchar(max)`.
- **فقط یک ایندکس: `PK_CrmsysDBTempInfo` روی `ID`** — نه Unique Index روی (UserId, TypeId)، نه ایندکس ترکیبی روی (UserId, TypeId).
- Trigger متصل به جدول پیدا نشد (اسکریپت جست‌وجوی تریگر والد را داشت).

**F-025 — نتیجه:** استفاده از این جدول برای ذخیرهٔ وضعیت فیلتر یا مجوز هر درخواست می‌تواند **Race Condition** ایجاد کند (نوشتن/خواندن هم‌زمان چند درخواست روی همان UserId+TypeId بدون قید یکتایی). **شدت:** High · **اثبات:** Confirmed (ساختار) / اثر عملی: نیازمند تست.

### ۹.۲ زنجیرهٔ TypeId=30 (فیلتر/حذف گروهی پیش‌سفارش)

**تولیدکننده — `WSspSelectPreOrderIndicator`** `[تأیید-مخزن]`:

- شرط گزارش به‌شکل SQL متنی ساخته می‌شود؛ پارامترهایی مانند CompanyID، PreOrderNumber، StatusID، ReferUserId، PrdId، گروه محصول و فیلدهای سفارشی در ساخت شرط دخیل‌اند.
- **Scope فروشنده:** شرط بر اساس `pordReferUserId` و `CrmLinkedUsers` با `CrmUserId = @rptUserId` (خطوط ۱۱۲–۱۲۱) و `AND pordReferUserId IN ( ' + @ReferUserId + ')'` (خط ۲۸۳).
- شرط نهایی در `CrmsysDBTempInfo` با **TypeId=30** و `rptUserId` ذخیره می‌شود؛ **قبل از درج، رکوردهای قبلی همان UserId و TypeId حذف می‌شوند** (خطوط ۱۳۷۴–۱۳۸۲):
  ```sql
  DELETE CrmsysDBTempInfo WHERE UserId = @rptUserId ...
  INSERT INTO dbo.CrmsysDBTempInfo (UserId, TypeId, TXT) VALUES (@rptUserId, 30, @Term)
  ```
- این طراحی در درخواست‌های هم‌زمان می‌تواند باعث تداخل شود.
- `@rptUserId` بخشی از **مرز امنیتی داده** است و نباید از کلاینت پذیرفته شود؛ باید از هویت احراز‌شدهٔ سمت سرور تعیین شود.

**مصرف‌کنندگان مهم** `[تأیید-مخزن]`:

| مصرف‌کننده | رفتار | شواهد |
|---|---|---|
| `WSspDeletePreOrderFromPreOrderIndicator` | شرط ذخیره‌شده مستقیم به SQL الحاق؛ ۱ Dynamic SQL؛ ۱۸ DELETE؛ بدون تراکنش واحد/TRY-CATCH | F-026 |
| **F-027 — `WSspPreOrderGroupVerify`** | UPDATE پویا با الحاق مستقیم `@UserID` و `@RegisterDatePersian` و `@TermTXT`: `execute(' update WSPreOrder set pordIsVerified = 1, pordVerifierId = ' + @UserID + ', ... ' + @RegisterDatePersian + ' ' + @TermTXT + ' And isnull(pordIsVerified,0) = 0 ')` — بدون تراکنش/TRY-CATCH | کل بدنه ۶۷۳ کاراکتر، تأیید کامل |
| **F-027 — `WSspPreOrderGroupVerifyExit`** | همان الگو برای رفع تأیید/تثبیت (`pordIsVerified=0`، `pordIsFixed=0`) | ۶۸۴ کاراکتر |
| **F-028 — `WSspSelectPreOrdersInMode`** | در حالت خاص `@FDate='-20'` (خط ۵۷) شرط ذخیره‌شده به‌عنوان فیلتر استفاده می‌شود | Scope و اعتبار شرط باید جداگانه بررسی شود |

**نتیجه:** این زنجیره برای API جدید **قابل استفادهٔ مستقیم نیست**. فیلتر باید در API به شکل پارامتری و مستقل پیاده‌سازی شود.

### ۹.۳ زنجیرهٔ TypeId=90 (تأمین موجودی)

`WSspSelectStockSupply` نیز در حالت `@FDate='-20'` شرط متنی را از `CrmsysDBTempInfo` با **TypeId=90** می‌خواند و به کوئری الحاق می‌کند `[تأیید-مخزن: dbo.WSspSelectStockSupply.sql:59]` — الگوی مشابه زنجیرهٔ TypeId=30 در حوزهٔ دیگر؛ جزو اولویت ۱ (شناسایی کامل Producer/Consumer همهٔ TypeIdها).

---

## ۱۰. جدول تجمیعی یافته‌ها (Finding Registry)

| ID | شیء | نوع | شدت | اثبات | وضعیت بررسی |
|---|---|---|---|---|---|
| F-001 | `ApispSelectCompany` | افشای فیلد نام کاربری/رمز | High | Confirmed (ماهیت فیلد نیازمند تأیید) | باز — تا تعیین ماهیت، مسدود در DTO |
| F-002 | `ApispSelectCompanyPersons` | PII گسترده | High | Confirmed | باز — طراحی DTO حداقلی |
| F-003 | `ApispSelectCompanyPersons` | باگ FName+FName | Medium | Confirmed | باز |
| F-004 | `ApispSelectCompany` | Dynamic SQL (`@CmpCode`) | High | Confirmed (الگو) | باز |
| F-005 | `ApispSelectProducts` | Dynamic SQL (`@PrdCode`) | High | Confirmed (الگو) | باز |
| F-006 | `ApispRpt_WareHouseStock`، `WSspRpt_WareHousePrdMinStock` | Dynamic SQL (`@PrdModel`، `@Tracing`) | High | Confirmed (الگو) | باز |
| F-007 | `WSspSelectStockSupply` | شرط متنی TypeId=90 | High | Confirmed (سازوکار) | باز |
| F-008 | `WSspRpt_WareHousePrdMinStock` | دور زدن مجوز انبار با @WHID>0 | High | Confirmed | باز |
| F-009 | `WSspReturnPrdQuantity` | نبود کنترل مجوز انبار در بدنه | High | Confirmed (نبود ارجاع) / مسیر فراخوانی Likely | باز |
| F-010 | ۱۸ رویهٔ خواندنی | نبود تضمین Scope فروشنده در بدنه | High | Likely (محدودیت شواهد) | باز |
| F-011 | رویه‌های اقلام/پرداخت | دسترسی Child فقط با شناسهٔ والد | High | Confirmed (ساختار پارامتر) | باز |
| F-012 | `ApispSelectDocItems` | جوین اشتباه `ApiFirstRegisterUser` | Medium | Confirmed | باز |
| F-013 | `ApispSelectBuyOrderItems` | بازگشت ID به‌جای متن واحد پول | Low | Confirmed | باز |
| F-014 | چند رویه | پارامترهای بلااستفاده | Informational | Confirmed | باز |
| F-015 | `WSspSelectStockSupplyItems` | CAST بدون TRY_CONVERT | Medium | Confirmed | باز |
| F-016 | رویه‌های خواندنی | پذیرش UserId/مالکیت از ورودی | High | Confirmed (ساختار) | باز |
| F-017 | ۶ رویهٔ Update (استخراج ۱) | Dynamic SQL اتصال رشته‌ای | Critical | Confirmed (الگو) | باز |
| F-018 | ۴ رویهٔ Update + ۳ Helper Duplicate (استخراج ۲) | Dynamic SQL/اتصال رشته‌ای | Critical | Confirmed (الگو) | باز |
| F-019 | رویه‌های Insert | نبود کنترل مالکیت/مجوز صریح | High | Likely | باز |
| F-020 | `MobspInsertPreOrderFull` | Delimiter سفارشی نه JSON | Medium | Confirmed | باز |
| F-021 | ۱۶ ماژول استخراج ۱ | الگوی معیوب @@ERROR | Medium | Confirmed | باز |
| F-022 | عملیات نوشتنی | نبود Idempotency | High | Confirmed (نبود نشانه) | باز |
| F-023 | `MobspCheckCmpDataPermissionForUser` | @IsAccess بدون مقداردهی اولیه | High | Confirmed | باز — اصلاح + بررسی فراخواننده‌ها |
| F-024 | `MobspSetcmpDataPermission`، `CRMspSetcmpDataPermission` | Permission SQL Fragment در جدول مشترک | High | Confirmed (سازوکار) | باز |
| F-025 | `CrmsysDBTempInfo` | Race Condition ساختاری | High | Confirmed (ساختار) | باز |
| F-026 | `WSspDeletePreOrderFromPreOrderIndicator` | ۱۸ DELETE + Dynamic SQL بدون تراکنش | Critical | Confirmed (ساختار) | باز |
| F-027 | `WSspPreOrderGroupVerify`/`Exit` | UPDATE پویا با الحاق UserID/تاریخ/شرط ذخیره‌شده | Critical | Confirmed (کل بدنه) | باز |
| F-028 | `WSspSelectPreOrdersInMode` | حالت `@FDate='-20'` با شرط ذخیره‌شده | High | Confirmed | باز |
| F-029 | `WSspIssueOrderFromBuyOrder` | اعتماد به شناسه‌های مستقل + JSON بدون اثبات والد | Critical | Likely | باز — فقط مدیر پس از اصلاح |
| F-030 | `Mobsp…`/`Apisp…DyDeleteFormFieldMasterValuesBySysPart` | حذف پویا با مقایسهٔ ثابت | Medium | Confirmed (Whitelist؛ تزریق مستقیم اثبات نشده) | باز |
| F-031 | ۵ Helper محاسباتی | عملیات نوشتنی داخلی | Medium | Confirmed | سیاست: فقط از والد کنترل‌شده |
| F-032 | دیتابیس زنده | FKهای Untrusted / نبود RowVersion/CDC/Temporal | High (معماری همگام‌سازی) | Confirmed (گزارش زنده) | باز |

**یادآوری:** «Confirmed» در این جدول یعنی *شواهد کدی/ساختاری مستقیم*؛ اثر امنیتی عملی همهٔ موارد نیازمند تست Integration و Security Test جداگانه است.

---

## ۱۱. تصمیم معماری API نسخهٔ اول (خواندنی)

### ۱۱.۱ Endpointهای پیشنهادی

**SalesRep:**

- `GET /api/v1/ideal/companies`
- `GET /api/v1/ideal/companies/{companyId}/contacts`
- `GET /api/v1/ideal/products`
- `GET /api/v1/ideal/products/{productId}/prices`
- `GET /api/v1/ideal/inventory/availability`
- `GET /api/v1/ideal/pre-orders`
- `GET /api/v1/ideal/orders`
- `GET /api/v1/ideal/pre-orders/{id}/items`
- `GET /api/v1/ideal/orders/{id}/items`

**Manager / Warehouse:**

- `GET /api/v1/ideal/inventory/stock`
- `GET /api/v1/ideal/inventory/low-stock`
- `GET /api/v1/ideal/documents`
- `GET /api/v1/ideal/documents/{id}/items`
- `GET /api/v1/ideal/purchase-orders`
- `GET /api/v1/ideal/purchase-orders/{id}/items`
- `GET /api/v1/ideal/purchase-orders/{id}/payments`
- `GET /api/v1/ideal/stock-supplies`
- `GET /api/v1/ideal/stock-supplies/{id}/items`

> تعریف دقیق Warehouse List باید **بعد از استخراج `ApispSelectWareHouse`** انجام شود.

### ۱۱.۲ قواعد DTO و شناسه‌ها

- DTOها حداقلی و مستقل از خروجی خام SP باشند.
- Credentialها و فیلدهای حساس (F-001، F-002) حذف شوند.
- `sourceSystem="ideal"` و `sourceId` برای ترکیب با داده‌های Holoo در نظر گرفته شود.
- **هیچ شناسهٔ مالکیت یا User ID از کلاینت پذیرفته نشود** (F-016).
- Parent Authorization قبل از خواندن Child Record الزامی است (F-011).
- دسترسی به انبار بر اساس Permission سمت سرور اعمال شود (F-008، F-009).

### ۱۱.۳ جداسازی منابع

Ideal و Holoo دو منبع مستقل‌اند و Namespace و Source ID هر کدام جداگانه حفظ می‌شود:

- **Ideal:** مشتری، CRM، فروش، محصول، انبار
- **Holoo:** حسابداری و مالی

---

## ۱۲. سیاست عملیات نوشتنی (وضعیت فعلی: مسدود)

در این مرحله **API نوشتنی هنوز تأیید نشده است**:

| حوزه | سیاست فعلی |
|---|---|
| مشتری و شخص تماس | تا رفع Dynamic SQL و کنترل مالکیت **مسدود** |
| محصول و قیمت | فقط مدیر، پس از ممیزی کامل |
| سفارش و پیش‌سفارش | تا رفع Parent/Child Authorization و اعتبارسنجی روابط **مسدود** |
| صدور سند و تأمین موجودی | عملیات حساس و مدیرمحور؛ فعلاً **مسدود** |
| حذف، تأیید، ابطال، تثبیت، انتقال و تغییر وضعیت | خارج از API نسخهٔ اول تا تکمیل ممیزی |

**تمام عملیات نوشتنی آینده باید:** Idempotency Key داشته باشند؛ Audit کامل داشته باشند؛ Authorization سمت سرور داشته باشند؛ Parent/Child Relationship Validation داشته باشند؛ Transaction و Rollback مشخص داشته باشند؛ خطاها و خروجی‌ها قابل اتکا طراحی شوند؛ از Dynamic SQL ناامن اجتناب کنند.

---

## ۱۳. کارهای باقی‌مانده به ترتیب اولویت

### اولویت ۱ — تکمیل ممیزی Permission

- تمام فراخواننده‌های `MobspCheckCmpDataPermissionForUser` در کل دیتابیس پیدا شوند (شامل ۵ فراخوانی داخل `MobspInsertQuickCompany`).
- تمام فراخواننده‌های `MobspCheckActionForUser` بررسی شوند.
- تمام محل‌های استفادهٔ `MobspSetcmpDataPermission` و `CRMspSetcmpDataPermission` بررسی شوند.
- مسیرهای **TypeId=20، 30، 90** و سایر TypeIdها کامل شناسایی شوند؛ Producer و Consumer هر نوع فیلتر ذخیره‌شده ثبت شود.
- مشخص شود کدام کنترل‌ها فقط **Action Permission** و کدام **Row-Level Permission** هستند.

### اولویت ۲ — ممیزی عملیات تغییر وضعیت

دسته‌بندی تمام خانواده‌ها: Verify/UnVerify · Fixed/UnFixed · Issue/Cancel · Delete/Remove · Transfer · Confirm/Reject · Close/Open · Exit.

برای هر عملیات: چه رکوردهایی تغییر می‌کنند؟ مجوز چگونه بررسی می‌شود؟ Parent Authorization وجود دارد؟ Transaction وجود دارد؟ Retry امن است؟ عملیات برگشت‌پذیر است؟

(نقطهٔ شروع: ۴۵ ماژول `WSsp*` موجود در فایل کامل استخراج سوم که در مجموعهٔ ۳۶۱تایی نیستند.)

### اولویت ۳ — تکمیل ممیزی Dynamic SQL

تمام رویه‌های Update بررسی‌شده (۱۰ مورد)، Helperهای Duplicate Check، رویه‌های Delete پویا، رویه‌های گزارش‌گیری با فیلتر متنی، و تمام موارد `EXEC`/`sp_executesql`. هر یافته با: کد واقعی، پارامتر ورودی، مسیر فراخوانی، شدت، روش اصلاح.

### اولویت ۴ — رابطهٔ والد و فرزند

به‌ویژه: BuyOrder↔BuyOrderItems · Order↔OrderItems · PreOrder↔PreOrderItems · Document↔DocumentItems · Company↔ContactPersons · PreOrder↔StockSupply · Warehouse↔Stock Documents.

### اولویت ۵ — تثبیت قرارداد Read API

Endpointها · DTOها · Authorization Matrix · Pagination · Date Filtering · Error Contract · Audit · Rate Limit · Incremental Sync Strategy.

### کارهای کوچک ثبت‌شده در این سند

- ثبت اجرای موفق مجدد ابزار کاوش (گزارش ۸ تریگر / ۰ هشدار) در `WORKLOG.md` (بخش ۲.۴).
- تعیین تکلیف فهرست ۱۸تایی بریفینگ (بند ۱۸) با فایل واقعی (تعارض C-1).

---

## ۱۴. قالب ثبت یافته‌های جدید

هر یافتهٔ جدید با این ساختار ثبت شود:

```text
Finding ID:        F-0XX
Stored Procedure / Object:
نوع یافته:
شدت:               Critical / High / Medium / Low / Informational
شواهد مستقیم از کد:   (فایل + شمارهٔ خط + قطعهٔ کد)
ورودی‌های مؤثر:
مسیر فراخوانی:
اثر امنیتی یا صحت داده:
وضعیت اثبات:       Confirmed / Likely / Unverified / False Positive
روش اصلاح:
وابستگی‌ها:
تست مورد نیاز:
وضعیت بررسی:
```

---

## ۱۵. تعارض‌ها و موارد نیازمند تأیید (ثبت صریح و حل‌نشده)

این تعارض‌ها بین اطلاعات بریفینگ و محتوای واقعی مخزن شناسایی شدند؛ **هیچ‌کدام حدس زده یا «حل» نشده‌اند:**

| ID | موضوع | بریفینگ می‌گوید | فایل‌های مخزن می‌گویند | وضعیت |
|---|---|---|---|---|
| **C-1** | بند ۱۸ فهرست رویه‌های خواندنی | `WSspRpt_WareHouseStock` | فایل واقعی: `dbo.ApispSelectProducts.sql`؛ `WSspRpt_WareHouseStock` در هیچ استخراجی نیست | حل‌نشده — فهرست ۴.۱ این سند مبنای ادامهٔ کار است |
| **C-2** | تعداد ماژول‌های استخراج دوم | ۳۷ ماژول | ۳۶ سرصفحه/تعریف در `ideal-write-audit-next-definitions.txt` | حل‌نشده |
| **C-3** | تعداد تعریف‌های استخراج سوم | «۳۶۱ تعریف» | فایل کامل ۴۰۶ ماژول؛ مجموعهٔ ۷ قطعه ۳۶۱ ماژول یکتا؛ ۴۵ ماژول `WSsp*` فقط در فایل کامل؛ `WSspIssueOrderFromPreOrder` در هر دو با طول متفاوت | توضیح ساختاری داده شد؛ کدام مجموعه «مبنای بازبینی» بوده قطعی نیست — هر دو عدد معتبر |
| **C-4** | تعریف `ApispDyDeleteFormFieldMasterValuesBySysPart` در استخراج سوم | «موجود نبود» | در هر دو استخراج سوم (۴٬۵۷۶ کاراکتر) و چهارم (۴٬۵۹۱ کاراکتر) موجود است | حل‌نشده |
| **C-5** | اصلاح Collation (خطای 451) | اصلاح با `COLLATE DATABASE_DEFAULT` روی اجزای متنی | اسکریپت commit‌شده (`ideal-write-audit-fourth-fixed.sql`) هیچ `COLLATE` ندارد؛ خروجی موفق ۱۳ قطعه موجود است | حل‌نشده — متن دقیق اسکریپت اجراشده در مخزن نیست |
| **C-6** | اسکریپت استخراج دور دوم | — | هیچ فایل SQL برای دور دوم در مخزن commit نشده | ثبت وضعیت — در صورت نیاز باید از مالک پرسیده شود |
| **C-7** | «رویه‌های Insert کنترل مالکیت ندارند» (بیان کلی بریفینگ) | — | `MobspInsertQuickCompany` پنج فراخوانی `MobspCheckCmpDataPermissionForUser` دارد (البته Helper معیوب F-023)؛ هشت رویهٔ Insert دیگر صفر فراخوانی | تفکیک ثبت شد — بیان کلی باید با همین دقت نقل شود |

**موارد نیازمند تأیید مالک/کسب‌وکار:**

- ماهیت واقعی فیلدهای `cmpUserName`/`cmpPassword` (F-001).
- معنای محاسبهٔ پیش‌سفارش‌های جزئی و لغوشده.
- تأیید اجرای مجدد ابزار کاوش با بستهٔ `dev-12.5.3` (گزارش ۸ تریگر) و ثبت آن در WORKLOG.
- `ideal/6afd73bb-0a84-83eb-8858-93609d1d6fbc.htm` (صفحهٔ کمکی دور چهارم) — محتوای آن مبنای شواهد این سند نیست.

---

## ۱۶. وضعیت نهایی و محدودیت شواهد

**به‌صراحت ثبت می‌شود:**

- **هیچ Stored Procedure روی دیتابیس واقعی اجرا نشده است.**
- **هیچ دادهٔ تجاری از دیتابیس خوانده نشده است.**
- **هیچ تغییری در Schema یا دادهٔ دیتابیس انجام نشده است.**
- بررسی‌ها **Static Audit** روی Module Definitions و Metadata بوده‌اند (تعاریف استخراج‌شده با `SELECT` روی نمای‌های کاتالوگ توسط حساب فقط-فراداده).
- **نبود یک Permission Call در بدنهٔ یک SP به‌تنهایی اثبات نمی‌کند** که در تمام مسیر فراخوانی هیچ مجوزی اعمال نمی‌شود (ممکن است لایهٔ Application اعمال کند).
- **Regex Scan برای شناسایی اولیه بوده** و نتیجهٔ قطعی نیست.
- برخی رفتارهای تجاری باید با **مالک کسب‌وکار** تأیید شوند.
- همهٔ موارد نیازمند **تست Integration و Security Test جداگانه** هستند.

---

## ۱۷. تاریخچهٔ Git مرتبط

کامیت‌های مرتبط با ممیزی روی شاخهٔ `ideal` (قدیمی → جدید):

| کامیت | موضوع |
|---|---|
| `ab9ff34`، `ad0248d`، `6bfb8c2` | `procedure-definitions` (۱۸ تعریف + manifest) |
| `03946bd` | `ideal-write-audit` (اسکریپت دور ۱) |
| `8e19528` | `ideal-write-audit-definitions` (۱۹ ماژول) |
| `feeb770` | `ideal-write-audit-next-definitions` (۳۶ ماژول) |
| `57400bc` | `ideal-write-audit-third` (اسکریپت دور ۳) |
| `ff3b715` | `ideal-write-audit-third-definitions` (۴۰۶ ماژول) |
| `951089a` | `ideal-write-audit-third-part-1..7` (۳۶۱ ماژول) |
| `2305ed7` | `ideal-write-audit-fourth-definitions` (+ فایل کمکی htm) |
| `0ed4469` | `ideal-write-audit-fourth-fixed` (اسکریپت دور ۴) |
| `4d44b6b` | `ideal-write-audit-fourth-part-*.txt` (۱۳ قطعه) |
| `d5ee55b` | fix(ideadump): رفع خطای استخراج تریگرها — فاز ۱۲.۵.۳ (پیش‌نیاز گزارش زندهٔ تریگرها) |

پیشینهٔ کامل فازها (۸ تا ۱۲.۵.۳) با SHAها در `ideal/IdealBridge/docs/WORKLOG.md`.

---

**پایان سند — این سند صرفاً مستندسازی است. ورود به اصلاح Stored Procedure یا پیاده‌سازی API تنها پس از تأیید مالک و با اجرای اولویت‌های بخش ۱۳ انجام می‌شود.**
