# IdealBridge — پل فقط-خواندنی Ideal CRM ↔ MedPad

> سرویس API مستقل برای خواندن ایمن داده‌های **نرم‌افزار Ideal CRM** و تحویل آن به **MedPad** — بدون هیچ عملیات نوشتن روی دیتابیس Ideal.

| | |
|---|---|
| شاخهٔ توسعه | `ideal` (مستقل از کد رستا) |
| مسیر | `ideal/IdealBridge/` |
| پشته | **.NET 10 (LTS)** · ASP.NET Core · ADO.NET (SqlClient 7) · Swagger · xUnit |
| دیتابیس | فقط **SELECT** روی SQL Server نرم‌افزار Ideal (حساب فقط-خواندنی) |
| احراز هویت | توکن مستقل (`ibk_...`) با انقضا و ابطال — جدا از احراز هویت Ideal |
| سازگاری | نسخهٔ نصب‌شدهٔ **3.1.16.169.0303** و سورس **3.1.18.187** — با کاوش خودکار سازگار می‌شود |
| سیاست دسترسی (فاز ۱۱) | حالت پیش‌فرض `Table` — **اجرای Stored Procedure به‌کلی غیرفعال** و گارد فقط-خواندنی با توکنایزر T-SQL |
| CI | GitHub Actions روی شاخهٔ `ideal` — Build + ۱۷۴ تست + اسکن Secret |

---

## شروع سریع (۵ دقیقه)

### پیش‌نیاز
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- دسترسی شبکه به SQL Server نرم‌افزار Ideal
- حساب SQL فقط-خواندنی (`ibk_reader`) — [ساخت در ۲ دقیقه](docs/06-sql-readonly-login.md)

### روش‌های پیکربندی اتصال (یکی از دو)

**روش ۱ — Connection String کامل** (متغیر محیطی؛ هرگز در فایل):

```powershell
[Environment]::SetEnvironmentVariable("IdealBridge__ConnectionString", "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True", "User")
```

**روش ۲ — تنظیمات تفکیکی** (`IdealBridge:Sql` — رمز باز هم فقط از متغیر محیطی):

```powershell
[Environment]::SetEnvironmentVariable("IdealBridge__Sql__Server", "SQLSRV\IDEAL", "User")
[Environment]::SetEnvironmentVariable("IdealBridge__Sql__Database", "CRM", "User")
[Environment]::SetEnvironmentVariable("IdealBridge__Sql__AuthMode", "Sql", "User")        # یا Windows
[Environment]::SetEnvironmentVariable("IdealBridge__Sql__UserId", "ibk_reader", "User")
[Environment]::SetEnvironmentVariable("IdealBridge__Sql__Password", "***", "User")
```

تفصیل کامل (Encrypt/TrustServerCertificate/ConnectTimeout/Windows Auth): [سند ۰۵](docs/05-sql-server-connection.md)

### مراحل

```powershell
# ۱) دریافت و Build

git clone -b ideal https://github.com/P3D4AM/Rasta.git
cd Rasta\ideal\IdealBridge
dotnet build IdealBridge.sln -c Release

# ۲) Secretها (فقط متغیر محیطی — هرگز در فایل/Git) — از بالا (روش ۱ یا ۲)
[Environment]::SetEnvironmentVariable("IdealBridge__AdminKey", "کلید-ادمین-قوی", "User")

# ۳) (پیشنهادی) کاوش ساختار دیتابیس واقعی قبل از اجرا — خروجی JSON کامل + مقایسهٔ دو نسخه
dotnet run --project tools/IdeaSchemaDump -- --connection "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"

# ۴) اجرا
$env:ASPNETCORE_URLS = "http://0.0.0.0:5100"
dotnet run --project src/IdealBridge.Api -c Release

# ۵) ساخت توکن برای MedPad (در پنجرهٔ دیگر)
$resp = Invoke-RestMethod -Method Post -Uri "http://localhost:5100/api/v1/tokens" `
  -ContentType "application/json" -Headers @{ "X-Admin-Key" = $env:IdealBridge__AdminKey } `
  -Body '{"name":"MedPad-Integration","expiresInDays":90}'
$resp.data.token   # ذخیره کنید — فقط یک‌بار نمایش داده می‌شود

# ۶) تست
Invoke-RestMethod -Uri "http://localhost:5100/api/v1/companies?pageSize=5" -Headers @{ "X-API-Key" = $resp.data.token }

# ۷) وضعیت اتصال (ادمین — بدون نیاز به توکن داده)
Invoke-RestMethod -Uri "http://localhost:5100/api/v1/admin/connection" -Headers @{ "X-Admin-Key" = $env:IdealBridge__AdminKey }
```

معادل Linux: [سند ۰۸](docs/08-run-linux.md) — استقرار پایدار Windows: [سند ۰۷](docs/07-run-windows.md).

---

## Endpointهای اصلی (همه با هدر `X-API-Key`)

| گروه | Endpointها |
|---|---|
| مشتریان | `GET /api/v1/companies` · `/{id}` · `/{id}/addresses` — فیلتر کد/نام/شماره/بازهٔ ثبت/بازاریاب/پیش‌نویس |
| اشخاص | `GET /api/v1/persons` · `/{id}` |
| کاربران CRM | `GET /api/v1/users` · `/{id}` — **بدون رمز عبور** |
| مکالمات | `GET /api/v1/conversations` |
| پروژه‌ها | `GET /api/v1/projects` |
| یادآوری‌ها | `GET /api/v1/reminders?userId=` |
| انبار/محصول/سفارش | `GET /api/v1/warehouses` · `/products` · `/orders` · `/preorders` |
| اطلاعات پایه | `GET /api/v1/baseinfo/{city|province|companygroup|...}` |
| همگام‌سازی | `GET /api/v1/sync/companies|persons|conversations` — Keyset با `afterId` |
| سلامت | `GET /health/live` (عمومی) · `GET /health/db` (توکن‌دار — گزارش سازگاری اسکیما + حالت هر موجودیت) |
| مدیریت توکن | `POST/GET/DELETE /api/v1/tokens` (با هدر `X-Admin-Key`) |
| وضعیت اتصال | `GET /api/v1/admin/connection` (با هدر `X-Admin-Key` — خلاصهٔ پیکربندی + آزمون زنده + دستهٔ خطا، بدون رمز) |

مستند کامل: [سند ۰۳](docs/03-endpoints.md) — مستند زندهٔ تعاملی: `http://<host>:5100/swagger`

پاکت پاسخ یکنواخت:

```json
{
  "data": [ ... ],
  "status": "Success",
  "message": "عملیات با موفقیت انجام شد.",
  "pagination": { "page": 1, "pageSize": 50, "hasMore": true, "nextAfterId": 100, "nextPageUrl": "..." }
}
```

---

## فقط-خواندنی: دو لایهٔ دفاعی

1. **کد (فاز ۱۱ — توکنایزر T-SQL):** `ReadOnlyCommandGuard` هر دستور را پیش از اجرا «توکن‌بندی» می‌کند (رشته/کامنت/براکت درست پارس می‌شود) و فقط یک `SELECT`/`WITH` تک‌دستوری بدون هیچ واژهٔ تغییردهنده (از جمله `INTO` و `SET`) مجاز است؛ **هیچ Stored Procedure — حتی با نام شناخته‌شده — اجرا نمی‌شود** و گارد در Production غیرقابل خاموش‌کردن است. اتصال همیشه با `ApplicationIntent=ReadOnly`.
2. **SQL Server:** حساب `ibk_reader` فقط `db_datareader` — حتی خطای برنامه‌نویسی هم قابل نوشتن نیست. [راهنمای ساخت](docs/06-sql-readonly-login.md).

نمونه‌های خروجی هرگز رمز عبور Ideal (کاربر/مشتری/شخص) ندارند — ستون‌های حساس حتی در SELECT نمی‌آیند.

## سازگاری نسخهٔ Ideal

نسخهٔ نصب‌شدهٔ شما (3.1.16.169.0303) با نسخهٔ سورس بررسی‌شده (3.1.18.187) **فرق دارد**؛ IdealBridge فرض یکسانی نمی‌کند:

- در راه‌اندازی، جدول‌ها/ستون‌ها/امضای SPها را با کوئری‌های فراداده (فقط `sys.*`) کاوش می‌کند؛
- هر موجودیت را با بهترین حالت در دسترس سرویس می‌دهد: `Sp` (خروجی غنی SPهای Ideal) یا `Table` (SELECT مستقیم روی ستون‌های پایدارِ هسته)؛
- نتیجه را در `/health/db` شفاف گزارش می‌کند؛
- صفحه‌بندی هرگز به پارامترهای SP وابسته نیست (این پارامترها احتمالاً در 3.1.16 وجود ندارند).

جزئیات کامل و ریسک‌ها: [سند ۰۹ — گزارش سازگاری](docs/09-version-compatibility.md).

## همگام‌سازی MedPad

دیتابیس Ideal ستون «آخرین تغییر» ندارد؛ الگوی پیشنهادی: **دریافت افزایشیِ جدید‌ها با پنجرهٔ ثبت + Snapshot دوره‌ای برای کشف ویرایش/حذف + پیمایش Keyset قابل ازسرگیری**. سند کامل: [۱۰ — طراحی همگام‌سازی](docs/10-sync-design.md). هیچ دادهٔ ساختگی تولید نمی‌شود.

## ساختار پروژه

```
ideal/IdealBridge/
├── IdealBridge.sln
├── src/  Domain (DTO) · Application (قراردادها) · Security (توکن) · Infrastructure (دیتابیس فقط-خواندنی) · Api (کنترلرها)
├── tests/ UnitTests (36) · IntegrationTests (22)
├── tools/ IdeaSchemaDump (کاوشگر مستقل فراداده)
└── docs/ 11 سند فنی
```

```powershell
dotnet test IdealBridge.sln -c Release   # 58 تست — همه باید PASS باشند
```

## مستندات کامل

| سند | موضوع |
|---|---|
| [۰۱](docs/01-ideal-api-reverse-engineering.md) | مهندسی معکوس API اصلی Ideal (SPها، احراز هویت، جداول) |
| [۰۲](docs/02-architecture.md) | معماری IdealBridge و تصمیم‌های فنی |
| [۰۳](docs/03-endpoints.md) | مرجع کامل Endpointها |
| [۰۴](docs/04-installation.md) | نصب و راه‌اندازی |
| [۰۵](docs/05-sql-server-connection.md) | یافتن و ساخت اتصال SQL Server |
| [۰۶](docs/06-sql-readonly-login.md) | ساخت SQL Login فقط-خواندنی |
| [۰۷](docs/07-run-windows.md) | اجرا در Windows (سرویس/IIS) |
| [۰۸](docs/08-run-linux.md) | اجرا در Linux (systemd/Nginx) |
| [۰۹](docs/09-version-compatibility.md) | گزارش سازگاری 3.1.16 ↔ 3.1.18.187 |
| [۱۰](docs/10-sync-design.md) | طراحی همگام‌سازی MedPad |
| [۱۱](docs/11-swagger.md) | مستند Swagger/OpenAPI |
| [WORKLOG](docs/WORKLOG.md) | گزارش فازها، تست‌ها و Commitها |

## امنیت در یک نگاه

- توکن‌های ۲۵۶ بیتی (`ibk_...`)؛ فقط هش SHA-256 در `tokens.json`؛ انقضا + ابطال فوری.
- مدیریت توکن با کلید ادمین از متغیر محیطی — مقایسهٔ زمان-ثابت.
- Rate limit: ۱۲۰ درخواست/دقیقه/توکن (صف ۳۰).
- لاگ هر درخواست: زمان + نتیجه + پیشوند توکن (بدون مقدار توکن).
- خطاهای SQL هرگز با جزئیات داخلی به بیرون نمی‌روند (پیام عمومی + 503).
- رمزنگاری قدیمی Ideal (TripleDES/کلید هاردکد) بازاستفاده نشده.
