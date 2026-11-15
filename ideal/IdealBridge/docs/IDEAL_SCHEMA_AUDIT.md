# ممیزی Schema و پیاده‌سازی IdealBridge — یافته‌های فاز ۱۲

> سند فاز ۱۲ — هر یافته با شاهد (فایل/خط یا متن SQL کاتالوگ) · هیچ تغییری در کد اعمال نشده است (فاز مستندسازی)

## ۱. دامنه و روش ممیزی

- **مورد بازبینی:** ۱۴ بلوک SQL در `Repositories.cs` و `CompanyRepository.cs`، دیکشنری `BaseInfoRepository.Map` (۲۴ kind)، فهرست `SchemaProbe.RequiredTableColumns`، `DataAccessPolicy`، DTOهای `Domain/Dto`، نگاشت SPهای `ApispSelect*` در سند ۰۱.
- **مبنای صحت:** `CRMTabel.ssdl` نسخهٔ ۱۸۷ (۶۳۳ جدول / هر ستون با نوع و Nullable) + کاتالوگ ۵۹,۱۲۴ دستور نصاب (متن کامل در بستهٔ statements) + جست‌وجوی متنی ۳۶۱MB متن SQL برای اثبات «نام غلط در هیچ نسخه‌ای نبوده».
- **ابزار:** اسکریپت‌های `p12_*.py` (استخراج SQL از C#، تطبیق با SSDL، تحول ستون‌ها در V1..V8، مقایسهٔ Probe با کوئری‌ها).

## ۲. یافتهٔ اصلی — نام‌های غلط جدول/ستون در SQL مخازن (Critical)

ممیزی ایستا ۱۶ مغایرت در SQLهای literal پیدا کرد؛ با افزودن دیکشنری BaseInfo (SQL تولیدی runtime)، فهرست کاملِ یکتا این است. **هر ۱۹ مورد در هر نسخه‌ای از Ideal شکست runtime (SqlException: Invalid column/table name) می‌دهند**، چون نام‌های صحیح از V1 ثابت بوده‌اند (شواهد: هیچ‌یک از نام‌های غلط در متن کامل SQL نصاب — ۳۶۱MB — به‌عنوان ستون واقعی ظاهر نمی‌شوند؛ نام‌های صحیح همه با joinهای خود Ideal تطبیق دارند).

### ۲.۱ جدول‌های غلط

| # | کد فعلی (غلط) | صحیح (SSDL 187) | محل | اثر |
|---|---|---|---|---|
| 1 | `dbo.CrmPersonJob` | `dbo.CrmPersonJobs` | PersonRepository Base (join J) + BaseInfo kind=personjob | شکست persons و baseinfo/personjob |
| 2 | `dbo.WSProductUnit` | `dbo.WSProductUnits` | ProductRepository Base (join UN) | شکست products |

### ۲.۲ ستون‌های غلط — کوئری اشخاص (`PersonRepository.Base`)

| # | کد فعلی | صحیح |
|---|---|---|
| 3 | `J.JobID` (شرط join) | `J.PersonJobID` |
| 4 | `J.Job` | `J.Jobs` |
| 5 | `PG.GroupName AS PersonGroup` | `PG.PersonGroup AS PersonGroup` |
| 6 | `SX.Sex` | `SX.SexType` |
| 7 | `DP.DepartmentID` (شرط join) | `DP.PersonDepartmentId` |
| 8 | `DP.Department` | `DP.PersonDepartment` |

### ۲.۳ ستون‌های غلط — کوئری مکالمات (`ConversationRepository`)

| # | کد فعلی | صحیح |
|---|---|---|
| 9 | `T.TopicName` | `T.Topic` |
| 10 | `T.TopicID` (شرط join) | `T.ConversationTopicsID` |
| 11 | `S.ConversationStatus` | `S.Status` |

### ۲.۴ ستون‌های غلط — کوئری پروژه‌ها (`ProjectRepository`)

| # | کد فعلی | صحیح |
|---|---|---|
| 12 | `G.GradeName` | `G.ProjectGrade` |
| 13 | `PG.GroupName` | `PG.ProjectGroup` |

### ۲.۵ ستون‌های غلط — کوئری یادآوری‌ها (`ReminderRepository`)

| # | کد فعلی | صحیح |
|---|---|---|
| 14 | `PR.PriorityName` | `PR.Priority` |
| 15 | `G.GroupName` | `G.UserTaskGroup` |

### ۲.۶ ستون‌های غلط — کوئری محصولات (`ProductRepository`)

| # | کد فعلی | صحیح |
|---|---|---|
| 16 | `G.GroupName` | `G.FGName` |
| 17 | `G.ProductFirstGroupID` (شرط join) | `G.PrdFirstGroupID` (+ معناشناسی: `PrdGroupID` به گروه **دوم** اشاره دارد، نه اول — بند §۵) |
| 18 | `UN.UnitName` | `UN.Unit` |

### ۲.۷ ستون‌های غلط — آدرس‌ها (`CompanyRepository.GetCompanyAddressesAsync`)

| # | کد فعلی | صحیح |
|---|---|---|
| 19 | `T.CompanyAddressType` | `T.CompanyAddressTypeName` |

### ۲.۸ دیکشنری BaseInfo (`BaseInfoRepository.Map`) — نام‌های غلط در تولید SQL

`personjob: (CrmPersonJob, JobID, Job)` → `(CrmPersonJobs, PersonJobID, Jobs)`؛ `persondepartment: (…, DepartmentID, Department)` → `(PersonDepartmentId, PersonDepartment)`؛ `persongroup: GroupName` → `PersonGroup`؛ `sex: Sex` → `SexType`؛ `companyaddresstype: CompanyAddressType` → `CompanyAddressTypeName`؛ `projectgroup: GroupName` → `ProjectGroup`؛ `projectgrade: GradeName` → `ProjectGrade`.

> چرا ۲۱۹ تست موجود این را نگرفته؟ تست‌ها با دیتابیس construction/fake کار می‌کنند و اجرای واقعی SQL روی SQL Server را شبیه‌سازی نمی‌کنند. این دقیقاً کلاس باگی است که فقط با اتصال زنده یا ممیزی ایستا علیه SSDL (همین فاز) پیدا می‌شود.

**توصیه:** اصلاح همهٔ موارد §۲ در یک commit کوچک فاز ۱۳ (تغییر نام‌ها به مقادیر صحیح ستون «Notes» سند نگاشت) + افزودن تست یکپارچگی که متن SQL مخازن را در برابر `SchemaProbe.RequiredTableColumns` و SSDL مرجع قفل کند. (فاز ۱۲ عمداً کد را تغییر نداد.)

## ۳. سازگاری نسخه — ستون‌های پرریسک V6/V7/V8 که API استفاده می‌کند (High)

تحول ستون‌ها در کاتالوگ نشان می‌دهد این ۱۴ ستون فقط در V6/V7/V8 اضافه شده‌اند و در نصب 3.1.16.169.0303 (قدیمی‌تر از V6) به‌احتمال قوی **وجود ندارند** — و **هر ۱۴ مورد در SQL مخازن یا SchemaProbe فعال استفاده می‌شوند**:

| ستون | سبد | Endpoint متأثر | پوشش Probe |
|---|---|---|---|
| `CrmCompany.cmpNameOfficial` | V6 | companies | ✅ هست → Blocked تمیز |
| `CrmCompanyAddresses.cmpaddTypeId` | V7 (RZ14010912) | آدرس‌ها | ✅ (در RequiredTableColumns) |
| `CrmConversation.cnvsIsTicketNew` | V7 | conversations | ❌ **نیست → SqlException runtime** |
| `CrmProjects.prjSubject` | V6 | projects | ❌ **نیست → SqlException runtime** |
| `CrmProjects.prjNumR` / `prjNumRef` | V6 | projects | ✅ هست |
| `Users.UserGroupId` | V6 | users | ✅ |
| `Users.StartDate` / `ExpireDate` | V6 | users | ✅ |
| `WSPreOrder.pordChangeStatusDate` | V8 | preorders | ✅ |
| `WSProducts.PrdInActive` | V6 | products | ✅ |
| `WSProducts.PrdMinQuantity` / `PrdMaxQuantity` | V6 | products | ✅ |
| `WSProducts.PrdWeight` | V8 (RZ14031114) | products | ✅ |

**نتیجه:** روی دیتابیس 169 احتمالی: companies/products/users/preorders با پیام تمیز 503 «ستون‌های لازم مفقودند» Block می‌شوند (رفتار درست)، اما **conversations و projects مستقیم SqlException می‌گیرند** چون ستون‌های پرریسکشان در Probe نیست (بند §۴). نسخه‌های ۱۸۷+ سالم‌اند.

## ۴. شکاف‌های پوشش SchemaProbe (Medium-High)

مقایسهٔ ستون‌های SELECT مخازن با `SchemaProbe.RequiredTableColumns`:

1. **جداول بدون هیچ پوشش Probe** (اگر جدول نباشد، endpoint خطای runtime SQL می‌دهد نه 503 کنترل‌شده): تمام ۳۱ جدول فرهنگ‌نامه (city, country, companygroups*, persontitle, sex, crmconversationstatus/topics, crmprojectgrade/groups, crmusertask*, wsproductcolor/firstgroup, wsorderopr, ...) — یعنی حتی بعد از اصلاح نام‌های §۲، غیبت هر جدول lookup روی 169 → خطای خام.
2. **ستون‌های استفاده‌شده ولی Probe نشده:** `CrmCompany.FirstRegisterUserId` (بی‌خطر — V پایه)، `CrmConversation.cnvsIsTicket/cnvsIsTicketNew` (ریسک §۳)، `CrmProjects.prjSubject` (ریسک §۳)، `CrmUserTasks.UserTaskRemindDate/Time`، `Users.UserIsActiveInMobApp/WinApp`.
3. **ستون‌های Probe که کوئری استفاده نمی‌کند:** `CrmProjects.prjcnvsStatusGroupId`، `CrmUserTasks.UserTaskShowAllarm`، `WSOrder.ordSellerId` — محافظه‌کارانه (بد) — حفظ شوند.
4. **SPهای `ApispSelect*` در Probe ولی هرگز اجرا نمی‌شوند** — فقط گزارشی؛ درست.

**توصیه:** افزودن ردیف Probe برای دو جدول conversation/projects (ستون‌های پرریسک) + جدول‌های lookup اصلی (حداقل همان‌هایی که join می‌شوند) در فاز ۱۳.

## ۵. نکات معناشناسی join (Medium)

1. **گروه محصول:** `WSProducts.PrdGroupID` به `WSProductSecondGroup(PrdSecondGroupID)` اشاره دارد (شاهد `WSspSelectProductsByFSGId`)؛ کد فعلی به `WSProductFirstGroup` با کلید غلط join می‌زند (§۲.۶). حتی با نام اصلاح‌شده، انتخاب «گروه اول» یا «دوم» یک تصمیم محصولی است — نگاشت صحیح در سند نگاشت §۵.
2. **عملیات پیش‌سفارش:** کد فعلی `OP.Name` را از `WSOrderOpr` می‌گیرد (`WSPreOrder.PreOrderOprID JOIN WSOrderOpr`) در حالی که جدول فرهنگ مستقل `WSPreOrderOpr(PreOrderOprID, PreOrderOpr)` وجود دارد. اگر IDهای این دو فرهنگ هم‌پوشان ولی متفاوت باشند، نام عملیات پیش‌سفارش غلط نمایش داده می‌شود — نیازمند راستی‌آزمایی با دادهٔ زنده (Unverified).
3. **همهٔ joinها چپ (LEFT) روی PK فرهنگ‌نامه‌ها هستند** → تکثیر ردیف نداریم؛ نام مدیر/بازاریاب با الحاق `FName + ' ' + LName` ساخته می‌شود (ISNULL برای مقادیر NULL در SPهای Ideal، در کد فعلی بدون ISNULL — نمایش NULL ممکن است؛ جزئی).
4. **`MainPersonName`** با زیرکوئری `TOP 1 ... WHERE P.CompanyPersonID = CC.cmpMainPersonId` — امن و بدون تکثیر.
5. **صفحه‌بندی مستقل با OFFSET/FETCH خود IdealBridge** — طراحی درست برای سازگاری 169 (پارامترهای صفحه‌بندی SP بعد از 3.1.16 اضافه شده‌اند — سند ۰۹).

## ۶. کارایی (Medium)

1. **Keyset (`afterId`) روی PK ایندکس‌دار** — الگوی درست و O(log n)؛ پیش‌فرض پیشنهادی sync.
2. **صفحه‌بندی عمیق `page=N` با OFFSET** — هزینهٔ O(N×pageSize)؛ برای MedPad قابل قبول، ولی مستند شود که `afterId` ترجیح دارد.
3. **فیلترهای `LIKE '%…%'`** (`name`، `mobile`، `title`) — Full Scan اجتناب‌ناپذیر؛ روی جداول بزرگ (CrmCompanyPersons) سنگین. ایندکس V2 `IX_CrmCompanyPersons` روی ستون‌های موبایل در نسخه‌های جدید هست ولی روی 169 Unverified.
4. **پنجرهٔ `RegisterDate` بدون ایندکس** — هیچ‌یک از ۱۱۵ ایندکس کاتالوگ روی RegisterDate نیست؛ پنجره‌های sync/companies روی 169 Full Scan می‌شوند. توصیه: پنجرهٔ sync را با Keyset ترکیب کنید (سند ۱۰ همین را می‌گوید).
5. **کوئری موجودی آینده** — فرمول `WSDoc JOIN WSDocItems` با ایندکس V8 `IX_WSDocItems (PrdId, DocId, WHId, DocICId)` پشتیبانی می‌شود؛ روی 169 این ایندکس نیست (Unverified) — گزارش انبوه بهتر است به ساعات کم‌بار منتقل شود.

## ۷. امنیت (وضعیت موجود — بدون اقدام فاز ۱۲)

تأییدشده‌ها: `Users.Password` در هیچ SELECT نیست؛ `cmpPassword` در نگاشت نیست؛ گزارمان ReadOnlyCommandGuard (+NEXT VALUE FOR) سبز؛ `ApplicationIntent=ReadOnly`/`ApplicationName` اجباری؛ SecretRedactor فعال؛ توکن‌ها SHA-256؛ endpointهای مدیریتی پشت `X-Admin-Key`؛ بدون EXECUTE در سیاست مجوزها (سند ۰۶ بازنویسی‌شدهٔ ۱۱.۱-E).

نکات باز (به سند allowlist ارجاع):
1. PII تصمیم‌دار: `Users.NationalCode` و `prsNationalCode/prsIdentityNumber/...` هم‌اکنون افشا می‌شوند (allowlist §۴) — تصمیم حداقل‌سازی با مالک.
2. لایهٔ دسترسی کاربر-مشتری Ideal (`CrmCompanyForbidden*/JustAccess*`) اعمال نمی‌شود — توکن MedPad دید کامل دارد (allowlist §۷).
3. غیبت جداول lookup → خطای خام SQL (دسترس‌پذیری، نه نقض امنیت) — بند §۴.

## ۸. آنچه عمداً انجام نشد (محدودهٔ فاز ۱۲)

- هیچ اصلاح کدی (حتی §۲) — فاز مستندسازی بود؛ اصلاحات به فاز ۱۳ موکول شد تا با تست‌های قفل‌کننده همراه شود.
- هیچ endpoint جدید (قیمت/موجودی/اقلام/پرداخت فقط «نقشهٔ مسیر» شد).
- هیچ تغییر DTO/فیلتر (از جمله PII §۷.۱).
- اجرای هیچ کوئری روی دیتابیس زنده — دسترسی همچنان Blocked است.

## ۹. اولویت‌بندی اقدامات (پیشنهاد فاز ۱۳)

| اولویت | اقدام | مبنا |
|---|---|---|
| P0 | اصلاح ۱۹+۷ مورد نام غلط §۲ (یک commit، بدون تغییر رفتار قراردادی) | شکست قطعی همهٔ نسخه‌ها |
| P0 | افزودن Probe برای cnvsIsTicketNew/prjSubject + جداول lookup متأثر | تبدیل خطای خام به 503 تمیز روی 169 |
| P1 | تست یکپارچگی «SQL مخازن ⊆ SSDL مرجع» در CI (قفل رگرسیون) | جلوگیری از تکرار کلاس باگ §۲ |
| P1 | تصمیم PII با مالک (حذف/نگه‌داشتن فیلدهای §۷.۱) | حداقل‌سازی داده |
| P2 | مسیر گروه محصول درست (گروه دوم + زنجیرهٔ اول) و فرهنگ `WSPreOrderOpr` | درستی معنایی §۵.۱/۵.۲ |
| P2 | بازبینی پنجره‌های RegisterDate در sync (ترکیب با Keyset) | کارایی §۶.۴ |
| P3 | طرح endpointهای قیمت/موجودی بر پایه §۶/§۷ سند نگاشت | نیازمندی MedPad |

## ۱۰. فرمان‌های راستی‌آزمایی زنده (برای وقتی اتصال واقعی فراهم شد — همه فقط-خواندن)

```sql
-- ۱) وجود ستون‌های پرریسک §۳ روی crmideal نصب‌شده:
SELECT c.name FROM sys.columns c
JOIN sys.tables t ON t.object_id = c.object_id
WHERE t.name = 'CrmConversation' AND c.name IN ('cnvsIsTicket','cnvsIsTicketNew');
SELECT c.name FROM sys.columns c JOIN sys.tables t ON t.object_id=c.object_id
WHERE t.name='CrmProjects' AND c.name IN ('prjSubject','prjNumR','prjNumRef');
-- ۲) قید FK آدرس‌ها (V7):
SELECT name FROM sys.foreign_keys WHERE name = 'FK_CrmCompanyAddresses_CrmCompanyAddressType';
-- ۳) ردیف‌های WSOrderOpr (فقط ۵ ردیف فرهنگ — نه دادهٔ مشتری):
SELECT OrderOprID, Name, OprType FROM dbo.WSOrderOpr ORDER BY OrderOprID;
-- ۴) فعال‌بودن Change Tracking (برای سند sync):
SELECT DB_NAME(database_id) AS db, is_auto_cleanup_on FROM sys.change_tracking_databases;
-- ۵) seed گروه قیمت:
SELECT ProductPriceGroupID, ProductPriceGroupName FROM dbo.WSProductPriceGroup ORDER BY ProductPriceGroupID;
-- (هیچ SELECT از دادهٔ مشتری/کارمند با این فهرست انجام نشده است)
```

ابزار کامل و مقایسهٔ خودکار با گزارش مرجع این فاز: `tools/IdeaSchemaDump` (روش اجرا: سند ۰۴/۰۵).
