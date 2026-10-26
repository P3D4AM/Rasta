#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Rasta Schema Generator — rebuilds prisma/schema.prisma so the physical database
EXACTLY mirrors CRMIdeal v3.1.18.187's own store schema (CRMTabel.ssdl).

Structure of the emitted schema.prisma:
  [HEAD]  generator/datasource + hand-maintained models (the ones the Rasta app
          actively uses), each with @@map/@map to the ORIGINAL table/column names
          + ALL missing original columns added.
  [GEN]   auto-generated models for every remaining base table — field names equal
          to original column names, original types, PK = identity.

Rules (documented deviations, never silent):
  - _Lang translation tables (253) are NOT generated: Rasta is fa-first; they can
    be generated on demand — decision documented in docs/analysis/02-original-db-catalog.md
  - Hand-maintained models keep String cuid() ids (app continuity); the id column
    still carries the ORIGINAL pk column name via @map. Newly generated models use
    Int @id @default(autoincrement()) exactly like the original identity PKs.
  - Generated models declare scalar FK columns (no Prisma relations yet) — wiring
    navigations is per-module work for the next phases.
  - Rasta-only fields with no original counterpart stay un-mapped (physical name =
    field name) and are commented «فقط رستا».
"""
import re, sys

SSDL = "/home/z/my-project/project-analysis/rasta-repo/project-analysis/decompiled/Models/CRMTabel.ssdl"
HEAD = "/home/z/my-project/scripts/schema_head.prisma"
OUT = "/home/z/my-project/project-analysis/rasta-repo/prisma/schema.prisma"

# hand-covered physical tables (emitted from HEAD file, not generated)
HAND_TABLES = {
    "Users", "CrmsysRolls", "CrmsysRollPermission",
    "CrmCompany", "CrmCompanyPersons",
    "CrmProjects", "CrmConversation", "CrmConversationStatus", "CrmConversationStatusGroups",
    "CrmProjectTitleGroups", "CrmProjectTitles", "CrmProjectCategory", "CrmProjectGrade",
    "CrmProjectPriority", "CrmProjectGroups",
    "UserPositions", "UserGroups", "UserDepartments", "UserLoginAllowedTimes",
    "CrmBankingBanks", "CrmBankingBranches", "CrmBankingAccountType", "CrmBankingAccounts",
    "CrmFund", "CrmFundGroups", "CrmUserTasks",
}

TYPE_MAP = {
    "int": "Int", "smallint": "Int", "tinyint": "Int", "bigint": "BigInt",
    "bit": "Boolean", "datetime": "DateTime", "date": "DateTime", "smalldatetime": "DateTime",
    "uniqueidentifier": "String",
    "nvarchar": "String", "varchar": "String", "ntext": "String", "nchar": "String",
    "text": "String", "xml": "String",
    "numeric": "Float", "decimal": "Float", "float": "Float", "real": "Float", "money": "Float", "smallmoney": "Float",
    "time": "String",
    "varbinary": "Bytes", "binary": "Bytes", "image": "Bytes", "timestamp": "Bytes",
}

def sanitize_model_name(name):
    return re.sub(r'[^A-Za-z0-9_]', '_', name)

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

out = []
out.append("// ═════════════════════════════════════════════════════════════════════════════════")
out.append("// رستا (Rasta) — Prisma Schema v2 — «بازسازی عیناً از کاتالوگ دیتابیس CRMIdeal v3.1.18.187»")
out.append("// ═════════════════════════════════════════════════════════════════════════════════")
out.append("// منبع قطعی: CRMTabel.ssdl (اسکیمای ذخیره‌شده در Models.dll خود محصول) — ۶۳۳ جدول (۳۸۰ اصلی + ۲۵۳ ترجمه).")
out.append("// ساختار این فایل:")
out.append("//   • بخش ۱ — مدل‌های فعال اپ رستا: هر مدل با @@map/@map دقیقاً روی نام جدول/ستون اصلی نشسته و")
out.append("//             همهٔ ستون‌های غایب نسخهٔ اصلی به آن افزوده شده است.")
out.append("//   • بخش ۲ — مدل‌های تولیدشده برای «همهٔ جدول‌های اصلی باقی‌مانده» با نام فیلد = نام ستون اصلی،")
out.append("//             نوع اصلی، و کلید اصلی identity مثل خود CRMIdeal (اتصال اپ به این جداول: فازهای بعد).")
out.append("// تصمیم‌های مستند (انحراف عامدانه — عیناً، ولی بدون شکستن اپ):")
out.append("//   • جدول‌های _Lang (۲۵۳) تولید نشدند — رستا فارسی-اول است؛ در صورت نیاز چندزبانه تولید می‌شوند.")
out.append("//   • مدل‌های فعال، شناسهٔ رشته‌ای cuid دارند (تداوم کد فعلی) اما نام فیزیکی ستون کلید = نام اصلی")
out.append("//     (مثل CompanyID/ProjectID). مدل‌های تولیدی شناسهٔ Int identity دارند مثل خود محصول.")
out.append("//   • فیلدهای مخصوص رستا که معادل اصلی ندارند، بدون @map مانده‌اند و با «فقط رستا» کامنت شده‌اند.")
out.append("//   • مدل‌های تولیدی فقط ستون اسکالر FK دارند (رابطه‌های Prisma فاز بعدی per-module سیم‌کشی می‌شوند).")
out.append("//   • مقادیر پیش‌فرض/ایندکس‌ها/بدنهٔ SPها در SSDL نیستند — پس از دریافت «کاتالوگ SQL» مالک تکمیل می‌شود.")
out.append("//")
out.append("// SQLite در توسعه فرم Enum/Decimal/list ندارد — وضعیت‌ها String هستند و در src/lib/constants.ts اعتبارسنجی می‌شوند؛")
out.append("// برای استقرار، provider به PostgreSQL تغییر می‌کند.")
out.append("")
out.append("generator client {")
out.append("  provider = \"prisma-client-js\"")
out.append("}")
out.append("")
out.append("datasource db {")
out.append("  provider = \"sqlite\"")
out.append("  url      = env(\"DATABASE_URL\")")
out.append("}")
out.append("")

# ── Section 1: hand models ──
head = open(HEAD, encoding="utf-8").read()
out.append("// ════════════════════════════════ بخش ۱ — مدل‌های فعال اپ رستا ════════════════════════════════")
out.append("")
out.append(head.rstrip())
out.append("")

# ── Section 2: generated models ──
out.append("// ════════════════════ بخش ۲ — کاتالوگ کامل جدول‌های CRMIdeal (تولید خودکار از SSDL) ════════════════════")
out.append("// نام مدل = نام جدول اصلی، نام فیلد = نام ستون اصلی، نوع‌ها مطابق SSDL، کلید identity مثل خود محصول.")
out.append("// این مدل‌ها «حضور ساختاری» جدول‌های اصلی در رستا را تضمین می‌کنند؛ اتصال API/UI به آن‌ها فازبه‌فاز انجام می‌شود.")
out.append("")

generated = 0
skipped = []
for t in order:
    if t.endswith("_Lang"):
        skipped.append(t); continue
    if t in HAND_TABLES:
        continue
    tb = tables[t]
    model = sanitize_model_name(t)
    pkset = set(tb["pk"])
    pk_is_composite = len(tb["pk"]) > 1
    out.append(f"// {t} — {len(tb['cols'])} ستون" + (" — کلید مرکب" if pk_is_composite else ""))
    out.append(f"model {model} {{")
    for c in tb["cols"]:
        base_type = re.sub(r'\(max\)$', '', c["type"])  # nvarchar(max) → nvarchar
        ptype = TYPE_MAP.get(base_type)
        if ptype is None:
            skipped.append(f"UNKNOWNTYPE {t}.{c['name']} {c['type']}")
            ptype = "String"
        fname = c["name"]
        is_pk = fname in pkset and not pk_is_composite
        nullable = "" if not c["null"] else "?"
        if is_pk:
            if c["id"]:
                out.append(f"  {fname} {ptype} @id @default(autoincrement())")
            else:
                out.append(f"  {fname} {ptype} @id")
        else:
            out.append(f"  {fname} {ptype}{nullable}")
    if pk_is_composite:
        out.append(f"  @@id([{', '.join(tb['pk'])}])")
    out.append("}")
    out.append("")
    generated += 1

out.append("// ═════════════════════════════════════════════════════════════════════════════════")
out.append(f"// پایان — تولیدشده توسط scripts/gen_rasta_schema.py | مدل‌های بخش ۲: {generated} | _Lang صرف‌نظرشده: {len([s for s in skipped if s.endswith('_Lang')])}")

open(OUT, "w", encoding="utf-8").write("\n".join(out) + "\n")
print(f"schema written: {OUT}")
print(f"generated models: {generated}")
print(f"hand tables: {len(HAND_TABLES)}")
unk = [s for s in skipped if not s.endswith("_Lang")]
if unk:
    print("WARNINGS:", unk[:20])
