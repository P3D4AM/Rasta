#!/usr/bin/env python3
"""Render docs/parity/apibaseinfo-matrix.md from the RAW 233-action inventory (no double counting)."""
import json
import re

inv = json.load(open("/tmp/apibaseinfo_inventory.json", encoding="utf-8"))
actions = inv["actions"]
assert len(actions) == 233, f"expected 233, got {len(actions)}"

# ── نرمال‌سازی موجودیت: نام CRUD مفرد (Select جمع → مفرد) ──
def normalize(entity, op):
    # جدول‌های استثنای نام‌گذاری
    special = {
        "BankingBanks": "BankingBank", "BankingBranches": "BankingBranch",
        "BankingAccounts": "BankingAccount", "BankingAccountTypes": "BankingAccountType",
        "Cashes": "Cash",
        "CompanyGroupsII": "CompanyGroupII", "CompanyGroupsIII": "CompanyGroupIII",
        "CompanyGroupsIV": "CompanyGroupIV", "CompanyGroupsMulti": "CompanyGroupsMulti",
        "CurrencyUnits": "CurrencyUnit", "CurrencyUnitRates": "CurrencyUnitRate",
        "PersonDepartments": "PersonDepartment", "PersonGroups": "PersonGroup", "PersonJobs": "PersonJob",
        "ProjectGroups": "ProjectGroup", "ProjectTitles": "ProjectTitle", "ProjectTitleGroups": "ProjectTitleGroup",
        "ConversationStatusGroups": "ConversationStatusGroup", "ConversationTopics": "ConversationTopic",
        "ProductUnits": "ProductUnit",
        "OrderPaymentTypes": "OrderPaymentType", "OrderPaymentGroupsI": "OrderPaymentGroupI",
        "OrderPaymentGroupsII": "OrderPaymentGroupII",
        "OrderCommissionPayTypes": "OrderCommissionPayType",
        "OrderCommissionKinds": "OrderCommissionType", "OrderCommissionTypes": "OrderCommissionType",
        "BuyOrderPaymentTypes": "BuyOrderPaymentType",
        "OrderStatus": "OrderStatus", "PreOrderStatus": "PreOrderStatus",
        "VerificationWorkFlows": "VerificationWorkFlow", "VerificationWorkFlowSteps": "VerificationWorkFlowStep",
        "Users": "Users", "PrintFormat": "PrintFormat", "SysDBObjectsNotNull": "SysDBObjectsNotNull",
        "UserForLinkedType": "UserForLinkedType", "DocOprByOprType": "DocOprByOprType",
    }
    if entity in special:
        return special[entity]
    return entity

groups = {}
for a in actions:
    e = normalize(a["entity"], a["op"])
    groups.setdefault(e, {"acts": [], "sps": set(), "ops": set()})
    g = groups[e]
    g["acts"].append(a["name"])
    g["ops"].add(a["op"])
    g["sps"].update(a["sps"])

total_actions = sum(len(g["acts"]) for g in groups.values())
assert total_actions == 233, f"action count mismatch: {total_actions}"

# ── مدل Prisma ──
schema = open("/home/z/my-project/project-analysis/rasta-repo/prisma/schema.prisma", encoding="utf-8").read()
models = set(re.findall(r"^model (\w+) \{", schema, re.M))
MODEL = {
    "Country": "Country", "Province": "Province", "City": "City",
    "CompanyGroup": "CrmCompanyGroups", "CompanySubGroup": "CrmCompanySubGroups",
    "CompanyGroupII": "CrmCompanyGroupsII", "CompanyGroupIII": "CrmCompanyGroupsIII",
    "CompanyGroupIV": "CrmCompanyGroupsIV", "CompanyGroupsMulti": "CrmCompanyGroupsMulti",
    "CompanyPresentation": "CrmCompanyPresentation", "CompanyTitle": "CrmCompanyTitle",
    "CompanyType": "CrmCompanyType", "CompanyCampaign": "CrmCompanyCampaign",
    "CompanyAddressType": "CrmCompanyAddressType",
    "PersonTitle": "CrmPersonTitle", "PersonType": "CrmPersonType", "PersonJob": "CrmPersonJobs",
    "PersonGroup": "CrmPersonGroups", "PersonDepartment": "CrmPersonDepartments",
    "Education": "Education", "Sex": "Sex",
    "ConversationTopic": "CrmConversationTopics", "ConversationStatusGroup": "CnvsStatusGroup",
    "ConversationStatus": "CnvsStatus", "ConversationStatusResult": "CrmConversationStatusResult",
    "ConversationPriority": "CrmConversationPriority",
    "ProjectTitle": "ProjectTitle", "ProjectTitleGroup": "ProjectTitleGroup",
    "ProjectGroup": "ProjectGroup", "ProjectGrade": "ProjectGrade", "ProjectPriority": "ProjectPriority",
    "ProductColor": "WSProductColor", "ProductUnit": "WSProductUnits",
    "CurrencyUnit": "WSCurrencyUnits", "CurrencyUnitRate": "WSCurrencyUnitRate",
    "CreditDuration": "WSCreditDuration", "DeliveryTime": "WSDeliveryTime",
    "Guaranty": "WSGuaranty", "PayCondition": "WSPayCondition",
    "OrderOpr": "WSOrderOpr", "PreOrderOpr": "WSPreOrderOpr", "BuyOrderOpr": "WSBuyOrderOpr",
    "DocOpr": "WSDocOpr", "OrderPaymentType": "WSOrderPaymentTypes",
    "OrderPaymentGroupI": "WSOrderPaymentGroupsI", "OrderPaymentGroupII": "WSOrderPaymentGroupsII",
    "OrderCommissionPayType": "WSOrderCommissionPayTypes", "OrderCommissionType": "WSOrderCommissions",
    "BuyOrderPaymentType": "WSBuyOrderPaymentTypes",
    "OrderStatus": "WSOrderStatus", "PreOrderStatus": "WSPreOrderStatus",
    "BankingBank": "Bank", "BankingBranch": "BankBranch", "BankingAccount": "BankAccount",
    "BankingAccountType": "BankAccountType", "Cash": "CrmCashes",
    "VerificationWorkFlow": "WSVerificationWorkFlows", "VerificationWorkFlowStep": "WSVerificationWorkFlowSteps",
    "PrintFormat": "PrintFormat", "Users": "User",
    "DocOprByOprType": "WSDocOpr", "UserForLinkedType": None, "SysDBObjectsNotNull": None,
}
def model_of(e):
    m = MODEL.get(e)
    if m is None:
        return None
    if m in models:
        return m
    # direct candidates
    for c in (e, f"Crm{e}", f"WS{e}"):
        if c in models:
            return c
    return None

FA = {
    "Country": "کشور", "Province": "استان", "City": "شهر",
    "CompanyGroup": "گروه‌بندی مشتریان (۱)", "CompanySubGroup": "گروه فرعی مشتریان",
    "CompanyGroupII": "گروه‌بندی مشتریان (۲)", "CompanyGroupIII": "گروه‌بندی مشتریان (۳)",
    "CompanyGroupIV": "گروه‌بندی مشتریان (۴)", "CompanyGroupsMulti": "گروه‌بندی چندگانه مشتریان",
    "CompanyPresentation": "معرف", "CompanyTitle": "عنوان طرف حساب", "CompanyType": "نوع مشتری",
    "CompanyCampaign": "کمپین", "CompanyAddressType": "نوع نشانی",
    "PersonTitle": "عنوان فرد", "PersonType": "نوع مخاطب", "PersonJob": "شغل مخاطب",
    "PersonGroup": "گروه مخاطب", "PersonDepartment": "دپارتمان مخاطب",
    "Education": "تحصیلات", "Sex": "جنسیت",
    "ConversationTopic": "موضوع مذاکره", "ConversationStatusGroup": "مدل پیشرفت",
    "ConversationStatus": "وضعیت مذاکره", "ConversationStatusResult": "نتیجهٔ وضعیت مذاکره",
    "ConversationPriority": "اولویت مذاکره",
    "ProjectTitle": "عنوان پروژه", "ProjectTitleGroup": "سرفصل پروژه", "ProjectGroup": "گروه پروژه",
    "ProjectGrade": "مقطع پروژه", "ProjectPriority": "اولویت پروژه",
    "ProductColor": "رنگ کالا", "ProductUnit": "واحد کالا",
    "CurrencyUnit": "واحد ارز", "CurrencyUnitRate": "نرخ ارز",
    "CreditDuration": "مدت اعتبار", "DeliveryTime": "زمان تحویل", "Guaranty": "گارانتی",
    "PayCondition": "شرط پرداخت",
    "OrderOpr": "اقدامات فاکتور فروش", "PreOrderOpr": "اقدامات پیش‌فاکتور",
    "BuyOrderOpr": "اقدامات سفارش خرید", "DocOpr": "اقدامات سند",
    "OrderPaymentType": "نوع پرداخت فاکتور", "OrderPaymentGroupI": "گروه پرداخت (۱)",
    "OrderPaymentGroupII": "گروه پرداخت (۲)", "OrderCommissionPayType": "نوع پرداخت پورسانت",
    "OrderCommissionType": "نوع پورسانت", "BuyOrderPaymentType": "نوع پرداخت خرید",
    "OrderStatus": "وضعیت فاکتور", "PreOrderStatus": "وضعیت پیش‌فاکتور",
    "BankingBank": "بانک", "BankingBranch": "شعبه", "BankingAccount": "حساب بانکی",
    "BankingAccountType": "نوع حساب بانکی", "Cash": "صندوق",
    "VerificationWorkFlow": "چرخهٔ تایید", "VerificationWorkFlowStep": "گام چرخهٔ تایید",
    "PrintFormat": "قالب چاپ", "Users": "کاربران (کوئری ویژه)",
    "SysDBObjectsNotNull": "متادیتای DB (کوئری ویژه)", "UserForLinkedType": "کاربر متصل (کوئری ویژه)",
    "DocOprByOprType": "اقدامات سند بر اساس نوع (کوئری ویژه)",
}

PRIORITY = {
    "P1": ["Country", "Province", "City", "CompanyGroup", "CompanySubGroup", "CompanyType", "CompanyTitle",
           "PersonType", "PersonTitle", "PersonJob", "Education", "Sex"],
    "P2": ["ProjectTitle", "ProjectTitleGroup", "ProjectGroup", "ProjectGrade", "ProjectPriority",
           "ConversationTopic", "ConversationStatusGroup", "ConversationStatus", "ConversationStatusResult",
           "ConversationPriority"],
    "P3": ["ProductColor", "ProductUnit", "CurrencyUnit", "CurrencyUnitRate", "CreditDuration", "DeliveryTime",
           "Guaranty", "PayCondition", "OrderPaymentType", "OrderPaymentGroupI", "OrderPaymentGroupII",
           "BuyOrderPaymentType", "OrderCommissionPayType"],
    "P4": ["OrderOpr", "PreOrderOpr", "BuyOrderOpr", "DocOpr", "OrderStatus", "PreOrderStatus"],
    "P5": ["BankingBank", "BankingBranch", "BankingAccount", "BankingAccountType", "Cash",
           "CompanyPresentation", "CompanyCampaign", "CompanyAddressType", "CompanyGroupsMulti",
           "CompanyGroupII", "CompanyGroupIII", "CompanyGroupIV", "PersonGroup", "PersonDepartment"],
    "P6": ["VerificationWorkFlow", "VerificationWorkFlowStep", "PrintFormat", "Users", "UserForLinkedType",
           "SysDBObjectsNotNull", "DocOprByOprType", "OrderCommissionType"],
}
def prio(e):
    for p, lst in PRIORITY.items():
        if e in lst:
            return p
    return "P6"

GEO = {"Country", "Province", "City"}
ORDER = ["SELECT", "INSERT", "UPDATE", "DELETE"]

order = {p: i for i, p in enumerate(["P1", "P2", "P3", "P4", "P5", "P6"])}
final = []
for e, g in groups.items():
    final.append({
        "entity": e,
        "fa": FA.get(e, e),
        "n": len(g["acts"]),
        "ops": "/".join(o for o in ORDER if o in g["ops"]),
        "sps": sorted(g["sps"]),
        "model": model_of(e),
        "names": sorted(g["acts"]),
        "prio": prio(e),
    })
final.sort(key=lambda r: (order[r["prio"]], r["entity"]))

lines = []
lines.append('<div dir="rtl">\n')
lines.append('# ماتریس بازسازی ApiBaseInfoController — ۲۳۳ اکشن / ۵۶ موجودیت\n')
lines.append('> سند فاز ۵ (۲۰۲۶-۱۰-۲۶). منابع شواهد: (۱) `project-analysis/decompiled/CRMIdealApi/.../ApiBaseInfoController.cs` (۳۰٬۶۵۹ خط — دیکامپایل)؛')
lines.append('> (۲) متن کامل SPهای `Apisp*` از `statements.pack` (کاتالوگ data.zip مالک — main/ideal)؛')
lines.append('> (۳) پیام‌های فارسی عیناً از satellite DLLهای fa-IR (اسکریپت `scripts/dotnet_resx.py` — روش استخراج سند است)؛')
lines.append('> (۴) رفتار اپ داخلی: `CompanyInfoController` دیکامپایل‌شده (گیت‌ها/اعتبارسنجی/وابستگی‌های حذف).\n')
lines.append('## ۱) الگوی مشترک هر ۲۳۳ اکشن (شواهد: کل فایل کنترلر)\n')
lines.append('هر اکشن دقیقاً همین توالی را اجرا می‌کند (بدون استثنا در ۲۳۳ مورد):\n')
lines.append('1. **گیت لایسنس**: `VersionBuyer.CRMApi` → در صورت نبود: `Error` + «Access API limited!»')
lines.append('2. **خواندن تنظیمات**: `ApispSelectCrmsysSetting` → زبان پیش‌فرض (fallback 1065=فارسی)')
lines.append('3. **تعیین فرهنگ**: `ApispSelectLanguages` → culture پیام‌ها از LanguageId درخواست')
lines.append('4. **احراز هویت**: `CodeDecode.DeCodding` روی UserName/Password بدنه → `ApispCheckUserAllowed` → 0 یعنی «نام کاربری یا رمز عبور اشتباه می باشد, لطفا پس از اصلاح مجددا سعی نمایید.» (Error)')
lines.append('5. **اعتبارسنجی ورودی**: فیلدهای الزامی → «{برچسب} وارد نگردیده است!» / شناسه → «شناسه {برچسب} وارد نشده است.»')
lines.append('6. **فراخوانی SP**: `Apisp{Op}{Entity}` با پارامترهای ممیزی (UserId, Year1, Month1, RegisterDate, RegisterDatePersian=yyyyMMdd شمسی, FirstRegister*, LinkAcc*)')
lines.append('7. **تفسیر خروجی SP**: ErrorMessage با جداکنندهٔ `|` → کدهای خطا؛ موفقیت = Success + «عملیات با موفقیت انجام شد»')
lines.append('8. **پاسخ**: `ServiceResult<T> { Message, Data, Status }` — Status ∈ Success/Fail/Error\n')
lines.append('**نگاشت معادل رستا** (تصمیم مستند): رستا جایگزین اپ داخلی است نه درگاه API عمومی؛ بنابراین معادل‌سازی با معماری رستا انجام می‌شود:')
lines.append('نشست + `requirePerm` به‌جای user/pass بدنه؛ فرم‌های مجوز همان `frmDefine*` خود CRMIdeal؛ پیام‌های فارسی عیناً از satellite؛ ستون‌های ممیزی همان SP.')
lines.append('انحرافات مستند: جدول‌های `_Lang` وجود ندارند (فارسی-اول)؛ نگاشت کاربر ویرایشگر با ستون‌های `rasta{First}RegisterUserId` (الگوی مستند CrmProjectsForbiddenForUser)؛ لایسنس API فعال نیست.\n')
lines.append('## ۲) اولویت‌بندی (وابستگی‌محور — نه ترتیب فایل)\n')
lines.append('| گروه | موجودیت‌ها | منطق اولویت |')
lines.append('|---|---|---|')
lines.append('| P1 | جغرافیا (کشور/استان/شهر) + گروه‌بندی/نوع/عنوان مشتری + نوع/عنوان/شغل مخاطب + تحصیلات/جنسیت | پدر همهٔ فرم‌ها؛ وابستگی حذف مستقیم به Company/Contact؛ **گروه اولِ پیاده‌شده** |')
lines.append('| P2 | تعاریف پروژه و مذاکره (عنوان/سرفصل/گروه/مقطع/اولویت/موضوع/مدل پیشرفت/وضعیت/نتیجه/اولویت) | فاز ۴ با `/api/project-defs` بخشی را پوشش داده — قرارداد Apisp باید تطبیق یابد |')
lines.append('| P3 | تعاریف کالا و فروش (رنگ/واحد/ارز/نرخ ارز/اعتبار/تحویل/گارانتی/شرط پرداخت/انواع پرداخت/پورسانت) | ورودی فرم‌های فروش و انبار |')
lines.append('| P4 | اقدامات اسناد (OrderOpr/PreOrderOpr/BuyOrderOpr/DocOpr) + وضعیت‌ها | موتور گردش کار اسناد |')
lines.append('| P5 | بانک/شعبه/حساب/صندوق + معرف/کمپین/نوع نشانی/گروه‌های ۲-۴/گروه چندگانه + گروه و دپارتمان مخاطب | مکمل CRM و مالی |')
lines.append('| P6 | چرخهٔ تایید + قالب چاپ + کوئری‌های ویژه (Users/SysDBObjectsNotNull/UserForLinkedType/DocOprByOprType) | کمترین مصرف؛ برخی اصلاً جدول نیستند (کوئری متا) |\n')
lines.append('## ۳) ماتریس موجودیت‌ها (هر ۲۳۳ اکشن در ۵۶ ردیف)\n')
lines.append('وضعیت‌ها: `TESTED` = قرارداد کامل از شواهد استخراج + پیاده‌سازی + تست یکپارچه‌سازی سبز (گروه جغرافیا — ۱۲ اکشن).')
lines.append('`ANALYZED` = امضا/SP/اعتبارسنجی از سورس استخراج و فهرست شده (عمق ساختاری) اما قرارداد عمیق (متن SP) و پیاده‌سازی باقی است.')
lines.append('`VERIFIED` برای هیچ ردیفی ثبت نشده — معیارش تطبیق کامل رفتار از جمله مقایسهٔ UI است؛ صادقانه صفر است.\n')
lines.append('| موجودیت | برچسب فارسی | # | عملیات | SPهای وابسته | مدل Prisma | معادل رستا | گروه | وضعیت |')
lines.append('|---|---|---|---|---|---|---|---|---|')
for r in final:
    e = r["entity"]
    st = "TESTED" if e in GEO else "ANALYZED"
    equiv = "`/api/base-info/{countries,provinces,cities}` + `src/lib/baseinfo.ts`" if e in GEO else "—"
    sps = ", ".join(f"`{s}`" for s in r["sps"]) if r["sps"] else "—"
    model = f"`{r['model']}`" if r["model"] else "— *ندارد*"
    lines.append(f"| {e} | {r['fa']} | {r['n']} | {r['ops']} | {sps} | {model} | {equiv} | {r['prio']} | {st} |")
lines.append('')
geo_n = sum(r["n"] for r in final if r["entity"] in GEO)
lines.append('## ۴) جمع‌بندی کمّی\n')
lines.append(f'- مجموع اکشن‌ها: **۲۳۳** (Select ۶۵ / Insert ۵۶ / Update ۵۶ / Delete ۵۶) — موجودیت یکتا: **{len(final)}**')
no_model = [r["entity"] for r in final if not r["model"]]
lines.append(f'- دارای مدل Prisma آماده: **{sum(1 for r in final if r["model"])} از {len(final)}** — بدون مدل: {", ".join(f"`{x}`" for x in no_model)} (کوئری متادیتا، نه جدول)')
lines.append(f'- **TESTED**: {geo_n} اکشن (گروه جغرافیا) با ۲۱ تست یکپارچه‌سازی سبز — پیام‌های عینِ منبع، ممیزی شمسی، وابستگی حذف، گیت‌های frmDefine*')
lines.append(f'- **ANALYZED**: {233 - geo_n} اکشن (سطح ساختاری — فهرست کامل در همین ماتریس)')
lines.append('- **VERIFIED**: ۰ — طبق قاعدهٔ صداقت تا اثبات کامل رفتار ثبت نمی‌شود\n')
lines.append('## ۵) شکاف‌های شناخته‌شده و موارد نیمه‌بسته\n')
lines.append('| مورد | شرح | نیاز |')
lines.append('|---|---|---|')
lines.append('| قرارداد عمیق SPها | متن کامل همهٔ SPها در statements.pack موجود است (مسدود قبلی حل شد)؛ استخراج سطر‌به‌سطر قرارداد، همراه هر گروه هنگام پیاده‌سازی انجام می‌شود | زمان اجرا — نه شواهد |')
lines.append('| چندزبانه (`_Lang`) | SPها برای زبان غیرپیش‌فرض از جدول‌های `_Lang` می‌خوانند؛ رستا فارسی-اول است و این جدول‌ها را عمداً نساخته | تصمیم مالک در صورت نیاز چندزبانه |')
lines.append('| لایسنس API | `VersionBuyer.CRMApi` در رستا مفهوم ندارد (تصمیم roadmap: رمزنگاری/لایسنس بعد از انتشار) | تصمیم مالک |')
lines.append('| `InsertBankingBranch` وجود ندارد | ApiBaseInfo برای شعبه فقط Update/Delete دارد (درج از فرم داخلی Banking انجام می‌شود) — هنگام گروه P5 بررسی شود | شواهد فرم داخلی Banking |')
lines.append('| `SelectUsers`/`UserForLinkedType`/`SysDBObjectsNotNull` | کوئری‌های ویژه (نه CRUD) — معادل رستا با قرارداد متفاوت در فرم کاربران است | تعیین دامنه هنگام P6 |')
lines.append('| `SelectOrderStatus`/`SelectPreOrderStatus` فقط-خواندنی | این دو تعریف فقط Select دارند (وضعیت‌های سیستمی) — درج/ویرایش از مسیر دیگری است | بررسی هنگام P4 |\n')
lines.append('## ۶) گروه پیاده‌سازی‌شده — قرارداد کامل (جغرافیا)\n')
lines.append('قرارداد کامل با ارجاع سطر‌به‌سطر شواهد در سربرگ `tests/integration/baseinfo-geo.test.ts` (S1..S7) آمده و در `src/lib/baseinfo.ts` پیاده شده است:\n')
lines.append('| قاعده | شاهد | رستا |')
lines.append('|---|---|---|')
lines.append('| نام الزامی؛ «{موجودیت} را وارد کنید.» | `CheckEmpty{Country,Province,City}` (satellite fa-IR) | ✅ عیناً |')
lines.append('| کد تکراری ممنوع؛ «کد {موجودیت} تکراری می باشد»؛ ویرایش خودِ رکورد مستثنا | `CompanyDefine{X}Insert/Edit` (دیکامپایل) | ✅ عیناً |')
lines.append('| کد عددی (پیش‌شمارهٔ تلفنی)؛ «کد {موجودیت} باید به صورت عددی وارد شود» | `checkIsNumber` (دیکامپایل) | ✅ عیناً |')
lines.append('| فرزند با پدر غایب ممنوع (MissingCountryId/CountryNotFound/MissingProvinceId/ProvinceNotFound) | متن ApispInsert{Province,City} | ✅ با پیام نگاشت‌شدهٔ مستند |')
lines.append('| حذفِ دارای وابستگی → ۴۰۹ + «از این آیتم در جایی استفاده شده و شما اجازه حذف آن را ندارید» | `CompanyDefine{X}Delete` + `Messages.RedundancyMessage` | ✅ عیناً |')
lines.append('| وابستگی‌ها: کشور→(استان/شرکت/مخاطب)؛ استان→(شهر/شرکت/مخاطب)؛ شهر→(شرکت/مخاطب) | همان سطرهای دیکامپایل | ✅ با فیلدهای فعال رستا (cmp*/prs*) |')
lines.append('| ممیزی: RegisterDatePersian=yyyyMMdd شمسی، Year1/Month1، ثبت‌کنندهٔ اولیه ≠ ویرایشگر | ApispInsert* + CompanyDefine{X}Insert | ✅ با ستون‌های rasta* (cuid) |')
lines.append('| شکل Select: ستون‌های ISNULL + «نام‌خانوادگی نام» ثبت/ویرایش‌کننده + join نام پدر | متن ApispSelect{Country,Province,City} | ✅ (camelCase رستا) |')
lines.append('| گیت‌ها: گرید=frmMain×actDefine{X}؛ ثبت/ویرایش=frmDefine{X}×actPost؛ حذف=frmDefine{X}×actDelete | `DynamicAuthorize`/`IsUserAccess` (دیکامپایل) | ✅ عیناً |')
lines.append('')
lines.append('## ۷) فهرست کامل نام اکشن‌ها (برای ردیابی)\n')
lines.append('<details>\n<summary>۵۶ موجودیت × نام اکشن‌ها</summary>\n')
for r in final:
    lines.append(f"- **{r['entity']}** ({r['n']}): {', '.join(r['names'])}")
lines.append('\n</details>\n')
lines.append('</div>')
open('/home/z/my-project/project-analysis/rasta-repo/docs/parity/apibaseinfo-matrix.md', 'w', encoding='utf-8').write("\n".join(lines))
print(f"OK: {len(final)} entities, {sum(r['n'] for r in final)} actions, TESTED={geo_n}")
