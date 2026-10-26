#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Verify: every original column of the 26 hand-mapped tables appears EXACTLY once
(physical name) in the final schema; report missing/duplicates."""
import re

SSDL = "/home/z/my-project/project-analysis/rasta-repo/project-analysis/decompiled/Models/CRMTabel.ssdl"
SCHEMA = "/home/z/my-project/project-analysis/rasta-repo/prisma/schema.prisma"

HAND = ["Users","CrmsysRolls","CrmsysRollPermission","CrmCompany","CrmCompanyPersons",
    "CrmProjects","CrmConversation","CrmConversationStatus","CrmConversationStatusGroups",
    "CrmProjectTitleGroups","CrmProjectTitles","CrmProjectCategory","CrmProjectGrade",
    "CrmProjectPriority","CrmProjectGroups","UserPositions","UserGroups","UserDepartments",
    "UserLoginAllowedTimes","CrmBankingBanks","CrmBankingBranches","CrmBankingAccountType",
    "CrmBankingAccounts","CrmFund","CrmFundGroups","CrmUserTasks"]

ssdl = open(SSDL, encoding="utf-8").read()
orig_cols = {}
for t in HAND:
    m = re.search(r'<EntityType Name="%s">(.*?)</EntityType>' % re.escape(t), ssdl, re.S)
    orig_cols[t] = [p.group(1) for p in re.finditer(r'<Property Name="([^"]+)"', m.group(1))]

schema = open(SCHEMA, encoding="utf-8").read()
# parse each model block: capture model name, and its fields with optional @map
models = {}
for m in re.finditer(r'^model (\w+) \{(.*?)^\}', schema, re.S | re.M):
    name, body = m.group(1), m.group(2)
    phys = []
    for line in body.splitlines():
        line = line.strip()
        if not line or line.startswith("//") or line.startswith("@@"):
            continue
        fm = re.match(r'(\w+)\s+\S', line)
        if fm:
            f = fm.group(1)
            mp = re.search(r'@map\("([^"]+)"\)', line)
            phys.append(mp.group(1) if mp else f)
    models[name] = phys

MODEL_OF = {"Users":"User","CrmsysRolls":"Role","CrmsysRollPermission":"RolePermission",
    "CrmCompany":"Company","CrmCompanyPersons":"Contact","CrmProjects":"Project",
    "CrmConversation":"ProjectConversation","CrmConversationStatus":"CnvsStatus",
    "CrmConversationStatusGroups":"CnvsStatusGroup","CrmProjectTitleGroups":"ProjectTitleGroup",
    "CrmProjectTitles":"ProjectTitle","CrmProjectCategory":"ProjectCategory",
    "CrmProjectGrade":"ProjectGrade","CrmProjectPriority":"ProjectPriority",
    "CrmProjectGroups":"ProjectGroup","UserPositions":"UserPosition","UserGroups":"UserGroup",
    "UserDepartments":"UserDepartment","UserLoginAllowedTimes":"UserLoginAllowedTime",
    "CrmBankingBanks":"Bank","CrmBankingBranches":"BankBranch",
    "CrmBankingAccountType":"BankAccountType","CrmBankingAccounts":"BankAccount",
    "CrmFund":"FundTransaction","CrmFundGroups":"FundGroup","CrmUserTasks":"Task"}

bad = 0
for t, mname in MODEL_OF.items():
    if mname not in models:
        print(f"!! MODEL MISSING: {mname}"); bad += 1; continue
    have = models[mname]
    dup = [c for c in have if have.count(c) > 1]
    miss = [c for c in orig_cols[t] if c not in have]
    status = "OK" if not dup and not miss else "FAIL"
    print(f"[{status}] {t} → {mname}: original {len(orig_cols[t])} cols | in-schema {len(have)} | missing {len(miss)} | dup {len(set(dup))}")
    if miss: print(f"    MISSING: {miss}")
    if dup: print(f"    DUP: {sorted(set(dup))}")
    if miss or dup: bad += 1

print(f"\n{'ALL 26 HAND TABLES MATCH ORIGINAL COLUMNS EXACTLY' if bad==0 else f'{bad} TABLES WITH PROBLEMS'}")

# ── Table-name (@@map) verification ──
import re as _re
_schema = open(SCHEMA, encoding="utf-8").read()
_tbl_ok, _tbl_bad = 0, []
for _t, _m in MODEL_OF.items():
    _mm = _re.search(r'^model %s \{(.*?)^\}' % _m, _schema, _re.S | _re.M)
    if _mm and '@@map("%s")' % _t in _mm.group(1):
        _tbl_ok += 1
    else:
        _tbl_bad.append(f"{_m} missing @@map(\"{_t}\")")
print(f"TABLE NAMES: {_tbl_ok}/26 correct; problems: {_tbl_bad if _tbl_bad else 'none'}")
