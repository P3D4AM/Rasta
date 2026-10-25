"use client";

import { useMemo, useState } from "react";
import { Search, Plus, Pencil, Trash2, UserRound, Building2 } from "lucide-react";
import { useRouter } from "next/navigation";
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
import { toPersianDigits } from "@/lib/jalali";

type Contact = {
  id: string; firstName: string; lastName: string; jobTitle: string | null;
  mobile: string | null; phone: string | null; email: string | null; isPrimary: boolean;
  company: { id: string; name: string };
};

const emptyForm = {
  id: "", companyId: "", firstName: "", lastName: "", jobTitle: "",
  phone: "", mobile: "", email: "", isPrimary: false, note: "",
};

export default function ContactsPage() {
  const router = useRouter();
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);
  const [companies, setCompanies] = useState<{ id: string; name: string }[]>([]);

  const url = useMemo(
    () => `/api/contacts?page=${page}&search=${encodeURIComponent(search)}`,
    [page, search]
  );
  const { rows, total, loading, refresh } = useList<Contact>(url);

  async function openDialog(c?: Contact) {
    const res = await fetch("/api/companies?pageSize=200");
    const data = await res.json();
    setCompanies(data.rows ?? []);
    if (c) {
      setForm({
        id: c.id, companyId: c.company.id, firstName: c.firstName, lastName: c.lastName,
        jobTitle: c.jobTitle ?? "", phone: c.phone ?? "", mobile: c.mobile ?? "",
        email: c.email ?? "", isPrimary: c.isPrimary, note: "",
      });
    } else {
      setForm(emptyForm);
    }
    setDialogOpen(true);
  }

  async function save() {
    if (!form.companyId) return toast({ title: "انتخاب شرکت الزامی است.", variant: "destructive" });
    if (!form.firstName.trim() || !form.lastName.trim())
      return toast({ title: "نام و نام خانوادگی الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const method = form.id ? "PUT" : "POST";
      const path = form.id ? `/api/contacts/${form.id}` : "/api/contacts";
      await api(path, { method, body: form });
      toast({ title: form.id ? "اطلاعات ویرایش شد." : "فرد جدید ثبت شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(c: Contact) {
    if (!confirm(`حذف «${c.firstName} ${c.lastName}»؟`)) return;
    try {
      await api(`/api/contacts/${c.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Contact>[] = [
    {
      key: "name",
      header: "نام",
      render: (c) => (
        <div className="flex items-center gap-2.5">
          <div className="w-9 h-9 rounded-full bg-secondary flex items-center justify-center shrink-0 text-xs font-bold">
            {c.firstName[0] ?? ""}{c.lastName[0] ?? ""}
          </div>
          <div>
            <p className="font-bold">{c.firstName} {c.lastName}</p>
            <p className="text-xs text-muted-foreground">{c.jobTitle ?? "—"}</p>
          </div>
        </div>
      ),
    },
    {
      key: "company",
      header: "شرکت",
      render: (c) => (
        <span className="flex items-center gap-1.5 text-sm">
          <Building2 className="w-3.5 h-3.5 text-muted-foreground" />
          {c.company.name}
        </span>
      ),
    },
    { key: "mobile", header: "موبایل", render: (c) => <span dir="ltr" className="text-muted-foreground">{toPersianDigits(c.mobile ?? "—")}</span> },
    { key: "email", header: "ایمیل", render: (c) => <span dir="ltr" className="text-muted-foreground text-xs">{c.email ?? "—"}</span> },
    {
      key: "actions",
      header: "",
      className: "w-24 text-end",
      render: (c) => (
        <div className="flex justify-end gap-1" onClick={(e) => e.stopPropagation()}>
          <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openDialog(c)} aria-label="ویرایش">
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(c)} aria-label="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <PageHeader
        title="افراد"
        subtitle={`${toPersianDigits(total)} مخاطب ثبت‌شده`}
        actions={
          <Button onClick={() => openDialog()}>
            <Plus className="w-4 h-4 me-1" />
            مخاطب جدید
          </Button>
        }
      />

      <form
        className="mb-4"
        onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}
      >
        <div className="relative max-w-md">
          <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
          <Input
            className="ps-9"
            placeholder="جستجوی نام، موبایل، ایمیل یا شرکت…"
            value={searchText}
            onChange={(e) => setSearchText(e.target.value)}
          />
        </div>
      </form>

      <DataTable
        columns={columns}
        rows={rows}
        loading={loading}
        page={page}
        pageSize={20}
        total={total}
        onPageChange={setPage}
        onRowClick={(c) => router.push(`/companies/${c.company.id}`)}
      />

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-xl">
          <DialogHeader>
            <DialogTitle>{form.id ? "ویرایش مخاطب" : "مخاطب جدید"}</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5">
              <Label>شرکت *</Label>
              <Select value={form.companyId} onValueChange={(v) => setForm({ ...form, companyId: v })}>
                <SelectTrigger><SelectValue placeholder="انتخاب شرکت" /></SelectTrigger>
                <SelectContent>
                  {companies.map((c) => (
                    <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>سمت</Label>
              <Input value={form.jobTitle} onChange={(e) => setForm({ ...form, jobTitle: e.target.value })} placeholder="مثلاً مدیر خرید" />
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
              <Label>موبایل</Label>
              <Input dir="ltr" value={form.mobile} onChange={(e) => setForm({ ...form, mobile: e.target.value })} placeholder="0912-0000000" />
            </div>
            <div className="space-y-1.5">
              <Label>تلفن</Label>
              <Input dir="ltr" value={form.phone} onChange={(e) => setForm({ ...form, phone: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>ایمیل</Label>
              <Input dir="ltr" type="email" value={form.email} onChange={(e) => setForm({ ...form, email: e.target.value })} />
            </div>
            <div className="flex items-center gap-2 pt-6">
              <Checkbox
                id="isPrimary"
                checked={form.isPrimary}
                onCheckedChange={(v) => setForm({ ...form, isPrimary: Boolean(v) })}
              />
              <Label htmlFor="isPrimary" className="cursor-pointer">مخاطب اصلی</Label>
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>
              {saving ? "در حال ذخیره…" : "ذخیره"}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
