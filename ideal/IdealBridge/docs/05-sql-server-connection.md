# راهنمای اتصال به SQL Server نرم‌افزار Ideal

> سند ۰۵ — یافتن اطلاعات اتصال و ساخت Connection String برای IdealBridge

## ۱. اطلاعات اتصال را از نصب Ideal پیدا کنید (نه با حدس)

### روش الف — فایل Web.config سایت Ideal

Ideal CRM نسخهٔ وب، اتصال را در `Web.config` ناحیهٔ API نگه می‌دارد (مقادیر با رمزگذاری قدیمی Ideal ذخیره شده‌اند — اگر رمزخوانی امکان‌پذیر نبود از روش ب استفاده کنید):

```powershell
# PowerShell — نمایش کلیدهای اتصال
Select-String -Path "C:\Inetpub\wwwroot\CRMIdealApi\Web.config" -Pattern "DBServer|DBName|DBUser|DBPass"
```

> **نکتهٔ امنیتی:** این فایل حاوی مقادیر رمزگذاری‌شدهٔ حساب Ideal است. آن را جابه‌جا یا کپی نکنید؛ فقط برای پیدا کردن نام سرور/دیتابیس استفاده کنید و برای IdealBridge **حساب فقط-خواندنی جدید** بسازید (سند ۰۶).

### روش ب — SSMS / SQL Server Configuration Manager

1. روی سرور، `SQL Server Configuration Manager` را باز کنید → «SQL Server Services» → نام Instance را ببینید (مثلاً `MSSQLSERVER` = پیش‌فرض، یا `IDEAL` = Instance نام‌دار).
2. در SSMS به سرور وصل شوید و دیتابیس‌ها را ببینید — نام دیتابیس CRM معمولاً الگویی مانند `CRM` یا `CRMIdeal` دارد؛ **تأیید نهایی با کوئری زیر** (فقط-خواندنی):

```sql
SELECT name, create_date, compatibility_level
FROM sys.databases
ORDER BY name;
```

دیتابیس CRM را با تعداد جدول بالا (چندصد جدول با پیشوندهای `Crm*`، `WS*`، `Users`...) شناسایی کنید:

```sql
-- فقط-خواندنی: شمارش جداول شناخته‌شدهٔ Ideal در هر دیتابیس
SELECT d.name AS DatabaseName, COUNT(1) AS IdealLikeTables
FROM sys.databases d
CROSS APPLY (
    SELECT 1 AS x FROM sys.tables t WHERE t.is_ms_shipped = 0
) t
GROUP BY d.name;
```

### روش ج — پرس‌وجوی مستقیم با ابزار IdealBridge

پس از ساخت حساب فقط-خواندنی، ابزار `IdeaSchemaDump` (سند ۰۴) گزارش کامل ساختار را می‌دهد و همان‌جا صحت انتخاب دیتابیس را می‌بینید.

## ۲. ساخت Connection String

قالب (با حساب فقط-خواندنی سند ۰۶):

```
Server=<SERVER>\<INSTANCE>;Database=<IDEAL_DB>;User Id=ibk_reader;Password=<STRONG_PASSWORD>;TrustServerCertificate=True;Encrypt=True
```

| جزء | مثال | توضیح |
|---|---|---|
| Server | `SQLSRV` یا `SQLSRV\IDEAL` یا `192.168.1.10` | نام سرور + Instance |
| Database | `CRM` | نام دیتابیس Ideal — با روش بالا تأییدشده |
| User Id | `ibk_reader` | حساب فقط-خواندنی (هرگز حساب Ideal اصلی) |
| TrustServerCertificate | `True` | برای گواهی self-signed داخلی |

IdealBridge خودش این را کامل می‌کند: `ApplicationIntent=ReadOnly` و `ApplicationName=IdealBridge` به‌صورت خودکار اضافه می‌شوند.

## ۳. معرفی به IdealBridge (بدون ورود Secret به فایل/Git)

**PowerShell — متغیر محیطی کاربر (ماندگار):**

```powershell
[Environment]::SetEnvironmentVariable("IdealBridge__ConnectionString", "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True", "User")
```

**PowerShell — فقط برای نشست جاری:**

```powershell
$env:IdealBridge__ConnectionString = "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"
```

**CMD:**

```cmd
setx IdealBridge__ConnectionString "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"
```

**Linux (bash):**

```bash
export IdealBridge__ConnectionString='Server=sqlsrv;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True'
```

> نکتهٔ نام‌گذاری: `IdealBridge__ConnectionString` (دو خط تیرهٔ زیرین) از سکشن `IdealBridge:ConnectionString` در تنظیمات ASP.NET Core مپ می‌شود.

## ۴. تست اتصال قبل از اجرای سرویس

PowerShell:

```powershell
# تست پورت SQL Server
Test-NetConnection -ComputerName "SQLSRV" -Port 1433

# تست واقعی اتصال و مجوز (فقط SELECT)
sqlcmd -S "SQLSRV\IDEAL" -d "CRM" -U "ibk_reader" -P "***" -Q "SELECT TOP 3 CompanyID, cmpName FROM dbo.CrmCompany ORDER BY CompanyID"
```

Linux:

```bash
sqlcmd -S "sqlsrv" -d "CRM" -U "ibk_reader" -P "***" -Q "SELECT TOP 3 CompanyID, cmpName FROM dbo.CrmCompany ORDER BY CompanyID"
```

سپس اجرای کاوشگر کامل:

```powershell
cd ideal\IdealBridge
dotnet run --project tools/IdeaSchemaDump -- --connection "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True" --out schema-report.json
```

خروجی `schema-report.json` نشان می‌دهد:
- جدول‌ها/ستون‌های موردانتظار IdealBridge موجودند یا نه؛
- کدام SPهای `ApispSelect*` با چه امضایی در دسترس‌اند؛
- حالت هر موجودیت چه خواهد بود.

## ۵. خطاهای رایج

| خطا | علت رایج | راه‌حل |
|---|---|---|
| `4060` — نمی‌تواند به دیتابیس وصل شود | نام دیتابیس اشتباه | با `sys.databases` تأیید کنید |
| `18456` — Login failed | کاربر/رمز اشتباه یا نداشتن دسترسی به دیتابیس | GRANT در سند ۰۶ را کامل اجرا کنید |
| `2/53` — server not found | Instance/پورت/فایروال | `Test-NetConnection`، SQL Browser (UDP 1434) برای Instance نام‌دار |
| اتصال OK ولی endpointها 503 | دیتابیس درست ولی جداول IdealBridge نیستند (دیتابیس اشتباه انتخاب شده) | `/health/db` را ببینید؛ `TablesMissing` را بررسی کنید |

---

## ۶. روش دوم پیکربندی: تنظیمات تفکیکی `IdealBridge:Sql` (فاز ۱۱)

به‌جای Connection String کامل می‌توانید فیلدها را جدا تنظیم کنید — رمز باز هم **فقط از متغیر محیطی**:

| کلید پیکربندی | متغیر محیطی | توضیح |
|---|---|---|
| `IdealBridge:Sql:Server` | `IdealBridge__Sql__Server` | نمونه/آدرس سرور، مثل `SQLSRV\IDEAL` یا `sqlsrv.local,1433` |
| `IdealBridge:Sql:Database` | `IdealBridge__Sql__Database` | نام دیتابیس Ideal (از محیط نصب — حدس زده نمی‌شود) |
| `IdealBridge:Sql:AuthMode` | `IdealBridge__Sql__AuthMode` | `Sql` (پیش‌فرض) یا `Windows` |
| `IdealBridge:Sql:UserId` | `IdealBridge__Sql__UserId` | کاربر SQL (حالت Sql) |
| `IdealBridge:Sql:Password` | `IdealBridge__Sql__Password` | رمز — هرگز در فایل/لاگ/Git |
| `IdealBridge:Sql:Encrypt` | — | پیش‌فرض `true` |
| `IdealBridge:Sql:TrustServerCertificate` | — | پیش‌فرض `false` (فقط آزمایش داخلی) |
| `IdealBridge:Sql:ConnectTimeoutSeconds` | — | پیش‌فرض ۱۵ ثانیه |

**اولویت:** اگر `IdealBridge:ConnectionString` تنظیم شده باشد، بخش `Sql` نادیده گرفته می‌شود.

**در هر دو روش** این‌ها همیشه به‌اجبار اعمال می‌شوند: `ApplicationName=IdealBridge`، `ApplicationIntent=ReadOnly` و مهلت اتصال.

### Windows Authentication

`AuthMode=Windows` روی ویندوز `Integrated Security` را فعال می‌کند (حساب اجرای سرویس باید به SQL Server دسترسی خواندنی داشته باشد). **در Linux** این حالت نیازمند راه‌اندازی Kerberos است — برای استقرار Linux حتماً SQL Authentication استفاده کنید.

## ۷. دسته‌بندی خطاهای اتصال (فاز ۱۱)

سرویس خطاهای اتصال را دسته‌بندی و با پیام فارسی امن گزارش می‌کند (بدون افشای نام سرور/کاربر/رمز):

| دسته (`errorKind`) | نمونهٔ شمارهٔ SQL | معنی |
|---|---|---|
| `Network` | 2، 53، 10060، 10061 | سرور در دسترس نیست / فایروال / پورت |
| `Authentication` | 18456، 18452، 18470 | ورود ناموفق / حساب غیرفعال |
| `DatabaseNotFound` | 4060 | دیتابیس باز نشد (نام/دسترسی) |
| `Timeout` | -2، 121، 258 | مهلت اتصال تمام شد |
| `Configuration` | 87 | پیکربندی نامعتبر |
| `PermissionDenied` | 229، 230، 262 | مجوز SELECT/VIEW DEFINITION داده نشده |
| `SqlServerError` | سایر | خطای SQL Server |

دیدن وضعیت زندهٔ اتصال:

```powershell
# PowerShell
Invoke-RestMethod -Uri "http://localhost:5100/api/v1/admin/connection" -Headers @{ "X-Admin-Key" = "<کلید ادمین>" }
```

```cmd
:: CMD
curl http://localhost:5100/api/v1/admin/connection -H "X-Admin-Key: <کلید ادمین>"
```

## ۸. خطاهای رایج (ادامه) و راه‌حل

| خطا (دسته) | علت رایج | راه‌حل |
|---|---|---|
| `Network` | SQL Browser خاموش / پورت 1433 بسته / نام Instance غلط | نام کامل Instance را تست کنید: `sqlcmd -S "SQLSRV\IDEAL" -U ibk_reader -Q "SELECT 1"` |
| `Authentication` | رمز اشتباه / حساب غیرفعال | با `sqlcmd` جداگانه تست کنید؛ حساب در SSMS فعال باشد |
| `DatabaseNotFound` | نام دیتابیس در پیکربندی با واقعیت فرق دارد | نام دقیق را از محیط نصب بگیرید (سند بالا) |
| `Timeout` | شبکه کند / سرور مشغول | `ConnectTimeoutSeconds` را موقتاً بالا ببرید |
| SSL/TLS | گواهی سرور Self-Signed و `Encrypt=True` | در محیط داخلی: `TrustServerCertificate=true` (مستندسازی ریسک) |
