#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Build docs/analysis/02-original-db-catalog.md — complete CRMIdeal DB catalog
reconstructed from the product's own embedded store schema (CRMTabel.ssdl)."""
import re, collections, json

SSDL = "/home/z/my-project/project-analysis/rasta-repo/project-analysis/decompiled/Models/CRMTabel.ssdl"
OUT = "/home/z/my-project/project-analysis/rasta-repo/docs/analysis/02-original-db-catalog.md"
AUDIT = "/home/z/my-project/scripts/db_audit.json"

ssdl = open(SSDL, encoding="utf-8").read()
tables = {}
order = []
for m in re.finditer(r'<EntityType Name="([^"]+)">(.*?)</EntityType>', ssdl, re.S):
    tname, body = m.group(1), m.group(2)
    pk = re.findall(r'<PropertyRef Name="([^"]+)"\s*/>', body)
    cols = []
    for p in re.finditer(r'<Property Name="([^"]+)"\s+Type="([^"]+)"([^/]*?)/>', body):
        attrs = p.group(3)
        cols.append({
            "name": p.group(1), "type": p.group(2),
            "null": 'Nullable="false"' not in attrs,
            "len": (re.search(r'MaxLength="(\d+)"', attrs) or [None, None])[1],
            "id": "Identity" in attrs,
        })
    tables[tname] = {"pk": pk, "cols": cols}
    order.append(tname)

# stored procedure inventory
SP = {
    "CRMSp.ssdl": 1584, "CRMSpI.ssdl": 694, "CRMSpII.ssdl": 643,
    "CRMSpIII.ssdl": 99, "CRMLinkSp.ssdl": 418,
}
sp_total = sum(SP.values())

base = [t for t in order if not t.endswith("_Lang")]
lang = [t for t in order if t.endswith("_Lang")]

# functional grouping (same logic as audit)
def group_of(t):
    t2 = t
    if t2.startswith("CrmCms"): return "CMS — سایت عمومی و مدیریت محتوا"
    if t2.startswith("CrmDyForm"): return "فرم‌ساز داینامیک"
    if t2.startswith("CrmSurvey"): return "نظرسنجی"
    if t2.startswith("CrmLinkAcc"): return "اتصال به نرم‌افزارهای حسابداری (۲۲ سامانه)"
    if t2.startswith("Sms") or t2.startswith("CrmSms"): return "پیامک"
    if t2.startswith("Email"): return "ایمیل"
    if t2.startswith("CrmTeleg"): return "تلگرام"
    if t2.startswith("CrmCall") or t2.startswith("CrmsysCI") or t2 == "TspSetting" or t2.startswith("CRMtmpManageTellNumber"): return "تلفنی / کال‌سنتر / CI"
    if t2.startswith("PayRoll"): return "حقوق و دستمزد (HRM)"
    if t2.startswith("CrmLeave") or t2.startswith("CrmTimeAttendance") or t2 == "CrmInternalMessage" or t2.startswith("CrmInternalMessage"): return "پیام داخلی / حضورغیاب / مرخصی"
    if t2.startswith("WS") or t2 == "WsWareHouse": return "ماژول فروش و انبار (WS)"
    if t2.startswith("CrmProject") or t2.startswith("CrmConversation") or t2 == "CrmProjects": return "پروژه‌ها و مذاکرات"
    if t2.startswith("CrmCompany") or t2.startswith("CrmPerson") or t2 == "CrmCompanyPersons": return "شرکت‌ها و مخاطبین"
    if t2 in ("Users","UsersPermission","UserPositions","UserDepartments","UserGroups","UserLoginAllowedTimes","UserSignature","UserPictures","UserMoneyBag","UserLanguages","UserDepartmentTicketReferUsers","CrmsysRolls","CrmsysRollPermission","CrmsysForms","CrmsysFormActions","CrmsysFormObjectProperties","CrmLinkedUsers","CrmLinkedRolls","CrmLinkedType","CrmLinkedUserPositions","CrmLinkedCompany","CrmMenuModel","CrmSystemParts","CrmUserNotes","CrmUserReportFilter","CrmOperationsType","CrmShowTableFieldInFO","CrmFileDirectoryType","CrmFileDirectoryTypeOpr"): return "کاربران، دسترسی و سیستم"
    if t2.startswith("CrmBanking") or t2 in ("CrmCashes","CrmFund","CrmFundGroups","CrmCompanyMoneyBag","CrmOnlinePayBankInfo"): return "مالی، خزانه و بانک"
    if t2.startswith("CrmKnowledgeTank"): return "دانش‌نامه"
    if t2.startswith("CrmFiles") or t2.startswith("CrmFoSetting") or t2.startswith("CrmMobSetting") or t2 == "CrmWebSetting" or t2.startswith("CrmImportFromExcel") or t2 in ("CrmNumRefSetting","CrmVersions","CrmVersionUpgrade","CrmVersionUpgradeDetails","CrmsysSetting","CrmsysDBObjects","CrmsysDBTempInfo","CrmsysDBTempInfoType","PrintFormat","PrintFormatType","Languages","CrmAddressing","CrmAddressingType","SecLetterType","SecLetters","SecLetterDefaultSettings","SecLetterNumberCounter"): return "تنظیمات و زیرساخت"
    if t2 in ("City","Province","Country","Centers","Education","Sex","ScoreRules","ScoreRulesSetting","Scores"): return "پایه و متفرقه"
    return "سایر"

groups = collections.defaultdict(list)
for t in base:
    groups[group_of(t)].append(t)

aud = json.load(open(AUDIT))
mapped = {t: d["prisma_model"] for t, d in aud["mapped"].items() if d["prisma_model"]}
# corrected real mapping (physical table -> prisma model) after name check
PHYS2MODEL = {
    "Users": "User", "CrmsysRolls": "Role", "CrmsysRollPermission": "RolePermission",
    "CrmCompany": "Company", "CrmCompanyPersons": "Contact",
    "CrmProjects": "Project", "CrmConversation": "ProjectConversation",
    "CrmConversationStatus": "CnvsStatus", "CrmConversationStatusGroups": "CnvsStatusGroup",
    "CrmProjectTitleGroups": "ProjectTitleGroup", "CrmProjectTitles": "ProjectTitle",
    "CrmProjectCategory": "ProjectCategory", "CrmProjectGrade": "ProjectGrade",
    "CrmProjectPriority": "ProjectPriority", "CrmProjectGroups": "ProjectGroup",
    "UserPositions": "UserPosition", "UserGroups": "UserGroup", "UserDepartments": "UserDepartment",
    "UserLoginAllowedTimes": "UserLoginAllowedTime",
    "CrmBankingBanks": "Bank", "CrmBankingBranches": "BankBranch",
    "CrmBankingAccountType": "BankAccountType", "CrmBankingAccounts": "BankAccount",
    "CrmFund": "FundTransaction", "CrmFundGroups": "FundGroup",
    "CrmUserTasks": "Task",
}

md = []
md.append("# کاتالوگ کامل دیتابیس CRMIdeal v3.1.18.187 — بازسازی از اسکیمای ذخیره‌شده در خود محصول\n")
md.append("> **منبع:** `CRMTabel.ssdl` — اسکیمای فروشگاهی (Store Schema) که در قلب `Models.dll` محصول کامپایل شده است. ")
md.append("> این فایل دقیقاً همان چیزی است که خود CRMIdeal از دیتابیس انتظار دارد؛ بنابراین ساختار جدول‌ها/ستون‌ها/کلیدها «مرجع قطعی» است. ")
md.append("> در صورت دریافت «کاتالوگ دستورات SQL» از مالک، این سند با آن تکمیل و صحت‌سنجی می‌شود (ایندکس‌ها/مقادیر پیش‌فرض/بدنهٔ Stored Procedureها فقط از آن فایل قابل استخراج‌اند).\n")
md.append("## آمار کلی\n")
md.append("| شاخص | مقدار |")
md.append("|---|---|")
md.append(f"| جدول‌های اصلی (بدون ترجمه) | **{len(base)}** |")
md.append(f"| جدول‌های ترجمه (`_Lang` — چهار زبان fa/tr/ar/de) | **{len(lang)}** |")
md.append(f"| جمع کل جدول‌ها | **{len(order)}** |")
md.append(f"| Stored Procedureهای تعریف‌شده در اسکیماهای EF | **{sp_total}** |")
for k, v in SP.items():
    md.append(f"  - `{k}`: {v} تابع |")
md.append("")
md.append("## گروه‌بندی کارکردی جدول‌های اصلی\n")
md.append("| گروه | تعداد جدول |")
md.append("|---|---|")
for g in sorted(groups, key=lambda k: -len(groups[k])):
    md.append(f"| {g} | {len(groups[g])} |")
md.append("")
md.append("## وضعیت پوشش در رستا (قبل از بازسازی اسکیمای این فاز)\n")
md.append(f"- مدل‌های موجود در رستا پیش از این فاز: **{aud['total_rasta_models']}** (معادل {len(PHYS2MODEL)} جدول اصلی)")
md.append("- جدول‌های اصلی که مدل معادل داشتند و در این فاز ستون‌هایشان با `@map` دقیقاً به نام اصلی برگشت و ستون‌های غایب اضافه شد:")
for t, m in sorted(PHYS2MODEL.items()):
    md.append(f"  - `{t}` → مدل `{m}` ({len(tables[t]['cols'])} ستون)")
md.append("\n## کاتالوگ کامل جدول‌ها\n")
for g in sorted(groups, key=lambda k: (k)):
    md.append(f"### {g} ({len(groups[g])} جدول)\n")
    for t in sorted(groups[g]):
        pk = ",".join(tables[t]["pk"]) or "—"
        md.append(f"#### {t} ({len(tables[t]['cols'])} ستون)")
        md.append(f"- کلید: `{pk}`")
        cols_line = ", ".join(f"`{c['name']}`({'?' if c['null'] else '!'}:{c['type']}" + (f"[{c['len']}]" if c['len'] else "") + ("⇄" if c['id'] else "") + ")" for c in tables[t]["cols"])
        md.append(f"- ستون‌ها: {cols_line}")
        md.append("")
open(OUT, "w", encoding="utf-8").write("\n".join(md))
print(f"Wrote {OUT}: {len(md)} lines, {len(base)} base tables, {len(lang)} lang tables, {sum(len(v) for v in groups.values())} grouped")
