#!/usr/bin/env python3
"""Extract the full ApiBaseInfo action inventory from the decompiled controller.
Output: JSON with entity groups, operations, SP dependencies, and Rasta model availability.
"""
import re
import json

SRC = "/home/z/my-project/project-analysis/rasta-repo/project-analysis/decompiled/CRMIdealApi/CRMIdealApi/Controllers/ApiBaseInfoController.cs"

text = open(SRC, encoding="utf-8").read()

# action signature pattern: public ServiceResult<...> Name(Params model)
sig_re = re.compile(r"public ServiceResult<([^>]+(?:<[^>]*>)?)>\s+(\w+)\((\w+) model\)")
actions = []
for m in sig_re.finditer(text):
    ret, name, params = m.groups()
    op = "SELECT" if name.startswith("Select") else "INSERT" if name.startswith("Insert") else "UPDATE" if name.startswith("Update") else "DELETE" if name.startswith("Delete") else "OTHER"
    # entity = name minus op prefix
    entity = name[len(op.title()) if op != "SELECT" else 6:] if op != "OTHER" else name
    entity = name.removeprefix("Select").removeprefix("Insert").removeprefix("Update").removeprefix("Delete")
    # SP dependencies within the action body (from this signature to the next)
    start = m.end()
    nxt = sig_re.search(text, start)
    body = text[start:nxt.start() if nxt else len(text)]
    sps = sorted(set(re.findall(r"cRMEntities\.(\w+)\(", body)))
    # only Apisp* calls (exclude common ones)
    apisp = [s for s in sps if s.startswith("Apisp") and s not in ("ApispCheckUserAllowed", "ApispSelectCrmsysSetting", "ApispSelectLanguages")]
    # required field validations (string.IsNullOrEmpty(model.X))
    reqs = sorted(set(re.findall(r"string\.IsNullOrEmpty\(model\.(\w+)\)", body)))
    # id validations (model.X <= 0)
    ids = sorted(set(re.findall(r"model\.(\w+Id)\s*<=\s*0", body)))
    actions.append({
        "name": name, "op": op, "entity": entity, "returns": ret.strip(),
        "params": params, "sps": apisp, "required": reqs, "idChecks": ids,
    })

print(f"total actions: {len(actions)}")
# entity grouping
entities = {}
for a in actions:
    entities.setdefault(a["entity"], []).append(a)

print(f"entities: {len(entities)}")
ops_count = {}
for a in actions:
    ops_count[a["op"]] = ops_count.get(a["op"], 0) + 1
print(f"ops: {ops_count}")

# entities with which ops
full_crud = [e for e, acts in entities.items() if {a["op"] for a in acts} == {"SELECT", "INSERT", "UPDATE", "DELETE"}]
no_delete = [e for e, acts in entities.items() if {a["op"] for a in acts} == {"SELECT", "INSERT", "UPDATE"}]
select_only = [e for e, acts in entities.items() if {a["op"] for a in acts} == {"SELECT"}]
print(f"full CRUD: {len(full_crud)}, no-delete: {len(no_delete)}, select-only: {len(select_only)}")
print("select-only entities:", select_only)

with open("/tmp/apibaseinfo_inventory.json", "w", encoding="utf-8") as f:
    json.dump({"actions": actions, "entities": {k: [a["name"] for a in v] for k, v in entities.items()}}, f, ensure_ascii=False, indent=1)
print("saved /tmp/apibaseinfo_inventory.json")

# List all entities with their SPs for the matrix
for e in sorted(entities):
    acts = entities[e]
    sps = sorted({s for a in acts for s in a["sps"]})
    print(f"{e}: {len(acts)} actions | SPs: {', '.join(sps) if sps else '(direct?)'}")
