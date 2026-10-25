"use client";

import { use, useEffect, useState } from "react";
import Link from "next/link";
import { ArrowRight, Printer, Repeat } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { useToast } from "@/hooks/use-toast";
import { StatusBadge } from "@/components/rasta/status-badge";
import { api } from "@/hooks/use-list";
import { formatMoney, formatDate, formatDateTime } from "@/lib/format";
import { QUOTATION_STATUS_LABELS } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type QuotationDetail = {
  id: string; number: number; status: string; issueDate: string; validUntil: string | null;
  note: string | null; subtotal: number; discountTotal: number; taxTotal: number; total: number;
  company: { id: string; name: string; address: string | null; phone: string | null };
  contact: { firstName: string; lastName: string } | null;
  deal: { id: string; title: string } | null;
  owner: { firstName: string; lastName: string } | null;
  items: {
    id: string; qty: number; unitPrice: number; discount: number; taxRate: number; lineTotal: number;
    description: string | null;
    product: { name: string; unit: string } | null;
  }[];
  orders: { id: string; number: number; status: string }[];
};

export default function QuotationDetailPage({
  params,
}: {
  params: Promise<{ id: string }>;
}) {
  const { id } = use(params);
  const { toast } = useToast();
  const [q, setQ] = useState<QuotationDetail | null>(null);
  const [notFound, setNotFound] = useState(false);

  useEffect(() => {
    api<QuotationDetail>(`/api/quotations/${id}`).then(setQ).catch(() => setNotFound(true));
  }, [id]);

  async function convert() {
    if (!confirm("تبدیل به فاکتور فروش؟")) return;
    try {
      await api(`/api/quotations/${id}`, { method: "PATCH", body: { action: "convert" } });
      toast({ title: "فاکتور صادر شد." });
      const updated = await api<QuotationDetail>(`/api/quotations/${id}`);
      setQ(updated);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  if (notFound) return <div className="text-center py-20 text-muted-foreground">پیش‌فاکتور یافت نشد.</div>;
  if (!q) return <div className="text-center py-20 text-muted-foreground">در حال بارگذاری…</div>;

  return (
    <div className="max-w-4xl mx-auto">
      <div className="flex items-center gap-2 mb-4 text-sm">
        <Link href="/quotations" className="text-muted-foreground hover:text-foreground flex items-center gap-1">
          <ArrowRight className="w-4 h-4" />پیش‌فاکتورها
        </Link>
        <span className="text-muted-foreground">/</span>
        <span className="font-medium">شماره {toPersianDigits(q.number)}</span>
      </div>

      <Card className="print:shadow-none">
        <CardContent className="p-6 sm:p-8">
          {/* header */}
          <div className="flex justify-between items-start pb-6 border-b">
            <div>
              <h1 className="text-xl font-extrabold mb-1">پیش‌فاکتور فروش</h1>
              <p className="text-sm text-muted-foreground">شماره: {toPersianDigits(q.number)}</p>
              <p className="text-sm text-muted-foreground">تاریخ صدور: {formatDate(q.issueDate)}</p>
              {q.validUntil && <p className="text-sm text-muted-foreground">اعتبار تا: {formatDate(q.validUntil)}</p>}
              {q.deal && <p className="text-xs text-muted-foreground mt-1">فرصت مرتبط: {q.deal.title}</p>}
            </div>
            <div className="text-end">
              <div className="w-20 h-20 rounded-xl bg-primary text-primary-foreground flex items-center justify-center font-black text-3xl mb-2">
                ر
              </div>
              <StatusBadge value={q.status} label={QUOTATION_STATUS_LABELS[q.status] ?? q.status} />
            </div>
          </div>

          {/* buyer */}
          <div className="py-5 border-b">
            <p className="text-xs text-muted-foreground mb-1">خریدار:</p>
            <Link href={`/companies/${q.company.id}`} className="text-base font-extrabold hover:text-primary">
              {q.company.name}
            </Link>
            {q.contact && <p className="text-sm text-muted-foreground mt-0.5"> Attention: {q.contact.firstName} {q.contact.lastName}</p>}
            {q.company.address && <p className="text-xs text-muted-foreground">{q.company.address}</p>}
            {q.company.phone && <p className="text-xs text-muted-foreground" dir="ltr">{toPersianDigits(q.company.phone)}</p>}
          </div>

          {/* items */}
          <table className="w-full text-sm my-5">
            <thead>
              <tr className="bg-muted text-xs">
                <th className="p-2.5 text-start rounded-s-lg">ردیف</th>
                <th className="p-2.5 text-start">شرح کالا</th>
                <th className="p-2.5">تعداد</th>
                <th className="p-2.5">فی (ریال)</th>
                <th className="p-2.5">تخفیف</th>
                <th className="p-2.5">مالیات</th>
                <th className="p-2.5 rounded-e-lg">جمع (ریال)</th>
              </tr>
            </thead>
            <tbody>
              {q.items.map((it, i) => (
                <tr key={it.id} className="border-b">
                  <td className="p-2.5 text-center text-muted-foreground">{toPersianDigits(i + 1)}</td>
                  <td className="p-2.5 font-medium">
                    {it.product?.name ?? it.description ?? "—"}
                    {it.product && <span className="text-xs text-muted-foreground ms-1">({it.product.unit})</span>}
                  </td>
                  <td className="p-2.5 text-center">{toPersianDigits(it.qty)}</td>
                  <td className="p-2.5 text-center">{formatMoney(it.unitPrice)}</td>
                  <td className="p-2.5 text-center text-amber-600">{formatMoney(it.discount)}</td>
                  <td className="p-2.5 text-center">٪{toPersianDigits(it.taxRate)}</td>
                  <td className="p-2.5 text-center font-bold">{formatMoney(it.lineTotal)}</td>
                </tr>
              ))}
            </tbody>
          </table>

          {/* totals */}
          <div className="flex justify-end">
            <div className="w-72 space-y-1.5">
              <Row label="جمع کل" value={`${formatMoney(q.subtotal)} ریال`} />
              <Row label="تخفیف" value={`${formatMoney(q.discountTotal)} ریال`} />
              <Row label="مالیات" value={`${formatMoney(q.taxTotal)} ریال`} />
              <div className="flex justify-between bg-primary text-primary-foreground rounded-lg px-3 py-2 font-extrabold">
                <span>مبلغ نهایی</span>
                <span>{formatMoney(q.total)} ریال</span>
              </div>
            </div>
          </div>

          {q.note && (
            <p className="text-xs text-muted-foreground mt-5 border-t pt-3">
              <strong>یادداشت: </strong>
              {q.note}
            </p>
          )}
        </CardContent>
      </Card>

      <div className="flex gap-2 mt-4 print:hidden">
        <Button variant="outline" onClick={() => window.print()}>
          <Printer className="w-4 h-4 me-1" />چاپ
        </Button>
        {q.status !== "CONVERTED" && (
          <Button onClick={convert}>
            <Repeat className="w-4 h-4 me-1" />
            تبدیل به فاکتور فروش
          </Button>
        )}
        {q.orders.length > 0 && (
          <span className="self-center text-xs text-muted-foreground">
            فاکتور {toPersianDigits(q.orders[0].number)} از این پیش‌فاکتور صادر شده است.
          </span>
        )}
      </div>
    </div>
  );
}

function Row({ label, value }: { label: string; value: string }) {
  return (
    <div className="flex justify-between px-3 py-1.5 text-sm">
      <span className="text-muted-foreground">{label}</span>
      <span className="font-bold">{value}</span>
    </div>
  );
}
