# معماری IdealBridge

> سند ۰۲ — معماری فنی سرویس پل Ideal CRM ↔ MedPad

## ۱. جایگاه در معماری کلی

```
┌──────────────────┐      ┌───────────────────┐      ┌────────────────────────┐      ┌────────────────┐
│  Ideal CRM        │      │  Ideal Bridge API  │      │  MedPad Integration     │      │  MedPad         │
│  (SQL Server)     │◄─────│  (این پروژه)       │◄─────│  Service (خارج از این   │◄─────│  Database       │
│  دیتابیس واقعی    │ فقط  │  فقط-خواندنی       │ HTTPS│  مأموریت — فقط قرارداد) │      │  (مستقل)        │
│  نسخهٔ 3.1.16      │ SELECT│  ASP.NET Core 8   │ Token│                        │      │                │
└──────────────────┘      └───────────────────┘      └────────────────────────┘      └────────────────┘
```

- IdealBridge **فقط می‌خواند** — دو لایهٔ دفاعی: گارد دستور در کد + مجوز SELECT-only در SQL Server.
- MedPad داده را دریافت و در دیتابیس مستقل خودش ذخیره می‌کند؛ هرگز در لحظهٔ نمایش به Ideal وابسته نیست.

## ۲. پشتهٔ فناوری و دلیل انتخاب‌ها

| فناوری | انتخاب | دلیل |
|---|---|---|
| فریم‌ورک | ASP.NET Core 8 (LTS تا نوامبر ۲۰۲۶) | پشتیبانی بلندمدت، اجرای Windows/Linux |
| دسترسی داده | **ADO.NET خالص** (Microsoft.Data.SqlClient) | برخلاف EF Core: بدون Change-Tracker، بدون Migration، بدون هیچ مسیر نوشتن احتمالی؛ کنترل دقیق روی هر دستور؛ فراخوانی SP و SELECT پارامتری |
| EF Core | **استفاده نشد — عمداً** | قابلیت‌های Migration/SaveChanges ریسک نوشتن روی دیتابیس Ideal هستند و برای خواندن خالص لازم نیستند (حکم بخش ۵ مأموریت: «در صورت مناسب بودن») |
| مستندسازی | Swashbuckle (Swagger/OpenAPI 3) | مستند زنده و قابل تست |
| احراز هویت | Handler اختصاصی `IdealBridgeToken` | توکن مستقل با انقضا/ابطال — جدا از احراز هویت Ideal |
| لاگ | ILogger ساختاری + میان‌افزار درخواست | زمان + نتیجه + پیشوند توکن (بدون مقدار توکن) |
| تست | xUnit + WebApplicationFactory + دوقلوی ADO.NET | بدون نیاز به SQL Server واقعی |

## ۳. لایه‌بندی پروژه

```
IdealBridge.sln
├── src/
│   ├── IdealBridge.Domain          # DTOها و پاکت پاسخ — بدون وابستگی
│   │   ├── Common/ApiResponse.cs   # { data, status, message, pagination }
│   │   ├── Common/Pagination.cs    # PagedQuery (page/pageSize/afterId) + PaginationInfo
│   │   └── Dto/                    # CompanyDto, CompanyPersonDto, CrmUserDto, ...
│   ├── IdealBridge.Application     # قراردادها (اینترفیس مخازن + SchemaReport)
│   ├── IdealBridge.Security        # TokenService + IdealBridgeAuthHandler
│   ├── IdealBridge.Infrastructure  # اتصال فقط-خواندنی
│   │   ├── Database/SqlConnectionFactory.cs   # نقطهٔ ساخت اتصال (ApplicationIntent.ReadOnly)
│   │   ├── Database/ReadOnlyCommandGuard.cs   # گارد توکنایزر T-SQL (فقط SELECT تک‌دستوری)
│   │   ├── Database/IdealDb.cs                # اجراکنندهٔ یکپارچهٔ گارد‌شده
│   │   ├── Database/SchemaProbe.cs            # کاوش فراداده + انتخاب حالت Auto/Sp/Table
│   │   └── Repositories/                      # پیاده‌سازی مخازن دو-حالته
│   └── IdealBridge.Api             # Controllers + Middleware + Program
├── tests/
│   ├── IdealBridge.UnitTests       # گارد، توکن، صفحه‌بندی
│   └── IdealBridge.IntegrationTests# HTTP کامل با دوقلوی ADO.NET
└── tools/
    └── IdeaSchemaDump              # ابزار مستقل استخراج فراداده (فقط-خواندنی)
```

## ۴. مدل دسترسی دادهٔ دو-حالته

هر موجودیت با یکی از دو حالت خوانده می‌شود:

| حالت | مکانیزم | مزیت | ریسک نسخه |
|---|---|---|---|
| **Table** (پیش‌فرض Auto در صورت سالم بودن جدول) | SELECT پارامتری مستقیم روی جدول‌های هسته + JOIN جدول‌های مرجع | ستون‌های هسته از نسخه‌های خیلی قدیمی پایدارند | پایین |
| **Sp** | فراخوانی SPهای `ApispSelect*` (فهرست سفید) | خروجی غنی‌تر (نام‌های ترجمه‌شده، JSON-پارس‌شده) | بالاتر — امضای SP بین نسخه‌ها تغییر کرده (۱۰ بازنگری برای ApispSelectCompany) |

انتخاب در زمان راه‌اندازی توسط `SchemaProbe` انجام می‌شود:
1. اتصال بررسی می‌شود (`SELECT @@SERVERNAME, DB_NAME(), @@VERSION`).
2. جدول‌ها/ستون‌های موردانتظار از `sys.tables`/`sys.columns` کنترل می‌شوند.
3. امضای SPها با `sys.procedures`/`sys.parameters` با امضای مرجع (نسخهٔ 3.1.18.187) مقایسه می‌شود.
4. `DataAccessModeSelector` حالت هر موجودیت را بر اساس تنظیم `Auto|Table|Sp` تعیین می‌کند و نتیجه در `/health/db` گزارش می‌شود.

نتیجهٔ کاوش در لاگ راه‌اندازی و endpoint سلامت دیده می‌شود — بدون حدس‌زدن نام دیتابیس یا فرض یکسانی نسخه‌ها.

## ۵. مدل امنیتی

```
درخواست ──► RateLimiter (120/min + صف 30)
        ──► IdealBridgeAuthHandler (X-API-Key یا Bearer)
        │     ├─ توکن؟ → SHA-256 → جستجو در tokens.json
        │     ├─ منقضی/ابطال‌شده؟ → 401
        │     └─ معتبر؟ → Claims (id, name, scope, prefix)
        ──► Controller [Authorize]
        ──► IdealDb → ReadOnlyCommandGuard → SQL Server (لاگین SELECT-only)
```

- **توکن‌ها:** ۲۵۶ بیت تصادفی با پیشوند `ibk_`؛ فقط هش SHA-256 در `tokens.json` ذخیره می‌شود؛ ساخت/ابطال فقط با `X-Admin-Key` (متغیر محیطی).
- **حساس‌ها:** Connection String و AdminKey فقط از Environment Variable/Secret خوانده می‌شوند؛ هرگز در Git/لاگ/پاسخ نیستند.
- **بدون افشای خطای SQL:** میان‌افزار خطا، خطاهای `DbException` را به پیام عمومی + 503 تبدیل می‌کند؛ جزئیات فقط در لاگ داخلی.
- **ستون‌های حساس:** `Password`/`cmpPassword`/`prsPassword` در هیچ DTO نیستند؛ در حالت Table حتی در SELECT نمی‌آیند؛ در حالت SP در نگاشت حذف می‌شوند.

## ۶. پاکت پاسخ یکنواخت

```json
{
  "data": [ ... ],
  "status": "Success",
  "message": "عملیات با موفقیت انجام شد.",
  "pagination": {
    "page": 1,
    "pageSize": 20,
    "totalCount": null,
    "hasMore": true,
    "nextAfterId": 40,
    "nextPageUrl": "/api/v1/companies?afterId=40&pageSize=20"
  }
}
```

`status` رشته است (`Success|Fail|Error`) — سازگار با `ServiceResultStatus` قدیمی Ideal؛ تفاوت‌های ساختاری (فیلدهای ApiRowNumber/ApiTotalCount درون رکورد قدیمی → بلوک pagination جدا) در همین لایهٔ Adapter جذب شده است.

## ۷. صفحه‌بندی و همگام‌سازی

- **صفحه‌ای:** `?page=2&pageSize=50` → `OFFSET/FETCH` پارامتری.
- **Keyset (پیشنهادی برای MedPad):** `?afterId=40&pageSize=100` → `WHERE id > @afterId ORDER BY id` — پایدار در برابر تغییر دادهٔ هم‌زمان، قابل ازسرگیری پس از قطع ارتباط.
- جزئیات کامل استراتژی همگام‌سازی (شامل محدودیت نبود ستون LastModified و راه‌حل Snapshot) در سند ۱۰.

## ۸. تصمیم‌های کلیدی ثبت‌شده

| # | تصمیم | دلیل |
|---|---|---|
| D1 | ADO.NET به‌جای EF Core | حذف کامل مسیرهای نوشتن + کنترل پارامتری دقیق |
| D2 | دو حالت Table/Sp + کاوش امضا | تفاوت نسخهٔ نصب‌شده (3.1.16) با سورس (3.1.18.187) |
| D3 | صفحه‌بندی Keyset مستقل | پارامترهای صفحه‌بندی SP احتمالاً در 3.1.16 وجود ندارند (بعد از SOH14050222) |
| D4 | فایل JSON برای توکن‌ها | سرویس بدون وابستگی به دیتابیس جانبی قابل استقرار بماند |
| D5 | Swagger در Production هم روشن (قابل خاموش‌کردن) | سرویس شبکهٔ داخلی است؛ مستند زنده مهم‌تر |
| D6 | عدم بازاستفاده از رمزنگاری Ideal | TripleDES با کلید هاردکد «I Love GOD» — حکم منع مأموریت |

---

## فاز ۱۱ — تغییرات معماری مهم

### ۱. سیاست مرکزی دسترسی به داده (`DataAccessPolicy`)

جایگزین `SchemaModeProvider`/`DataAccessModeSelector` قدیمی شد. تنها مرجع تصمیم برای همهٔ Repositoryها:

- مقدار پیش‌فرض `IdealBridge:DataAccessMode` = **`Table`** (قبلاً Auto).
- مقادیر مجاز: `Table` | `Auto` (معادل Table در این نسخه). مقدار `Sp` **در راه‌اندازی با خطای واضح رد می‌شود**.
- **مسیر اجرای Stored Procedure به‌کلی از کد حذف شد** (`IdealDb.QuerySpAsync` ندارد؛ مخازن مسیر SP ندارند؛ گارد هر `CommandType.StoredProcedure` را می‌بندد) — تا بازبینی بدنهٔ SPهای واقعی و تأیید مجوزها در فازهای بعد.
- اگر جدول پشتیبان موجودیت مفقود/ناقص باشد → موجودیت `Blocked` و هر درخواست **خطای شفاف ۵۰۳** می‌گیرد (`DataAccessUnavailableException`) — رفع باگ تاریخی «آرایهٔ خالی بی‌صدا».
- تست‌های ساختاری ضد-بازگشت (`SourceStructureRegressionTests`) از بازگشت هر دو رده باگ جلوگیری می‌کنند.

### ۲. گارد فقط-خواندنی با توکنایزر T-SQL

`ReadOnlyCommandGuard` بازنویسی شد — به‌جای جست‌وجوی رشته‌ای، متن دستور **توکن‌بندی** می‌شود (رشته‌ها، کامنت‌ها، شناسه‌های `[براکت‌دار]` درست تشخیص داده می‌شوند):
- هیچ SP (حتی با نام معتبر) مجاز نیست — فهرست سفید قبلی حذف شد؛
- فقط یک دستور `SELECT`/`WITH`؛ `;` و `GO` ممنوع؛
- واژه‌های `INTO` (SELECT INTO)، `SET`، `WAITFOR`، `OPENROWSET` و `sp_*`/`xp_*` هم ممنوع؛
- فاز ۱۱.۱: عبارت `NEXT VALUE FOR` (افزایش Sequence = تغییر state) با تطبیق دنبالهٔ توکن ممنوع — بدون مثبت کاذب روی متن رشته/کامنت؛
- `ReadOnlyGuardPolicy`: در **Production** گارد غیرقابل خاموش‌کردن است (تنظیم `EnforceReadOnlyGuard=false` نادیده و لاگ می‌شود).

### ۳. زیرساخت اتصال (فاز ۱۱)

- دو روش پیکربندی: `ConnectionString` کامل یا بخش تفکیکی `IdealBridge:Sql` (با `Sql`/`Windows` Auth).
- همیشه: `ApplicationName=IdealBridge` + `ApplicationIntent=ReadOnly` + مهلت اتصال.
- فاز ۱۱.۱: کارخانهٔ اتصال بدون Connection String هم ساخته می‌شود (وضعیت `Unconfigured`) — سرویس بالا می‌آید، endpointهای داده ۵۰۳ کنترل‌شده می‌دهند و هیچ Crash رخ نمی‌دهد.
- `SqlConnectionErrorClassifier`: دسته‌بندی خطا (Network/Authentication/DatabaseNotFound/Timeout/Configuration/PermissionDenied/SqlServerError) با پیام فارسی امن.
- `SecretRedactor`: رمز هرگز وارد لاگ نمی‌شود.
- endpoint مدیریتی `GET /api/v1/admin/connection` (X-Admin-Key): چهار وضعیت (Unconfigured/Configured/Connected/ConnectionFailed) + خلاصهٔ امن پیکربندی؛ فراخوانی پیش‌فرض هیچ اتصالی برقرار نمی‌کند، آزمون زنده با `?test=true`.

### ۴. پشته

ارتقا به **.NET 10 LTS** (+ SqlClient 7.1.1 / Swashbuckle 11 / Mvc.Testing 10). CI در `.github/workflows/idealbridge-ci.yml`.

### ۵. نمودار لایه‌ها (پس از فاز ۱۱)

```
MedPad ──X-API-Key──▶ Api (Controllers/Middleware)
                        │  IDataAccessPolicy (مرکزی: Table|Blocked — SP غیرفعال)
                        ▼
                     Application (IRepositories)
                        ▼
                     Infrastructure: IdealDb ──ReadOnlyCommandGuard(توکنایزر)──▶ SqlCommand (فقط Text/SELECT)
                        ▼
                     SqlConnectionFactory (ReadOnly intent + Auth + Timeout) ──▶ Ideal SQL Server (ibk_reader: db_datareader)
```
