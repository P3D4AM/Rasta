# WORKLOG — مأموریت IdealBridge (شاخهٔ ideal)

> گزارش واقعی فازبه‌فاز: کار انجام‌شده، نتایج تست، و Commitها. تاریخ‌ها از `git log` استخراج شده (UTC) — اصلاح فاز ۱۱: تاریخ‌های قبلی ۲۰۲۵ اشتباه بودند، تاریخ واقعی همهٔ Commitها ۲۰۲۶ است.
>
> | دوره | تاریخ واقعی (UTC) |
> |---|---|
> | فازهای ۱-۲ | ۲۰۲۶-۱۱-۱۰ |
> | فازهای ۳-۹ | ۲۰۲۶-۱۱-۱۰ |
> | فاز ۱۰ | ۲۰۲۶-۱۱-۱۲ |
> | فاز ۱۱ | ۲۰۲۶-۱۱-۱۲ |
> | فاز ۱۱.۱ | ۲۰۲۶-۱۱-۱۲ |

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
| `d521ce2` | فاز ۱۰ — راستی‌آزمایی مستقل + رفع باگ وابستگی مسیر در تست ساختاری |
| `76287e7` | فاز ۹ — مستندات کامل + ابزار IdeaSchemaDump + README فارسی + Worklog |
| `e199748` | فاز ۸ — ۵۸ تست PASS + دوقلوی ADO.NET + رفع JSON encoder |
| `5b480b3` | فازهای ۵-۷ — لایهٔ API: کنترلرها + پاکت پاسخ + میان‌افزارها |
| `e156b3f` | فازهای ۵-۷ — مخازن دو-حالتهٔ ۱۰ موجودیت + Keyset Pagination |
| `9da33ba` | فاز ۴ — اتصال فقط-خواندنی + گارد + SchemaProbe |
| `5dc890a` | فاز ۳ — اسکلت مستقل لایه‌ای |
| `14b28c5` | فازهای ۱-۲ — سند مهندسی معکوس کامل |
| `3d99e6a` | (مبنا — از main) کاتالوگ SQL نسخهٔ ماشین‌خوان |

## فاز ۱۰ — راستی‌آزمایی مستقل و سخت‌سازی تست‌ها (۲۰۲۶-۱۱-۱۲)

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

---

# فاز ۱۱ — Security Hardening، ارتقای .NET 10 و زیرساخت اتصال (۲۰۲۶-۱۱-۱۲)

> دستور مأموریت: اصلاح DataAccessMode، بازنویسی ReadOnlyCommandGuard، زیرساخت اتصال SQL Server، تکمیل IdeaSchemaDump، ارتقا به .NET 10 LTS، CI، مستندات، Release آزمایشی. همهٔ مراحل با Build و تست واقعی اجرا شد.

## مرحله A — بررسی وضعیت

- شاخهٔ `ideal` با `origin/ideal` همگام بود (HEAD: `50da585`).
- دو باگ واقعی از فازهای قبل در بررسی اولیه شناسایی شد:
  1. `PersonRepository.Query` در حالت Sp «آرایهٔ خالی بی‌صدا» برمی‌گرداند (`_mode == "Sp" ? Array.Empty...`).
  2. `UserRepository` شرط مردهٔ `_mode == "Sp" && false` داشت.
- تاریخ‌های WORKLOG (۲۰۲۵) با تاریخ واقعی Commitهای Git (۲۰۲۶) مغایر بود → در همین فاز اصلاح شد.

## مرحله B — اصلاح DataAccessMode و غیرفعال‌سازی کامل SP

- `DataAccessMode` پیش‌فرض **Table** شد (قبلاً Auto).
- سیاست مرکزی و یکپارچهٔ `DataAccessPolicy` جایگزین `SchemaModeProvider` + `DataAccessModeSelector`: پیش‌فرض Table؛ `Sp` در راه‌اندازی رد (خطای واضح)؛ `Auto` ≡ Table؛ موجودیت با جدول مفقود → `Blocked` = خطای شفاف ۵۰۳ (`DataAccessUnavailableException` + نگاشت در میان‌افزار خطا) — **رفع کامل «آرایهٔ خالی بی‌صدا»**.
- **حذف کامل مسیر اجرای SP**: `IdealDb.QuerySpAsync` حذف؛ متدهای SP مخزن مشتریان (GetCompaniesSpAsync/GetCompanySpAsync/MapCompanyLegacy) حذف؛ شرط‌های مردهٔ Person/User پاک شد.
- تست‌ها: `DataAccessPolicyTests` (۱۰) + `SourceStructureRegressionTests` (۴ تست ساختاری ضد-بازگشت: منع Array.Empty، منع بازگشت مسیر SP، پوشش سیاست مرکزی همهٔ مخازن، گارد همهٔ مسیرهای اجرای IdealDb) + ۳ تست یکپارچه (هیچ دستور StoredProcedure اجرا نمی‌شود؛ جدول مفقود → ۵۰۳ شفاف نه آرایهٔ خالی؛ حالت Sp → شکست راه‌اندازی).
- رفع دو باگ جانبی کشف‌شده: سریال‌سازی عددی enum در پاسخ‌های خطای میان‌افزار (ناسازگار با کنترلرها) و زمان‌بندی اعتبارسنجی پیکربندی (انتقال به post-Build از کانفیگ نهایی).
- تست: ۷۹ PASS (۵۴ واحد + ۲۵ یکپارچه).

**Commit:** `17c9a87` (2026-11-12 11:48 UTC)

## مرحله C — بازنویسی ReadOnlyCommandGuard با توکنایزر

- **حذف فهرست سفید SP** — هیچ SP (حتی با نام معتبر خواندنی) مجاز نیست؛ `CommandType.StoredProcedure` همیشه رد.
- توکنایزر واقعی T-SQL: رشته‌ها ('...' و N'...' با گریز '')، کامنت‌ها (-- و /* */)، شناسه‌های [براکت‌دار] و "کوتیشن‌دار" درست پارس می‌شوند — کلیدواژه داخل کامنت/رشته/براکت فریب نمی‌دهد.
- منع‌های جدید: `INTO` (SELECT INTO)، `SET`، `WAITFOR`، `GO`، `OPENROWSET/OPENQUERY/OPENDATASOURCE/OPENXML`، `BULK`، `sp_*`/`xp_*`، رشته/کامنت/براکت نیمه‌تمام.
- `ReadOnlyGuardPolicy.Effective`: در **Production** گارد همیشه روشن (تنظیم false نادیده + لاگ هشدار در Program.cs).
- تست‌ها: بازنویسی کامل `ReadOnlyCommandGuardTests` — ۶۱ تست شامل ۱۷ SELECT مجاز (کامنت/رشته/براکت)، همهٔ فعل‌های تغییردهنده، SELECT INTO، batch/GO، EXEC به‌همراه اشکال دورزدن (کامنت ابتدایی، حروف مخلوط، تب/خط جدید)، ورودی‌های خراب، واژه‌های شامل زیررشته (OFFSET/SettingId)، سیاست محیطی، اثبات ساختاری IdealDb.

**Commit:** `7b43644` (2026-11-12 11:50 UTC) — تست: ۱۴۰ PASS

## مرحله D — زیرساخت اتصال SQL Server

- **دو روش پیکربندی**: `IdealBridge:ConnectionString` کامل، یا بخش تفکیکی `IdealBridge:Sql` (Server/Database/AuthMode=Sql|Windows/UserId/Password/Encrypt/TrustServerCertificate/ConnectTimeoutSeconds) — در هر دو حالت `ApplicationName=IdealBridge` + `ApplicationIntent=ReadOnly` + مهلت اتصال اجباری؛ اولویت ConnectionString.
- Windows Authentication با `IntegratedSecurity` (سند: Linux نیازمند Kerberos).
- `SqlConnectionErrorClassifier`: دسته‌بندی خطا (Network/Authentication/DatabaseNotFound/Timeout/Configuration/PermissionDenied/SqlServerError/Unknown) + پیام فارسی امن برای هر دسته.
- `SecretRedactor`: پاک‌سازی Password از هر متن لاگ‌شونده؛ `ConnectionSummary`: توصیف ساختاریافتهٔ امن.
- `ConnectionConfigurationException` با پیام فارسی شفاف (نگاشت به ۵۰۳ در میان‌افزار).
- `IDbConnectionFactory.TestConnectionAsync`: آزمون اتصال با CancellationToken و اندازه‌گیری تأخیر.
- Endpoint مدیریتی **`GET /api/v1/admin/connection`** (X-Admin-Key): پیکربندی + آزمون زنده + دستهٔ خطا — بدون هیچ Secret.
- میان‌افزار خطا از دسته‌بندی برای پیام‌های دقیق‌تر استفاده می‌کند.
- تست‌ها: `SqlConnectionProviderTests` (۱۶: پارس هر دو روش، اعمال ReadOnly/AppName، اولویت، ۶ حالت اعتبارسنجی، عدم افشای رمز در Description/Summary، Redactor، ۱۵ نگاشت شمارهٔ خطا→دسته، پیام امن هر دسته) + ۴ تست یکپارچه (ادمین بدون کلید 401؛ خلاصه+آزمون موفق بدون Secret؛ گزارش دستهٔ خطا در شکست اتصال؛ پیکربندی ناقص → ۵۰۳ شفاف).

**Commit:** `783cc07` (2026-11-12 11:54 UTC) — تست: ۱۷۴ PASS

## مرحله E — IdeaSchemaDump v2.0

- گارد مشترک `ReadOnlyCommandGuard` (قاعدهٔ واحد با سرویس) جایگزین regex داخلی ابزار.
- استخراج کامل: جداول/ستون‌ها (+precision/scale/computed)، **PK، FK با نام Constraint، ایندکس‌ها (نوع/یکتا/PK/ستون‌های کلیدی و Included)، ویوها + متن تعریف، Identity Columns، Default Constraintها**، SPها (امضا + متن تعریف فقط با مجوز VIEW DEFINITION) — **هیچ SP اجرا نمی‌شود**.
- خروجی JSON با زمان استخراج + نسخه/سطح/نسخهٔ کامل SQL Server — بدون هیچ اطلاعات اتصال.
- **حالت مقایسه**: `--compare baseline.json current.json` بدون اتصال → diff کامل (جداول/ستون‌ها/نوع‌ها/PK/ویوها/SP/Default) — آزمون عملکردی واقعی با دو گزارش ساختگی انجام شد (تشخیص درست: +۱ جدول، -۱ جدول، ستون اضافه/حذف، PK/SPهای اضافه-حذف).
- تفکیک خطای اتصال با پیام امن در دسته‌های مرحله D.

**Commit:** `4e268aa` (2026-11-12 11:56 UTC)

## مرحله F — ارتقا به .NET 10 LTS

- همهٔ ۸ پروژه: net8.0 → **net10.0** (SDK 10.0.404).
- بسته‌ها: SqlClient 5.2.2→**7.1.1**، Swashbuckle 6.6.2→**11.0.0** (اصلاح API برای OpenApi 3.x: namespace Models حذف شده؛ `OpenApiSecuritySchemeReference` + امضای Func جدید)، Logging.Abstractions 8.0.2→**10.0.15**، Test.Sdk 17.8→**18.12.0**، xunit 2.5.3→**2.9.3**، runner 2.5.3→**4.0.1**، coverlet 6.0.0→**10.1.0**، Mvc.Testing 8.0.10→**10.0.15**.
- **رفع هشدارهای امنیتی NU1902/NU1903** (آسیب‌پذیری شناخته‌شدهٔ وابستگی انتقالی System.Security.Cryptography.Pkcs 9.0.18) با قفل نسخهٔ اصلاح‌شده 9.0.23.
- Build: 0 Error / 0 Warning — هر ۱۷۴ تست روی net10.0 PASS.

**Commit:** `2288bfb` (2026-11-12 12:01 UTC)

## مرحله G — GitHub Actions CI

- `.github/workflows/idealbridge-ci.yml` (تنها فایل خارج از ideal/IdealBridge — الزام GitHub Actions، در قاعدهٔ محدوده لحاظ شد).
- Trigger: push/PR روی شاخهٔ ideal با مسیر ideal/IdealBridge/**.
- گام‌ها: Checkout کامل → Setup .NET 10 → **بررسی محدودهٔ تغییرات** (فقط ideal/IdealBridge و workflow مجاز؛ مبنای مقایسه: PR→base، Push→event.before، fallback→main) → Restore → Build Release → تست‌های واحد → تست‌های یکپارچه → **اسکن سه‌مرحله‌ای Secret** (توکن‌های شناخته‌شده؛ مقدار غیرخالی ConnectionString/Password/AdminKey در appsettings؛ رمز در کد src/tools) → انتشار نتایج trx.
- اسکن Secret با دادهٔ واقعی آزمون شد: False-Positive صفر روی کل سورس؛ تشخیص صحیح توکن تزریقی آزمایشی.
- **نتیجهٔ اجرای واقعی روی GitHub:** `conclusion=success` برای commit `0139bc0` (run 43214285695).

**Commit:** `0139bc0` (2026-11-12 12:02 UTC)

## مرحله H — مستندات، Worklog و Release

- مستندات به‌روز شد: README (net10/SP غیرفعال/روش دوم پیکربندی/endpoint اتصال)، سند ۰۲ (سیاست مرکزی + توکنایزر + نمودار لایه‌ها)، ۰۳ (endpoint مدیریتی + تغییر entityModes)، ۰۴ (.NET 10 + کلیدهای جدید + تست‌ها + CI + انتشار)، ۰۵ (پیکربندی تفکیکی + Windows Auth + دسته‌بندی خطا + خطاهای رایج)، ۰۶ (EXECUTE لازم نیست + VIEW DEFINITION اختیاری).
- WORKLOG: اصلاح تاریخ‌های اشتباه ۲۰۲۵→۲۰۲۶ بر اساس `git log` + همین بخش فاز ۱۱ با SHAهای واقعی.
- Release آزمایشی: انتشار win-x64 با برچسب `dev-11.1.0` (بستهٔ Self-Contained + راهنمای نصب فارسی) — جزئیات در گزارش نهایی مأموریت.

## نتیجهٔ تست نهایی فاز ۱۱ (واقعی، روی net10.0)

```
Passed! - Failed: 0, Passed: 145, Skipped: 0, Total: 145 (IdealBridge.UnitTests)
Passed! - Failed: 0, Passed: 29,  Skipped: 0, Total: 29  (IdealBridge.IntegrationTests)
```
Build: `0 Error(s), 0 Warning(s)` — CI GitHub Actions: **success**.

## فهرست Commitهای فاز ۱۱

| SHA | مرحله | عنوان |
|---|---|---|
| `17c9a87` | B | اصلاح DataAccessMode + حذف کامل مسیر SP + سیاست مرکزی |
| `7b43644` | C | ReadOnlyCommandGuard با توکنایزر T-SQL |
| `783cc07` | D | زیرساخت اتصال SQL Server + دسته‌بندی خطا + endpoint مدیریتی |
| `4e268aa` | E | IdeaSchemaDump v2.0 + حالت مقایسه |
| `2288bfb` | F | ارتقا به .NET 10 LTS + بسته‌ها + رفع NU1902/NU1903 |
| `0139bc0` | G | GitHub Actions CI |
| `3c8976e` | H | مستندات + WORKLOG + Release dev-11.1.0 (Release ID 442892787) |

---

# فاز ۱۱.۱ — Pre-Connection Hardening (۲۰۲۶-۱۱-۱۲)

> دستور مأموریت: رفع ایرادهای باقی‌ماندهٔ بررسی فاز ۱۱، پیش از اتصال به SQL Server واقعی.
> محدوده: اصلاحات مشخص‌شده فقط — بدون اتصال به دیتابیس واقعی، بدون بازنویسی معماری، بدون تغییر Repositoryها، بدون فعال‌سازی SP.

## مرحله B — مدیریت نبود Connection String

- چهار وضعیت صریح `ConnectionStateKind`: **Unconfigured / Configured / Connected / ConnectionFailed** (+ تابع خالص `ComputeState` برای تست واحد هر چهار حالت).
- سازندهٔ `SqlConnectionFactory` **هرگز Crash نمی‌دهد** — نبود/نقص/خرابیِ تنظیمات به‌صورت خطای امن ذخیره و در `ConfigurationError` گزارش می‌شود (پیامِ Connection String ساختارنامعتبر، محتوای رمز را بازتاب نمی‌کند؛ `Summary.Source` = None/Invalid).
- Endpoint مدیریتی `GET /api/v1/admin/connection`: فراخوانی پیش‌فرض **بدون ساخت اجباری Connection** وضعیت را می‌دهد (حتی در Unconfigured = HTTP 200 + state)؛ با `?test=true` آزمون زندهٔ اتصال انجام و State به Connected/ConnectionFailed به‌روز می‌شود (`lastLiveTest` ثبت می‌شود).
- Endpointهای داده و `/health/db` در حالت Unconfigured → **۵۰۳ کنترل‌شده** با پیام دقیق فارسی (نه خطای عمومی/کرش).
- کاوش اسکیما در راه‌اندازی فقط وقتی اتصال قابل استفاده است انجام می‌شود؛ در غیر این صورت هشدار شفاف لاگ می‌شود (سرویس بالا می‌آید).
- تفکیک خطا (Network/Authentication/DatabaseNotFound/Timeout/Configuration/PermissionDenied) از فاز ۱۱ پابرجاست و در `?test=true` گزارش می‌شود.
- تست‌ها: ۷ تست واحد جدید (هر چهار وضعیت؛ ساخت بدون Crash؛ خطای شفاف پیش از هر تلاش شبکه‌ای؛ عدم بازتاب رمز در پیام خطا) + ۴ تست یکپارچهٔ جدید (سرویس بدون اتصال بالا می‌آید؛ گزارش Unconfigured از endpoint مدیریتی؛ ۵۰۳ کنترل‌شده؛ ?test=true در Unconfigured) + به‌روزرسانی ۲ تست قبلی به قرارداد جدید (?test=true).

**Commit:** `972642b` — تست: ۱۸۵ PASS

## مرحله C — امنیت IdeaSchemaDump (v2.1)

- **حذف کامل آرگومان `--connection`** — دریافت Connection String از خط فرمان (هر شکل: مقدار جدا، `--connection=x`، حروف بزرگ/کوچک) صریحاً و با پیام راهنما رد می‌شود (رمز در Process Arguments/تاریخچهٔ ترمینال افشا می‌شد).
- منبع یکتای اتصال: متغیر محیطی `IdealBridge__ConnectionString` (کلاس جدید `SchemaDumpPolicy`).
- بستن مسیرهای دورزدن: فلگ ناشناخته و آرگومان موقعیتی قاچاقی هم رد می‌شوند (فقط `--compare`/`--out` با مقادیرشان مجازند)؛ متن آرگومان‌ها هرگز در پیام خطا بازتاب نمی‌شود.
- **اجبار `ApplicationIntent=ReadOnly` + `Encrypt=True` + `ApplicationName=IdeaSchemaDump`** در خود ابزار (حتی اگر مقدار محیطی چیز دیگری بگوید).
- هیچ Connection String/رمز/Secret در پیام خطا یا لاگ بازتاب نمی‌شود؛ نبود متغیر محیطی → پیام خطای راهنما با مثال PowerShell و CMD (کد خروج ۲).
- تست‌ها: ۱۲ تست واحد جدید (رد همهٔ اشکال خط فرمان؛ رد فلگ ناشناخته/موقعیتی؛ مجازبودن compare/out؛ نبود env → راهنما؛ اجبار ReadOnly/Encrypt؛ عدم افشای رمز) + آزمون عملکردی واقعی خود ابزار (رد --connection و نبود env هر دو با کد خروج ۲؛ حالت compare بدون اتصال سالم).

**Commit:** `c28e2b1` — تست: ۱۹۷ PASS

## مرحله D — گارد فقط-خواندنی: رد NEXT VALUE FOR

- قاعدهٔ جدید: عبارت **`NEXT VALUE FOR`** (افزایش Sequence = تغییر state دیتابیس) رد می‌شود.
- تشخیص با **تطبیق دنبالهٔ توکن** (سه واژهٔ برهنهٔ متوالی NEXT+VALUE+FOR) — نه جست‌وجوی متنی ساده: کامنت بین واژه‌ها مانع تشخیص نمی‌شود (کامنت‌ها از قبل حذف‌اند)، فاصله/تب/خط جدید بی‌اثر است.
- **بدون مثبت کاذب:** متن داخل رشته/کامنت، ستون‌های به نام NEXT/VALUE، واژهٔ پیوستهٔ NEXTVALUEFOR و FOR XML/JSON مجاز می‌مانند.
- تمام ۱۰۷ تست گزارمانی قبلی + جدید PASS (۲۲ مورد جدید).

**Commit:** `51d0d5e` — تست: ۲۱۹ PASS

## مرحله E — سند ۰۶: سیاست نهایی فقط-خواندنی SQL Server

- حذف کامل GRANT EXECUTE و آموزش اجرای SP؛ `EXEC sp_helptext` → `SELECT` روی `sys.sql_modules` (بدون EXEC).
- حذف اسکریپت قدیمی CURSOR + `sp_executesql` → تولید «متن» دستورهای GRANT قابل بازبینی.
- حذف توصیهٔ اجرا با حساب sysadmin؛ ممنوعیت صریح sa/Administrator/حساب اصلی Ideal به‌عنوان حساب سرویس.
- سیاست نهایی مستند: فقط SELECT روی جداول/ویوهای موردنیاز + VIEW DEFINITION اختیاری برای فراداده — **بدون EXECUTE و بدون هیچ مجوز نوشتنی**.
- جست‌وجوی کل مستندات: **صفر** تناقض باقی‌مانده (GRANT EXECUTE/sp_executesql/sp_helptext/توصیهٔ sa).

**Commit:** `c1c5aca`

## مرحله F — مستندات روش اجرای ابزار و وضعیت‌های اتصال

- حذف تمام دستورهای `--connection` از مستندات (۰۴/۰۵/۰۹/README) → روش متغیر محیطی با **مثال‌های جداگانهٔ PowerShell و CMD** + هشدار عدم قرارگیری رمز در Git/فایل عمومی/Screenshot/Log.
- سند ۰۳: مدل چهار وضعیت endpoint مدیریتی + `?test=true` + رفتار ۵۰۳ در Unconfigured.
- سند ۰۴: جدول متغیرهای محیطی اصلاح (پیش‌فرض DataAccessMode=Table، Sp رد می‌شود، رفتار بدون Connection String) + مثال CMD.
- سند ۰۵: ردیف خطای Unconfigured در جدول خطاهای رایج + توضیح چهار وضعیت.
- سند ۰۲ + README: گارد NEXT VALUE FOR + چهار وضعیت اتصال + ?test=true.

**Commit:** `8acdca0`

## انتشار

- Release **`dev-11.1.1`** — win-x64 Self-Contained (net10.0) + راهنمای نصب فارسی INSTALL-FA.md؛ بدون هیچ رمز/Connection String واقعی (تأییدشده با اسکن).

## نتیجهٔ تست نهایی فاز ۱۱.۱ (واقعی، روی net10.0)

```
Passed! - Failed: 0, Passed: 186, Skipped: 0, Total: 186 (IdealBridge.UnitTests)
Passed! - Failed: 0, Passed:  33, Skipped: 0, Total:  33 (IdealBridge.IntegrationTests)
```

Build: `0 Error(s), 0 Warning(s)` — CI GitHub Actions: **success** برای هر پنج commit فاز (972642b، c28e2b1، 51d0d5e، c1c5aca، 8acdca0).

## فهرست Commitهای فاز ۱۱.۱

| SHA | مرحله | عنوان |
|---|---|---|
| `972642b` | B | مدیریت نبود Connection String — چهار وضعیت + endpoint مدیریتی بدون اتصال اجباری |
| `c28e2b1` | C | امنیت IdeaSchemaDump — حذف --connection + env-var + اجبار ReadOnly/Encrypt |
| `51d0d5e` | D | گارد: رد NEXT VALUE FOR با تطبیق دنبالهٔ توکن |
| `c1c5aca` | E | سند ۰۶ — سیاست نهایی بدون EXECUTE |
| `8acdca0` | F | مستندات — روش env-var ابزار + وضعیت‌های اتصال |
| `(این commit)` | G | WORKLOG فاز ۱۱.۱ + اصلاح تاریخ عنوان فاز ۱۰ (۲۰۲۵→۲۰۲۶) |
