# گزارش سازگاری کوئری‌های مخزن با اسکیمای واقعی (فاز ۱۲.۵)

> **وضعیت: تحلیل ایستا ثبت‌شده — راستی‌آزمایی زنده «در انتظار» است.**
> این فاز **هیچ کوئری مخزنی را تغییر نمی‌دهد** (اصلاحات به فاز ۱۳ موکول شده
> و عمداً قفل شده). یافته‌های زیر برچسب منبع دارند؛ پس از اجرای زندهٔ
> `IdeaSchemaDump v3.0`، بخش §۶ با دادهٔ واقعی تکمیل و رده‌بندی‌ها نهایی می‌شود.

## ۱. راهنمای رده‌بندی چهارسطحی (فاز ۱۲.۵)

| رده | معنا |
|---|---|
| **CONFIRMED ERROR** | نام جدول/ستون در **هیچ** نسخهٔ Ideal وجود نداشته — شکست قطعی Runtime در هر نصبی |
| **VERSION DIFFERENCE** | موجود در 3.1.18.187 ولی احتمالاً/قطعاً در 3.1.16.169.0303 نیست — شکست فقط روی نسخهٔ قدیمی |
| **POTENTIAL ERROR** | معناشناسی مشکوک (join/نوع/Nullable) — نیاز به شاهد دارد |
| **VERIFIED** | با شاهد معتبر تأیید شده |

منبع شواهد هر ردیف در ستون «شاهد»: `[ایستا-SSDL187]` (جست‌وجوی کامل متن ۳۶۱MB نصاب + SSDL + سورس دیکامپایل‌شده — فاز ۱۲) یا `[زنده]` (هنوز هیچ‌کدام نیست — §۶).

## ۲. CONFIRMED ERROR — نام‌های غلط در SQL مخازن (ثابت هر نسخه)

نام غلط در ۳۶۱MB متن SQL نسخه‌های Ideal **هیچ‌وقت** وجود نداشته؛ بنابراین این کوئری‌ها در **هر** دیتابیسی (از جمله 3.1.16 و 3.1.18) با SqlException می‌شکنند `[ایستا-SSDL187]`:

| # | غلط (در کد فعلی) | صحیح | محل استفاده | اثر شکست |
|---|---|---|---|---|
| ۱ | `dbo.CrmPersonJob` | `dbo.CrmPersonJobs` | PersonRepository Base (join J) + BaseInfo kind=personjob | شکست persons و baseinfo/personjob |
| ۲ | `dbo.WSProductUnit` | `dbo.WSProductUnits` | ProductRepository Base (join UN) | شکست products |
| ۳ | `J.JobID` (شرط join) | `J.PersonJobID` | همان join | همان |
| ۴ | (دیکشنری personjob) `JobID, Job` | `PersonJobID, Jobs` | خروجی BaseInfo | نام فیلد غلط در خروجی |
| ۵ | `PG.GroupName AS PersonGroup` | `PG.PersonGroup AS PersonGroup` | همان join | همان |
| ۶ | `SX.Sex` | `SX.SexType` | همان join | همان |
| ۷ | (دیکشنری persondepartment) `DepartmentID, Department` | `PersonDepartmentId, PersonDepartment` | BaseInfo | نام فیلد غلط |
| ۸ | (sex) `Sex` | `SexType` | دیکشنری BaseInfo | نام فیلد غلط |
| ۹ | (companyaddresstype) `CompanyAddressType` | `CompanyAddressTypeName` | دیکشنری BaseInfo | نام فیلد غلط |
| ۱۰ | (projectgroup) `GroupName` | `ProjectGroup` | دیکشنری BaseInfo | نام فیلد غلط |
| ۱۱ | (projectgrade) `GradeName` | `ProjectGrade` | دیکشنری BaseInfo | نام فیلد غلط |
| ۱۲ | `UN.UnitName` | `UN.Unit` | همان join | همان |
| ۱۳ | `T.CompanyAddressType` (ستون) | `T.CompanyAddressTypeName` | CompanyRepository آدرس‌ها | شکست آدرس‌ها |

(۱۹ مورد کامل با اثر دقیق هر یک در `IDEAL_SCHEMA_AUDIT.md` فاز ۱۲ — جدول بالا زیرمجموعهٔ راهنما با تمرکز بر موارد درخواستی فاز ۱۲.۵ است.)

**نتیجهٔ زنده لازم:** این رده به راستی‌آزمایی زنده **نیازی ندارد** (نبود نام در تمام نسخه‌ها از جست‌وجوی کامل متن نصاب اثبات شده) — ولی برای بستن حلقه، پس از اجرای ابزار، بلوک `idealBridgeCompatibility.missingTables/missingColumns` همین نام‌ها را دوباره و مستقل از دیتابیس واقعی فهرست خواهد کرد.

## ۳. VERSION DIFFERENCE — ستون‌های پرریسک 3.1.18 که در 169 احتمالاً نیست

شاهد: کاتالوگ V6→V8 نصاب + تاریخ کامنت‌های سازنده `[ایستا-SSDL187]` — ستون‌هایی که کد IdealBridge **الان** استفاده می‌کند و در نسخهٔ نصب‌شدهٔ مالک احتمالاً موجود نیستند (→ SqlException خام روی 169):

| ستون | نسخهٔ افزودن | endpoint متأثر | وضعیت Probe فعلی |
|---|---|---|---|
| `CrmConversation.cnvsIsTicketNew` | V7 | conversations | Probe ندارد → SqlException خام |
| `CrmProjects.prjSubject` | V6 | projects | Probe ندارد → SqlException خام |
| ۳۱ جدول فرهنگی lookup (مثل `WSWareHouse`/`WSProductUnits` در مسیر آینده) | V6/V7/V8 | مسیرهای آینده | پوشش Probe ندارد |
| ۱۴ ستون V6/V7/V8 در SELECTهای فعال | V6–V8 | همهٔ endpointهای داده | ۱۱ مورد Probe دارد (Block تمیز) |

**نتیجهٔ زنده لازم:** پس از اجرای ابزار، بلوک `idealBridgeCompatibility.missingColumns` این فهرست را **واقعی** می‌کند: هر ستونِ فهرست‌شده = VERSION DIFFERENCE قطعی روی 169؛ هر ستونِ غایب از آن بلوک = VERIFIED (موجود روی 3.1.16). همین قاعده در §۶ نهایی می‌شود.

## ۴. POTENTIAL ERROR — معناشناسی join/نوع (از فاز ۱۲)

- **گروه دوم محصول:** گروه‌بندی محصولات دو جدول فرهنگی جدا دارد؛ join اشتباه `PrdGroup` با فرهنگ اشخاص نتایج غلط می‌دهد (شاهد: ساختار SSDL + بدنه SP) `[ایستا-SSDL187]`.
- **فرهنگ مستقل WSPreOrderOpr:** عملیات پیش‌سفارش فرهنگ خودش را دارد؛ join با `WSOpr` غلط است `[ایستا-SSDL187]`.
- **قیمت ردیف ≠ قیمت نهایی:** `WSfnReturnProductPrice` رزولوشن گروه-قیمت است (شاهد بدنهٔ تابع در نصاب) `[ایستا-SSDL187]`.
- **Nullable/نوع‌ها:** `Users.IsAdmin` رشتهٔ True/False است نه bit (در 3.1.18) `[ایستا-SSDL187]` — خوانندهٔ «bool-like» امن در کد جبران می‌کند `[کد-IdealBridge]`.
- **پنجرهٔ `RegisterDate`:** تاریخ «ایجاد» است نه ویرایش؛ ویرایش‌ها بدون شاهد قابل تشخیص نیستند (تحلیل فاز ۱۲ §همگام‌سازی) `[ایستا-SSDL187]`.

## ۵. VERIFIED — موارد تأییدشده بدون اتصال

- اجرای SP در IdealBridge غیرفعال است و مسیر EXEC بسته است `[کد-IdealBridge]` (تست فاز ۱۱).
- صفحه‌بندی با `OFFSET/FETCH` خود IdealBridge انجام می‌شود — وابسته به پارامترهای SP نیست `[کد-IdealBridge]`.
- `Users.Password`/`ApiCmpPassword` در هیچ SELECT/DTO نیست `[کد-IdealBridge]` (تست + بازبینی فاز ۱۲).

## ۶. در انتظار اجرای زنده (پس از `ideal-live-schema-report.json`)

| پرسش | پاسخ از کجا می‌آید |
|---|---|
| کدام ستون‌های §۳ واقعاً در 169 نیستند؟ | `idealBridgeCompatibility.missingColumns` `[زنده]` |
| آیا جداول/ستون‌های ردهٔ §۲ در دیتابیس واقعی غایب‌اند (چک مستقل)؟ | `idealBridgeCompatibility.missingTables` `[زنده]` |
| انواع/طول/Nullable/مرتب‌سازی واقعی ستون‌ها (برای POTENTIAL ERRORها)؟ | بلوک `tables`/`columns` (با `collation`/`nullable`/`type`) `[زنده]` |
| ایندکس‌های موجود برای پنجره‌های `RegisterDate`/`LIKE`؟ | بلوک `indexes` (با فیلتر/Disabled) `[زنده]` |
| امضای واقعی SPهای `ApispSelect*` روی 169؟ | بلوک `storedProcedures` `[زنده]` |

**تا آن لحظه، هیچ ردیفی از این سند به ردهٔ VERIFIED-زنده ارتقا نمی‌یابد و این سند به‌عنوان «در انتظار» می‌ماند.** اصلاح کوئری‌ها مال فاز ۱۳ است — با تست‌های قفل‌کننده بر همین جدول‌ها.

## ۷. محدودیت‌ها

- منبع «ایستا» بر 3.1.18.187 استوار است؛ برای 3.1.16 تنها مساز با راستی‌آزمایی زنده است (نسخهٔ نصب‌شدهٔ مالک).
- `cnvsIsTicketNew`/`prjSubject` و ۳۱ جدول lookup بدون Probe باقی می‌مانند — ریسک ثبت‌شده تا فاز ۱۳.
- این سند عمداً هیچ توصیه‌ای برای تغییر کد نمی‌دهد؛ نقشهٔ اصلاح (P0..P3) در `IDEAL_SCHEMA_AUDIT.md` فاز ۱۲ موجود است.
