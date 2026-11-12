# راهنمای ایجاد SQL Login فقط-خواندنی برای IdealBridge

> سند ۰۶ — اعمال سیاست فقط-خواندنی در سطح SQL Server (لایهٔ دوم دفاعی)

## چرا حساب جداگانه؟

IdealBridge با دو لایه فقط-خواندنی است:
1. **لایهٔ کد** — `ReadOnlyCommandGuard` که هر دستور را قبل از اجرا اعتبارسنجی می‌کند (فقط SELECT / فهرست‌سفید SPهای خواندنی).
2. **لایهٔ SQL Server** — حساب `ibk_reader` که **هیچ مجوز نوشتن ندارد**، حتی اگر کد به اشتباه تلاش کند.

لایهٔ دوم تضمین قطعی است: هر INSERT/UPDATE/DELETE/DDL با خطای `The UPDATE permission was denied` شکست می‌خورد.

## گام ۱ — ساخت Login و User (در دیتابیس Ideal)

در SSMS یا sqlcmd، با حساب sysadmin اجرا کنید (نام دیتابیس را جایگزین `CRM` کنید):

```sql
USE [master];
GO
-- ۱) Login سرور
CREATE LOGIN [ibk_reader] WITH PASSWORD = N'«یک رمز قوی یکتا»', CHECK_POLICY = ON;
GO
USE [CRM];   -- نام واقعی دیتابیس Ideal
GO
-- ۲) User در دیتابیس Ideal
CREATE USER [ibk_reader] FOR LOGIN [ibk_reader];
GO
```

## گام ۲ — مجوز فقط SELECT روی جداول (به‌جای db_datareader محدودتر؟)

ساده‌ترین روش استاندارد:

```sql
USE [CRM];
GO
ALTER ROLE [db_datareader] ADD MEMBER [ibk_reader];
GO
```

`db_datareader` فقط `SELECT` روی همهٔ جداول/ویوهای دیتابیس می‌دهد — بدون INSERT/UPDATE/DELETE/DDL.

اگر می‌خواهید **محدودتر** باشید (فقط جداولی که IdealBridge می‌خواند)، به‌جای عضویت در نقش، مجوز شیء-به-شیء بدهید:

```sql
USE [CRM];
GO
DECLARE @tables TABLE (name SYSNAME);
INSERT INTO @tables (name)
SELECT name FROM sys.tables
WHERE name IN (
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
DECLARE @t SYSNAME, @sql NVARCHAR(MAX);
DECLARE c CURSOR FOR SELECT name FROM @tables;
OPEN c; FETCH NEXT FROM c INTO @t;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = N'GRANT SELECT ON OBJECT::dbo.' + QUOTENAME(@t) + N' TO [ibk_reader];';
    EXEC sp_executesql @sql;
    FETCH NEXT FROM c INTO @t;
END
CLOSE c; DEALLOCATE c;
GO
```

## گام ۳ — EXECUTE فقط برای SPهای خواندنی (اختیاری — فقط در حالت DataAccessMode=Sp لازم است)

پیش‌شرط مأموریت: **EXECUTE فقط پس از بررسی کامل بدنهٔ SP**. بدنهٔ این SPها از کاتالوگ SQL بستهٔ اصلی نسخهٔ سورس بازبینی شده و همگی فقط SELECT هستند؛ در محیط واقعی **قبل از GRANT، بدنهٔ همان نسخهٔ نصب‌شده را هم ببینید** (گام ۴) و در صورت اختلاف، GRANT نکنید:

```sql
USE [CRM];
GO
-- فهرست سفید SPهای خواندنی IdealBridge (فقط همین‌ها):
GRANT EXECUTE ON OBJECT::dbo.[ApispSelectCompany]        TO [ibk_reader];
GRANT EXECUTE ON OBJECT::dbo.[ApispSelectCompanyPersons] TO [ibk_reader];
GRANT EXECUTE ON OBJECT::dbo.[ApispSelectUsers]          TO [ibk_reader];
GO
```

**نکتهٔ سازگاری:** اگر SP روی دیتابیس نصب‌شده (3.1.16) با امضای موردانتظار IdealBridge (نسخهٔ 3.1.18.187) فرق دارد، IdealBridge خودش آن SP را غیرقابل استفاده علامت می‌زند و به حالت Table می‌رود (`/health/db`) — لازم نیست کاری کنید.

## گام ۴ — بازبینی بدنهٔ SP قبل از GRANT (فقط-خواندنی)

```sql
-- دیدن تعریف SP (خواندن تعریف، اجرا نیست)
EXEC sp_helptext 'dbo.ApispSelectCompany';
```

معیار پذیرش: بدنه فقط SELECT/FETCH/SET/DECLARE دارد؛ هیچ INSERT/UPDATE/DELETE/EXEC تغییردهنده‌ای در آن نیست.

## گام ۵ — اثبات فقط-خواندنی

```sql
-- تست مستقیم denies (نتیجهٔ هر سه باید خطای permission denied باشد):
USE [CRM];
EXECUTE AS USER = 'ibk_reader';
SELECT TOP 1 * FROM dbo.CrmCompany;          -- ✔ باید موفق باشد
-- INSERT INTO dbo.CrmCompany (cmpName) VALUES ('test');  -- ✖ باید FAIL شود
-- UPDATE dbo.CrmCompany SET cmpName = 'x' WHERE 1=0;     -- ✖ باید FAIL شود
-- DELETE FROM dbo.CrmCompany WHERE 1=0;                  -- ✖ باید FAIL شود
REVERT;
```

و تست از بیرون (PowerShell):

```powershell
sqlcmd -S "SQLSRV\IDEAL" -d "CRM" -U "ibk_reader" -P "***" -Q "SELECT TOP 1 CompanyID FROM dbo.CrmCompany"   # باید موفق شود
sqlcmd -S "SQLSRV\IDEAL" -d "CRM" -U "ibk_reader" -P "***" -Q "UPDATE dbo.CrmCompany SET cmpName='x' WHERE 1=0"  # باید خطای 229 بدهد
```

## گام ۶ — کارهای ممنوع (چک‌لیست استقرار)

- [ ] از حساب `sa` یا حساب اصلی Ideal برای IdealBridge استفاده نشده
- [ ] Connection String در هیچ فایل کامیت‌شده/لاگ/سندی نیست (فقط Environment Variable/Secret)
- [ ] `db_datawriter`، `db_owner`، `db_ddladmin` به `ibk_reader` داده نشده
- [ ] EXECUTE فقط روی فهرست سفید سند بالا داده شده
- [ ] رمز قوی و یکتا (با `CHECK_POLICY=ON`)
- [ ] در صورت تغییر نیازها، REVOKE سریع:

```sql
REVOKE EXECUTE ON OBJECT::dbo.[ApispSelectCompany] FROM [ibk_reader];
-- یا حذف کامل دسترسی:
USE [CRM]; DROP USER [ibk_reader];
USE [master]; DROP LOGIN [ibk_reader];
```

---

## فاز ۱۱ — نکتهٔ مهم: EXECUTE دیگر لازم نیست

از فاز ۱۱ **اجرای Stored Procedure در IdealBridge به‌کلی غیرفعال** است؛ بنابراین:

- **هیچ مجوز EXECUTE ندهید** — سرویس فقط `SELECT` مستقیم روی جداول می‌زند.
- اگر قبلاً EXECUTE داده بودید، حذفش کنید: `REVOKE EXECUTE ON OBJECT::dbo.ApispSelectCompany FROM ibk_reader;` (اختیاری — بستگی به سیاست شما).

### مجوز VIEW DEFINITION (فقط برای ابزار کاوش)

برای آنکه `IdeaSchemaDump` بتواند متن تعریف SP/ویوها را هم استخراج کند (برای مقایسهٔ نسخه‌ها) به‌اختیار:

```sql
GRANT VIEW DEFINITION TO ibk_reader;
```

بدون این مجوز ابزار کار می‌کند ولی به‌جای متن تعریف، عبارت «بدون مجوز VIEW DEFINITION» ثبت می‌شود. این مجوز فقط «خواندن متن تعریف» است و هیچ دسترسی اجرایی اضافه نمی‌کند.
