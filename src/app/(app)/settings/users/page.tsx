"use client";

import { useMemo, useState } from "react";
import { Plus, Pencil, Trash2, ShieldCheck } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import {
  Select, SelectContent, SelectItem, SelectTrigger, SelectValue,
} from "@/components/ui/select";
import { Checkbox } from "@/components/ui/checkbox";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { useList, api } from "@/hooks/use-list";
import { formatDate } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";

type User = {
  id: string; username: string; firstName: string; lastName: string;
  email: string | null; phone: string | null; isAdmin: boolean; isActive: boolean;
  role: { id: string; name: string } | null;
  lastLoginAt: string | null;
};

const emptyForm = {
  id: "", username: "", password: "", firstName: "", lastName: "",
  email: "", phone: "", roleId: "", isAdmin: false, isActive: true,
};

export default function UsersPage() {
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);
  const [roles, setRoles] = useState<{ id: string; name: string }[]>([]);

  const url = useMemo(() => `/api/users?page=${page}`, [page]);
  const { rows, total, loading, refresh } = useList<User>(url);

  async function openDialog(u?: User) {
    const res = await fetch("/api/roles?light=1");
    const data = await res.json();
    setRoles(data.rows ?? []);
    setForm(
      u
        ? {
            id: u.id, username: u.username, password: "", firstName: u.firstName,
            lastName: u.lastName, email: u.email ?? "", phone: u.phone ?? "",
            roleId: u.role?.id ?? "", isAdmin: u.isAdmin, isActive: u.isActive,
          }
        : emptyForm
    );
    setDialogOpen(true);
  }

  async function save() {
    if (!form.username.trim() || !form.firstName.trim() || !form.lastName.trim()) {
      return toast({ title: "فیلدهای الزامی را تکمیل کنید.", variant: "destructive" });
    }
    if (!form.id && form.password.length < 6) {
      return toast({ title: "رمز عبور باید حداقل ۶ کاراکتر باشد.", variant: "destructive" });
    }
    setSaving(true);
    try {
      const method = form.id ? "PUT" : "POST";
      const path = form.id ? `/api/users/${form.id}` : "/api/users";
      await api(path, { method, body: form });
      toast({ title: form.id ? "کاربر ویرایش شد." : "کاربر ایجاد شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(u: User) {
    if (!confirm(`غیرفعال‌سازی حساب «${u.firstName} ${u.lastName}»؟`)) return;
    try {
      await api(`/api/users/${u.id}`, { method: "DELETE" });
      toast({ title: "کاربر غیرفعال شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<User>[] = [
    {
      key: "name",
      header: "کاربر",
      render: (u) => (
        <div>
          <p className="font-bold">
            {u.firstName} {u.lastName}
            {u.isAdmin && (
              <span className="ms-2 text-[10px] bg-primary/10 text-primary px-1.5 py-0.5 rounded-full font-bold">مدیر سیستم</span>
            )}
          </p>
          <p className="text-xs text-muted-foreground" dir="ltr">{u.username}</p>
        </div>
      ),
    },
    {
      key: "role",
      header: "نقش",
      render: (u) => (
        u.role ? (
          <span className="flex items-center gap-1.5 text-sm">
            <ShieldCheck className="w-3.5 h-3.5 text-muted-foreground" />
            {u.role.name}
          </span>
        ) : <span className="text-muted-foreground text-xs">—</span>
      ),
    },
    { key: "email", header: "ایمیل", render: (u) => <span dir="ltr" className="text-xs text-muted-foreground">{u.email ?? "—"}</span> },
    {
      key: "lastLogin",
      header: "آخرین ورود",
      render: (u) => <span className="text-xs text-muted-foreground">{u.lastLoginAt ? formatDate(u.lastLoginAt) : "—"}</span>,
    },
    {
      key: "status",
      header: "وضعیت",
      render: (u) => (
        <span className={`text-xs font-bold ${u.isActive ? "text-emerald-600" : "text-rose-600"}`}>
          {u.isActive ? "فعال" : "غیرفعال"}
        </span>
      ),
    },
    {
      key: "actions",
      header: "",
      className: "w-24 text-end",
      render: (u) => (
        <div className="flex justify-end gap-1">
          <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openDialog(u)} aria-label="ویرایش">
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(u)} aria-label="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <PageHeader
        title="کاربران"
        subtitle={`${toPersianDigits(total)} کاربر`}
        actions={
          <Button onClick={() => openDialog()}>
            <Plus className="w-4 h-4 me-1" />
            کاربر جدید
          </Button>
        }
      />

      <DataTable columns={columns} rows={rows} loading={loading} page={page} pageSize={20} total={total} onPageChange={setPage} />

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader>
            <DialogTitle>{form.id ? "ویرایش کاربر" : "کاربر جدید"}</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5">
              <Label>نام کاربری *</Label>
              <Input dir="ltr" value={form.username} onChange={(e) => setForm({ ...form, username: e.target.value })} disabled={!!form.id} />
            </div>
            <div className="space-y-1.5">
              <Label>{form.id ? "رمز عبور جدید (اختیاری)" : "رمز عبور *"}</Label>
              <Input dir="ltr" type="password" value={form.password} onChange={(e) => setForm({ ...form, password: e.target.value })} placeholder="حداقل ۶ کاراکتر" />
            </div>
            <div className="space-y-1.5">
              <Label>نام *</Label>
              <Input value={form.firstName} onChange={(e) => setForm({ ...form, firstName: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>نام خانوادگی *</Label>
              <Input value={form.lastName} onChange={(e) => setForm({ ...form, lastName: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>ایمیل</Label>
              <Input dir="ltr" type="email" value={form.email} onChange={(e) => setForm({ ...form, email: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>موبایل</Label>
              <Input dir="ltr" value={form.phone} onChange={(e) => setForm({ ...form, phone: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>نقش</Label>
              <Select value={form.roleId} onValueChange={(v) => setForm({ ...form, roleId: v })}>
                <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                <SelectContent>
                  {roles.map((r) => (
                    <SelectItem key={r.id} value={r.id}>{r.name}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="flex items-center gap-4 pt-6">
              <span className="flex items-center gap-2">
                <Checkbox id="isAdmin" checked={form.isAdmin} onCheckedChange={(v) => setForm({ ...form, isAdmin: Boolean(v) })} />
                <Label htmlFor="isAdmin" className="cursor-pointer">مدیر سیستم</Label>
              </span>
              <span className="flex items-center gap-2">
                <Checkbox id="isActive" checked={form.isActive} onCheckedChange={(v) => setForm({ ...form, isActive: Boolean(v) })} />
                <Label htmlFor="isActive" className="cursor-pointer">فعال</Label>
              </span>
            </div>
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
