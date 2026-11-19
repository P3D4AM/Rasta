# ممیزی امنیتی عملیات نوشتنی Ideal CRM — سند مرجع (Write API Security Audit)

> **مسیر:** `ideal/IdealBridge/docs/IDEAL_WRITE_API_SECURITY_AUDIT.md`
> **مخزن/شاخه:** `P3D4AM/Rasta` — شاخهٔ **`ideal`**
> **تاریخ نقطهٔ کنترل:** ۲۰۲۶-۱۱-۱۹
> **ماهیت سند:** ثبت نتایج **Static Code Review** ممیزی امنیتی عملیات نوشتنی (INSERT/UPDATE/DELETE/صدور) دیتابیس `crmideal` — **این سند صرفاً مستندسازی است و هیچ تغییر عملکردی، کد، SQL عملیاتی، تنظیمات اتصال یا دیتابیسی با آن انجام نمی‌شود.**
> **جایگاه:** این سند **مرجع اصلی ممیزی امنیتی عملیات نوشتنی** است. ممیزی عملیات خواندنی در اسناد `01-ideal-api-reverse-engineering.md`، `IDEAL_API_MAPPING.md`، `IDEAL_SECURITY_ALLOWLIST.md` و `IDEAL_PII_AUDIT.md` ثبت شده و اینجا تکرار نمی‌شود (فقط ارجاع — پیوست الف).

---

## فهرست

- [۰. راهنمای وضعیت‌های یافته](#۰-راهنمای-وضعیت‌های-یافته)
- [۱. دامنه و محدودیت بررسی](#۱-دامنه-و-محدودیت-بررسی)
- [۲. منابع استخراج‌شده در مخزن](#۲-منابع-استخراج‌شده-در-مخزن)
- [۳. یافته‌های سری اول — پروسیجرهای اصلی نوشتنی](#۳-یافته‌های-سری-اول--پروسیجرهای-اصلی-نوشتنی)
- [۴. یافته‌های سری دوم — کالا، قیمت، خرید، سند و تأمین موجودی](#۴-یافته‌های-سری-دوم--کالا-قیمت-خرید-سند-و-تأمین-موجودی)
- [۵. یافته‌های سری سوم و چهارم — فیلترهای موقت `CrmsysDBTempInfo`](#۵-یافته‌های-سری-سوم-و-چهارم--فیلترهای-موقت-crmSysdbtempinfo)
- [۶. عملیات گروهی پیش‌سفارش (TypeId=30)](#۶-عملیات-گروهی-پیش‌سفارش-typeid30)
- [۷. تبدیل سفارش خرید به سفارش فروش](#۷-تبدیل-سفارش-خرید-به-سفارش-فروش)
- [۸. اسناد و انبار — موارد تکمیلی](#۸-اسناد-و-انبار--موارد-تکمیلی)
- [۹. عملیات حساس CRM (حذف/تأیید/ابطال)](#۹-عملیات-حساس-crm-حذفتأییدابطال)
- [۱۰. یافته‌های BOLA/IDOR در روابط CRM](#۱۰-یافته‌های-bolaidor-در-روابط-crm)
- [۱۱. ممیزی Controllerهای مکالمه و پروژه](#۱۱-ممیزی-controllerهای-مکالمه-و-پروژه)
- [۱۲. ممیزی Controllerهای سفارش و پیش‌سفارش](#۱۲-ممیزی-controllerهای-سفارش-و-پیش‌سفارش)
- [۱۳. پروسیجرهای SQL مسیر تأیید/اصلاح سفارش و پیش‌سفارش](#۱۳-پروسیجرهای-sql-مسیر-تأییداصلاح-سفارش-و-پیش‌سفارش)
- [۱۴. سیاست معماری و امنیت API](#۱۴-سیاست-معماری-و-امنیت-api)
- [۱۵. اولویت اصلاحات](#۱۵-اولویت-اصلاحات)
- [۱۶. کارهای بعدی](#۱۶-کارهای-بعدی)
- [پیوست الف — ارجاع به اسناد موجود و مرز اطلاعات تکراری](#پیوست-الف--ارجاع-به-اسناد-موجود-و-مرز-اطلاعات-تکراری)
- [پیوست ب — ثبت تعارض‌ها و موارد نیازمند تأیید](#پیوست-ب--ثبت-تعارض‌ها-و-موارد-نیازمند-تأیید)
- [پیوست ج — تاریخچهٔ Git استخراج‌های این ممیزی](#پیوست-ج--تاریخچه-git-استخراج‌های-این-ممیزی)

---

## ۰. راهنمای وضعیت‌های یافته

هر یافتهٔ این سند دقیقاً با یکی از وضعیت‌های زیر علامت‌گذاری می‌شود:

| وضعیت | معنا |
|---|---|
| **Confirmed Static Finding** | الگو/رفتار در تعریف استخراج‌شدهٔ SQL (یا سورس دیکامپایل‌شدهٔ Controller) به‌صورت ایستا مشاهده و با مسیر فایل/خط ثبت شده است. |
| **Potential Risk** | ریسک محتمل بر پایهٔ مشاهدهٔ ایستا، اما بهره‌برداری‌پذیری واقعی (ورود دادهٔ غیرقابل‌اعتماد به مسیر، شرایط اجرا) **اثبات نشده** است. |
| **Controller Mitigation Observed** | کنترل جبرانی در لایهٔ Controller (سورس دیکامپایل‌شده) مشاهده شده؛ این کنترل **جایگزین کنترل مستقل SP نیست** و فقط برای همان مسیر Controller معتبر است. |
| **SQL Definition Pending** | تعریف کامل SQL در مجموعهٔ فایل‌های فعلی مخزن موجود نیست؛ تا رسیدن تعریف، هیچ نتیجهٔ قطعی ثبت نمی‌شود. |
| **Runtime Verification Pending** | قضاوت نیازمند اجرای فقط-خواندنی روی دیتابیس واقعی (فراداده/امضا) یا مشاهدهٔ رفتار اجرایی است. |

**اصل صادقانه:** نبودِ یک کنترل در بخشی از کد به‌تنهایی **اثبات بهره‌برداری‌پذیری نیست**. نتیجهٔ جستجوی متنی هم هرگز به‌عنوان اثبات آسیب‌پذیری ثبت نمی‌شود؛ مبنای ثبت، مشاهدهٔ مستقیم تعریف SQL است.

---

## ۱. دامنه و محدودیت بررسی

1. همهٔ تحلیل‌های این سند **Static Code Review** هستند: بررسی تعریف ماژول‌های SQL استخراج‌شده (از `sys.sql_modules`) و سورس دیکامپایل‌شدهٔ Controllerها.
2. **هیچ Stored Procedure نوشتنی روی دیتابیس واقعی اجرا نشده است.** اسکریپت‌های استخراج (`ideal/ideal-write-audit.sql`، `ideal/ideal-write-audit-third.sql`، `ideal/ideal-write-audit-fourth-fixed.sql`) فقط از نمای‌های کاتالوگ سیستم (`sys.sql_modules`، `sys.objects`، `sys.columns`، `sys.indexes`، `sys.sql_expression_dependencies`، `sys.triggers`) می‌خوانند و در سربرگ خود تصریح دارند که هیچ ردیف تجاری انتخاب/درون‌ریزی/ویرایش/حذف نمی‌کنند.
3. **هیچ دادهٔ تجاری از جداول واقعی خوانده نشده است.**
4. **هیچ تغییر دیتابیس، Schema، کد عملیاتی یا تنظیمات اتصال** در نتیجهٔ این ممیزی انجام نشده و انجام نمی‌شود.
5. نتیجه‌گیری‌ها فقط برای ماژول‌هایی ثبت شده که تعریف کامل آن‌ها در مخزن موجود است؛ برای بقیه وضعیت `SQL Definition Pending` است (بخش ۱۳).
6. کنترل‌های Controller در سورس دیکامپایل‌شده بررسی شده‌اند؛ **امنیت یک مسیر Controller هرگز به امنیت مستقل SP تعمیم داده نمی‌شود** (و بالعکس).

---

## ۲. منابع استخراج‌شده در مخزن

همهٔ مسیرها نسبت به ریشهٔ مخزن. شمارش ماژول‌ها با شمارش سربرگ‌های `-- [dbo].[…]` (یا `-- [schema].[name] | Reason` در استخراج چهارم) در همین نقطهٔ کنترل راستی‌آزمایی شده است.

| # | فایل (مسیر در مخزن) | محتوا | شمارش/اندازه |
|---|---|---|---|
| ۱ | `ideal/ideal-write-audit-definitions.txt` | استخراج اول — ۱۹ ماژول: **۱۶ پروسیجر + ۱ View + ۲ Function** (درج/ویرایش شرکت، شخص، سفارش، پیش‌سفارش، اقلام، پرداخت + `WSfnProductsInGroups(_Lang)` + `CRMvwSelectCompanyPersons`) | ۱۸٬۵۶۹ خط |
| ۲ | `ideal/ideal-write-audit-next-definitions.txt` | استخراج دوم — ۳۶ ماژول: کالا، قیمت، سفارش خرید، اقلام خرید، سند، تأمین موجودی + Helperهای بررسی تکراری و `MobspCheckCmpDataPermissionForUser` | ۱۳٬۳۸۳ خط |
| ۳ | `ideal/ideal-write-audit-third-definitions.txt` | استخراج سوم — ۴۰۶ ماژول (خانواده‌های `Apisp/Mobsp/WSsp` با نام‌های حاوی Delete/Remove/Verify/UnVerify/Fixed/Issue/Cancel/Transfer/Exit + اهداف دقیق) | ۷۲٬۳۱۵ خط |
| ۴ | `ideal/ideal-write-audit-third-part-1.txt` … `third-part-7.txt` | همان استخراج سوم در ۷ قطعه — مجموعاً **۳۶۱ ماژول**، زیرمجموعهٔ بازبینی‌شده | ~۶۴٬۸۴۴ خط |
| ۵ | `ideal/ideal-write-audit-third.sql` | اسکریپت استخراج سوم (فقط-فراداده) | ۱۱۲ خط |
| ۶ | `ideal/ideal-write-audit-fourth-definitions.txt` | خروجی مرحلهٔ فرادادهٔ استخراج چهارم — ساختار ستون‌ها و ایندکس `CrmsysDBTempInfo` + فهرست ماژول‌های هدف («Exact target» / «References permission/temp-filter machinery») — **کدگذاری UTF-16** (به همین دلیل Git آن را باینری می‌شمارد) | ۱۵۲ خط |
| ۷ | `ideal/ideal-write-audit-fourth-fixed.sql` | اسکریپت استخراج چهارم (فقط-فراداده؛ شامل کوئری تریگرهای `CrmsysDBTempInfo`) | ۱۳۸ خط |
| ۸ | `ideal/ideal-write-audit-fourth-part-1.txt` … `fourth-part-13.txt` | استخراج چهارم — ۱۳ قطعه، **۱۳۵ ماژول یکتا** با تعریف کامل؛ هر قطعه بلوک فرادادهٔ `CrmsysDBTempInfo` را نیز تکرار می‌کند | ~۸۷٬۳۱۵ خط |
| ۹ | `ideal/procedure-definitions/` | ۱۸ پروسیجر **خواندنی** به‌صورت فایل مجزا + `manifest.csv` (طول و SHA256 هر تعریف) — مبنای ممیزی عملیات خواندنی؛ اینجا فقط به‌عنوان مرز مرجع ثبت می‌شود | ۱۸ SQL + manifest |
| ۱۰ | `ideal-live-schema-report.json` | گزارش اسکیمای زنده (خروجی `IdeaSchemaDump`) — **فقط در محیط مالک؛ وارد Git نشده و نباید شود.** هرجا از آن نقل شده، صراحتاً ذکر می‌شود. | خارج از مخزن |
| ۱۱ | `ideal/order-preorder-procedure-parameters.txt` | **استخراج مالک (کامیت `e6968a0`، ۲۰۲۶-۱۱-۱۹)** — تعریف کامل ۴ پروسیجر در قالب رکورد تک‌خطی (`Name | 1 | dbo | SQL_STORED_PROCEDURE | <تعریف>`): `MobspOrderVerifyWithPreChecks`، `MobspPreOrderVerifyWithPreChecks`، `MobspUpdateOrder`، `MobspUpdatePreOrder` | ۷۷٬۶۸۵ بایت / ۴ رکورد |
| ۱۲ | `ideal/order-preorder-procedure-definitions.txt` | همان استخراج مالک — فقط تعریف `MobspUpdateOrder` | ۳۱٬۹۵۷ بایت |
| ۱۳ | `ideal/order-preorder-procedure-parameters - Copy.txt` | همان استخراج مالک — امضای پارامترهای ۴ پروسیجر بالا (نام/نوع/طول/دقت/خروجی‌بودن؛ قالب TSV) | ۳۶ خط |

**یادداشت‌های صادقانهٔ موجودیت فایل‌ها:**

- سه فایل ردیف‌های ۱۱ تا ۱۳ **پیش از ثبت این نقطهٔ کنترل و پس از شروع تدوین آن** توسط مالک به شاخهٔ `ideal` push شدند (`e6968a0`) و در همین بازبینی لحاظ و در بخش ۱۳ تحلیل شدند — تحویل مستقیم خواستهٔ بند ۱ بخش ۱۶.
- فایل `ideal/6afd73bb-0a84-83eb-8858-93609d1d6fbc.htm` یک صفحهٔ ذخیره‌شدهٔ مرورگر است که همراه کامیت استخراج چهارم (`2305ed7`) به مخزن راه یافته؛ **جزو شواهد ممیزی نیست** و فقط برای شفافیت موجودیت‌شناسی فهرست شده است. حذف/تغییر آن خارج از محدودهٔ این سند است.
- `ideal/procedure-definitions.zip` نیز در `ideal/` وجود دارد (نسخهٔ فشردهٔ همان پوشه).
- هیچ‌یک از فایل‌های استخراج در این نقطهٔ کنترل بازنویسی یا حذف نشده‌اند.

---

## ۳. یافته‌های سری اول — پروسیجرهای اصلی نوشتنی

دامنهٔ بازبینی: ۱۶ پروسیجر، یک View و دو Function از `ideal/ideal-write-audit-definitions.txt` (کامیت `8e19528`).

### ۳.۱ شش پروسیجر Update با SQL پویا و الحاق رشته — الگوی مشترک

هر شش پروسیجر، قطعه‌های دستور `UPDATE` را در متغیرهای متنی (نام‌های رایج: `@Columns`/`@QRY`/`@Conditions`) می‌سازند و سپس با `EXECUTE(@QRY + @Columns + @Conditions)` اجرا می‌کنند — **بدون `sp_executesql` و بدون پارامتری‌سازی**:

| پروسیجر | تعریف در `ideal/ideal-write-audit-definitions.txt` (خط شروع) | نشانهٔ الحاق رشته در بدنه |
|---|---|---|
| `ApispUpdateCompany` | 3934 | ۱۷۷ قطعه‌سازی `SET @… = @… + '…'` + دو بار `EXECUTE(@QRY + @Columns + @Conditions)` |
| `ApispUpdateCompanyPerson` | 6540 | ۱۴۰ قطعه‌سازی + دو بار `EXECUTE (@Qry + @Columns + @Conditions)` |
| `ApispUpdateOrder` | 7721 | ۱۷۲ قطعه‌سازی + دو بار `EXECUTE` |
| `ApispUpdateOrderItems` | 9361 | ۹۹ قطعه‌سازی + دو بار `EXECUTE` |
| `ApispUpdatePreOrder` | 10349 | ۱۸۶ قطعه‌سازی + دو بار `EXECUTE` |
| `ApispUpdatePreOrderItems` | 11996 | ۸۸ قطعه‌سازی + دو بار `EXECUTE` |

وضعیت: الگوی SQL پویا **Confirmed Static Finding**؛ بهره‌برداری‌پذیری تزریق به ازای هر پروسیجر نیازمند اثبات مسیر ورود دادهٔ غیرقابل‌اعتماد به قطعه‌های متنی است — تا آن اثبات، ریسک تزریق **Potential Risk** ثبت می‌شود. اصلاح همهٔ موارد با `sp_executesql` + پارامترها + Whitelist نام ستون‌ها الزامی است (بخش ۱۴، اصل ۷).

### ۳.۲ کنترل مالکیت و روابط در پروسیجرهای Insert

- **`ApispInsertOrder`** (خط 1483) و **`ApispInsertPreOrder`** (خط 2822): کنترل کافی و آشکار **مالکیت شرکت** (تعلق سفارش به شرکتِ مجازِ کاربرِ فراخوان) در بدنهٔ بررسی‌شده مشاهده نشد — **Potential Risk** (کامل‌نبودِ اثباتِ کنترل، نه اثبات آسیب).
- **`ApispInsertCompanyPersons`** (خط 1041): کنترل مستقل دسترسی به **شرکت والد** پیش از درج شخص مشاهده نشد — **Potential Risk**.
- **`ApispInsertOrderItems`** (خط 2170) و **`ApispInsertOrderPayments`** (خط 2616): کنترل وضعیت رکورد وجود دارد (**Confirmed Static Finding** — وجود کنترل وضعیت)، اما مالکیت سفارشِ والد به‌طور کامل اثبات نشد — **Potential Risk**.

### ۳.۳ قالب ورودی `MobspInsertPreOrderFull`

این پروسیجر (خط 12998) ورودی را با الگوی delimiter-based شامل `|#|` بین فیلدها و `=` بین نام/مقدار تجزیه می‌کند (`PATINDEX('%|#|%', @PreOrder)` و `CHARINDEX('=', @PreOrder)` در حدود خط 13287) — نه قرارداد JSON. وضعیت: **Confirmed Static Finding** (قالب ورودی) + دلالت طراحی: قالب متن‌محور مستعد خطای تجزیه و خطای ساختاری است — **Potential Risk**.

### ۳.۴ مدیریت خطا و Idempotency

- در چند پروسیجر الگوی `IF (@@ERROR > 0) BEGIN SET @ErrorFrom='…' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END` مشاهده می‌شود (نمونه‌ها: خطوط 998-999، 1441-1442، 1914-1915؛ در کل ۵۴ ارجاع `@@ERROR` در همین فایل). چون `SET` پیش از خواندن `@@ERROR` اجرا می‌شود، مقدار `@@ERROR` در لحظهٔ انتساب معمولاً بازنشانی شده و **شمارهٔ خطای واقعی از بین می‌رود** — **Confirmed Static Finding**.
- برخی مسیرها ممکن است با وجود خطای اعتبارسنجی، خروجی عددی «موفقیت‌نما» برگردانند — **Potential Risk** (نیازمند اثبات مسیر اجرایی دقیق).
- **Idempotency برای عملیات نوشتنی تضمین نشده است** — **Potential Risk** (بخش ۱۴ اصل ۵؛ بخش ۱۵ P2).

---

## ۴. یافته‌های سری دوم — کالا، قیمت، خرید، سند و تأمین موجودی

دامنهٔ بازبینی: ۳۶ ماژول از `ideal/ideal-write-audit-next-definitions.txt` (کامیت `feeb770`).

### ۴.۱ چهار پروسیجر Update دیگر با SQL پویا (مکمل سری اول)

| پروسیجر | تعریف در `ideal/ideal-write-audit-next-definitions.txt` (خط شروع) |
|---|---|
| `ApispUpdateBuyOrder` | 4105 |
| `ApispUpdateBuyOrderItems` | 5330 |
| `ApispUpdateProductPrice` | 6265 |
| `ApispUpdateProducts` | 6616 |

با افزودن به شش مورد بخش ۳.۱، **حداقل ۱۰ پروسیجر Update** دارای الگوی SQL پویا و پرخطر شناخته شده‌اند. وضعیت: الگو **Confirmed Static Finding**؛ امکان ورود دادهٔ غیرقابل‌اعتماد به قطعه‌های متنی هر پروسیجر باید **تک‌تک** بررسی و اثبات/رد شود — تا آن زمان بهره‌برداری‌پذیری هر مورد **Potential Risk** است.

### ۴.۲ سه Helper بررسی تکراری با SQL پویا

| Helper | تعریف (خط شروع) |
|---|---|
| `ApispCheckDuplicateCompany` | `ideal-write-audit-next-definitions.txt:595` (بازاستخراج کامل: `ideal-write-audit-fourth-part-1.txt:1050`) |
| `MobspCheckDuplicateCompany` | `ideal-write-audit-next-definitions.txt:8708` (بازاستخراج: `ideal-write-audit-fourth-part-7.txt:4361`) |
| `MobspCheckDuplicateCompanyForSetReason` | `ideal-write-audit-next-definitions.txt:9070` (بازاستخراج: `ideal-write-audit-fourth-part-7.txt:4670`) |

این سه Helper نیز قطعه‌های متنی کوئری می‌سازند (متغیرهایی مانند `@fld`، `@from`، `@term`) — الگو **Confirmed Static Finding**؛ بهره‌برداری‌پذیری **Potential Risk** تا اثبات مسیر ورود.

### ۴.۳ روابط شناسه‌ها در `ApispInsertBuyOrder`

در `ApispInsertBuyOrder` (خط 977) وجودِ شرکت، شخص، پروژه و کاربر بررسی می‌شود؛ اما **وجودِ هر شناسه به‌تنهایی رابطهٔ معتبر بین آن‌ها را اثبات نمی‌کند** (مثلاً تعلق شخص/پروژه به همان شرکت) — **Potential Risk**.

### ۴.۴ سند، کالا و تأمین موجودی

- **`ApispInsertProducts`** (خط 2339) و **`ApispInsertProductPrice`** (خط 2141): عملیات کالا و قیمت‌گذاری دادهٔ حساس تجاری است و باید **مدیریتی** بماند — **Potential Risk** تا تکمیل کنترل‌ها.
- **`MobspInsertDocFull`** (خط 10199؛ بازاستخراج: `ideal-write-audit-fourth-part-7.txt:5151`): ورودی JSON دارد و کنترل‌های تجاری موجودی و سریال کالا را انجام می‌دهد (**Confirmed Static Finding** — وجود کنترل‌های تجاری)؛ اما **مجوز Action جایگزین مجوز مالکیت سند و انبار نیست** — **Potential Risk**.
- **`MobspUpdateDoc`** (خط 12446؛ بازاستخراج: `ideal-write-audit-fourth-part-11.txt:184`): نیازمند کنترل مستقل مالکیت سند و مجوز انبار — **Potential Risk**.
- **`WSspIssueStockSupplyFromPreOrder`** (خط 12868؛ بازاستخراج: `ideal-write-audit-fourth-part-12.txt:66`): باید از نظر مالکیت پیش‌سفارش، مجوز انبار، مقدار باقی‌مانده و اجرای تکراری (Idempotency) اصلاح شود — **Potential Risk**.

---
## ۵. یافته‌های سری سوم و چهارم — فیلترهای موقت `CrmsysDBTempInfo`

منابع: `ideal/ideal-write-audit-third-definitions.txt` + `ideal/ideal-write-audit-third-part-1..7.txt` (کامیت‌های `ff3b715`، `951089a`) و استخراج چهارم (`ideal/ideal-write-audit-fourth-definitions.txt` + `ideal/ideal-write-audit-fourth-part-1..13.txt`، کامیت‌های `2305ed7`، `0ed4469`، `4d44b6b`).

### ۵.۱ ساختار جدول و نبود ایندکس یکتا

خروجی فرادادهٔ استخراج چهارم (تکرارشده در ابتدای هر قطعه و در `ideal-write-audit-fourth-definitions.txt`) ساختار `dbo.CrmsysDBTempInfo` را نشان می‌دهد:

- ستون‌ها: `ID (bigint)`, `UserId (int)`, `GUId (uniqueidentifier)`, `TypeId (int)`, `TXT (nvarchar(max))`, `AppType (varchar(20))`, `LanguageID (int)`, `FirstRegisterUserId (int)`, `FirstRegisterDatePersian (varchar(8))`, `FirstRegisterDate (datetime)`, `TXTObjType (nvarchar(400))`, `TXTJsResult (nvarchar(max))`.
- ایندکس ثبت‌شده فقط `PK_CrmsysDBTempInfo` روی `ID` است — **هیچ Unique Index روی `(UserId, TypeId)` وجود ندارد** — **Confirmed Static Finding**.
- کوئری تریگرهای متصل به این جدول (بخش ۳ اسکریپت `ideal-write-audit-fourth-fixed.sql`) **هیچ تریگری برنگرداند** — **Confirmed Static Finding** (بدون تریگرِ پاک‌ساز/نظارتی).

خطرهای نتیجه‌شده (همه **Potential Risk** تا رخداد اثبات‌شده):

1. تداخل درخواست‌های هم‌زمان یک کاربر و یک نوع فیلتر (نبود کلید یکتا)؛
2. ایجاد رکورد تکراری برای همان `(UserId, TypeId)`؛
3. انتخاب غیرقطعی هنگام وجود چند رکورد (الگوی رایج خواندن `TOP 1`)؛
4. باقی‌ماندن فیلتر قدیمی و اعمال ناخواستهٔ آن به درخواست بعدی؛
5. خطر الحاق SQL پویا (متن فیلتر در `TXT` ساخته و مصرف می‌شود)؛
6. احتمال Truncation در متغیرهای `VARCHAR(4000)` سازندهٔ متن فیلتر — شواهد: `DECLARE @Term VARCHAR(4000)` در `CRMspSetcmpDataPermission` (`ideal-write-audit-third-definitions.txt:16310`) و `MobspSetcmpDataPermission` (`:34752`)؛ همچنین پارامتر `@prjTitleGroup NVARCHAR(4000)` در `CRMspRpt_CompanyFilterData` (`ideal-write-audit-fourth-part-4.txt:1646`). (ستون `TXT` خودش `nvarchar(max)` است؛ ریسک Truncation مربوط به متغیرهای میانی SPهاست.)

### ۵.۲ نقشهٔ TypeIdها و Producerهای آن‌ها

| TypeId | Producer (تعریف در مخزن) |
|---|---|
| 1 | `CRMspRpt_CompanyFilterData` — `ideal-write-audit-fourth-part-4.txt:1517` |
| 20 | `CRMspSetcmpDataPermission` — `ideal-write-audit-third-definitions.txt:16304` · `MobspSetcmpDataPermission` — `:34743` |
| 30 | `WSspSelectPreOrderIndicator` — `ideal-write-audit-fourth-part-13.txt:1512` |
| 40 | `WSspSelectOrderIndicator` — `ideal-write-audit-fourth-part-12.txt:3368` |
| 50 | `WSspSelectBuyOrderIndicator` — `ideal-write-audit-fourth-part-12.txt:683` |
| 60 | `WSspDocIndicator` — `ideal-write-audit-fourth-part-11.txt:4706` |
| 70 | `WSspCostSheetIndicator` — `ideal-write-audit-fourth-part-11.txt:4147` |
| 80 | `SecspLetterIndicator` — `ideal-write-audit-fourth-part-11.txt:928` |
| 90 | `WSspSelectStockSupplyIndicator` — `ideal-write-audit-fourth-part-13.txt:4229` |

### ۵.۳ یافته‌های به تفکیک TypeId

- **TypeId=30 (پیش‌سفارش):** حذف گروهی، تأیید گروهی و خروج از تأیید گروهی به فیلتر ذخیره‌شده متکی‌اند و کنترل مستقل مالکیت در بدنه‌های بررسی‌شده کافی نیست — **Confirmed Static Finding** (اتکا به فیلتر) + **Potential Risk** (نبود کنترل مستقل). جزئیات در بخش ۶.
- **TypeId=40 (سفارش):** فیلتر سفارش در بعضی مصرف‌کنندگان بدون کنترل مستقل مالکیت دوباره استفاده می‌شود — **Potential Risk**.
- **TypeId=50 (خرید):** فیلتر خرید نیز در مسیر مصرف نیازمند کنترل مستقل والد است — **Potential Risk**.
- **TypeId=60 (سند):** Producer پارامترهای `@WHId`/`@WHIdI` (WareHouseId) دارد (`ideal-write-audit-fourth-part-11.txt` — بلوک شروع خط 4706)؛ تعیین WarehouseId مشخص در Producer می‌تواند مسیر بررسی مجوز انبار را دور بزند — **Potential Risk**.
- **TypeId=70 (برگهٔ هزینه):** مجوز مالکیت و محدودهٔ پروژه در تعریف بررسی‌شده روشن نیست؛ **فعلاً مدیریتی** — **Potential Risk** (تا تکمیل بررسی مجوزها).
- **TypeId=80 (نامه):** مصرف‌کنندگان نامه، کنترل مالکیت و شرکت را مجدداً اعمال می‌کنند — **نمونهٔ مثبت** (**Confirmed Static Finding** — الگوی کنترل دوباره در مصرف‌کننده).
- **TypeId=90 (تأمین موجودی):** کنترل مستقل مجوز انبار در Producer و Consumer اثبات نشده است؛ **فعلاً مدیریتی** — **Potential Risk**.

### ۵.۴ Helperهای مجوز

- **`MobspCheckCmpDataPermissionForUser`** (تعریف‌ها: `ideal-write-audit-next-definitions.txt:8157`، `ideal-write-audit-third-definitions.txt:18887`، `ideal-write-audit-fourth-part-7.txt:4093`): خروجی `@IsAccess` **در ابتدای بدنه مقداردهی نمی‌شود** — تنها انتساب‌های مشاهده‌شده `SET @IsAccess = 1` هستند (۹ مورد در بدنه) و مسیر «رد» مقدار قبلی متغیر را دست‌نخورده می‌گذارد؛ اگر Caller خروجی را پیش‌فرض صفر نکرده باشد، مقدار کهنه/حتی ۱ باقی می‌ماند — **Confirmed Static Finding**. بیشتر Callerهای شناسایی‌شده مقدار خروجی را پیش از فراخوانی صفر می‌کنند (**Controller Mitigation Observed** در سطح Caller)، اما **خود Helper باید اصلاح شود**: `SET @IsAccess = 0` در ابتدای بدنه و مقدار ۱ فقط پس از اثبات مجوز؛ همهٔ Callerها نیز باید بازبینی شوند (بخش ۱۵ P0).
- **`MobspCheckActionForUser`** (تعریف: `ideal-write-audit-third-definitions.txt:18844`؛ بازاستخراج: `ideal-write-audit-fourth-part-7.txt:4050`): مجوز Action/Form را بررسی می‌کند و **به‌تنهایی مجوز مالکیت ردیف یا انبار نیست** — **Confirmed Static Finding** (محدودهٔ کارکرد Helper).
- **`MobspCheckCompanyDataPermissionForUser`:** در فهرست اهداف دقیق اسکریپت استخراج چهارم (`ideal-write-audit-fourth-fixed.sql:15`) قرار داشت اما در خروجی استخراج **پیدا نشد** — این یعنی این شیء با این نام دقیق در دیتابیسِ استخراج‌شده ظاهر نشده است؛ موجودیت/نام دقیق آن **نیازمند تأیید** است (پیوست ب، مورد ۲) — **Runtime Verification Pending**.

### ۵.۵ نتیجهٔ معماری برای فیلترهای موقت

اتکا به `CrmsysDBTempInfo` به‌عنوان «وضعیت فیلتر امنیتی درخواست» برای API جدید **پذیرفته نیست**؛ فیلترها باید در لایهٔ API با پارامترهای مستقل و `sp_executesql` پیاده شوند (بخش ۱۴ اصول ۳ و ۷؛ بخش ۱۵ P1).

---

## ۶. عملیات گروهی پیش‌سفارش (TypeId=30)

سه پروسیجر:

| پروسیجر | تعریف (نمونه مسیرها) |
|---|---|
| `WSspDeletePreOrderFromPreOrderIndicator` | `ideal-write-audit-third-definitions.txt:45096` · `third-part-5.txt:8023` · `ideal-write-audit-fourth-part-11.txt:4565` |
| `WSspPreOrderGroupVerify` | `ideal-write-audit-third-definitions.txt:66952` · `ideal-write-audit-fourth-part-12.txt:587` |
| `WSspPreOrderGroupVerifyExit` | `ideal-write-audit-third-definitions.txt:66992` · `ideal-write-audit-fourth-part-12.txt:627` |

یافته‌ها (همه در بدنه‌های بررسی‌شده):

- استفاده از فیلتر ذخیره‌شدهٔ TypeId=30 (خواندن از `CrmsysDBTempInfo`) — **Confirmed Static Finding**؛
- SQL پویا با الحاق متن فیلتر — **Confirmed Static Finding** (الگوی الحاق)؛
- **کنترل مستقل مالکیت/مجوز ردیفی در بدنه‌ها مشاهده نشد** — **Potential Risk**؛
- حذف گروهی شامل **۱۸ عملیات DELETE وابسته** است (شمارش عبارات `DELETE FROM …` در بلوک) — **Confirmed Static Finding**؛
- **تراکنش یکپارچه و TRY/CATCH صریح در بدنهٔ حذف بررسی‌شده مشاهده نشد** (نبود `BEGIN TRAN`/`BEGIN TRY` در تعریف) — **Confirmed Static Finding** (نبود الگو در تعریف) + پیامد آن **Potential Risk**؛
- تأیید و خروج از تأیید نیز نیازمند تراکنش و کنترل مجوز هستند — **Potential Risk**.

**نتیجه:** این سه عملیات **از API عمومی خارج بمانند** تا به‌طور کامل بازطراحی شوند (فیلتر پارامتری + کنترل مالکیت ردیف‌به‌ردیف + تراکنش + TRY/CATCH + Idempotency).

---

## ۷. تبدیل سفارش خرید به سفارش فروش

**`WSspIssueOrderFromBuyOrder`** — تعریف‌ها: `ideal-write-audit-third-definitions.txt:59002` · `third-part-7.txt:2699` · `ideal-write-audit-fourth-part-11.txt:5610` (بزرگ‌ترین ماژول این خانواده: ۴۱٬۴۲۵ کاراکتر تعریف).

- ورودی شامل `BuyOrderId`، `CompanyId`، `ProjectId`، `WarehouseId`، `UserId` و اقلام است.
- **کنترل مالکیت سفارش خرید، شرکت، پروژه، انبار و کاربر در بدنهٔ بررسی‌شده کافی/مشهود نیست** — **Potential Risk**؛ ارتباط چند شناسهٔ مستقل ورودی با هم اعتبارسنجی آشکار ندارد.
- **ارتباط اقلام ورودی با سفارش خرید** باید بررسی شود (تعلق Item به همان BuyOrderId) — **Potential Risk**.
- جلوگیری از تبدیل تکراری به Helper وابسته است — **Potential Risk** (شرط رقابتی/Idempotency).
- تراکنش‌های تو در تو، الگوی `@@ERROR` و SQL پویا در بدنه نیازمند اصلاح‌اند — **Confirmed Static Finding** (الگوها) / **Potential Risk** (پیامد).

**نتیجه:** **مدیرمحور و تا تکمیل کنترل‌ها مسدود.**

---

## ۸. اسناد و انبار — موارد تکمیلی

| پروسیجر | تعریف (خط شروع) | یافته | وضعیت |
|---|---|---|---|
| `MobspDeleteWSDoc` | `ideal-write-audit-third-definitions.txt:23056` · `third-part-3.txt:4968` | حذف سند با `DocID`؛ کنترل مالکیت و مجوز کاربر/انبار در بدنهٔ بررسی‌شده مشاهده نشد | **Potential Risk** |
| `WSspDeleteStockSupplyWithDependencies` | `ideal-write-audit-third-definitions.txt:46719` · `third-part-6.txt:196` | وابستگی خرید کنترل می‌شود؛ مجوز مالکیت/انبار نیازمند بررسی و اصلاح | **Potential Risk** |
| `WSspIssueBuyOrderFromStockSupply` | `ideal-write-audit-third-definitions.txt:50050` · `third-part-6.txt:3527` | ارتباط شرکت، شخص، پروژه و اقلام با تأمین باید اعتبارسنجی شود؛ race condition در ایجاد خرید هم‌زمان بررسی شود | **Potential Risk** |
| `MobspInsertDocFull` | `ideal-write-audit-next-definitions.txt:10199` · `ideal-write-audit-fourth-part-7.txt:5151` | کنترل Action کافی نیست؛ مجوز ردیفی و انبار باید مستقل باشد | **Potential Risk** |
| `MobspUpdateDoc` | `ideal-write-audit-next-definitions.txt:12446` · `ideal-write-audit-fourth-part-11.txt:184` | همان الزام مالکیت سند/انبار | **Potential Risk** |

**نتیجه:** صدور، اصلاح، حذف سند و تأمین موجودی **تا اصلاح مجوزها، مدیریتی/مسدود**.

---

## ۹. عملیات حساس CRM (حذف/تأیید/ابطال)

موارد بررسی‌شده (تعریف در `ideal/ideal-write-audit-third-definitions.txt` و قطعات سوم):

| پروسیجر | خط شروع (third-definitions) |
|---|---|
| `ApispDeleteCompany` | 4208 |
| `ApispDeleteCompanyPerson` | 4587 |
| `ApispDeleteProject` | 5436 |
| `ApispDeleteLinkedCompany` | 4946 |
| `ApispDeleteAllLinkedCompany` | 4030 |
| `MobspDeleteCrmProject` | 22385 |
| `MobspDeleteCrmConversation` | 22208 |
| `MobspOrderVerify` | 32724 |
| `MobspPreOrderVerify` | 32944 |
| `MobspLeaveVerify` | 32540 |
| `MobspLeaveCancel` | 32430 |

یافته‌ها:

- در برخی از این پروسیجرها تراکنش وجود دارد (**Confirmed Static Finding** — وجود تراکنش در بدنه)، اما **کنترل مالکیت رکورد و شرکت والد در خود SPها کافی نیست** — **Potential Risk**.
- نمونهٔ مشخص: بدنهٔ `MobspPreOrderVerify` به `UPDATE dbo.WSPreOrder … WHERE PreOrderID = @PreOrderId` خلاصه می‌شود بدون شرط مالکیت شرکت در همان UPDATE — **Confirmed Static Finding** (نبود شرط مالکیت در UPDATE بررسی‌شده).
- **کنترل‌های Controller فعلی باید جداگانه بررسی شوند؛ امنیت مسیر Controller را نباید به امنیت مستقل SP تعمیم داد** — بخش‌های ۱۱ و ۱۲ و اصل ۶/۰.

---
## ۱۰. یافته‌های BOLA/IDOR در روابط CRM

دو یافتهٔ مشخص در بازبینی ایستای کد. **هیچ Exploit Runtime انجام نشده است** — وضعیت هر دو: **Confirmed Static Finding** (از نظر الگوی کد) و از نظر بهره‌برداری‌پذیری عملی: **Potential Risk** تا اثبات مسیر فراخوانی با ورودی مهاجم.

### ۱۰.۱ `MobspUpdateCompanyPerson`

تعریف: `ideal/ideal-write-audit-fourth-part-10.txt:4098` (بلوک ~۱۰۰۷ خطی).

زنجیرهٔ مشاهده‌شده در بدنه:

1. کنترل دسترسی به شرکتِ **ورودی**: `EXEC dbo.MobspCheckCmpDataPermissionForUser @Mode = 8, @Id = @CompanyId, @CrmUserId = @UserId, @IsAccess = @IsAccessCompanyId OUTPUT` (حدود خط 4611-4619) — دسترسی به `@CompanyId` بررسی می‌شود.
2. کنترل وجود شخص: `SET @FindRecord = (SELECT TOP 1 P.CompanyPersonID FROM dbo.CrmCompanyPersons P WHERE P.CompanyPersonID = @PersonId)` (حدود خط 4208) — فقط وجود، بدون شرط شرکت.
3. `UPDATE [dbo].[CrmCompanyPersons] … WHERE CompanyPersonID = @PersonId` (حدود خط 4970/5023) و `UPDATE [dbo].[CrmCompanyPersons_Lang] … WHERE [CompanyPersonID] = @PersonId` (حدود خط 5025).
4. **تطبیق `prsCompanyId` شخص با `@CompanyId` در بدنهٔ بررسی‌شده مشاهده نشد** — تنها کاربردهای `prsCompanyId` در این بلوک، رشته‌های پیام خطا هستند (حدود خطوط 4672-4707).

**ریسک:** دسترسی به شرکت A ممکن است برای اصلاح شخص متعلق به شرکت B کافی باشد، اگر شناسهٔ شخص دیگر ارائه شود (آپدیت صرفاً بر اساس `CompanyPersonID` انجام می‌شود).

**اصلاح:** `CompanyId` واقعی باید از خود رکورد Person (`SELECT prsCompanyId FROM CrmCompanyPersons WHERE CompanyPersonID = @PersonId`) استخراج و مجوز همان والد بررسی شود؛ UPDATE نیز باید با شرط تعلق والد مقید گردد.

### ۱۰.۲ `MobspUpdateCompanyProject`

تعریف: `ideal/ideal-write-audit-fourth-part-10.txt:5358` (بلوک ~۹۴۰ خطی).

زنجیرهٔ مشاهده‌شده:

1. کنترل دسترسی به شرکتِ ورودی با همان Helper (حدود خط 6047-6055).
2. کنترل وجود پروژه: `SET @FindRecord = (SELECT TOP 1 P.ProjectID FROM dbo.CrmProjects P WHERE P.ProjectID = @ProjectId)` (حدود خط 5478).
3. `UPDATE [dbo].[CrmProjects] … WHERE ProjectID = @ProjectId` (حدود خط 6132/6201) و `UPDATE [dbo].[CrmProjects_Lang]` (حدود خط 6203).
4. **تطبیق `prjCompanyId` پروژه با `CompanyId` ورودی در مسیر بررسی‌شده مشاهده نشد** (تنها کاربرد `@CompanyId` در بلوک، پارامتر ورودی و Helper مجوز است).

**اصلاح:** شرکت والد از رکورد پروژه استخراج شود و مجوز همان شرکت بررسی گردد؛ آپدیت با شرط تعلق والد مقید شود.

---

## ۱۱. ممیزی Controllerهای مکالمه و پروژه

منبع Controllerها: سورس دیکامپایل‌شده در `project-analysis/decompiled/Mobile/Mobile/Controllers/` (و `CRMIdealApi/`).

- **`MobspUpdateConversation`** (تعریف SP: `ideal-write-audit-fourth-part-10.txt:6322`): مجوز شرکت و پروژه بررسی می‌شود (`MobspCheckCmpDataPermissionForUser` در حدود خط 6768) و سپس `EXEC [MobspSingleCrmConversationPreChecks]` فراخوانی می‌شود (حدود خط 6839)؛ **تعریف کامل این Helper در مجموعهٔ فایل‌های استخراج فعلی موجود نیست** — **SQL Definition Pending** (فهرست پیوست ب، مورد ۳).
- **`MobspDeleteCrmConversation`** (تعریف SP: `ideal-write-audit-third-definitions.txt:22208`): Controller ابتدا مکالمه را می‌خواند و شرکت/پروژهٔ واقعی و کاربران مرتبط را بررسی می‌کند — **Controller Mitigation Observed**؛ اما SP به‌تنهایی این تضمین را ندارد — **Potential Risk** در سطح SP.
- **`MobspDeleteCrmProject`** (تعریف SP: `ideal-write-audit-third-definitions.txt:22385`): Controller شرکت واقعی پروژه را بررسی می‌کند — **Controller Mitigation Observed**؛ اما ارسال `cmpId` ورودی به SP باید اصلاح شود تا مبنای تصمیم، شرکتِ واقعیِ استخراج‌شده از رکورد پروژه باشد — **Potential Risk** (تا اصلاح).
- **`MobspInsertQuickCmpPrsPrjCnvs`** (تعریف: `ideal-write-audit-fourth-part-7.txt:6245`): کنترل‌های متعددی برای ایجاد شرکت/شخص/پروژه وجود دارد (**Confirmed Static Finding** — وجود کنترل‌ها)، اما رابطهٔ تمام رکوردهای ورودی نیازمند ممیزی کامل است — **Potential Risk**.

---

## ۱۲. ممیزی Controllerهای سفارش و پیش‌سفارش

Controllerهای بررسی‌شده (سورس دیکامپایل‌شده): `OrderController.cs`، `PreOrderController.cs`، `UpdateController.cs` (در `project-analysis/decompiled/Mobile/Mobile/Controllers/`).

- **تأیید سفارش:** Token و مجوز `actVerifyOrder` بررسی می‌شود (`OrderController.cs:238` — `UserLogin.IsUserAccess("frmOrder", "actVerifyOrder", UserLogin.CurrentUser, cId)`)؛ کاربر و نقش از Token می‌آیند؛ سپس `MobspOrderVerifyWithPreChecks(ordId, token2.RollId, token2.userId, …)` فراخوانی می‌شود. **تطبیق شرکت واقعی سفارش با `cId` پیش از اجرای SP در کد بررسی‌شده مشاهده نشد** — **Potential Risk**.
- **تأیید پیش‌سفارش:** Token و مجوز `actVerifyPreOrder` بررسی می‌شود (`PreOrderController.cs:288`؛ فراخوانی SP در `:362`)؛ کنترل مالکیت رکورد در Controller اثبات نشد — **Potential Risk**.
- **اصلاح سفارش/پیش‌سفارش:** `UserId` از Token می‌آید، اما شناسهٔ رکورد و `CenterId` از مدل درخواست می‌آیند (نمونه فراخوانی‌ها در `UpdateController.cs`: `MobspUpdatePreOrder` خط 1194، `MobspUpdatePreOrderItem` خط 1313، `MobspUpdateOrder` خط 1541، `MobspUpdateOrderItem` خط 1675) — **Potential Risk** (اعتماد به شناسه‌های بدنهٔ درخواست).
- **اصلاح اقلام:** کنترل‌های محدودیت موجودی در Controller وجود دارند (**Controller Mitigation Observed**)، اما این کنترل‌ها **جایگزین بررسی تعلق Item به Parent و کنترل موجودی اتمیک در SQL نیستند** — **Potential Risk**.
- در مسیرهای بررسی‌شده، **کنترل صریح مجوز ویرایش در Controller پیش از فراخوانی SP مشاهده نشد** — **Potential Risk**.
- **عملیات پس از تأیید** شامل ارجاع انبار، امتیاز، تاریخچه، پیامک و اعلان است؛ باید Workflow و Idempotency داشته باشد — **Potential Risk** (تا طراحی).

---

## ۱۳. پروسیجرهای SQL مسیر تأیید/اصلاح سفارش و پیش‌سفارش

این شش پروسیجر در مسیرهای تأیید/اصلاح سفارش و پیش‌سفارشِ API موبایل فراخوانی می‌شوند (شواهد فراخوانی در بخش ۱۲).

### ۱۳.۱ وضعیت تعاریف — به‌روزِ ثبت نقطهٔ کنترل (۲۰۲۶-۱۱-۱۹)

در میانهٔ تدوین این نقطهٔ کنترل، مالک استخراج فقط-خواندنی جدید را push کرد (`e6968a0` — فایل‌های ردیف ۱۱ تا ۱۳ بخش ۲). وضعیت نهایی:

| پروسیجر | تعریف | وضعیت ثبت |
|---|---|---|
| `MobspOrderVerifyWithPreChecks` | `ideal/order-preorder-procedure-parameters.txt` (رکورد ۱) + نسخهٔ هم‌ارز در `ideal-write-audit-third-definitions.txt:32809` | **تعریف موجود و راستی‌آزمایی‌شده** (دو نسخه پس از نرمال‌سازی فاصله‌ها یکسان‌اند) — ممیزی ایستا در §۱۳.۲ |
| `MobspPreOrderVerifyWithPreChecks` | `ideal/order-preorder-procedure-parameters.txt` (رکورد ۲) + `ideal-write-audit-third-definitions.txt:33030` | **تعریف موجود و راستی‌آزمایی‌شده** — §۱۳.۲ |
| `MobspUpdateOrder` | `ideal/order-preorder-procedure-parameters.txt` (رکورد ۳) + `ideal/order-preorder-procedure-definitions.txt` | **تعریف موجود (استخراج مالک)** — ممیزی اولیه در §۱۳.۳ |
| `MobspUpdatePreOrder` | `ideal/order-preorder-procedure-parameters.txt` (رکورد ۴) | **تعریف موجود (استخراج مالک)** — §۱۳.۳ |
| `MobspUpdateOrderItem` | **خیر** — فراخوانی از `UpdateController.cs:1675` | **SQL Definition Pending** |
| `MobspUpdatePreOrderItem` | **خیر** — فراخوانی از `UpdateController.cs:1313` (تنها اشارهٔ متنی موجود، فراخوانی پروسیجر متفاوتِ `MobspUpdatePreOrderItemCurrencyUnitId` است) | **SQL Definition Pending** |

امضای پارامترهای چهار پروسیجرِ دارای تعریف، در `ideal/order-preorder-procedure-parameters - Copy.txt` ثبت شده است (مثلاً `MobspOrderVerifyWithPreChecks(@OrderId, @RollId, @VerifierUserId, @RegisterDatePersian, @RegisterDate, @LimitOrderDiscountPercent OUTPUT, @Result OUTPUT)`).

### ۱۳.۲ ممیزی ایستای دو پروسیجر تأیید (تعاریف تأییدشده)

`MobspOrderVerifyWithPreChecks` و `MobspPreOrderVerifyWithPreChecks`:

- به‌روزرسانی وضعیت رکورد با `UPDATE … WHERE OrderID = @OrderId` / `WHERE PreOrderID = @PreOrderId` — **بدون شرط مالکیت شرکت در همان UPDATE** — **Confirmed Static Finding**؛
- **هیچ فراخوانی Helper مجوز** (`MobspCheckCmpDataPermissionForUser`/`MobspCheckActionForUser`) در بدنه وجود ندارد — **Confirmed Static Finding** (نبودِ فراخوانی)؛
- **تراکنش و TRY/CATCH در بدنه وجود ندارد** — **Confirmed Static Finding**؛
- پیامد امنیتی: کنترل مالکیت (در صورت وجود) باید کاملاً در لایهٔ Controller تأمین شده باشد؛ مطابق بخش ۱۲ در مسیر بررسی‌شدهٔ `OrderController`/`PreOrderController` تطبیق شرکت واقعی رکورد با `cId` پیش از فراخوانی SP مشاهده نشد — **Potential Risk** (تا اثبات مسیر جبرانی دیگر).

### ۱۳.۳ ممیزی اولیهٔ دو پروسیجر اصلاح (تعاریف جدید مالک)

`MobspUpdateOrder` و `MobspUpdatePreOrder` (تعاریف ~۳۲ و ~۳۹ هزار کاراکتری):

- هر دو از **قالب delimiter-based `|#|` و `=`** برای پارامتر رشته‌ای اصلی استفاده می‌کنند (همان الگوی `MobspInsertPreOrderFull` در بخش ۳.۳) — **Confirmed Static Finding**؛
- دستور اصلی: `UPDATE [dbo].[WSOrder] SET … ,[ordCompanyId] = @ordCompanyId … WHERE [OrderID] = @OrderId` و `UPDATE [dbo].[WSPreOrder] … WHERE PreOrderID = @PreOrderId` — **آپدیت فقط با شناسهٔ رکورد و بدون شرط مالکیت شرکت در WHERE**؛ شرکتِ جدیدِ رکورد نیز از ورودی می‌آید — **Confirmed Static Finding** (الگو) + **Potential Risk** (مالکیت)؛
- `BEGIN TRANSACTION` و `ROLLBACK` وجود دارد (**Confirmed Static Finding**) اما **TRY/CATCH مشاهده نشد** — **Confirmed Static Finding** (نبود TRY/CATCH در تعریف)؛
- الگوی `@@ERROR` پس از `SET` (بخش ۳.۴) در هر دو حضور دارد — **Confirmed Static Finding**؛
- **هیچ فراخوانی Helper مجوز در بدنه‌ها مشاهده نشد** — **Confirmed Static Finding** (نبودِ فراخوانی)؛
- نتیجهٔ اولیه: این دو مسیر نیز مشمول الگوی اصلاحی بخش ۱۰ (استخراج والد واقعی از رکورد + authorize مستقل) و اصول بخش ۱۴ هستند؛ ممیزی کامل جزئیات تجاری آن‌ها (اقلام، پرداخت‌ها، رویدادهای پس از اصلاح) همچنان باز است — **Potential Risk**.

### ۱۳.۴ موارد هنوز در انتظار

- **`MobspUpdateOrderItem` و `MobspUpdatePreOrderItem`:** تعریف و امضای پارامترها هنوز استخراج نشده؛ تا رسیدن تعریف، **هیچ نتیجهٔ قطعی** دربارهٔ کنترل SQL مالکیت این دو ثبت نشود، وضعیت `SQL Definition Pending` بماند و **هیچ‌کدام اجرا نشود**.
- ممیزی عمیق تجاری دو پروسیجر §۱۳.۳ (پردازش اقلام/پرداخت‌ها در رشتهٔ `|#|`، رویدادهای جانبی، شرط‌های تکراری) و بازبینی کامل Callerهای هر شش پروسیجر (بند ۳ بخش ۱۶).

---

## ۱۴. سیاست معماری و امنیت API

### ۱۴.۱ معماری هدف

```
MedPad Backend API
├── Authentication
├── Authorization
├── Ideal Adapter
├── Holoo Adapter
├── Audit
├── Idempotency
└── Sync
```

**Ideal و Holoo دو منبع مستقل داده‌اند.** شناسه‌ها باید با `sourceSystem` (مثلاً `"ideal"` / `"holoo"`) و `sourceId` تفکیک شوند؛ هر منبع Namespace و Source ID مستقل خود را حفظ می‌کند و ادغام داده در لایهٔ MedPad انجام می‌شود، نه با بازنویسی شناسه‌های منبع.

### ۱۴.۲ اصول اجباری

1. **UserId و شناسهٔ مالکیت از identity احراز‌شدهٔ سرور** استخراج شوند، نه از ورودی کلاینت.
2. برای دسترسی به child record ابتدا **parent واقعی خوانده و authorize** شود.
3. شناسهٔ شرکت/پروژه/انبار/مرکز از **رکورد واقعی یا Context معتبر** استخراج شود.
4. **DTOها حداقلی** باشند؛ credential و PII غیرضروری افشا نشود (نمونهٔ خطر در سمت خواندنی: `ApispSelectCompany` ستون‌های `cmpUserName`/`cmpPassword` را برمی‌گرداند — `ideal/procedure-definitions/dbo.ApispSelectCompany.sql:101-102`؛ ممیزی کامل PII: `IDEAL_PII_AUDIT.md`).
5. **Write API باید Audit و Idempotency** داشته باشد.
6. **تراکنش‌ها روشن و قابل اطمینان** باشند؛ `TRY/CATCH`، `XACT_ABORT`، `XACT_STATE` بررسی و به‌کار گرفته شوند.
7. **SQL پویا با `sp_executesql` و پارامترها** جایگزین شود؛ شناسهٔ ستون‌ها **Whitelist** شود.
8. عملیات **قیمت‌گذاری، خرید، صدور سند و تأمین موجودی فعلاً مدیریتی** بمانند.
9. **API خواندنی می‌تواند مستقل از ممیزی Write ادامه یابد** (سیاست موجود Allowlist: `IDEAL_SECURITY_ALLOWLIST.md`).
10. **هیچ Stored Procedure نوشتنی تا تکمیل ممیزی و اصلاح امنیتی اجرا نشود.**

---

## ۱۵. اولویت اصلاحات

### P0 — پیش از هرگونه فعال‌سازی Write

- مالکیت شرکت، سفارش، پیش‌سفارش و انبار (کنترل مستقل در سطح SP/لایهٔ API)؛
- کنترل Parent قبل از دسترسی به Items/Payments؛
- استخراج `UserId` و `WarehouseId` از هویت سرور؛
- اصلاح BOLA/IDOR در `MobspUpdateCompanyPerson` و `MobspUpdateCompanyProject` (بخش ۱۰)؛
- اصلاح مقداردهی اولیهٔ `@IsAccess` در `MobspCheckCmpDataPermissionForUser` (بخش ۵.۴).

### P1

- پارامتری کردن SQL پویا (`sp_executesql` + پارامتر + Whitelist ستون/نام)؛
- اصلاح تراکنش و مدیریت خطا (`TRY/CATCH`، `XACT_ABORT`، حذف الگوی `@@ERROR` پس از `SET`)؛
- حذف اتکا به `CrmsysDBTempInfo` برای وضعیت فیلتر امنیتی درخواست.

### P2

- Idempotency و Audit برای همهٔ عملیات نوشتنی؛
- Paging و محدودیت پنجرهٔ زمانی؛
- کنترل هم‌زمانی عملیات تجاری (قفل/شرط رقابتی برای صدور و تبدیل).

### P3

- بررسی FKهای Untrusted؛
- Query Store و Execution Plan؛
- تعیین منبع قابل‌اعتماد Sync Incremental (کاوش موجودی: `IDEAL_SYNC_CAPABILITY_AUDIT.md`).

---

## ۱۶. کارهای بعدی

1. **استخراج فقط-خواندنی دو SP باقی‌مانده** (`MobspUpdateOrderItem`، `MobspUpdatePreOrderItem` — تعریف کامل + امضای پارامترها) از دیتابیس واقعی؛ چهار مورد دیگرِ این فهرست با کامیت `e6968a0` مالک تحویل و در بخش ۱۳ لحاظ شد.
2. **تکمیل ممیزی SQL مالکیت و روابط سفارش/پیش‌سفارش.**
3. **بررسی Callerهای عملیات تأیید و اصلاح** (نقشهٔ کامل فراخوانی `Mobsp*Verify*` و `MobspUpdate*`).
4. **بررسی Workflow پس از تأیید و Idempotency.**
5. **تکمیل ماتریس دسترسی نقش‌ها.**
6. **بازبینی تفاوت مستند Endpointها، Allowlist و کد فعلی IdealBridge** تا مستندات با رفتار واقعی سرویس یکسان شوند (`03-endpoints.md` ↔ `IDEAL_SECURITY_ALLOWLIST.md` ↔ سورس `IdealBridge.Api`).

---

## پیوست الف — ارجاع به اسناد موجود و مرز اطلاعات تکراری

| سند | نقش | مرز نسبت به این سند |
|---|---|---|
| `01-ideal-api-reverse-engineering.md` | مهندسی معکوس API قدیمی Ideal (فاز ۱-۲) | زمینهٔ کلی؛ ممیزی Write اینجا ثبت می‌شود |
| `IDEAL_API_MAPPING.md` | نگاشت فیلد-به-فیلد (خواندنی) | فقط خواندنی |
| `IDEAL_SECURITY_ALLOWLIST.md` | سیاست فقط-SELECT و فهرست جداول مجاز | مکمل: Write خارج از Allowlist است تا اصلاح‌ها انجام شود |
| `IDEAL_LIVE_SCHEMA_AUDIT.md` | ممیزی اسکیمای زنده (فاز ۱۲.۵) | منبع فرادیدهٔ ساختاری؛ وضعیت تریگرها «تا اجرای مجدد نامشخص» |
| `IDEAL_PII_AUDIT.md` | ممیزی افشای PII | مبنای اصل ۱۴.۴ |
| `IDEAL_SYNC_CAPABILITY_AUDIT.md` | قابلیت‌های همگام‌سازی | مبنای P3 (منبع Incremental) |
| `03-endpoints.md` / `11-swagger.md` | مستند Endpointهای IdealBridge | موضوع بند ۶ بخش ۱۶ |
| `10-sync-design.md` | طراحی همگام‌سازی MedPad | مبنای معماری Sync |
| `ideal/procedure-definitions/` (۱۸ SP + manifest) | تعاریف راستی‌آزمایی‌شدهٔ خواندنی | ممیزی آن‌ها در اسناد خواندنی؛ اینجا فقط مرجع |

در صورت تداخل آتی، **این سند مرجع اصلی ممیزی Write** است؛ سندهای دیگر برای حوزهٔ خود معتبرند و تعارض‌ها باید در پیوست ب ثبت شوند، نه حذف خاموش.

## پیوست ب — ثبت تعارض‌ها و موارد نیازمند تأیید

1. **شش SP بخش ۱۳ — تعارض ثبت‌شده و «حل‌شده با شواهد جدید»:** در متن مأموریت این نقطهٔ کنترل ادعا شده بود تعریف کامل هر شش پروسیجر «در مجموعهٔ فایل‌های SQL فعلی مخزن پیدا نشد». راستی‌آزمایی همین تاریخ نشان داد **دو مورد** (`MobspOrderVerifyWithPreChecks` و `MobspPreOrderVerifyWithPreChecks`) از قبل در `ideal/ideal-write-audit-third-definitions.txt` (خطوط 32809 و 33030) تعریف داشتند و **چهار مورد** فاقد تعریف بودند. سپس مالک کامیت `e6968a0` را push کرد که تعریف همان چهار موردِ غایب را داد؛ مقایسهٔ دو نسخه از پروسیجرهای تأیید نشان داد **کاملاً یکسان‌اند** (پس از نرمال‌سازی فاصله‌ها). جمع‌بندی: ادعای «نبودِ تعریف» برای دو پروسیجر تأیید، نادرست از ابتدا بود (تعریف در استخراج سوم موجود بود) و برای چهار مورد دیگر تا `e6968a0` درست بود. **هر دو روایت در این پیوست حفظ شد** و نتیجه در بخش ۱۳ با وضعیت‌های به‌روز ثبت شد. دو پروسیجر `MobspUpdateOrderItem` و `MobspUpdatePreOrderItem` همچنان `SQL Definition Pending` هستند.
2. **`MobspCheckCompanyDataPermissionForUser`:** در اهداف دقیق `ideal-write-audit-fourth-fixed.sql` بود اما در خروجی استخراج نیامد — موجودیت این شیء با این نام دقیق **نیازمند تأیید** است (احتمال نام دقیق متفاوت برای Helper مشابه؛ Helper مشاهده‌شده در بدنه‌ها `MobspCheckCmpDataPermissionForUser` است).
3. **`MobspSingleCrmConversationPreChecks`:** توسط `MobspUpdateConversation` فراخوانی می‌شود (`ideal-write-audit-fourth-part-10.txt` حدود خط 6839) اما تعریف آن در هیچ فایل استخراج فعلی نیست — **SQL Definition Pending**.
4. **شمارش استخراج دوم:** فایل `ideal-write-audit-next-definitions.txt` دارای **۳۶** سربرگ ماژول است؛ اگر در یادداشت‌های قبلی عدد دیگری (مثلاً ۳۷) ثبت شده باشد، مبنای معتبر همین شمارش مستقیم فایل است.
5. **`ideal-live-schema-report.json`:** در مخزن نیست (محیط مالک). داده‌های ساختاری نقل‌شده در این سند از خروجی فرادادهٔ استخراج‌های چهارم (که در مخزن هستند) گرفته شده‌اند؛ هر نقل دیگری از گزارش زنده باید صراحتاً برچسب منبع بخورد.
6. **مستندات کنارگذاشته‌شدهٔ نشده:** در شاخهٔ `ideal` هیچ سند دیگری با عنوان «ممیزی Write» وجود ندارد (`IDEAL_WRITE_API_SECURITY_AUDIT.md` در زمان ثبت این نقطهٔ کنترل ایجاد شد)؛ سند سراسری‌تر دیگری اگر در آینده به مخزن اضافه شود، باید به این سند به‌عنوان مرجع Write ارجاع دهد.

## پیوست ج — تاریخچهٔ Git استخراج‌های این ممیزی

| کامیت | تاریخ (UTC) | شرح |
|---|---|---|
| `ad0248d` | 2026-11-18 11:57 | `procedure-definitions.zip` |
| `ab9ff34` | 2026-11-18 12:16 | پوشهٔ `procedure-definitions/` (۱۸ SP + manifest) |
| `6bfb8c2` | 2026-11-18 12:19 | جابه‌جایی `procedure-definitions/` به ریشهٔ `ideal/` |
| `03946bd` | 2026-11-18 13:05 | `ideal-write-audit.sql` (اسکریپت استخراج اول) |
| `8e19528` | 2026-11-18 13:08 | `ideal-write-audit-definitions.txt` (۱۹ ماژول) |
| `feeb770` | 2026-11-19 00:43 | `ideal-write-audit-next-definitions.txt` (۳۶ ماژول) |
| `57400bc` | 2026-11-19 00:59 | `ideal-write-audit-third.sql` |
| `ff3b715` | 2026-11-19 01:01 | `ideal-write-audit-third-definitions.txt` (۴۰۶ ماژول) |
| `951089a` | 2026-11-19 01:09 | `ideal-write-audit-third-part-1..7.txt` (۳۶۱ ماژول) |
| `2305ed7` | 2026-11-19 01:40 | `ideal-write-audit-fourth-definitions.txt` + فایل HTM کناری |
| `0ed4469` | 2026-11-19 01:58 | `ideal-write-audit-fourth-fixed.sql` |
| `4d44b6b` | 2026-11-19 02:02 | `ideal-write-audit-fourth-part-1..13.txt` (۱۳۵ ماژول یکتا) |
| `e6968a0` | 2026-11-19 13:37 (+0330) | **مالک:** `order-preorder-procedure-parameters.txt` + `order-preorder-procedure-definitions.txt` + `order-preorder-procedure-parameters - Copy.txt` — تعریف/امضای ۴ پروسیجر بخش ۱۳ |
| `b07eca2` / `3d81d24` | 2026-11-19 | غیرممیز: افزودن و حذف فایل کاوش `.tmp-token-write-probe` (ابزار تشخیصی تصادلی حین عیب‌یابی push؛ بلافاصله حذف شد — هیچ محتوایی باقی نگذاشت) |

> **یادآوری پایانی:** این سند یک نقطهٔ کنترل (Checkpoint) است؛ یافته‌های جدید باید با همان قالب وضعیت‌گذاری (بخش ۰) و ارجاع فایل/خط به آن افزوده شوند و تعارض‌ها در پیوست ب ثبت شوند — نه با حذف خاموش اطلاعات قبلی.
