# سند مهندسی معکوس API نرم‌افزار Ideal CRM

> **وضعیت سند:** تکمیل‌شده — فاز ۱ و ۲ مأموریت IdealBridge
> **منبع بررسی:** سورس دیکامپایل‌شده `CRMIdealApi.dll` و `Models.dll` نسخهٔ **3.1.18.187** (موجود در مخزن، شاخهٔ develop زیر `project-analysis/decompiled/`) به‌همراه کاتالوگ کامل دستورات SQL (`CRM__Update_187.exe`).
> **نسخهٔ نصب‌شدهٔ واقعی:** **3.1.16.169.0303** — ساختار دیتابیس آن با نسخهٔ سورس **یکسان فرض نمی‌شود** (شرح در سند ۰۹).

---

## ۱. معماری کلی API اصلی Ideal

### ۱.۱ پشتهٔ فناوری

| جزء | فناوری |
|---|---|
| فریم‌ورک | ASP.NET Web API 2 روی .NET Framework 4.7 |
| هاست | IIS (وب‌اپلیکیشن جدا از سایت اصلی CRM) |
| دسترسی داده | Entity Framework 5 با مدل EDMX (`ApiModels.CRM`) |
| دیتابیس | SQL Server |
| احراز هویت | **ندارد** در سطح HTTP — نام کاربری/رمز داخل بدنهٔ هر درخواست |
| مستندسازی | Swagger/OpenAPI **ندارد** |
| لاگ خطا | ELMAH |
| سریالایز | Newtonsoft.Json |

### ۱.۲ کشف کلیدی: مدل EF کاملاً مبتنی بر Stored Procedure است

بررسی فایل‌های `ApiModels.CRM.csdl` نشان داد کانتینر `CRMEntities`:

- **۵۸۰ FunctionImport** دارد (همان SPها)،
- و **هیچ EntitySet جدولی ندارد** — یعنی API اصلی هیچ‌وقت مستقیم روی جدول `SELECT/INSERT` نمی‌زند؛ **تمام** دسترسی داده از طریق SPهای `Apisp*` (و چند تابع قابل‌ترکیب `Apifn*`) انجام می‌شود.

این یعنی هرگونه بازتولید API باید یا همان SPها را صدا بزند، یا معادل منطق آن‌ها را با SELECT مستقیم بازنویسی کند.

### ۱.۳ مسیریابی

از `WebApiConfig.cs`:

```
POST/GET  api/{controller}/{id}        → id فقط عددی
           api/{controller}/{action}/{name}
           api/{controller}/{action}   → پیش‌فرض action=Get
```

در عمل تقریباً همهٔ اکشن‌ها `[HttpPost]` هستند و پارامترها در **بدنهٔ JSON** ارسال می‌شوند (حتی عملیات خواندنی!).

---

## ۲. ساختار درخواست و پاسخ

### ۲.۱ پاکت پاسخ یکنواخت `ServiceResult<T>`

```json
{
  "Data":     <payload یا null>,
  "Status":   "Success" | "Fail" | "Error",
  "Message":  "پیغام"
}
```

- `Status` از enum `ServiceResultStatus` (Success=1, Fail=2, Error=3) با `StringEnumConverter`.
- **فیلد pagination جدا ندارد** — اطلاعات صفحه‌بندی داخل خود رکوردها می‌آید (ستون‌های `ApiRowNumber` و `ApiTotalCount` که خود SP تولید می‌کند).

### ۲.۲ الگوی ViewModel درخواست

هر اکشن یک ViewModel اختصاصی دارد؛ کلاس پایهٔ `PublicParameters` که در همه دیده می‌شود:

```csharp
public class PublicParameters {
    public string UserName;   // رمزگذاری‌شده با TripleDESC دیکامپایل‌شده
    public string Password;   // رمزگذاری‌شده با TripleDESC دیکامپایل‌شده
    public int UserId;
    public int? LanguageId;   // 1065=فارسی پیش‌فرض، 1033=انگلیسی، 1025=عربی
    public int? CenterId;     // چندمرکزی (multi-center)
    public string CenterCode;
}
```

### ۲.۳ صفحه‌بندی در API اصلی

- پارامترها: `PageNumber` و `PageSize` در ViewModel.
- اگر `PageNumber>0` و `PageSize` خالی باشد → `PageSize=20` می‌شود.
- اگر `PageNumber=0` → بدون صفحه‌بندی (همهٔ رکوردها!).
- مکانیزم در SP: `OFFSET/FETCH` + شمارش جداگانه برای `ApiTotalCount`.
- **نکتهٔ سازگاری:** پارامترهای صفحه‌بندی در تاریخ ۱۴۰۵/۰۲/۲۲ شمسی به SPها اضافه شده‌اند (`SOH14050222` در کامنت SPها)؛ این تاریخ **بعد از** ساخت نسخهٔ نصب‌شدهٔ 3.1.16 است، پس **احتمال جدی وجود ندارد در SPهای نسخهٔ نصب‌شده** — IdealBridge باید در زمان اجرا امضای SP را بررسی کند (شرح در سند ۰۹).

### ۲.۴ تاریخ‌ها

- ورودی‌ها رشتهٔ تاریخ شمسی‌اند (مثل `14030501`) و در کنترلر با `PersianDate.GetShamsi2Miladi` به میلادی تبدیل می‌شوند.
- فیلتر بازهٔ ثبت مشتری **باید جفت باشد** (`FromRegisterDate` و `ToRegisterDate` با هم) وگرنه شرط BETWEEN در SP اعمال نمی‌شود.

---

## ۳. احراز هویت و امنیت API اصلی

1. **بدون Token/Session:** نام کاربری و رمز Ideal CRM (رمزگذاری‌شده با TripleDES با کلید هاردکد `I Love GOD` — کلاس `Security.cs`) در **هر درخواست** در بدنه ارسال می‌شود.
2. اعتبارسنجی با SP: `ApispCheckUserAllowed(@UserName, @Password)` → برگرداندن `UserId` (۰ = نامعتبر). این SP صرفاً مقایسهٔ متنی با ستون‌های `Users.UserName`/`Users.Password` است (شرط IsActive حتی کامنت شده و **بررسی نمی‌شود**).
3. **گیت لایسنس:** در ابتدای هر اکشن `VersionBuyer.CRMApi` و مشابه آن بررسی می‌شود (مجوزهای حرفی U/P/O/W/... از SP `ApispSelectCrmsysSetting`).
4. **بدون Rate-Limit، بدون HTTPS-forcing، بدون نقش‌بندی** — هر کاربر معتبر CRM به همهٔ اکشن‌ها دسترسی دارد.
5. **خطر SQL Injection در SPهای خود Ideal:** بدنهٔ `ApispSelectCompany` پارامترها را با الحاق رشته در SQL داینامیک می‌سازد (مثلاً `@CmpCode` مستقیم داخل رشتهٔ `@QRY` قرار می‌گیرد) — این یعنی ورودی‌های IdealBridge باید همیشه پارامتری و اعتبارسنجی‌شده باشند و هرگز از خودِ SP برای ورودی نامعتبرCx امن نباشیم.

### ۳.۱ تصمیم امنیتی IdealBridge (مطابق مأموریت)

- مکانیزم رمزنگاری/کلید دیکامپایل‌شدهٔ Ideal **بازاستفاده نمی‌شود**.
- احراز هویت IdealBridge کاملاً مستقل: توکن اختصاصی MedPad با انقضا و ابطال.
- رمز عبور هیچ‌وقت در پاسخ نمی‌آید — حتی فیلدهای `Password`/`cmpPassword`/`prsPassword` که SPهای Ideal برمی‌گردانند، در لایهٔ نگاشت DTO **حذف** می‌شوند (Blacklist ستون حساس).

---

## ۴. جدول‌ها و SPهای درگیر (بر اساس نسخهٔ سورس 3.1.18.187)

### ۴.۱ SPهای خواندنی کلیدی و امضای دقیق (استخراج از CSDL)

| SP | امضای پارامترها | خروجی |
|---|---|---|
| `ApispCheckUserAllowed` | UserName:String, Password:String | Collection(Int32) |
| `ApispSelectCompany` | CompanyId, CmpCode, CmpNumber, FromRegisterDate, ToRegisterDate, FromFirstRegisterDate, ToFirstRegisterDate, LanguageID, DefaultLanguageID, CenterId, CenterCode, PageNumber, PageSize | ~۹۰ ستون + ApiRowNumber/ApiTotalCount |
| `ApispSelectCompanyById` | CompanyId, LanguageID, DefaultLanguageID, CenterId, CenterCode | رکورد کامل |
| `ApispSelectCompanyWithIdNumberCode` | CompanyId, CmpNumber, CmpCode, LanguageID, DefaultLanguageID | رکورد کامل |
| `ApispSelectCompanyPersons` | CompanyPersonID, CompanyId, LanguageID, DefaultLanguageID, PageNumber, PageSize | ~۶۵ ستون |
| `ApispSelectCompanyAddresses` | CompanyId, LanguageID, DefaultLanguageID | آدرس‌ها |
| `ApispSelectUsers` | UserId, LanguageID, DefaultLanguageID | کاربران (**شامل ستون Password!**) |
| `ApispSelectUsersById` | UserId, LanguageID, DefaultLanguageID | UserId/FName/LName/FullName/IsActive/UserIsActiveInWebApp |
| `ApispSelectUsersWithIdOrUserName` | UserId, UserName, LanguageID, DefaultLanguageID | کاربر کامل + DepartmentInfo + PointInfo |
| `ApispSelectConversation` | ConversationID, ProjectID, CopmanyID, LanguageID, DefaultLanguageID, CenterId, CenterCode, PageNumber, PageSize | مکالمات |
| `ApispSelectProjects` | ProjectID, CompanyId, LanguageID, DefaultLanguageID, FromRegisterDate, ToRegisterDate, FromFirstRegisterDate, ToFirstRegisterDate, PageNumber, PageSize | پروژه‌ها |
| `ApispSelectReminderCartable` | Date, UserId, LanguageID, DefaultLanguageID, SelectWithCnvs, CrmUserId | یادآوری‌های کارتبل |
| `ApispSelectWareHouse` | WrhsDeActive:Boolean, LanguageID, DefaultLanguageID | انبارها |
| `ApispSelectProducts` | ProductID, PrdGroupID, PrdCode, FromRegisterDate, ToRegisterDate, FromFirstRegisterDate, ToFirstRegisterDate, LanguageID, DefaultLanguageID, PageNumber, PageSize | محصولات |
| `ApispSelectOrder` | OrderID, ordNumber, FromOrderDate, ToOrderDate, FromRegisterDate, ToRegisterDate, FromFirstRegisterDate, ToFirstRegisterDate, LanguageID, DefaultLanguageID, CenterId, CenterCode, PageNumber, PageSize | سفارش‌ها |
| `ApispSelectPreOrder` | مشابه Order + pordNumber, FromPreOrderDate, ToPreOrderDate | پیش‌سفارش‌ها |
| `ApispMainSearch` / `ApispMainSearchWebSmart` | Val, UserID, SearchType, LanguageID, DefaultLanguageID, CenterId, CenterCode | جست‌وجوی فراگیر |
| `ApispSelectCrmsysSetting` | Val, UserID, SearchType, LanguageID, DefaultLanguageID, SearchConditionMode, CenterId, CenterCode | تنظیمات سیستم (شامل لایسنس) |
| `ApispSelectDefaultCenter` | LanguageID, DefaultLanguageID | مرکز پیش‌فرض |

به‌علاوهٔ SPهای اطلاعات پایه از `ApiBaseInfoController`:
`ApispSelectCity / Province / Country / CompanyTitle / CompanyType / CompanyGroup / CompanySubGroup / CompanyGroupsII..IV / CompanyGroupsMulti / CompanyPresentation / CompanyCampaign / CompanyAddressType / PersonTitle / PersonType / PersonDepartments / PersonJobs / Education / Sex / ProjectTitles / ProjectGroups / ProjectGrade / ProjectPriority`.

### ۴.۲ ساختار جدول `CrmCompany` (۱۱۷ ستون — از `CRMTabel.ssdl` نسخهٔ سورس)

ستون‌های کلیدی برای MedPad:

```
CompanyID int (PK, Identity)     ← شناسهٔ پایدار
cmpNumber int                    ← شمارهٔ مشتری
cmpCode nvarchar                 ← کد مشتری (در نسخه‌های جدید JSON چندکدی!)
cmpName nvarchar(300)
cmpNameEng, cmpNameOfficial
cmpTitleId, cmpGroupId, cmpSubGroupId, cmpGroupIdII/III/IV, cmpTypeId, cmpPresentationId
cmpPreTel/cmpTel/cmpTelII, cmpMobile, cmpFax
cmpCountryId, cmpProvinceId, cmpCityId, cmpAddress, cmpZipCode, cmpPostBox
cmpWebSite, cmpEmail
cmpCoordinateLatitude/Longitude (nvarchar!), cmpCoordinateZoomLevel, cmpCoordinateLastDate
RegisterDate datetime, RegisterDatePersian, ImportDate, ImportDateTime
FirstRegisterDate, FirstRegisterUserId, FirstRegisterDatePersian
UserId (آخرین ویراستر), cmpReferUserId (بازاریاب/معرف), cmpSuppUserId
cmpRegistrationNumber, cmpEconomicCode, cmpNationalCode
cmpIsDraft (bit), cmpKind, cmpMainPersonId
LanguageID, GUId
```

**نکتهٔ حیاتی برای همگام‌سازی:** هیچ ستون `LastModifiedDate` روی `CrmCompany` (و جداول مشابه) وجود ندارد. `RegisterDate` تاریخ **ایجاد** رکورد است نه آخرین تغییر؛ `UserId` آخرین ویراستر را می‌گوید اما نه زمانش را. بنابراین همگام‌سازی افزایشی واقعی «تغییرات» از روی دیتابیس Ideal **بدون Snapshot یا مقایسهٔ دوره‌ای ممکن نیست** — سند ۱۰ این محدودیت و راه‌حل را کامل شرح می‌دهد. **هیچ دادهٔ ساختگی برای شبیه‌سازی تغییر تولید نمی‌شود.**

### ۴.۳ روابط اصلی جداول (استنتاج از SPها و EDMX)

```
Centers (CenterID) ──┐
                      ├─ <cmpFOInfo JSON در CrmCompany: CId/ReferUId/SuppUId> (رابطهٔ چندمرکزی جدید)
Users (UserId) ───────┤  cmpReferUserId → Users (بازاریاب)
                      │  UserId → Users (آخرین ویراستر)
CrmCompany (CompanyID)─┼─ 1:N ─ CrmCompanyPersons (prsCompanyId → CompanyID)  [تماس‌ها]
                      ├─ 1:N ─ CrmCompanyAddresses (CompanyId)
                      ├─ 1:N ─ CrmProjects (CompanyId)
                      │            └─ 1:N ─ CrmConversation (ProjectID) ── CrmCReminder (CnvsId)
                      ├─ N:M ─ CrmCompanyGroups / SubGroups / II / III / IV (lookup مستقیم با Id)
                      └─ 1:N ─ WSOrder (CmpId) / WSPreOrder
CrmProducts ── N:1 ── CrmProductFirstGroup/SecondGroup/Unit/...
CrmWareHouse ── انبارها
```

جدول‌های زبان (_Lang): `CrmCompany_Lang, CrmCompanyTitle_Lang, City_Lang, Province_Lang, Country_Lang, Users_Lang, ...` — فقط وقتی LanguageID ≠ DefaultLanguageID در SP مسیر join زبان می‌رود. برای MedPad مسیر پیش‌فرض (زبان پیش‌فرض سیستم) کافی است.

---

## ۵. چه اطلاعاتی برای MedPad کاربرد دارد؟

| اولویت مأموریت | موجود در API اصلی | SP منبع | ملاحظات |
|---|---|---|---|
| لیست مشتری + جزئیات | بله | ApispSelectCompany | صفحه‌بندی، فیلتر کد/شماره/بازهٔ ثبت |
| موقعیت جغرافیایی | بله | همان SP | Latitude/Longitude رشته‌ای‌اند |
| بازاریاب/مسئول | بله | همان SP (ApiCmpReferUser از JSON cmpFOInfo یا cmpReferUserId) | منطق JSON در SP |
| تماس‌ها و آدرس مشتری | بله | ApispSelectCompanyPersons / ApispSelectCompanyAddresses | حذف رمز |
| کاربران CRM | بله | ApispSelectUsers / ById / WithIdOrUserName | **حذف ستون Password الزامی** |
| مکالمات/پیگیری | بله | ApispSelectConversation | بر اساس Company/Project |
| یادآوری‌ها | بله | ApispSelectReminderCartable | بر اساس کاربر و تاریخ |
| پروژه‌های مشتری | بله | ApispSelectProjects | + بازهٔ ثبت |
| محصولات | بله | ApispSelectProducts | |
| سفارش/پیش‌سفارش | بله | ApispSelectOrder / PreOrder | |
| انبار | بله | ApispSelectWareHouse | |
| اطلاعات پایه (شهر/استان/گروه/عنوان...) | بله | ApispSelectCity/Province/... | از ApiBaseInfoController |

---

## ۶. قابلیت‌های وابسته به نسخه

| قابلیت | نشانهٔ نسخه | ریسک در 3.1.16 نصب‌شده |
|---|---|---|
| پارامترهای صفحه‌بندی در SPها (`@PageNumber/@PageSize`, `ApiRowNumber/ApiTotalCount`) | کامنت `SOH14050222` (پس از 3.1.16) | **بالا — احتمالاً وجود ندارد** |
| ستون‌های رسمی مشتری (`cmpOfficialTel`, `cmpOfficialCityId`, `TspCmpBbc/Bpn/Tob`) | کامنت `SOH14050220` | **بالا** |
| JSON چندکدی در `cmpCode` (OPENJSON) | کامنت `RZ14030518` | متوسط |
| JSON مرکز/بازاریاب در `cmpFOInfo` (ReferUId/SuppUId/CId) | کامنت `RZ14040719` | متوسط |
| `cmpCampaignIds` و نام کمپین‌ها | کامنت `RZ14010519` | متوسط |
| `ApispSelectUsersWithIdOrUserName` (جست‌وجوی نام‌کاربری با نرمال‌سازی حروف عربی/فارسی) | کامنت `RZ14010716` | متوسط |
| `ApispSelectConversation` پارامتر CenterId/CenterCode | کامنت `NKR14040124` | متوسط |
| SPهای یادآوری `ApispSelectReminderCartable` | `V7` در کاتالوگ | پایین (قدیمی‌تر است) |
| `ApispSelectCompanyById` | `V8` | متوسط |
| ستون‌های هستهٔ `CrmCompany` (CompanyID/cmpNumber/cmpName/...) | از V1 (خیلی قدیمی) | **بسیار پایین** |

**نتیجهٔ طراحی:** IdealBridge نباید به وجود پارامترهای صفحه‌بندی SP تکیه کند؛ صفحه‌بندی را خودِ سرویس با Keyset Pagination مستقل (`ORDER BY id OFFSET/FETCH` روی کوئری‌های خودش یا بعد از اجرای SP) انجام می‌دهد و در زمان راه‌اندازی، امضای هر SP را با کوئری فراداده (`sys.parameters`) راستی‌آزمایی می‌کند. مسیر جایگزین SELECT مستقیم روی جدول‌های هسته هم به‌عنوان حالت fallback تعبیه شده است.

---

## ۷. بازاستفاده مستقیم در برابر بازنویسی مستقل

### قابل بازاستفاده مستقیم (منبع مرجع، نه کپی کورکورانه)

- **نام و امضای SPهای خواندنی** و ساختار خروجی‌شان ( DTOهای `Apisp*_Result` مرجع نگاشت IdealBridge هستند).
- **نقشهٔ ستون‌های جدول** از `CRMTabel.ssdl` (برای مسیر SELECT مستقیم).
- **قواعد دامنه:** نام‌گذاری فیلدها (پیشوند Api)، سلسله‌مراتب گروه‌ها، نرمال‌سازی نام کاربری، تبدیل تاریخ شمسی/میلادی.
- **کاتالوگ SQL** برای بررسی وجود ستون/SP در محیط واقعی.

### باید مستقل بازنویسی شود (و در IdealBridge بازنویسی شده)

| بخش دلیل | دلیل |
|---|---|
| کل لایهٔ وب (Controller/Routing/Filter) | ASP.NET Web API 2 قدیمی؛ IdealBridge با ASP.NET Core 8 |
| پاکت پاسخ | `ServiceResult` قدیمی → پاکت یکنواخت جدید با `data/status/message/pagination` |
| احراز هویت | بدون توکن، رمز در هر درخواست → توکن مستقل با انقضا/ابطال |
| صفحه‌بندی | وابسته به SP → Keyset Pagination سرویس‌محور |
| رمزنگاری TripleDES کلاس Security | ممنوع بازاستفاده (حکم صریح مأموریت) |
| دسترسی داده EF5 EDMX | ADO.NET فقط-خواندنی با گارد دستور و بررسی امضا |
| مدیریت خطا | افشای پیام SQL خام → خطاهای یکسان و بدون جزئیات داخلی |
| مستندسازی | Swagger/OpenAPI |

---

## ۸. فهرست فایل‌های بررسی‌شده (خلاصه)

- زیرساخت: `WebApiConfig.cs`, `RouteConfig.cs`, `WebApiApplication.cs`, `DbConnection.cs`, `Classes/Security.cs`, `Classes/VersionBuyer.cs`, `Classes/Configuration.cs`, `Classes/Helper/CommonClass.cs`, `Classes/Helper/User.cs`, `Classes/Helper/Versions.cs`, `Classes/Helper/Center.cs`
- کنترلرها (۲۶ فایل): از جمله `ApiCompanyController` (۶۷۶۹ خط، ۲۴ اکشن)، `ApiUserController` (۵)، `ApiCompanyPersonController` (۵)، `ApiConversationController` (۴)، `ApiCReminderController` (۴)، `ApiProjectController` (۵)، `ApiOrdersController` (۲۸)، `ApiPreOrdersController` (۲۶)، `ApiProductController` (۲۹)، `ApiWareHouseController` (۲)، `ApiBaseInfoController` (۳۰۶۵۹ خط — ۲۳۳ اکشن اطلاعات پایه)، `ApiHomeController`، `ApiPublicController`، `ApiOtherSystemsController`، `ApiVerificationRequestController`, `ApiDocController`, `ApiDyFormController` و بقیه
- مدل داده: `ApiModels.CRM.csdl/ssdl/msl` (۵۸۰ FunctionImport)، ViewModelهای Select*، DTOهای نتیجهٔ `Apisp*_Result`
- مدل دامنهٔ CRM: `Models/CRMTabel.ssdl` (۶۳۳ EntityType — ساختار کامل جداول نسخهٔ سورس)، `Models/CRM/CrmCompany.cs` و موجودیت‌های هم‌جوار
- بدنهٔ SPها از کاتالوگ SQL (منبع V1..V8): `ApispSelectCompany`, `ApispCheckUserAllowed`, `ApispSelectUsers(ById/WithIdOrUserName)`, `ApispSelectCompanyPersons`, `ApispSelectCompanyAddresses`, `ApispSelectConversation`, `ApispSelectProjects`, `ApispSelectReminderCartable`, `ApispSelectWareHouse`, `ApispSelectOrder`, `ApispSelectPreOrder`, `ApispSelectProducts`

---

## ۹. جمع‌بندی برای طراحی IdealBridge

1. **دسترسی داده دوحالته:** (a) فراخوانی SPهای `Apisp*` خواندنی بعد از راستی‌آزمایی امضا در راه‌اندازی؛ (b) fallback مستقیم SELECT روی جدول‌های هسته با ستون‌های پایدار. انتخاب با تنظیمات + تشخیص خودکار.
2. **صفحه‌بندی Keyset مستقل** (`afterId` + `limit`) — هرگز وابسته به پارامترهای صفحه‌بندی SP.
3. **بدون رمز عبور در خروجی** — Blacklist ستون حساس در همهٔ نگاشت‌ها.
4. **توکن مستقل MedPad** با انقضا/ابطال/ثبت درخواست — جدا از احراز هویت Ideal.
5. **محدودیت همگام‌سازی:** نبود ستون LastModified → سند ۱۰ (Snapshot/مقایسهٔ دوره‌ای + پنجرهٔ ثبت).
6. **فراداده در زمان استقرار:** ابزار `IdeaSchemaDump` فقط-خواندنی برای استخراج ساختار واقعی دیتابیس نصب‌شده و گزارش تفاوت با نسخهٔ سورس.
