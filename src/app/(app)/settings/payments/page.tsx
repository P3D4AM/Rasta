"use client";

/**
 * تنظیمات پرداخت آنلاین — بازسازی Areas/OnlinePayment محصول CRMIdeal
 * - فعال‌سازی و پیکربندی درگاه‌ها (زرین‌پال / ملت / پارسیان)
 * - لیست پرداخت‌های آنلاین با وضعیت
 * - درج پرداخت آزمایشی (شروع جریان درگاه)
 */

import { useCallback, useEffect, useState } from "react";
import { CreditCard, Save, CheckCircle2, XCircle, Clock, Plus, Ban } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { formatJalali, toPersianDigits } from "@/lib/jalali";
import { PAYMENT_GATEWAY_LABELS, PAYMENT_GATEWAYS } from "@/lib/constants";
import { cn } from "@/lib/utils";

type GatewayCfg = {
  gateway: string;
  enabled: boolean;
  fields: Record<string, string>;
};

type OnlinePaymentRow = {
  id: string; gateway: string; amount: number; description: string | null;
  status: string; authority: string | null; refId: string | null;
  payerName: string | null; payerMobile: string | null; paidAt: string | null;
  createdAt: string;
};

const FIELD_LABELS: Record<string, string> = {
  merchantId: "مرچنت‌آی‌دی",
  sandbox: "حالت آزمایشی (sandbox)",
  terminalId: "ترمینال‌آی‌دی",
  userName: "نام کاربری",
  pin: "پین درگاه",
};

const emptyPayForm = {
  gateway: "ZARINPAL",
  amount: "",
  description: "",
  payerName: "",
  payerMobile: "",
};

export default function PaymentSettingsPage() {
  const { toast } = useToast();
  const [gateways, setGateways] = useState<GatewayCfg[]>([]);
  const [drafts, setDrafts] = useState<Record<string, GatewayCfg>>({});
  const [payments, setPayments] = useState<OnlinePaymentRow[]>([]);
  const [payDlg, setPayDlg] = useState(false);
  const [payForm, setPayForm] = useState(emptyPayForm);
  const [saving, setSaving] = useState(false);

  const load = useCallback(() => {
    api<{ gateways: GatewayCfg[] }>("/api/payments/gateways")
      .then((r) => {
        setGateways(r.gateways);
        setDrafts(Object.fromEntries(r.gateways.map((g) => [g.gateway, { ...g, fields: { ...g.fields } }])));
      })
      .catch(() => {});
    api<{ rows: OnlinePaymentRow[] }>("/api/payments/online")
      .then((r) => setPayments(r.rows))
      .catch(() => {});
  }, []);

  useEffect(load, [load]);

  function setField(gateway: string, key: string, value: string) {
    setDrafts((d) => ({
      ...d,
      [gateway]: { ...d[gateway], fields: { ...d[gateway].fields, [key]: value } },
    }));
  }

  function toggleEnabled(gateway: string, enabled: boolean) {
    setDrafts((d) => ({ ...d, [gateway]: { ...d[gateway], enabled } }));
  }

  async function saveGateway(gateway: string) {
    const draft = drafts[gateway];
    setSaving(true);
    try {
      await api("/api/payments/gateways", {
        method: "PUT",
        body: {
          gateway,
          enabled: draft.enabled,
          fields: Object.fromEntries(
            Object.entries(draft.fields).map(([k, v]) => [k, k === "sandbox" ? v : v])
          ),
        },
      });
      toast({ title: `تنظیمات ${PAYMENT_GATEWAY_LABELS[gateway]} ذخیره شد.` });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function startPayment() {
    if (!(Number(payForm.amount) > 0)) return toast({ title: "مبلغ معتبر وارد کنید.", variant: "destructive" });
    setSaving(true);
    try {
      const res = await api<{ startUrl: string }>("/api/payments/online", {
        method: "POST",
        body: { ...payForm, amount: Number(payForm.amount) },
      });
      if (res.startUrl && res.startUrl !== "#") {
        window.open(res.startUrl, "_blank");
        toast({ title: "به درگاه بانکی منتقل شدید." });
      } else {
        toast({ title: "پرداخت در حالت آزمایشی ثبت شد.", description: "برای اتصال واقعی، مرچنت‌آی‌دی معتبر وارد کنید." });
      }
      setPayDlg(false);
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function setPaymentStatus(row: OnlinePaymentRow, action: "verify" | "cancel" | "fail") {
    try {
      await api("/api/payments/online", { method: "PATCH", body: { id: row.id, action } });
      toast({ title: "وضعیت پرداخت به‌روزرسانی شد." });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<OnlinePaymentRow>[] = [
    { key: "gateway", header: "درگاه", render: (r) => PAYMENT_GATEWAY_LABELS[r.gateway] ?? r.gateway },
    { key: "amount", header: "مبلغ (ریال)", render: (r) => <span className="font-bold">{formatMoney(r.amount)}</span> },
    { key: "payer", header: "پرداخت‌کننده", render: (r) => r.payerName ?? "—" },
    {
      key: "status",
      header: "وضعیت",
      render: (r) => {
        const map: Record<string, { label: string; cls: string; Icon: typeof CheckCircle2 }> = {
          PENDING: { label: "در انتظار", cls: "text-[#b8860b]", Icon: Clock },
          VERIFIED: { label: "موفق", cls: "text-[#0e7a3d]", Icon: CheckCircle2 },
          FAILED: { label: "ناموفق", cls: "text-[#c0392b]", Icon: XCircle },
          CANCELED: { label: "لغوشده", cls: "text-muted-foreground", Icon: Ban },
        };
        const s = map[r.status] ?? map.PENDING;
        return (
          <span className={cn("inline-flex items-center gap-1 text-[12.5px] font-medium", s.cls)}>
            <s.Icon className="w-3.5 h-3.5" />
            {s.label}
          </span>
        );
      },
    },
    { key: "refId", header: "شماره مرجع", render: (r) => <span dir="ltr" className="text-[12px] text-muted-foreground">{r.refId ?? r.authority ?? "—"}</span> },
    { key: "createdAt", header: "تاریخ", render: (r) => formatJalali(r.createdAt, true) },
    {
      key: "actions",
      header: "عملیات",
      render: (r) =>
        r.status === "PENDING" ? (
          <div className="flex items-center gap-1">
            <Button variant="ghost" size="icon" className="w-7 h-7 text-[#0e7a3d]" onClick={() => setPaymentStatus(r, "verify")} title="تایید دستی">
              <CheckCircle2 className="w-3.5 h-3.5" />
            </Button>
            <Button variant="ghost" size="icon" className="w-7 h-7 text-muted-foreground" onClick={() => setPaymentStatus(r, "cancel")} title="لغو">
              <Ban className="w-3.5 h-3.5" />
            </Button>
          </div>
        ) : null,
    },
  ];

  return (
    <div>
      <PageHeader
        title="تنظیمات پرداخت آنلاین"
        subtitle="درگاه‌های زرین‌پال، ملت و پارسیان"
        icon={<CreditCard className="w-4 h-4" />}
        actions={
          <Button onClick={() => setPayDlg(true)} className="bg-white text-[#528fcc] hover:bg-[#eef4fb] rounded-full text-[13px] gap-1.5">
            <Plus className="w-4 h-4" />
            درج پرداخت آنلاین
          </Button>
        }
      />

      {/* کارت‌های درگاه */}
      <div className="grid md:grid-cols-3 gap-4">
        {PAYMENT_GATEWAYS.map((gw) => {
          const draft = drafts[gw];
          if (!draft) return null;
          return (
            <div key={gw} className="crm-section overflow-hidden">
              <div className="crm-section-header flex items-center justify-between px-4 py-2.5">
                <h6 className="text-[14px] font-semibold flex items-center gap-2">
                  <CreditCard className="w-4 h-4" />
                  {PAYMENT_GATEWAY_LABELS[gw]}
                </h6>
                {/* سوییچ فعال/غیرفعال */}
                <label className="flex items-center cursor-pointer gap-2" dir="ltr">
                  <span className="text-[11px] text-white/90">{draft.enabled ? "فعال" : "غیرفعال"}</span>
                  <span
                    className={cn(
                      "w-9 h-5 rounded-full relative transition-colors",
                      draft.enabled ? "bg-[#29b2c2]" : "bg-white/30"
                    )}
                    onClick={() => toggleEnabled(gw, !draft.enabled)}
                  >
                    <span
                      className={cn(
                        "absolute top-0.5 w-4 h-4 rounded-full bg-white transition-all",
                        draft.enabled ? "left-0.5" : "left-[18px]"
                      )}
                    />
                  </span>
                </label>
              </div>
              <div className="p-4 space-y-3">
                {Object.entries(draft.fields).map(([fieldKey, value]) => (
                  <div key={fieldKey} className="space-y-1">
                    <Label className="text-[12px] text-muted-foreground">
                      {FIELD_LABELS[fieldKey] ?? fieldKey}
                    </Label>
                    {fieldKey === "sandbox" ? (
                      <select
                        value={value || "true"}
                        onChange={(e) => setField(gw, fieldKey, e.target.value)}
                        className="w-full h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
                      >
                        <option value="true">بله (آزمایشی)</option>
                        <option value="false">خیر (واقعی)</option>
                      </select>
                    ) : (
                      <Input
                        value={value}
                        onChange={(e) => setField(gw, fieldKey, e.target.value)}
                        dir="ltr"
                        className="text-right text-[13px]"
                        placeholder="—"
                      />
                    )}
                  </div>
                ))}
                <Button
                  onClick={() => saveGateway(gw)}
                  disabled={saving}
                  className="w-full bg-[#012875] hover:bg-[#0a3a8f] text-[13px] gap-1.5"
                >
                  <Save className="w-4 h-4" />
                  ذخیره تنظیمات
                </Button>
              </div>
            </div>
          );
        })}
      </div>

      {/* لیست پرداخت‌ها */}
      <div className="crm-section mt-4">
        <div className="crm-section-header px-4 py-2.5">
          <h6 className="text-[14px] font-semibold">پرداخت‌های آنلاین</h6>
        </div>
        <DataTable
          columns={columns}
          rows={payments}
          loading={false}
          page={1}
          pageSize={100}
          total={payments.length}
          onPageChange={() => {}}
          emptyText="پرداختی ثبت نشده است."
        />
      </div>

      {/* دیالوگ درج پرداخت */}
      <Dialog open={payDlg} onOpenChange={setPayDlg}>
        <DialogContent className="sm:max-w-md">
          <DialogHeader><DialogTitle>درج پرداخت آنلاین</DialogTitle></DialogHeader>
          <div className="space-y-4">
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-1.5">
                <Label>درگاه</Label>
                <select
                  value={payForm.gateway}
                  onChange={(e) => setPayForm((f) => ({ ...f, gateway: e.target.value }))}
                  className="w-full h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
                >
                  {PAYMENT_GATEWAYS.map((g) => (
                    <option key={g} value={g}>{PAYMENT_GATEWAY_LABELS[g]}</option>
                  ))}
                </select>
              </div>
              <div className="space-y-1.5">
                <Label>مبلغ (ریال)</Label>
                <Input value={payForm.amount} onChange={(e) => setPayForm((f) => ({ ...f, amount: e.target.value }))} dir="ltr" className="text-right" />
              </div>
            </div>
            <div className="space-y-1.5">
              <Label>پرداخت‌کننده</Label>
              <Input value={payForm.payerName} onChange={(e) => setPayForm((f) => ({ ...f, payerName: e.target.value }))} />
            </div>
            <div className="space-y-1.5">
              <Label>موبایل پرداخت‌کننده</Label>
              <Input value={payForm.payerMobile} onChange={(e) => setPayForm((f) => ({ ...f, payerMobile: e.target.value }))} dir="ltr" className="text-right" placeholder="09xxxxxxxxx" />
            </div>
            <div className="space-y-1.5">
              <Label>توضیحات</Label>
              <Input value={payForm.description} onChange={(e) => setPayForm((f) => ({ ...f, description: e.target.value }))} />
            </div>
            <p className="text-[11.5px] text-muted-foreground leading-5">
              توجه: اگر درگاه فعال نباشد یا مرچنت‌آی‌دی معتبر نباشد، پرداخت در حالت آزمایشی ثبت می‌شود.
              شماره سند: {toPersianDigits(payments.length + 1)}
            </p>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setPayDlg(false)}>انصراف</Button>
            <Button onClick={startPayment} disabled={saving} className="bg-[#012875] hover:bg-[#0a3a8f]">
              {saving ? "…" : "شروع پرداخت"}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
