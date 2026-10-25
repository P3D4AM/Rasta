"use client";

import { useMemo, useState } from "react";
import { Plus, Pencil, Trash2, ShieldCheck } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { Checkbox } from "@/components/ui/checkbox";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { useList, api } from "@/hooks/use-list";
import { MODULES, ACTIONS, type ModuleKey } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Permission = {
  module: string; canView: boolean; canCreate: boolean; canEdit: boolean; canDelete: boolean;
};

type Role = {
  id: string; name: string; description: string | null;
  permissions: Permission[];
  _count: { users: number };
};

const EDITABLE_MODULES: ModuleKey[] = [
  "dashboard", "companies", "contacts", "deals", "activities", "tasks",
  "products", "quotations", "orders", "reports", "users", "roles",
  "fund", "banking", "payments", "settings",
];

type PermRow = { module: string; canView: boolean; canCreate: boolean; canEdit: boolean; canDelete: boolean };

export default function RolesPage() {
  const { toast } = useToast();
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState<{ id: string; name: string; description: string; permissions: PermRow[] }>({
    id: "", name: "", description: "", permissions: [],
  });
  const [saving, setSaving] = useState(false);

  const { rows, total, loading, refresh } = useList<Role>("/api/roles");

  function openDialog(r?: Role) {
    setForm(
      r
        ? {
            id: r.id,
            name: r.name,
            description: r.description ?? "",
            permissions: r.permissions.map((p) => ({ ...p })),
          }
        : { id: "", name: "", description: "", permissions: [] }
    );
    setDialogOpen(true);
  }

  function getPerm(module: string): PermRow | undefined {
    return form.permissions.find((p) => p.module === module);
  }

  function togglePerm(module: string, key: keyof PermRow) {
    const perms = [...form.permissions];
    const idx = perms.findIndex((p) => p.module === module);
    if (idx === -1) {
      perms.push({ module, canView: false, canCreate: false, canEdit: false, canDelete: false, [key]: true } as PermRow);
    } else {
      perms[idx] = { ...perms[idx], [key]: !perms[idx][key] };
    }
    setForm({ ...form, permissions: perms });
  }

  function toggleModuleAll(module: string, value: boolean) {
    const perms = [...form.permissions];
    const idx = perms.findIndex((p) => p.module === module);
    const row: PermRow = { module, canView: value, canCreate: value, canEdit: value, canDelete: value };
    if (idx === -1) perms.push(row);
    else perms[idx] = row;
    setForm({ ...form, permissions: perms });
  }

  async function save() {
    if (!form.name.trim()) return toast({ title: "نام نقش الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const method = form.id ? "PUT" : "POST";
      const path = form.id ? `/api/roles/${form.id}` : "/api/roles";
      await api(path, { method, body: form });
      toast({ title: form.id ? "نقش ویرایش شد." : "نقش ایجاد شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(r: Role) {
    if (!confirm(`حذف نقش «${r.name}»؟`)) return;
    try {
      await api(`/api/roles/${r.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  return (
    <div>
      <PageHeader
        title="نقش‌ها و دسترسی‌ها"
        subtitle={`${toPersianDigits(total)} نقش تعریف‌شده`}
        actions={
          <Button onClick={() => openDialog()}>
            <Plus className="w-4 h-4 me-1" />
            نقش جدید
          </Button>
        }
      />

      <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-4">
        {loading ? (
          <p className="text-sm text-muted-foreground">در حال بارگذاری…</p>
        ) : (
          rows.map((r) => (
            <div key={r.id} className="rounded-xl border bg-card p-4 hover:shadow-md transition-shadow">
              <div className="flex items-start justify-between">
                <div className="flex items-center gap-2">
                  <div className="w-9 h-9 rounded-lg bg-primary/10 text-primary flex items-center justify-center">
                    <ShieldCheck className="w-4 h-4" />
                  </div>
                  <div>
                    <p className="font-bold">{r.name}</p>
                    <p className="text-[11px] text-muted-foreground">{toPersianDigits(r._count.users)} کاربر</p>
                  </div>
                </div>
                <div className="flex gap-1">
                  <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => openDialog(r)} aria-label="ویرایش">
                    <Pencil className="w-3.5 h-3.5" />
                  </Button>
                  <Button variant="ghost" size="icon" className="h-7 w-7 text-destructive hover:text-destructive" onClick={() => remove(r)} aria-label="حذف">
                    <Trash2 className="w-3.5 h-3.5" />
                  </Button>
                </div>
              </div>
              {r.description && <p className="text-xs text-muted-foreground mt-3">{r.description}</p>}
              <div className="flex flex-wrap gap-1 mt-3">
                {r.permissions.filter((p) => p.canView).map((p) => (
                  <span key={p.module} className="text-[10px] bg-muted px-2 py-0.5 rounded-full">
                    {MODULES[p.module as ModuleKey]?.label ?? p.module}
                  </span>
                ))}
              </div>
            </div>
          ))
        )}
      </div>

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-2xl max-h-[92vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle>{form.id ? "ویرایش نقش" : "نقش جدید"}</DialogTitle>
          </DialogHeader>

          <div className="grid grid-cols-2 gap-3">
            <div className="space-y-1.5">
              <Label>نام نقش *</Label>
              <Input value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>توضیح</Label>
              <Input value={form.description} onChange={(e) => setForm({ ...form, description: e.target.value })} />
            </div>
          </div>

          <div className="rounded-xl border overflow-hidden">
            <table className="w-full text-xs">
              <thead className="bg-muted font-bold">
                <tr>
                  <th className="p-2 text-start">ماژول</th>
                  <th className="p-2 w-16">مشاهده</th>
                  <th className="p-2 w-16">ایجاد</th>
                  <th className="p-2 w-16">ویرایش</th>
                  <th className="p-2 w-16">حذف</th>
                  <th className="p-2 w-16">همه</th>
                </tr>
              </thead>
              <tbody>
                {EDITABLE_MODULES.map((m) => {
                  const perm = getPerm(m);
                  return (
                    <tr key={m} className="border-t">
                      <td className="p-2 font-medium">{MODULES[m].label}</td>
                      {(["canView", "canCreate", "canEdit", "canDelete"] as const).map((key) => (
                        <td key={key} className="p-2 text-center">
                          <Checkbox
                            checked={Boolean(perm?.[key])}
                            onCheckedChange={() => togglePerm(m, key)}
                            aria-label={`${MODULES[m].label} — ${ACTIONS[key.replace("can", "").toLowerCase() as never]}`}
                          />
                        </td>
                      ))}
                      <td className="p-2 text-center">
                        <button
                          className="text-[10px] text-primary hover:underline"
                          onClick={() => toggleModuleAll(m, !perm?.canView)}
                        >
                          {perm?.canView ? "هیچ" : "همه"}
                        </button>
                      </td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>

          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
