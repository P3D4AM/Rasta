# اعمال «کاتالوگ جامع دستورات SQL» — تحلیل، ممیزی و پیاده‌سازی عیناً

> **منبع:** `SQL_Catalog_Word_v1.0.zip` — ۵۹٬۱۲۴ دستور SQL استخراج‌شده ایستا از `CRM__Update_187.exe`
> (مهاجرت‌های V1→V8، دامنهٔ نسخه‌های 2.2.6.43 تا 4.4.3.213) + ۶۹۹ کوئری درون‌برنامه‌ای ۱۴۳ فرم فعال.
> نسخهٔ Word در شاخهٔ main داخل `ideal/SQL_Catalog_Word_v1.0.zip` فروزن شده است (README مخصوص: `ideal/README_SQL_Catalog.md`).
> **افزودهٔ ۲۰۲۶-۱۰-۲۶:** نسخهٔ ماشین‌خوان مالک `ideal/data.zip` (`catalog.tsv` + `statements.pack`) — متن کامل هر ۵۹٬۱۲۴ دستور؛ ۳٬۱۱۰ SP بریدهٔ جلدهای V5–V8 بازیابی شد و این سند در §۴.۱ و §۵.۳ بر اساس آن اصلاح شد.
> این سند گزارش فازِ «اعمال کاتالوگ» بر کد رستا روی شاخهٔ develop است.

## ۱. خلاصهٔ اجرایی

| شاخص | مقدار |
|---|---|
| دستورات پارس‌شده (هر ۱۱ جلد) | **۵۹٬۱۲۴** — دقیقاً مطابق آمار جلد صفر |
| اشیاء یکتای استخراج‌شده | ۴۶۲ CREATE TABLE (۳٬۹۹۴ ستون inline) · ۷۲۸ جدول با ۳٬۲۱۴ ستون ALTER-ADD · ۲۷۰ پیش‌فرض DF · ۱۵۶ ایندکس · ۵۰۱ PK · ۹۴۸ FK |
| رویه‌های ذخیره‌شدهٔ یکتا | **۵٬۳۰۲** (۱٬۴۴۴ با متن کامل از V1–V4) |
| توابع / نماها / تریگرها | ۲۱۴ تابع (۱۴۶ متن کامل) · ۳۵ نما (۸ متن کامل) · ۷ تریگر |
| تغییرات اسکیمای رستا (عیناً) | ۱۲ پیش‌فرض + ۶ ایندکس فیزیکی + ۶ ستون مهاجرتی + ۱ ستون فقط-رستا |
| اصلاح رفتاری | منطق ورود `CRMspCheckUserLoginAllowedTimes` (معنای معکوس رفع شد + بُعد IP + انباشت Reason) |
| قابلیت جدید | «عناوین پروژهٔ ممنوع» — CrmProjectsForbiddenForUser + دو SP، سیم‌کاسی کامل API/UI/E2E |
| تست | ۲۶ سنجهٔ E2E رفتاری — **ALL PASS** (e2e-login-times.mjs و e2e-forbidden-titles.mjs) |

## ۲. ابزار تحلیل (تکرارپذیر)

همهٔ اسکریپت‌ها در `scripts/` پروژهٔ رستا (develop) و سندباکس ذخیره شده‌اند:

| اسکریپت | نقش |
|---|---|
| `extract_sql_catalog.py` | استخراج متن ۱۱ جلد docx → txt (۹۹MB) |
| `parse_sql_catalog.py` | پارس ۵۹٬۱۲۴ مدخل (عنوان/شرح/شناسه/منبع/گام/پرچم/SQL) → `catalog_full.json` |
| `extract_db_objects_v2.py` | استخراج اشیاء: جدول/ستون/PK/FK/DF/ایندکس/SP/تابع/نما/تریگر → `inv_*.json` |
| `compare_catalog_vs_rasta.py` + `deep_dive_active.py` | مقایسه با ۲۶ مدل فعال رستا + تعیین شکاف‌ها |
| `apply_schema_fixes.py` | اعمال ۲۱ ویرایش کنترل‌شده روی `prisma/schema.prisma` |

خروجی‌های میانی JSON در سندباکس: `sql-catalog/parsed/` (catalog_full.json ۱۱۲MB + ۱۰ فایل inv_*.json).

## ۳. شکاف‌های SSDL که فقط از کاتالوگ قابل‌استخراج بود

تا پیش از این فاز، تنها منبع ساختاری، `CRMTabel.ssdl` (۶۳۳ جدول/۳٬۴۳۸ امضای SP) بود. کاتالوگ این‌ها را افزود:

### ۳.۱ پیش‌فرض‌های ستون (۱۲ مورد روی جدول‌های فعال)

| جدول.ستون | DEFAULT اورجینال | اعمال در رستا |
|---|---|---|
| ۹ جدول `.GUId` (CrmUserTasks، CrmFund، CrmFundGroups، CrmProjectCategory، CrmProjectGroups، CrmProjectTitleGroups، CrmConversationStatusGroups، UserGroups، UserLoginAllowedTimes، UserPositions) | `(newid())` | `@default(uuid())` |
| `Users.MobMovementTrackingDistanceInterval` | `(100)` | `@default(100)` |
| `Users.MobMovementTrackingTimeInterval` | `(60)` | `@default(60)` |

### ۳.۲ ایندکس‌های فیزیکی (۶ مورد عیناً روی نام ستون‌های اصلی)

| ایندکس اورجینال | جدول (ستون) | منبع | اعمال |
|---|---|---|---|
| `IX_CrmCompanyPersons` | CrmCompanyPersons (prsMobile) | V2 گام ۶۸۶ | `@@index([mobile])` |
| `IX_CrmCompanyPersons_CmpId` | CrmCompanyPersons (prsCompanyId) | V5 گام ۱۱۲۷۹ | `@@index([companyId])` |
| `IX_CrmConversation_CompanyId` | CrmConversation (cnvsCompanyId) | V5 گام ۱۲۱۴۵ | `@@index([companyId])` |
| `IX_CrmConversation_ProjectId` | CrmConversation (cnvsProjectId) | V5 گام ۱۲۱۴۶ | `@@index([projectId])` |
| `IX_CrmConversation_StatusId` | CrmConversation (cnvsStatusId) | V5 گام ۱۲۱۴۷ | `@@index([statusId])` |
| `IX_CrmProjects_CompanyId` | CrmProjects (prjCompanyId) | V5 گام ۱۲۱۴۸ | `@@index([companyId])` |

### ۳.۳ ستون‌های مهاجرتی غایب از SSDL نسخهٔ فروزن (۶ مورد)

این ستون‌ها پس از نسخهٔ 3.1.18 در مهاجرت‌های V4/V5/V7 افزوده شده‌اند؛ طبق دستور مالک («هر چی که تا الان نداشتی… عیناً پیاده‌سازی کن») به مدل‌ها اضافه شدند:

| ستون | نوع اورجینال | منبع مهاجرت |
|---|---|---|
| `CrmCompany.FirstRegisterDateTime` | datetime NULL | V4 گام ۲۶۴۴ |
| `CrmCompany.cmpOfficialKind` | int NULL | V7 گام ۳۲۳۱۵ |
| `CrmCompanyPersons.FirstRegisterDateTime` | datetime NULL | V4 گام ۲۶۳۹ |
| `CrmConversationStatusGroups.NoRegCnvsOlderStatue` | bit NULL | V7 گام ۳۰۲۸۴ |
| `CrmUserTasks.UserTaskTimeNext` | varchar(12) NULL | V1 (CREATE TABLE جدول‌ساز) |
| `UserDepartments.DefaultReferUserIdForCnvs` | int NULL | V5 گام ۹۵۴۵ |

### ۳.۴ قیدهای یکتایی و روابط تأییدشده

- `Users.UserName` — `IX_Users UNIQUE NONCLUSTERED` (V2 گام ۶۸۹، بازتأیید V4 گام ۲۸۳۹) → از قبل `@unique` بود؛ **تأیید شد**.
- ۹۴۸ FK استخراج شد؛ روی جدول‌های فعال، الگوی غالب: `FirstRegisterUserId → Users.UserId` (حسابرسی ثبت اولیه)، `prjGroupId → CrmProjectGroups`، `prjcnvsStatusGroupId → CrmConversationStatusGroups`، `GroupId → CrmConversationStatusGroups`، `cmpReferUserId → Users` و خود‌ارجاع‌های `Users` (`UserId1`، `ResponsibleUserId`).
- FKهای `int → Users` با کلید cuid رستا سیم‌کشی‌پذیر نیستند؛ اسکالر عیناً حفظ و انحراف در کامنت مدل‌ها مستند است.

## ۴. مطالعات رفتاری و اصلاحات

### ۴.۱ چک ورود — `CRMspCheckUserLoginAllowedTimes` (متن کامل نهایی از data.zip)

**رفتار اورجینال (متن نهایی V5 گام ۳۷۲۵ — از statements.pack مالک):**
- چهار بُعد مستقل: `Date` (`@CurrDate BETWEEN FDatePersian AND TDatePersian`)، `Day` (`@CurrDay BETWEEN DayNumber AND DayNumber` = برابری)، `Time` (`@CurrTime BETWEEN FTime AND TTime`)، `IP` (`@CurrIPAddress = IPAddress`).
- **ردیف = پنجرهٔ مجاز (whitelist)** — عین متن SP: «if there are some records for user in UserLoginAllowedTimes, then user can login to system by these records (just)»: اگر کاربر برای بُعدی قاعده‌ای دارد، «اکنون» باید داخل حداقل یکی از پنجره‌های همان بُعد باشد؛ وگرنه `AllowUserLogin=0` و دلیل‌ها انباشته می‌شوند (`Date,Day,Time,IPAddress`). بدون قاعده در یک بُعد = بدون محدودیت آن بُعد.

**تاریخچهٔ اصلاح (شفافیت):** پیاده‌سازی اولیه رستا ردیف‌ها را «ممنوع» می‌پنداشت؛ در تسک ۹ بر اساس متن V3 (که باگ `<> NULL` دارد و عملاً no-op است) معنا دوباره «ممنوع» خوانده شد و E2E هم برای همان معنا نوشته شد. با دریافت data.zip و خواندن متن نهایی V5 گام ۳۷۲۵، معنا به whitelist اصلاح شد (commit 7b2f0f9) — E2E بازنویسی و ۱۴/۱۴ PASS؛ شامل سنجهٔ استقلال ابعاد (روزِ امروز + ساعت آینده → فقط Time).

### ۴.۲ «عناوین پروژهٔ ممنوع» — قابلیت جدید عیناً

منبع: جدول `CrmProjectsForbiddenForUser` + `CRMspSelectCrmProjectsForbiddenForUser/NotForbiddenForUser` (متن کامل V2) + کوئری فرم‌های frmBuyOrder/frmOrderDat:
```sql
SELECT prjIsFinished FROM dbo.CrmProjects
WHERE ProjectID = :ProjectId
AND prjTitle NOT IN (SELECT ForbiddenProjectTitle
                     FROM CrmProjectsForbiddenForUser WHERE CrmUserId = :UserID)
```
پیاده‌سازی در رستا (commit c11ee25):
- مدل بخش-۲ + ستون فقط-رستا `rastaUserId` (نگاشت cuid؛ `CrmUserId` اصلی int حفظ شد)
- API مدیریت: `GET/POST/DELETE /api/users/[id]/forbidden-titles`
- فیلتر تعاریف: `/api/project-defs/titles?forMe=1` (فرم پروژه این حالت را می‌خواند)
- فیلتر لیست پروژه‌ها + گارد ۴۰۳ درج (عنوان ممنوع)
- شمارنده‌های تب عیناً فیلتر نمی‌شوند — مطابق بدنهٔ `CRMspSelectCompanyProjectsCount` که فقط فیلتر استارتر/کاربر-متصل دارد
- دیالوگ UI در فرم تعریف کاربر (مجوز `actEditMoreInfo` — نام action اورجینال یافت نشد؛ بدون جعل مستند شد)
- ۱۴ سنجهٔ E2E ALL PASS

**افزودهٔ نسخهٔ نهایی (V8 گام ۳۲۰۱ — از data.zip):** SP نهایی پارامتر `@CenterId` و فیلتر `(ISNULL(@CenterId,0)=0 OR ISNULL(PF.CId,0)=ISNULL(@CenterId,0))` دارد — یعنی ممنوعیت قابل تخصیص به یک مرکز (ستون `CId`) است. تا وقتی ماژول مراکز در رستا ساخته نشده، زمینهٔ مرکز وجود ندارد و رفتار فعلی (همهٔ ردیف‌ها) معادل حالت بدون مرکز SP است؛ برای فاز مراکز ثبت شد.

### ۴.۳ کشف: «کاربر متصل» در شمارنده‌ها — `CrmLinkedUsers (LinkedTypeId=24)`

بدنهٔ `CRMspSelectCompanyProjectsCount` (متن کامل V2/V5/V7/V8):
```sql
AND [prjStarterUserId] IN (SELECT @UserID UNION
    SELECT LinkedUserId FROM dbo.CrmLinkedUsers WHERE CrmUserId = @UserID AND LinkedTypeId = 24)
```
یعنی شمارنده/پروژه‌های هر کاربر شامل پروژه‌های «کاربران متصل نوع ۲۴» است (سازوکار جانشینی مدیر/دستیار). **اعمال نشد** — نیازمند سیم‌کاسی `CrmLinkedUsers` با الگوی rastaUserId؛ برای فاز بعد ثبت شد (فهرست کامل در §۵).

## ۵. کشف‌شده اما اجرانشده در این فاز (صف فازهای بعد)

قاعدهٔ مالک: «پیاده‌سازی نشده را جعل نکن، مستند کن». این موارد از کاتالوگ شناسایی و مشخص شدند اما به‌دلیل حجم/وابستگی سیم‌کابی، در این فاز فقط مستند شدند:

1. **ماتریس دسترسی مخاطب** — ۱۴ جدول `CrmCompanyForbidden{City,Company,Province,Group,GroupIV,SubGroup,Department,…}` و `CrmCompanyJustAccess{…}` + ~۶۰ SP (Insert/Delete/Select) + `CrmfnSelectNotForbiddenCompany` (۳ کوئری فرم). معنا: مدیر می‌تواند دامنهٔ دید مخاطبان هر کاربر را «ممنوع/فقط-دسترسی» کند. زیرساخت: مدل‌های بخش-۲ موجود؛ سیم‌کابی با الگوی عناوین ممنوع (rastaUserId) قابل‌تکرار است.
2. **کاربر متصل (`CrmLinkedUsers`)** — نوع ۲۴ برای پروژه‌ها (شمارنده/دید)؛ انواع دیگر برای جانشینی در تیکت/ارجاع. جدول بخش-۲ موجود؛ اتصال با rastaUserId.
3. ~~**متن کامل SPهای V5–V8**~~ — **حل شد با data.zip مالک (۲۰۲۶-۱۰-۲۶)**: `statements.pack` متن کامل هر ۵۹٬۱۲۴ دستور را دارد؛ هر ۳٬۱۱۰ SP بریده راستی‌آزمایی‌شده بازیابی شد (مجموع len = حجم pack دقیقاً؛ ۰ ردیف خارج از مرز). الگوی کار برای هر SP: آخرین ردیف آن در ترتیب V1→V8 = نسخهٔ نهایی. فایل در main/ideal/data.zip + راهنمای کامل در ideal/README_SQL_Catalog.md.
4. **۱۲۲ کوئری پارامتری فرم‌ها** (جلد ۱۰) — مثل `:Mode` در `WSspSelectProductModels`؛ مرجع همان‌سازی رفتار فرم‌های فروش/انبار در فازهای ماژول WS.
5. **۲۷۲ SP گزارش (`Rpt`)** — قلب گزارش‌گیری اورجینال؛ ۲۹ متن کامل؛ فاز مستقل «گزارش‌ها».
6. **۷ تریگر + ۳۵ نما** — شامل `CRMvwSelectCompanyAndPersons*` با ایندکس‌های CLUSTERED یکتا (V7) — برای جستجوی سراسری مخاطب.
7. **۱۷ دستور مخرب** (فهرست جدول ۴ جلد صفر) — صرفاً مرجع ایمنی؛ اجرا نمی‌شوند.

## ۶. صحت‌سنجی و وضعیت

- `prisma validate` ✓ · `db push` ✓ · `tsc --noEmit` = 0 خطا · `eslint` = 0 خطا
- E2E (پس از اصلاح whitelist با data.zip): ساعت ورود (۱۴) + عناوین ممنوع (۱۴) — **28/28 PASS**
- کامیت‌ها: `95d2b58` (اسکیما+رفتار ورود — بعداً اصلاح شد) · `c11ee25` (عناوین ممنوع) · `7b2f0f9` (اصلاح معنای whitelist ساعت ورود از متن نهایی V5)
- کاتالوگ + README مخصوص: `main` شاخهٔ ideal (کامیت `fbe2938`) · data.zip ماشین‌خوان + به‌روزرسانی README (کامیت `3d99e6a`)
