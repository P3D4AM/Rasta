# راهنمای ایجاد SQL Login فقط-خواندنی برای IdealBridge

> سند ۰۶ — اعمال سیاست فقط-خواندنی در سطح SQL Server (لایهٔ دوم دفاعی)
>
> **سیاست نهایی (فاز ۱۱.۱):** فقط `SELECT` روی جداول و ویوهای موردنیاز + در صورت نیاز `VIEW DEFINITION` برای استخراج فراداده.
> **بدون EXECUTE** (اجرای Stored Procedure از فاز ۱۱ در IdealBridge به‌کلی غیرفعال است) و **بدون هیچ مجوز نوشتنی** (INSERT/UPDATE/DELETE/ALTER/DROP/...).

## چرا حساب جداگانه؟

IdealBridge با دو لایه فقط-خواندنی است:
1. **لایهٔ کد** — `ReadOnlyCommandGuard` با توکنایزر T-SQL: فقط «یک» دستور SELECT/WITH، بدون EXEC، بدون batch، بدون SELECT INTO و بدون عبارات تغییردهندهٔ state (از جمله `NEXT VALUE FOR`). هیچ SP — حتی با نام «خواندنی» — مجاز نیست.
2. **لایهٔ SQL Server** — حساب `ibk_reader` که **هیچ مجوز نوشتن و هیچ مجوز EXECUTE ندارد**، حتی اگر کد به اشتباه تلاش کند.

لایهٔ دوم تضمین قطعی است: هر INSERT/UPDATE/DELETE/DDL و هر EXECUTE با خطای `The ... permission was denied` شکست می‌خورد.

> **ممنوع:** استفاده از `sa`، حساب Administrator ویندوز یا حساب اصلی برنامهٔ Ideal به‌عنوان حساب سرویس IdealBridge.
> حساب سرویس همیشه یک Login اختصاصی فقط-خواندنی است که در همین سند ساخته می‌شود.

## گام ۱ — ساخت Login و User (یک‌بار، توسط DBA)

این اسکریپت یک‌بار توسط DBA (با حداقل مجوز لازم برای ساخت Login/User — مثلاً عضویت در `securityadmin` و `db_owner` همان یک دیتابیس) اجرا می‌شود. نام دیتابیس را جایگزین `CRM` کنید:

```sql
USE [master];
GO
-- ۱) Login سرور — رمز قوی و یکتا (با CHECK_POLICY = ON)
CREATE LOGIN [ibk_reader] WITH PASSWORD = N'«یک رمز قوی یکتا»', CHECK_POLICY = ON;
GO
USE [CRM];   -- نام واقعی دیتابیس Ideal
GO
-- ۲) User در دیتابیس Ideal
CREATE USER [ibk_reader] FOR LOGIN [ibk_reader];
GO
```

## گام ۲ — مجوز فقط SELECT روی جداول و ویوها

**روش الف — ساده و استاندارد (پیشنهادی):** عضویت در نقش دیتابیس `db_datareader` (فقط SELECT روی همهٔ جداول/ویوها؛ بدون نوشتن و بدون EXECUTE):

```sql
USE [CRM];
GO
ALTER ROLE [db_datareader] ADD MEMBER [ibk_reader];
GO
```

**روش ب — محدودتر (شیء-به-شیء):** اگر می‌خواهید فقط جداول/ویوهایی که IdealBridge می‌خواند مجاز باشند، به‌جای عضویت در نقش، این کوئری را اجرا کنید تا دستورهای GRANT لازم «تولید» شود؛ خروجی را بازبینی و سپس اجرا کنید:

```sql
USE [CRM];
GO
-- تولید دستورهای GRANT SELECT (خروجی = متن دستورها؛ اجرای آن‌ها با شماست)
SELECT 'GRANT SELECT ON OBJECT::dbo.' + QUOTENAME(name) + ' TO [ibk_reader];' AS GrantCommand
FROM sys.objects
WHERE schema_id = 1 AND type IN ('U', 'V')   -- U = جدول، V = ویو
  AND name IN (
    'CrmCompany','CrmCompanyPersons','Users','CrmConversation','CrmProjects',
    'CrmUserTasks','WsWareHouse','WSProducts','WSOrder','WSPreOrder','CrmCompanyAddresses',
    'CrmCompanyTitle','CrmCompanyType','CrmCompanyGroups','CrmCompanySubGroups',
    'CrmCompanyGroupsII','CrmCompanyGroupsIII','CrmCompanyGroupsIV','CrmCompanyPresentation',
    'CrmCompanyAddressType','CrmPersonTitle','CrmPersonType','CrmPersonJob','CrmPersonDepartments',
    'CrmPersonGroups','Education','Sex','City','Province','Country',
    'CrmProjectTitles','CrmProjectGroups','CrmProjectGrade','CrmProjectPriority',
    'CrmConversationTopics','CrmConversationStatus','CrmUserTaskPriorities','CrmUserTaskGroups',
    'WSOrderOpr','WSProductFirstGroup','WSProductColor','WSProductUnit','Centers'
);
GO
```

> چرا تولید متن به‌جای CURSOR + `EXEC sp_executesql`؟ سیاست این سند «بدون EXECUTE و بدون داینامیک» است؛ متن دستورها را می‌بینید، بازبینی می‌کنید و خودتان اجرا می‌کنید — هیچ کدی پنهان اجرا نمی‌شود.

## گام ۳ — (اختیاری) VIEW DEFINITION برای ابزار کاوش

برای آنکه `IdeaSchemaDump` بتواند متن تعریف SP/ویوها را هم استخراج کند (مقایسهٔ نسخه‌ها — ابزار هرگز SP اجرا نمی‌کند، فقط «متن تعریف» را می‌خواند):

```sql
USE [CRM];
GO
GRANT VIEW DEFINITION TO [ibk_reader];
GO
```

بدون این مجوز ابزار کار می‌کند ولی به‌جای متن تعریف، عبارت «بدون مجوز VIEW DEFINITION» ثبت می‌شود. این مجوز فقط «خواندن متن تعریف» است و هیچ دسترسی اجرایی یا نوشتنی اضافه نمی‌کند.

### دیدن متن تعریف (در صورت نیاز) — بدون EXEC

```sql
-- خواندن تعریف با SELECT روی sys.sql_modules (نیازمند VIEW DEFINITION) — نه با EXEC sp_helptext
SELECT OBJECT_NAME(object_id) AS ObjectName, definition
FROM sys.sql_modules
WHERE object_id = OBJECT_ID('dbo.ApispSelectCompany');
```

## گام ۴ — اثبات فقط-خواندنی

```sql
-- تست مستقیم denies (نتیجهٔ هر سه باید خطای permission denied باشد):
USE [CRM];
EXECUTE AS USER = 'ibk_reader';
SELECT TOP 1 * FROM dbo.CrmCompany;          -- ✔ باید موفق باشد
-- INSERT INTO dbo.CrmCompany (cmpName) VALUES ('test');  -- ✖ باید FAIL شود
-- UPDATE dbo.CrmCompany SET cmpName = 'x' WHERE 1=0;     -- ✖ باید FAIL شود
-- DELETE FROM dbo.CrmCompany WHERE 1=0;                  -- ✖ باید FAIL شود
-- EXEC dbo.ApispSelectCompany @CompanyId = NULL;          -- ✖ باید FAIL شود (بدون EXECUTE)
REVERT;
```

و تست از بیرون (PowerShell):

```powershell
sqlcmd -S "SQLSRV\IDEAL" -d "CRM" -U "ibk_reader" -P "***" -Q "SELECT TOP 1 CompanyID FROM dbo.CrmCompany"   # باید موفق شود
sqlcmd -S "SQLSRV\IDEAL" -d "CRM" -U "ibk_reader" -P "***" -Q "UPDATE dbo.CrmCompany SET cmpName='x' WHERE 1=0"  # باید خطای 229 بدهد
sqlcmd -S "SQLSRV\IDEAL" -d "CRM" -U "ibk_reader" -P "***" -Q "EXEC dbo.ApispSelectCompany"                        # باید خطای 229 بدهد
```

## گام ۵ — کارهای ممنوع (چک‌لیست استقرار)

- [ ] از حساب `sa`، Administrator یا حساب اصلی Ideal برای IdealBridge استفاده نشده
- [ ] Connection String در هیچ فایل کامیت‌شده/لاگ/سندی نیست (فقط Environment Variable/Secret)
- [ ] `db_datawriter`، `db_owner`، `db_ddladmin`، `db_securityadmin` به `ibk_reader` داده نشده
- [ ] **هیچ مجوز EXECUTE** (شیءای یا نقش‌ای) به `ibk_reader` داده نشده — IdealBridge از فاز ۱۱ هیچ SP اجرا نمی‌کند
- [ ] رمز قوی و یکتا (با `CHECK_POLICY=ON`)
- [ ] در صورت تغییر نیازها، حذف سریع دسترسی:

```sql
-- حذف کامل حساب سرویس (در صورت نیاز):
USE [CRM]; DROP USER [ibk_reader];
USE [master]; DROP LOGIN [ibk_reader];
```

> اگر در گذشته (نسخه‌های قبل از فاز ۱۱) EXECUTE داده بودید، حذفش کنید:
> `REVOKE EXECUTE ON OBJECT::dbo.ApispSelectCompany FROM [ibk_reader];` — و یا با حذف User/Login (بالا) همهٔ دسترسی‌ها یک‌جا پاک می‌شود.

---

## پیوست — چرا EXECUTE لازم نیست؟

از فاز ۱۱ معماری IdealBridge عوض شده است:

- **اجرای Stored Procedure به‌کلی غیرفعال است** — حتی `CommandType.StoredProcedure` همیشه رد می‌شود؛ فهرست سفید SP حذف شده است.
- سرویس فقط `SELECT` پارامتری مستقیم روی جداول می‌زند (حالت پیش‌فرض `DataAccessMode=Table`).
- موجودی/امضای SPهای `ApispSelect*` فقط «گزارش» می‌شود (کاوش اسکیما و ابزار IdeaSchemaDump) — نه انتخاب مسیر اجرا. بنابراین GRANT EXECUTE نه لازم است، نه توصیه می‌شود؛ سیاست این سند **صریحاً بدون EXECUTE** است.
