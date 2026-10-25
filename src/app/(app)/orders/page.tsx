"use client";

import { useMemo, useState } from "react";
import { useRouter, useSearchParams } from "next/navigation";
import { Search, ReceiptText, Plus, CreditCard } from "lucide-react";
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
import { JalaliDateInput } from "@/components/rasta/jalali-date-input";
import { useList, api } from "@/hooks/use-list";
import { formatMoney, formatDate } from "@/lib/format";
import { ORDER_STATUSES, ORDER_STATUS_LABELS, PAYMENT_METHODS, PAYMENT_METHOD_LABELS } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Order = {
  id: string; number: number; status: string; total: number; paidTotal: number; issueDate: string;
  company: { id: string; name: string };
  _count: { items: number; payments: number };
};

type OrderDetail = {
  id: string; number: number; status: string; total: number; paidTotal: number;
  company: { id: string; name: string };
  items: { id: string; qty: number; unitPrice: number; discount: number; taxRate: number; lineTotal: number; product: { name: string; unit: string } | null; description: string | null }[];
  payments: { id: string; amount: number; method: string; paidAt: string; note: string | null }[];
};

export default function OrdersPage() {
  const router = useRouter();
  const sp = useSearchParams();
  const focusId = sp.get("focus");
  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState("ALL");

  // payment dialog state
  const [order, setOrder] = useState<OrderDetail | null>(null);
  const [paymentOpen, setPaymentOpen] = useState(false);
  const [payment, setPayment] = useState({ amount: "", method: "CASH", paidAt: null as string | null, note: "" });
  const [saving, setSaving] = useState(false);

  const url = useMemo(
    () => `/api/orders?page=${page}&search=${encodeURIComponent(search)}&status=${statusFilter}`,
    [page, search, statusFilter]
  );
  const { rows, total, loading, refresh } = useList<Order>(url);

  async function openPayments(o: Order) {
    const detail = await api<OrderDetail>(`/api/orders/${o.id}`);
    setOrder(detail);
    setPayment({ amount: String(Math.max(0, Math.round(detail.total - detail.paidTotal))), method: "CASH", paidAt: null, note: "" });
    setPaymentOpen(true);
  }

  async function addPayment() {
    if (!order) return;
    const amount = Number(payment.amount);
    if (!amount || amount <= 0) return toast({ title: "مبلغ نامعتبر است.", variant: "destructive" });
    setSaving(true);
    try {
      await api(`/api/orders/${order.id}`, { method: "PATCH", body: { action: "addPayment", ...payment } });
      toast({ title: "پرداخت ثبت شد." });
      setPaymentOpen(false);
      refresh();
      const detail = await api<OrderDetail>(`/api/orders/${order.id}`);
      setOrder(detail);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function deletePayment(pid: string) {
    if (!order || !confirm("حذف این پرداخت؟")) return;
    try {
      await api(`/api/orders/${order.id}`, { method: "PATCH", body: { action: "deletePayment", paymentId: pid } });
      const detail = await api<OrderDetail>(`/api/orders/${order.id}`);
      setOrder(detail);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Order>[] = [
    {
      key: "number",
      header: "شماره",
      render: (o) => (
        <span className={`flex items-center gap-2 font-bold ${focusId === o.id ? "text-primary" : ""}`}>
          <ReceiptText className="w-4 h-4 text-muted-foreground" />
          {toPersianDigits(o.number)}
        </span>
      ),
    },
    { key: "company", header: "شرکت", render: (o) => <span>{o.company.name}</span> },
    { key: "date", header: "تاریخ", render: (o) => <span className="text-muted-foreground text-xs">{formatDate(o.issueDate)}</span> },
    { key: "total", header: "مبلغ (ریال)", render: (o) => <span className="font-bold">{formatMoney(o.total)}</span> },
    {
      key: "paid",
      header: "پرداخت‌شده",
      render: (o) => (
        <div className="flex items-center gap-2">
          <div className="h-1.5 w-16 bg-muted rounded-full overflow-hidden">
            <div
              className="h-full bg-emerald-500 rounded-full"
              style={{ width: `${Math.min(100, (o.paidTotal / Math.max(o.total, 1)) * 100)}%` }}
            />
          </div>
          <span className="text-xs">{formatMoney(o.paidTotal)}</span>
        </div>
      ),
    },
    {
      key: "status",
      header: "وضعیت",
      render: (o) => <StatusBadge value={o.status} label={ORDER_STATUS_LABELS[o.status] ?? o.status} />,
    },
  ];

  return (
    <div>
      <PageHeader title="فاکتورهای فروش" subtitle={`${toPersianDigits(total)} سند`} />

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
            {ORDER_STATUSES.map((s) => (
              <SelectItem key={s} value={s}>{ORDER_STATUS_LABELS[s]}</SelectItem>
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
        onRowClick={(o) => openPayments(o)}
        emptyText="فاکتوری یافت نشد. از طریق پیش‌فاکتورها فاکتور صادر کنید."
      />

      <Dialog open={paymentOpen} onOpenChange={setPaymentOpen}>
        <DialogContent className="max-w-2xl">
          <DialogHeader>
            <DialogTitle className="flex items-center gap-2">
              فاکتور {order ? toPersianDigits(order.number) : ""}
              {order && <StatusBadge value={order.status} label={ORDER_STATUS_LABELS[order.status]} />}
            </DialogTitle>
          </DialogHeader>

          {order && (
            <>
              <div className="grid grid-cols-3 gap-2 text-center mb-4">
                <div className="rounded-lg bg-muted p-2.5">
                  <p className="text-[10px] text-muted-foreground">مبلغ فاکتور</p>
                  <p className="font-bold">{formatMoney(order.total)}</p>
                </div>
                <div className="rounded-lg bg-muted p-2.5">
                  <p className="text-[10px] text-muted-foreground">پرداخت‌شده</p>
                  <p className="font-bold text-emerald-600">{formatMoney(order.paidTotal)}</p>
                </div>
                <div className="rounded-lg bg-muted p-2.5">
                  <p className="text-[10px] text-muted-foreground">مانده</p>
                  <p className="font-bold text-amber-600">{formatMoney(Math.max(0, order.total - order.paidTotal))}</p>
                </div>
              </div>

              {/* items */}
              <div className="rounded-xl border max-h-40 overflow-y-auto mb-4">
                <table className="w-full text-xs">
                  <thead className="bg-muted sticky top-0">
                    <tr>
                      <th className="p-2 text-start">کالا</th>
                      <th className="p-2">تعداد</th>
                      <th className="p-2">جمع (ریال)</th>
                    </tr>
                  </thead>
                  <tbody>
                    {order.items.map((it) => (
                      <tr key={it.id} className="border-t">
                        <td className="p-2">{it.product?.name ?? it.description ?? "—"}</td>
                        <td className="p-2 text-center">{toPersianDigits(it.qty)}</td>
                        <td className="p-2 text-center font-bold">{formatMoney(it.lineTotal)}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>

              {/* payments list */}
              {order.payments.length > 0 && (
                <div className="mb-4">
                  <p className="text-xs font-bold mb-1.5">پرداخت‌ها:</p>
                  {order.payments.map((p) => (
                    <div key={p.id} className="flex items-center justify-between text-xs py-1.5 border-b">
                      <span>
                        {formatMoney(p.amount)} ریال · {PAYMENT_METHOD_LABELS[p.method] ?? p.method} · {formatDate(p.paidAt)}
                      </span>
                      <button className="text-destructive" onClick={() => deletePayment(p.id)} aria-label="حذف پرداخت">✕</button>
                    </div>
                  ))}
                </div>
              )}

              {/* add payment */}
              <div className="rounded-xl border p-3">
                <p className="text-xs font-bold mb-2 flex items-center gap-1">
                  <CreditCard className="w-3.5 h-3.5" />ثبت پرداخت جدید
                </p>
                <div className="grid grid-cols-1 sm:grid-cols-4 gap-2">
                  <div className="space-y-1">
                    <Label className="text-[11px]">مبلغ (ریال)</Label>
                    <Input dir="ltr" type="number" value={payment.amount} onChange={(e) => setPayment({ ...payment, amount: e.target.value })} />
                  </div>
                  <div className="space-y-1">
                    <Label className="text-[11px]">روش</Label>
                    <Select value={payment.method} onValueChange={(v) => setPayment({ ...payment, method: v })}>
                      <SelectTrigger><SelectValue /></SelectTrigger>
                      <SelectContent>
                        {PAYMENT_METHODS.map((m) => (
                          <SelectItem key={m} value={m}>{PAYMENT_METHOD_LABELS[m]}</SelectItem>
                        ))}
                      </SelectContent>
                    </Select>
                  </div>
                  <div className="space-y-1">
                    <Label className="text-[11px]">تاریخ</Label>
                    <JalaliDateInput value={payment.paidAt} onChange={(iso) => setPayment({ ...payment, paidAt: iso })} />
                  </div>
                  <div className="space-y-1">
                    <Label className="text-[11px]">شرح</Label>
                    <Input value={payment.note} onChange={(e) => setPayment({ ...payment, note: e.target.value })} />
                  </div>
                </div>
                <Button className="w-full mt-2" onClick={addPayment} disabled={saving}>
                  <Plus className="w-4 h-4 me-1" />
                  {saving ? "در حال ثبت…" : "ثبت پرداخت"}
                </Button>
              </div>
            </>
          )}
        </DialogContent>
      </Dialog>
    </div>
  );
}
