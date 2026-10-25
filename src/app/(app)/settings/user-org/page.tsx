"use client";

/** اطلاعات پایه کاربران — سمت‌های سازمانی (درخت) / گروه‌های کاربری / دپارتمان‌ها (frmMain/actDefine*) */

import { useCallback, useEffect, useState } from "react";
import { Plus, Pencil, Trash2 } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from "@/components/ui/dialog";
import { PageHeader } from "@/components/rasta/page-header";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { fetchMe } from "@/lib/client-me";
import { toPersianDigits } from "@/lib/jalali";

type Pos = { id: string; name: string; code: string | null; manager: string | null; parentId: string | null; parent: { name: string } | null; _count: { users: number; children: number } };
type Simple = { id: string; name: string; description: string | null; _count?: { users: number } };

export default function UserOrgPage() {
  const { toast } = useToast();
  const [positions, setPositions] = useState<Pos[]>([]);
  const [groups, setGroups] = useState<Simple[]>([]);
  const [departments, setDepartments] = useState<Simple[]>([]);
  const [me, setMe] = useState<{ isAdmin: boolean; permissions: Record<string, string[]> } | null>(null);
  const [dialog, setDialog] = useState<{ entity: "positions" | "groups" | "departments"; row: Pos | Simple | null } | null>(null);
  const [form, setForm] = useState<Record<string, string>>({});
  const [saving, setSaving] = useState(false);

  const has = useCallback((act: string) => !!me && (me.isAdmin || (me.permissions["frmMain"] ?? []).includes(act)), [me]);

  const load = useCallback(async () => {
    try {
      const [p, g, d] = await Promise.all([
        api<{ rows: Pos[] }>("/api/user-org/positions"),
        api<{ rows: Simple[] }>("/api/user-org/groups"),
        api<{ rows: Simple[] }>("/api/user-org/departments"),
      ]);
      setPositions(p.rows);
      setGroups(g.rows);
      setDepartments(d.rows);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }, [toast]);

  useEffect(() => {
    load();
    fetchMe().then((m) => { if (m) setMe(m); });
  }, [load]);

  function open(entity: "positions" | "groups" | "departments", row: Pos | Simple | null) {
    setForm({
      name: row?.name ?? "",
      code: (row as Pos)?.code ?? "",
      manager: (row as Pos)?.manager ?? "",
      parentId: (row as Pos | null)?.parentId ?? "",
      description: (row as Simple | null)?.description ?? "",
    });
    setDialog({ entity, row });
  }

  async function save() {
    if (!dialog) return;
    if (!form.name.trim()) return toast({ title: "نام الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const body = dialog.entity === "positions"
        ? { name: form.name, code: form.code || null, manager: form.manager || null, parentId: form.parentId || null }
        : { name: form.name, description: form.description || null };
      if (dialog.row) await api(`/api/user-org/${dialog.entity}/${dialog.row.id}`, { method: "PUT", body });
      else await api(`/api/user-org/${dialog.entity}`, { method: "POST", body });
      toast({ title: dialog.row ? "ویرایش شد." : "ثبت شد." });
      setDialog(null);
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(entity: "positions" | "groups" | "departments", id: string) {
    if (!confirm("حذف این مورد؟")) return;
    try {
      await api(`/api/user-org/${entity}/${id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const Actions = ({ entity, row, act }: { entity: "positions" | "groups" | "departments"; row: Pos | Simple; act: string }) =>
    has(act) ? (
      <div className="flex justify-end gap-1">
        <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => open(entity, row)}><Pencil className="w-3.5 h-3.5" /></Button>
        <Button variant="ghost" size="icon" className="h-7 w-7 text-destructive hover:text-destructive" onClick={() => remove(entity, row.id)}><Trash2 className="w-3.5 h-3.5" /></Button>
      </div>
    ) : null;

  // سمت‌ها به شکل درخت (گروه‌بندی بر اساس والد)
  const roots = positions.filter((p) => !p.parentId);
  const childRows = (parentId: string) => positions.filter((p) => p.parentId === parentId);
  const PosRow = (p: Pos, depth: number) => (
    <div key={p.id}>
      <div className={`flex items-center justify-between gap-2 px-3 py-2 border-b last:border-0 hover:bg-muted/30 ${depth ? "ms-6 border-muted" : ""}`}>
        <div className="text-xs">
          <span className="font-medium">{p.name}</span>
          {p.code && <code className="ms-2 text-[10px] text-muted-foreground" dir="ltr">{p.code}</code>}
          {p.manager && <span className="ms-2 text-[10px] text-muted-foreground">مدیر: {p.manager}</span>}
          <span className="ms-2 text-[10px] text-muted-foreground">({toPersianDigits(p._count.users)} کاربر)</span>
        </div>
        <Actions entity="positions" row={p} act="actDefineUserPositions" />
      </div>
      {childRows(p.id).map((c) => PosRow(c, depth + 1))}
    </div>
  );

  return (
    <div>
      <PageHeader title="اطلاعات پایه کاربران" subtitle="سمت‌های سازمانی، گروه‌های کاربری و دپارتمان‌ها — مطابق UserPositions/UserGroups/UserDepartments خود CRMIdeal" />
      <Tabs defaultValue="positions" dir="rtl">
        <TabsList className="mb-4">
          <TabsTrigger value="positions">سمت‌های سازمانی</TabsTrigger>
          <TabsTrigger value="groups">گروه‌های کاربری</TabsTrigger>
          <TabsTrigger value="departments">دپارتمان‌ها</TabsTrigger>
        </TabsList>

        <TabsContent value="positions">
          <Card>
            <CardContent className="p-0">
              <div className="flex items-center justify-between px-4 py-3 border-b">
                <h3 className="text-sm font-bold">درخت سمت‌های سازمانی ({toPersianDigits(positions.length)})</h3>
                {has("actDefineUserPositions") && (
                  <Button size="sm" className="h-8" onClick={() => open("positions", null)}><Plus className="w-4 h-4 me-1" />سمت جدید</Button>
                )}
              </div>
              {positions.length === 0 ? (
                <p className="text-xs text-muted-foreground text-center py-6">سمتی ثبت نشده است.</p>
              ) : (
                roots.map((p) => PosRow(p, 0))
              )}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="groups">
          <SimpleList
            title={`گروه‌های کاربری (${toPersianDigits(groups.length)})`}
            rows={groups}
            addable={has("actDefineUserGroups")}
            onAdd={() => open("groups", null)}
            actions={(r) => <Actions entity="groups" row={r} act="actDefineUserGroups" />}
          />
        </TabsContent>

        <TabsContent value="departments">
          <SimpleList
            title={`دپارتمان‌ها (${toPersianDigits(departments.length)})`}
            rows={departments}
            addable={has("actDefineDepartments")}
            onAdd={() => open("departments", null)}
            actions={(r) => <Actions entity="departments" row={r} act="actDefineDepartments" />}
          />
        </TabsContent>
      </Tabs>

      <Dialog open={!!dialog} onOpenChange={(v) => !v && setDialog(null)}>
        <DialogContent className="max-w-md">
          <DialogHeader>
            <DialogTitle>{dialog?.row ? "ویرایش" : "درج"} — {dialog?.entity === "positions" ? "سمت سازمانی" : dialog?.entity === "groups" ? "گروه کاربری" : "دپارتمان"}</DialogTitle>
          </DialogHeader>
          <div className="space-y-3">
            <div className="space-y-1.5">
              <Label>نام *</Label>
              <Input value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
            </div>
            {dialog?.entity === "positions" && (
              <>
                <div className="space-y-1.5">
                  <Label>کد سمت</Label>
                  <Input dir="ltr" value={form.code} onChange={(e) => setForm({ ...form, code: e.target.value })} />
                </div>
                <div className="space-y-1.5">
                  <Label>مدیر سمت</Label>
                  <Input value={form.manager} onChange={(e) => setForm({ ...form, manager: e.target.value })} />
                </div>
                <div className="space-y-1.5">
                  <Label>سمت والد</Label>
                  <Select value={form.parentId || undefined} onValueChange={(v) => setForm({ ...form, parentId: v === "__E__" ? "" : v })}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      <SelectItem value="__E__">— (ریشه)</SelectItem>
                      {positions.filter((p) => p.id !== dialog.row?.id).map((p) => <SelectItem key={p.id} value={p.id}>{p.name}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </div>
              </>
            )}
            {dialog?.entity !== "positions" && (
              <div className="space-y-1.5">
                <Label>توضیح</Label>
                <Input value={form.description} onChange={(e) => setForm({ ...form, description: e.target.value })} />
              </div>
            )}
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

function SimpleList({
  title, rows, addable, onAdd, actions,
}: {
  title: string;
  rows: Simple[];
  addable: boolean;
  onAdd: () => void;
  actions: (r: Simple) => React.ReactNode;
}) {
  return (
    <Card>
      <CardContent className="p-0">
        <div className="flex items-center justify-between px-4 py-3 border-b">
          <h3 className="text-sm font-bold">{title}</h3>
          {addable && <Button size="sm" className="h-8" onClick={onAdd}><Plus className="w-4 h-4 me-1" />درج</Button>}
        </div>
        {rows.length === 0 ? (
          <p className="text-xs text-muted-foreground text-center py-6">موردی ثبت نشده است.</p>
        ) : (
          rows.map((r) => (
            <div key={r.id} className="flex items-center justify-between gap-2 px-4 py-2.5 border-b last:border-0 hover:bg-muted/30">
              <div className="text-xs">
                <span className="font-medium">{r.name}</span>
                {r.description && <span className="ms-2 text-muted-foreground">{r.description}</span>}
                {r._count != null && <span className="ms-2 text-[10px] text-muted-foreground">({toPersianDigits(r._count.users)} کاربر)</span>}
              </div>
              {actions(r)}
            </div>
          ))
        )}
      </CardContent>
    </Card>
  );
}
