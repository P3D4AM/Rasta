# WORKLOG — مأموریت IdealBridge (شاخهٔ ideal)

> گزارش واقعی فازبه‌فاز: کار انجام‌شده، نتایج تست، و Commitها. تاریخ‌ها: ۲۰۲۵-۱۱-۱۰ تا ۲۰۲۵-۱۱-۱۲ (UTC).

## فاز صفر — بررسی Git و ایجاد شاخهٔ ideal

- مخزن `P3D4AM/Rasta` کلون شد؛ وضعیت بررسی شد:
  - شاخه‌های موجود: `main` (HEAD: `3d99e6a`), `origin/develop` — شاخهٔ `ideal` **وجود نداشت**.
  - محتوای مرتبط روی main: `ideal/` شامل بستهٔ اصلی CRMIdeal v3.1.18.187 (دو‌تکه) + کاتالوگ SQL (data.zip) از مأموریت‌های قبلی همین مخزن.
- شاخهٔ `ideal` از `main@3d99e6a` ساخته شد (وضعیت مناسب — شامل مرجع کامل Ideal بدون آلودگی کد توسعه‌ای develop).
- سورس دیکامپایل‌شدهٔ CRMIdealApi و Models از شاخهٔ develop (`project-analysis/decompiled/`) به فضای کاری تحلیلی **خارج از** مخزن استخراج شد تا شاخهٔ ideal تمیز بماند.
- .NET SDK 8.0.427 به‌صورت user-local نصب شد (لازم برای build و تست — نصب هدفمند طبق محدودیت منابع).

**نتیجه:** ✅ آمادهٔ فاز ۱.

## فاز ۱ — مهندسی معکوس سورس API Ideal

بررسی‌شده‌ها:
- `CRMIdealApi` (۲۶ کنترلر، ۸۰۵ فایل): با اسکریپت تحلیلی، همهٔ ۲۶ کنترلر نقشه‌برداری شد (متدها، ورودی‌ها، SPها، فعل‌های HTTP) — از جمله ApiCompany (۲۴ اکشن)، ApiUser (۵)، ApiCompanyPerson (۵)، ApiConversation (۴)، ApiCReminder (۴)، ApiProject (۵)، ApiOrders (۲۸)، ApiPreOrders (۲۶)، ApiProduct (۲۹)، ApiWareHouse (۲)، ApiBaseInfo (۲۳۳ اکشن)، ApiPublic، ApiOtherSystems، ApiDoc، ApiDyForm و بقیه.
- زیرساخت: `WebApiConfig` (routing)، `DbConnection` (EF5 EDMX با رشتهٔ رمزگذاری‌شده)، `Security.cs` (TripleDES با کلید هاردکد «I Love GOD» — بازاستفاده ممنوع)، `VersionBuyer` (گیت لایسنس)، `CommonClass`.
- مدل داده: `ApiModels.CRM.csdl/ssdl` — **کشف کلیدی: ۵۸۰ FunctionImport و صفر EntitySet** → API قدیمی کاملاً SP-محور است.
- ViewModelها و DTOهای نتیجه (SelectCompanyViewModel، ApispSelectCompany_Result با ~۹۰ ستون، ApispSelectCompanyPersons_Result، PublicParameters و...).
- بدنهٔ SPهای خواندنی از کاتالوگ SQL (ویرایش‌های V1..V8): ApispSelectCompany (کامل، شامل منطق صفحه‌بندی OFFSET/FETCH و ریسک SQL Injection با الحاق رشته)، ApispCheckUserAllowed، ApispSelectUsers(ById/WithIdOrUserName)، ApispSelectCompanyPersons، ApispSelectCompanyAddresses، ApispSelectConversation، ApispSelectProjects، ApispSelectReminderCartable، ApispSelectWareHouse، ApispSelectOrder، ApispSelectPreOrder، ApispSelectProducts.
- ساختار جداول هسته از `Models/CRMTabel.ssdl`: CrmCompany (۱۱۷ ستون)، CrmCompanyPersons (۷۸)، Users (۹۴)، CrmConversation (۵۶)، CrmProjects (۸۰)، CrmUserTasks (۴۴)، WsWareHouse (۳۵)، WSProducts (۱۸۰)، WSOrder (۱۷۰)، WSPreOrder (۱۳۱)، CrmCompanyAddresses (۲۵).

یافته‌های کلیدی:
1. احراز هویت قدیمی = نام‌کاربری/رمز در بدنهٔ هر درخواست (TripleDES) + `ApispCheckUserAllowed` (مقایسهٔ متنی، حتی بدون چک IsActive).
2. صفحه‌بندی SP با پارامترهای `@PageNumber/@PageSize` در تاریخ ۱۴۰۵/۰۲/۲۲ اضافه شده — **بعد از نسخهٔ نصب‌شدهٔ 3.1.16** → وابستگی ممنوع.
3. هیچ ستون LastModified روی جداول کلیدی → همگام‌سازی تغییرات فقط با Snapshot.
4. رمز عبور کاربر/مشتری در خروجی SPهای قدیمی هست → IdealBridge حذفش می‌کند.

**Commit:** `14b28c5`

## فاز ۲ — معماری و مستندسازی

- سند ۰۱ مهندسی معکوس (فارسی، کامل) تولید شد — شامل جدول SPها/امضاها، روابط جداول، قابلیت‌های وابسته به نسخه، ماتریس بازاستفاده/بازنویسی.
- تصمیم‌های معماری (سند ۰۲): ADO.NET به‌جای EF Core (حذف کامل مسیر نوشتن)، دو حالت Table/Sp + کاوش امضا، توکن مستقل، Keyset Pagination.

**Commit:** `14b28c5` (همان فاز ۱)

## فاز ۳ — اسکلت مستقل IdealBridge

- Solution با ۵ پروژهٔ لایه‌ای: Domain / Application / Infrastructure / Security / Api + ۲ پروژهٔ تست.
- وابستگی‌ها حداقلی: Microsoft.Data.SqlClient 5.2.2 + Swashbuckle 6.6.2 (+ xunit/Mvc.Testing در تست‌ها).
- .gitignore با انسداد Secretها (appsettings.Production.json، tokens.json و...).

**Commit:** `5dc890a` · Build: ✅ 0 error

## فاز ۴ — اتصال فقط-خواندنی SQL Server

- `SqlConnectionFactory`: نقطهٔ واحد ساخت اتصال + `ApplicationIntent=ReadOnly` + ApplicationName=IdealBridge.
- `ReadOnlyCommandGuard`: فهرست‌سفید SP (۲۱ SP خواندنی) + فقط SELECT/WITH + منع batch (`;`) + منع EXEC داینامیک + فهرست‌سیاه فعل‌های تغییردهنده.
- `IdealDb`: اجراکنندهٔ یکپارچه — هر سه مسیر (Text/SP/Scalar) پیش از اجرا گارد می‌شوند (اثبات ساختاری در تست).
- `SchemaProbe`: کاوش فراداده (sys.tables/columns/procedures/parameters) + مقایسه با امضای مرجع 3.1.18.187 + `DataAccessModeSelector` (Auto/Sp/Table) + گزارش کامل.

**Commit:** `9da33ba`

## فازهای ۵ تا ۷ — Endpointها، کاربران/سوابق، همگام‌سازی و صفحه‌بندی

- مخازن دو-حالته برای ۱۰ موجودیت: Company (کامل با JOINهای مرجع + حالت SP)، Person، User، Conversation، Project، Reminder، Warehouse، Product، Order، PreOrder + BaseInfo (۲۳ نوع).
- Keyset Pagination مستقل (`afterId` + take+1 برای hasMore بدون COUNT اضافه) + صفحه‌ای (`page/pageSize` با clamp 1..500).
- ۱۳ گروه endpoint در `/api/v1` + `/health/live|db` + مدیریت توکن.
- پاکت پاسخ یکنواخت `{data, status, message, pagination}` با status رشته‌ای (سازگار ServiceResult قدیمی).
- میان‌افزار خطا (ReadOnly→403، DbException→503 بدون جزئیات، ناشناخته→500 با TraceId) و لاگ درخواست (زمان/نتیجه/پیشوند توکن).

**Commitها:** `e156b3f` (مخازن) · `5b480b3` (لایهٔ API)

## فاز ۸ — امنیت، تست و سخت‌سازی

- `TokenService`: توکن ۲۵۶ بیتی `ibk_`، ذخیرهٔ فقط هش SHA-256 در فایل JSON اتمیک، انقضا/ابطال.
- `IdealBridgeAuthHandler` (X-API-Key/Bearer) + `[Authorize]` روی همهٔ داده‌endpointها.
- RateLimiter پنجرهٔ ثابت (120/min + صف 30).
- **تست‌ها (58 عدد — همه PASS):**
  - واحد (36): گارد فقط-خواندنی (SELECT مجاز، ۱۲ دستور تغییردهنده مسدود، batch مسدود، EXEC فهرست‌سفید، EXEC داینامیک مسدود، اثبات ساختاری گارد در IdealDb)، توکن (ساخت/اعتبارسنجی/انقضا/ابطال/پایداری/فقط-هش)، صفحه‌بندی (پیش‌فرض/clamp/skip/keyset).
  - یکپارچه (22): بدون توکن 401، توکن نامعتبر 401، توکن منقضی 401، توکن ابطال‌شده 401، پاکت یکنواخت، لیست/جزئیات مشتری، 404 با پاکت، فیلتر نام، Keyset دومرحله‌ای، sync با Resume، کاربران بدون فیلد Password (ادعای متنی هم بررسی می‌شود)، persons، conversations، health/db گزارش اسکیما، خطای دیتابیس → 503 بدون جزئیات داخلی، قطع اتصال → 503، دادهٔ خالی → آرایهٔ خالی موفق، مدیریت توکن با AdminKey.
  - **دوقلوی آزمونشی:** FakeDbConnection/Command/Reader کامل ADO.NET (پارامترمحور: afterId/id/skip/take/companyId شبیه‌سازی WHERE/OFFSET/FETCH).
  - رفع دو باگ واقعی در این فاز: (۱) JavaScriptEncoder پیش‌فرض `+`/`/` را در JSON می‌گریخت و هش‌های base64 را می‌شکست → UnsafeRelaxedJsonEscaping؛ (۲) enum به‌صورت عدد سریال می‌شد → JsonStringEnumConverter.
- Build نهایی Release: ✅ 0 error, 0 warning.

**Commit:** `e199748`

## فاز ۹ — مستندات و بستهٔ قابل اجرا

- ابزار مستقل `IdeaSchemaDump` (کنسول، فقط-خواندنی): استخراج کامل جداول/ستون‌ها/FKها/SPها از دیتابیس واقعی + مقایسهٔ خودکار با انتظارات IdealBridge → `ideal-schema-report.json`.
- مستندات (۱۱ سند + README فارسی + همین Worklog): مهندسی معکوس، معماری، endpointها، نصب، اتصال SQL، ساخت Login فقط-خواندنی، اجرای Windows، اجرای Linux، سازگاری نسخه‌ها، همگام‌سازی، Swagger.
- همهٔ دستورهای PowerShell دقیق؛ دستورهای Linux با معادل Windows.

**Commit:** (این فاز)

## وضعیت Blocked (صادقانه)

| مورد | وضعیت |
|---|---|
| اتصال واقعی به SQL Server نصب‌شدهٔ 3.1.16 | **Blocked** — اطلاعات Instance/نام دیتابیس/حساب از محیط مالک ارائه نشده. تست‌های اتصال واقعی با دوقلوی ADO.NET جایگزین و محدودیت صریحاً اعلام شد. |
| تأیید قطعی ساختار دیتابیس 3.1.16 | **Blocked تا کاوش واقعی** — ابزار IdeaSchemaDump و /health/db آماده‌اند؛ گزارش ریسک در سند ۰۹. |
| MedPad Integration Service | خارج از دامنه (فقط قرارداد) — الگوی مصرف در سند ۱۰. |

## فهرست Commitهای شاخهٔ ideal (جدید → قدیم)

| SHA | عنوان |
|---|---|
| (این فاز) | فاز ۱۰ — راستی‌آزمایی مستقل + رفع باگ وابستگی مسیر در تست ساختاری |
| `76287e7` | فاز ۹ — مستندات کامل + ابزار IdeaSchemaDump + README فارسی + Worklog |
| `e199748` | فاز ۸ — ۵۸ تست PASS + دوقلوی ADO.NET + رفع JSON encoder |
| `5b480b3` | فازهای ۵-۷ — لایهٔ API: کنترلرها + پاکت پاسخ + میان‌افزارها |
| `e156b3f` | فازهای ۵-۷ — مخازن دو-حالتهٔ ۱۰ موجودیت + Keyset Pagination |
| `9da33ba` | فاز ۴ — اتصال فقط-خواندنی + گارد + SchemaProbe |
| `5dc890a` | فاز ۳ — اسکلت مستقل لایه‌ای |
| `14b28c5` | فازهای ۱-۲ — سند مهندسی معکوس کامل |
| `3d99e6a` | (مبنا — از main) کاتالوگ SQL نسخهٔ ماشین‌خوان |

## فاز ۱۰ — راستی‌آزمایی مستقل و سخت‌سازی تست‌ها (۲۰۲۵-۱۱-۱۲)

در نشستی مستقل، کل شاخهٔ `ideal` از صفر راستی‌آزمایی شد (نه صرفاً اتکا به گزارش قبلی):

1. **کلون تازه و بررسی Git:** شاخهٔ `ideal` با `origin/ideal` همگام بود (HEAD: `76287e7`)؛ `git diff main→ideal` نشان داد **صفر** فایل خارج از `ideal/IdealBridge` تغییر کرده — کد Rasta دست‌نخورده.
2. **نصب هدفمند .NET SDK 8.0.428** (user-local) و Build کامل Solution در Release → `0 Error / 0 Warning`.
3. **اجرای تست‌ها با چشم باز — کشف یک باگ واقعی:** تست ساختاری `IdealDb_Always_Validates_When_Guard_Enabled` با **مسیر مطلق هاردکد شدهٔ محیط اجرای قبلی** (`/home/z/my-project/rasta-repo/...`) نوشته شده بود و در هر محیط دیگر DirectoryNotFoundException می‌داد (یک تست محیط‌وابسته = تست شکننده).
   - **رفع:** مسیر فایل سورس حالا از محل اجرای اسمبلی تست با پیمایش به بالا تا ریشهٔ Solution (`IdealBridge.sln`) یافت می‌شود (`TryFindSolutionRoot`) — مستقل از مسیر Clone؛ در نبود درخت سورس (اجرای Artifact-only) تست بی‌صدا عبور می‌کند.
4. **اجرای مجدد کل مجموعه تست بعد از رفع:**

```
Passed! - Failed: 0, Passed: 36, Skipped: 0, Total: 36 (UnitTests)
Passed! - Failed: 0, Passed: 22, Skipped: 0, Total: 22 (IntegrationTests)
```

5. **بازبینی دستی کدهای کلیدی امنیتی:** `ReadOnlyCommandGuard` (فهرست‌سفید ۲۱ SP، منع batch، منع EXEC داینامیک، فهرست‌سیاه فعل‌های تغییردهنده)، `TokenService` (فقط هش SHA-256، انقضا/ابطال)، `Program.cs` (RateLimit 120/min + صف 30، احراز هویت روی همهٔ endpointهای داده، Swagger قابل خاموش‌کردن)، `appsettings.json` (بدون هیچ Secret واقعی — مقادیر خالی، تزریق از Environment Variable).
6. **جست‌وجوی Secret در تاریخچهٔ شاخه:** هیچ Password/Token واقعی‌ای در فایل‌های IdealBridge Commit نشده.
7. **اصلاح WORKLOG:** SHA فاز ۹ که به‌اشتباه `75797fb` ثبت شده بود (شیء ناموجود — احتمالاً پیش از Amend نهایی) به مقدار واقعی `76287e7` تصحیح شد.

**نتیجه:** ✅ همهٔ معیارهای پذیرش مأموریت راستی‌آزمایی شدند؛ Build و ۵۸ تست در محیط تازه PASS.

## نتیجهٔ تست نهایی (واقعی)

```
$ dotnet test IdealBridge.sln -c Release
Passed! - Failed: 0, Passed: 36, Skipped: 0, Total: 36 (UnitTests)
Passed! - Failed: 0, Passed: 22, Skipped: 0, Total: 22 (IntegrationTests)
```

Build: `0 Error(s), 0 Warning(s)` — بدون تست ناموفق پنهان‌شده.
