# نقشهٔ جامع دیتابیس Ideal CRM (crmideal)

> سند فاز ۱۲ — نگاشت هوشمندی دیتابیس و API · تهیه‌شده صرفاً از شواهد ایستا (SSDL + کاتالوگ SQL + سورس دیکامپایل‌شده)

## ۰. وضعیت صداقت

| مورد | مقدار |
|---|---|
| نسخهٔ سورس مرجع | **3.1.18.187** (دیتابیس منطقی 4.4.3.213) |
| نسخهٔ نصب‌شدهٔ واقعی | **3.1.16.169.0303** — **بدون دسترسی زنده** (Blocked) |
| منبع ۱ — ساختار جداول | `Models/CRMTabel.ssdl` — **۶۳۳ EntityType** با نوع/طول/دقت/Nullable/Identity هر ستون |
| منبع ۲ — تحول ساختار | کاتالوگ نصاب `CRM__Update_187.exe` — **۵۹,۱۲۴ دستور SQL** در ۱۱ سبد (V1…V8 + UPDPROJ + UPDOTHER + FORMS) |
| منبع ۳ — رفتار برنامه | متن کامل ۱۷,۴۳۸ `CREATE PROC` و ۵۵۴ `CREATE FUNC` و کوئری‌های درون‌برنامه‌ای (۱۴۳ فرم فعال) |
| وضعیت اعتبار | **همهٔ ادعاهای این سند دربارهٔ «ساختار در نسخهٔ ۱۸۷» قابل‌راستی‌آزمایی از منابع بالا است؛ هر ادعا دربارهٔ دیتابیس نصب‌شدهٔ 3.1.16 صریحاً «Unverified» علامت‌گذاری شده است.** |

طبقه‌بندی روابط (در سراسر سند):

- **[FK]** = قید FOREIGN KEY واقعی در DDL کاتالوگ نصاب (قابل استعلام از `sys.foreign_keys` در دیتابیس زنده)
- **[Logical]** = رابطهٔ منطقی با شاهد کد (SQL خود Ideal به آن join می‌زند) ولی بدون قید FK در کاتالوگ
- **[Unverified]** = حدسی/نامشخص — نیازمند کاوش زنده

## ۱. نمای کلی و آمار

| سنجه | مقدار (نسخهٔ ۱۸۷) |
|---|---|
| جدول (EntityType در SSDL) | ۶۳۳ |
| ویو (`CREATE_VIEW` در کاتالوگ) | ۱۲۲ |
| تریگر (`CREATE_TRG`) | ۸ |
| رویهٔ ذخیره‌شده (`CREATE_PROC`) | ۱۷,۴۳۸ دستور (شامل بازنگری‌های مکرر هر SP در طول نسخه‌ها) |
| تابع (`CREATE_FUNC`) | ۵۵۴ |
| ایندکس (`CREATE_IDX`) | ۱۱۵ |
| قید FK در کاتالوگ | ۷۶۲ |
| قید UNIQUE صریح در کاتالوگ | ۰ (یکتایی عملاً با PK و ایندکس‌های `UNIQUE CLUSTERED` روی ویوها) |

**سبدهای نسخهٔ کاتالوگ** (مهم برای سازگاری با 3.1.16):

| سبد | بازهٔ نسخهٔ برنامه | تعداد دستور |
|---|---|---|
| V1 | 2.2.6.43.9108 → 3.3.0.88.9304 | ۶۲۰ |
| V2 | 3.3.1.90.9306 → 4.3.2.115.9411 | ۸۳۹ |
| V3 | 4.3.2.116.9411 → 4.3.5.131.9510 | ۸۲۳ |
| V4 | 4.3.4.132.9510 → 4.3.4.143.9609 | ۷,۲۲۷ |
| V5 | 4.3.4.143 → 4.3.7.157.9905 | ۹,۴۸۴ |
| V6 | 4.3.6.143.9609 → 4.3.9.171.0012 | ۷,۳۷۴ |
| V7 | 4.3.6.145.40103 → 4.3.9.172.0103 | ۱۴,۸۱۴ |
| V8 | 4.3.6.143.9609 → 4.4.3.213.0507 | ۱۷,۲۲۵ |
| FORMS | کوئری‌های درون‌برنامه‌ای | ۶۹۹ |

> نسخهٔ نصب‌شده 3.1.16.169.0303 قدیمی‌تر از تمام افزوده‌های V6/V7/V8 است؛ فهرست دقیق ستون‌های پرریسک در سند `IDEAL_SCHEMA_AUDIT.md` §۳.

## ۲. قراردادهای نام‌گذاری (برای همهٔ جداول تقریباً یکسان)

هر جدول هستهٔ Ideal این ستون‌های «اداری» را دارد:

| ستون | معنا | شاهد |
|---|---|---|
| `UserId` | **آخرین ویراستر** (نه سازنده) | SP به‌روزرسانی: `UPDATE CrmCompany SET ... [UserId]=@UserId, [RegisterDate]=@RegisterDate WHERE CompanyID=@CompanyId` |
| `RegisterDate` (datetime) + `RegisterDatePersian` (nvarchar(8)، جلالی `YYYYMMDD`) | **زمان آخرین ویرایش** | همان UPDATE بالا |
| `FirstRegisterUserId` / `FirstRegisterDate` / `FirstRegisterDatePersian` | سازنده / زمان ایجاد | قرارداد یکسان در ۶۳۳ جدول |
| `Year1`, `Month1` | سال/ماه مالی-شمسی ثبت رکورد | — |
| `GUId` (uniqueidentifier) | شناسهٔ همگام‌سازی سمت کلاینت Ideal (مکانیزم sync خود CRM) | — |
| `AppType` (varchar(20)), `LanguageID` (int) | برنامهٔ ثبت‌کننده و زبان (جدول‌های `_Lang` همتای چندزبانه دارند) | — |
| `FPId` | دورهٔ مالی جاری → `WSFinancialPeriod(ID)` | [FK] روی `WSOrderPayments.FPId` و `WSPreOrderPayments.FPId` |

**PK پایدار:** تقریباً همهٔ جداول PK از نوع `int IDENTITY(1,1)` با نام `<Table>ID` دارند (مثلاً `CompanyID`, `CompanyPersonID`, `ConversationID`, `ProductID`, `OrderID`, `PreOrderID`). Keyset pagination روی این PKها امن است.

## ۳. دامنهٔ A — مشتریان، اشخاص و آدرس‌ها

### ۳.۱ `CrmCompany` — مشتری (PK: `CompanyID`، ۱۲۰ ستون)

ستون‌های کلیدی (نوع/Nullable از SSDL):

- هویت: `cmpNumber` (int، شمارهٔ سیستمی مشتری)، `cmpCode` (nvarchar، کد کاربر-تعریفی؛ در نسخه‌های جدید محتوای JSON چندکدی — Unverified برای 169)، `cmpName`، `cmpNameEng`، `cmpNameOfficial` **(افزودهٔ V6 — پرریسک برای 169)**، `cmpFame`، `cmpActivityType`
- دسته‌بندی: `cmpTitleId` → `CrmCompanyTitle`، `cmpGroupId` → `CrmCompanyGroups`، `cmpSubGroupId` → `CrmCompanySubGroups`، `cmpGroupIdII/III/IV` → `CrmCompanyGroupsII/III/IV`، `cmpTypeId` → `CrmCompanyType`، `cmpPresentationId` → `CrmCompanyPresentation` (همه [Logical]؛ فقط ستون‌های ارجاع‌دهنده بدون قید FK در کاتالوگ)
- تماس: `cmpPreTel/cmpTel/cmpTelUpTo/cmpTelDesc`، `cmpPreTelII/cmpTelII/...`، `cmpMobile`، `cmpFax`
- جغرافیا: `cmpCountryId` → `Country`، `cmpProvinceId` → `Province`، `cmpCityId` → `City` (زنجیرهٔ [Logical]؛ `City.ProvinceId → Province` [Logical]، `Province.CountryId → Country` [Logical])، `cmpAddress/cmpAddressDesc/cmpZipCode/cmpPostBox`، مختصات `cmpCoordinateLatitude/Longitude/ZoomLevel/LastDate`
- ثبتی/مالی: `cmpRegistrationNumber`، `cmpEconomicCode`، `cmpNationalCode`، `cmpBuyLimit`، `cmpAccountNumber`
- انتساب: `cmpReferUserId` → `Users(UserId)` **[FK]**، `cmpMainPersonId` → `CrmCompanyPersons` [Logical]، `UserId` (آخرین ویراستر) → `Users` **[FK]**
- وضعیت: `cmpIsDraft` (bit، افزودهٔ V5)، `cmpKind` (V5)، `cmpFirstRegisterUserId`/`FirstRegisterUserId` → `Users` **[FK]**
- **حساس:** `cmpPassword` (رمز پورتال مشتری) — هرگز نباید SELECT شود

### ۳.۲ `CrmCompanyPersons` — اشخاص مرتبط با مشتری (PK: `CompanyPersonID`، ۸۰ ستون)

- `prsCompanyId` → `CrmCompany.CompanyID` **[Logical]** (بدون FK در کاتالوگ؛ join دائمی در SQL خود Ideal)
- نام: `prsFName`، `prsLName`؛ ارجاع فرهنگ‌نامه‌ها: `prsTitleId` → `CrmPersonTitle`، `prsJobId` → `CrmPersonJobs(PersonJobID)` [Logical] (شاهد: FK همانند روی جدول الگو `CrmCompanyPersonsTemplate.prsJobId → CrmPersonJobs.PersonJobID` **[FK V4]**)، `prsTypeId` → `CrmPersonType`، `prsGroupId` → `CrmPersonGroups`، `prsSexId` → `Sex`، `prsEducationId` → `Education`، `prsDepartmentId` → `CrmPersonDepartments` (همه [Logical])
- **نام ستون‌های واقعی فرهنگ‌نامه‌ها** (مهم — نام‌های دیگر در هیچ نسخه‌ای وجود نداشته‌اند):
  - `CrmPersonJobs`: PK `PersonJobID`، نام `Jobs`
  - `CrmPersonDepartments`: PK `PersonDepartmentId`، نام `PersonDepartment`
  - `CrmPersonGroups`: PK `PersonGroupID`، نام `PersonGroup`
  - `Sex`: PK `SexID`، نام `SexType`
- تماس: `prsPreTel/prsTel/prsTelUpTo/prsTelDesc/prsTelII/prsFax/prsMobile/prsWebSite/prsEmail/prsEmailII`
- جغرافیا: `prsCountryId/prsProvinceId/prsCityId` + آدرس/کدپستی/صندوق
- PII: `prsNationalCode` (کد ملی)، `prsIdentityNumber` (شماره شناسنامه)، `prsFatherName`، `prsBirthDate/BirthPlace`، `prsIsMarried/MarriageDate`
- وضعیت: `prsWorkingOut` (خارج از شرکت)، `prsStopSendSms`، `ImportDate/ImportDateTime`

### ۳.۳ `CrmCompanyAddresses` — آدرس‌های اضافی (PK: `CompanyAddressId`، ۲۵ ستون)

- `cmpaddCompanyId` → `CrmCompany` [Logical]
- `cmpaddTypeId` → `CrmCompanyAddressType(CompanyAddressTypeId)` **[FK V7: `FK_CrmCompanyAddresses_CrmCompanyAddressType`]** — دقت: خودِ ستون `cmpaddTypeId` افزودهٔ V7 است (RZ14010912) → برای 169 **پرریسک**
- `cmpaddCityId` → `City` [Logical]؛ متن `CompanyAddress`، `cmpaddDesc/ZipCode/PostBox`، مختصات `cmpaddCoordinate*`
- نام واقعی ستون نام نوع آدرس در `CrmCompanyAddressType`: `CompanyAddressTypeName` (نه `CompanyAddressType`)

### ۳.۴ `CrmClients` — **نه مشتریان!** رجیستری نصب کلاینت‌ها (V6)

جدول `CrmClients` (ایجادشده در V6) دربارهٔ «نصب‌های نرم‌افزار کلاینت Ideal» است، نه اشخاص حقیقی/حقوقی مشتری: `ClientId`, `ClientTitle`, `ClientNumber`, `ClientCoName`, `ClientUrl`, `ClientLockSerial`, `ClientSoftVersion`, `ClientRegisterCode`, `ClientInActive`. برای MedPad به‌عنوان دامنهٔ «مشتری» بی‌ارزش و در فهرست مجاز نیست.

### ۳.۵ جداول دسترسی کاربر↔مشتری (غیر لازم برای MedPad فقط-خواندن)

`CrmCompanyForbidden{City,Company,Department,Group,GroupIV,Province,SubGroup}` و `CrmCompanyJustAccess{...}` (هر کدام ~۱۴-۱۵ ستون با `CrmUserId`,`UserId` [FK → Users]) و `CrmCompanyUserForbidden` — سازوکار محدودسازی دید کاربران CRM خود Ideal. IdealBridge این لایه را اعمال نمی‌کند (توکن MedPad به کل دامنهٔ مجاز SELECT می‌زند) — دیده شود در سند امنیت.

## ۴. دامنهٔ B — کاربران، گروه‌ها و سِمت‌ها

### ۴.۱ `Users` (PK: `UserId`)

- ستون‌های موردنیاز MedPad: `FName`, `LName`, `PersCode`, `UserName`, `IsAdmin` (**nvarchar(50) با متن 'True'/'False' در ۱۸۷** — خوانندهٔ bool-like امن در IdealBridge)، `IsActive`, `Row`, `PositionId` → `UserPositions(PositionId)` [Logical], `UserGroupId` → `UserGroups(UserGroupId)` [Logical] (**ستون UserGroupId افزودهٔ V6 — پرریسک**)، `Mobile`, `MobileII`, `Tel`, `NationalCode`, `StartDate`, `ExpireDate` (**هر دو V6 — پرریسک**)، `Description`، `UserIsActiveInWinApp/WebApp/MobApp`، `ResponsibleUserId` → خودتابع **[FK V4]**
- **ستون‌های ممنوع (اعتبار/حریم خصوصی):** `Password` (nvarchar(50))، `IPAddress`، `ComputerName`، `InsuranceCode`، `MobImeiCode`, `MobHRMImeiCode`, `MobHRMLoginMode`, `UserLoginCheckLocationType`, `UserLoginCheckLocations`, `LinkAccUserCode`
- `UserDepartments` (PK: `DepartmentID`، نام: `Department`): فرهنگ‌نامهٔ دپارتمان‌های **کاربران** (متمایز از `CrmPersonDepartments` مخصوص اشخاص مشتریان)؛ `UserId` → Users **[FK V4]**

### ۴.۲ `UserGroups` (PK: `UserGroupId`، نام: `GroupName`) و `UserPositions` (PK: `PositionId`؛ `ParentId` درخت سلسله‌مراتب، `PositionName`, `PositionCode`, `PositionManager`, ...)

## ۵. دامنهٔ C — محصولات، قیمت و انبار

### ۵.۱ `WSProducts` (PK: `ProductID`)

- شناسایی: `PrdCode`, `PrdName`, `PrdLatinName`, `PrdType`, `PrdModel`, `PrdFirstBarcode` (+بارکد دوم/سوم)، سریال‌ها
- دسته‌بندی: `PrdGroupID` → **`WSProductSecondGroup(PrdSecondGroupID)`** [Logical] — شاهد: `WSspSelectProductsByFSGId` می‌نویسد `(SELECT FirstGroupId FROM dbo.WSProductSecondGroup WHERE PrdSecondGroupID = Fn.PrdGroupID)`؛ یعنی گروه محصول روی جدول گروه **دوم** است و `WSProductSecondGroup.FirstGroupId` → `WSProductFirstGroup` [Logical]
- مشخصه: `PrdColorId` → `WSProductColor(ProductColorID; Color, ColorEn)` [Logical]؛ `PrdUnitId` → `WSProductUnits(ProductUnitID; Unit, QuantityInUnit)` [Logical]
- وضعیت: `PrdInActive` (**V6 — پرریسک**)، `PrdInactiveInSale`/`PrdInactiveInBuy` (V2)، آستانه‌ها: `PrdMinQty`/`PrdMaxQty` (پایه) و `PrdMinQuantity`/`PrdMaxQuantity` (**V6 — پرریسک**)، `PrdWeight` (**V8 — پرریسک**؛ RZ14031114)
- `WSProductSpecification` (مشخصات فنی)، `WSProductPicture`

### ۵.۲ قیمت — `WSProductPrice` + `WSProductPriceGroup`

**هشدار اصلی فاز ۱۲: وجود ردیف در `WSProductPrice` به‌هیچ‌وجه «قیمت نهایی فروش» نیست.**

ساختار ردیف قیمت (PK: `PrdPriceID` identity):

- `PrdId` → `WSProducts` [Logical]، `ProductPriceGroupId` → `WSProductPriceGroup(ProductPriceGroupID)` **[FK V4]**
- `WHId` → انبار **[FK V4]** (قیمت می‌تواند انبار-خصیص باشد)، `CurrencyUnitId` → `WSCurrencyUnits` [Logical]، `FPId`/`Month1` (دورهٔ مالی)، `CId` (Unverified — احتمالاً مرکز/Center)
- اجزا: `Price`، `CurrencyPrice`، `CooperationPrice` (قیمت همکاری)، `PricePercent`، `DiscountPrecent`، `Discount`، `OtherPrice`، `PrePaymentPrice`، `TaxIndex`
- تاریخ سند: `DocDate` (nvarchar(50))، `DocDateTime` (datetime)، `DocNumber`

منطق قطعی قیمت پیش‌فرض (متن تابع `WSfnReturnProductPrice` در کاتالوگ):

```sql
SELECT TOP 1 PrdId, DocDate, DocNumber, Price, CurrencyPrice, ..., Discount, OtherPrice
FROM dbo.WSProductPrice PP
WHERE PrdId = @ProductID AND ProductPriceGroupId = @ProductPriceGroupId
ORDER BY DocDate DESC
```

- یعنی «آخرین ردیف قیمتِ محصول در گروه-قیمت، بر اساس تاریخ سند» — بدون در نظر گرفتن انبار/دوره/مشتری در این تابع.
- گروه قیمت پیش‌فرض: رکورد ۱ «لیست پیش فرض» (seed کاتالوگ؛ `UPDATE WSProductPrice SET ProductPriceGroupId = 1 WHERE ProductPriceGroupId IS NULL`).
- قیمت قلم سفارش به‌صورت جداگانه توسط خانوادهٔ `WSspAutoCalcOrderItemPrice` / `MobspAutoCalcOrderItemPrice` و قیمت‌گذاری مشتری-خصیص (`WSspCmpPrdSalePriceHistory`, `WSspReturnPricePartRateFromCmpGroupII` — نرخ گروه مشتری II) محاسبه می‌شود؛ `WSOrderItems.ordIPrdPriceGroupID` گروه-قیمتِ لحظهٔ ثبت را ثبت می‌کند.
- ایندکس V8: `IX_WSProductPrice_DocDateTime (DocDateTime DESC, PrdPriceID DESC)` — tie-break با PK.
- `WSProductCost`/`WSProductCostGroup` ساختار موازی برای **بهای تمام‌شده** (Cost، حمل، ترخیص، ...) — برای MedPad لازم نیست.

### ۵.۳ موجودی — محاسبه از اسناد، نه ستون روی محصول

شاهد قطعی (متن `WSspRpt_WareHouseStock`):

```sql
-- جمع اقلام اسناد انبار به تفکیک جهت سند:
CASE WHEN D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)
     THEN SUM(DI.Quantity) END InQuantity,
CASE WHEN D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)
     THEN SUM(DI.Quantity) END OutQuantity
-- موجودی = SUM(In) - SUM(Out)  به تفکیک FPId + WHId + محصول
FROM dbo.WSDoc D JOIN dbo.WSDocItems DI ON ...
```

- **موجودی = تابعی از اسناد انبار (`WSDoc`+`WSDocItems` با جهت `WSDocOpr.OprType`: 1=ورود، 2=خروج)** به تفکیک دورهٔ مالی و انبار؛ روی `WSProducts` فقط آستانه‌ها (`PrdMinQty/MaxQty`, `PrdMinQuantity/MaxQuantity`) و شمارش دستی ماژول فروشگاه (`PrdSHPStockManualyCount`) نگه‌داری می‌شود.
- `WSDoc` (PK: `DocID`): `DocNumber`, `DocDate`, `WHId`/`WHIdI` (انبار مبدأ/مقصد — `WHIdI` → `WsWareHouse` **[FK V4]**)، `FPId`، `CompanyId` → `CrmCompany` **[FK V4: FK_WSDoc_CrmCompany]**، `OprId` → `WSDocOpr`
- `WSDocItems` (PK: `DocItemID`): `DocId`، `PrdId`، `WHId`، `Quantity`، ایندکس V8: `IX_WSDocItems (PrdId, DocId, WHId, DocICId)`
- `WSStockSupply`/`WSStockSupplyItems` (انبارگردانی/تأمین موجودی): سند `stsup*` با وضعیت‌های `stsupIsVerified/stsupIsCanceled/stsupIsFixed` و پیوند به پیش‌سفارش `stsupPreOrderId` → `WSPreOrder` [Logical]؛ اقلام: `stsupIPrdId` → `WSProducts` [Logical]، `stsupIWHId` → انبار، `stsupIPreOrderId/stsupIPreOrderItemId` → پیش‌سفارش [Logical]
- `WsWareHouse` (PK: `WareHouseID`): `WrhsName/WrhsCode/WrhsAddress/WrhsTel.../WrhsDeActive (V5)/OrderView`

## ۶. دامنهٔ D — پیش‌سفارش و سفارش

### ۶.۱ فرهنگ عملیات: `WSOrderOpr` (PK: `OrderOprID`)

- `Name` (نام فارسی عملیات)، `GUId`، `OprType` (int؛ V1: `UPDATE WSOrderOpr SET OprType = Type` — جهت عملیات)، `OrderView`، `DocOprId` → `WSDocOpr(DocOprID)` **[FK V4]** (عملیات سند انبار متناظر)، `VerifyAfterIssue` (V7)، `Taxable`
- دادهٔ seed کاتالوگ (V1):

| OrderOprID | Name | OprType |
|---|---|---|
| ۲ | فاکتور فروش غير رسمي | ۲ |
| ۳ | فاکتور برگشت از فروش رسمي | ۱ |
| ۴ | فاکتور برگشت از فروش | ۱ |
| ۵ | فاکتور اماني | ۲ |

(ردیف ۱ در seed فوق حذف شده — «فاکتور فروش» رسمی؛ مقادیر نهایی روی دیتابیس زنده Unverified.) **OprType=۱ برگشت از فروش، OprType=۲ فروش غیررسمی/امانی.** هر تحلیل فروش باید `OprType` را فیلتر کند.

### ۶.۲ `WSPreOrder` (PK: `PreOrderID` identity، ۱۳۳ ستون)

- پیوند مشتری: `pordCompanyId` → `CrmCompany` [Logical]، `pordCompanyPersonId` → `CrmCompanyPersons` [Logical]، `pordProjectId` → `CrmProjects` [Logical]
- شماره/تاریخ: `pordNumber` (bigint)، `pordDate` (nvarchar(8) جلالی)، `pordDateTime`، `pordDay/pordTime`
- مبالغ: `pordItemsAmount`, `pordInstallAmount`, `pordDiscount`, `pordSumAmount`, `pordTax`, `pordTaxIndex`, `pordCalculateTax`, `pordTotalAmount`
- وضعیت واقعی: `pordIsVerified` (bit) + `pordVerifierId` + `pordVerifiedRegisterDate`، `pordStatusId` → `WSPreOrderStatus` [Logical]، `pordChangeStatusDate` (**V8 — پرریسک**)، `pordIsFixed`، `pordExpireDate`
- عملیات: `PreOrderOprID` → `WSPreOrderOpr(PreOrderOprID)` [Logical] (جدول موازی `WSOrderOpr` برای پیش‌سفارش: `PreOrderOpr`, `OrderView`, ...)
- نسخه‌ها: `pordParentPreOrderId` (درخت بازنگری) + `pordNumberRevision` — یک «شماره پیش‌سفارش» می‌تواند چند رکورد بازنگری داشته باشد
- انتساب: `pordReferUserId` → `Users` **[FK V3]**، `pordFirstRegisterUserId` → `Users` **[FK V3]**، `pordSellerId`، `pordSaleCenterId`، `pordDefWHId`، `pordDefPrdPriceGroupId` → `WSProductPriceGroup` [Logical]
- مالی: `FPId` → `WSFinancialPeriod` [Logical]، `pordCurrencyUnitId` → `WSCurrencyUnits` [Logical]، `pordPayConditionId`, `pordCreditDurationId`, `pordDeliveryTimeId`

### ۶.۳ `WSOrder` (PK: `OrderID` identity، ۱۷۷ ستون)

- **پیوند به پیش‌سفارش: `PreOrderId` → `WSPreOrder(PreOrderID)` [Logical] — قید FK در کاتالوگ وجود ندارد؛ رابطهٔ ۱:N (یک پیش‌سفارش → چند سفارش/برگشت). شاهد: تابع `WSfnReturnOrderFromPreOrder`: `SELECT ... FROM dbo.WSOrder WHERE PreOrderId = @PreorderID`.**
- `OrderOprID` → `WSOrderOpr` [Logical]، `PreOrderVerifierId`
- مشتری/شخص/پروژه: `ordCompanyId` → `CrmCompany` [Logical]، `ordCompanyPersonId` → `CrmCompanyPersons` [Logical]، `ordProjectId` → `CrmProjects` [Logical]
- مبالغ: `ordItemsAmount/ordInstallAmount/ordDiscount/ordSumAmount/ordTax/ordTaxIndex/ordCalculateTax/ordTotalAmount/ordItemCount`
- وضعیت: `ordIsVerified` + `ordVerifierId` → `Users` **[FK V4]** + `ordVerifiedRegisterDate`، `ordStatusId` → `WSOrderStatus(OrderStatusId)` [Logical]، `ordIsFixed`، `ordSellerId`
- انتساب: `ordReferUserId` → `Users` **[FK V4]**، `ordFirstRegisterUserId` → `Users` **[FK V4]**، `UserId`/`RegisterDate` (آخرین ویرایش)
- **وجود رکورد در `WSOrder` ≠ فروش قطعی** — وضعیت واقعی = ترکیب `ordIsVerified` + `WSOrderOpr.OprType` (1=برگشت!) + `ordStatusId`؛ و سند انبارِ متناظر در `WSDoc` صادر شده باشد (خانوادهٔ `WSspIssueStockSupplyFromPreOrder`/`WSspReturnOrderFromPreOrder` جریان صدور را مدیریت می‌کنند).

### ۶.۴ اقلام و پرداخت‌ها

- `WSPreOrderItems` (PK: `PreOrderItemId`): `PreOrderId`، `pordIPrdId` → `WSProducts` [Logical]، `pordIQuantity/pordIPrice/pordITotalPrice`، تخفیف‌ها (`pordIDiscount/DiscountI/DiscountPercent/DiscountIPercent`)، `pordIPrdUnitId` → `WSProductUnits` **[FK V4]**، `pordICurrencyUnitId` → `WSCurrencyUnits` **[FK V4]**، `pordIPrdPriceGroupID` (گروه قیمت لحظهٔ ثبت)، مالیات `pordITax/...`
- `WSOrderItems` (PK: `OrderItemID`): همان الگو + `ordIWHId` → انبار [Logical]، `ordIPricePartRate/PricePartI/II`، `ordIRefOrderItemId`، `ordILinkedParentItemId`؛ `ordIPrdUnitId`/`ordICurrencyUnitId` **[FK V4]**
- `WSPreOrderPayments` (PK: `PreOrderPaymentId`): `pordpayPreOrderId` → پیش‌سفارش [Logical]، `pordpayTypeId` → `WSOrderPaymentTypes` [Logical]، `pordpayAmount/pordpayDocNumber/pordpayDocDate/pordpayDocAmount`، `FPId` → `WSFinancialPeriod(ID)` **[FK V4]**
- `WSOrderPayments` (PK: `OrderPaymentId`): `ordpayOrderId` → سفارش [Logical]، `ordpayTypeId` → `WSOrderPaymentTypes` [Logical]، **`PreOrderPaymentId` → `WSPreOrderPayments` [Logical]** (ردیف پرداخت سفارش از پرداخت پیش‌سفارش کپی می‌شود)، `ordpayDocId`، `FPId` → `WSFinancialPeriod` **[FK V4]**
- `WSPreOrderDiscounts/WSOrderDiscounts` و `WSPreOrderCommissions/WSOrderCommissions` (پورسانت‌ها؛ `WSOrderCommissions.CommIsPaidPayRollUserCycleId` → `PayRollUserCycle` **[FK V5]**)
- فرهنگ‌ها: `WSOrderStatus`/`WSPreOrderStatus` (نام وضعیت + `FPId`)، `WSOrderPaymentTypes` (`ordpayType`, `ordpayTypeIsChq`, `DeActive`, پرچم‌های پرداخت آنلاین/پیوست، `Tsp*` سامانه مالیاتی)، `WSFinancialPeriod` (PK: `ID`؛ `Name`, `FDate`, `TDate`)، `WSCurrencyUnits` (`CurrencyUnit`, `IsDecimal`)، `WSSettlementType` (`WSOrder.ordSettlementTypeId` → **[FK V4]**)، `WSGuaranty`, `WSPayCondition`, `WSCreditDuration`, `WSDeliveryTime`

## ۷. دامنهٔ E — فعالیت‌های CRM

### ۷.۱ `CrmConversation` (PK: `ConversationID`، ۵۹ ستون)

- پیوند: `cnvsCompanyId` → `CrmCompany` [Logical]، `cnvsPersonId` → `CrmCompanyPersons` [Logical]، `cnvsProjectId` → `CrmProjects` [Logical]، `cnvsUserId`/`cnvsReferUserId` → `Users` [Logical]
- موضوع/وضعیت: `cnvsTopicId` → `CrmConversationTopics` [Logical] (ستون نام: **`Topic`**، PK: `ConversationTopicsID`)، `cnvsStatusId` → `CrmConversationStatus` [Logical] (ستون نام: **`Status`**؛ `GroupId` → `CrmConversationStatusGroups` **[FK V2]**)، `cnvsPriorityId` → `CrmConversationPriority`
- زمان: `cnvsDate/cnvsDay/cnvsTime/cnvsDateTime`، یادآوری `cnvsRemindDate/Time/DateTime/ForAllarm`، `cnvsRemindOk`
- تیکت: `cnvsIsTicket`، `cnvsIsTicketNew` (**V7 — پرریسک**)، `cnvsTicketIsRead`، `cnvsDoingTime/From/To/Sec`، `cnvsStatusProcessKindId/StatusGroupId/StatusResultId`
- متن: `cnvsSubject` (nvarchar(50))، `cnvsDesc` (nvarchar(max))
- **تریگر روی این جدول:** `CrmTrgConversationManageAlarmChangesInsertUpdate/Delete` (مدیریت زنگ‌های هشدار) — فقط-خواندن بودن IdealBridge تحت تأثیر نیست.

### ۷.۲ `CrmConversationReferUsers` (PK: `ConversationReferUserID`): `ConversationId` → مکالمه [Logical]، `ReferUserId` → `Users` [Logical]، `PriorityId`

### ۷.۳ `CrmCallHistory` (PK: `CallHistoryID`، ۴۶ ستون)

- `CompanyID` → `CrmCompany(CompanyID)` **[FK V4]**، `CompanyPersonId` → `CrmCompanyPersons(CompanyPersonID)` **[FK V4]** — تنها جدولِ فعالیت با FK واقعی به مشتری
- `CallTypeId` → `CrmCallType` [Logical]، `UserID` → `Users`، `CallDate`/`CallTime` (nvarchar(50))، `CallDateTime` (datetime)، `CallerIDDetectData`

### ۷.۴ `CrmUserTasks` — یادآوری‌ها/تقویم (PK: `UserTaskId`)

- `UserId` → `Users`، `UserTaskDate/Time/TimeEnd`، `UserTaskDidIt` (انجام‌شده)، `UserTaskRemindDate/Time/DateTime`، `UserTaskPriorityId` → `CrmUserTaskPriorities` (ستون نام: **`Priority`**)، `UserTaskGroupId` → `CrmUserTaskGroups` (ستون نام: **`UserTaskGroup`**)، `UserTaskIsPublic` (V1)، `UserTaskCompanyIds` (nvarchar(max)، **V7 — پرریسک**)، تکرارها، `ObjectTypeId/ObjectId` (پیوند چندریختی — Unverified معنای دقیق typeها)، تریگرهای `CrmTrgUserTaskManageAlarmChanges*`

### ۷.۵ `CrmProjects` (PK: `ProjectID`، ۸۲ ستون)

- `prjCompanyId` → `CrmCompany` [Logical]؛ عنوان/موضوع: `prjTitle`، `prjSubject` (**V6 — پرریسک**)، `prjDesc`
- شماره‌گذاری: `prjNumRef`/`prjNumR` (هر دو **V6 — پرریسک**)، `prjPostFix`
- زمان: `prjStartDate/StartTime/StartDateTime`، پایان `prjIsFinished`/`prjFinishedStatusId`/`prjFinishedDate(Time)`/`prjFinishedUserId`
- ارجاع: `prjStarterUserId`، `prjGradeId` → `CrmProjectGrade` (ستون نام: **`ProjectGrade**)، `prjPriorityId` → `CrmProjectPriority`، `prjGroupId` → `CrmProjectGroups(ProjectGroupID)` **[FK V4]** (ستون نام: **`ProjectGroup`**)، `prjcnvsStatusGroupId` → `CrmConversationStatusGroups` **[FK V4]**

## ۸. ویوها، ایندکس‌ها، تریگرها و SPها

### ۸.۱ ویوها (۱۲۲)

خانواده‌های مرتبط با دامنه‌های MedPad (همه V7/V8 — **روی 169 احتمالاً ناموجود**):

- `CRMvwSelectCompanyAndPersons{,_Lang}`، `CRMvwSelectCompanyAndPersonsAndProjects{,_Lang}`، `CRMvwSelectCompany...` — ویوهای خواندن مشتری+شخص (+پروژه)
- `WSvwSelectProducts{,_Lang}` — ویوی محصولات (V8)
- ویوهای سریال/سند: `WSvwSelectDocItemSerial...` و غیره
- چند ویو **ایندکس‌دار** (`CREATE UNIQUE CLUSTERED INDEX IDX_CompanyID_CompanyPersonID_ProjectID_ConversationID ON ...`) — روی نسخهٔ 169 نباید اتکا شود.

### ۸.۲ ایندکس‌های کاتالوگ (۱۱۵ مورد — نمونه‌های مهم)

- V2: `IX_CrmCompanyPersons` (روی ستون‌های موبایل/جست‌وجوی شخص)، `IX_WSDocItemSerials` (UNIQUE)
- V7/V8: موج عظیم `IDX_*` روی جداول همتای `_Lang` (CompanyID، CompanyPersonID، CrmProjectID، ConversationID، ProductID، prsId و ترکیب‌ها) — برای جست‌وجوی چندزبانه
- V8: `IX_WSProductPrice_DocDateTime (DocDateTime DESC, PrdPriceID DESC)`، `IX_WSDocItems (PrdId, DocId, WHId, DocICId)`
- **نبودِ ایندکس روی `RegisterDate` جداول هسته** — پنجرهٔ زمانی همگام‌سازی روی 169/187 بدون ایندکس است (خطر Full Scan) → در سند ممیزی §۶.

### ۸.۳ تریگرها (۸)

| تریگر | جدول | اثر |
|---|---|---|
| `CrmTrgManageInternalMessageChangesInsertDelete/Update` | `CrmInternalMessage` | همگام‌سازی تغییرات پیام داخلی |
| `CrmTrgUserTaskManageAlarmChangesInsertUpdate/Delete` | `CrmUserTasks` | مدیریت زنگ هشدار کار |
| `CrmTrgConversationManageAlarmChangesInsertUpdate/Delete` | `CrmConversation` | مدیریت زنگ هشدار مکالمه |
| `CRMtrgUpdateCompanyInfo` | `[FTM]..[Record]` (**between-database** — دیتابیس تلفنی FTM) | به‌روزرسانی اطلاعات مشتری از رکورد تماس تلفنی |

هیچ‌کدام مسیر خواندن IdealBridge را تغییر نمی‌دهند؛ `CRMtrgUpdateCompanyInfo` اصلاً در دیتابیس FTM ساخته می‌شود (خارج از crmideal).

### ۸.۴ رویه‌های ذخیره‌شده (خانواده‌های اصلی)

- `Apisp*` — API رسمی موبایل/سرویس Ideal (select/insert/update/delete برای همهٔ موجودیت‌ها؛ **صفحه‌بندی @PageNumber/@PageSize فقط در بازنگری پس از 3.1.16 — سند ۰۹**)
- `Mobsp*` — مسیر موبایل (محصول+قیمت، سفارش، کنترل موجودی: `MobspControlOrderItemsStock`, `MobspAutoCalcOrderItemPrice`)
- `WSsp*` — هستهٔ فروش/انبار (قیمت: `WSspReturnProductPriceAndPriceGroup`, `WSspSelectProductsLastPrice`؛ موجودی: `WSspRpt_WareHouseStock`, `WSspControlOrderItemsStock`؛ جریان سند: `WSspIssueStockSupplyFromPreOrder`, `WSspReturnOrderFromPreOrder`, `WSspIssueBuyOrderFromStockSupply`)
- `CRMsp*` — هستهٔ CRM؛ `SHP*` — ماژول فروشگاه

اجرای هیچ SPی برای IdealBridge لازم نیست (سیاست فقط-خواندن — سند ۰۶).

## ۹. یافته‌های همگام‌سازی (Incremental Sync)

| نیازمندی | وضعیت در Ideal |
|---|---|
| PK پایدار برای Keyset | ✅ همهٔ جداول هسته `int IDENTITY` |
| مهر زمان ویرایش | ✅ `RegisterDate` (datetime) + نسخهٔ جلالی — **معنای «آخرین ویرایش» با شاهد UPDATE SP اثبات شد (§۲)** |
| ویراستر | ✅ `UserId` (آخرین) / `FirstRegisterUserId` (سازنده) — با همان شاهد |
| rowversion / Change Tracking / CDC | ❌ هیچ‌کدام در کاتالوگ نصاب فعال/ایجاد نمی‌شود — وضعیت واقعی روی سرور مالک **Unverified** (فرمان بررسی در سند ممیزی §۷) |
| حذف نرم | ❌ جداول هسته `IsDeleted` ندارند (تنها `SmsReceive.IsDeleted` از V1) — **حذف‌ها ردیابی نمی‌شوند** |
| غیرفعال‌سازی (بدون حذف) | ✅ پراکنده: `WrhsDeActive` (V5)، `PrdInActive` (V6)، `ClientInActive`، `DeActive` روی انواع پرداخت و غیره |
| شناسهٔ همگام‌سازی سازنده | ✅ `GUId` (uniqueidentifier) روی همهٔ رکوردها |

**نتیجه:** استراتژی پایدار = Keyset روی PK + پنجرهٔ `RegisterDate` برای ویرایش‌ها + **آشتی‌سازی دوره‌ای کامل** (شمارش/بیشینهٔ PK در بازه) برای کشف حذف‌ها — چون هیچ سازوکار ردیابی حذف وجود ندارد. (جزئیات در سند ۱۰ و ممیزی §۶.)

## ۱۰. فرضیات Unverified (فهرست صریح)

1. تمام ادعاهای ساختاری این سند دربارهٔ **دیتابیس نصب‌شدهٔ 3.1.16.169.0303** — منبع فقط SSDL/کاتالوگ نسخهٔ ۱۸۷ است.
2. معنای دقیق `CId` (رایج روی جداول V4+: `cnvsCId`, `DocCId`, `stsupCId`, ...) — احتمالاً Center؛ شاهد قطعی نداریم.
3. مقادیر seed نهایی `WSOrderOpr` روی دیتابیس زنده (از جمله ردیف ۱).
4. محتوای `cmpCode` (تک‌کد یا JSON چندکدی) روی 169.
5. نوع دادهٔ واقعی `Users.IsAdmin` روی 169 (در ۱۸۷ رشتهٔ 'True'/'False').
6. فعال‌بودن Change Tracking/CDC/rowversion توسط مدیر روی سرور مالک.
7. وجود جداول کمکی V7/V8 (مثل `CrmCompanyCampaign`) روی 169.

هر هفت مورد با اجرای `IdeaSchemaDump` روی محیط واقعی و مقایسه با گزارش مرجع این فاز، به Verified تبدیل می‌شود.
