# راهنمای نصب و راه‌اندازی IdealBridge

> سند ۰۴ — از صفر تا سرویس در حال اجرا

## پیش‌نیازها

| نیاز | حداقل | توضیح |
|---|---|---|
| .NET SDK | 8.0 | فقط برای build؛ برای اجرا **ASP.NET Core Runtime 8.0** کافی است |
| دسترسی شبکه | به SQL Server نرم‌افزار Ideal | پورت 1433 (و 1434/UDP برای Instance نام‌دار) |
| حساب SQL | `ibk_reader` فقط-خواندنی | سند ۰۶ |
| سیستم‌عامل | Windows Server 2016+ / Windows 10+ / Linux | سند ۰۷ و ۰۸ |

## ۱) دریافت سورس

```powershell
# PowerShell
git clone -b ideal https://github.com/P3D4AM/Rasta.git
cd Rasta\ideal\IdealBridge
```

```bash
# Linux
git clone -b ideal https://github.com/P3D4AM/Rasta.git
cd Rasta/ideal/IdealBridge
```

## ۲) Build

```powershell
# PowerShell
dotnet build IdealBridge.sln -c Release
```

```bash
# Linux
dotnet build IdealBridge.sln -c Release
```

خروجی موفق: `Build succeeded. 0 Error(s)`.

## ۳) تنظیم Secretها (بدون فایل!)

> **قانون طلایی:** رمز واقعی هرگز در فایل کامیت‌شده، فایل عمومی، Screenshot یا Log قرار نمی‌گیرد — فقط متغیر محیطی / Secret Store.

> فاز ۱۱.۱: سرویس «بدون» Connection String هم بالا می‌آید (وضعیت `Unconfigured` از `GET /api/v1/admin/connection`) — endpointهای داده تا تنظیم اتصال پاسخ ۵۰۳ کنترل‌شده می‌دهند. برای دسترسی واقعی به داده، اتصال الزامی است.

حداقل دو متغیر محیطی لازم است:

```powershell
# PowerShell — ماندگار برای کاربر جاری
[Environment]::SetEnvironmentVariable("IdealBridge__ConnectionString", "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True", "User")
[Environment]::SetEnvironmentVariable("IdealBridge__AdminKey", "یک-کلید-ادمین-قوی-یکتا", "User")
```

```bat
REM CMD — ماندگار برای کاربر جاری (پس از setx پنجرهٔ جدید باز کنید)
setx IdealBridge__ConnectionString "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"
setx IdealBridge__AdminKey "یک-کلید-ادمین-قوی-یکتا"
```

```bash
# Linux (bash) — برای نشست جاری؛ برای ماندگاری در ~/.bashrc بگذارید
export IdealBridge__ConnectionString='Server=sqlsrv;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True'
export IdealBridge__AdminKey='یک-کلید-ادمین-قوی-یکتا'
```

| متغیر | الزامی | نقش |
|---|---|---|
| `IdealBridge__ConnectionString` | ✔ (برای داده) | اتصال فقط-خواندنی به دیتابیس Ideal (سند ۰۵) — بدون آن سرویس بالا می‌آید ولی endpointهای داده ۵۰۳ می‌دهند |
| `IdealBridge__AdminKey` | ✔ (برای مدیریت توکن) | کلید ساخت/ابطال توکن‌ها |
| `IdealBridge__DataAccessMode` | ✖ (پیش‌فرض `Table`) | `Table` / `Auto` (معادل Table) — مقدار `Sp` در راه‌اندازی رد می‌شود (اجرای SP غیرفعال) |
| `IdealBridge__TokenStorePath` | ✖ (پیش‌فرض `tokens.json`) | مسیر ذخیرهٔ توکن‌ها |
| `IdealBridge__EnableSwagger` | ✖ (پیش‌فرض `true`) | خاموش‌کردن Swagger در Production |
| `ASPNETCORE_URLS` | ✖ | مثلاً `http://0.0.0.0:5100` |

## ۴) کاوش ساختار دیتابیس واقعی (قبل از اولین اجرا)

ابزار `IdeaSchemaDump` از فاز ۱۱.۱ Connection String را «فقط از متغیر محیطی» می‌خواند — دریافت آن از خط فرمان حذف و صریحاً ممنوع شده است (رمز در Process Arguments و تاریخچهٔ ترمینال افشا می‌شد). خود ابزار هم `ApplicationIntent=ReadOnly` و `Encrypt=True` را اجباری می‌کند.

**PowerShell:**

```powershell
# ۱) تنظیم امن Connection String (ماندگار برای کاربر جاری — فقط یک‌بار)
[Environment]::SetEnvironmentVariable("IdealBridge__ConnectionString", "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True", "User")

# ۲) اجرای ابزار — بدون هیچ Secret در خط فرمان
dotnet run --project tools/IdeaSchemaDump -- --out schema-report.json
```

**CMD:**

```bat
REM ۱) تنظیم امن (پس از setx پنجرهٔ جدید باز کنید)
setx IdealBridge__ConnectionString "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"

REM ۲) اجرای ابزار — بدون هیچ Secret در خط فرمان
dotnet run --project tools/IdeaSchemaDump -- --out schema-report.json
```

> هشدار: رمز واقعی نباید در Git، فایل‌های عمومی، Screenshot یا Log قرار گیرد. اگر رمزی در خط فرمان تایپ شده، از تاریخچهٔ ترمینال پاکش کنید و آن را عوض کنید.

خروجی: `schema-report.json` + خلاصهٔ سازگاری در کنسول (جداول/ستون‌های مفقود و SPهای موجود). این گزارش همان چیزی است که در «گزارش سازگاری نسخه» (سند ۰۹) باید ضمیمه شود.

## ۵) اجرا

```powershell
# PowerShell — اجرای تستی
$env:ASPNETCORE_URLS = "http://0.0.0.0:5100"
dotnet run --project src/IdealBridge.Api -c Release
```

```bash
# Linux
ASPNETCORE_URLS="http://0.0.0.0:5100" dotnet run --project src/IdealBridge.Api -c Release
```

لاگ راه‌اندازی باید خط `Schema probe: ConnectionOk=True ... Modes=...` را نشان دهد.

## ۶) ساخت اولین توکن برای MedPad

```powershell
$base = "http://localhost:5100"
$adminKey = "یک-کلید-ادمین-قوی-یکتا"

$resp = Invoke-RestMethod -Method Post -Uri "$base/api/v1/tokens" `
  -ContentType "application/json" `
  -Headers @{ "X-Admin-Key" = $adminKey } `
  -Body '{"name":"MedPad-Integration","expiresInDays":90}'
$resp.data.token     # ← ibk_... — همین حالا ذخیره کنید؛ دوباره نمایش داده نمی‌شود
```

## ۷) صحت‌سنجی سریع

```powershell
# با توکن مرحلهٔ قبل:
$tok = "ibk_..."
Invoke-RestMethod -Uri "$base/health/db" -Headers @{ "X-API-Key" = $tok } | ConvertTo-Json -Depth 5
Invoke-RestMethod -Uri "$base/api/v1/companies?pageSize=5" -Headers @{ "X-API-Key" = $tok }
Invoke-RestMethod -Uri "$base/api/v1/users?pageSize=5" -Headers @{ "X-API-Key" = $tok }
```

## ۸) اجرای تست‌ها

```powershell
dotnet test IdealBridge.sln -c Release
# انتظار: 36 unit + 22 integration = 58 تست PASS
```

> تست‌های یکپارچه با دوقلوی آزمونشی ADO.NET اجرا می‌شوند (بدون نیاز به SQL Server واقعی). محدودیت و معنای آن در سند ۰۹ و ۱۱.

## ۹) انتشار (Publish) و استقرار پایدار

استقرار Windows (IIS/سرویس): سند ۰۷ — استقرار Linux (systemd): سند ۰۸.

```powershell
dotnet publish src/IdealBridge.Api -c Release -o .\publish
```

## عیب‌یابی سریع

| نشانه | علت/راه‌حل |
|---|---|
| لاگ: `ConnectionOk=False` | Connection String/فایروال/مجوز — سند ۰۵ |
| همهٔ endpointها 503 | دیتابیس وصل ولی جدول‌های Ideal نیستند → دیتابیس اشتباه؛ `/health/db` را ببینید |
| 401 روی همهٔ درخواست‌ها | توکن اشتباه/منقضی/ابطال‌شده؛ با AdminKey توکن جدید بسازید |
| `TablesMissing` در /health/db | دیتابیس نصب‌شده با انتظارات IdealBridge فرق دارد — سند ۰۹ (گزارش سازگاری) |

---

## فاز ۱۱ — تغییرات نصب

### پیش‌نیاز جدید: .NET 10

- SDK برای Build: [dotnet.microsoft.com/download/dotnet/10.0](https://dotnet.microsoft.com/download/dotnet/10.0)
- Runtime برای اجرای Framework-Dependent: همان صفحه (ASP.NET Core Runtime 10.x)
- نسخهٔ انتشار win-x64 **Self-Contained** است و Runtime جدا نمی‌خواهد (حجم بیشتر، نصب ساده‌تر).

```powershell
# بررسی نسخهٔ نصب‌شده
dotnet --list-sdks
```

```cmd
:: CMD
dotnet --list-sdks
```

### کلیدهای پیکربندی جدید/تغییریافته

| کلید | پیش‌فرض | توضیح |
|---|---|---|
| `IdealBridge:DataAccessMode` | **`Table`** | فقط `Table` یا `Auto` مجاز؛ مقدار `Sp` راه‌اندازی را با خطا متوقف می‌کند |
| `IdealBridge:Sql:*` | — | روش دوم پیکربندی اتصال (سند ۰۵) |
| `IdealBridge:CommandTimeoutSeconds` | 30 | مهلت اجرای هر دستور |
| `IdealBridge:EnforceReadOnlyGuard` | true | در Production هر مقداری بدهید روشن است (غیرقابل خاموش‌کردن) |

### اجرای تست‌ها

```powershell
dotnet test IdealBridge.sln -c Release
# جداگانه:
dotnet test tests/IdealBridge.UnitTests -c Release
dotnet test tests/IdealBridge.IntegrationTests -c Release
```

```bash
# Linux معادل
dotnet test IdealBridge.sln -c Release
```

هیچ تستی به دیتابیس واقعی وصل نمی‌شود (دوقلوی آزمونشی ADO.NET).

### CI

هر Push/PR روی شاخهٔ `ideal` (مسیر `ideal/IdealBridge/**`) در GitHub Actions اجرا می‌شود: بررسی محدودهٔ تغییرات → Restore → Build → تست‌ها → اسکن Secret.

### انتشار نسخهٔ آزمایشی

برچسب‌های `dev-*` (مثل `dev-11.1.0`) بستهٔ win-x64 آزمایشی در صفحهٔ Releases مخزن منتشر می‌کنند. ساخت بسته:

```powershell
dotnet publish src/IdealBridge.Api -c Release -r win-x64 --self-contained true -o publish/win-x64
Compress-Archive -Path publish/win-x64/* -DestinationPath IdealBridge-win-x64-dev.zip
```
