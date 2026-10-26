<div dir="rtl">

# ماتریس بازسازی ApiBaseInfoController — ۲۳۳ اکشن / ۶۴ موجودیت یتا (۵۶ با CRUD کامل + ۸ فقط-Select)

> سند فاز ۵ (۲۰۲۶-۱۰-۲۶). منابع شواهد: (۱) `project-analysis/decompiled/CRMIdealApi/.../ApiBaseInfoController.cs` (۳۰٬۶۵۹ خط — دیکامپایل)؛
> (۲) متن کامل SPهای `Apisp*` از `statements.pack` (کاتالوگ data.zip مالک — main/ideal)؛
> (۳) پیام‌های فارسی عیناً از satellite DLLهای fa-IR (اسکریپت `scripts/dotnet_resx.py` — روش استخراج سند است)؛
> (۴) رفتار اپ داخلی: `CompanyInfoController` دیکامپایل‌شده (گیت‌ها/اعتبارسنجی/وابستگی‌های حذف).

## ۱) الگوی مشترک هر ۲۳۳ اکشن (شواهد: کل فایل کنترلر)

هر اکشن دقیقاً همین توالی را اجرا می‌کند (بدون استثنا در ۲۳۳ مورد):

1. **گیت لایسنس**: `VersionBuyer.CRMApi` → در صورت نبود: `Error` + «Access API limited!»
2. **خواندن تنظیمات**: `ApispSelectCrmsysSetting` → زبان پیش‌فرض (fallback 1065=فارسی)
3. **تعیین فرهنگ**: `ApispSelectLanguages` → culture پیام‌ها از LanguageId درخواست
4. **احراز هویت**: `CodeDecode.DeCodding` روی UserName/Password بدنه → `ApispCheckUserAllowed` → 0 یعنی «نام کاربری یا رمز عبور اشتباه می باشد, لطفا پس از اصلاح مجددا سعی نمایید.» (Error)
5. **اعتبارسنجی ورودی**: فیلدهای الزامی → «{برچسب} وارد نگردیده است!» / شناسه → «شناسه {برچسب} وارد نشده است.»
6. **فراخوانی SP**: `Apisp{Op}{Entity}` با پارامترهای ممیزی (UserId, Year1, Month1, RegisterDate, RegisterDatePersian=yyyyMMdd شمسی, FirstRegister*, LinkAcc*)
7. **تفسیر خروجی SP**: ErrorMessage با جداکنندهٔ `|` → کدهای خطا؛ موفقیت = Success + «عملیات با موفقیت انجام شد»
8. **پاسخ**: `ServiceResult<T> { Message, Data, Status }` — Status ∈ Success/Fail/Error

**نگاشت معادل رستا** (تصمیم مستند): رستا جایگزین اپ داخلی است نه درگاه API عمومی؛ بنابراین معادل‌سازی با معماری رستا انجام می‌شود:
نشست + `requirePerm` به‌جای user/pass بدنه؛ فرم‌های مجوز همان `frmDefine*` خود CRMIdeal؛ پیام‌های فارسی عیناً از satellite؛ ستون‌های ممیزی همان SP.
انحرافات مستند: جدول‌های `_Lang` وجود ندارند (فارسی-اول)؛ نگاشت کاربر ویرایشگر با ستون‌های `rasta{First}RegisterUserId` (الگوی مستند CrmProjectsForbiddenForUser)؛ لایسنس API فعال نیست.

## ۲) اولویت‌بندی (وابستگی‌محور — نه ترتیب فایل)

| گروه | موجودیت‌ها | منطق اولویت |
|---|---|---|
| P1 | جغرافیا (کشور/استان/شهر) + گروه‌بندی/نوع/عنوان مشتری + نوع/عنوان/شغل مخاطب + تحصیلات/جنسیت | پدر همهٔ فرم‌ها؛ وابستگی حذف مستقیم به Company/Contact؛ **گروه اولِ پیاده‌شده** |
| P2 | تعاریف پروژه و مذاکره (عنوان/سرفصل/گروه/مقطع/اولویت/موضوع/مدل پیشرفت/وضعیت/نتیجه/اولویت) | فاز ۴ با `/api/project-defs` بخشی را پوشش داده — قرارداد Apisp باید تطبیق یابد |
| P3 | تعاریف کالا و فروش (رنگ/واحد/ارز/نرخ ارز/اعتبار/تحویل/گارانتی/شرط پرداخت/انواع پرداخت/پورسانت) | ورودی فرم‌های فروش و انبار |
| P4 | اقدامات اسناد (OrderOpr/PreOrderOpr/BuyOrderOpr/DocOpr) + وضعیت‌ها | موتور گردش کار اسناد |
| P5 | بانک/شعبه/حساب/صندوق + معرف/کمپین/نوع نشانی/گروه‌های ۲-۴/گروه چندگانه + گروه و دپارتمان مخاطب | مکمل CRM و مالی |
| P6 | چرخهٔ تایید + قالب چاپ + کوئری‌های ویژه (Users/SysDBObjectsNotNull/UserForLinkedType/DocOprByOprType) | کمترین مصرف؛ برخی اصلاً جدول نیستند (کوئری متا) |

## ۳) ماتریس موجودیت‌ها (هر ۲۳۳ اکشن در ۶۴ ردیف)

وضعیت‌ها: `TESTED` = قرارداد کامل از شواهد استخراج + پیاده‌سازی + تست یکپارچه‌سازی سبز (گروه جغرافیا — ۱۲ اکشن).
`ANALYZED` = امضا/SP/اعتبارسنجی از سورس استخراج و فهرست شده (عمق ساختاری) اما قرارداد عمیق (متن SP) و پیاده‌سازی باقی است.
`VERIFIED` برای هیچ ردیفی ثبت نشده — معیارش تطبیق کامل رفتار از جمله مقایسهٔ UI است؛ صادقانه صفر است.

| موجودیت | برچسب فارسی | # | عملیات | SPهای وابسته | مدل Prisma | معادل رستا | گروه | وضعیت |
|---|---|---|---|---|---|---|---|---|
| City | شهر | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCity`, `ApispInsertCity`, `ApispSelectCity` | `City` | `/api/base-info/{countries,provinces,cities}` + `src/lib/baseinfo.ts` | P1 | TESTED |
| CompanyGroup | گروه‌بندی مشتریان (۱) | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyGroup`, `ApispInsertCompanyGroup`, `ApispSelectCompanyGroup`, `ApispUpdateCompanyGroup` | `CrmCompanyGroups` | — | P1 | ANALYZED |
| CompanySubGroup | گروه فرعی مشتریان | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanySubGroup`, `ApispInsertCompanySubGroup`, `ApispSelectCompanySubGroup`, `ApispUpdateCompanySubGroup` | `CrmCompanySubGroups` | — | P1 | ANALYZED |
| CompanyTitle | عنوان طرف حساب | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyTitle`, `ApispInsertCompanyTitle`, `ApispSelectCompanyTitle`, `ApispUpdateCompanyTitle` | `CrmCompanyTitle` | — | P1 | ANALYZED |
| CompanyType | نوع مشتری | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyType`, `ApispInsertCompanyType`, `ApispSelectCompanyType`, `ApispUpdateCompanyType` | `CrmCompanyType` | — | P1 | ANALYZED |
| Country | کشور | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCountry`, `ApispInsertCountry`, `ApispSelectCountry` | `Country` | `/api/base-info/{countries,provinces,cities}` + `src/lib/baseinfo.ts` | P1 | TESTED |
| Education | تحصیلات | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteEducation`, `ApispInsertEducation`, `ApispSelectEducation`, `ApispUpdateEducation` | `Education` | — | P1 | ANALYZED |
| PersonJob | شغل مخاطب | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePersonJob`, `ApispInsertPersonJob`, `ApispSelectPersonJobs`, `ApispUpdatePersonJob` | `CrmPersonJobs` | — | P1 | ANALYZED |
| PersonTitle | عنوان فرد | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePersonTitle`, `ApispInsertPersonTitle`, `ApispSelectPersonTitle`, `ApispUpdatePersonTitle` | `CrmPersonTitle` | — | P1 | ANALYZED |
| PersonType | نوع مخاطب | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePersonType`, `ApispInsertPersonType`, `ApispSelectPersonType`, `ApispUpdatePersonType` | `CrmPersonType` | — | P1 | ANALYZED |
| Province | استان | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProvince`, `ApispInsertProvince`, `ApispSelectProvince` | `Province` | `/api/base-info/{countries,provinces,cities}` + `src/lib/baseinfo.ts` | P1 | TESTED |
| Sex | جنسیت | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteSex`, `ApispInsertSex`, `ApispSelectSex`, `ApispUpdateSex` | `Sex` | — | P1 | ANALYZED |
| ConversationPriority | اولویت مذاکره | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteConversationPriority`, `ApispInsertConversationPriority`, `ApispSelectConversationPriority`, `ApispUpdateConversationPriority` | `CrmConversationPriority` | — | P2 | ANALYZED |
| ConversationStatus | وضعیت مذاکره | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteConversationStatus`, `ApispInsertConversationStatus`, `ApispSelectConversationStatus` | `CnvsStatus` | — | P2 | ANALYZED |
| ConversationStatusGroup | مدل پیشرفت | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteConversationStatusGroup`, `ApispInsertConversationStatusGroup`, `ApispSelectConversationStatusGroups`, `ApispUpdateConversationStatusGroup` | `CnvsStatusGroup` | — | P2 | ANALYZED |
| ConversationStatusResult | نتیجهٔ وضعیت مذاکره | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteConversationStatusResult`, `ApispSelectConversationStatus`, `ApispUpdateConversationStatusResult` | `CrmConversationStatusResult` | — | P2 | ANALYZED |
| ConversationTopic | موضوع مذاکره | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteConversationTopic`, `ApispInsertConversationTopic`, `ApispSelectConversationTopics`, `ApispUpdateConversationTopic` | `CrmConversationTopics` | — | P2 | ANALYZED |
| ProjectGrade | مقطع پروژه | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProjectGrade`, `ApispInsertProjectGrade`, `ApispSelectProjectGrade`, `ApispUpdateProjectGrade` | `ProjectGrade` | — | P2 | ANALYZED |
| ProjectGroup | گروه پروژه | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProjectGroup`, `ApispInsertProjectGroup`, `ApispSelectProjectGroups`, `ApispUpdateProjectGroup` | `ProjectGroup` | — | P2 | ANALYZED |
| ProjectPriority | اولویت پروژه | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProjectPriority`, `ApispInsertProjectPriority`, `ApispSelectProjectPriority`, `ApispUpdateProjectPriority` | `ProjectPriority` | — | P2 | ANALYZED |
| ProjectTitle | عنوان پروژه | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProjectTitle`, `ApispInsertProjectTitle`, `ApispSelectProjectTitles`, `ApispUpdateProjectTitle` | `ProjectTitle` | — | P2 | ANALYZED |
| ProjectTitleGroup | سرفصل پروژه | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProjectTitleGroup`, `ApispInsertProjectTitleGroup`, `ApispSelectProjectTitleGroups`, `ApispUpdateProjectTitleGroup` | `ProjectTitleGroup` | — | P2 | ANALYZED |
| BuyOrderPaymentType | نوع پرداخت خرید | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteBuyOrderPaymentType`, `ApispInsertBuyOrderPaymentType`, `ApispSelectBuyOrderPaymentTypes`, `ApispUpdateBuyOrderPaymentType` | `WSBuyOrderPaymentTypes` | — | P3 | ANALYZED |
| CreditDuration | مدت اعتبار | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCreditDuration`, `ApispInsertCreditDuration`, `ApispSelectCreditDuration`, `ApispUpdateCreditDuration` | `WSCreditDuration` | — | P3 | ANALYZED |
| CurrencyUnit | واحد ارز | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCurrencyUnit`, `ApispInsertCurrencyUnit`, `ApispSelectCurrencyUnits` | `WSCurrencyUnits` | — | P3 | ANALYZED |
| CurrencyUnitRate | نرخ ارز | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCurrencyUnitRate`, `ApispInsertCurrencyUnitRate`, `ApispSelectCurrencyUnitRate`, `ApispUpdateCurrencyUnitRate` | `WSCurrencyUnitRate` | — | P3 | ANALYZED |
| DeliveryTime | زمان تحویل | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteDeliveryTime`, `ApispInsertDeliveryTime`, `ApispSelectDeliveryTime`, `ApispUpdateDeliveryTime` | `WSDeliveryTime` | — | P3 | ANALYZED |
| Guaranty | گارانتی | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteGuaranty`, `ApispInsertGuaranty`, `ApispSelectGuaranty`, `ApispUpdateGuaranty` | `WSGuaranty` | — | P3 | ANALYZED |
| OrderCommissionPayType | نوع پرداخت پورسانت | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteOrderCommissionPayType`, `ApispInsertOrderCommissionPayType`, `ApispSelectOrderCommissionPayTypes`, `ApispUpdateOrderCommissionPayType` | `WSOrderCommissionPayTypes` | — | P3 | ANALYZED |
| OrderPaymentGroupI | گروه پرداخت (۱) | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteOrderPaymentGroupI`, `ApispInsertOrderPaymentGroupI`, `ApispSelectOrderPaymentGroupsI`, `ApispUpdateOrderPaymentGroupI` | `WSOrderPaymentGroupsI` | — | P3 | ANALYZED |
| OrderPaymentGroupII | گروه پرداخت (۲) | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteOrderPaymentGroupII`, `ApispInsertOrderPaymentGroupII`, `ApispSelectOrderPaymentGroupsII`, `ApispUpdateOrderPaymentGroupII` | `WSOrderPaymentGroupsII` | — | P3 | ANALYZED |
| OrderPaymentType | نوع پرداخت فاکتور | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteOrderPaymentType`, `ApispInsertOrderPaymentType`, `ApispSelectOrderPaymentTypeById`, `ApispSelectOrderPaymentTypes` | `WSOrderPaymentTypes` | — | P3 | ANALYZED |
| PayCondition | شرط پرداخت | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePayCondition`, `ApispInsertPayCondition`, `ApispSelectPayCondition`, `ApispUpdatePayCondition` | `WSPayCondition` | — | P3 | ANALYZED |
| ProductColor | رنگ کالا | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProductColor`, `ApispInsertProductColor`, `ApispSelectProductColor`, `ApispUpdateProductColor` | `WSProductColor` | — | P3 | ANALYZED |
| ProductUnit | واحد کالا | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteProductUnit`, `ApispInsertProductUnit`, `ApispSelectProductUnits`, `ApispUpdateProductUnit` | `WSProductUnits` | — | P3 | ANALYZED |
| BuyOrderOpr | اقدامات سفارش خرید | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteBuyOrderOpr`, `ApispSelectBuyOrderOpr` | `WSBuyOrderOpr` | — | P4 | ANALYZED |
| DocOpr | اقدامات سند | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteDocOpr`, `ApispSelectDocOpr`, `ApispUpdateDocOpr` | `WSDocOpr` | — | P4 | ANALYZED |
| OrderOpr | اقدامات فاکتور فروش | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteOrderOpr`, `ApispSelectOrderOpr` | `WSOrderOpr` | — | P4 | ANALYZED |
| OrderStatus | وضعیت فاکتور | 1 | SELECT | `ApispSelectOrderStatus` | `WSOrderStatus` | — | P4 | ANALYZED |
| PreOrderOpr | اقدامات پیش‌فاکتور | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePreOrderOpr`, `ApispInsertPreOrderOpr`, `ApispSelectPreOrderOpr`, `ApispUpdatePreOrderOpr` | `WSPreOrderOpr` | — | P4 | ANALYZED |
| PreOrderStatus | وضعیت پیش‌فاکتور | 1 | SELECT | `ApispSelectPreOrderStatus` | `WSPreOrderStatus` | — | P4 | ANALYZED |
| BankingAccount | حساب بانکی | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteBankingAccount`, `ApispInsertBankingAccount`, `ApispSelectBankingAccounts`, `ApispUpdateBankingAccount` | `BankAccount` | — | P5 | ANALYZED |
| BankingAccountType | نوع حساب بانکی | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteBankingAccountType`, `ApispInsertBankingAccountType`, `ApispSelectBankingAccountTypes`, `ApispUpdateBankingAccountType` | `BankAccountType` | — | P5 | ANALYZED |
| BankingBank | بانک | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteBankingBank`, `ApispInsertBankingBank`, `ApispSelectBankingBanks`, `ApispUpdateBankingBank` | `Bank` | — | P5 | ANALYZED |
| BankingBranch | شعبه | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteBankingBranch`, `ApispSelectBankingBranches`, `ApispUpdateBankingBranch` | `BankBranch` | — | P5 | ANALYZED |
| Cash | صندوق | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCash`, `ApispInsertCash`, `ApispSelectCashes`, `ApispUpdateCash` | `CrmCashes` | — | P5 | ANALYZED |
| CompanyAddressType | نوع نشانی | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyAddressType`, `ApispInsertCompanyAddressType`, `ApispSelectCompanyAddressType`, `ApispUpdateCompanyAddressType` | `CrmCompanyAddressType` | — | P5 | ANALYZED |
| CompanyCampaign | کمپین | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyCampaign`, `ApispInsertCompanyCampaign`, `ApispSelectCompanyCampaign`, `ApispUpdateCompanyCampaign` | `CrmCompanyCampaign` | — | P5 | ANALYZED |
| CompanyGroupII | گروه‌بندی مشتریان (۲) | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyGroupII`, `ApispInsertCompanyGroupII`, `ApispSelectCompanyGroupsII`, `ApispUpdateCompanyGroupII` | `CrmCompanyGroupsII` | — | P5 | ANALYZED |
| CompanyGroupIII | گروه‌بندی مشتریان (۳) | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyGroupIII`, `ApispInsertCompanyGroupIII`, `ApispSelectCompanyGroupsIII`, `ApispUpdateCompanyGroupIII` | `CrmCompanyGroupsIII` | — | P5 | ANALYZED |
| CompanyGroupIV | گروه‌بندی مشتریان (۴) | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyGroupIV`, `ApispInsertCompanyGroupIV`, `ApispSelectCompanyGroupsIV`, `ApispUpdateCompanyGroupIV` | `CrmCompanyGroupsIV` | — | P5 | ANALYZED |
| CompanyGroupsMulti | گروه‌بندی چندگانه مشتریان | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyGroupMulti`, `ApispInsertCompanyGroupMulti`, `ApispSelectCompanyGroupsMulti`, `ApispUpdateCompanyGroupMulti` | `CrmCompanyGroupsMulti` | — | P5 | ANALYZED |
| CompanyPresentation | معرف | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteCompanyPresentation`, `ApispInsertCompanyPresentation`, `ApispSelectCompanyPresentation`, `ApispUpdateCompanyPresentation` | `CrmCompanyPresentation` | — | P5 | ANALYZED |
| PersonDepartment | دپارتمان مخاطب | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePersonDepartment`, `ApispInsertPersonDepartment`, `ApispSelectPersonDepartments`, `ApispUpdatePersonDepartment` | `CrmPersonDepartments` | — | P5 | ANALYZED |
| PersonGroup | گروه مخاطب | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeletePersonGroup`, `ApispInsertPersonGroup`, `ApispSelectPersonGroups`, `ApispUpdatePersonGroup` | `CrmPersonGroups` | — | P5 | ANALYZED |
| DocOprByOprType | اقدامات سند بر اساس نوع (کوئری ویژه) | 1 | SELECT | `ApispSelectDocOprByoprType` | `WSDocOpr` | — | P6 | ANALYZED |
| OrderCommissionType | نوع پورسانت | 2 | SELECT | `ApispSelectOrderCommissionKinds`, `ApispSelectOrderCommissionTypes` | `WSOrderCommissions` | — | P6 | ANALYZED |
| PrintFormat | قالب چاپ | 1 | SELECT | `ApispSelectPrintFormat` | `PrintFormat` | — | P6 | ANALYZED |
| SettlementType | SettlementType | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteSettlementType`, `ApispInsertSettlementType`, `ApispSelectSettlementType`, `ApispUpdateSettlementType` | — *ندارد* | — | P6 | ANALYZED |
| SysDBObjectsNotNull | متادیتای DB (کوئری ویژه) | 1 | SELECT | `ApispSelectsysDBObjectsNotNull` | — *ندارد* | — | P6 | ANALYZED |
| UserForLinkedType | کاربر متصل (کوئری ویژه) | 1 | SELECT | `ApispSelectUserForLinkedType` | — *ندارد* | — | P6 | ANALYZED |
| Users | کاربران (کوئری ویژه) | 1 | SELECT | `ApispSelectUsers` | `User` | — | P6 | ANALYZED |
| VerificationWorkFlow | چرخهٔ تایید | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteVerificationWorkFlow`, `ApispSelectVerificationWorkFlows` | `WSVerificationWorkFlows` | — | P6 | ANALYZED |
| VerificationWorkFlowStep | گام چرخهٔ تایید | 4 | SELECT/INSERT/UPDATE/DELETE | `ApispDeleteVerificationWorkFlowStep`, `ApispSelectVerificationWorkFlowSteps`, `ApispUpdateVerificationWorkFlowStep` | `WSVerificationWorkFlowSteps` | — | P6 | ANALYZED |

## ۴) جمع‌بندی کمّی

- مجموع اکشن‌ها: **۲۳۳** (Select ۶۵ / Insert ۵۶ / Update ۵۶ / Delete ۵۶) — موجودیت یکتا: **64**
- دارای مدل Prisma آماده: **61 از 64** — بدون مدل: `SettlementType`, `SysDBObjectsNotNull`, `UserForLinkedType` (کوئری متادیتا، نه جدول)
- **TESTED**: 12 اکشن (گروه جغرافیا) با ۲۱ تست یکپارچه‌سازی سبز — پیام‌های عینِ منبع، ممیزی شمسی، وابستگی حذف، گیت‌های frmDefine*
- **ANALYZED**: 221 اکشن (سطح ساختاری — فهرست کامل در همین ماتریس)
- **VERIFIED**: ۰ — طبق قاعدهٔ صداقت تا اثبات کامل رفتار ثبت نمی‌شود

## ۵) شکاف‌های شناخته‌شده و موارد نیمه‌بسته

| مورد | شرح | نیاز |
|---|---|---|
| قرارداد عمیق SPها | متن کامل همهٔ SPها در statements.pack موجود است (مسدود قبلی حل شد)؛ استخراج سطر‌به‌سطر قرارداد، همراه هر گروه هنگام پیاده‌سازی انجام می‌شود | زمان اجرا — نه شواهد |
| چندزبانه (`_Lang`) | SPها برای زبان غیرپیش‌فرض از جدول‌های `_Lang` می‌خوانند؛ رستا فارسی-اول است و این جدول‌ها را عمداً نساخته | تصمیم مالک در صورت نیاز چندزبانه |
| لایسنس API | `VersionBuyer.CRMApi` در رستا مفهوم ندارد (تصمیم roadmap: رمزنگاری/لایسنس بعد از انتشار) | تصمیم مالک |
| `InsertBankingBranch` وجود ندارد | ApiBaseInfo برای شعبه فقط Update/Delete دارد (درج از فرم داخلی Banking انجام می‌شود) — هنگام گروه P5 بررسی شود | شواهد فرم داخلی Banking |
| `SelectUsers`/`UserForLinkedType`/`SysDBObjectsNotNull` | کوئری‌های ویژه (نه CRUD) — معادل رستا با قرارداد متفاوت در فرم کاربران است | تعیین دامنه هنگام P6 |
| `SelectOrderStatus`/`SelectPreOrderStatus` فقط-خواندنی | این دو تعریف فقط Select دارند (وضعیت‌های سیستمی) — درج/ویرایش از مسیر دیگری است | بررسی هنگام P4 |

## ۶) گروه پیاده‌سازی‌شده — قرارداد کامل (جغرافیا)

قرارداد کامل با ارجاع سطر‌به‌سطر شواهد در سربرگ `tests/integration/baseinfo-geo.test.ts` (S1..S7) آمده و در `src/lib/baseinfo.ts` پیاده شده است:

| قاعده | شاهد | رستا |
|---|---|---|
| نام الزامی؛ «{موجودیت} را وارد کنید.» | `CheckEmpty{Country,Province,City}` (satellite fa-IR) | ✅ عیناً |
| کد تکراری ممنوع؛ «کد {موجودیت} تکراری می باشد»؛ ویرایش خودِ رکورد مستثنا | `CompanyDefine{X}Insert/Edit` (دیکامپایل) | ✅ عیناً |
| کد عددی (پیش‌شمارهٔ تلفنی)؛ «کد {موجودیت} باید به صورت عددی وارد شود» | `checkIsNumber` (دیکامپایل) | ✅ عیناً |
| فرزند با پدر غایب ممنوع (MissingCountryId/CountryNotFound/MissingProvinceId/ProvinceNotFound) | متن ApispInsert{Province,City} | ✅ با پیام نگاشت‌شدهٔ مستند |
| حذفِ دارای وابستگی → ۴۰۹ + «از این آیتم در جایی استفاده شده و شما اجازه حذف آن را ندارید» | `CompanyDefine{X}Delete` + `Messages.RedundancyMessage` | ✅ عیناً |
| وابستگی‌ها: کشور→(استان/شرکت/مخاطب)؛ استان→(شهر/شرکت/مخاطب)؛ شهر→(شرکت/مخاطب) | همان سطرهای دیکامپایل | ✅ با فیلدهای فعال رستا (cmp*/prs*) |
| ممیزی: RegisterDatePersian=yyyyMMdd شمسی، Year1/Month1، ثبت‌کنندهٔ اولیه ≠ ویرایشگر | ApispInsert* + CompanyDefine{X}Insert | ✅ با ستون‌های rasta* (cuid) |
| شکل Select: ستون‌های ISNULL + «نام‌خانوادگی نام» ثبت/ویرایش‌کننده + join نام پدر | متن ApispSelect{Country,Province,City} | ✅ (camelCase رستا) |
| گیت‌ها: گرید=frmMain×actDefine{X}؛ ثبت/ویرایش=frmDefine{X}×actPost؛ حذف=frmDefine{X}×actDelete | `DynamicAuthorize`/`IsUserAccess` (دیکامپایل) | ✅ عیناً |

## ۷) فهرست کامل نام اکشن‌ها (برای ردیابی)

<details>
<summary>۵۶ موجودیت × نام اکشن‌ها</summary>

- **City** (4): DeleteCity, InsertCity, SelectCity, UpdateCity
- **CompanyGroup** (4): DeleteCompanyGroup, InsertCompanyGroup, SelectCompanyGroup, UpdateCompanyGroup
- **CompanySubGroup** (4): DeleteCompanySubGroup, InsertCompanySubGroup, SelectCompanySubGroup, UpdateCompanySubGroup
- **CompanyTitle** (4): DeleteCompanyTitle, InsertCompanyTitle, SelectCompanyTitle, UpdateCompanyTitle
- **CompanyType** (4): DeleteCompanyType, InsertCompanyType, SelectCompanyType, UpdateCompanyType
- **Country** (4): DeleteCountry, InsertCountry, SelectCountry, UpdateCountry
- **Education** (4): DeleteEducation, InsertEducation, SelectEducation, UpdateEducation
- **PersonJob** (4): DeletePersonJob, InsertPersonJob, SelectPersonJobs, UpdatePersonJob
- **PersonTitle** (4): DeletePersonTitle, InsertPersonTitle, SelectPersonTitle, UpdatePersonTitle
- **PersonType** (4): DeletePersonType, InsertPersonType, SelectPersonType, UpdatePersonType
- **Province** (4): DeleteProvince, InsertProvince, SelectProvince, UpdateProvince
- **Sex** (4): DeleteSex, InsertSex, SelectSex, UpdateSex
- **ConversationPriority** (4): DeleteConversationPriority, InsertConversationPriority, SelectConversationPriority, UpdateConversationPriority
- **ConversationStatus** (4): DeleteConversationStatus, InsertConversationStatus, SelectConversationStatus, UpdateConversationStatus
- **ConversationStatusGroup** (4): DeleteConversationStatusGroup, InsertConversationStatusGroup, SelectConversationStatusGroups, UpdateConversationStatusGroup
- **ConversationStatusResult** (4): DeleteConversationStatusResult, InsertConversationStatusResult, SelectConversationStatusResult, UpdateConversationStatusResult
- **ConversationTopic** (4): DeleteConversationTopic, InsertConversationTopic, SelectConversationTopics, UpdateConversationTopic
- **ProjectGrade** (4): DeleteProjectGrade, InsertProjectGrade, SelectProjectGrade, UpdateProjectGrade
- **ProjectGroup** (4): DeleteProjectGroup, InsertProjectGroup, SelectProjectGroups, UpdateProjectGroup
- **ProjectPriority** (4): DeleteProjectPriority, InsertProjectPriority, SelectProjectPriority, UpdateProjectPriority
- **ProjectTitle** (4): DeleteProjectTitle, InsertProjectTitle, SelectProjectTitles, UpdateProjectTitle
- **ProjectTitleGroup** (4): DeleteProjectTitleGroup, InsertProjectTitleGroup, SelectProjectTitleGroups, UpdateProjectTitleGroup
- **BuyOrderPaymentType** (4): DeleteBuyOrderPaymentType, InsertBuyOrderPaymentType, SelectBuyOrderPaymentTypes, UpdateBuyOrderPaymentType
- **CreditDuration** (4): DeleteCreditDuration, InsertCreditDuration, SelectCreditDuration, UpdateCreditDuration
- **CurrencyUnit** (4): DeleteCurrencyUnit, InsertCurrencyUnit, SelectCurrencyUnits, UpdateCurrencyUnit
- **CurrencyUnitRate** (4): DeleteCurrencyUnitRate, InsertCurrencyUnitRate, SelectCurrencyUnitRates, UpdateCurrencyUnitRate
- **DeliveryTime** (4): DeleteDeliveryTime, InsertDeliveryTime, SelectDeliveryTime, UpdateDeliveryTime
- **Guaranty** (4): DeleteGuaranty, InsertGuaranty, SelectGuaranty, UpdateGuaranty
- **OrderCommissionPayType** (4): DeleteOrderCommissionPayType, InsertOrderCommissionPayType, SelectOrderCommissionPayTypes, UpdateOrderCommissionPayType
- **OrderPaymentGroupI** (4): DeleteOrderPaymentGroupI, InsertOrderPaymentGroupI, SelectOrderPaymentGroupsI, UpdateOrderPaymentGroupI
- **OrderPaymentGroupII** (4): DeleteOrderPaymentGroupII, InsertOrderPaymentGroupII, SelectOrderPaymentGroupsII, UpdateOrderPaymentGroupII
- **OrderPaymentType** (4): DeleteOrderPaymentType, InsertOrderPaymentType, SelectOrderPaymentTypes, UpdateOrderPaymentType
- **PayCondition** (4): DeletePayCondition, InsertPayCondition, SelectPayCondition, UpdatePayCondition
- **ProductColor** (4): DeleteProductColor, InsertProductColor, SelectProductColor, UpdateProductColor
- **ProductUnit** (4): DeleteProductUnit, InsertProductUnit, SelectProductUnits, UpdateProductUnit
- **BuyOrderOpr** (4): DeleteBuyOrderOpr, InsertBuyOrderOpr, SelectBuyOrderOpr, UpdateBuyOrderOpr
- **DocOpr** (4): DeleteDocOpr, InsertDocOpr, SelectDocOpr, UpdateDocOpr
- **OrderOpr** (4): DeleteOrderOpr, InsertOrderOpr, SelectOrderOpr, UpdateOrderOpr
- **OrderStatus** (1): SelectOrderStatus
- **PreOrderOpr** (4): DeletePreOrderOpr, InsertPreOrderOpr, SelectPreOrderOpr, UpdatePreOrderOpr
- **PreOrderStatus** (1): SelectPreOrderStatus
- **BankingAccount** (4): DeleteBankingAccount, InsertBankingAccount, SelectBankingAccounts, UpdateBankingAccount
- **BankingAccountType** (4): DeleteBankingAccountType, InsertBankingAccountType, SelectBankingAccountTypes, UpdateBankingAccountType
- **BankingBank** (4): DeleteBankingBank, InsertBankingBank, SelectBankingBanks, UpdateBankingBank
- **BankingBranch** (4): DeleteBankingBranch, InsertBankingBranch, SelectBankingBranches, UpdateBankingBranch
- **Cash** (4): DeleteCash, InsertCash, SelectCashes, UpdateCash
- **CompanyAddressType** (4): DeleteCompanyAddressType, InsertCompanyAddressType, SelectCompanyAddressType, UpdateCompanyAddressType
- **CompanyCampaign** (4): DeleteCompanyCampaign, InsertCompanyCampaign, SelectCompanyCampaign, UpdateCompanyCampaign
- **CompanyGroupII** (4): DeleteCompanyGroupII, InsertCompanyGroupII, SelectCompanyGroupsII, UpdateCompanyGroupII
- **CompanyGroupIII** (4): DeleteCompanyGroupIII, InsertCompanyGroupIII, SelectCompanyGroupsIII, UpdateCompanyGroupIII
- **CompanyGroupIV** (4): DeleteCompanyGroupIV, InsertCompanyGroupIV, SelectCompanyGroupsIV, UpdateCompanyGroupIV
- **CompanyGroupsMulti** (4): DeleteCompanyGroupsMulti, InsertCompanyGroupsMulti, SelectCompanyGroupsMulti, UpdateCompanyGroupsMulti
- **CompanyPresentation** (4): DeleteCompanyPresentation, InsertCompanyPresentation, SelectCompanyPresentation, UpdateCompanyPresentation
- **PersonDepartment** (4): DeletePersonDepartment, InsertPersonDepartment, SelectPersonDepartments, UpdatePersonDepartment
- **PersonGroup** (4): DeletePersonGroup, InsertPersonGroup, SelectPersonGroups, UpdatePersonGroup
- **DocOprByOprType** (1): SelectDocOprByOprType
- **OrderCommissionType** (2): SelectOrderCommissionKinds, SelectOrderCommissionTypes
- **PrintFormat** (1): SelectPrintFormat
- **SettlementType** (4): DeleteSettlementType, InsertSettlementType, SelectSettlementType, UpdateSettlementType
- **SysDBObjectsNotNull** (1): SelectSysDBObjectsNotNull
- **UserForLinkedType** (1): SelectUserForLinkedType
- **Users** (1): SelectUsers
- **VerificationWorkFlow** (4): DeleteVerificationWorkFlow, InsertVerificationWorkFlow, SelectVerificationWorkFlows, UpdateVerificationWorkFlow
- **VerificationWorkFlowStep** (4): DeleteVerificationWorkFlowStep, InsertVerificationWorkFlowStep, SelectVerificationWorkFlowSteps, UpdateVerificationWorkFlowStep

</details>

</div>