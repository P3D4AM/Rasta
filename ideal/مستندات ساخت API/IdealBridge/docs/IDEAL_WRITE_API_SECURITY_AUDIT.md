# ممیزی امنیتی عملیات نوشتنی Ideal CRM — سند مرجع (Write API Security Audit)

> **مسیر:** `ideal/IdealBridge/docs/IDEAL_WRITE_API_SECURITY_AUDIT.md`
> **مخزن/شاخه:** `P3D4AM/Rasta` — شاخهٔ **`ideal`**
> **تاریخ نقطهٔ کنترل:** ۲۰۲۶-۱۱-۱۹
> **ماهیت سند:** ثبت نتایج **Static Code Review** ممیزی امنیتی عملیات نوشتنی (INSERT/UPDATE/DELETE/صدور) دیتابیس `crmideal` — **این سند صرفاً مستندسازی است و هیچ تغییر عملکردی، کد، SQL عملیاتی، تنظیمات اتصال یا دیتابیسی با آن انجام نمی‌شود.**
> **جایگاه:** این سند **مرجع اصلی ممیزی امنیتی عملیات نوشتنی** است. ممیزی عملیات خواندنی در اسناد `01-ideal-api-reverse-engineering.md`، `IDEAL_API_MAPPING.md`، `IDEAL_SECURITY_ALLOWLIST.md` و `IDEAL_PII_AUDIT.md` ثبت شده و اینجا تکرار نمی‌شود (فقط ارجاع — پیوست الف).
> **ادامهٔ نقطهٔ کنترل:** بخش‌های ۱۷ تا ۲۷ در ادامهٔ همان روز (۲۰۲۶-۱۱-۱۹) و پس از کامیت `9033b94`، در چارچوب مأموریت «تکمیل IDEAL_WRITE_API_SECURITY_AUDIT و ادامه تحقیقات» افزوده شده‌اند (یافته‌های AUTH/ORD/WF، فازهای AUTH-CENTER-02، Caller Mapping، Workflow، ماتریس نقش‌ها، همسان‌سازی IdealBridge و مرز معماری؛ وضعیت ادامه در بخش ۲۶).

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
- [۱۷. یافته‌های سری AUTH — احراز هویت، مجوز و Cache](#۱۷-یافته‌های-سری-auth--احراز-هویت-مجوز-و-cache)
- [۱۸. تکمیل ممیزی Order/PreOrder (سری ORD)](#۱۸-تکمیل-ممیزی-orderpreorder-سری-ord)
- [۱۹. تعیین‌تکلیف موارد باز ثبت‌شده در پیوست ب و بند ۱ بخش ۱۶](#۱۹-تعیین-تکلیف-موارد-باز-ثبت-شده-در-پیوست-ب-و-بند-۱-بخش-۱۶)
- [۲۰. فاز AUTH-CENTER-02 — ممیزی جامع CenterId](#۲۰-فاز-auth-center-02--ممیزی-جامع-centerid)
- [۲۱. فاز Caller Mapping — نگاشت فراخوانی SPهای خانوادهٔ Write](#۲۱-فاز-caller-mapping--نگاشت-فراخوانی-spهای-خانوادهٔ-write)
- [۲۲. فاز Workflow و Idempotency](#۲۲-فاز-workflow-و-idempotency)
- [۲۳. فاز ماتریس دسترسی نقش‌ها](#۲۳-فاز-ماتریس-دسترسی-نقش‌ها)
- [۲۴. فاز همسان‌سازی IdealBridge (مستندات ↔ کد)](#۲۴-فاز-همسان-سازی-idealbridge-مستندات--کد)
- [۲۵. مرز معماری MedPad ↔ IdealBridge — رفع ابهام بخش ۱۴.۱](#۲۵-مرز-معماری-medpad--idealbridge--رفع-ابهام-بخش-۱۴۱)
- [۲۶. Continuation State — وضعیت ادامه (۲۰۲۶-۱۱-۱۹، پس از Checkpoint `9033b94`)](#۲۶-continuation-state--وضعیت-ادامه-۲۰۲۶-۱۱-۱۹-پس-از-checkpoint-9033b94)
- [۲۷. Next Chat Instructions — دستورالعمل چت بعدی](#۲۷-next-chat-instructions--دستورالعمل-چت-بعدی)
- [فاز ۱۳ — ممیزی Schema و سازگاری Queryهای IdealBridge برای MedPad](#فاز-۱۳--ممیزی-schema-و-سازگاری-queryهای-idealbridge-برای-medpad)
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

## ۱۷. یافته‌های سری AUTH — احراز هویت، مجوز و Cache

> دامنه: سورس دیکامپایل‌شدهٔ `project-analysis/decompiled/Mobile/Mobile/` (Cache، Classes، Controllers، Models) + نگاشت‌های EF (`.ssdl/.csdl/.msl`) و تعاریف SQL استخراج‌شدهٔ مخزن. یافته‌های این سری با پیشوند `AUTH` شماره‌گذاری شده‌اند؛ در زمان ثبت، هیچ شناسهٔ `AUTH` دیگری در سند وجود نداشت. برای مورد «مسیر Login» که در مأموریت «AUTH-17 یا شناسهٔ جدید» درخواست شده بود، چون شناسهٔ AUTH-17 تا این نقطه استفاده نشده بود، شناسهٔ جدید ترتیبی **AUTH-05** انتخاب شد تا شماره‌گذاری پیوسته بماند.

### ۱۷.۱ AUTH-01 — کلید Cache مجوزها فاقد CenterId است

فایل: `project-analysis/decompiled/Mobile/Mobile/Cache/User/Permissions.cs`

شواهد:

- `Get(int? userId = null, int? cId = null)` (خط 22) برای بارگذاری از `cRMEntities.MobspSelectUserRollPermission(result, cId)` استفاده می‌کند (خط 49) — یعنی `cId` به SP پاس می‌شود؛
- اما کلید Cache فقط از UserId ساخته می‌شود: `string key = MainCacheName + result;` (خط 45)؛
- `Update(int? userId = null, int? cId = null)` (خط 94) همان کلید User-محور را می‌سازد (خط 116)، Cache را Clear و با نتیجهٔ `MobspSelectUserRollPermission(result, cId)` دوباره Add می‌کند (خطوط 118-121)؛
- `Clear(int? userId = null)` (خط 63) نیز فقط با همان کلید واحد پاک می‌کند (خط 83).

پیامدهای ایستای الگو (همه **Confirmed Static Finding** در سطح کد C#):

1. Cache یک کاربر بین همهٔ CenterIdها مشترک است؛ اولین درخواستی که Cache را می‌سازد محتوا را تعیین می‌کند و درخواست‌های بعدی با cId متفاوت همان محتوا را دریافت می‌کنند (تا پایان TTL)؛
2. فراخوانی `Permissions.Update(userId)` بدون cId (نمونه‌ها: `AccountController.cs:346` در Login، `PermissionController.cs:46` و `:171`، `Cache/Manager.cs:73`) نسخهٔ cId=null را برای همهٔ مراکز جایگزین می‌کند؛
3. ترتیب درخواست‌ها مجوزهای مؤثر کاربر را تغییر می‌دهد (Request-order dependence)؛
4. تغییر نقش/مرکز/مجوز فقط از طریق همان کلید واحد بازتاب می‌یابد؛ invalidate به تفکیک مرکز ممکن نیست و `Clear` نیز لزوماً همهٔ مراکز را با هم از بین می‌برد.

مرز اطمینان: آیا `MobspSelectUserRollPermission` اساساً خروجی وابسته به CenterId تولید می‌کند؟ تعریف این SP در هیچ فایل استخراجی مخزن نیست (**SQL Definition Pending**)؛ تنها قرارداد موجود، امضای SSDL با دو پارامتر `UserId`/`CenterId` است (`Models.Mob.ssdl:4833-4836`). بنابراین: نقص طراحی کلید Cache **Confirmed Static Finding**؛ اثر عملی امنیتی آن **Runtime Verification Pending** (وابسته به رفتار SP). بارگذاری و نگهداری خود فهرست مجوزها ایراد ساختاری دیگری نشان نمی‌دهد؛ مسئله همین کلید است.

اصلاح پیشنهادی برای API جدید: کلید Cache باید `(UserId, CenterId)` باشد، یا مجوزها بدون Cache مرکزمحور و با context معتبر هر درخواست محاسبه شوند.

### ۱۷.۲ AUTH-02 — Info.Update اطلاعات مراکز کاربر را از Cache حذف می‌کند

فایل: `project-analysis/decompiled/Mobile/Mobile/Cache/User/Info.cs`

شواهد:

- `Info.Get` (خط 23) در ساخت `UserLoginInfo`، `UserCIds` (خط 58) و `UserLastCId` (خط 59) را از `MobspLoadUserLoginInfo` برمی‌دارد؛
- `Info.Update(int? userId = null, bool? fromLoginPage = null)` (خط 110) رکورد جدید Cache را **بدون این دو فیلد** می‌سازد (خطوط 139-146 فقط UserId/IsActive/FullName/RollName/RollId را پر می‌کنند)؛
- پارامتر `fromLoginPage` در بدنهٔ متد استفاده نمی‌شود (**Confirmed Static Finding**)؛
- نکتهٔ مقایسه‌ای: نسخهٔ وب همان کلاس (`CRMIdeal/CRMIdeal/Cache/User/Info.cs`) در Update هر دو فیلد را حفظ می‌کند (`UserCIds` خط 189، `UserLastCId` خط 190) و `fromLoginPage` را هم به‌کار می‌برد (خط 178) — یعنی حذف این فیلدها در نسخهٔ Mobile نقص پیاده‌سازی است، نه تصمیم طراحی.

اثر عملی (زنجیرهٔ ایستا):

- Login در هر ورود موفق `Info.Update(userId, true)` صدا می‌زند (`AccountController.cs:345`)؛ بنابراین بلافاصله پس از هر Login، `UserLogin.CurrentUser.UserCIds` و `CurrentUser.UserLastCId` تا انقضای TTL نال/خالی‌اند؛
- مصرف‌کنندگان این دو فیلد در همان پروژه: `Mobile/Classes/Helper/Order.cs:788` (`centerId = currentUser.UserLastCId` — در مسیر ثبت/مشخصات سفارش)، `ReportsController.cs:6199/6811/8165/8722`، `ReminderCartableController.cs:1874/2030`، `Mobile/Classes/Helper/Company.cs:472/650/1069`، `PersonController.cs:397`، `CompanyController.cs:2654`؛
- `AccessUserToCIds` نیز به `currUser.UserCIds` تکیه دارد (`Mobile/Classes/Helper/User.cs:41`) — با UserCIds نال خروجی آن رشتهٔ خالی می‌شود (رفتار فعلاً fail-closed، اما به معنی ازکارافتادن کنترلِ افشای مراکز تکراری است).

وضعیت: **Confirmed Static Finding** (حذف فیلدها + بی‌استفاده‌ماندن `fromLoginPage` + زنجیرهٔ فراخوانی Login)؛ اثر دقیق بر هر مصرف‌کننده **Runtime Verification Pending**. مسیر جایگزینی: تنها راه بازگشت این فیلدها، انقضای TTL یا فراخوانی دوبارهٔ `Info.Get` پس از Clear است.

### ۱۷.۳ AUTH-03 — IsUserAccess: مجوز Form/Action جایگزین مالکیت رکورد نیست (الزام معماری)

شواهد:

- `UserLogin.IsUserAccess(string formName, string actionName, UserLoginInfo user = null, int? cId = null)` (`Mobile/Classes/UserLogin.cs:32-39`) تنها عضویت `(FormName, ActionName)` را در فهرست Cacheشدهٔ `Permissions.Get(user.UserId, cId)` بررسی می‌کند؛ فیلتر مرکز (در صورت وجود) در مسیر بارگذاری مجوزها اعمال می‌شود نه در خود این متد؛
- SQL `MobspCheckActionForUser` (تعریف: `ideal/ideal-write-audit-third-definitions.txt:18844-18871`) فقط عضویت در `CrmsysRollPermission` با `RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11)` را بررسی می‌کند — نه مالکیت رکورد، نه انبار، نه شرکت؛
- نکتهٔ جانبی: همین subquery با `TOP 1` و بدون `ORDER BY` نوشته شده (**Confirmed Static Finding**) — اگر کاربر بیش از یک RollId در PrjId=11 داشته باشد، نقش مؤثر نامعین است.

الزام معماری برای API جدید — چهار مفهوم مستقل که نباید با هم اشتباه گرفته شوند (**Confirmed Static Finding** در سطح الگوی موجود / الزام طراحی):

1. Permission اکشن (Form/Action)؛
2. Permission مرکز (Center)؛
3. Permission شرکت/دامنهٔ داده (Company/DataPermission)؛
4. Ownership رکورد (تعلق والد-فرزند و مالکیت).

مجوز (1) به‌تنهایی هیچ‌یک از (2)-(4) را اثبات نمی‌کند. این همان الگویی است که بخش‌های ۵.۴، ۱۰ و ۱۳ این سند در سطح SP ثبت کرده‌اند؛ اینجا به‌عنوان الزام معماری صریح و واحد ثبت می‌شود تا در مشخصات API جدید به‌صورت لایه‌های مجوز مستقل طراحی شود.

### ۱۷.۴ AUTH-04 — اختلاف قرارداد SQL و EF در MobspCheckActionForUser

شواهد (چهار منبع مستقل):

| منبع | مسیر/خط | قرارداد |
|---|---|---|
| SQL استخراج‌شده | `ideal/ideal-write-audit-third-definitions.txt:18844-18855` | ۴ پارامتر: `@FormName NVARCHAR(50), @ActionName NVARCHAR(50), @UserId INT, @HasAction BIT OUTPUT` — بدون CenterId |
| SSDL | `project-analysis/decompiled/Mobile/Models.MobI.ssdl:1009-1015` | ۵ پارامتر، شامل `<Parameter Name="CenterId" Type="int" Mode="In" />` (خط 1014) |
| CSDL | `Models.MobI.csdl:3269-3275` | همان قرارداد ۵-پارامتری |
| کد تولیدی EF | `Mobile/Models/CRMSpEntities.cs:4561-4567` | `MobspCheckActionForUser(formName, actionName, userId, hasAction, centerId)` — ۵ آرگومان |

فراخوانندهٔ اصلی `UserLogin.IsUserAccessByUserId` (`Mobile/Classes/UserLogin.cs:49`) آرگومان پنجم را `userLastCId` (پیش‌فرض 0) پاس می‌دهد. ترتیب پارامترها در EF با نام‌گذاری شده (ObjectParameter) است و مشکل ترتیب وجود ندارد؛ مسئله، وجود خود پارامتر پنجم است.

نتیجه‌گیری محتاطانه: اگر دیتابیس استخراج‌شده همان دیتابیس هدف برنامه باشد، فراخوانی EF با پارامتر پنجم باید به خطای «تعداد آرگومان» بخورد و متد (به‌دلیل catch) false برگرداند؛ اگر چنین خطایی در عمل رخ نمی‌دهد، دیتابیس عملیاتی نسخهٔ متفاوتی از این SP دارد. **از روی فایل‌های موجود نسخهٔ عملیاتی قابل قطعیت نیست.** وضعیت: **Confirmed Static Finding** (اختلاف قرارداد در فایل‌های موجود) + **Runtime Verification Pending** (تعیین امضای واقعی با استخراج فقط-خواندنی — گنجانده‌شده در اسکریپت پنجم، §۱۹.۳).

### ۱۷.۵ AUTH-05 — مسیر Login و CenterId ورودی بدون تطبیق با UserCIds

شواهد:

- مدل ورود `MyLogin` فیلد `int? CenterId` دارد (`Mobile/Models/MyLogin.cs:29`)؛
- در `AccountController.Login` پس از احراز هویت، `UserCIds`/`UserLastCId` از `MobspLoadUserLoginInfo` فقط به پاسخ منتقل می‌شوند (خطوط 307-308) و **تنها مصرفِ `login.CenterId` در کل بدنهٔ Login**، فراخوانی `UserLogin.IsUserAccess("frmMain", "actcUserLocation", user, login.CenterId)` (خط 337) است؛
- تطبیق صریح `login.CenterId` با `UserCIds` در کل مسیر بررسی‌شده مشاهده نشد (**Confirmed Static Finding** — نبودِ تطبیق در مسیر)؛
- بلافاصله پس از آن `Info.Update(userId, true)` و `Permissions.Update(userId)` بدون cId اجرا می‌شوند (خطوط 345-346) — پیوند با AUTH-01/AUTH-02؛
- اعتبارسنجی مرکز در صورت وجود باید داخل SPها انجام شود؛ تعریف `MobspSelectUserRollPermission` در مخزن نیست و رفتار `MobspLoadUserLoginInfo` نسبت به مرکز نیز از تعریف موجود قابل استخراج نیست (**SQL Definition Pending** — هر دو در اسکریپت پنجم).

وضعیت: ورود CenterId غیرمجاز به‌عنوان context درخواست‌های بعدی **Potential Risk** تا تعیین رفتار SPها. تفاوت «مرکز فعال» (UserLastCId) و «فهرست مراکز مجاز» (UserCIds) در API جدید باید صریح شود: ورودی مرکز فقط در صورت عضویت در فهرست مجازِ هویت سرور پذیرفته شود (اصل ۱۴.۲/۱۴.۳).

### ۱۷.۶ AUTH-06 — GetUserCenters: ورودی cIds بدون اعمال AccessUserToCIds

شواهد:

- `AccountController.GetUserCenters(string cIds, int? ln = null)` (`AccountController.cs:384-445`؛ `[HttpPost][MobileAuthorize]`) پس از اعتبارسنجی توکن FO با `new FoCommon().GetToken(token)` (خط 406)، مستقیماً `MobspSelectCentersWithIds(cIds, ",", num, result2)` را فراخوانی می‌کند (خط 409)؛
- Helper موجود `Mobile.Classes.Helper.User.AccessUserToCIds(string cIds, UserLoginInfo currUser)` (`Mobile/Classes/Helper/User.cs:34-89`) اشتراک cIds درخواستی با `currUser.UserCIds` را برمی‌گرداند اما در `GetUserCenters` استفاده نمی‌شود؛ در پروژهٔ Mobile تنها دو مصرف‌کننده دارد و هر دو برای «پیام تکراری بودن» هستند (`PersonController.cs:322`، `CompanyController.cs:2579`)؛
- امضای SSDL این SP (`Models.MobI.ssdl:2207-2212`) چهار پارامتر `Ids nvarchar(max)`, `Seperator`, `LanguageID`, `DefaultLanguageID` دارد — **هیچ پارامتری برای شناسهٔ کاربر**؛ تعریف SQL در مخزن نیست (**SQL Definition Pending** — در اسکریپت پنجم).

وضعیت: الگوی کد **Confirmed Static Finding** (نبود فیلتر مراکز مجاز در Controller + امضای SP بدون User context)؛ بهره‌برداری به‌عنوان استعلام/افشای مشخصات مراکز دلخواه **Potential Risk** تا دیدن تعریف SQL. ورودی‌های خالی/تکراری/نامعتبر و ترکیبی رفتار تعریف‌شدهٔ بررسی‌شده‌ای ندارند (پردازش رشته‌ای cIds به SP واگذار می‌شود). کنترل باید در لایهٔ API (اعمال UserCIds روی cIds پیش از فراخوانی، همان کاری که AccessUserToCIds انجام می‌دهد) انجام شود و SQL نیز به شناسه‌های مجاز محدود بماند؛ جای درست کنترل، Controller/Service است نه اعتماد به SQL.

### ۱۷.۷ AUTH-07 — مسیر تغییر UserLastCId: در API موبایل وجود ندارد؛ در وب بدون اعتبارسنجی

جست‌وجوی سراسری (`UserLastCId`, `UserCIds`, `actcUserLocation`, `CenterId`, `GetUserCenters`) در کل `project-analysis/decompiled`:

**API موبایل (Mobile):**

- هیچ endpoint و هیچ فراخوانی SP برای «تغییر مرکز فعال کاربر» وجود ندارد؛ `UserLastCId` فقط خوانده می‌شود (فهرست مصرف‌کنندگان در §۱۷.۲)؛
- `MobspUpdateCompanyCIds` (`CompanyController.cs:2654`) و `MobspUpdateCompanyPersonCIds` (`PersonController.cs:397`، `Helper/Company.cs:1069`) به کاربر ربط ندارند — CIds شرکت/شخص را به مرکز وصل می‌کنند؛
- این موضوع به‌عنوان **خلأ مستندات** ثبت می‌شود: طراحی API جدید باید مشخص کند تغییر مرکز فعال چگونه انجام می‌شود (endpoint صریح + اعتبارسنجی `cId ∈ UserCIds` + بازسازی Cache مجوزها).

**وب CRMIdeal:**

- endpoint تغییر مرکز وجود دارد: `AccountsController.UpdateUserLastCId(int cId)` (`CRMIdeal/Areas/Accounts/Controllers/AccountsController.cs:8400-8420`؛ `[HttpPost][LoginAuthorize]`) که `Helper.User.UpdateUserLastCId(CurrentUser.UserId, cId)` (`CRMIdeal/Classes/Helper/User.cs:126-142`) → `CRMspUpdateUserLastCId(userId, cId)` را فراخوانی می‌کند (امضای SSDL: `Models/CRMSpII.ssdl:2963`)؛ سپس Cacheها بازسازی می‌شوند (`Info.Update`, `Permissions.Update`, ... — خطوط 8409-8413)؛
- **در Controller هیچ تطبیق `cId` با `UserCIds` کاربر مشاهده نشد** (**Confirmed Static Finding** — نبودِ اعتبارسنجی در مسیر بررسی‌شده)؛ تعریف `CRMspUpdateUserLastCId` در مخزن نیست (**SQL Definition Pending** — در اسکریپت پنجم)؛
- مسیر کمکی `UpdateUserLastCIdForFirst` (`Helper/User.cs:144-177`) اولین مؤلفهٔ غیرخالی `UserCIds` را انتخاب می‌کند — منبع آن فهرست خود کاربر است و ریسک ورودی ندارد.

وضعیت کل: **Potential Risk** (ثبت مرکز فعال غیرمجاز در وب، اگر SP نیز کنترل نکند) + **خلأ مستندات** (نبود مسیر معادل در API موبایل).

### ۱۷.۸ AUTH-08 — صدور توکن از ورودی خامِ بدون احراز هویت + بازنویسی Cache کاربر دیگر (یافتهٔ جدید، اولویت بالا)

این یافته هنگام اجرای فاز AUTH کشف شد و به‌دلیل شدت بالاتر از سایر موارد این سری، پیش از ادامهٔ فازهای بعدی ثبت و مستند می‌شود (اعمال قاعدهٔ «تغییر ترتیب با ذکر دلیل»).

دو endpoint با الگوی یکسان:

| Controller | متد | ویژگی احراز هویت |
|---|---|---|
| `Mobile/Controllers/AccountController.cs:1770-1819` | `CmpAuthenticationByMobNum(CmpAuthenticationByMobileModel model)` | فقط `[HttpPost]` — بدون `[MobileAuthorize]` |
| `Mobile/Controllers/CRMShopAccountController.cs:23-115` | `CmpAuthenticationByMobNum(...)` (هم‌نام) | فقط `[HttpPost]` — بدون `[MobileAuthorize]` |

زنجیرهٔ مشاهده‌شده (در هر دو):

1. `model.UserId` و `model.UserRollId` مستقیماً از بدنهٔ درخواست می‌آیند (`Mobile/Models/CmpAuthenticationByMobileModel.cs:9-11`) و هیچ اعتبارسنجی مالکیت روی این مقادیر در مسیر انجام نمی‌شود (تنها کنترل‌های مسیر، جست‌وجوی شمارهٔ موبایل/فعال‌بودن فروشگاه است)؛
2. توکن با چیدمان استاندارد Common ساخته می‌شود: `rand|model.UserId|rand|model.UserRollId|rand|extra|rand|datetime|rand` → `CodeDecode.Codding(...)` (`AccountController.cs:1793-1794`، `CRMShopAccountController.cs:86-87`)؛
3. `Common.GetToken` دقیقاً همین چیدمان را parse می‌کند (userId از اندیس 1، rollId از اندیس 3 — `Mobile/Classes/Helper/Common.cs:15-36`) و `[MobileAuthorize]` فقط تطابق هدر `extra` با `extra` داخل توکن را می‌خواهد (`Mobile/Classes/MobileAuthorizeAttribute.cs:20-48`) که هر دو مقدار تحت کنترل فراخواننده‌اند؛
4. همان endpoint بلافاصله `Info.Update(model.UserId, false)` و `Permissions.Update(model.UserId)` را اجرا می‌کند (`AccountController.cs:1795-1796`، `CRMShopAccountController.cs:88-89`) — یعنی **بازنویسی Cache اطلاعات و مجوزهای هر UserId دلخواه** بدون احراز هویت (پیوند با AUTH-01/AUTH-02)؛
5. در نسخهٔ CRMShop علاوه بر آن، عملیات نوشتنی `MobspUpdateCompanyCRMShopActive(..., userId: model.UserId, ...)` با UserId خام ورودی اجرا می‌شود (`CRMShopAccountController.cs:78`).

وضعیت: الگوی کد **Confirmed Static Finding**؛ بهره‌برداری‌پذیری عملی (دسترس‌پذیری بیرونی این endpointها در استقرار واقعی) **Runtime Verification Pending**. اگر endpoint در استقرار در دسترس باشد، این مسیر عملاً «انتقال هویت هر کاربر/نقش دلخواه» بدون احراز هویت است و جزو **P0** قرار می‌گیرد. اصلاح: UserId/RollId باید از احراز هویت سمت سرور بیاید نه بدنهٔ درخواست؛ توکن فقط پس از اثبات مالکیت صادر شود؛ نوشتن Cache/DB هرگز با شناسهٔ خام ورودی انجام نشود.

### ۱۷.۹ AUTH-09 — الگوی سیستماتیک «CenterId در EF هست، در دیتابیس استخراج‌شده نیست»

در ادامهٔ AUTH-04، همان اختلاف قرارداد در سه SP دیگر مسیر Write/Workflow مشاهده شد:

| SP | پارامترهای دیتابیس استخراج‌شده (منبع) | پارامتر(های) اضافه در SSDL/EF | شواهد SSDL | فراخوانی Controller |
|---|---|---|---|---|
| `MobspCheckActionForUser` | ۴ پارامتر، بدون CenterId (`ideal-write-audit-third-definitions.txt:18844`) | `CenterId` | `Models.MobI.ssdl:1014` | `Mobile/Classes/UserLogin.cs:49` |
| `MobspUpdateOrder` | ۱۲ پارامتر، بدون CenterId (`ideal/order-preorder-procedure-parameters - Copy.txt` ردیف‌های ۱-۱۲) | `CenterId` | `Models.Mob.ssdl:5317` | `UpdateController.cs:1541` |
| `MobspUpdatePreOrder` | ۱۰ پارامتر، بدون CenterId (همان فایل، ردیف‌های ۱-۱۰) | `CenterId` | `Models.Mob.ssdl:5362` | `UpdateController.cs:1194` |
| `MobspVerificationRequestVerify` | ۲۰ پارامتر (`ideal/ideal-write-audit-third-definitions.txt:35235-35256`) | `VerifyReqResultId`, `InternalMessageId`, `CenterId` | `Models.Mob.ssdl:5593-5595` | `VerificationWorkFlowController.cs` (متد `VerifyRequest`) |

وضعیت: **Confirmed Static Finding** (اختلاف در فایل‌های موجود، ۴ SP) + **Runtime Verification Pending** برای تعیین اینکه دیتابیس عملیاتی کدام امضا را دارد و آیا بیلد دیکامپایل‌شده با دیتابیسِ استخراج مالک هم‌نسخه است. دلالت برای API جدید: حضور پارامتر CenterId در کد موبایل «قصد طراحیِ» فیلتر مرکزی را نشان می‌دهد که در تعریف‌های استخراج‌شده محقق نشده است؛ قرارداد CenterId باید با استخراج پنجم (sys.parameters) تعیین تکلیف و در مشخصات API جدید version-lock شود.

---

## ۱۸. تکمیل ممیزی Order/PreOrder (سری ORD)

یافته‌های این سری مکمل بخش‌های ۱۲ و ۱۳ هستند و یافته‌های تکراری آن بخش‌ها بازنویسی نشده‌اند. منبع اصلی تعاریف SP: استخراج مالک (`ideal/order-preorder-procedure-parameters.txt`، کامیت `e6968a0`).

### ۱۸.۱ ORD-01 — کنترل دسترسی ReferUserId فقط در حالت non-null اجرا می‌شود و null کردن فیلد هم کنترل را دور می‌زند هم ارجاع را پاک می‌کند

شواهد دقیق (هر دو SP الگوی یکسان دارند؛ نقل از تعریف مالک):

- شرط ورودی کنترل: `IF(@ordReferUserId IS NOT NULL)` در `MobspUpdateOrder` و `IF(@pordReferUserId IS NOT NULL)` در `MobspUpdatePreOrder`؛
- منطق کنترل: مجاز بودن ReferUser درخواستی در مجموعهٔ `{@UserId} ∪ {LinkedUserId : CrmUserId = @UserId AND LinkedTypeId = 15}` (جدول `CrmLinkedUsers`)؛ در صورت رد، فقط `@ErrorMessage += '|Msg=ordReferUserIdAccess'` (یا `pordReferUserIdAccess`) اضافه می‌شود؛
- Update اصلی تحت گارد `IF(@ErrorMessage = '' OR @ErrorMessage IS NULL)` اجرا می‌شود — یعنی در شاخهٔ «مقدار غیرنالِ غیرمجاز»، Update اجرا نمی‌شود (رفتار درست)؛
- **اما** در حلقهٔ تجزیهٔ payload، مقدار متنی `'null'` صریحاً به SQL NULL نگاشت می‌شود (نمونه از تعریف: `CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(...) END`) و حذف فیلد از payload نیز متغیر را NULL نگه می‌دهد؛ در این حالت بلوک کنترل به‌کل اجرا نمی‌شود؛
- در عین حال ستون `[ordReferUserId] = @ordReferUserId` / `[pordReferUserId] = @pordReferUserId` **بی‌قیدوشرط** در فهرست SET همان Update اصلی آمده است؛
- جمع‌بندی این دو: ارسال `ordReferUserId=null` (یا حذف فیلد) **هم کنترل دسترسی را دور می‌زند و هم ارجاع‌دهندهٔ فعلی رکورد را NULL می‌کند** — یعنی محدودیت «کاربر فقط می‌تواند به خودش/کاربران مرتبطش ارجاع دهد» با null کردن فیلد قابل دورزدن است.

وضعیت: **Confirmed Static Finding** (الگوی شرط + SET بی‌قیدوشرط + نگاشت 'null'→NULL)؛ اثر تجاری **Potential Risk**. در بازبینی این نقطهٔ کنترل، الگوی مشابه «کنترل مشروط به non-null بودن» برای فیلدهای حساس دیگر این دو SP دیده نشد (فیلدهای شرکت/پروژه اصلاً کنترل هم‌خانواده ندارند — ORD-02).

### ۱۸.۲ ORD-02 — ماتریس منبع شناسه‌های حساس در مسیرهای Insert/Update سفارش و پیش‌سفارش

روش: ردیابی هر شناسه از ViewModel تا SP (سورس Controller + تعریف SP مالک).

| شناسه | در Update (UpdateController) | در Insert (OrderController/PreOrderController) | رکورد قبلی load می‌شود؟ | کنترل رابطهٔ جدید با Company/دسترسی کاربر |
|---|---|---|---|---|
| `CompanyId` | از payload (فیلد `ordCompanyId=`/`pordCompanyId=` در رشتهٔ `|#|`) | از payload (`model.Order`) | خیر — Controller رکورد قبلی را نمی‌خواند | مشاهده نشد — در بدنهٔ هر دو SP هیچ فراخوانی Helper مجوز (`MobspCheckCmpDataPermissionForUser`/`MobspCheckActionForUser`) وجود ندارد (تأیید با جست‌وجوی `EXEC` در کل تعریف) |
| `CompanyPersonId` | از payload (`ordCompanyPersonId=`/`pordCompanyPersonId=`) | از payload | خیر | همان بالا |
| `ProjectId` | از payload (`ordProjectId=`/`pordProjectId=`) | از payload | خیر | همان بالا |
| `ReferUserId` | از payload (`ordReferUserId=`/`pordReferUserId=`) — کنترل مشروط به non-null (ORD-01) | از payload | خیر | فقط همان کنترل مشروط CrmLinkedUsers |
| `CenterId` | ویژگی مدل `model.CenterId` (`UpdateOrderViewModel.cs` و همتایان) — به SP پاس می‌شود (طبق AUTH-09 در دیتابیس استخراج‌شده پارامتری ندارد) | `model.CenterId` از payload — به SP و `IsUserAccess` پاس می‌شود (`OrderController.cs:831-841`) | — | تطبیق با UserCIds مشاهده نشد (بخش ۲۰) |
| `UserId` | از توکن (`token2.userId` — `UpdateController.cs:1533`/`1194`) | سفارش: از payload با fallback توکن (`OrderController.cs:836` — ORD-03)؛ پیش‌سفارش: از توکن (`PreOrderController.cs:656`) | — | — |

نتیجه: امکان تغییر رکورد سفارش/پیش‌سفارش به شرکت/شخص/پروژهٔ دیگر از payload در سطح SP ثابت است (SET بی‌قیدوشرط + WHERE فقط با شناسهٔ رکورد — §۱۳.۳) و کنترل جبرانی در Controller نیز مشاهده نشد؛ این یافته ادغام‌شدهٔ تکمیلی بخش ۱۲ است. وضعیت: **Confirmed Static Finding** (منبع شناسه‌ها) + **Potential Risk** (جابجایی مالکیت رکورد تا طراحی کنترل مستقل).

### ۱۸.۳ ORD-03 — InsertOrderFull: UserId قابل ارسال از Payload در برابر InsertPreOrderFull با token.userId

شواهد:

- `OrderController.InsertOrderFull` (`OrderController.cs:799-841`): خط 836 — `model.UserId = model.UserId ?? token2.userId;` — اگر کلایست UserId بفرستد همان مبناست و توکن فقط fallback است؛ سپس `MobspInsertOrderFull(..., model.UserId, ..., model.CenterId, ...)` (خط 841)؛
- `PreOrderController.InsertPreOrderFull` (`PreOrderController.cs:616-656`): مستقیماً `token2.userId` پاس می‌شود (خط 656)؛
- `InsertOrderFullViewModel.UserId` یک `int?` سادهٔ قابل دستکاری است (`Mobile/Models/InsertOrderFullViewModel.cs`)؛
- `InsertShopOrderFull` (`OrderController.cs:987-1091`): SP آن (`SHPMobspIssueOrder`، خط 1091) **اصلاً پارامتر UserId ندارد** — ثبت سفارش فروشگاهی بدون ثبت هویت کاربر فراخوان؛ همچنین نتیجهٔ `UserLogin.IsUserAccess("frmOrderItemDataEntry", "actCanNotSelectWithNoStockInOrd", ...)` در خط 1020 **مصرف نمی‌شود** (مقدار بازگشتی نادیده گرفته شده) — **Confirmed Static Finding**؛
- تعریف SQL `MobspInsertOrderFull` و `SHPMobspIssueOrder` در مخزن موجود نیست (**SQL Definition Pending** — هر دو در اسکریپت پنجم)؛
- بررسی سایر Insertها: در پروژهٔ Mobile تنها این الگو (پذیرش UserId از مدل) در `InsertOrderFull` دیده شد؛ سایر Insertهای بررسی‌شده UserId را از توکن می‌گیرند؛ عمدی‌بودن تفاوت سفارش/پیش‌سفارش در هیچ سند مخزنی توجیه نشده — **Runtime Verification Pending** (نیازمند تعریف SP برای تعیین اینکه آیا SP مالکیت/رابطهٔ UserId ورودی را کنترل می‌کند).

وضعیت: **Confirmed Static Finding** (منبع UserId/CenterId از payload در InsertOrderFull + نبود UserId در SHPMobspIssueOrder + نادیده‌گرفتن نتیجهٔ مجوز) + **Potential Risk** (ثبت سفارش به نام کاربر دیگر تا اثبات کنترل داخل SP).

### ۱۸.۴ ORD-04 — نقص نهایی‌سازی تراکنش در MobspUpdateOrder / MobspUpdatePreOrder

شواهد (پایان هر دو تعریف مالک؛ الگوی یکسان):

- `BEGIN TRANSACTION Main` در ابتدای بدنه + `BEGIN TRAN`های بی‌نام داخلی برای بلوک‌های میانی؛
- پایان مسیر: `IF (@@ERROR > 0) BEGIN SET @ErrorFrom='...' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END ELSE COMMIT TRAN` — همان الگوی ازدست‌رفتن `@@ERROR` پس از `SET` (ثبت‌شده در §۳.۴)؛
- سپس: `IF (@ErrorNumber > 0) BEGIN RAISERROR('Error From TransAction %S', 16, 1, @ErrorFrom) ROLLBACK TRANSACTION Main ... END ELSE BEGIN COMMIT TRANSACTION Main ... END` — یعنی **مسیر COMMIT/ROLLBACK دوگانه** (یک‌بار در شاخهٔ `@@ERROR` و بار دیگر در شاخهٔ `@ErrorNumber`)؛
- `%S` در `RAISERROR` مشخص‌کنندهٔ قالب نامعتبر است (خودش خطای ثانویه تولید می‌کند)؛
- متغیر `@UpdatedOrderId`/`@UpdatedPreOrderId` پیش از این شاخه‌بندی نهایی و فارغ از نتیجهٔ تراکنش مقداردهی می‌شود.

وضعیت: **Confirmed Static Finding** (ساختار تراکنش) + پیامد رفتاری (رولبک/کامیت مؤثر در سناریوهای خطا) **Potential Risk** — نیازمند اثبات اجرایی. مکمل §۱۳.۳.

---

## ۱۹. تعیین‌تکلیف موارد باز ثبت‌شده در پیوست ب و بند ۱ بخش ۱۶

### ۱۹.۱ مورد ۲ پیوست ب — `MobspCheckCompanyDataPermissionForUser`

جست‌وجوی مجدد در تمام فایل‌های استخراجی هر چهار دور + استخراج مالک (`ideal/ideal-write-audit-*.txt`، `order-preorder-*.txt`): این نام **در هیچ خروجی استخراجی وجود ندارد**؛ تنها حضورش فهرست اهداف اسکریپت چهارم است (`ideal/ideal-write-audit-fourth-fixed.sql:15`). تمام ارجاعات داخل بدنهٔ SPها به Helper مجوز، با نام کوتاه `MobspCheckCmpDataPermissionForUser` است (نمونه‌ها: ۱۱ ارجاع در استخراج اول، ۲۷ در `fourth-part-1.txt`، ۱۳ در `fourth-part-10.txt`).

جمع‌بندی: شواهد به **یک شیء واحد با نام کوتاه** اشاره می‌کنند؛ نام بلند در فهرست اهداف اسکریپت، نام‌گذاری غیررسمی/متفاوت بوده و دو موجودیت مستقل منظور نبوده است. کاوش موجودیتِ نام بلند در اسکریپت پنجم گنجانده شد؛ تا آن زمان وضعیت «دو نام، دو موجودیت مستقل» منتفی و وضعیت Helper با نام کوتاه همان §۵.۴ می‌ماند.

### ۱۹.۲ مورد ۳ پیوست ب — `MobspSingleCrmConversationPreChecks`

تعریف همچنان در مخزن نیست (**SQL Definition Pending**)، اما **قرارداد فراخوانی** آن از سه فراخوانندهٔ موجود مستند شد:

| فراخواننده | شاهد وابستگی | شاهد EXEC | Mode |
|---|---|---|---|
| `MobspInsertQuickCmpPrsPrjCnvs` | `ideal-write-audit-fourth-part-1.txt:561` | `ideal-write-audit-fourth-part-8.txt:3656` | ۱ |
| `MobspInsertQuickConversation` | `ideal-write-audit-fourth-part-1.txt:637` | `ideal-write-audit-fourth-part-8.txt:6042` | ۱ |
| `MobspUpdateConversation` | `ideal-write-audit-fourth-part-1.txt:912` | `ideal-write-audit-fourth-part-10.txt:6839` | ۲ |

قرارداد پارامترها (از هر سه فراخوان، یکسان): `@Mode, @ConversationID, @cnvsCompanyId, @cnvsProjectId, @cnvsPersonId, @cnvsStatusId, @cnvsStatusResultId, @cnvsDoingTimeSec, @CurrentUserId, @LanguageID, @DefaultLanguageID, @ChecksNotPassed OUTPUT, @ErrorMessage OUTPUT`. استخراج تعریف کامل در اسکریپت پنجم گنجانده شد.

### ۱۹.۳ بند ۱ بخش ۱۶ — دو SP باقی‌مانده و اسکریپت استخراج پنجم

- `MobspUpdateOrderItem` و `MobspUpdatePreOrderItem`: جست‌وجوی کامل مجدد در همهٔ فایل‌های `ideal/` → هیچ `CREATE PROCEDURE` با این دو نام وجود ندارد؛ وضعیت **SQL Definition Pending** حفظ می‌شود؛
- قرارداد مورد انتظار از SSDL (شواهد جدید — تعریف SQL نیست): `MobspUpdateOrderItem` با ۱۶ پارامتر (`Models.Mob.ssdl:5319-5336`؛ شامل `DontCheckQuantity` و `ActCanNotSelectWithNo*` و **بدون CenterId**) و `MobspUpdatePreOrderItem` با ۱۴ پارامتر (`Models.Mob.ssdl:5371-5386`)؛
- در همین نقطهٔ کنترل اسکریپت فقط-خواندنی **`ideal/ideal-write-audit-fifth-pending-sp.sql`** ایجاد شد: فقط کاتالوگ‌های سیستمی (`sys.objects`, `sys.parameters`, `sys.sql_modules`, `sys.schemas`, `sys.sql_expression_dependencies`)؛ بدون اجرای هیچ SP و بدون خواندن هیچ ردیف تجاری. اهداف: ۱۱۱ SP خانوادهٔ Write بدون تعریف (§۲۱) + `MobspUpdateOrderItem`, `MobspUpdatePreOrderItem`, `MobspSingleCrmConversationPreChecks`, `MobspInsertOrderFull`, `SHPMobspIssueOrder` + SPهای مسیر AUTH (`MobspSelectUserRollPermission`, `MobspSelectCentersWithIds`, `MobspLoadUserLoginInfo`, `CRMspUpdateUserLastCId`, `MobspCheckActionForUser`, `MobspCheckCmpDataPermissionForUser`, `MobspCheckCompanyDataPermissionForUser` به‌عنوان کاوش موجودیت) + چهار SP اختلاف قرارداد AUTH-09.

### ۱۹.۴ بند ۲ بخش ۱۶ — ممیزی عمیق دو پروسیجر اصلاح — انجام شد

موارد §۱۸.۱ تا §۱۸.۴ همین سند، تکمیل ممیزی عمیق `MobspUpdateOrder`/`MobspUpdatePreOrder` است: کنترل ReferUserId، فهرست کامل فیلدهای payload (۷۵ کلید یکتای Order و ۸۲ کلید PreOrder از حلقهٔ تجزیه)، SETهای بی‌قیدوشرط شرکت/شخص/پروژه، گارد `@ErrorMessage`، ساختار تراکنش و نگاشت 'null'→NULL.

---

## ۲۰. فاز AUTH-CENTER-02 — ممیزی جامع CenterId

روش: بررسی همهٔ endpointهای Write در Controllerهای سفارش/پیش‌سفارش/اصلاح/گردش‌کار تأیید/خرید/انبار/درج سریع + Helperهای مرتبط از سورس دیکامپایل‌شده؛ تعریف SQL هر SP فقط در صورت وجود در مخزن لحاظ شد.

### ۲۰.۱ تیپولوژی منبع CenterId (پنج الگوی مشاهده‌شده)

1. پارامتر query با نام `cId` — endpointهای Verify/VerifyExit/Delete/جزئیات؛ به `IsUserAccess(..., cId)` و/یا SP پاس می‌شود؛
2. ویژگی مدل `model.CenterId` — endpointهای Insert/Update؛ مستقیم به SP و گاه به `IsUserAccess`؛
3. `login.CenterId` — فقط در Login و فقط برای مجوز `actcUserLocation` (AUTH-05)؛
4. `currentUser.UserLastCId` — خواندن از Cache (که بلافاصله پس از هر Login به‌دلیل AUTH-02 نال است)؛ مصرف در `Helper/Order.cs:788`، Reports، Reminder؛
5. از توکن — **در هیچ مسیر بررسی‌شده CenterId از توکن نمی‌آید** (توکن فقط userId/rollId/extra/datetime دارد — `Common.cs:15-36`).

### ۲۰.۲ ماتریس CenterId عملیات Write

| # | Controller/Endpoint | گارد مجوز (Form/Action) | منبع CenterId | تطبیق با UserCIds | SP مقصد | وضعیت SQL |
|---|---|---|---|---|---|---|
| 1 | `OrderController.InsertOrderFull` (خط 801) | `frmOrderItemDataEntry/actCanNotSelectWithNo*InOrd` (خطوط 831-833) — فقط برای فلگ‌های موجودی | `model.CenterId` (payload) | خیر | `MobspInsertOrderFull` | **Pending** |
| 2 | `OrderController.InsertShopOrderFull` (خط 987) | همان فرم (خط 1020) — **نتیجه مصرف نمی‌شود** | `model.CenterId` (payload) | خیر | `SHPMobspIssueOrder` | **Pending** |
| 3 | `OrderController.OrderVerify` (خط 212) | `frmOrder/actVerifyOrder` | `cId` (query) | خیر | `MobspOrderVerifyWithPreChecks` | موجود (§۱۳.۲) |
| 4 | `OrderController.OrderVerifyExit` (خط 403) | `frmOrder/actExitFromIsFix` | `cId` | خیر | `MobspOrderVerifyExit` | موجود (third-definitions) |
| 5 | `PreOrderController.PreOrderVerify` (خط 262) | `frmPreOrder/actVerifyPreOrder` | `cId` | خیر | `MobspPreOrderVerifyWithPreChecks` | موجود (§۱۳.۲) |
| 6 | `PreOrderController.PreOrderVerifyExit` (خط 493) | `frmPreOrder/actExitFromIsFix` | `cId` | خیر | `MobspPreOrderVerifyExit` | موجود |
| 7 | `UpdateController.Order` (خط 1497) | **بدون گارد مجوز** (فقط اعتبار توکن) | `model.CenterId` (payload) | خیر | `MobspUpdateOrder` | موجود (مالک) |
| 8 | `UpdateController.PreOrder` (خط 1163) | **بدون گارد مجوز** | `model.CenterId` | خیر | `MobspUpdatePreOrder` | موجود (مالک) |
| 9 | `UpdateController.OrderItem` (خط 1626) | فلگ‌های موجودی (طبق §۱۲) | `model.CenterId` | خیر | `MobspUpdateOrderItem` | **Pending** |
| 10 | `UpdateController.PreOrderItem` (خط 1279) | فلگ‌های موجودی | `model.CenterId` | خیر | `MobspUpdatePreOrderItem` | **Pending** |
| 11 | `UpdateController.OrderPayment` / `PreOrderPayment` (خطوط 1837/1400) | مشاهده نشد | — | — | `MobspUpdateOrderPayment` / `MobspUpdatePreOrderPayment` | **Pending** |
| 12 | `VerificationWorkFlowController.VerifyRequest` (خط 152) | گارد مستقیم پیش از SP مشاهده نشد؛ `IsUserAccess` فقط برای تصمیم‌های پس از تأیید (خطوط 302، 476-479) | `model.CenterId` (payload) | خیر | `MobspVerificationRequestVerify` | موجود (third-definitions:35224+) |
| 13 | `VerificationWorkFlowController.EditObject*` (Order/PreOrder/BuyOrder/Doc/Draft/Movement/DyForm — خطوط 1961-2829) | مشاهده نشد | `cId` (فقط EditObjectPreOrder) | خیر | `MobspUpdate*EditAfterFixInfoJs` (۷ SP) | **Pending** |
| 14 | `BuyOrderController.BuyOrderVerify` (خط 184) | `frmBuyOrder/actVerifyOrder` (خط 208) | `cId` | خیر | `MobspBuyOrderVerify` | موجود |
| 15 | `BuyOrderController.BuyOrderVerifyExit` (خط 307) | `frmBuyOrder/actExitFromIsFix` (خط 331) | `cId` | خیر | `MobspBuyOrderVerifyExit` | موجود |
| 16 | `WareHouseController.InsertDocFull` (خط 741) | مشاهده نشد (طبق §۴.۴) | `model.CenterId` (payload — خط 776) | خیر | `MobspInsertDocFull` | موجود (next-definitions:10199) |
| 17 | `WareHouseController.DocVerify` (خط 959) | `frmDoc/actVerifyDoc` یا `frmDraft/actVerifyDraft` یا `frmWareHouseMovement/actVerifyDoc` (خطوط 1001-1007) | `cId` | خیر | `MobspDocVerify` | موجود |
| 18 | `WareHouseController.DocVerifyExit` (خط 1084) | `actExitFromIsFix` سه‌گانه (خطوط 1125-1131) | `cId` | خیر | `MobspDocVerifyExit` | موجود |
| 19 | `DeleteController.Order` (خط 672) / `PreOrder` (خط 579) | `frmOrder/actDelete` (خط 696) / `frmPreOrder/actDelete` (خط 603) | `cId` | خیر | `MobspDeleteWSOrder(pordId)` / `MobspDeleteWSPreOrder(pordId)` — **فقط شناسهٔ رکورد، بدون هیچ پارامتر کاربر** | موجود |
| 20 | `DeleteController.OrderItem/OrderPayment/...` (خطوط 765-1032+) | `actRemoveProduct`/`actDeletePay`/... | `cId` | خیر | خانوادهٔ `MobspDelete*` | اغلب موجود |
| 21 | `InsertQuickController.InsertQuick*` (۶ endpoint؛ خطوط 24-2056) | مشاهده نشد | `model.CenterId` (payload) | خیر | `MobspInsertQuick*` | CmpPrsPrjCnvs موجود (§۱۱)؛ Company/Person/Project/Conversation موجود |
| 22 | `AccountController.Login` (خط 30) | `frmMain/actcUserLocation` (خط 337) | `login.CenterId` (payload) | خیر | — (مسیر SP مجوز: AUTH-01) | Pending |
| 23 | `AccountController.GetUserCenters` (خط 386) | فقط اعتبار توکن FO | `cIds` (query) | خیر (AUTH-06) | `MobspSelectCentersWithIds` | **Pending** |
| 24 | `CRMIdeal AccountsController.UpdateUserLastCId` (خط 8402 — وب) | فقط `[LoginAuthorize]` | `cId` (payload) | خیر (AUTH-07) | `CRMspUpdateUserLastCId` | **Pending** |

نکتهٔ ردیف ۱۹: `MobspDeleteWSOrder(@OrderId INT)` (تعریف: `ideal-write-audit-third-definitions.txt` — بلوک `MobspDeleteWSOrder`) فقط با شناسهٔ رکورد کار می‌کند، در بدنه گارد وضعیت (`ordIsVerified/ordIsFixed`) یا مالکیت ندارد و DELETE ساده است؛ تنها کنترل، مجوز فرم در Controller و یک خواندن قبلی `MobspSelectOrderWithID(ordId, token2.userId, ..., cId)` است که خودش **SQL Definition Pending** است (فیلتر دید کاربر در آن قابل اثبات نیست). تراکنش و TRY/CATCH در این SP وجود دارد (**Confirmed Static Finding** — مثال مثبت نسبی).

### ۲۰.۳ جمع‌بندی فاز

- در **هیچ‌یک** از ۲۴ مسیر بالا، تطبیق صریح CenterId با `UserCIds` کاربر انجام نمی‌شود؛ تنها سازوکار موجود (`AccessUserToCIds`) فقط در دو مسیر نمایش «پیام تکراری» به‌کار رفته است؛
- CenterId ورودی در بخش بزرگی از endpointها مستقیماً به SPهای Write پاس می‌شود و در چهار SP کلیدی طبق AUTH-09 اصلاً پارامتری برای آن در دیتابیس استخراج‌شده وجود ندارد؛
- الزام برای API جدید: (الف) CenterId از context معتبر (توکن/نشست) یا از رکورد والد استخراج شود، (ب) عضویت در فهرست مراکز مجاز هویتِ سرور کنترل شود، (ج) در قرارداد هر SP صریح و version-locked باشد.

---

## ۲۱. فاز Caller Mapping — نگاشت فراخوانی SPهای خانوادهٔ Write

روش: استخراج همهٔ فراخوانی‌های `Mobsp*Verify*|Update*|Delete*|Insert*` از کل Controllers/Classes/Helpers پروژهٔ Mobile (الگوی فراخوانی روی شیء EF) و تطبیق با تعریف‌های موجود مخزن.

نتایج شمارشی (**Confirmed Static Finding** — شمارش مستقیم از سورس):

- **۱۸۲** SP خانوادهٔ Write از کد Mobile فراخوانی می‌شوند؛
- **۷۱** تعریف SQL در مخزن موجود است (استخراج‌های ۱-۴ + استخراج مالک)؛
- **۱۱۱** تعریف ندارند (**SQL Definition Pending**) — فهرست کامل هر ۱۱۱ مورد به‌صورت اهداف دقیق در اسکریپت پنجم (`ideal/ideal-write-audit-fifth-pending-sp.sql`) گنجانده شده است.

نگاشت کلیدی مسیر سفارش/پیش‌سفارش/سند/گردش‌کار (نمونهٔ مهم؛ فهرست کامل ۱۸۲ مورد در خروجی مرحلهٔ نگاشت نگهداری شده و قابل بازتولید است):

| SP | فراخواننده(های) مستقیم |
|---|---|
| `MobspInsertOrderFull` | `OrderController` |
| `MobspInsertPreOrderFull` | `PreOrderController` |
| `MobspUpdateOrder` / `MobspUpdatePreOrder` | `UpdateController` |
| `MobspUpdateOrderItem` / `MobspUpdatePreOrderItem` | `UpdateController` |
| `MobspUpdateOrderPayment` / `MobspUpdatePreOrderPayment` | `UpdateController` |
| `MobspOrderVerifyWithPreChecks` / `MobspOrderVerifyExit` | `OrderController` |
| `MobspPreOrderVerifyWithPreChecks` / `MobspPreOrderVerifyExit` | `PreOrderController` |
| `MobspVerificationRequestVerify` | `VerificationWorkFlowController` |
| `MobspBuyOrderVerify(Exit)` | `BuyOrderController` |
| `MobspDocVerify(Exit)` / `MobspInsertDocFull` | `WareHouseController` |
| `MobspDeleteWSOrder` / `MobspDeleteWSPreOrder` / `MobspDeleteWSDoc(Items...)` / `MobspDeleteCrm*` | `DeleteController` |
| `MobspUpdate*EditAfterFixInfoJs` (۷ SP) | `VerificationWorkFlowController` |
| `MobspInsertQuick*` (۵ SP) | `InsertQuickController` |
| `MobScorespInsertAndCalcOrderScores` / `MobScorespDeleteOrderScores` | `OrderController` (خطوط 284/452) |
| `MobspSendSms*FOLinkAfterVerify` | `OrderController`/`PreOrderController`/`VerificationWorkFlowController` |

جمع‌بندی پوشش: نگاشت فراخوانی **کامل** است (همهٔ فراخوانی‌های کد شمرده و طبقه‌بندی شدند)؛ اما پوشش تعریف SQL فعلاً ۳۹٪ است و تا اجرای اسکریپت پنجم توسط مالک، وضعیت SPهای بدون تعریف همان `SQL Definition Pending` می‌ماند. مسیرهای غیرمستقیم (SPهایی که SPهای دیگر را صدا می‌زنند — مانند `MobspUpdateConversation` → `MobspSingleCrmConversationPreChecks`) فقط برای مواردی که فرادادهٔ وابستگی در استخراج چهارم موجود بود ثبت شده‌اند (§۱۹.۲).

---

## ۲۲. فاز Workflow و Idempotency

چرخهٔ حیات مشاهده‌شده در کد Mobile (سفارش؛ پیش‌سفارش هم‌الگو):

1. ایجاد: `OrderController.InsertOrderFull` → `MobspInsertOrderFull` (+ مسیر فروشگاه: `InsertShopOrderFull` → `SHPMobspIssueOrder`)؛
2. گردش‌کار تأیید (مسیر مستندشده در این نقطهٔ کنترل): `VerificationWorkFlowController.VerifyRequest` → `MobspVerificationRequestVerify` (تعریف موجود: `ideal-write-audit-third-definitions.txt:35224+` — خواندن `WSVerificationWorkFlows` برای ObjectType و `CrmsysRolls` برای سقف تخفیف نقش، سپس برشی بر اساس ObjectType=10 پیش‌سفارش و ...)؛
3. تأیید مستقیم: `OrderController.OrderVerify` (خط 212) → `MobspOrderVerifyWithPreChecks` (خط 261)؛
4. خروج از تأیید: `OrderVerifyExit` (خط 403) → `MobspOrderVerifyExit` + `MobScorespDeleteOrderScores` (خطوط 451-452)؛
5. اصلاح پس از تثبیت: `VerificationWorkFlowController.EditObject*` → `MobspUpdateOrderEditAfterFixInfoJs` و همتایان (خطوط 2802-2829)؛ اصلاح اصلی: `UpdateController.Order` → `MobspUpdateOrder`؛
6. عملیات پس از تأیید: امتیاز (`MobScorespInsertAndCalcOrderScores` — خط 284)، ارجاع انبار/سند (`MobspInsertDocFull` — `WareHouseController.cs:776`)، پیامک (`MobspSendSmsOrdFOLinkAfterVerify` — خط 328)، پیام داخلی (`SendInternalmsgSingle` در PreOrder مسیر گردش‌کار) و PushNotif؛
7. حذف: `DeleteController.Order/PreOrder` → با گارد `actDelete` و سپس `MobspDeleteWSOrder/MobspDeleteWSPreOrder` فقط با شناسهٔ رکورد.

یافته‌های این فاز:

- **WF-01 — گارد وضعیت در UPDATE تأیید:** در `MobspOrderVerifyWithPreChecks` (تعریف مالک، رکورد ۱)، UPDATE نهایی `SET ordIsVerified = 1, ordVerifierId = @VerifierUserId, ordIsFixed = 1, ... WHERE OrderID = @OrderId` است — **پیش‌شرط وضعیت (مثل `AND ordIsFixed = 0`) در WHERE وجود ندارد**؛ تأیید تکراری رکوردِ ازپیش‌تأییدشده بدون گارد اجرا می‌شود — **Confirmed Static Finding** (نبود گارد در UPDATE) + **Potential Risk** (اثر تجاری re-verify)؛
- **WF-02 — نبود Idempotency:** در هیچ‌یک از مسیرهای Insert/Update/Verify هیچ کلید Idempotency (شناسهٔ درخواست کلاینت/Dedup) مشاهده نشد؛ تکرار درخواست = تکرار اثر — **Potential Risk** (ادغام با §۳.۴)؛
- **WF-03 — عدم بازگردانی اثرات جانبی در Exit:** خروج از تأیید وضعیت و امتیاز را معکوس می‌کند (`MobspOrderVerifyExit` + `MobScorespDeleteOrderScores`) اما اثری برای بازگردانی پیام‌های داخلی/اعلان‌های صادرشده در زمان تأیید مشاهده نشد — **Potential Risk**؛
- **WF-04 — عدم اتمیسیتهٔ زنجیرهٔ تأیید:** فراخوانی‌های «تأیید + امتیاز + پیامک/پیام» در Controller و در چند اتصال/تراکنش جداگانه انجام می‌شوند (ترتیب در `OrderController.cs:261-330`)؛ خطای مرحلهٔ بعدی، تأیید را بازنمی‌گرداند — **Confirmed Static Finding** (ترتیب فراخوانی) + **Potential Risk**.

---

## ۲۳. فاز ماتریس دسترسی نقش‌ها

آنچه به‌صورت ایستا قابل استخراج بود:

- **مدل دادهٔ مجوز (از SQL موجود):** `UsersPermission(UserId, RollId, PrjId)` — نقش کاربر به‌ازای پروژه (PrjId=11 برای CRM)؛ `CrmsysRollPermission(FormId, FormActionId, RollId)`؛ `CrmsysForms(FormName)`؛ `CrmsysFormActions(ActionName, FormId)`؛ `CrmsysRolls(LimitOrderDiscountActive/Percent, LimitPreOrderDiscountActive/Percent)` — سقف تخفیف به نقش؛
- **اسکلت ماتریس:** ۱۴۸ جفت یکتای `(FormName, ActionName)` از کل کد Mobile استخراج شد (همهٔ فراخوانی‌های `IsUserAccess`). نمونه‌های Write-محور: `frmOrder/actVerifyOrder`، `frmPreOrder/actVerifyPreOrder`، `frmOrder|frmPreOrder/actDelete`، `frmCompanyI/actDelete + actDeleteAllCmp*WithDep`، `frmCompanyI/actprsDelete`، `frmCompanyI/actcnvsDelete`، `frmDoc|frmDraft|frmWareHouseMovement/actVerifyDoc|actVerifyDraft|actDeleteDoc*|actDeleteItemSerial|actIsFixed|actExitFromIsFix`، `frmBuyOrder/actVerifyOrder`، `frmSendLetters/actVerifyLetter`، `frmProjectPreview/actDelete`، `frmOrder|frmPreOrder/actRemoveProduct|actDeletePay`، `frmCompanyI/actNotCanEditNoReferUserCmp`؛
- **تفکیک اولیه (بر اساس نام و دامنه):** عملیات مدیریتی — حذف‌های WithDependencies، تغییر CIds شرکت/شخص، عملیات گروهی TypeId=30، صدور سند و تبدیل خرید/فروش (بخش‌های ۶-۹)؛ عملیات کاربری — ثبت/اصلاح سفارش، پیش‌سفارش و مکالمه؛ عملیات نماینده-محور — `actNotCanEditNoReferUserCmp` و کنترل `CrmLinkedUsers` (ORD-01)؛
- **پاسخ به «آیا مجوز فرم با مالکیت داده اشتباه گرفته شده؟»** — در سطح الگو بله؛ مستند در AUTH-03 و بخش‌های ۵.۴/۱۰/۱۳: مجوز Form/Action عملاً تنها لایهٔ بررسی در اکثر مسیرهاست؛
- **مرز صادقانه:** نگاشت واقعی نقش→مجوز «داده» است نه کد (جداول `UsersPermission`/`CrmsysRolls`/`CrmsysRollPermission`)؛ خواندن این جداول در Allowlist فعلی IdealBridge ممنوع است (§۳ سند Allowlist) و در هیچ استخراج فعلی نیز نیست. تکمیل ماتریس **Runtime Verification Pending** است و نیازمند SELECT فقط-خواندنی مالک روی سه جدول فوق + `CrmsysForms`/`CrmsysFormActions` است (پیشنهاد: افزودن به اسکریپت استخراج بعدی به انتخاب مالک — این جداول در Allowlist سرویس نیستند و استخراجشان تصمیم مالک است).

---

## ۲۴. فاز همسان‌سازی IdealBridge (مستندات ↔ کد)

بازبینی سه‌گانهٔ `03-endpoints.md` + `11-swagger.md` + `IDEAL_SECURITY_ALLOWLIST.md` در برابر سورس `ideal/IdealBridge/src/`:

- همهٔ endpointهای مستندشده پیاده‌سازی و فعال‌اند: `companies` (لیست/`{id}`/`{id}/addresses`)، `persons` (لیست/`{id}`)، `users` (لیست/`{id}`)، `conversations`، `projects`، `reminders`، `baseinfo/{kind}`، `warehouses`، `products`، `orders`، `preorders`، `sync` (companies/persons/conversations)، `health` (live/db)، `admin/connection`، `tokens` (POST/GET/DELETE با `X-Admin-Key`) — شواهد: `src/IdealBridge.Api/Controllers/*.cs` (۷ کنترلر)؛
- **هیچ endpoint نوشتنی روی دادهٔ تجاری وجود ندارد** — تنها نوشتن‌ها: مدیریت توکن خود پل؛ سازگار با سیاست فقط-SELECT (§۱ Allowlist) و `ReadOnlyCommandGuard` (`src/IdealBridge.Infrastructure/Database/ReadOnlyCommandGuard.cs:34`)؛
- مغایرت مستند↔کد یافت نشد؛
- نکتهٔ مستندشدهٔ مهم (§۷ Allowlist): IdealBridge سلسله‌مراتب دید کاربران Ideal (`CrmCompanyForbidden*`/`CrmCompanyJustAccess*`) را اعمال نمی‌کند و توکن MedPad دید کامل مدیریت دارد — تصمیم آگاهانهٔ فاز ۱ و مستند؛
- پیوند با ممیزی Write: هرگونه فعال‌سازی Write در IdealBridge مستلزم عبور از اصول §۱۴ و اولویت‌های §۱۵ این سند است و با Allowlist فعلی در تعارض خواهد بود؛ چنان تعارضی باید با تغییر صریحِ سیاست حل شود، نه بی‌سروصدا.

---

## ۲۵. مرز معماری MedPad ↔ IdealBridge — رفع ابهام بخش ۱۴.۱

شواهد مخزن:

- معماری واقعی و پیاده‌شده (`ideal/IdealBridge/docs/02-architecture.md` بخش ۱): `Ideal CRM (SQL Server، نسخهٔ 3.1.16) ← فقط-SELECT ← IdealBridge API (این پروژه) ← HTTPS+Token ← MedPad Integration Service (خارج از این مأموریت) ← MedPad Database (مستقل)`؛
- `ideal/IdealBridge/docs/10-sync-design.md`: MedPad داده را از IdealBridge «دریافت» و در دیتابیس مستقل خود ذخیره می‌کند؛ پیاده‌سازی سمت MedPad در «MedPad Integration Service» و خارج از دامنه است؛
- عبارت‌های «MedPad Backend API» و «Adapter Holoo» **فقط** در همین سند (§۱۴.۱) و `WORKLOG.md` همان نقطهٔ کنترل ظاهر می‌شوند؛ هیچ کد، سند طراحی یا پروژهٔ دیگری در مخزن برای یک «MedPad Backend API» چند-Adapterی وجود ندارد و در کد IdealBridge هیچ Adapter و هیچ ارجاع Holoo نیست.

نتیجه‌گیری (صرفاً مستندسازی ابهام — بدون هیچ تغییر کد/معماری):

- دیاگرام §۱۴.۱ **آمیزهٔ دو سطح متفاوت** است: (۱) IdealBridge موجود — پل فقط-خواندنی با معماری چهار-جزئیِ مستند در 02-architecture؛ (۲) معماری هدفِ آینده برای Backend نوشتنی MedPad (با Adapterهای Ideal/Holoo، Audit، Idempotency) که هنوز هیچ مصنوع مخزنی جز همین سند ندارد؛
- پیشنهاد (نه تغییر): در بازنگری بعدی §۱۴.۱، دیاگرام به «معماری هدفِ Backend آیندهٔ MedPad (Design-only)» برچسب بخورد و کنار آن به معماری پیاده‌شدهٔ IdealBridge (02-architecture) ارجاع شود؛ IdealBridge فعلی جایگاه «پل خواندنی» را حفظ می‌کند و Backend نوشتنی آینده پروژه‌ای جدید با اصول همین سند خواهد بود؛ دو پروژه در یک دیاگرام ادغام نشوند؛
- رابطهٔ دو پروژه در صورت تصویب Backend مشترک: IdealBridge منبع خواندنی باقی می‌ماند و «Adapter Ideal» در Backend جدید، قراردادهای Write را مطابق مشخصات همین ممیزی پیاده می‌کند؛ این تصمیم محصولی است و نیازمند تأیید مالک.

---

## ۲۶. Continuation State — وضعیت ادامه (۲۰۲۶-۱۱-۱۹، پس از Checkpoint `9033b94`)

این بخش وضعیت کار را برای ادامهٔ تحقیقات در چت بعدی ثبت می‌کند (خواستهٔ بخش پنجم مأموریت). مبنای شروع چت بعدی: شاخهٔ `ideal` در کامیت همین نقطهٔ کنترل + همین سند.

### ۲۶.۱ آخرین فاز تکمیل‌شده

- تکمیل یافته‌های AUTH (بخش ۱۷: AUTH-01 تا AUTH-09)؛
- تکمیل جزئیات Order/PreOrder (بخش ۱۸: ORD-01 تا ORD-04)؛
- تعیین‌تکلیف موارد باز پیوست ب و بندهای ۱-۲ بخش ۱۶ (بخش ۱۹)؛
- فاز **AUTH-CENTER-02** — ممیزی جامع CenterId (بخش ۲۰)؛
- فاز **Caller Mapping** (بخش ۲۱)؛
- فاز **Workflow و Idempotency** (بخش ۲۲: WF-01 تا WF-04)؛
- فاز **ماتریس دسترسی نقش‌ها** — تا مرز شواهد ایستا (بخش ۲۳)؛
- فاز **همسان‌سازی IdealBridge** (بخش ۲۴)؛
- بررسی **مرز معماری MedPad/IdealBridge** (بخش ۲۵)؛
- ایجاد اسکریپت استخراج فقط-خواندنی پنجم: `ideal/ideal-write-audit-fifth-pending-sp.sql`.

### ۲۶.۲ فایل‌های بررسی‌شده در این مرحله (شواهد)

- `project-analysis/decompiled/Mobile/Mobile/Cache/User/Permissions.cs` و `Info.cs`؛
- `project-analysis/decompiled/Mobile/Mobile/Classes/UserLogin.cs`، `Helper/User.cs`، `Helper/Common.cs`، `Helper/FoCommon.cs`، `MobileAuthorizeAttribute.cs`؛
- `project-analysis/decompiled/Mobile/Mobile/Controllers/`: `AccountController.cs`، `CRMShopAccountController.cs`، `OrderController.cs`، `PreOrderController.cs`، `UpdateController.cs`، `VerificationWorkFlowController.cs`، `BuyOrderController.cs`، `WareHouseController.cs`، `DeleteController.cs`، `InsertQuickController.cs`، `PermissionController.cs`؛
- `project-analysis/decompiled/Mobile/Mobile/Models/`: `MyLogin.cs`، `CmpAuthenticationByMobileModel.cs`، `InsertOrderFullViewModel.cs`، `UpdateOrderViewModel.cs`، `UpdatePreOrderViewModel.cs`، `UpdateOrderItemViewModel.cs`، `CRMSpEntities.cs`؛
- `project-analysis/decompiled/Mobile/`: `Models.Mob.ssdl`، `Models.MobI.ssdl`، `Models.MobI.csdl`، `Models.MobI.msl`؛
- `project-analysis/decompiled/CRMIdeal/CRMIdeal/`: `Areas/Accounts/Controllers/AccountsController.cs`، `Classes/Helper/User.cs`، `Cache/User/Info.cs`؛
- `project-analysis/decompiled/Models/CRMSpII.ssdl`؛
- `ideal/order-preorder-procedure-parameters.txt`، `ideal/order-preorder-procedure-definitions.txt`، `ideal/order-preorder-procedure-parameters - Copy.txt` (تحلیل عمیق هر ۴ رکورد)؛
- `ideal/ideal-write-audit-third-definitions.txt` (تعاریف `MobspCheckActionForUser`، `MobspVerificationRequestVerify`، `MobspDeleteWSOrder` و وابستگی‌های `MobspSingleCrmConversationPreChecks`)، `ideal/ideal-write-audit-fourth-part-1/8/10.txt` (فراخوانی‌های PreChecks)؛
- `ideal/IdealBridge/src/IdealBridge.Api/Controllers/*.cs` + `docs/03-endpoints.md`، `docs/11-swagger.md`، `docs/IDEAL_SECURITY_ALLOWLIST.md`، `docs/02-architecture.md`، `docs/10-sync-design.md`.

### ۲۶.۳ یافته‌های جدید این مرحله

`AUTH-01` تا `AUTH-09` (بخش ۱۷)، `ORD-01` تا `ORD-04` (بخش ۱۸)، `WF-01` تا `WF-04` (بخش ۲۲)، حل موارد ۲ و ۳ پیوست ب (بخش ۱۹)، ماتریس CenterId ۲۴ مسیره (بخش ۲۰)، آمار Caller Mapping (بخش ۲۱)، و رفع ابهام معماری §۱۴.۱ (بخش ۲۵). مهم‌ترین مورد از نظر شدت: **AUTH-08** (صدور توکن از ورودی خام بدون احراز هویت + بازنویسی Cache کاربر دیگر — P0 در صورت دسترس‌پذیری استقرار).

### ۲۶.۴ فایل‌ها و SPهای بررسی‌نشده / ناتمام

- **۱۱۱ SP خانوادهٔ Write بدون تعریف SQL** (فهرست کامل در اسکریپت پنجم) — از جمله `MobspUpdateOrderItem`، `MobspUpdatePreOrderItem`، `MobspInsertOrderFull`، `SHPMobspIssueOrder`، `MobspUpdate*EditAfterFixInfoJs`؛
- `MobspSingleCrmConversationPreChecks` (تعریف؛ قرارداد فراخوانی مستند شد — §۱۹.۲)؛
- `MobspSelectUserRollPermission`، `MobspSelectCentersWithIds`، `MobspLoadUserLoginInfo`، `CRMspUpdateUserLastCId`، `MobspSelectOrderWithID`، `MobspSelectPreOrderWithID` (بدون این‌ها اثر CenterId در SPهای مجوز/دیتا قابل قطعیت نیست)؛
- تعریف واقعی چهار SP اختلاف قرارداد AUTH-09 در دیتابیس عملیاتی؛
- Controllerهای کمتر پرریسک که فقط در سطح شمارش Caller Mapping آمدند (FO*/HRM*/Ticket/DyForms و ...) — ممیزی عمیق endpoint-به-endpoint آن‌ها انجام نشده؛
- فایل `IDEAL-API-SECURITY-AUDIT-HANDOFF` (که هرگز push نشد) — مقایسهٔ انجام‌شده در این نقطهٔ کنترل: یافته‌های Write آن (F-017 تا F-032) هم‌ارزِ محتوای بخش‌های ۳ تا ۱۳ همین سند است و اطلاعات جدیدی ندارد؛ یافته‌های خواندنی آن (F-001 تا F-016) موضوع اسناد ممیزی خواندنی است (پیوست الف) و در این سند تکرار نمی‌شود؛ نیازمند اقدام نیست مگر اینکه مالک آن را push کند.

### ۲۶.۵ موارد نیازمند دیتابیس واقعی (همگی فقط-خواندنی)

1. اجرای `ideal/ideal-write-audit-fifth-pending-sp.sql` توسط مالک و push خروجی (تعریف + امضای ۱۲۳ هدف)؛ هیچ SP اجرا نشود؛
2. تعیین امضای واقعی چهار SP اختلاف قرارداد (AUTH-09) و نتیجه‌گیری نسخهٔ دیتابیس در برابر بیلد دیکامپایل‌شده؛
3. در صورت تصمیم مالک: SELECT فقط-خواندنی روی `UsersPermission`/`CrmsysRolls`/`CrmsysRollPermission`/`CrmsysForms`/`CrmsysFormActions` برای تکمیل ماتریس نقش‌ها (بخش ۲۳)؛
4. تعیین دسترس‌پذیری استقراری endpointهای AUTH-08 (آیا `CmpAuthenticationByMobNum` در استقرار عمومی فعال است).

### ۲۶.۶ فاز بعدی دقیق

**فاز پنجم — تحلیل خروجی اسکریپت استخراج (پس از اجرای مالک):**

1. تحلیل تعاریف `MobspUpdateOrderItem`/`MobspUpdatePreOrderItem` (تکمیل §۱۳) و `MobspSingleCrmConversationPreChecks`؛
2. تعیین‌تکلیف AUTH-09 (چهار SP) و AUTH-01 (`MobspSelectUserRollPermission`) و AUTH-06 (`MobspSelectCentersWithIds`) با امضاهای واقعی؛
3. ممیزی SQL مالکیت `MobspInsertOrderFull` و `SHPMobspIssueOrder` (تکمیل ORD-03)؛
4. تکمیل ممیزی SPهای ۱۱۱گانه بر اساس اولویت: Verify → Update → Delete → Insert؛
5. سپس: تکمیل ماتریس نقش‌ها با دادهٔ واقعی (در صورت تجویز مالک) و به‌روزرسانی بخش ۲۳؛
6. سپس: بازبینی §۱۴.۱ بر اساس جمع‌بندی بخش ۲۵ (تفکیک برچسب دیاگرام) با تأیید مالک؛
7. در پایان: تدوین «مشخصات قابل پیاده‌سازی API جدید» از دل همین سند (هدف نهایی مأموریت) — تا پیش از آن هیچ پیاده‌سازی آغاز نشود.

---

## ۲۷. Next Chat Instructions — دستورالعمل چت بعدی

برای ادامهٔ تحقیقات در چت جدید، این سند را با لینک مستقیم به همین فایل (`ideal/IdealBridge/docs/IDEAL_WRITE_API_SECURITY_AUDIT.md` روی شاخهٔ `ideal`) ارائه کنید و متن زیر را کپی کنید:

---

**مأموریت ادامهٔ ممیزی Write ایده‌آل (پس از نقطهٔ کنترل دوم):**

مخزن `P3D4AM/Rasta`، شاخهٔ `ideal`. سند مرجع: `ideal/IdealBridge/docs/IDEAL_WRITE_API_SECURITY_AUDIT.md`. قبل از هر کاری: (۱) `git fetch` و آخرین وضعیت شاخه؛ (۲) خواندن کامل بخش‌های ۲۶ (Continuation State) و ۲۷ همین سند؛ (۳) خواندن بخش ۰ (وضعیت‌ها) و رعایت همان قواعد شواهد.

قواعد ثابت (از مأموریت‌های قبل، همچنان الزامی): فقط مستندسازی؛ هیچ SQL نوشتنی/کد عملیاتی/دیتابیس/تنظیمات تغییر نکند؛ هیچ SP اجرا نشود؛ استخراج دیتابیس فقط با اسکریپت فقط-خواندنی موجود (`ideal/ideal-write-audit-fifth-pending-sp.sql`) توسط مالک؛ یافته‌ها با وضعیت‌های پنج‌گانهٔ بخش ۰ و شواهد فایل/خط؛ شماره‌گذاری یکتا (ادامه از آخرین شناسهٔ هر سری: AUTH-09، ORD-04، WF-04)؛ بخش‌های موجود حذف/بازنویسی نشوند؛ تغییرات فقط در فایل‌های مستنداتی؛ commit روی `ideal` بدون force-push.

وضعیت ورودی: اگر مالک خروجی اسکریپت پنجم را push کرده باشد → فاز ۲۶.۶-بند ۱ تا ۴ را اجرا کن. اگر نه → قبل از آن، این کارهای بدون دیتابیس را انجام بده: (الف) ممیزی عمیق endpoint-به-endpoint Controllerهای بررسی‌نشدهٔ فهرست ۲۶.۴ (FO*/HRM*/Ticket/DyForms) با همان قالب ماتریس بخش ۲۰؛ (ب) تکمیل نگاشت مسیرهای غیرمستقیم SP→SP از فرادادهٔ وابستگی استخراج چهارم؛ (ج) تدوین پیش‌نویس «مشخصات قابل پیاده‌سازی API جدید» (قراردادها، DTO حداقلی، لایه‌های مجوز چهارگانهٔ AUTH-03، Idempotency/Audit) به‌عنوان بخش جدید سند؛ در هر حالت پس از اتمام، بخش ۲۶ را به‌روزرسانی و این بخش را بازنویسی کن.

پس از هر مرحله: Diff را بازبینی کن، فقط فایل‌های مستنداتی مرتبط را commit/push کن، SHA و لینک مستقیم گزارش را اعلام کن.

---

## فاز ۱۳ — ممیزی Schema و سازگاری Queryهای IdealBridge برای MedPad

> **تاریخ ثبت:** ۲۰۲۶-۱۱-۲۱ · **SHA مبنای بررسی:** `9812159dc408a066a6b6a517a8421673b3ccd22e` (HEAD شاخهٔ `ideal` در زمان ثبت؛ راستی‌آزمایی مستقل این فاز روی همین SHA انجام شد)
> **ماهیت:** نخستین فاز برنامهٔ «تکمیل API اتصال Ideal CRM به MedPad» — ثبت و راستی‌آزمایی یافته‌های ممیزی Schema و سازگاری Queryهای IdealBridge در سند مرجع. **این فاز صرفاً مستندسازی است: هیچ سورس کد، SQL، DTO، تنظیمات یا تستی تغییر نکرد و هیچ کوئری‌ای روی دیتابیس زنده اجرا نشد.**
> **تفاوت دامنه با بخش‌های ۱ تا ۲۷:** بخش‌های قبلی این سند، سورس قدیمی (`Mobile.dll` دیکامپایل‌شده) و SPهای خانوادهٔ Write را ممیزی کردند. این فاز برای نخستین بار **پیاده‌سازی جدید IdealBridge خودِ مخزن** (متن SQL مخازن، دیکشنری تولید SQL در زمان اجرا و SchemaProbe) را در برابر اسکیمای مرجع ممیزی و ثبت می‌کند — ادامهٔ مسیر فاز ۲۴ (بخش ۲۴) که فقط «مستندات ↔ کد» را سنجید، نه «کد ↔ دیتابیس».
> **برچسب‌های وضعیت این فاز (چهارگانهٔ برنامهٔ تکمیل API):** `CONFIRMED_STATIC` = تأیید ایستا در سورس/SSDL (هم‌ارز «Confirmed Static Finding» بخش ۰) · `UNVERIFIED_LIVE` = نیازمند تأیید روی نصب واقعی (هم‌ارز «Runtime Verification Pending» بخش ۰) · `POTENTIAL` = ریسک محتمل بدون حلقهٔ نهایی شواهد (هم‌ارز «Potential Risk» بخش ۰) · `FIXED_AND_TESTED` = اصلاح‌شده همراه با تست قفل‌کننده (**هیچ یافتهٔ این فاز این وضعیت را ندارد — هیچ اصلاحی انجام نشد**).
> **سری شناسه‌های جدید:** `SCH-01` تا `SCH-07` (Schema). در زمان ثبت، هیچ شناسهٔ `SCH-` در این سند وجود نداشت؛ سری‌های قبلی (AUTH/ORD/WF) به سورس قدیمی مربوط‌اند و بازنویسی نشدند.

### ۱۳.۱ منشأ کشف، روش و منابع این فاز

- **منشأ کشف:** ممیزی ایستای فاز ۱۲ (`ideal/IdealBridge/docs/IDEAL_SCHEMA_AUDIT.md` — یافته‌های §۲/§۳/§۴/§۵ آن) و رده‌بندی چهارسطحی فاز ۱۲.۵ (`ideal/IdealBridge/docs/IDEAL_QUERY_COMPATIBILITY_REPORT.md`). آن اسناد مرجع جزئیات فنی‌اند و محتوایشان اینجا حذف یا خلاصه نشد؛ این بخش، ثبت رسمی همان یافته‌ها در سند مرجع Write است.
- **راستی‌آزمایی مستقل این فاز:** هیچ یافته‌ای صرفاً به دلیل ثبت در سند قبلی، اصلاح‌شده یا تأییدشده فرض نشد. همهٔ ادعاها مجدداً روی کد در SHA مبنا بررسی شد: (۱) تطبیق ماشینی همهٔ نام‌های ادعاشده با `CRMTabel.ssdl` نسخهٔ 3.1.18.187 (`project-analysis/decompiled/Models/CRMTabel.ssdl` — ۶۳۳ EntityType) — نتیجه: ۴۸/۴۸ ادعای نام (وجود نام صحیح / عدم وجود نام غلط) سبز؛ (۲) بیرون‌کشی شمارهٔ خط دقیق همهٔ نام‌ها از سورس IdealBridge در همان SHA.
- **مرجع ایستا:** SSDL نسخهٔ 3.1.18.187 + شواهد فاز ۱۲ مبنی بر اینکه نام‌های غلط در متن کامل ۳۶۱MB دستورات نصاب (کاتالوگ V1→V8) هیچ‌گاه به‌عنوان نام واقعی جدول/ستون ظاهر نشده‌اند.
- **محدودیت اصلی شواهد:** گزارش زندهٔ `ideal-live-schema-report.json` هنوز تولید و بررسی نشده است (بند ۱۳.۷ / SCH-07).

### ۱۳.۲ SCH-01 — مغایرت نام جدول/ستون در Queryهای فعلی و دیکشنری تولید SQL در `BaseInfoRepository.Map` (CONFIRMED_STATIC)

۱۹ مغایرت یکتای نام جدول/ستون، هم در Queryهای literal مخازن و هم در دیکشنری تولید SQL زمان اجرا (`BaseInfoRepository.Map`) دیده می‌شوند و بر اساس ممیزی ایستای SSDL نسخهٔ 3.1.18.187 مغایرند. چون نام‌های غلط در هیچ نسخه‌ای از Ideal وجود نداشته‌اند، هر ۱۹ مورد در **هر** دیتابیسی — از جمله نصب 3.1.16 و 3.1.18 — به `SqlException` (Invalid column/table name) در زمان اجرا می‌شکنند؛ یعنی این رده به راستی‌آزمایی زنده وابسته نیست، هرچند مشاهدهٔ عملی شکست هنوز انجام نشده (اتصال زنده مسدود است).

قرارداد مسیرها: `Repositories.cs` = `ideal/IdealBridge/src/IdealBridge.Infrastructure/Repositories/Repositories.cs` · `CompanyRepository.cs` = همان پوشه · `SSDL` = `project-analysis/decompiled/Models/CRMTabel.ssdl` (شمارهٔ خط = خطِ `<EntityType>` مربوط). ستون «Map» یعنی همان نام غلط در دیکشنری `BaseInfoRepository.Map` (Repositories.cs:703-728) هم ظاهر می‌شود.

| # | بخش | نام فعلی (غلط) | محل در سورس | نام صحیح (ممیزی SSDL 187) | شاهد SSDL |
|---|---|---|---|---|---|
| ۱ | Person | `dbo.CrmPersonJob` (جدول JOIN) | Repositories.cs:34 | `dbo.CrmPersonJobs` | SSDL:6186 |
| ۲ | Person | `J.JobID` (شرط JOIN) | Repositories.cs:34 | `J.PersonJobID` | SSDL:6188-6190 |
| ۳ | Person | `J.Job` | Repositories.cs:20 (+Map:716) | `J.Jobs` | SSDL:6191 |
| ۴ | Person | `PG.GroupName` | Repositories.cs:21 (+Map:718) | `PG.PersonGroup` | SSDL:6159 |
| ۵ | Person | `SX.Sex` | Repositories.cs:21 (+Map:720) | `SX.SexType` | SSDL:9411 |
| ۶ | Person | `DP.DepartmentID` (شرط JOIN) | Repositories.cs:39 (+Map:717) | `DP.PersonDepartmentId` | SSDL:6132 |
| ۷ | Person | `DP.Department` | Repositories.cs:22 (+Map:717) | `DP.PersonDepartment` | SSDL:6132 |
| ۸ | Conversation | `T.TopicName` | Repositories.cs:231 | `T.Topic` | SSDL:3186 |
| ۹ | Conversation | `T.TopicID` (شرط JOIN) | Repositories.cs:240 | `T.ConversationTopicsID` | SSDL:3186 |
| ۱۰ | Conversation | `S.ConversationStatus` | Repositories.cs:234 | `S.Status` | SSDL:2946 |
| ۱۱ | Project | `G.GradeName` | Repositories.cs:324 (+Map:726) | `G.ProjectGrade` | SSDL:6399 |
| ۱۲ | Project | `PG.GroupName` | Repositories.cs:324 (+Map:725) | `PG.ProjectGroup` | SSDL:6426 |
| ۱۳ | Reminder | `PR.PriorityName` | Repositories.cs:399 | `PR.Priority` | SSDL:8110 |
| ۱۴ | Reminder | `G.GroupName` | Repositories.cs:400 | `G.UserTaskGroup` | SSDL:8083 |
| ۱۵ | Product | `dbo.WSProductUnit` (جدول JOIN) | Repositories.cs:519 | `dbo.WSProductUnits` | SSDL:14720 |
| ۱۶ | Product | `UN.UnitName` | Repositories.cs:512 | `UN.Unit` | SSDL:14720 |
| ۱۷ | Product | `G.GroupName` | Repositories.cs:511 | `G.FGName` | SSDL:13695 |
| ۱۸ | Product | `G.ProductFirstGroupID` (شرط JOIN) | Repositories.cs:517 | `G.PrdFirstGroupID` | SSDL:13695 |
| ۱۹ | Company Address | `T.CompanyAddressType` (ستون نام) | CompanyRepository.cs:132 (+Map:713) | `T.CompanyAddressTypeName` | SSDL:1213 |

نکات تکمیلی:

- **دیکشنری Map (SQL تولیدی runtime):** هفت kind از `BaseInfoRepository.Map` درگیرند: `PersonJob` (Repositories.cs:716 — هر سه مؤلفه table/id/name غلط)، `PersonDepartment` (۷۱۷)، `PersonGroup` (۷۱۸)، `Sex` (۷۲۰)، `ProjectGroup` (۷۲۵)، `ProjectGrade` (۷۲۶)، `CompanyAddressType` (۷۱۳) — یعنی علاوه بر endpointهای دادهٔ اصلی، endpointهای BaseInfo هم درگیر شکست‌اند.
- **اثر شکست به تفکیک endpoint (بر اساس JOINها):** persons (ردیف‌های ۱-۷)، baseinfo (شخص/شغل/واحد سازمانی/گروه/جنسیت/گروه و درجهٔ پروژه/نوع آدرس)، conversations (۸-۱۰)، projects (۱۱-۱۲)، reminders (۱۳-۱۴)، products (۱۵-۱۸)، آدرس‌های شرکت (۱۹). مجموعهٔ این ۱۹ مورد با فهرست §۲ سند `IDEAL_SCHEMA_AUDIT.md` منطبق است (ترتیب ردیف‌ها در اینجا دامنه‌محور است و با ترتیب آن سند تفاوت دارد؛ نگاشت یک‌به‌یک با شماره‌گذاری آن سند در §۱۳.۹ ثبت نشد و برای ارجاع باید از «نام» استفاده شد نه شماره).
- **نکتهٔ ردیف ۱۹:** کلید JOIN در CompanyRepository.cs:137 (`T.CompanyAddressTypeID`) با PK جدول (`CompanyAddressTypeId` — SSDL:1213) تطبیق می‌کند (case-insensitive)؛ فقط ستون نام غلط است. ردیف‌های ۱/۱۵ برعکس، خطای «جدول» هستند (شکست پیش از ارزیابی ستون‌ها).
- **وضعیت:** `CONFIRMED_STATIC` (نسبت به SSDL187 و متن کامل نصاب). مشاهدهٔ عملی روی دیتابیس واقعی: `UNVERIFIED_LIVE` — اما طبق شواهد فاز ۱۲ نتیجه در هر نسخه یکسان است.
- **ارتباط با یافته‌های قبلی سند:** مستقل از سری‌های AUTH/ORD/WF (سورس قدیمی)؛ نزدیک‌ترین زمینهٔ قبلی بخش ۲۴ (همسان‌سازی IdealBridge) است که فقط انطباق مستندات↔کد را بررسی کرده بود — اینجا لایهٔ سوم (کد↔دیتابیس) ممیزی و نقص‌نگاری شد.

### ۱۳.۳ SCH-02 — ستون‌های استفاده‌شده در Queryها بدون پوشش `SchemaProbe.RequiredTableColumns` (CONFIRMED_STATIC)

هفت ستون در SELECTهای فعال مصرف می‌شوند اما در فهرست `SchemaProbe.RequiredTableColumns` (`ideal/IdealBridge/src/IdealBridge.Infrastructure/Database/SchemaProbe.cs:21-34`) نیستند؛ در نتیجه سازوکار «کاوش زودهنگام → Block با پیام 503 تمیز» (`DataAccessPolicy.ApplySchemaReport` — `DataAccessPolicy.cs:89-102`: جدول مفقود → «جدول «X» در دیتابیس Ideal یافت نشد»؛ ستون مفقود → «ستون‌های لازم در «X» مفقودند: …»؛ سیم‌کابی در `Program.cs:143-147`) آن‌ها را پوشش نمی‌دهد و شکستشان در زمان اجرا به‌صورت `SqlException` خام ظاهر می‌شود، نه خطای کنترل‌شده و زودهنگام 503:

| ستون | مصرف در سورس (SHA مبنا) | غیاب در Probe | ردهٔ نسخه (فاز ۱۲ §۳) |
|---|---|---|---|
| `CrmConversation.cnvsIsTicket` | Repositories.cs:236 | در لیست CrmConversation (SchemaProbe.cs:26) نیست | ستون پایه — اما Probe ندارد |
| `CrmConversation.cnvsIsTicketNew` | Repositories.cs:236 | نیست (SchemaProbe.cs:26) | V7 — در 169 احتمالاً ناموجود |
| `CrmProjects.prjSubject` | Repositories.cs:321 | نیست (SchemaProbe.cs:27) | V6 — در 169 احتمالاً ناموجود |
| `CrmUserTasks.UserTaskRemindDate` | Repositories.cs:401 | نیست (SchemaProbe.cs:28 — فقط `UserTaskRemindDateTime` هست) | — |
| `CrmUserTasks.UserTaskRemindTime` | Repositories.cs:401 | نیست (SchemaProbe.cs:28) | — |
| `Users.UserIsActiveInMobApp` | Repositories.cs:147 | نیست (SchemaProbe.cs:25 — فقط `UserIsActiveInWebApp` هست) | — |
| `Users.UserIsActiveInWinApp` | Repositories.cs:147 | نیست (SchemaProbe.cs:25) | — |

وضعیت: `CONFIRMED_STATIC`. اثر عملی روی نصب فرضی 3.1.16.169 در صورت نبود ستون‌های V6/V7: `UNVERIFIED_LIVE` — اما جهت ریسک روشن است: conversations و projects (و به تبع آن reminders/users در ستون‌های خودشان) مستقیم SqlException خام می‌گیرند، در حالی که همان سازوکار برای ستون‌های Probeشده (نمونهٔ `WSPreOrder.pordChangeStatusDate` — V8) پیام تمیز 503 می‌دهد.

### ۱۳.۴ SCH-03 — نبود پوشش کامل و منسجم جدول‌های فرهنگ‌نامه (Lookup) در Probe (CONFIRMED_STATIC)

- فهرست Probe فقط ۱۱ جدول اصلی را پوشش می‌دهد (SchemaProbe.cs:23-33): CrmCompany، CrmCompanyPersons، Users، CrmConversation، CrmProjects، CrmUserTasks، WsWareHouse، WSProducts، WSOrder، WSPreOrder، CrmCompanyAddresses.
- **هیچ‌یک از جدول‌های فرهنگ‌نامه‌ای که در JOINهای Queryهای فعلی مصرف می‌شوند در Probe نیستند** (استخراج این فاز از متن Queryها در SHA مبنا): CrmPersonTitle، CrmPersonJobs، CrmPersonType، CrmPersonGroups، Sex، Education، CrmPersonDepartments، Country، Province، City (مسیر Person)؛ CrmConversationTopics، CrmConversationStatus (Conversation)؛ CrmProjectGrade، CrmProjectPriority، CrmProjectGroups (Project)؛ CrmUserTaskPriorities، CrmUserTaskGroups (Reminder)؛ WSProductFirstGroup، WSProductColor، WSProductUnits (Product)؛ CrmCompanyAddressType (آدرس‌ها)؛ WSOrderOpr (Order/PreOrder) — هم‌خوان با شمارش فاز ۱۲ §۴.۱: «تمام ۳۱ جدول فرهنگ‌نامه بدون هیچ پوشش Probe» (شامل جداول مسیرهای آینده مانند `WSPreOrderOpr`).
- پیامد: غیبت هر جدول lookup روی دیتابیس هدف → خطای خام SQL در زمان اجرا به‌جای خطای کنترل‌شده و زودهنگام 503؛ یعنی حتی پس از اصلاح کامل SCH-01، کلاس خطای «جدول فرهنگ مفقود» روی نصب‌های ناقص همچنان خام باقی می‌ماند.
- وضعیت: `CONFIRMED_STATIC` (هر دو فهرست — Probe و JOINهای Query — در SHA مبنا).

### ۱۳.۵ یافته‌های معنایی که هنوز قطعی نیستند

#### ۱۳.۵.۱ SCH-04 — رابطهٔ گروه محصول: `PrdGroupID` به گروه دوم اشاره دارد (POTENTIAL)

- شواهد ایستا: `WSProducts` (SSDL:14132) تنها یک ستون گروه به نام `PrdGroupID` دارد؛ دو جدول فرهنگی مستقل وجود دارند: `WSProductFirstGroup` (PK: `PrdFirstGroupID`؛ نام: `FGName` — SSDL:13695) و `WSProductSecondGroup` (PK: `PrdSecondGroupID`؛ ستون والد: `FirstGroupId`؛ نام: `SGName`). شاهد SP بومی `WSspSelectProductsByFSGId` (فاز ۱۲ §۵.۱) و ردیف `Product.Group` در `ideal/IdealBridge/docs/IDEAL_API_MAPPING.md`: مسیر صحیح `PrdGroupID → WSProductSecondGroup.PrdSecondGroupID` و سپس `SecondGroup.FirstGroupId → WSProductFirstGroup.PrdFirstGroupID`.
- کد فعلی: Repositories.cs:517 مقدار `PrdGroupID` را به `WSProductFirstGroup` JOIN می‌زند (با کلید ناموجود `ProductFirstGroupID` — SCH-01 ردیف ۱۸).
- نتیجهٔ ثبت‌شده: **اصلاح JOIN باید زنجیرهٔ گروه اول و دوم را درست مدل کند؛ صرفاً تغییر نام ستون به `PrdFirstGroupID` کافی نیست** — با اصلاحِ نام به‌تنهایی، Query از نظر شناسه‌ها معتبر می‌شود اما از نظر معنایی، مقدارِ ID گروه دوم را با PK گروه اول تطبیق می‌دهد (JOIN بی‌نتیجهٔ گسترده یا تطبیق اشتباه). انتخاب «نمایش مستقیم گروه دوم» یا «زنجیرهٔ دوم→اول» یک تصمیم محصولی است که نیازمندی MedPad تعیین‌گر آن است.
- وضعیت: `POTENTIAL` (معناشناسی) + `UNVERIFIED_LIVE` (رفتار واقعی با دادهٔ زنده).

#### ۱۳.۵.۲ SCH-05 — فرهنگ عملیات پیش‌سفارش: فرهنگ مستقل `WSPreOrderOpr` (POTENTIAL)

- کد فعلی: Repositories.cs:659 — `WSPreOrder.PreOrderOprID` به `WSOrderOpr.OrderOprID` JOIN و نام عملیات از `OP.Name` خوانده می‌شود (Repositories.cs:651).
- شواهد ایستا: جدول فرهنگی مستقل `WSPreOrderOpr` (PK: `PreOrderOprID`؛ نام: `PreOrderOpr` — SSDL:13352) وجود دارد و ساختار ستون‌هایش با `WSOrderOpr` (SSDL:12549 — `OrderOprID, Name, GUId, OprType, …`) متفاوت است.
- ریسک: اگر IDهای دو فرهنگ هم‌پوشان اما متفاوت باشند، نام عملیات پیش‌سفارش غلط نمایش داده می‌شود (JOIN بی‌نتیجه یا تطبیق اشتباه). **تا بررسی ساختار و دادهٔ معتبر، این مورد خطای قطعی اعلام نمی‌شود** — این امکان نیز هست که دو فرهنگ در عمل هم‌مقدار باشند.
- وضعیت: `POTENTIAL` + `UNVERIFIED_LIVE` (راستی‌آزمایی فقط-خواندنی پیشنهادی: فرمان‌های §۱۰ سند `IDEAL_SCHEMA_AUDIT.md` — SELECT روی دو فرهنگ کوچک `WSOrderOpr`/`WSPreOrderOpr` روی دیتابیس مالک).

### ۱۳.۶ SCH-06 — شکاف تست: کنترل جامع مغایرت نام جدول/ستون SQL مخازن در برابر Schema مرجع وجود ندارد (CONFIRMED_STATIC)

- مجموعهٔ تست در SHA مبنا: ۱۲۶ شناسهٔ `[Fact]`/`[Theory]` در ۱۰ فایل (۹۳ Unit در `tests/IdealBridge.UnitTests/` + ۳۳ Integration در `tests/IdealBridge.IntegrationTests/IdealBridgeApiTests.cs`). هیچ‌یک متن SQL مخازن را با اسکیمای مرجع تطبیق نمی‌دهد.
- شواهد ساختاری شکاف:
  1. تست‌های یکپارچه با FakeDb اسکریپت‌شده کار می‌کنند (`tests/IdealBridge.IntegrationTests/FakeDb.cs`؛ ساخت در `IdealBridgeApiTests.cs:629/655`)؛ اجرای واقعی SQL روی SQL Server شبیه‌سازی نمی‌شود.
  2. خودارجاعی: در `IdealBridgeApiTests.cs:786-794`، فرادادهٔ ساختگی‌ای که به SchemaProbe برگردانده می‌شود **دقیقاً از خودِ `SchemaProbe.RequiredTableColumns`** ساخته می‌شود؛ جداول دادهٔ دستی (CompanyTable()/UsersTable()/…) نیز جداگانه و منطبق با نام‌های خودِ Query اسکریپت شده‌اند. در نتیجه هیچ مسیر تستی، شناسه‌های SQL مخازن را با منبعی مستقل (SSDL/گزارش زنده) مقایسه نمی‌کند.
  3. به همین دلیل هر ۱۹ مغایرت SCH-01 از کل مجموعهٔ تست فعلی عبور کرده‌اند (تأیید نقل فاز ۱۲: «تست‌ها با دیتابیس fake کار می‌کنند و اجرای واقعی SQL روی SQL Server را شبیه‌سازی نمی‌کنند»).
- راهکار پیشنهادی برای فاز اصلاح:
  1. تست رگرسیون تطبیق متن SQL مخازن با Schema مرجع (استخراج شناسه‌های جدول/ستون از SQLهای literal و تطبیق با SSDL187 و/یا گزارش زنده)؛
  2. پوشش Queryهای تولیدشده در `BaseInfoRepository` (اعتبارسنجی سه‌تایی table/id/name دیکشنری Map در برابر مرجع)؛
  3. پوشش جدول‌ها و ستون‌های JOINشده — نه فقط جدول اصلی هر Repository؛
  4. تست SchemaProbe برای همهٔ ستون‌های واقعاً استفاده‌شده (رفع خودارجاعی FakeDb — اسکیمای ساختگی باید از منبعی مستقل از خود Probe ساخته شود)؛
  5. تستی که اطمینان دهد نبود جدول یا ستون ضروری به خطای کنترل‌شدهٔ 503 منجر می‌شود، نه SqlException خام.
- وضعیت: `CONFIRMED_STATIC`.

### ۱۳.۷ SCH-07 — محدودیت شواهد: گزارش زندهٔ Schema هنوز بررسی نشده (UNVERIFIED_LIVE)

- `ideal-live-schema-report.json` در مخزن نیست (جست‌وجوی این فاز؛ هم‌راستا با پیوست ب بند ۵ همین سند) — ابزار `IdeaSchemaDump v3.0` آماده و منتشرشده است اما استخراج زنده توسط مالک انجام نشده (`ideal/IdealBridge/docs/IDEAL_LIVE_SCHEMA_AUDIT.md` §۲: «استخراج زنده: انجام‌نشده»).
- بنابراین در این فاز همهٔ شواهد اسکیما با برچسب منبع ایستا `[ایستا-SSDL187]` ثبت شدند؛ **وضعیت واقعی نصب Ideal نسخهٔ 3.1.16.169.0303 تأییدشده اعلام نمی‌شود** (این شمارهٔ نسخه از تحلیل فاز ۱۲ آمده و تأیید ساختاری‌اش بدون اتصال ممکن نیست).
- موارد نیازمند اتصال زنده (کارهای باز): اجرای گزارش Schema زنده روی دیتابیس مالک؛ راستی‌آزمایی ستون‌های V6/V7/V8 (§۱۳.۳)؛ تعیین‌تکلیف SCH-04/SCH-05 با دادهٔ واقعی. فرمان‌های فقط-خواندنی آماده در `IDEAL_SCHEMA_AUDIT.md` §۱۰.
- وضعیت: `UNVERIFIED_LIVE`.

### ۱۳.۸ جدول پیگیری — برنامهٔ تکمیل API (MedPad)

| # | مورد | وضعیت | شواهد | وابستگی | فاز هدف |
|---|---|---|---|---|---|
| ۱ | اصلاح نام‌های اشتباه SQL و BaseInfo (۱۹ مورد SCH-01) | باز — اصلاح نشده (`FIXED_AND_TESTED` نیست) | §۱۳.۲ (شمارهٔ خط Repositories.cs/CompanyRepository.cs/Map + شاهد SSDL) | ندارد (پایه) — پیشنهاد: یک commit کوچک بدون تغییر رفتار قراردادی | فاز اصلاح — P0 |
| ۲ | تکمیل `RequiredTableColumns` (۷ ستون SCH-02) | باز | §۱۳.۳ | همراه با مورد ۱ (تا فهرست با نام‌های صحیح قفل شود) | فاز اصلاح — P0 |
| ۳ | پوشش جدول‌های Lookup در Probe (SCH-03) | باز | §۱۳.۴ | فهرست lookup از SSDL/گزارش زنده | فاز اصلاح — P0/P1 |
| ۴ | افزودن تست رگرسیون Schema | باز | §۱۳.۶ | اسکیمای مرجع (SSDL187 و/یا گزارش زنده) | فاز اصلاح — P1 |
| ۵ | بررسی معنایی گروه محصولات (SCH-04) | باز — `POTENTIAL` | §۱۳.۵.۱ + ردیف `Product.Group` در `IDEAL_API_MAPPING.md` | تصمیم محصولی MedPad + دادهٔ زنده | فاز تحلیل — P2 |
| ۶ | بررسی فرهنگ عملیات پیش‌سفارش (SCH-05) | باز — `POTENTIAL` | §۱۳.۵.۲ + فرمان‌های §۱۰ سند ممیزی اسکیما | دادهٔ زنده (دو فرهنگ کوچک) | فاز تحلیل — P2 |
| ۷ | اجرای گزارش Schema زنده روی دیتابیس مالک | باز — اقدام مالک | §۱۳.۷ + `IDEAL_LIVE_SCHEMA_AUDIT.md` §۲ | مالک (ابزار v3.0 آماده/تست‌شده) | پیش‌نیاز نهایی‌سازی موارد ۲/۳/۴ |
| ۸ | بررسی مجدد Queryهای تمام Endpointها پس از اصلاح | باز | — | تکمیل موارد ۱-۴ (+ ۷ برای نسخهٔ واقعی) | فاز پایش پس از اصلاح |

### ۱۳.۹ تصمیم‌های این فاز و یادداشت‌های ثبت

- **هیچ اصلاحی انجام نشد** — حتی SCH-01 که P0 است؛ طبق قواعد فازهای مستندسازی، اصلاح باید همراه با تست‌های قفل‌کنندهٔ §۱۳.۶ در commit مجزای فاز اصلاح بیاید (توصیهٔ §۲/§۹ سند `IDEAL_SCHEMA_AUDIT.md` عیناً حفظ شد).
- **شماره‌گذاری فاز:** عنوان «فاز ۱۳» از شماره‌گذاری برنامهٔ تکمیل API پیروی می‌کند (۱۲ = ممیزی اسکیما — `IDEAL_SCHEMA_AUDIT.md`؛ ۱۲.۵ = ابزار استخراج و رده‌بندی سازگاری — `IDEAL_QUERY_COMPATIBILITY_REPORT.md` و `IDEAL_LIVE_SCHEMA_AUDIT.md`؛ ۱۳ = نخستین فاز تکمیل API اتصال MedPad). سند `IDEAL_SCHEMA_AUDIT.md` در متن خود «فاز ۱۳» را برای اصلاحات رزرو کرده بود — مرحلهٔ «ثبت و راستی‌آزمایی» آن فاز، همین بخش است و مرحلهٔ اصلاح در §۱۳.۸ دنبال می‌شود.
- **مرز با اسناد تخصصی:** `IDEAL_SCHEMA_AUDIT.md` (جزئیات ۱۹ مورد + تحول ستون‌ها در V1→V8)، `IDEAL_QUERY_COMPATIBILITY_REPORT.md` (رده‌بندی چهارسطحی CONFIRMED ERROR / VERSION DIFFERENCE / POTENTIAL ERROR / VERIFIED و بلوک‌های راستی‌آزمایی زنده) و `IDEAL_LIVE_SCHEMA_AUDIT.md` (وضعیت ابزار و برچسب‌های منبع) مرجع باقی می‌مانند؛ این بخش جمع‌بندی ثبت‌شده در سند مرجع Write است و در تداخل آتی هر دو روایت حفظ می‌شوند (قاعدهٔ پیوست ب).
- **فایل‌های بررسی‌شده در این فاز (همه در SHA مبنا):** `ideal/IdealBridge/src/IdealBridge.Infrastructure/Repositories/Repositories.cs` (۷۵۲ خط — همهٔ Queryها و Map)، `.../Repositories/CompanyRepository.cs`، `.../Repositories/DataAccessPolicy.cs`، `.../Database/SchemaProbe.cs` (۱۶۷ خط)، `ideal/IdealBridge/src/IdealBridge.Api/Program.cs` (سیم‌کابی 503)، `tests/IdealBridge.UnitTests/*` و `tests/IdealBridge.IntegrationTests/*` (شمارش و ساختار تست‌ها)، `project-analysis/decompiled/Models/CRMTabel.ssdl` (مرجع ایستا) و اسناد `IDEAL_SCHEMA_AUDIT.md`، `IDEAL_QUERY_COMPATIBILITY_REPORT.md`، `IDEAL_LIVE_SCHEMA_AUDIT.md`، `IDEAL_API_MAPPING.md`.
- **یافتهٔ جانبی (ثبت بدون اقدام):** در `IDEAL_QUERY_COMPATIBILITY_REPORT.md` §۴ یک مورد POTENTIAL دیگر (قیمت ردیف ≠ قیمت نهایی — `WSfnReturnProductPrice`) ثبت است که به endpointهای آیندهٔ قیمت مربوط می‌شود و خارج از دامنهٔ این بخش (Queryهای فعلی) ماند؛ در فاز طراحی endpointهای قیمت دوباره مرور شود.
- **یادداشت مسیرها (ثبت هنگام تحویل):** در جریان همین فاز، مالک کامیت `8373002` («مستندات ساخت API ایده آل») را push کرد که کل پوشهٔ `ideal/IdealBridge/` را به `ideal/مستندات ساخت API/IdealBridge/` منتقل کرد (برای فایل‌های ممیزی‌شدهٔ این بخش، تغییرنام خالص/R100 بود — محتوا و شمارهٔ خط‌ها بدون تغییر ماند؛ blob این سند نیز پیش از افزودن فاز ۱۳ یکسان بود: `01a2ef3`). همهٔ مسیرهای ثبت‌شده در این بخش به SHA مبنا (`9812159`، پیش از انتقال) اشاره دارند و در مسیر جدید نیز معتبرند؛ در جلسات آتی برای یافتن این فایل‌ها از مسیر جدید استفاده شود.

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
2. **`MobspCheckCompanyDataPermissionForUser`:** در اهداف دقیق `ideal-write-audit-fourth-fixed.sql` بود اما در خروجی استخراج نیامد — موجودیت این شیء با این نام دقیق **نیازمند تأیید** است (احتمال نام دقیق متفاوت برای Helper مشابه؛ Helper مشاهده‌شده در بدنه‌ها `MobspCheckCmpDataPermissionForUser` است). **[به‌روزرسانی ۲۰۲۶-۱۱-۱۹ (ادامه):** تعیین‌تکلیف در §۱۹.۱ — شواهد به یک شیء واحد با نام کوتاه اشاره می‌کند؛ کاوش موجودیت نام بلند در اسکریپت پنجم گنجانده شد.]
3. **`MobspSingleCrmConversationPreChecks`:** توسط `MobspUpdateConversation` فراخوانی می‌شود (`ideal-write-audit-fourth-part-10.txt` حدود خط 6839) اما تعریف آن در هیچ فایل استخراج فعلی نیست — **SQL Definition Pending**. **[به‌روزرسانی ۲۰۲۶-۱۱-۱۹ (ادامه):** قرارداد فراخوانی و هر سه فراخواننده در §۱۹.۲ مستند شد؛ تعریف همچنان Pending و در اهداف اسکریپت پنجم است.]
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
| — (ادامهٔ `9033b94`) | 2026-11-19 | **ادامهٔ نقطهٔ کنترل:** بخش‌های ۱۷-۲۷ سند ممیزی Write (AUTH-01..09، ORD-01..04، WF-01..04، فازهای ۲۰-۲۵) + `ideal/ideal-write-audit-fifth-pending-sp.sql` (اسکریپت استخراج فقط-خواندنی ۱۲۳ هدف) + به‌روزرسانی WORKLOG |

> **یادآوری پایانی:** این سند یک نقطهٔ کنترل (Checkpoint) است؛ یافته‌های جدید باید با همان قالب وضعیت‌گذاری (بخش ۰) و ارجاع فایل/خط به آن افزوده شوند و تعارض‌ها در پیوست ب ثبت شوند — نه با حذف خاموش اطلاعات قبلی.
