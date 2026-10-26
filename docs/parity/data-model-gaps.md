<div dir="rtl">

# شکاف‌های مدل داده — دیتابیس اصلی در برابر اسکیمای رستا

> سند فاز صفر. همهٔ اعداد از سه منبع مکانیکی استخراج شده‌اند: (۱) `prisma/schema.prisma` رستا، (۲) `CRMTabel.ssdl` (۶۳۳ جدول)، (۳) پارس کاتالوگ SQL مالک (`sql-catalog/parsed/inv_*.json` — ۵۹٬۱۲۴ دستور). هیچ عددی از حدس نیامده است.

## ۱) وضعیت کلی پوشش

| شاخص | مقدار |
|---|---|
| جدول‌های اصلی نسخهٔ قدیمی (SSDL، بدون _Lang) | ۳۸۰ |
| CREATE TABLE یکتای کاتالوگ SQL | ۴۶۲ (۳٬۹۹۴ ستون) + ۳٬۲۱۴ ستون ALTER-ADD بعدي |
| مدل‌های Prisma رستا | ۳۹۶ (بخش ۱: ۴۲ فعال — ۲۶ نگاشت‌یافته + ۱۶ رستا-بومی؛ بخش ۲: ۳۵۴ کاتالوگ) |
| جدول‌های اصلی که اپ رستا واقعاً به آن‌ها سیم‌کشی شده | ۲۷ (۲۶ مدل بخش ۱ + `CrmProjectsForbiddenForUser` از بخش ۲) = ۷٫۱٪ |
| ستون‌های رستا-اختصاصی (بدون معادل اصلی) | ۵۵ — همه با کامنت «فقط رستا» |
| SPهای یکتای کاتالوگ | ۵٬۳۰۲ — با data.zip مالک (۲۰۲۶-۱۰-۲۶) همه با متن کامل از statements.pack |
| FK / PK / ایندکس / DEFAULT در کاتالوگ | ۹۴۸ / ۵۰۱ / ۱۵۶ / ۲۶۰ |
| تابع / نما / تریگر | ۲۱۴ / ۳۵ / ۷ |

## ۲) جدول‌های سیم‌کابی‌شده (۲۷) و ستون‌هایشان

تسک ۸ (commit `a86a2d0`) همهٔ ستون‌های اصلی ۲۶ جدول فعال را با `verify_schema_vs_ssdl.py` تک‌به‌تک صحت‌سنجی کرد (۱٬۰۶۳ ستون اصلی) — این پوشش ستونی کامل است. شکاف ستونی صفر روی این ۲۷ جدول؛ شکاف در لایه‌های دیگر است (رابطه، پیش‌فرض، SP، رفتار):

`Users`، `CrmsysRolls`، `CrmsysRollPermission`، `CrmUserTasks`، `UserLoginAllowedTimes`، `UserGroups`، `UserPositions`، `UserDepartments`، `CrmCompany`، `CrmCompanyPersons`، `CrmProjects`، `CrmProjectsForbiddenForUser`، `CrmProjectTitles`، `CrmProjectTitleGroups`، `CrmProjectGroups`، `CrmProjectGrade`، `CrmProjectPriority`، `CrmProjectCategory`، `CrmConversation`، `CrmConversationStatus`، `CrmConversationStatusGroups`، `CrmFund`، `CrmFundGroups`، `CrmBankingBanks`، `CrmBankingBranches`، `CrmBankingAccounts`، `CrmBankingAccountType`

۱۶ جدولِ رستا-بومی که معادلهای اصلی‌شان فقط در بخش ۲ (کاتالوگ، بدون سیم‌کشی) حاضرند:

| رستا | معادل اصلی (بخش ۲) | یادداشت انحراف مستند |
|---|---|---|
| SalesOrder/SalesOrderItem | WSOrders/WSOrderItems | شناسهٔ cuid به‌جای Int identity (تداوم کد — در سرصفحهٔ schema) |
| Quotation/QuotationItem | WSPreOrders/WSPreOrderItems | همانند بالا |
| PurchaseOrder(+Item) | WSBuyOrders/WSBuyOrderItems | همانند بالا |
| Payment | WSOrderPayments + WSPreOrderPayments | در اصلی دو جدول‌اند؛ در رستا یک مدل با نوع |
| Product | CrmProducts | در اصلی با قیمت/سریال/واحد جداجدا |
| Warehouse | CrmWareHouses | — |
| StockLevel/StockMovement | CrmProductWareHouses + CrmWareHouseMovement | در اصلی جداول بیشتری (رسد/حواله جدا) |
| Deal | CrmOpportunities | — |
| Activity | CrmCompanyActivities | — |
| Setting | CrmSysSettings | — |
| ActivityLog | (ندارد — ایزافتهٔ رستا برای Audit) | «فقط رستا» |
| OnlinePayment | OnlinePayment* (بخش ۲) | — |

## ۳) رابطه‌ها (FK) — شکاف واقعی شمارهٔ یک

- FKهای **خروجی از ۲۷ جدول سیم‌کابی‌شده**: ۸۴ مورد در کاتالوگ. بخش ۱ اسکیما ۱۰۷ فیلد relation دارد که پوشش درون‌بخش-۱ را می‌دهد؛ اما FKهایی که به جدول‌های **بخش ۲** اشاره می‌کنند (مثل `CrmUserTasks.UserTaskGroupId → CrmUserTaskGroups`) هنوز رابطهٔ Prisma ندارند — به شکل ستون اسکالر نگه‌داری شده‌اند (انحراف مستند، سیم‌کابی per-module در فازهای بعد).
- FKهای **ورودی به ۲۷ جدول**: ۴۲۹ مورد. توزیع: `Users` ۳۹۳، `CrmCompany` ۱۰، `CrmCompanyPersons` ۹، بقیه پراکنده. یعنی تقریباً هر ماژول آینده (پیامک، ایمیل، مرخصی، فرم‌ساز، …) برای `UserId` به Users وصل می‌شود — این جداول در بخش ۲ با ستون UserId حاضرند ولی رابطه نشده‌اند.
- `Users.UserId` ۳۹۳ FK ورودی دارد؛ در اسکیمای فعال، حذف کاربر باید دفاعی بماند (رفتار فعلی: حذف با بلاک وابستگی‌ها — منطق درست است؛ با سیم‌کابی کامل Prisma رفتار DB هم پوشش داده می‌شود).

## ۴) پیش‌فرض‌ها، ایندکس‌ها و قیدهای یکتایی

- **DEFAULT:** کاتالوگ ۲۶۰ پیش‌فرض دارد؛ ۱۲ مورد مربوط به جدول‌های فعال در تسک ۹ اعمال شد (GUId `newid()` در ۱۰ جدول، `MobMovement` 100/60). ۲۴۸ موردِ باقی روی جدول‌های بخش ۲ است و هنگام سیم‌کابی هر ماژول باید اعمال شود (منبع: `rasta_defaults_needed.json`).
- **ایندکس فیزیکی:** ۶ مورد جدول‌های فعال اعمال شد (با کامنت شناسهٔ گام اورجینال). بقیه مربوط به بخش ۲.
- **یکتایی:** `IX_Users` (V2-689) روی `UserName` UNIQUE — تأیید و در اسکیما اعمال شده.
- **PK:** ۵۰۱ در کاتالوگ؛ بخش ۲ همهٔ مدل‌ها PK identity دارند (تولید مکانیکی) — پوشش ساختاری کامل، ولی identity seed/increment و PKهای مرکبیِ چندجدول خاص باید در فاز سیم‌کابی بررسی شود.

## ۵) رویه‌های ذخیره‌شده — شکاف واقعی شمارهٔ دو

کوپلینگ SP↔جدول‌های فعال (تعداد SPهایی که نام جدول در متنشان هست):

| جدول | SP | جدول | SP |
|---|---|---|---|
| Users | ۲۳۱ | CrmProjects | ۸۵ |
| CrmCompany | ۲۲۳ | CrmConversationStatus | ۳۷ |
| CrmConversation | ۹۱ | CrmsysRollPermission | ۱۹ |
| CrmCompanyPersons | ۸۹ | CrmsysRolls / CrmProjectsForbiddenForUser | ۱۴ / ۱۴ |

- **بازسازی رفتاری کامل:** ۲ رفتار — `CRMspCheckUserLoginAllowedTimes` (نسخهٔ نهایی V5 گام ۳۷۲۵؛ E2E ۱۴ سنجه — پس از اصلاح معنا به whitelist با متن کامل data.zip) و سه SP عناوین پروژهٔ ممنوع (E2E ۱۴ سنجه؛ افزودهٔ V8: پارامتر CenterId/CId برای فاز مراکز ثبت شد). این‌ها `VERIFIED` هستند.
- **بازسازی رفتاری ضمنی بدون تست مکانیکی:** CRUDهای اصلی (شرکت/پروژه/کارتابل/انبار/مالی) رفتارهای ظاهری SPها را در TypeScript بازتولید کرده‌اند ولی تطبیق تک‌تک با متن SP انجام نشده — وضعیت `IMPLEMENTED` نه `VERIFIED`.
- **کاملاً بدون بازسازی:** کل بقیه — از جمله ۱۲۲ کوئری پارامتری فرم‌ها و ۲۷۲ SP گزارشی.
- **مسدود (حل‌شده ۲۰۲۶-۱۰-۲۶):** متن ۳٬۱۱۰ SP بریدهٔ جلدهای V5–V8 — با data.zip مالک (`ideal/data.zip`: catalog.tsv + statements.pack) همه بازیابی و راستی‌آزمایی شد (مجموع len = ۳۶۱٬۰۲۱٬۰۶۹ = حجم pack؛ ۰ ردیف خارج از مرز). الگوی نسخهٔ نهایی هر SP = آخرین ردیف آن در ترتیب V1→V8.

## ۶) قواعد کسب‌وکار شناخته‌شده و بازسازی‌نشده (با شواهد)

این فهرست از همین فاز صفر (متن SPهای کامل + منوها + نماها) استخراج شد و هر مورد باید در فاز مربوطه بازسازی شود:

1. **گردش‌های تایید گروهی** سفارش/پیش‌فاکتور (`actOrderGroupVerify`/`actPreOrderGroupVerifyExit` + SPهای Verify) — فاز فروش.
2. **ارسال اسناد به حسابداری و مودیان** (`BordActSendToAccLink`, `OrdActSendOrdToTsp`, ۲۲ سامانه) — فاز یکپارچه‌سازی.
3. **چرخهٔ تایید (VerificationWorkflow)** — روی ۲ جدول بخش ۲ + SPهای Verify.
4. **قواعد فرم‌ساز** (۱۴ جدول متادیتا + ۶۹۹ کوئری ۱۴۳ فرم فعال) — فاز FormBase/DyForms.
5. **سقف تخفیف نقش** — بازسازی شد (`lib/discount.ts` در درج/ویرایش فاکتور و پیش‌فاکتور) ولی از مسیر تست مکانیکی بی‌بهره است.
6. **شمارش/محدودیت لایسنس** (`muShowDetailsUserCount`, SPهای UserCount) — در رستا تعریف نشده (تصمیم محصولی: فعلاً بدون لایسنس — مستند در roadmap).
7. **پیش‌فرض‌های GUId/تاریخ ثبت** در جدول‌های بخش ۲ — هنگام سیم‌کابی هر ماژول از `rasta_defaults_needed.json` برداشت شود.

## ۷) انحراف‌های عامدانهٔ مستند (تصمیم معماری — نه شکاف)

| انحراف | دلیل |
|---|---|
| ۲۵۳ جدول `_Lang` تولید نشد | رستا فارسی-اول؛ چندزبانه در صورت نیاز |
| شناسهٔ cuid در ۱۶ جدول رستا-بومی | تداوم کد فعلی — در سرصفحهٔ schema |
| Enumها String در SQLite | محدودیت توسعه؛ Postgres در استقرار |
| رابطه‌های بخش ۲ فقط ستون اسکالر | سیم‌کابی per-module در فازهای بعد |
| `db push --accept-data-loss` فقط در توسعهٔ SQLite | در roadmap ممنوعیت استفادهٔ بی‌قید در production ثبت شده |

## ۸) صف کار برای فازهای بعد (خروجی مستقیم این سند)

1. سیم‌کابی رابطه‌های FK بخش-۲ برای ماژول‌های پیوسته (Users/CrmCompany اول — بیشترین FK ورودی).
2. اعمال ۲۴۸ DEFAULT باقی‌مانده هنگام فعال‌سازی هر ماژول.
3. بازسازی عیناً SPهای متنی پرکاربرد قبل از ساخت هر فرم (منبع: `inv_procs.json`).
4. ~~دریافت خروجی CRM_SQL_Runner از مالک برای ۳٬۱۱۰ SP بریده~~ — حل شد با data.zip (statements.pack، متن کامل همهٔ دستورها).
5. تست واحد (vitest) برای قواعد بازسازی‌شده (تخفیف، وضعیت‌ها، تراکنش‌های انبار) — زیرساخت تست در همین فاز توصیه شد.

</div>
