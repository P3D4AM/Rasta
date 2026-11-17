# ممیزی اسکیمای زندهٔ دیتابیس Ideal (فاز ۱۲.۵)

> **وضعیت: ابزار آماده و منتشرشده — استخراج زنده «هنوز انجام نشده».**
> این سند تا رسیدن خروجی واقعی `ideal-live-schema-report.json` از محیط مالک،
> **هیچ واقعیت اسکیمایی را به‌عنوان «زنده» ثبت نمی‌کند.** هر ادعا برچسب منبع دارد.

## ۱. راهنمای برچسب منابع

| برچسب | معنا |
|---|---|
| `[زنده]` | از گزارش واقعی `ideal-live-schema-report.json` (ابزار v3.0 روی دیتابیس واقعی) |
| `[ایستا-SSDL187]` | از SSDL نسخهٔ 3.1.18.187 (۶۳۳ جدول) و کاتالوگ ۳۶۱MB نصاب — فاز ۱۲ |
| `[کد-IdealBridge]` | از کد فعلی مخازن IdealBridge |
| `[کاربر-تأییدشده]` | آزمون مستقل مالک روی SQL Server واقعی (بیرون از این پروژه) |
| `[در انتظار]` | **هنوز هیچ شواهدی ثبت نشده** — منتظر اجرای زنده |

## ۲. وضعیت فعلی (صادقانه)

- نسخهٔ نصب‌شدهٔ Ideal CRM: **3.1.16.169.0303** `[ایستا-SSDL187]` (تحلیل فاز ۱۲؛ تأیید ساختاری آن **ممکن نیست** بدون اتصال).
- ابزار استخراج: **IdeaSchemaDump v3.0** — ساخته، تست‌شده (۲۱۰ تست واحد + ۳۳ تست یکپارچه)، منتشرشده در Release این فاز `[کد-IdealBridge]`.
- حساب فقط-فراداده: `ibk_schema_reader` — تأیید مالک `[کاربر-تأییدشده]`:
  - خواندن فرادادهٔ کاتالوگ: کار می‌کند.
  - `SELECT` روی `dbo.CrmCompanyPersons`: **رد می‌شود** (همان‌طور که انتظار می‌رفت).
  - `VIEW DEFINITION = 1`.
  - عضو **هیچ** Database Role نیست (`db_datareader` ندارد).
- **استخراج زنده: انجام‌نشده.** تا رسیدن فایل خروجی واقعی، هیچ شماری (جدول/ستون/ویو/SP/…) در این سند به‌عنوان واقعیت 3.1.16 ثبت نمی‌شود.

## ۳. مدل امنیتی استخراج (طراحی — همه با تست قفل شده)

| # | ضمانت | سازگیری |
|---|---|---|
| ۱ | فقط `SELECT` تک‌دستوری روی نمای‌های کاتالوگ `sys.*` — `ReadOnlyCommandGuard` مشترک با سرویس، قبل از ارسال هر کوئری | تست `Every_Query_Passes_The_Shared_ReadOnlyCommandGuard` |
| ۲ | **صفر متن تعریف ماژول**: `sys.sql_modules` / `OBJECT_DEFINITION` / `sp_helptext` هرگز خوانده نمی‌شوند؛ ویوها فقط نام+ستون، SPها فقط نام+امضای پارامتر، توابع فقط نام+امضا، تریگرها فقط نام+والد+رویداد | تست‌های `No_Sql_Module_Definition_Is_Ever_Queried` |
| ۳ | **همهٔ Schemaها** — هیچ `schema_id = 1` / `SCHEMA_ID('dbo')` در هیچ کوئری نیست | تست `No_Query_Is_Restricted_To_A_Single_Schema` |
| ۴ | صفر خواندن جدول/ویوی کسب‌وکار = صفر دادهٔ واقعی؛ فقط `sys.*` در FROM/JOIN | تست‌های `Every_From_Or_Join_Source_Is_A_System_Catalog_View` و `No_Business_Table_Is_Ever_Read` |
| ۵ | بدون شمارش سطر/توزیع داده (بدون DMV/`COUNT(*)`/`partition_stats`) | تست `No_Row_Count_Or_Data_Distribution_Is_Queried` |
| ۶ | CDC فقط از فراداده: پرچم `is_cdc_enabled` + فهرست اشیای schema «cdc» در `sys.objects`؛ `cdc.change_tables` و `cdc.fn_*` مستقیم خوانده نمی‌شوند (نیازمند SELECT است — سیاست: درخواست مجوز جدید ممنوع) | تست `Cdc_Is_Inspected_Only_Via_Object_Metadata` |
| ۷ | Connection String فقط از متغیر محیطی `IdeaSchemaDump__ConnectionString` — متغیر سرویس (`IdealBridge__ConnectionString`) هرگز خوانده نمی‌شود؛ خط فرمان هرگز | تست‌های `EnvVar_Is_The_Dedicated_Tool_Variable_Separated_From_Service` و `Tool_Never_Reads_The_Service_EnvVar` |
| ۸ | اجبار `ApplicationIntent=ReadOnly` + `Encrypt=True` + `ApplicationName=IdeaSchemaDump` داخل خود ابزار | تست `EnvVar_Connection_Is_Resolved_ReadOnly_And_Encrypt_Forced` |
| ۹ | کوئری‌های مکملِ نسخه‌محور در صورت نبودن روی سرور → «هشدار استخراج» ثبت می‌شوند؛ **هرگز مقدار ساختگی ساخته نمی‌شود** | طراحی `TryQuery` + خروجی بلوک `extractionWarnings` |
| ۱۰ | خروجی JSON بدون هیچ Secret/Connection String/دادهٔ کسب‌وکار؛ فایل هرگز وارد Git نمی‌شود (الگوی `.gitignore`) | بازبینی + قفل ثبت |

**در اجرای زنده باید شاهد باشید:** ابزار با `ibk_schema_reader` متصل می‌شود، فراداده را می‌خواند و هیچ SqlException «دسترسی رد شد» برای کوئری‌های کاتالوگ نمی‌گیرد (رد شدن `SELECT` جدول واقعی دیده نمی‌شود چون کوئری‌ای برای آن نیست). اگر چیزی در دسترس نبود، به‌جای شکست، در `extractionWarnings` ثبت می‌شود.

## ۴. خروجی ابزار — ۲۵+ بلوک

`metadata` (نسخه ابزار/سیاست/شمارش‌ها) · `sqlServer` (فقط `SERVERPROPERTY` — بدون `@@VERSION` کامل) · `database` (سطح سازگاری/مرتب‌سازی/مدل بازیابی/فقط-خواندنی/Snapshot/RCS/پرچم CDC) · `schemas` · `tables` · `tableFlags` (پرچم‌های Replication + create/modify تاریخ DDL) · `primaryKeys` · `foreignKeys` (onDelete/onUpdate/Disabled/NotTrusted) · `indexes` (ستون‌ها/Included/فیلتر/Disabled) · `views` (نام+ستون — بدون تعریف) · `storedProcedures` (نام+امضا) · `functions` (نام+نوع+امضا) · `triggers` (نام+والد+رویداد+Disabled) · `identityColumns` (Seed/Increment بدون last_value) · `computedColumns` (عبارت سطح-ستون) · `rowVersionColumns` · `defaultConstraints` · `temporalTables` · `memoryOptimizedTables` · `generatedAlwaysColumns` · `cdc` · `changeTracking` (سطح دیتابیس + جدول + Retention/AutoCleanup) · `syncCapabilities` (فقط از پرچم‌های واقعی — نه از نام ستون‌ها) · `idealBridgeCompatibility` (مفقودات جدول/ستون/SP نسبت به انتظارات مخازن) · `extractionWarnings`.

## ۵. دستور اجرای دقیق (روی ویندوز مالک)

```powershell
# ۰) از پوشهٔ ابزار (خروجی Release این فاز) — نیازی به .NET SDK/_runtime ندارد
cd C:\IdealBridge\IdeaSchemaDump-win-x64

# ۱) تنظیم امن Connection String — فقط یک‌بار (مقدار واقعی را جای *** بگذارید؛
#    هرگز در Git/اسکرین‌شات/لاگ نگذارید)
[Environment]::SetEnvironmentVariable("IdeaSchemaDump__ConnectionString", "Server=نام-سرور;Database=crmideal;User Id=ibk_schema_reader;Password=***;Encrypt=True;TrustServerCertificate=True", "User")

# ۲) اجرا (پنجرهٔ جدید یا همان نشست پس از مرحلهٔ ۱)
.\IdeaSchemaDump.exe --out C:\IdealBridge\ideal-live-schema-report.json

# ۳) (اختیاری) بازبینی سریع
Get-Content C:\IdealBridge\ideal-live-schema-report.json | Select-Object -First 40
```

**نشانهٔ موفقیت:** خروجی کنسول شامل «متصل (فقط-خواندنی/رمزنگاری‌شده)»، شمارنده‌های هر بلوک و خلاصهٔ «مقایسهٔ زنده با انتظارات IdealBridge» است. فایل JSON ساخته می‌شود.

**نشانهٔ خطای مجوز:** پیام خطای اتصال دسته‌بندی‌شده (نه خام)؛ اگر کوئری کاتالوگی رد شود، در `extractionWarnings` می‌نشیند و ابزار نمی‌شکند.

## ۶. پس از اجرا — چه چیزی به این سند اضافه می‌شود

1. شمارش واقعی: Schemaها / جداول / ستون‌ها / ویوها / SPها / توابع / تریگرها / Identity / Computed / RowVersion / Default `[زنده]`.
2. وضعیت CDC / Change Tracking / Temporal / RowVersion / Replication روی **3.1.16 واقعی** `[زنده]`.
3. فهرست کامل `extractionWarnings` + تفسیر هر مورد (مثلاً «سرور قدیمی‌تر از 2016 است → فرادادهٔ Temporal در دسترس نیست»).
4. بلوک `idealBridgeCompatibility` (جدول/ستون/SPهای مفقود) → ورودی مستقیم `IDEAL_QUERY_COMPATIBILITY_REPORT.md`.
5. جمع `syncCapabilities` → ورودی مستقیم `IDEAL_SYNC_CAPABILITY_AUDIT.md`.

## ۷. محدودیت‌ها و موارد باز

- استخراج **توسط مالک** روی ویندوز واقعی انجام می‌شود؛ این پروژه به آن محیط دسترسی ندارد و **هرگز** بدون خروجی واقعی، «استخراج انجام شد» گزارش نمی‌کند.
- `cdc.change_tables` مستقیم خوانده نمی‌شود (نبود مجوز SELECT بخشی از طراحی است) — نمونه‌های Capture از نام اشیای schema «cdc» استنتاج می‌شوند؛ این استنتاج در خود گزارش برچسب دارد.
- تعریف SP/ویو/تابع/تریگر عمداً استخراج نمی‌شود؛ مقایسهٔ معنایی نسخه‌ها از **امضا و ساختار** انجام می‌شود (`--compare`).
- `last_value` ستون‌های Identity و مقدار واقعی RowVersion عمداً خوانده نمی‌شوند (state زمان اجرا، نه ساختار).
- قضاوت «LastModified» و «Soft Delete» هرگز از نام ستون نمی‌آید — فقط پرچم ساختاری (RowVersion/Temporal/CDC/CT) مبنای قضاوت است؛ در غیر این صورت جدول به Snapshot کامل می‌رود.
