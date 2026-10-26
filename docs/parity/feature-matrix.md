<div dir="rtl">

# ماتریس تطبیق قابلیت‌ها — CRMIdeal (قدیمی) در برابر رستا

> سند فاز صفر (خط مبنا). وضعیت‌ها: `NOT_ANALYZED` (کاوش نشده)، `ANALYZED` (کاوش شده، پیاده‌سازی نشده)، `IN_PROGRESS` (بخشی پیاده شده)، `IMPLEMENTED` (پیاده شده، بدون تست مکانیکی)، `VERIFIED` (با تست/E2E اثبات شده)، `BLOCKED` (به شواهد/تصمیم مالک وابسته).
> قاعدهٔ صداقت: `VERIFIED` فقط با اجرای تست ثبت می‌شود. «کامپایل شد» یا «صفحه باز شد» دلالت بر VERIFIED ندارد.

## ۱) وضعیت تست و خط پایهٔ فنی (اثبات‌شده در این فاز)

| بررسی | نتیجهٔ واقعی اجرا (۲۰۲۶-۱۰-۲۶) |
|---|---|
| `npx tsc --noEmit` | ۰ خطا ✅ |
| `npm run lint` | ۰ خطا ✅ |
| `npx prisma validate` | معتبر ✅ |
| E2E `scripts/e2e-login-times.mjs` | ۱۴/۱۴ PASS ✅ (رفتار `CRMspCheckUserLoginAllowedTimes` — نسخهٔ نهایی V5، whitelist؛ پس از اصلاح با data.zip) |
| E2E `scripts/e2e-forbidden-titles.mjs` | ۱۴/۱۴ PASS ✅ (عناوین پروژهٔ ممنوع) |
| E2E (باز اجرا پس از data.zip) | ۲۸/۲۸ PASS ✅ (۱۴+۱۴) |
| data.zip مالک (`ideal/data.zip`) | متن کامل هر ۵۹٬۱۲۴ دستور — ۳٬۱۱۰ SP بریدهٔ V5–V8 بازیابی شد؛ اصلاح رفتاری ساعت ورود (whitelist) انجام شد |
| `npm run build` | در پایان همین فاز اجرا شد؛ نتیجه در §۶ |

ادعاهای worklog تا امروز (tsc/lint/E2E ۲۶/۲۶) همگی بازتولید شدند — ادعای کذبی یافت نشد. اما دو حقیقت مهم: (۱) هیچ فریم‌ورک تست واحد (jest/vitest) یا E2E پایدار (playwright) وجود ندارد؛ «تست» فعلاً دو اسکریپت Node دست‌ساز است و بقیهٔ ادعاهای فازهای ۱–۳ (ورود/پروژه‌ها/تعاریف/…) با curl دستی انجام شده و اسکریپت ماندگاری ندارد. (۲) در package.json اسکریپت `test` وجود ندارد.

## ۲) ماتریس ۴۶ Area

معادل‌ها = مسیر واقعی رستا. «باقی‌مانده» فقط موارد با شواهد است (نما/کنترلر/SP واقعی در نسخهٔ قدیمی).

| Area قدیمی | معادل رستا | UI | API/منطق | مدل داده | مجوزها | تست | وضعیت کلی | مهم‌ترین باقی‌مانده (با شواهد) |
|---|---|---|---|---|---|---|---|---|
| Company | `/companies`, `/contacts`, `/companies/[id]` | IMPLEMENTED | IMPLEMENTED (CRUD+جستجو) | IMPLEMENTED (CrmCompany+Persons عیناً) | IMPLEMENTED (frmCompany) | E2E فاز ۴ | IN_PROGRESS | ۱۷۲ نما: آدرس‌ها، کیف پول (CompanyMoneyBag)، شرکت مرتبط، ثبت سریع، درج اکسل، تاریخچهٔ تماس |
| Setting | `/settings`, `/settings/*` (۶ صفحه) | IN_PROGRESS | IN_PROGRESS | IMPLEMENTED (Users/Rolls عیناً + ۲۰ مدل تعریفی) | IMPLEMENTED | E2E فاز ۴ | IN_PROGRESS | ۴۶ کنترلر/۱۴۲ نما: تعاریف پایهٔ خارج از پوشش فعلی (نوع شرکت/شغل/منبع آشنایی و ده‌ها مورد در CrmSysForms) |
| Orders | `/orders` | IMPLEMENTED | IMPLEMENTED (فاکتور+اقلام+پرداخت+اتصال انبار تراکنشی) | رستا-بومی (SalesOrder~WSOrder) | IMPLEMENTED (frmOrders) | E2E فاز ۲ | IN_PROGRESS | تایید گروهی (actOrderGroupVerify)، ارسال به مودیان (Tsp)، ارسال به حسابداری، سریال اقلام |
| PreOrders | `/quotations` | IMPLEMENTED | IMPLEMENTED (پیش‌فاکتور→فاکتور، سقف تخفیف نقش) | رستا-بومی (Quotation~WSPreOrder) | IMPLEMENTED | E2E فاز ۲ | IN_PROGRESS | تایید گروهی، نمایش دلایل نبودِ گروه کالا (SP شواهد دارد) |
| BuyOrders | `/purchases` | IMPLEMENTED | IMPLEMENTED (سفارش خرید→رسید انبار) | رستا-بومی (PurchaseOrder) | IMPLEMENTED | E2E فاز ۲ | IN_PROGRESS | ارسال به حسابداری (BordAct*)، فایل اقلام |
| Products | `/products` | IN_PROGRESS | IN_PROGRESS (CRUD+دسته) | رستا-بومی + بخش ۲ کاتالوگ حاضر | IMPLEMENTED | E2E فاز ۱ | IN_PROGRESS | ۱۱۰ نما: قیمت/هزینه/گالری/مشخصات فنی/سریال/کالای مرتبط — ApiProductController ۲۸ اکشن |
| WareHouse | `/inventory`, `/warehouses` | IMPLEMENTED | IMPLEMENTED (رسید/حواله/انتقال/اصلاح تراکنشی + کارت کالا) | رستا-بومی + کاتالوگ | IMPLEMENTED | E2E فاز ۲ | IN_PROGRESS | موجودی چندانباره پیشرفته، سریال/بچ، اتصال مکانی کالا |
| Fund | `/fund` | IMPLEMENTED | IMPLEMENTED (درخت گروه+اسناد+گردش تایید) | CrmFund عیناً | IMPLEMENTED | E2E فاز ۳ | IN_PROGRESS | اسناد حسابداری کامل (Accounts)، چک |
| Banking | `/banking` | IMPLEMENTED | IMPLEMENTED (بانک→شعبه→حساب، کارت/شبا) | CrmBanking* عیناً | IMPLEMENTED | E2E فاز ۳ | IN_PROGRESS | تسویه/حواله بانکی، اتصال اسناد |
| OnlinePayment | `/settings/payments` | IMPLEMENTED | IMPLEMENTED (تنظیم درگاه + جریان پرداخت + تراکنش‌ها) | رستا-بومی | IMPLEMENTED | E2E فاز ۳ | IN_PROGRESS | کال‌بک واقعی درگاه‌ها (شبکهٔ بیرونی — BLOCKED در سندباکس)، تسویه |
| Cartables | `/tasks`, `/activities` | IN_PROGRESS | IN_PROGRESS (یادآور/کار داخلی/مکالمه پروژه) | CrmUserTasks عیناً | IMPLEMENTED | E2E فاز ۴ | IN_PROGRESS | ۱۲۲ نما: نامه‌ها (Letters)، وضعیت‌ها، کارتابل ترکیبی (muCompanyAndCartables)، کارنامهٔ روزانه (cDaily) |
| Menu | ریل app-shell | IMPLEMENTED | — (استاتیک + نقش) | — | IMPLEMENTED | چشمی | IN_PROGRESS | ۶۰ کلید منویی قدیمی بدون معادل (فهرست در §۳) |
| Reports | `/reports` | IN_PROGRESS | IN_PROGRESS (KPI+نمودار Recharts) | — | IMPLEMENTED | E2E فاز ۱ | IN_PROGRESS | ۲۷۲ SP گزارشی + موتور StimulSoft + فرم‌های گزارش ۶۹۹ کوئری فعال |
| Component | اجزای مشترک React | — | — | — | — | — | IN_PROGRESS | کنترلرهای JSON پشتیبان (۹) |
| DiscountCode | `lib/discount.ts` | NOT_ANALYZED | IN_PROGRESS (سقف تخفیف نقش اتصال یافت) | بخش ۲ حاضر | IMPLEMENTED | unit ندارد | IN_PROGRESS | کد تخفیف/سیاست/راهبرد سه Area مستقل با نما و API |
| AI | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | دستیار هوشمند قدیمی (۹ کنترلر) |
| Accounts | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | اسناد حسابداری، دورهٔ مالی |
| Centers | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | مراکز فروش/شعب |
| Cms | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | پورتال محتوا |
| CompanyReport | — | NOT_ANALYZED | NOT_ANALYZED | — | — | — | NOT_ANALYZED | ۴۲ نمای گزارش مشتری‌محور |
| Costsheets | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | برگه هزینه |
| DyForms | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | فرم‌ساز کامل |
| Emails | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | ایمیل SMTP/POP |
| Filter | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | فیلترهای ذخیره‌شده |
| FormBase | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر (فرم‌ها ۱۴ جدولی) | — | — | NOT_ANALYZED | موتور متادیتای فرم × اکشن (۳۵ کنترلر/۷۴ نما) |
| ImportExcel | — | NOT_ANALYZED | NOT_ANALYZED | — | — | — | NOT_ANALYZED | درج گروهی اکسل |
| Leave | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | مرخصی/ماموریت |
| Letters | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | نامه‌های اداری |
| OtherSystems | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | پل ۲۲ حسابداری (۱۳۶ نما) |
| PayRolls | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | حقوق/پورسانت |
| Score | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | امتیاز مشتری |
| SEO | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | — |
| Shop | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | فروشگاه |
| Sms | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | ۱۵+ درگاه |
| StockSupply | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | درخواست/رسد تأمین |
| Survey | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | نظرسنجی |
| Targeting | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | هدف‌گذاری |
| Telegram | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | ربات |
| TimeAttendance | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | حضور/غیاب QR |
| Tools | — (منو soon) | NOT_ANALYZED | NOT_ANALYZED | — | — | — | NOT_ANALYZED | ابزارها |
| Tsp | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | مودیان |
| UserLocationDetails | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | GPS |
| VerificationWorkflow | — | NOT_ANALYZED | NOT_ANALYZED | بخش ۲ حاضر | — | — | NOT_ANALYZED | چرخهٔ تایید |
| Content | — | — | — | — | — | — | — | Area خالی در بسته |

وضعیت‌های IN_PROGRESS بالا یعنی: هستهٔ دامنه کار می‌کند و تست E2E دارد، اما فهرست «مهم‌ترین باقی‌مانده» (که از شمارش واقعی نماها/اکشن‌ها آمده) هنوز پیاده نشده. هیچ Areaیی هنوز `VERIFIED` کامل نیست چون تطبیق رفتار صفحه‌به‌صفحه با نسخهٔ قدیمی انجام نشده و تست‌های مکانیکی فقط دو رفتار SP-محور را پوشش می‌دهند.

## ۳) شکاف منوها — ۶۰ کلید قدیمی بدون معادل در ریل رستا

پس از یکسان‌سازی پیشوندهای ریشه (`muDashboard`≡`mnuDashboard` و ۱۳ مورد مشابه)، این کلیدها واقعاً معادل ندارند (دسته‌بندی بر اساس نوع شکاف):

**قابلیت کامل غایب (۱۹):** `muLinkAccHoloo`, `muLinkAccSepidar`, `muLinkAccTarazSamaneh`, `muLinkAccNoAvaran`, `muLinkAccNoAvaranII`, `muLinkAccSoftware` (اتصال حسابداری)، `muSendToAcc`, `muSendToTsp` (ارسال اسناد به حسابداری/مودیان)، `muCall` (تماس‌ها)، `muCmpFiles` (پرونده‌ها)، `mnuDefineCenters`, `muOrganizations`, `mnuGoToPrdSpecificationFields`, `mnuGoToPrdSpecificationGroups`, `muShowCIVoiceRecordInformation` (ضبط مکالمات)، `muActiveDemoUser`, `muTopSelections`, `muDailyPordChart`, `mnuSReport`

**تعاریف پایهٔ غایب (۹):** `muBaseInfo`, `muBuyOrderBaseInfo`, `muSaleOrderBaseInfo`, `muPreOrderBaseInfo`, `muWareHouseBaseInfo`, `muFOBaseInfo`, `muDefineTimeAttendanceBase`, `muOrder`, `muSelectSysPartDyForm`

**ریشهٔ ماژول غایب (۴):** `muSms`, `muEmails`, `muFoRpt` (گزارش باشگاه مشتریان), `muDeliveryScheduleReports`

**آیتم‌های جانبی (۶):** `muPrintSurveyQuestions`, `muSendRequest`, `muShowDetailsUserCount` (شمارش لایسنس), `muKaraAfzar`, `mnuHolding`, `mnuRptSaleCenterDelivery`

**اکشن‌های Chrome فرم (۶):** `muAction`, `muShow`, `muCancel`, `muCloseForm`, `muExit`, `muCompanyAndCartables` — بخشی از رفتار پنجره‌ها؛ در رستا با Dialog/بستن تب تا حدی معادل مفهومی دارد ولی نه با همان رفتار.

همچنین در سمت مقابل، ریل رستا ۱۱ ریشه/آیتم «جدید برای رستا» دارد (`mnuHumanResource`, `mnuTargeting`, `mnuAIAssistant`, `muBanking`, `muOnlinePayment` به‌عنوان آیتم، ۱۱ کلید `c*` کارتابل‌ریل) که در `menus-fa` با آن نام نیستند — این‌ها از ساختار واقعی محصول (ردهای کارتابل، منوی تنظیمات) گرفته شده‌اند نه اختراع؛ ولی کلید منبع دقیق آن‌ها باید در فاز UI از متادیتای دیتابیس منو استخراج شود (جدول‌های Menu area).

## ۴) API — مقایسهٔ کمّی

| شاخص | CRMIdeal | رستا | نسبت |
|---|---|---|---|
| کنترلر/API | ۲۶ (Web API) + ۳۱۸ MVC + ۸۲ Mobile | ۵۹ فایل route | — |
| اکشن‌ها | ۴۶۳ POST (Web API فقط) | ۱۲۸ متد REST دقیق (GET 41 / POST 30 / DELETE 27 / PUT 17 / PATCH 13) | ۲۸٪ |
| یکپارچه‌سازی خارجی | ۲۲+ | ۳ (تنظیم درگاه؛ فراخوان واقعی BLOCKED شبکه) | ~۱۳٪ |

توجه: ممیزی امنیتی این فاز (۲۰۲۶-۱۰-۲۶، بازرسی تک‌تک ۵۹ فایل route): همهٔ مسیرها گارد سمت‌سرور دارند — ۵۵ فایل با `requirePerm/requirePermission/requireUser` (نشست + مجوز فرم×اکشن) و ۴ مسیر auth (login بنا به ماهیتش عمومی است؛ me/logout/change-password نشست را داخلی چک می‌کنند و بدون ورود ۴۰۱ می‌دهند). اکشن‌به‌اکشن‌های ApiBaseInfoController (۲۳۳ اکشن تعاریف پایه) بزرگ‌ترین گلوگاه توسعه‌ای سمت API است.

## ۵) صفحه‌ها و عملیات — مقایسهٔ کمّی

| شاخص | CRMIdeal | رستا |
|---|---|---|
| نماهای Razor/صفحات | ۱٬۴۲۷ (۱٬۳۹۳ + ۳۴) | ۳۰ صفحه React |
| فرم‌های فعال ثبت‌شده در کاتالوگ | ۱۴۳ فرم × ۶۹۹ کوئری | ~۲۰ فرم در `MODULES`/`FORMS` (constants.ts) |
| عملیات گزارش | ۲۷۲ SP گزارش + طراحی‌گر StimulSoft | ۱ صفحهٔ KPI/نمودار |
| چندزبانه | fa/tr/ar/de | fa |

## ۶) نتیجهٔ Build فاز صفر

`npm run build` در پایان این فاز اجرا شد تا ادعای Build واقعی ثبت شود: خروجی Standalone با موفقیت تولید شد (next build موفق، خروجی در `.next/`). هر تغییر ساختاری بعدی باید دوباره اجرا و نتیجه‌اش همین‌جا به‌روز شود.

## ۷) نتیجهٔ ممیزی صداقت ادعاها (docs vs واقعیت)

| ادعا | واقعیت |
|---|---|
| «E2E ۲۶/۲۶» تسک ۹ | بازتولید شد — درست ✅ |
| «tsc=0, eslint=0» | بازتولید شد — درست ✅ |
| «E2E ورود/پروژه‌ها/تعاریف/آرشیو/کاربران/نقش‌ها/ساخت شرکت/کاربر/وظیفه» (تسک ۸) | اسکریپت ماندگار ندارد — فقط با curl دستی آن زمان انجام شده؛ قابل بازتولید نیست ⚠️ |
| «UI تصدیق شد» (فاز بازطراحی) | اسکرین‌شات‌ها موجود ولی مقایسهٔ سیستماتیک صفحه‌به‌صفحه انجام نشده — سند ui-comparison-plan این شکاف را می‌پوشاند |

## ۸) نتیجهٔ فاز صفر برای ماتریس

- هیچ ردیفی `VERIFIED` کامل نیست؛ دو رفتار SP-محور (ساعت ورود، عناوین ممنوع) تنها موارد `VERIFIED` رفتاری هستند.
- ترتیب منطقی توسعه (نقشهٔ وابستگی) در `roadmap.md` بر اساس همین ماتریس بازچینش شده است: FormBase→تعاریف پایه (ApiBaseInfo)→Sms/Email→Reports→سایر ماژول‌ها.

</div>
