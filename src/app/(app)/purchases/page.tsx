"use client";

import { useMemo, useState } from "react";
import {
  Search, Plus, Trash2, ShoppingCart, PackageCheck, Send, Pencil, Eye,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
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
import { JalaliDateInput } from "@/components/rasta/jalali-date-input";
import { useList, api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { PURCHASE_STATUSES, PURCHASE_STATUS_LABELS } from "@/lib/constants";
import { toPersianDigits, formatJalali } from "@/lib/jalali";

type Purchase = {
  id: string; number: number; status: string; total: number;
  issueDate: string; expectedAt: string | null;
  supplier: { id: string; name: string };
  warehouse: { id: string; name: string } | null;
  _count: { items: number };
};

type ItemRow = {
  productId: string; description: string; qty: string; unitPrice: string; taxRate: string;
};

type ProductOption = { id: string; name: string; cost: number | null; price: number; taxRate: number };

const emptyItem: ItemRow = { productId: "", description: "", qty: "1", unitPrice: "", taxRate: "9" };

export default function PurchasesPage() {
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState("ALL");

  const [dialogOpen, setDialogOpen] = useState(false);
  const [viewing, setViewing] = useState<Purchase | null>(null); // read-only mode
  const [saving, setSaving] = useState(false);

  const [suppliers, setSuppliers] = useState<{ id: string; name: string }[]>([]);
  const [warehouses, setWarehouses] = useState<{ id: string; name: string }[]>([]);
  const [products, setProducts] = useState<ProductOption[]>([]);
  const [form, setForm] = useState({
    id: "",
    supplierId: "",
    warehouseId: "",
    issueDate: null as string | null,
    expectedAt: null as string | null,
    note: "",
    items: [{ ...emptyItem }] as ItemRow[],
  });

  const url = useMemo(
    () => `/api/purchases?page=${page}&search=${encodeURIComponent(search)}&status=${statusFilter}`,
    [page, search, statusFilter]
  );
  const { rows, total, loading, refresh } = useList<Purchase>(url);

  async function openDialog(p?: Purchase) {
    const [cRes, wRes, pRes] = await Promise.all([
      fetch("/api/companies?pageSize=200"),
      fetch("/api/warehouses"),
      fetch("/api/products?active=1&pageSize=200"),
    ]);
    const [c, w, pr] = await Promise.all([cRes.json(), wRes.json(), pRes.json()]);
    const supplierRows: { id: string; name: string; type: string }[] = c.rows ?? [];
    setSuppliers(supplierRows.map((s) => ({ id: s.id, name: s.name })));
    setWarehouses((w.rows ?? []).map((x: { id: string; name: string; isActive: boolean }) => ({ id: x.id, name: x.name })));
    setProducts(pr.rows ?? []);

    if (p) {
      // edit (DRAFT) or view (other statuses)
      const detail = await api<{
        supplierId: string; warehouseId: string | null; issueDate: string; expectedAt: string | null;
        note: string | null;
        items: { productId: string | null; description: string | null; qty: number; unitPrice: number; taxRate: number }[];
      }>(`/api/purchases/${p.id}`);
      setForm({
        id: p.id,
        supplierId: detail.supplierId,
        warehouseId: detail.warehouseId ?? "",
        issueDate: detail.issueDate ? detail.issueDate.slice(0, 10) : null,
        expectedAt: detail.expectedAt ? detail.expectedAt.slice(0, 10) : null,
        note: detail.note ?? "",
        items: detail.items.map((it) => ({
          productId: it.productId ?? "",
          description: it.description ?? "",
          qty: String(it.qty),
          unitPrice: String(it.unitPrice),
          taxRate: String(it.taxRate),
        })),
      });
      setViewing(p.status !== "DRAFT" ? p : null);
    } else {
      setForm({ id: "", supplierId: "", warehouseId: "", issueDate: null, expectedAt: null, note: "", items: [{ ...emptyItem }] });
      setViewing(null);
    }
    setDialogOpen(true);
  }

  function setItem(i: number, patch: Partial<ItemRow>) {
    const items = [...form.items];
    items[i] = { ...items[i], ...patch };
    setForm({ ...form, items });
  }

  function onProductSelected(i: number, productId: string) {
    const p = products.find((x) => x.id === productId);
    setItem(i, {
      productId,
      unitPrice: p ? String(p.cost ?? p.price) : "",
      taxRate: p ? String(p.taxRate) : "9",
      description: p?.name ?? "",
    });
  }

  function calc() {
    let subtotal = 0;
    let tax = 0;
    for (const it of form.items) {
      const q = Number(it.qty) || 0;
      const up = Number(it.unitPrice) || 0;
      const tr = Number(it.taxRate) || 0;
      subtotal += q * up;
      tax += (q * up * tr) / 100;
    }
    return { subtotal, tax, total: subtotal + tax };
  }

  async function save() {
    if (!form.supplierId) return toast({ title: "انتخاب تأمین‌کننده الزامی است.", variant: "destructive" });
    const valid = form.items.filter((it) => it.productId || it.description.trim());
    if (valid.length === 0) return toast({ title: "حداقل یک ردیف کالا وارد کنید.", variant: "destructive" });
    setSaving(true);
    try {
      const method = form.id ? "PUT" : "POST";
      const path = form.id ? `/api/purchases/${form.id}` : "/api/purchases";
      await api(path, {
        method,
        body: {
          supplierId: form.supplierId,
          warehouseId: form.warehouseId || null,
          issueDate: form.issueDate,
          expectedAt: form.expectedAt,
          note: form.note,
          items: valid,
        },
      });
      toast({ title: form.id ? "سفارش خرید ویرایش شد." : "سفارش خرید ثبت شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function doAction(p: Purchase, action: "setStatus" | "receive", status?: string) {
    const label =
      action === "receive"
        ? `دریافت کالای سفارش ${toPersianDigits(p.number)} و ورود به انبار؟`
        : status === "ORDERED"
          ? `ارسال سفارش ${toPersianDigits(p.number)} به تأمین‌کننده؟`
          : `لغو سفارش ${toPersianDigits(p.number)}؟`;
    if (!confirm(label)) return;
    try {
      await api(`/api/purchases/${p.id}`, { method: "PATCH", body: { action, status } });
      toast({ title: action === "receive" ? "کالا به انبار اضافه شد." : "وضعیت سفارش به‌روزرسانی شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function remove(p: Purchase) {
    if (!confirm(`حذف سفارش خرید ${toPersianDigits(p.number)}؟`)) return;
    try {
      await api(`/api/purchases/${p.id}`, { method: "DELETE" });
      toast({ title: "سفارش خرید حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Purchase>[] = [
    {
      key: "number",
      header: "شماره",
      render: (p) => <span className="font-bold" dir="ltr">#{toPersianDigits(p.number)}</span>,
    },
    { key: "supplier", header: "تأمین‌کننده", render: (p) => <span className="text-sm font-medium">{p.supplier.name}</span> },
    {
      key: "issueDate",
      header: "تاریخ سفارش",
      render: (p) => <span className="text-xs text-muted-foreground">{formatJalali(p.issueDate)}</span>,
    },
    {
      key: "expectedAt",
      header: "تحویل مورد انتظار",
      render: (p) => (
        <span className="text-xs text-muted-foreground">{p.expectedAt ? formatJalali(p.expectedAt) : "—"}</span>
      ),
    },
    {
      key: "warehouse",
      header: "انبار",
      render: (p) => <span className="text-xs text-muted-foreground">{p.warehouse?.name ?? "پیش‌فرض"}</span>,
    },
    { key: "items", header: "اقلام", render: (p) => <span>{toPersianDigits(p._count.items)} ردیف</span> },
    { key: "total", header: "مبلغ (ریال)", render: (p) => <span className="font-bold">{formatMoney(p.total)}</span> },
    {
      key: "status",
      header: "وضعیت",
      render: (p) => <StatusBadge value={p.status} label={PURCHASE_STATUS_LABELS[p.status] ?? p.status} />,
    },
    {
      key: "actions",
      header: "",
      className: "w-32 text-end",
      render: (p) => (
        <div className="flex justify-end gap-1">
          {p.status === "DRAFT" && (
            <>
              <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openDialog(p)} aria-label="ویرایش">
                <Pencil className="w-3.5 h-3.5" />
              </Button>
              <Button variant="ghost" size="icon" className="h-8 w-8 text-indigo-600 hover:text-indigo-700" onClick={() => doAction(p, "setStatus", "ORDERED")} aria-label="ارسال سفارش">
                <Send className="w-3.5 h-3.5" />
              </Button>
              <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(p)} aria-label="حذف">
                <Trash2 className="w-3.5 h-3.5" />
              </Button>
            </>
          )}
          {p.status === "ORDERED" && (
            <>
              <Button
                variant="outline"
                size="sm"
                className="h-8 gap-1 text-xs text-emerald-700 border-emerald-200 hover:bg-emerald-50"
                onClick={() => doAction(p, "receive")}
              >
                <PackageCheck className="w-3.5 h-3.5" />
                دریافت کالا
              </Button>
              <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => doAction(p, "setStatus", "CANCELED")} aria-label="لغو">
                <Trash2 className="w-3.5 h-3.5" />
              </Button>
            </>
          )}
          {p.status !== "DRAFT" && p.status !== "ORDERED" && (
            <Button variant="ghost" size="icon" className="h-8 w-8" onClick={() => openDialog(p)} aria-label="مشاهده">
              <Eye className="w-3.5 h-3.5" />
            </Button>
          )}
        </div>
      ),
    },
  ];

  const { subtotal, tax, total: grandTotal } = calc();
  const readOnly = !!viewing;

  return (
    <div>
      <PageHeader
        title="سفارشات خرید"
        subtitle={`${toPersianDigits(total)} سفارش از تأمین‌کنندگان`}
        actions={
          <Button onClick={() => openDialog()}>
            <Plus className="w-4 h-4 me-1" />
            سفارش خرید جدید
          </Button>
        }
      />

      <div className="flex flex-col sm:flex-row gap-2 mb-4">
        <form className="flex-1" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
          <div className="relative max-w-md">
            <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
            <Input className="ps-9" placeholder="جستجوی تأمین‌کننده…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
          </div>
        </form>
        <Select value={statusFilter} onValueChange={(v) => { setStatusFilter(v); setPage(1); }}>
          <SelectTrigger className="w-40">
            <SelectValue placeholder="همه وضعیت‌ها" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="ALL">همه وضعیت‌ها</SelectItem>
            {PURCHASE_STATUSES.map((s) => (
              <SelectItem key={s} value={s}>
                {PURCHASE_STATUS_LABELS[s]}
              </SelectItem>
            ))}
          </SelectContent>
        </Select>
      </div>

      <DataTable columns={columns} rows={rows} loading={loading} page={page} pageSize={20} total={total} onPageChange={setPage} emptyText="سفارش خریدی ثبت نشده است." />

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-3xl">
          <DialogHeader>
            <DialogTitle className="flex items-center gap-2">
              <ShoppingCart className="w-4 h-4 text-primary" />
              {readOnly ? `مشاهده سفارش خرید ${toPersianDigits(viewing!.number)}` : form.id ? "ویرایش سفارش خرید" : "سفارش خرید جدید"}
              {viewing && (
                <StatusBadge value={viewing.status} label={PURCHASE_STATUS_LABELS[viewing.status] ?? viewing.status} />
              )}
            </DialogTitle>
          </DialogHeader>

          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5">
              <Label>تأمین‌کننده *</Label>
              <Select
                value={form.supplierId}
                onValueChange={(v) => setForm({ ...form, supplierId: v })}
                disabled={readOnly}
              >
                <SelectTrigger>
                  <SelectValue placeholder="انتخاب شرکت" />
                </SelectTrigger>
                <SelectContent>
                  {suppliers.map((s) => (
                    <SelectItem key={s.id} value={s.id}>
                      {s.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>انبار تحویل</Label>
              <Select
                value={form.warehouseId || "none"}
                onValueChange={(v) => setForm({ ...form, warehouseId: v === "none" ? "" : v })}
                disabled={readOnly}
              >
                <SelectTrigger>
                  <SelectValue placeholder="انبار پیش‌فرض" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="none">انبار پیش‌فرض</SelectItem>
                  {warehouses.map((w) => (
                    <SelectItem key={w.id} value={w.id}>
                      {w.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>تاریخ سفارش</Label>
              <JalaliDateInput value={form.issueDate} onChange={(v) => setForm({ ...form, issueDate: v })} disabled={readOnly} />
            </div>
            <div className="space-y-1.5">
              <Label>تحویل مورد انتظار</Label>
              <JalaliDateInput value={form.expectedAt} onChange={(v) => setForm({ ...form, expectedAt: v })} disabled={readOnly} />
            </div>
          </div>

          {/* ── items editor ── */}
          <div className="rounded-xl border overflow-hidden">
            <div className="bg-muted/60 px-3 py-2 text-xs font-bold flex items-center justify-between">
              <span>اقلام سفارش</span>
              {!readOnly && (
                <Button variant="ghost" size="sm" className="h-7 gap-1 text-xs" onClick={() => setForm({ ...form, items: [...form.items, { ...emptyItem }] })}>
                  <Plus className="w-3.5 h-3.5" />
                  افزودن ردیف
                </Button>
              )}
            </div>
            <div className="p-3 space-y-2 max-h-[40vh] overflow-y-auto">
              {form.items.map((it, i) => (
                <div key={i} className="grid grid-cols-12 gap-2 items-center">
                  <div className="col-span-5 sm:col-span-4">
                    <Select value={it.productId} onValueChange={(v) => onProductSelected(i, v)} disabled={readOnly}>
                      <SelectTrigger className="h-9 text-xs">
                        <SelectValue placeholder="انتخاب کالا یا شرح آزاد" />
                      </SelectTrigger>
                      <SelectContent>
                        {products.map((p) => (
                          <SelectItem key={p.id} value={p.id}>
                            {p.name}
                          </SelectItem>
                        ))}
                      </SelectContent>
                    </Select>
                    {!it.productId && (
                      <Input
                        className="mt-1 h-8 text-xs"
                        placeholder="شرح کالا/خدمت"
                        value={it.description}
                        onChange={(e) => setItem(i, { description: e.target.value })}
                        disabled={readOnly}
                      />
                    )}
                  </div>
                  <div className="col-span-2 sm:col-span-2">
                    <Input dir="ltr" type="number" className="h-9 text-xs" placeholder="تعداد" value={it.qty} onChange={(e) => setItem(i, { qty: e.target.value })} disabled={readOnly} />
                  </div>
                  <div className="col-span-2">
                    <Input dir="ltr" type="number" className="h-9 text-xs" placeholder="قیمت واحد" value={it.unitPrice} onChange={(e) => setItem(i, { unitPrice: e.target.value })} disabled={readOnly} />
                  </div>
                  <div className="col-span-1 sm:col-span-1">
                    <Input dir="ltr" type="number" className="h-9 text-xs px-1" placeholder="٪" value={it.taxRate} onChange={(e) => setItem(i, { taxRate: e.target.value })} disabled={readOnly} />
                  </div>
                  <div className="col-span-2 sm:col-span-2 flex items-center justify-between gap-1">
                    <span className="text-xs font-bold text-muted-foreground truncate">
                      {formatMoney(((Number(it.qty) || 0) * (Number(it.unitPrice) || 0) * (1 + (Number(it.taxRate) || 0) / 100)))}
                    </span>
                    {!readOnly && form.items.length > 1 && (
                      <Button variant="ghost" size="icon" className="h-7 w-7 text-destructive hover:text-destructive shrink-0" onClick={() => setForm({ ...form, items: form.items.filter((_, j) => j !== i) })} aria-label="حذف ردیف">
                        <Trash2 className="w-3.5 h-3.5" />
                      </Button>
                    )}
                  </div>
                </div>
              ))}
            </div>
            <div className="border-t bg-muted/30 px-3 py-2 grid grid-cols-3 gap-2 text-xs">
              <span>جمع کل: <b>{formatMoney(subtotal)}</b></span>
              <span>مالیات: <b>{formatMoney(tax)}</b></span>
              <span className="text-emerald-700">مبلغ نهایی: <b>{formatMoney(grandTotal)}</b></span>
            </div>
          </div>

          <div className="space-y-1.5">
            <Label>یادداشت</Label>
            <Textarea rows={2} value={form.note} onChange={(e) => setForm({ ...form, note: e.target.value })} disabled={readOnly} placeholder="شرایط تحویل، پیش‌پرداخت و…" />
          </div>

          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>بستن</Button>
            {!readOnly && (
              <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ذخیره سفارش"}</Button>
            )}
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
