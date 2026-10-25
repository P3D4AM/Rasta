<div dir="rtl">

# تحلیل نسخه قدیمی — CRMIdeal 3.1.18.187 (مرجع بازنویسی رستا)

> سند فاز ۱ پروژه رستا — آبان ۱۴۰۵ / اکتبر ۲۰۲۶
> منبع: بسته publish شده ASP.NET MVC (بدون سورس C#) به‌همراه PDB کامل — ۱۸۷ مگابایت، ۱۲,۵۶۴ فایل

## ۱) شناسنامه بسته

| مشخصه | مقدار |
|---|---|
| محصول | CRMIdeal نسخه 3.1.18.187 — شرکت کارآفراز (KaraAfzar) |
| نوع بسته | Publish بدون سورس؛ ۱,۴۴۶ نمای Razor؛ PDB همه اسمبلی‌ها (شرایط دیکامپایل عالی) |
| فریم‌ورک | ASP.NET MVC 5.2.9 / .NET Framework 4.7 / Web API 2 |
| دسترسی داده | EF5 Database-First — **۷ زمینه EF** (CRMEntities، CRMSpI/II/III، CRMTabel، CRMLinkSp) |
| Real-time | SignalR 2.2.0 — ۴ هاب: ChatHub, NotificationHub, MsgHub, ProgressHub |
| احراز هویت | SimpleMembership + OWIN |
| گزارش‌ساز | StimulSoft Reports |
| دیتابیس | SQL Server |

## ۲) اسمبلی‌های اصلی و نتیجه دیکامپایل

| اسمبلی | حجم | نقش | نتیجه دیکامپایل |
|---|---|---|---|
| CRMIdeal.dll | 12.4MB | اپ اصلی؛ ۴۰۴ کنترلر در ۴۶ Area | ۱,۲۴۶ فایل / 34MB |
| CRMIdealApi.dll | 6.4MB | ۲۶ کنترلر Web API | ۸۰۵ فایل / 12MB |
| Mobile.dll | 10.9MB | اپ موبایل HRM/FO/CIC؛ ~۹۷ کنترلر | ۱,۶۵۰ فایل / 18MB |
| Models.dll | 47MB | ۴,۷۶۶ کلاس موجودیت؛ ۷ DbContext | ۴,۹۴۳ فایل / 52MB |
| Resources.dll | ~5MB | منابع چندزبانه fa/tr/ar/de | 5.1MB |
| General.dll | — | کتابخانه عمومی | ۴۸ فایل |
| OtherWebServices.dll | — | یکپارچه‌سازی‌های خارجی | ۲۸۹ فایل |
| RegisterCompany.dll | — | لایسنس/فعال‌سازی (موکول به بعد از انتشار) | ۳۰ فایل |
| **جمع** | ~80MB | — | **~۸,۹۷۰ فایل / ~120MB سورس C#** |

سورس بازیابی‌شده در `project-analysis/decompiled/` این مخزن موجود است.

## ۳) نقشه ۴۶ Area (گروه‌بندی دامنه‌ای)

- **فروش (هسته):** Company، Cartables، Products، PreOrders، Orders، فاکتورها
- **انبار و خرید:** WareHouse، BuyOrders، StockSupply
- **مالی:** OnlinePayment، Banking، Fund، PayRolls، Shop
- **منابع انسانی:** Leave، TimeAttendance (QR)، UserLocationDetails (GPS)، Score، Targeting
- **ارتباطات:** Sms، Emails، Telegram، Letters
- **بازاریابی/محتوا:** Survey، Cms
- **پلتفرم:** Setting، Accounts، FormBase، DyForms، Reports، OtherSystems، AI و…

## ۴) باستان‌شناسی فرانت‌اند (چرا بازنویسی لازم بود)

- **۹ نسخه موازی jQuery** و **دو نسل Kendo UI** (2013/2014 و 2022.3.913) هم‌زمان در یک اپ
- Bootstrap 3→4 — مهاجرت ناتمام
- سه کتابخانه نمودار موازی: Highcharts + Chart.js + CanvasJS
- Leaflet + Google Maps موازی؛ ۱۴۰ فونت فارسی در بسته
- فایل‌های غول‌آسا: نمای ۹,۸۶۱ خطی (`Areas/Orders/Views/Home/Index.cshtml`)، `jsPublicFunction.js` با 552KB، Layout چهار هزار خطی (`_LayoutMain.cshtml` با 4,253 خط)

## ۵) یکپارچه‌سازی‌ها

- ۲۲ نرم‌افزار مالی ایرانی (سپیدار، هلو، رهکار، رایورز و…) + مجموعه Shygun/سامان
- ۳ درگاه پرداخت: ملت (BPECAPI)، پارسیان، زرین‌پال
- ۱۵+ درگاه پیامک
- سامانه مالیات مودیان (TaxCollectData) + شهرکار
- Telegram Bot + MTProto (TLSharp/TeleSharp) + Firebase FCM
- CTI/Caller-ID با سرویس WCF روی پورت ۷۷۷۷
- ۱۴۳ پکیج NuGet در بسته

## ۶) ماژول AI نسخه قدیم

مدیریت Provider های LLM، کتابخانه Prompt، سهمیه Token به تفکیک کاربر، سازگار با GPT-4o — در رستا بازطراحی و پیاده‌سازی می‌شود (فاز ۸ نقشه راه).

## ۷) بدهی‌های امنیتی نسخه قدیم (در رستا برطرف می‌شوند)

| بدهی | ریسک |
|---|---|
| ELMAH بدون احراز هویت | افشای کامل خطاها و Stack Trace |
| `debug=true` در production | افشای مسیرها و جزئیات خطا |
| machineKey هاردکد در web.config | جعل احراز هویت |
| اعتبارنامه‌های توسعه در config | ریسک نفوذ |
| SautinSoft نسخه کرک‌شده | ریسک حقوقی/امنیتی |
| AntiForgeryToken کامنت‌شده در صفحه ورود | CSRF |

## ۸) دلالت‌های بازنویسی

- منطق کسب‌وکار مفید از سورس دیکامپایل‌شده **پورت** می‌شود (نه کپی مستقیم) — با الگوهای امروزی TypeScript
- هسته دامنه حفظ شد: ساختار Company-Person-Project-Order + RBAC (Rolls/UsersPermission) → مدل‌های Prisma رستا
- میراث فرانت‌اند (Kendo/jQuery) کاملاً کنار گذاشته شد → Tailwind + shadcn/ui با RTL بومی
- ماژول لایسنس (RegisterCompany.dll) طبق تصمیم مالک فقط دیکامپایل شد؛ پیاده‌سازی آن به بعد از انتشار اولیه موکول است

</div>
