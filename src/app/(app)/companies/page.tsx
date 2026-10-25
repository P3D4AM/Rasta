"use client";

import { useMemo, useState } from "react";
import { useRouter } from "next/navigation";
import { Building2, Plus, Search, Pencil, Trash2, Users, Target } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import {
  Select, SelectContent, SelectItem, SelectTrigger, SelectValue,
} from "@/components/ui/select";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { StatusBadge } from "@/components/rasta/status-badge";
import { useList, api } from "@/hooks/use-list";
import { formatDate } from "@/lib/format";
import { COMPANY_TYPES, COMPANY_TYPE_LABELS } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Company = {
  id: string; name: string; type: string; city: string | null;
  phone: string | null; email: string | null; status: string;
  createdAt: string;
  _count?: { contacts: number; deals: number; orders: number };
};

const emptyForm = {
  id: "", name: "", nameEn: "", type: "CUSTOMER", industry: "",
  taxId: "", econCode: "", phone: "", email: "", website: "",
  province: "", city: "", address: "", description: "",
};

export default function CompaniesPage() {
  const router = useRouter();
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [search, setSearch] = useState("");
  const [searchText, setSearchText] = useState("");
  const [typeFilter, setTypeFilter] = useState("ALL");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);

  const url = useMemo(
    () => `/api/companies?page=${page}&search=${encodeURIComponent(search)}&type=${typeFilter}`,
    [page, search, typeFilter]
  );
  const { rows, total, loading, refresh } = useList<Company>(url);

  function openCreate() {
    setForm(emptyForm);
    setDialogOpen(true);
  }

  function openEdit(c: Company) {
    api<Record<string, unknown>>(`/api/companies/${c.id}`)
      .then((d) =>
        setForm({
          id: d.id as string,
          name: (d.name as string) ?? "",
          nameEn: (d.nameEn as string) ?? "",
          type: (d.type as string) ?? "CUSTOMER",
          industry: (d.industry as string) ?? "",
          taxId: (d.taxId as string) ?? "",
          econCode: (d.econCode as string) ?? "",
          phone: (d.phone as string) ?? "",
          email: (d.email as string) ?? "",
          website: (d.website as string) ?? "",
          province: (d.province as string) ?? "",
          city: (d.city as string) ?? "",
          address: (d.address as string) ?? "",
          description: (d.description as string) ?? "",
        })
      )
      .then(() => setDialogOpen(true));
  }

  async function save() {
    if (!form.name.trim()) {
      toast({ title: "نام شرکت الزامی است.", variant: "destructive" });
      return;
    }
    setSaving(true);
    try {
      if (form.id) {
        await api(`/api/companies/${form.id}`, { method: "PUT", body: form });
        toast({ title: "شرکت ویرایش شد." });
      } else {
        await api("/api/companies", { method: "POST", body: form });
        toast({ title: "شرکت جدید ثبت شد." });
      }
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(c: Company) {
    if (!confirm(`حذف «${c.name}»؟`)) return;
    try {
      await api(`/api/companies/${c.id}`, { method: "DELETE" });
      toast({ title: "شرکت حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Company>[] = [
    {
      key: "name",
      header: "نام شرکت",
      render: (c) => (
        <div className="flex items-center gap-2.5">
          <div className="w-9 h-9 rounded-lg bg-primary/10 text-primary flex items-center justify-center shrink-0">
            <Building2 className="w-4 h-4" />
          </div>
          <div className="min-w-0">
            <p className="font-bold truncate">{c.name}</p>
            {c.city && <p className="text-xs text-muted-foreground">{c.city}</p>}
          </div>
        </div>
      ),
    },
    {
      key: "type",
      header: "نوع",
      render: (c) => <StatusBadge value={c.type} label={COMPANY_TYPE_LABELS[c.type] ?? c.type} />,
    },
    { key: "phone", header: "تلفن", render: (c) => <span dir="ltr" className="text-muted-foreground">{toPersianDigits(c.phone ?? "—")}</span> },
    {
      key: "counts",
      header: "افراد / فرصت",
      render: (c) => (
        <div className="flex gap-3 text-xs text-muted-foreground">
          <span className="flex items-center gap-1"><Users className="w-3.5 h-3.5" />{toPersianDigits(c._count?.contacts ?? 0)}</span>
          <span className="flex items-center gap-1"><Target className="w-3.5 h-3.5" />{toPersianDigits(c._count?.deals ?? 0)}</span>
        </div>
      ),
    },
    { key: "createdAt", header: "تاریخ ثبت", render: (c) => <span className="text-muted-foreground text-xs">{formatDate(c.createdAt)}</span> },
    {
      key: "actions",
      header: "",
      className: "w-24 text-end",
      render: (c) => (
        <div className="flex justify-end gap-1" onClick={(e) => e.stopPropagation()}>
          <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openEdit(c)} aria-label="ویرایش">
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
        title="مشتریان"
        subtitle={`${toPersianDigits(total)} شرکت ثبت‌شده`}
        actions={
          <Button onClick={openCreate}>
            <Plus className="w-4 h-4 me-1" />
            شرکت جدید
          </Button>
        }
      />

      <div className="flex flex-col sm:flex-row gap-2 mb-4">
        <form
          className="flex-1"
          onSubmit={(e) => {
            e.preventDefault();
            setPage(1);
            setSearch(searchText);
          }}
        >
          <div className="relative">
            <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
            <Input
              className="ps-9"
              placeholder="جستجوی نام، تلفن، ایمیل، شناسه ملی یا شهر…"
              value={searchText}
              onChange={(e) => setSearchText(e.target.value)}
            />
          </div>
        </form>
        <Select value={typeFilter} onValueChange={(v) => { setTypeFilter(v); setPage(1); }}>
          <SelectTrigger className="w-full sm:w-44">
            <SelectValue placeholder="همه انواع" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="ALL">همه انواع</SelectItem>
            {COMPANY_TYPES.map((t) => (
              <SelectItem key={t} value={t}>{COMPANY_TYPE_LABELS[t]}</SelectItem>
            ))}
          </SelectContent>
        </Select>
      </div>

      <DataTable
        columns={columns}
        rows={rows}
        loading={loading}
        page={page}
        pageSize={20}
        total={total}
        onPageChange={setPage}
        onRowClick={(c) => router.push(`/companies/${c.id}`)}
        emptyText="شرکتی یافت نشد. با دکمه «شرکت جدید» اولین مشتری را ثبت کنید."
      />

      <CompanyDialog
        open={dialogOpen}
        onOpenChange={setDialogOpen}
        form={form}
        setForm={setForm}
        onSave={save}
        saving={saving}
      />
    </div>
  );
}

export function CompanyDialog({
  open, onOpenChange, form, setForm, onSave, saving,
}: {
  open: boolean;
  onOpenChange: (o: boolean) => void;
  form: typeof emptyForm;
  setForm: (f: typeof emptyForm) => void;
  onSave: () => void;
  saving: boolean;
}) {
  const set = (k: keyof typeof emptyForm) => (v: string) => setForm({ ...form, [k]: v });

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
        <DialogHeader>
          <DialogTitle>{form.id ? "ویرایش شرکت" : "ثبت شرکت جدید"}</DialogTitle>
        </DialogHeader>
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
          <div className="space-y-1.5">
            <Label>نام شرکت *</Label>
            <Input value={form.name} onChange={(e) => set("name")(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label>نام انگلیسی</Label>
            <Input dir="ltr" value={form.nameEn} onChange={(e) => set("nameEn")(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label>نوع همکاری</Label>
            <Select value={form.type} onValueChange={set("type")}>
              <SelectTrigger><SelectValue /></SelectTrigger>
              <SelectContent>
                {COMPANY_TYPES.map((t) => (
                  <SelectItem key={t} value={t}>{COMPANY_TYPE_LABELS[t]}</SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
          <div className="space-y-1.5">
            <Label>حوزه فعالیت</Label>
            <Input value={form.industry} onChange={(e) => set("industry")(e.target.value)} placeholder="مثلاً فناوری اطلاعات" />
          </div>
          <div className="space-y-1.5">
            <Label>شناسه ملی / کد اقتصادی</Label>
            <Input dir="ltr" value={form.taxId} onChange={(e) => set("taxId")(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label>تلفن</Label>
            <Input dir="ltr" value={form.phone} onChange={(e) => set("phone")(e.target.value)} placeholder="021-12345678" />
          </div>
          <div className="space-y-1.5">
            <Label>ایمیل</Label>
            <Input dir="ltr" type="email" value={form.email} onChange={(e) => set("email")(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label>وب‌سایت</Label>
            <Input dir="ltr" value={form.website} onChange={(e) => set("website")(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label>استان</Label>
            <Input value={form.province} onChange={(e) => set("province")(e.target.value)} />
          </div>
          <div className="space-y-1.5">
            <Label>شهر</Label>
            <Input value={form.city} onChange={(e) => set("city")(e.target.value)} />
          </div>
          <div className="space-y-1.5 sm:col-span-2">
            <Label>آدرس</Label>
            <Input value={form.address} onChange={(e) => set("address")(e.target.value)} />
          </div>
          <div className="space-y-1.5 sm:col-span-2">
            <Label>توضیحات</Label>
            <Input value={form.description} onChange={(e) => set("description")(e.target.value)} />
          </div>
        </div>
        <DialogFooter>
          <Button variant="outline" onClick={() => onOpenChange(false)}>انصراف</Button>
          <Button onClick={onSave} disabled={saving}>
            {saving ? "در حال ذخیره…" : "ذخیره"}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
