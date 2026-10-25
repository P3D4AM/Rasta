"use client";

import { useMemo, useState } from "react";
import { Search, Plus, Pencil, Trash2, Warehouse as WarehouseIcon, MapPin, Star } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { Checkbox } from "@/components/ui/checkbox";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { StatusBadge } from "@/components/rasta/status-badge";
import { useList, api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";

type Warehouse = {
  id: string; name: string; code: string | null; location: string | null;
  isDefault: boolean; isActive: boolean; note: string | null;
  itemCount: number; totalValue: number;
};

const emptyForm = {
  id: "", name: "", code: "", location: "",
  isDefault: false, isActive: true, note: "",
};

export default function WarehousesPage() {
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);

  const url = useMemo(() => `/api/warehouses?search=${encodeURIComponent(search)}`, [search]);
  const { rows, total, loading, refresh } = useList<Warehouse>(url);

  function openDialog(w?: Warehouse) {
    setForm(
      w
        ? {
            id: w.id, name: w.name, code: w.code ?? "", location: w.location ?? "",
            isDefault: w.isDefault, isActive: w.isActive, note: w.note ?? "",
          }
        : emptyForm
    );
    setDialogOpen(true);
  }

  async function save() {
    if (!form.name.trim()) return toast({ title: "نام انبار الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const method = form.id ? "PUT" : "POST";
      const path = form.id ? `/api/warehouses/${form.id}` : "/api/warehouses";
      await api(path, { method, body: form });
      toast({ title: form.id ? "انبار ویرایش شد." : "انبار ثبت شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(w: Warehouse) {
    if (!confirm(`حذف «${w.name}»؟`)) return;
    try {
      const res = await api<{ deactivated?: boolean }>(`/api/warehouses/${w.id}`, { method: "DELETE" });
      toast({ title: res.deactivated ? "این انبار سابقه گردش دارد — غیرفعال شد." : "انبار حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Warehouse>[] = [
    {
      key: "name",
      header: "انبار",
      render: (w) => (
        <div className="flex items-center gap-2.5">
          <div className="w-9 h-9 rounded-lg bg-secondary flex items-center justify-center shrink-0">
            <WarehouseIcon className="w-4 h-4 text-muted-foreground" />
          </div>
          <div>
            <p className={`font-bold ${!w.isActive ? "text-muted-foreground line-through" : ""}`}>
              {w.name}
              {w.isDefault && <Star className="inline w-3.5 h-3.5 ms-1.5 text-amber-500 fill-amber-400" />}
            </p>
            {w.code && <p className="text-xs text-muted-foreground" dir="ltr">{w.code}</p>}
          </div>
        </div>
      ),
    },
    {
      key: "location",
      header: "موقعیت",
      render: (w) =>
        w.location ? (
          <span className="text-muted-foreground inline-flex items-center gap-1 text-sm">
            <MapPin className="w-3.5 h-3.5" />
            {w.location}
          </span>
        ) : (
          <span className="text-muted-foreground text-sm">—</span>
        ),
    },
    {
      key: "itemCount",
      header: "اقلام دارای موجودی",
      render: (w) => <span className="font-bold">{toPersianDigits(w.itemCount)} قلم</span>,
    },
    {
      key: "totalValue",
      header: "ارزش موجودی (ریال)",
      render: (w) => <span className="text-muted-foreground">{formatMoney(w.totalValue)}</span>,
    },
    {
      key: "status",
      header: "وضعیت",
      render: (w) => (
        <StatusBadge value={w.isActive ? "ACTIVE" : "INACTIVE"} label={w.isActive ? "فعال" : "غیرفعال"} />
      ),
    },
    {
      key: "actions",
      header: "",
      className: "w-24 text-end",
      render: (w) => (
        <div className="flex justify-end gap-1">
          <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openDialog(w)} aria-label="ویرایش">
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(w)} aria-label="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <PageHeader
        title="انبارها"
        subtitle={`${toPersianDigits(total)} انبار فعال و غیرفعال`}
        actions={
          <Button onClick={() => openDialog()}>
            <Plus className="w-4 h-4 me-1" />
            انبار جدید
          </Button>
        }
      />

      <form className="mb-4" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
        <div className="relative max-w-md">
          <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
          <Input className="ps-9" placeholder="جستجوی نام انبار…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
        </div>
      </form>

      <DataTable columns={columns} rows={rows} loading={loading} page={page} pageSize={20} total={total} onPageChange={setPage} emptyText="انباری ثبت نشده است." />

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader>
            <DialogTitle>{form.id ? "ویرایش انبار" : "انبار جدید"}</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5 sm:col-span-2">
              <Label>نام انبار *</Label>
              <Input value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} placeholder="انبار مرکزی" />
            </div>
            <div className="space-y-1.5">
              <Label>کد</Label>
              <Input dir="ltr" value={form.code} onChange={(e) => setForm({ ...form, code: e.target.value })} placeholder="WH-01" />
            </div>
            <div className="space-y-1.5">
              <Label>موقعیت</Label>
              <Input value={form.location} onChange={(e) => setForm({ ...form, location: e.target.value })} placeholder="تهران، خیابان…" />
            </div>
            <div className="flex items-center gap-2 pt-6">
              <Checkbox
                id="isDefault"
                checked={form.isDefault}
                onCheckedChange={(v) => setForm({ ...form, isDefault: Boolean(v) })}
              />
              <Label htmlFor="isDefault" className="cursor-pointer">انبار پیش‌فرض</Label>
            </div>
            <div className="flex items-center gap-2 pt-6">
              <Checkbox
                id="isActiveWh"
                checked={form.isActive}
                onCheckedChange={(v) => setForm({ ...form, isActive: Boolean(v) })}
              />
              <Label htmlFor="isActiveWh" className="cursor-pointer">فعال</Label>
            </div>
            <div className="space-y-1.5 sm:col-span-2">
              <Label>توضیحات</Label>
              <Textarea rows={2} value={form.note} onChange={(e) => setForm({ ...form, note: e.target.value })} />
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
