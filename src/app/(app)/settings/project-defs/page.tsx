"use client";

/**
 * اطلاعات پایه پروژه‌ها — بازسازی فرم‌های تعریف خود CRMIdeal (منوی frmMain/actDefine*):
 * عنوان‌ها / سرفصل‌ها / گروه / مقطع / اولویت / دسته‌بندی / مدل‌های پیشرفت (+وضعیت‌ها)
 */

import { useCallback, useEffect, useMemo, useState } from "react";
import { Plus, Pencil, Trash2 } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Checkbox } from "@/components/ui/checkbox";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from "@/components/ui/dialog";
import { PageHeader } from "@/components/rasta/page-header";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { fetchMe } from "@/lib/client-me";
import { toPersianDigits } from "@/lib/jalali";

type Row = Record<string, unknown> & { id: string };

type DefState = {
  titles: Row[]; titleGroups: Row[]; groups: Row[]; grades: Row[]; priorities: Row[];
  categories: Row[]; statusGroups: Row[]; statuses: Row[];
};

const EMPTY: DefState = { titles: [], titleGroups: [], groups: [], grades: [], priorities: [], categories: [], statusGroups: [], statuses: [] };

export default function ProjectDefsPage() {
  const { toast } = useToast();
  const [defs, setDefs] = useState<DefState>(EMPTY);
  const [me, setMe] = useState<{ isAdmin: boolean; permissions: Record<string, string[]> } | null>(null);
  const [dialog, setDialog] = useState<{ entity: string; row: Row | null } | null>(null);
  const [form, setForm] = useState<Record<string, unknown>>({});
  const [saving, setSaving] = useState(false);

  const ENTITIES = ["titles", "titleGroups", "groups", "grades", "priorities", "categories", "statusGroups", "statuses"] as const;

  const load = useCallback(async () => {
    try {
      const results = await Promise.all(ENTITIES.map((e) => api<{ rows: Row[] }>(`/api/project-defs/${e}`)));
      const next = { ...EMPTY };
      ENTITIES.forEach((e, i) => { (next as Record<string, Row[]>)[e] = results[i].rows; });
      setDefs(next);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }, [toast]);

  useEffect(() => {
    load();
    fetchMe().then((m) => { if (m) setMe(m); });
  }, [load]);

  const has = useCallback((act: string) => !!me && (me.isAdmin || (me.permissions["frmMain"] ?? []).includes(act)), [me]);

  function openDialog(entity: string, row: Row | null) {
    setDialog({ entity, row });
    const base: Record<string, unknown> = {};
    const keysByEntity: Record<string, string[]> = {
      titles: ["title", "postFix", "remindDay", "description", "titleGroupId", "statusGroupId", "gradeId", "priorityId", "activeNumRWithTitle", "foCmpCanSee", "isTicket"],
      titleGroups: ["name", "description", "color", "agreementActive", "agreementDesc", "subjectDefaultContext", "ticketAllowInCurrentCount", "orderView"],
      groups: ["name", "description", "orderView"],
      grades: ["name", "description", "orderView"],
      priorities: ["name", "color", "description", "orderView"],
      categories: ["name", "parentId", "statusGroupId", "orderView"],
      statusGroups: ["name", "description", "orderView", "isActive"],
      statuses: ["groupId", "name", "progressPercent", "orderView", "prjFinished", "addPrjActive", "issuePreOrderActive", "issueOrderActive", "noCnvsDup", "isDefault", "isActive", "color"],
    };
    for (const k of keysByEntity[entity] ?? []) {
      const v = row?.[k];
      base[k] = typeof v === "boolean" ? v : v == null ? "" : v;
    }
    setForm(base);
  }

  async function save() {
    if (!dialog) return;
    setSaving(true);
    try {
      const method = dialog.row ? "PUT" : "POST";
      const path = dialog.row
        ? `/api/project-defs/${dialog.entity}/${dialog.row.id}`
        : `/api/project-defs/${dialog.entity}`;
      await api(path, { method, body: form });
      toast({ title: dialog.row ? "ویرایش شد." : "ثبت شد." });
      setDialog(null);
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(entity: string, row: Row) {
    const name = String(row.title ?? row.name ?? "");
    if (!confirm(`حذف «${name}»؟`)) return;
    try {
      await api(`/api/project-defs/${entity}/${row.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const PermRow = ({ entity, row, act }: { entity: string; row: Row; act: string }) => (
    <div className="flex items-center gap-1">
      {has(act) && (
        <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => openDialog(entity, row)} title="ویرایش">
          <Pencil className="w-3.5 h-3.5" />
        </Button>
      )}
      {has(act) && (
        <Button variant="ghost" size="icon" className="h-7 w-7 text-destructive hover:text-destructive" onClick={() => remove(entity, row)} title="حذف">
          <Trash2 className="w-3.5 h-3.5" />
        </Button>
      )}
    </div>
  );

  const AddBtn = ({ entity, act, label }: { entity: string; act: string; label: string }) =>
    has(act) ? (
      <Button size="sm" className="h-8" onClick={() => openDialog(entity, null)}>
        <Plus className="w-4 h-4 me-1" />{label}
      </Button>
    ) : null;

  const name = (r: Row) => String(r.title ?? r.name ?? "");

  return (
    <div>
      <PageHeader title="اطلاعات پایه پروژه ها" subtitle="تعاریف عنوان/سرفصل/گروه/مقطع/اولویت/دسته‌بندی و مدل‌های پیشرفت — مطابق فرم‌های تعریف CRMIdeal" />
      <Tabs defaultValue="titles" dir="rtl">
        <TabsList className="flex-wrap h-auto">
          <TabsTrigger value="titles">عنوان‌های پیش‌فرض</TabsTrigger>
          <TabsTrigger value="titleGroups">سرفصل‌ها</TabsTrigger>
          <TabsTrigger value="groups">گروه‌ها</TabsTrigger>
          <TabsTrigger value="grades">مقطع‌ها</TabsTrigger>
          <TabsTrigger value="priorities">اولویت‌ها</TabsTrigger>
          <TabsTrigger value="categories">دسته‌بندی</TabsTrigger>
          <TabsTrigger value="statusGroups">مدل‌های پیشرفت</TabsTrigger>
        </TabsList>

        <TabsContent value="titles">
          <ListCard
            title={`عنوان‌های پیش‌فرض پروژه (${toPersianDigits(defs.titles.length)})`}
            add={<AddBtn entity="titles" act="actDefineProjectTitle" label="عنوان جدید" />}
            headers={["عنوان", "سرفصل", "مدل پیشرفت", "پسوند", "روز یادآوری", "شماره‌گذاری به تفکیک عنوان", "تیکت"]}
            rows={defs.titles}
            cells={(r) => [
              name(r),
              String((r.titleGroup as Row | null)?.name ?? "—"),
              String((r.statusGroup as Row | null)?.name ?? "—"),
              String(r.postFix ?? "—"),
              r.remindDay != null ? toPersianDigits(r.remindDay as number) : "—",
              r.activeNumRWithTitle ? "فعال" : "—",
              r.isTicket ? "تیکت" : "—",
            ]}
            actions={(r) => <PermRow entity="titles" row={r} act="actDefineProjectTitle" />}
          />
        </TabsContent>

        <TabsContent value="titleGroups">
          <ListCard
            title={`سرفصل‌های پروژه (${toPersianDigits(defs.titleGroups.length)})`}
            add={<AddBtn entity="titleGroups" act="actDefineProjectTitleGroup" label="سرفصل جدید" />}
            headers={["سرفصل", "رنگ", "توافق‌نامه", "سقف تیکت هم‌جریان", "ترتیب"]}
            rows={defs.titleGroups}
            cells={(r) => [
              name(r),
              r.color ? <span className="w-4 h-4 rounded-full inline-block" style={{ backgroundColor: String(r.color) }} /> : "—",
              r.agreementActive ? "دارد" : "—",
              r.ticketAllowInCurrentCount != null ? toPersianDigits(r.ticketAllowInCurrentCount as number) : "—",
              toPersianDigits((r.orderView as number) ?? 0),
            ]}
            actions={(r) => <PermRow entity="titleGroups" row={r} act="actDefineProjectTitleGroup" />}
          />
        </TabsContent>

        <TabsContent value="groups">
          <ListCard
            title={`گروه‌های پروژه (${toPersianDigits(defs.groups.length)})`}
            add={<AddBtn entity="groups" act="actDefinePrjGroup" label="گروه جدید" />}
            headers={["گروه", "توضیح", "ترتیب"]}
            rows={defs.groups}
            cells={(r) => [name(r), String(r.description ?? "—"), toPersianDigits((r.orderView as number) ?? 0)]}
            actions={(r) => <PermRow entity="groups" row={r} act="actDefinePrjGroup" />}
          />
        </TabsContent>

        <TabsContent value="grades">
          <ListCard
            title={`مقطع‌های پروژه (${toPersianDigits(defs.grades.length)})`}
            add={<AddBtn entity="grades" act="actDefinePrjGrade" label="مقطع جدید" />}
            headers={["مقطع", "توضیح", "ترتیب"]}
            rows={defs.grades}
            cells={(r) => [name(r), String(r.description ?? "—"), toPersianDigits((r.orderView as number) ?? 0)]}
            actions={(r) => <PermRow entity="grades" row={r} act="actDefinePrjGrade" />}
          />
        </TabsContent>

        <TabsContent value="priorities">
          <ListCard
            title={`اولویت‌های پروژه (${toPersianDigits(defs.priorities.length)})`}
            add={<AddBtn entity="priorities" act="actDefinePrjPriority" label="اولویت جدید" />}
            headers={["اولویت", "رنگ", "توضیح"]}
            rows={defs.priorities}
            cells={(r) => [
              name(r),
              r.color ? <span className="w-4 h-4 rounded-full inline-block" style={{ backgroundColor: String(r.color) }} /> : "—",
              String(r.description ?? "—"),
            ]}
            actions={(r) => <PermRow entity="priorities" row={r} act="actDefinePrjPriority" />}
          />
        </TabsContent>

        <TabsContent value="categories">
          <ListCard
            title={`دسته‌بندی پروژه (${toPersianDigits(defs.categories.length)})`}
            add={<AddBtn entity="categories" act="actDefinePrjCategory" label="دسته جدید" />}
            headers={["دسته", "دسته والد", "مدل پیشرفت پیش‌فرض"]}
            rows={defs.categories}
            cells={(r) => [
              name(r),
              String((r.parent as Row | null)?.name ?? "—"),
              String((r.statusGroup as Row | null)?.name ?? "—"),
            ]}
            actions={(r) => <PermRow entity="categories" row={r} act="actDefinePrjCategory" />}
          />
        </TabsContent>

        <TabsContent value="statusGroups">
          <div className="space-y-4">
            <ListCard
              title={`مدل‌های پیشرفت (${toPersianDigits(defs.statusGroups.length)})`}
              add={<AddBtn entity="statusGroups" act="actDefinecnvsStatusGroups" label="مدل جدید" />}
              headers={["مدل پیشرفت", "توضیح", "تعداد وضعیت", "فعال"]}
              rows={defs.statusGroups}
              cells={(r) => [
                name(r),
                String(r.description ?? "—"),
                toPersianDigits(((r.statuses as Row[]) ?? []).length),
                r.isActive ? "فعال" : "غیرفعال",
              ]}
              actions={(r) => <PermRow entity="statusGroups" row={r} act="actDefinecnvsStatusGroups" />}
            />
            <ListCard
              title={`وضعیت‌های مذاکره (${toPersianDigits(defs.statuses.length)})`}
              add={<AddBtn entity="statuses" act="actDefinecnvsStatus" label="وضعیت جدید" />}
              headers={["مدل", "وضعیت", "درصد", "نتیجه‌ها", "رنگ"]}
              rows={defs.statuses}
              cells={(r) => {
                const flags = [
                  r.prjFinished ? "آرشیو پروژه" : "",
                  r.addPrjActive ? "پروژه جدید" : "",
                  r.issuePreOrderActive ? "صدور پیش‌فاکتور" : "",
                  r.issueOrderActive ? "صدور فاکتور" : "",
                  r.noCnvsDup ? "مذاکره تکراری ممنوع" : "",
                  r.isDefault ? "پیش‌فرض" : "",
                ].filter(Boolean);
                return [
                  String((r.group as Row | null)?.name ?? "—"),
                  name(r),
                  `${toPersianDigits((r.progressPercent as number) ?? 0)}٪`,
                  flags.length ? flags.join(" · ") : "—",
                  r.color ? <span className="w-4 h-4 rounded-full inline-block" style={{ backgroundColor: String(r.color) }} /> : "—",
                ];
              }}
              actions={(r) => <PermRow entity="statuses" row={r} act="actDefinecnvsStatus" />}
            />
          </div>
        </TabsContent>
      </Tabs>

      <Dialog open={!!dialog} onOpenChange={(v) => !v && setDialog(null)}>
        <DialogContent className="max-w-lg max-h-[85vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle>{dialog?.row ? "ویرایش" : "درج"} — {ENTITY_LABELS[dialog?.entity ?? ""]}</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <EntityFields entity={dialog?.entity ?? ""} form={form} setForm={setForm} defs={defs} />
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialog(null)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}

const ENTITY_LABELS: Record<string, string> = {
  titles: "عنوان پیش‌فرض پروژه",
  titleGroups: "سرفصل پروژه",
  groups: "گروه پروژه",
  grades: "مقطع پروژه",
  priorities: "اولویت پروژه",
  categories: "دسته‌بندی پروژه",
  statusGroups: "مدل پیشرفت",
  statuses: "وضعیت مذاکره",
};

function EntityFields({
  entity, form, setForm, defs,
}: {
  entity: string;
  form: Record<string, unknown>;
  setForm: (f: Record<string, unknown>) => void;
  defs: DefState;
}) {
  const S = (key: string, label: string, type = "text") => (
    <div className="space-y-1.5">
      <Label>{label}</Label>
      <Input
        dir={type === "number" ? "ltr" : undefined}
        type={type}
        value={String(form[key] ?? "")}
        onChange={(e) => setForm({ ...form, [key]: type === "number" ? e.target.value : e.target.value })}
      />
    </div>
  );
  const Sel = (key: string, label: string, options: { id: string; name: string }[], allowEmpty = true) => (
    <div className="space-y-1.5">
      <Label>{label}</Label>
      <Select value={String(form[key] ?? "") || undefined} onValueChange={(v) => setForm({ ...form, [key]: v === "__EMPTY__" ? "" : v })}>
        <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
        <SelectContent>
          {allowEmpty && <SelectItem value="__EMPTY__">—</SelectItem>}
          {options.map((o) => <SelectItem key={o.id} value={o.id}>{o.name}</SelectItem>)}
        </SelectContent>
      </Select>
    </div>
  );
  const Chk = (key: string, label: string) => (
    <span className="flex items-center gap-2 pt-6">
      <Checkbox id={key} checked={Boolean(form[key])} onCheckedChange={(v) => setForm({ ...form, [key]: Boolean(v) })} />
      <Label htmlFor={key} className="cursor-pointer text-xs">{label}</Label>
    </span>
  );

  const statusOptions = defs.statusGroups.map((g) => ({ id: g.id, name: String(g.name) }));

  switch (entity) {
    case "titles":
      return (
        <>
          {S("title", "عنوان *")}
          {S("postFix", "پسوند")}
          {Sel("titleGroupId", "سرفصل", defs.titleGroups.map((g) => ({ id: g.id, name: String(g.name) })))}
          {Sel("statusGroupId", "مدل پیشرفت", statusOptions)}
          {Sel("gradeId", "مقطع", defs.grades.map((g) => ({ id: g.id, name: String(g.name) })))}
          {Sel("priorityId", "اولویت", defs.priorities.map((g) => ({ id: g.id, name: String(g.name) })))}
          {S("remindDay", "روز یادآوری از امروز", "number")}
          <div className="sm:col-span-2">{S("description", "توضیح")}</div>
          {Chk("activeNumRWithTitle", "شماره‌گذاری به تفکیک این عنوان")}
          {Chk("isTicket", "پروژه از نوع تیکت")}
        </>
      );
    case "titleGroups":
      return (
        <>
          {S("name", "سرفصل *")}
          {S("color", "رنگ (hex)")}
          <div className="sm:col-span-2">{S("ticketAllowInCurrentCount", "سقف تیکت‌های هم‌جریان مجاز", "number")}</div>
          <div className="sm:col-span-2">
            <div className="space-y-1.5">
              <Label>متن توافق‌نامه (SLA)</Label>
              <Textarea rows={3} value={String(form.agreementDesc ?? "")} onChange={(e) => setForm({ ...form, agreementDesc: e.target.value })} />
            </div>
          </div>
          <div className="sm:col-span-2">
            <div className="space-y-1.5">
              <Label>متن پیش‌فرض موضوع تیکت</Label>
              <Textarea rows={2} value={String(form.subjectDefaultContext ?? "")} onChange={(e) => setForm({ ...form, subjectDefaultContext: e.target.value })} />
            </div>
          </div>
          {Chk("agreementActive", "نمایش توافق‌نامه")}
          {S("orderView", "ترتیب نمایش", "number")}
        </>
      );
    case "groups":
    case "grades":
      return (
        <>
          {S("name", "نام *")}
          {S("orderView", "ترتیب نمایش", "number")}
          <div className="sm:col-span-2">{S("description", "توضیح")}</div>
        </>
      );
    case "priorities":
      return (
        <>
          {S("name", "اولویت *")}
          {S("color", "رنگ (hex)")}
          {S("orderView", "ترتیب نمایش", "number")}
          <div className="sm:col-span-2">{S("description", "توضیح")}</div>
        </>
      );
    case "categories":
      return (
        <>
          {S("name", "نام دسته *")}
          {Sel("parentId", "دسته والد", defs.categories.map((c) => ({ id: c.id, name: String(c.name) })))}
          {Sel("statusGroupId", "مدل پیشرفت پیش‌فرض", statusOptions)}
          {S("orderView", "ترتیب نمایش", "number")}
        </>
      );
    case "statusGroups":
      return (
        <>
          {S("name", "نام مدل پیشرفت *")}
          {S("orderView", "ترتیب نمایش", "number")}
          <div className="sm:col-span-2">{S("description", "توضیح")}</div>
          {Chk("isActive", "فعال")}
        </>
      );
    case "statuses":
      return (
        <>
          {Sel("groupId", "مدل پیشرفت *", statusOptions, false)}
          {S("name", "وضعیت *")}
          {S("progressPercent", "درصد پیشرفت (۰-۱۰۰)", "number")}
          {S("color", "رنگ (hex)")}
          {S("orderView", "ترتیب نمایش", "number")}
          <div className="sm:col-span-2 grid grid-cols-2 gap-2">
            {Chk("prjFinished", "نتیجه: آرشیو پروژه")}
            {Chk("addPrjActive", "نتیجه: پروژه جدید")}
            {Chk("issuePreOrderActive", "نتیجه: صدور پیش‌فاکتور")}
            {Chk("issueOrderActive", "نتیجه: صدور فاکتور فروش")}
            {Chk("noCnvsDup", "مذاکره تکراری ممنوع")}
            {Chk("isDefault", "وضعیت پیش‌فرض درج")}
            {Chk("isActive", "فعال")}
          </div>
          <p className="sm:col-span-2 text-[11px] text-muted-foreground">
            نتیجه‌های «پروژه جدید / صدور پیش‌فاکتور / صدور فاکتور» فقط ذخیره می‌شوند؛ اجرای خودکارشان در رستا پیاده‌سازی نشده است.
          </p>
        </>
      );
    default:
      return null;
  }
}

function ListCard({
  title, headers, rows, cells, actions, add,
}: {
  title: string;
  headers: string[];
  rows: Row[];
  cells: (r: Row) => (string | React.ReactNode)[];
  actions: (r: Row) => React.ReactNode;
  add?: React.ReactNode;
}) {
  return (
    <Card>
      <CardContent className="p-0">
        <div className="flex items-center justify-between px-4 py-3 border-b">
          <h3 className="text-sm font-bold">{title}</h3>
          {add}
        </div>
        <div className="overflow-x-auto">
          <table className="w-full text-xs">
            <thead className="bg-muted/50 text-muted-foreground">
              <tr>
                {headers.map((h) => <th key={h} className="px-3 py-2 text-start font-medium whitespace-nowrap">{h}</th>)}
                <th className="px-3 py-2 w-20" />
              </tr>
            </thead>
            <tbody>
              {rows.length === 0 ? (
                <tr><td colSpan={headers.length + 1} className="text-center py-6 text-muted-foreground">موردی ثبت نشده است.</td></tr>
              ) : (
                rows.map((r) => (
                  <tr key={r.id} className="border-t hover:bg-muted/30">
                    {cells(r).map((c, i) => <td key={i} className="px-3 py-2 whitespace-nowrap">{c ?? "—"}</td>)}
                    <td className="px-3 py-2">{actions(r)}</td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      </CardContent>
    </Card>
  );
}
