# فهرست مجاز امنیتی IdealBridge — جداول، ستون‌ها و مجوزهای SQL

> سند فاز ۱۲ — مبنای اعطای حداقلی مجوز SELECT روی دیتابیس `crmideal` · مکمل سند ۰۶ (سیاست فقط-خواندنی)

## ۱. اصول

1. **فقط SELECT** — هیچ INSERT/UPDATE/DELETE/MERGE/TRUNCATE/ALTER/DROP/CREATE و هیچ EXECUTE.
2. **اعطای سطح-جدول** (نه سطح-دیتابیس): `db_datareader` هم بیشتر از نیاز است؛ مجوز دقیق روی جداول فهرست‌شده پایین.
3. **ممنوعیت مطلق:** `db_owner`, `db_datawriter`, `db_ddladmin`, `db_securityadmin`, `ALTER`, `EXECUTE` (هر شیء)، `CONTROL`.
4. `VIEW DEFINITION` اختیاری است (فقط برای فرادیدهٔ دقیق‌تر `IdeaSchemaDump`) — با همان حساب فقط-خواندنی.
5. حساب سرویس IdealBridge ≠ حساب Ideal CRM ≠ sa. هیچ‌گاه sa/sysadmin/حساب اصلی Ideal.

## ۲. جداول مجاز (Allowlist)

### ۲.۱ جداول هستهٔ داده (مستقیماً توسط endpointها کوئری می‌شوند)

| # | جدول | هدف | ستون‌های لازم (فراتر از این لازم نیست) |
|---|---|---|---|
| 1 | `CrmCompany` | companies/sync | همهٔ ستون‌های `CompanySelectBase` به‌جز ستون‌های ممنوع §۳ |
| 2 | `CrmCompanyAddresses` | آدرس‌ها | CompanyAddressId, cmpaddCompanyId, cmpaddTypeId, cmpaddCityId, CompanyAddress, cmpaddDesc, cmpaddZipCode, cmpaddPostBox, cmpaddCoordinate*, RegisterDate |
| 3 | `CrmCompanyPersons` | persons/sync | ستون‌های `Base` کوئری اشخاص (به‌جز موارد PII تصمیم‌دار §۴) |
| 4 | `Users` | users | UserId, Row, FName, LName, PersCode, UserName, IsAdmin, IsActive, UserIsActiveInWinApp/WebApp/MobApp, Mobile, MobileII, Tel, PositionId, UserGroupId, NationalCode*, StartDate*, ExpireDate*, Description — **Password هرگز** |
| 5 | `CrmConversation` | conversations | ستون‌های SELECT کوئری مکالمات |
| 6 | `CrmProjects` | projects | ستون‌های SELECT کوئری پروژه‌ها |
| 7 | `CrmUserTasks` | reminders | ستون‌های SELECT کوئری یادآوری‌ها |
| 8 | `WsWareHouse` | warehouses | WareHouseID, Wrhs*, OrderView, RegisterDate |
| 9 | `WSProducts` | products | ستون‌های SELECT کوئری محصولات |
| 10 | `WSOrder` | orders | ستون‌های SELECT کوئری سفارش‌ها |
| 11 | `WSPreOrder` | preorders | ستون‌های SELECT کوئری پیش‌سفارش‌ها |
| 12 | `WSOrderOpr` | نام عملیات سفارش | OrderOprID, Name, OprType, DocOprId, OrderView |

### ۲.۲ جداول فرهنگ‌نامه (lookup — join/baseinfo)

`CrmCompanyTitle`, `CrmCompanyType`, `CrmCompanyGroups`, `CrmCompanySubGroups`, `CrmCompanyGroupsII`, `CrmCompanyGroupsIII`, `CrmCompanyGroupsIV`, `CrmCompanyPresentation`, `CrmCompanyAddressType`, `CrmPersonTitle`, `CrmPersonType`, `CrmPersonJobs`, `CrmPersonDepartments`, `CrmPersonGroups`, `Education`, `Sex`, `Country`, `Province`, `City`, `CrmProjectTitles`, `CrmProjectGroups`, `CrmProjectGrade`, `CrmProjectPriority`, `CrmConversationTopics`, `CrmConversationStatus`, `CrmUserTaskGroups`, `CrmUserTaskPriorities`, `UserGroups`, `UserPositions`, `WSCurrencyUnits`, `WSFinancialPeriod`

> برای این جداول فقط دو ستونِ Id و Name (+Parent در City/Province/CrmCompanySubGroups) لازم است — مجوز SELECT ستونی (`GRANT SELECT ON dbo.City (CityID, City, ProvinceId, ...)`) در SQL Server ممکن نیست؛ بنابراین مجوز جدولی اعطا می‌شود و «حداقل‌سازی» در لایهٔ SELECT کد اعمال می‌شود (بند ۶).

### ۲.۳ جداول مسیر آینده (فقط با تصمیم محصول بعدی — فعلاً در اعطا نیستند)

`WSProductPrice`, `WSProductPriceGroup`, `WSProductSecondGroup`, `WSProductFirstGroup`, `WSProductColor`, `WSProductUnits`, `WSDoc`, `WSDocItems`, `WSDocOpr`, `WSOrderItems`, `WSPreOrderItems`, `WSOrderPayments`, `WSPreOrderPayments`, `WSOrderPaymentTypes`, `WSOrderStatus`, `WSPreOrderStatus`, `WSPreOrderOpr`, `CrmConversationReferUsers`, `CrmCallHistory`, `CrmConversationPriority`, `CrmConversationStatusGroups`

> اگر/وقتی endpoint موجودی، قیمت، اقلام یا پرداخت ساخته شد، جدول متناظر به §۲.۱ منتقل شود — نه زودتر (اصل حداقل‌سازی).

### ۲.۴ فرادادهٔ سیستمی

- `sys.tables`, `sys.columns`, `sys.parameters`, `sys.objects`, `sys.indexes`, `sys.key_constraints`, `sys.foreign_keys`, `sys.sql_modules` — با مجوز `VIEW DEFINITION` (یا `PUBLIC` برای sys.views پایه) — فقط برای `SchemaProbe` و `IdeaSchemaDump`.
- توابع `DB_NAME()`, `@@SERVERNAME`, `@@VERSION` — بدون مجوز خاص.

## ۳. ستون‌های ممنوع (Denylist — هرگز SELECT نشوند)

| جدول | ستون(ها) | دلیل |
|---|---|---|
| `Users` | `Password` | اعتبارنامه — حتی در SELECT نمی‌آید (تضمین کد + تست فاز ۱۱) |
| `Users` | `IPAddress`, `ComputerName` | زیرساخت داخلی |
| `Users` | `MobImeiCode`, `MobHRMImeiCode`, `MobHRMLoginMode` | شناسهٔ دستگاه/احراز هویت موبایل |
| `Users` | `UserLoginCheckLocationType`, `UserLoginCheckLocations` | سیاست احراز هویت |
| `Users` | `LinkAccUserCode` | شناسهٔ حسابداری |
| `Users` | `InsuranceCode` | PII حساس |
| `CrmCompany` | `cmpPassword` | رمز پورتال مشتری |
| هر جدول | `LinkAcc*` (LinkAccData/…IdStr/…FirstTransferDate/…) | دادهٔ همگام‌سازی حسابداری — نویز و ریسک |
| هر جدول | `Tsp*` (TspCmpBbc/Bpn/Tob, TspOrdpayType*…) | شناسه‌های سامانهٔ مالیاتی |
| `SmsReceive`/`SmsSendDetail`/جداول پیامک | کل جداول | محتوای پیامک — خارج از دامنه |
| `CrmInternalMessage*` | کل جداول | پیام داخلی کارکنان — خارج از دامنه |
| `CrmBankingAccounts`, `CrmBankingBanks`, `CrmBankingBranches`, `CrmBankingAccountType` | کل جداول | اطلاعات بانکی |
| `CrmTimeAttendance*`, `CrmLeave*` | کل جداول | حضور و غیاب کارکنان — خارج از دامنه |
| `CrmClients` | کل جدول | رجیستری نصب کلاینت — بی‌ارزش برای MedPad (نقشه §۳.۴) |
| `CrmsysPasswordEncryptionHistory` | کل جدول | تاریخ رمزنگاری — حساس |
| `UsersPermission`, `CrmsysRolls`, `CrmsysRollPermission` | کل جداول | ماتریس مجوزهای داخلی CRM |

## ۴. PII تصمیم‌دار (اکنون افشا می‌شود — بازنگری حداقل‌سازی)

| فیلد API | منبع | وضعیت |
|---|---|---|
| `nationalCode` (users) | `Users.NationalCode` | کد ملی کارمندان — برای «نمایش پروفایل» لازم نیست؛ حذف یا نگه‌داشتن فقط با تصمیم صریح مالک |
| `nationalCode` (persons) | `CrmCompanyPersons.prsNationalCode` | کد ملی مخاطبان مشتری — برای احراز هویت تلفنی ممکن است لازم باشد؛ تصمیم مالک |
| `identityNumber` (persons) | `prsIdentityNumber` | شماره شناسنامه — همان وضعیت |
| `fatherName`, `birthDate`, `birthPlace`, `marriageDate` (persons) | `prsFatherName/...` | دادهٔ شخصی غیرضرور برای MedPad — کاندید حذف از DTO |
| `prsNationalCode`… در فیلترها | — | جست‌وجو با کد ملی مجاز بماند فقط اگر مالک نیاز اعلام کرد (پارامتر `mobile` فعلاً کافی است) |

**توصیهٔ فاز ۱۲:** در نخستین نسخهٔ_productive، DTO اشخاص به فیلدهای تماس+ساختاری محدود شود و PII کامل پشت یک پارامتر/نقاط تصمیم مالک برود. این تغییر رفتار API است و **عمداً در فاز ۱۲ انجام نشده** (فاز مستندسازی) — ببینید ممیزی §۸.

## ۵. اسکریپت اعطای مجوز (مرجع — با حساب admin فقط یک‌بار)

```sql
-- با حساب دارای اختیار (مثلاً sa) — نه حساب سرویس IdealBridge:
CREATE LOGIN IdealBridgeRO WITH PASSWORD = N'<قوی-و-مستقل>';
USE crmideal;
CREATE USER IdealBridgeRO FOR LOGIN IdealBridgeRO;
-- هستهٔ داده:
GRANT SELECT ON dbo.CrmCompany            TO IdealBridgeRO;
GRANT SELECT ON dbo.CrmCompanyAddresses   TO IdealBridgeRO;
GRANT SELECT ON dbo.CrmCompanyPersons     TO IdealBridgeRO;
GRANT SELECT ON dbo.Users                 TO IdealBridgeRO;
GRANT SELECT ON dbo.CrmConversation       TO IdealBridgeRO;
GRANT SELECT ON dbo.CrmProjects           TO IdealBridgeRO;
GRANT SELECT ON dbo.CrmUserTasks          TO IdealBridgeRO;
GRANT SELECT ON dbo.WsWareHouse           TO IdealBridgeRO;
GRANT SELECT ON dbo.WSProducts            TO IdealBridgeRO;
GRANT SELECT ON dbo.WSOrder               TO IdealBridgeRO;
GRANT SELECT ON dbo.WSPreOrder            TO IdealBridgeRO;
GRANT SELECT ON dbo.WSOrderOpr            TO IdealBridgeRO;
-- (هر ۳۱ جدول فرهنگ‌نامهٔ §۲.۲ به همین شکل)
-- اختیاری برای IdeaSchemaDump/SchemaProbe:
GRANT VIEW DEFINITION TO IdealBridgeRO;
-- صریحاً «نه»:
-- بدون EXECUTE، بدون db_datareader/db_owner/db_ddladmin/db_datawriter، بدون WRITEANY
```

گام‌های ۴ و ۵ سند ۰۶ (تست‌های deny: INSERT/UPDATE/DELETE/DROP/EXEC/… و چک‌لیست نهایی) بدون تغییر معتبرند.

## ۶. حداقل‌سازی در لایهٔ کد (تضمین‌های موجود)

1. **SELECT ستونی صریح** — هیچ `SELECT *` در مخازن وجود ندارد (بررسی ممیزی فاز ۱۲، ۱۴ بلوک SQL).
2. `Users.Password` در هیچ کوئری‌ای نیست؛ `ApiCmpPassword` (خروجی SP قدیمی Ideal) از نگاشت حذف شده.
3. `ReadOnlyCommandGuard` هر دستور غیر SELECT را پیش از اجرا رد می‌کند (شامل `NEXT VALUE FOR` از فاز ۱۱.۱-D)؛ `ReadOnlyGuardPolicy` در Production خاموش‌شدنی نیست.
4. `ApplicationIntent=ReadOnly` + `ApplicationName=IdealBridge` اجباری در Connection String (کارخانهٔ اتصال + خود IdeaSchemaDump).
5. `SecretRedactor` — Connection String/رمز در لاگ بازتاب نمی‌شود.
6. توکن‌های API فقط به‌صورت SHA-256 ذخیره می‌شوند؛ توکن متن-آشکار فقط یک‌بار در پاسخ ساخت نمایش داده می‌شود.

## ۷. لایهٔ دسترسی Ideal که IdealBridge اعمال نمی‌کند

جداول `CrmCompanyForbidden*` / `CrmCompanyJustAccess*` (دودمان دید کاربران CRM) توسط IdealBridge خوانده و اعمال نمی‌شوند؛ توکن MedPad عملاً «دید کامل مدیریت» دارد. این تصمیم آگاهانهٔ فاز ۱ است، اما برای بهره‌بردار مستند بماند: هر کسی به توکن MedPad دسترسی یابد، کل دامنهٔ مشتریان را می‌بیند. در صورت نیاز به محدودسازی، گزینه‌ها: فیلتر سمت IdealBridge روی `cmpReferUserId`، یا حساب SQL با viewهای محدود — هر دو خارج از فاز ۱۲.
