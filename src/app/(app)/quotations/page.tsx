"use client";

import { useMemo, useState } from "react";
import { useRouter } from "next/navigation";
import { Search, Plus, FileText, Trash2, Repeat, Send } from "lucide-react";
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
import { formatMoney, formatDate } from "@/lib/format";
import { QUOTATION_STATUSES, QUOTATION_STATUS_LABELS } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Quotation = {
  id: string; number: number; status: string; total: number; issueDate: string;
  company: { id: string; name: string };
  deal: { id: string; title: string } | null;
  _count: { items: number };
};

type ProductOption = { id: string; name: string; price: number; unit: string; taxRate: number };

type ItemRow = {
  productId: string; description: string; qty: string;
  unitPrice: string; discount: string; taxRate: string;
};

const emptyItem: ItemRow = { productId: "", description: "", qty: "1", unitPrice: "", discount: "0", taxRate: "9" };

export default function QuotationsPage() {
  const router = useRouter();
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState("ALL");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [saving, setSaving] = useState(false);

  const [companies, setCompanies] = useState<{ id: string; name: string }[]>([]);
  const [products, setProducts] = useState<ProductOption[]>([]);
  const [form, setForm] = useState({
    companyId: "",
    issueDate: null as string | null,
    validUntil: null as string | null,
    note: "",
    items: [{ ...emptyItem }] as ItemRow[],
  });

  const url = useMemo(
    () => `/api/quotations?page=${page}&search=${encodeURIComponent(search)}&status=${statusFilter}`,
    [page, search, statusFilter]
  );
  const { rows, total, loading, refresh } = useList<Quotation>(url);

  async function openDialog() {
    const [cRes, pRes] = await Promise.all([
      fetch("/api/companies?pageSize=200"),
      fetch("/api/products?active=1&pageSize=200"),
    ]);
    const [c, p] = await Promise.all([cRes.json(), pRes.json()]);
    setCompanies(c.rows ?? []);
    setProducts(p.rows ?? []);
    setForm({ companyId: "", issueDate: null, validUntil: null, note: "", items: [{ ...emptyItem }] });
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
      unitPrice: p ? String(p.price) : "",
      taxRate: p ? String(p.taxRate) : "0",
      description: p?.name ?? "",
    });
  }

  function calc() {
    let subtotal = 0, discount = 0, tax = 0;
    for (const it of form.items) {
      const q = Number(it.qty) || 0;
      const up = Number(it.unitPrice) || 0;
      const d = Math.min(q * up, Number(it.discount) || 0);
      const tr = Number(it.taxRate) || 0;
      subtotal += q * up;
      discount += d;
      tax += ((q * up - d) * tr) / 100;
    }
    return { subtotal, discount, tax, total: subtotal - discount + tax };
  }

  async function save() {
    if (!form.companyId) return toast({ title: "انتخاب شرکت الزامی است.", variant: "destructive" });
    const valid = form.items.filter(
      (it) => it.productId || it.description.trim()
    );
    if (valid.length === 0) return toast({ title: "حداقل یک ردیف کالا وارد کنید.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/quotations", {
        method: "POST",
        body: {
          companyId: form.companyId,
          issueDate: form.issueDate,
          validUntil: form.validUntil,
          note: form.note,
          items: valid,
        },
      });
      toast({ title: "پیش‌فاکتور صادر شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function convert(q: Quotation) {
    if (!confirm(`تبدیل پیش‌فاکتور ${toPersianDigits(q.number)} به فاکتور؟`)) return;
    try {
      await api(`/api/quotations/${q.id}`, { method: "PATCH", body: { action: "convert" } });
      toast({ title: "فاکتور صادر شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function setStatus(q: Quotation, status: string) {
    try {
      await api(`/api/quotations/${q.id}`, { method: "PATCH", body: { action: "setStatus", status } });
      toast({ title: "وضعیت به‌روزرسانی شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function remove(q: Quotation) {
    if (!confirm(`حذف پیش‌فاکتور ${toPersianDigits(q.number)}؟`)) return;
    try {
      await api(`/api/quotations/${q.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Quotation>[] = [
    {
      key: "number",
      header: "شماره",
      render: (q) => (
        <span className="flex items-center gap-2 font-bold">
          <FileText className="w-4 h-4 text-muted-foreground" />
          {toPersianDigits(q.number)}
        </span>
      ),
    },
    {
      key: "company",
      header: "شرکت",
      render: (q) => <span>{q.company.name}</span>,
    },
    { key: "items", header: "ردیف‌ها", render: (q) => <span className="text-muted-foreground">{toPersianDigits(q._count.items)}</span> },
    { key: "date", header: "تاریخ", render: (q) => <span className="text-muted-foreground text-xs">{formatDate(q.issueDate)}</span> },
    { key: "total", header: "مبلغ کل (ریال)", render: (q) => <span className="font-bold">{formatMoney(q.total)}</span> },
    {
      key: "status",
      header: "وضعیت",
      render: (q) => <StatusBadge value={q.status} label={QUOTATION_STATUS_LABELS[q.status] ?? q.status} />,
    },
    {
      key: "actions",
      header: "",
      className: "w-32 text-end",
      render: (q) => (
        <div className="flex justify-end gap-1" onClick={(e) => e.stopPropagation()}>
          {q.status === "DRAFT" && (
            <Button variant="ghost" size="icon" className="h-8 w-8 text-primary" title="ارسال" onClick={() => setStatus(q, "SENT")}>
              <Send className="w-3.5 h-3.5" />
            </Button>
          )}
          {q.status !== "CONVERTED" && q.status !== "DRAFT" && (
            <Button variant="ghost" size="icon" className="h-8 w-8 text-primary" title="تبدیل به فاکتور" onClick={() => convert(q)}>
              <Repeat className="w-3.5 h-3.5" />
            </Button>
          )}
          <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(q)} aria-label="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  const totals = calc();

  return (
    <div>
      <PageHeader
        title="پیش‌فاکتورها"
        subtitle={`${toPersianDigits(total)} سند`}
        actions={
          <Button onClick={openDialog}>
            <Plus className="w-4 h-4 me-1" />
            صدور پیش‌فاکتور
          </Button>
        }
      />

      <div className="flex flex-col sm:flex-row gap-2 mb-4">
        <form className="flex-1" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
          <div className="relative max-w-md">
            <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
            <Input className="ps-9" placeholder="جستجوی نام شرکت…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
          </div>
        </form>
        <Select value={statusFilter} onValueChange={(v) => { setStatusFilter(v); setPage(1); }}>
          <SelectTrigger className="w-full sm:w-44"><SelectValue /></SelectTrigger>
          <SelectContent>
            <SelectItem value="ALL">همه وضعیت‌ها</SelectItem>
            {QUOTATION_STATUSES.map((s) => (
              <SelectItem key={s} value={s}>{QUOTATION_STATUS_LABELS[s]}</SelectItem>
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
        onRowClick={(q) => router.push(`/quotations/${q.id}`)}
      />

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-3xl max-h-[92vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle>صدور پیش‌فاکتور</DialogTitle>
          </DialogHeader>

          <div className="grid grid-cols-1 sm:grid-cols-3 gap-3">
            <div className="space-y-1.5">
              <Label>شرکت *</Label>
              <Select value={form.companyId} onValueChange={(v) => setForm({ ...form, companyId: v })}>
                <SelectTrigger><SelectValue placeholder="انتخاب" /></SelectTrigger>
                <SelectContent>
                  {companies.map((c) => (
                    <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>تاریخ صدور</Label>
              <JalaliDateInput value={form.issueDate} onChange={(iso) => setForm({ ...form, issueDate: iso })} />
            </div>
            <div className="space-y-1.5">
              <Label>اعتبار تا</Label>
              <JalaliDateInput value={form.validUntil} onChange={(iso) => setForm({ ...form, validUntil: iso })} />
            </div>
          </div>

          <div className="rounded-xl border overflow-hidden">
            <table className="w-full text-xs">
              <thead className="bg-muted font-bold">
                <tr>
                  <th className="p-2 text-start">کالا</th>
                  <th className="p-2 w-20">تعداد</th>
                  <th className="p-2 w-32">فی (ریال)</th>
                  <th className="p-2 w-28">تخفیف</th>
                  <th className="p-2 w-16">مالیات ٪</th>
                  <th className="p-2 w-10"></th>
                </tr>
              </thead>
              <tbody>
                {form.items.map((it, i) => (
                  <tr key={i} className="border-t">
                    <td className="p-1.5">
                      <Select value={it.productId} onValueChange={(v) => onProductSelected(i, v)}>
                        <SelectTrigger className="h-8 text-xs"><SelectValue placeholder="انتخاب کالا" /></SelectTrigger>
                        <SelectContent>
                          {products.map((p) => (
                            <SelectItem key={p.id} value={p.id}>{p.name}</SelectItem>
                          ))}
                        </SelectContent>
                      </Select>
                    </td>
                    <td className="p-1.5"><Input dir="ltr" className="h-8" type="number" value={it.qty} onChange={(e) => setItem(i, { qty: e.target.value })} /></td>
                    <td className="p-1.5"><Input dir="ltr" className="h-8" type="number" value={it.unitPrice} onChange={(e) => setItem(i, { unitPrice: e.target.value })} /></td>
                    <td className="p-1.5"><Input dir="ltr" className="h-8" type="number" value={it.discount} onChange={(e) => setItem(i, { discount: e.target.value })} /></td>
                    <td className="p-1.5"><Input dir="ltr" className="h-8" type="number" value={it.taxRate} onChange={(e) => setItem(i, { taxRate: e.target.value })} /></td>
                    <td className="p-1.5 text-center">
                      {form.items.length > 1 && (
                        <button className="text-destructive" onClick={() => setForm({ ...form, items: form.items.filter((_, x) => x !== i) })} aria-label="حذف ردیف">✕</button>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            <button
              className="w-full p-2 text-xs text-primary hover:bg-accent font-bold border-t"
              onClick={() => setForm({ ...form, items: [...form.items, { ...emptyItem }] })}
            >
              + افزودن ردیف
            </button>
          </div>

          <div className="grid grid-cols-4 gap-2 text-sm">
            <div className="rounded-lg bg-muted p-2.5 text-center">
              <p className="text-[10px] text-muted-foreground">جمع کل</p>
              <p className="font-bold">{formatMoney(totals.subtotal)}</p>
            </div>
            <div className="rounded-lg bg-muted p-2.5 text-center">
              <p className="text-[10px] text-muted-foreground">تخفیف</p>
              <p className="font-bold text-amber-600">{formatMoney(totals.discount)}</p>
            </div>
            <div className="rounded-lg bg-muted p-2.5 text-center">
              <p className="text-[10px] text-muted-foreground">مالیات</p>
              <p className="font-bold">{formatMoney(totals.tax)}</p>
            </div>
            <div className="rounded-lg bg-primary text-primary-foreground p-2.5 text-center">
              <p className="text-[10px] opacity-80">مبلغ نهایی</p>
              <p className="font-extrabold">{formatMoney(totals.total)}</p>
            </div>
          </div>

          <div className="space-y-1.5">
            <Label>یادداشت</Label>
            <Textarea rows={2} value={form.note} onChange={(e) => setForm({ ...form, note: e.target.value })} />
          </div>

          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال صدور…" : "صدور پیش‌فاکتور"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
