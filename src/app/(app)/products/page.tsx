"use client";

import { useMemo, useState } from "react";
import { Search, Plus, Pencil, Trash2, Package } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { Checkbox } from "@/components/ui/checkbox";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { useList, api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";

type Product = {
  id: string; name: string; code: string | null; unit: string;
  price: number; cost: number | null; taxRate: number; isActive: boolean;
  description: string | null;
};

const emptyForm = {
  id: "", name: "", code: "", unit: "عدد", price: "", cost: "",
  taxRate: "9", isActive: true, description: "",
};

export default function ProductsPage() {
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);

  const url = useMemo(() => `/api/products?page=${page}&search=${encodeURIComponent(search)}`, [page, search]);
  const { rows, total, loading, refresh } = useList<Product>(url);

  function openDialog(p?: Product) {
    setForm(
      p
        ? {
            id: p.id, name: p.name, code: p.code ?? "", unit: p.unit,
            price: String(p.price), cost: p.cost != null ? String(p.cost) : "",
            taxRate: String(p.taxRate), isActive: p.isActive, description: p.description ?? "",
          }
        : emptyForm
    );
    setDialogOpen(true);
  }

  async function save() {
    if (!form.name.trim()) return toast({ title: "نام محصول الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const method = form.id ? "PUT" : "POST";
      const path = form.id ? `/api/products/${form.id}` : "/api/products";
      await api(path, { method, body: form });
      toast({ title: form.id ? "محصول ویرایش شد." : "محصول ثبت شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(p: Product) {
    if (!confirm(`حذف «${p.name}»؟`)) return;
    try {
      const res = await api<{ softDeleted?: boolean }>(`/api/products/${p.id}`, { method: "DELETE" });
      toast({ title: res.softDeleted ? "محصول در اسناد استفاده شده — غیرفعال شد." : "محصول حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Product>[] = [
    {
      key: "name",
      header: "محصول",
      render: (p) => (
        <div className="flex items-center gap-2.5">
          <div className="w-9 h-9 rounded-lg bg-secondary flex items-center justify-center shrink-0">
            <Package className="w-4 h-4 text-muted-foreground" />
          </div>
          <div>
            <p className={`font-bold ${!p.isActive ? "text-muted-foreground line-through" : ""}`}>{p.name}</p>
            {p.code && <p className="text-xs text-muted-foreground" dir="ltr">{p.code}</p>}
          </div>
        </div>
      ),
    },
    { key: "price", header: "قیمت (ریال)", render: (p) => <span className="font-bold">{formatMoney(p.price)}</span> },
    { key: "cost", header: "بهای تمام‌شده", render: (p) => <span className="text-muted-foreground">{formatMoney(p.cost)}</span> },
    { key: "tax", header: "مالیات", render: (p) => <span className="text-muted-foreground">٪{toPersianDigits(p.taxRate)}</span> },
    { key: "unit", header: "واحد", render: (p) => <span className="text-muted-foreground">{p.unit}</span> },
    {
      key: "actions",
      header: "",
      className: "w-24 text-end",
      render: (p) => (
        <div className="flex justify-end gap-1">
          <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openDialog(p)} aria-label="ویرایش">
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(p)} aria-label="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <PageHeader
        title="محصولات"
        subtitle={`${toPersianDigits(total)} قلم کالا و خدمات`}
        actions={
          <Button onClick={() => openDialog()}>
            <Plus className="w-4 h-4 me-1" />
            محصول جدید
          </Button>
        }
      />

      <form className="mb-4" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
        <div className="relative max-w-md">
          <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
          <Input className="ps-9" placeholder="جستجوی نام یا کد…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
        </div>
      </form>

      <DataTable columns={columns} rows={rows} loading={loading} page={page} pageSize={20} total={total} onPageChange={setPage} />

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader>
            <DialogTitle>{form.id ? "ویرایش محصول" : "محصول جدید"}</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5 sm:col-span-2">
              <Label>نام محصول *</Label>
              <Input value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>کد</Label>
              <Input dir="ltr" value={form.code} onChange={(e) => setForm({ ...form, code: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>واحد شمارش</Label>
              <Input value={form.unit} onChange={(e) => setForm({ ...form, unit: e.target.value })} placeholder="عدد / کیلوگرم / سرویس" />
            </div>
            <div className="space-y-1.5">
              <Label>قیمت فروش (ریال)</Label>
              <Input dir="ltr" type="number" value={form.price} onChange={(e) => setForm({ ...form, price: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>بهای تمام‌شده (ریال)</Label>
              <Input dir="ltr" type="number" value={form.cost} onChange={(e) => setForm({ ...form, cost: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>نرخ مالیات (٪)</Label>
              <Input dir="ltr" type="number" value={form.taxRate} onChange={(e) => setForm({ ...form, taxRate: e.target.value })} />
            </div>
            <div className="flex items-center gap-2 pt-6">
              <Checkbox
                id="isActive"
                checked={form.isActive}
                onCheckedChange={(v) => setForm({ ...form, isActive: Boolean(v) })}
              />
              <Label htmlFor="isActive" className="cursor-pointer">فعال</Label>
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
