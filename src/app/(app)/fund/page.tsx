"use client";

/**
 * صفحه خزانه — بازسازی Areas/Fund/Views/Home/Index.cshtml محصول CRMIdeal
 *
 * ساختار اصلی:
 *  ┌─ هدر آبی (فرم رسید/پرداخت خزانه)
 *  ├─ ستون راست: درخت گروه‌های خزانه (_PartialFundGroupTree)
 *  ├─ فیلترها: کاربر، از تاریخ، تا تاریخ، گروه (FundCrmUser/FundFromDate/FundToDate/FundGroup)
 *  ├─ جدول اسناد: ردیف، شماره، تاریخ، گروه، دریافت وجه، پرداخت وجه، وضعیت، توضیح
 *  └─ فوتر: جمع دریافت / پرداخت / مانده (GetFundSumFooter)
 */

import { useCallback, useEffect, useMemo, useState } from "react";
import {
  Wallet, Plus, Pencil, Trash2, CheckCircle2, Undo2, ChevronLeft, FolderTree,
  ArrowDownToLine, ArrowUpFromLine,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { JalaliDateInput } from "@/components/rasta/jalali-date-input";
import { useList, api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { formatJalali, toPersianDigits } from "@/lib/jalali";
import { FUND_TRANSACTION_TYPE_LABELS } from "@/lib/constants";
import { cn } from "@/lib/utils";

type FundGroup = {
  id: string; name: string; parentId: string | null; order: number;
  _count?: { transactions: number };
};

type FundTx = {
  id: string; number: number; date: string; type: "RECEIVE" | "PAY";
  amount: number; description: string | null; isVerified: boolean;
  verifiedAt: string | null;
  group: { id: string; name: string };
  custodian: { id: string; firstName: string; lastName: string };
  verifier: { id: string; firstName: string; lastName: string } | null;
};

type FundList = {
  rows: FundTx[]; total: number;
  footer: { totalReceive: number; totalPay: number; remain: number };
};

const emptyForm = {
  id: "",
  groupId: "",
  type: "RECEIVE" as "RECEIVE" | "PAY",
  amount: "",
  date: new Date().toISOString().slice(0, 10),
  description: "",
};

export default function FundPage() {
  const { toast } = useToast();
  const [groups, setGroups] = useState<FundGroup[]>([]);
  const [selectedGroup, setSelectedGroup] = useState<string>("all");
  const [typeFilter, setTypeFilter] = useState<string>("all");
  const [verifiedFilter, setVerifiedFilter] = useState<string>("all");
  const [fromDate, setFromDate] = useState<string | null>(null);
  const [toDate, setToDate] = useState<string | null>(null);
  const [page, setPage] = useState(1);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    api<{ rows: FundGroup[] }>("/api/fund/groups")
      .then((r) => setGroups(r.rows))
      .catch(() => {});
  }, []);

  const url = useMemo(() => {
    const p = new URLSearchParams({ page: String(page), pageSize: "50" });
    if (selectedGroup !== "all") p.set("groupId", selectedGroup);
    if (typeFilter !== "all") p.set("type", typeFilter);
    if (verifiedFilter !== "all") p.set("verified", verifiedFilter);
    if (fromDate) p.set("from", fromDate);
    if (toDate) p.set("to", toDate);
    return `/api/fund/transactions?${p.toString()}`;
  }, [page, selectedGroup, typeFilter, verifiedFilter, fromDate, toDate]);

  const { rows, total, loading, refresh, data } = useList<FundTx>(url);
  const footer = (data as FundList | undefined)?.footer;

  const refreshGroups = useCallback(() => {
    api<{ rows: FundGroup[] }>("/api/fund/groups").then((r) => setGroups(r.rows)).catch(() => {});
  }, []);

  function openDialog(tx?: FundTx) {
    setForm(
      tx
        ? {
            id: tx.id,
            groupId: tx.group.id,
            type: tx.type,
            amount: String(tx.amount),
            date: tx.date.slice(0, 10),
            description: tx.description ?? "",
          }
        : {
            ...emptyForm,
            groupId: selectedGroup !== "all" ? selectedGroup : (groups[0]?.id ?? ""),
            date: new Date().toISOString().slice(0, 10),
          }
    );
    setDialogOpen(true);
  }

  async function save() {
    if (!form.groupId) return toast({ title: "گروه خزانه را انتخاب کنید.", variant: "destructive" });
    if (!(Number(form.amount) > 0)) return toast({ title: "مبلغ معتبر وارد کنید.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/fund/transactions", {
        method: form.id ? "PATCH" : "POST",
        body: {
          id: form.id || undefined,
          groupId: form.groupId,
          type: form.type,
          amount: Number(form.amount),
          date: form.date,
          description: form.description,
        },
      });
      toast({ title: form.id ? "سند خزانه ویرایش شد." : "سند خزانه ثبت شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function verify(tx: FundTx, action: "verify" | "unverify") {
    try {
      await api("/api/fund/transactions", { method: "PATCH", body: { id: tx.id, action } });
      toast({ title: action === "verify" ? "سند تایید شد." : "تایید سند لغو شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function remove(tx: FundTx) {
    if (!confirm(`حذف سند شماره ${toPersianDigits(tx.number)}؟`)) return;
    try {
      await api(`/api/fund/transactions?id=${tx.id}`, { method: "DELETE" });
      toast({ title: "سند حذف شد." });
      refresh();
      refreshGroups();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<FundTx>[] = [
    { key: "number", header: "شماره", render: (t) => <span className="font-bold">{toPersianDigits(t.number)}</span> },
    { key: "date", header: "تاریخ", render: (t) => formatJalali(t.date, true) },
    { key: "group", header: "گروه", render: (t) => t.group.name },
    {
      key: "receive",
      header: "دریافت وجه",
      render: (t) =>
        t.type === "RECEIVE" ? (
          <span className="font-semibold text-[#0e7a3d]">{formatMoney(t.amount)}</span>
        ) : (
          <span className="text-muted-foreground">—</span>
        ),
    },
    {
      key: "pay",
      header: "پرداخت وجه",
      render: (t) =>
        t.type === "PAY" ? (
          <span className="font-semibold text-[#c0392b]">{formatMoney(t.amount)}</span>
        ) : (
          <span className="text-muted-foreground">—</span>
        ),
    },
    {
      key: "status",
      header: "وضعیت",
      render: (t) =>
        t.isVerified ? (
          <span className="inline-flex items-center gap-1 text-[12px] text-[#0e7a3d]">
            <CheckCircle2 className="w-3.5 h-3.5" />
            تاییدشده
          </span>
        ) : (
          <span className="inline-flex items-center gap-1 text-[12px] text-[#b8860b]">
            <Undo2 className="w-3.5 h-3.5" />
            در انتظار تایید
          </span>
        ),
    },
    { key: "description", header: "توضیحات", render: (t) => <span className="text-muted-foreground text-[13px]">{t.description ?? "—"}</span> },
    {
      key: "actions",
      header: "عملیات",
      render: (t) => (
        <div className="flex items-center gap-1">
          <Button variant="ghost" size="icon" className="w-7 h-7" onClick={() => openDialog(t)} title="ویرایش">
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          {t.isVerified ? (
            <Button variant="ghost" size="icon" className="w-7 h-7 text-[#b8860b]" onClick={() => verify(t, "unverify")} title="لغو تایید">
              <Undo2 className="w-3.5 h-3.5" />
            </Button>
          ) : (
            <Button variant="ghost" size="icon" className="w-7 h-7 text-[#0e7a3d]" onClick={() => verify(t, "verify")} title="تایید">
              <CheckCircle2 className="w-3.5 h-3.5" />
            </Button>
          )}
          <Button variant="ghost" size="icon" className="w-7 h-7 text-destructive" onClick={() => remove(t)} title="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <PageHeader
        title="فرم رسید و پرداخت خزانه"
        subtitle="گردش نقدینگی، تایید اسناد و مانده خزانه"
        icon={<Wallet className="w-4 h-4" />}
        actions={
          <Button
            onClick={() => openDialog()}
            className="bg-white text-[#528fcc] hover:bg-[#eef4fb] rounded-full text-[13px] gap-1.5"
          >
            <Plus className="w-4 h-4" />
            درج سند خزانه
          </Button>
        }
      />

      <div className="grid grid-cols-12 gap-4">
        {/* درخت گروه‌ها (ستون راست مثل _PartialFundGroupTree) */}
        <aside className="col-span-12 lg:col-span-3">
          <div className="crm-section overflow-hidden">
            <div className="crm-section-header px-4 py-2.5 flex items-center gap-2">
              <FolderTree className="w-4 h-4" />
              <h6 className="text-[14px] font-semibold">گروه‌های خزانه</h6>
            </div>
            <div className="p-2">
              <button
                type="button"
                onClick={() => { setSelectedGroup("all"); setPage(1); }}
                className={cn(
                  "w-full text-right px-3 py-2 rounded-md text-[13.5px] transition-colors",
                  selectedGroup === "all" ? "bg-[#e7effc] text-[#012875] font-medium" : "hover:bg-[#f4f6fa]"
                )}
              >
                همه گروه‌ها
              </button>
              <GroupTree
                groups={groups}
                parentId={null}
                depth={0}
                selectedId={selectedGroup}
                onSelect={(id) => { setSelectedGroup(id); setPage(1); }}
              />
            </div>
          </div>
        </aside>

        {/* اسناد خزانه */}
        <section className="col-span-12 lg:col-span-9">
          <div className="crm-section">
            {/* فیلترها مثل فرم اصلی: کاربر/از تاریخ/تا تاریخ/گروه */}
            <div className="flex flex-wrap items-end gap-3 p-3 border-b border-[#eef1f7]">
              <div className="flex flex-col gap-1">
                <Label className="text-[12px] text-muted-foreground">از تاریخ</Label>
                <JalaliDateInput value={fromDate} onChange={(v) => { setFromDate(v); setPage(1); }} />
              </div>
              <div className="flex flex-col gap-1">
                <Label className="text-[12px] text-muted-foreground">تا تاریخ</Label>
                <JalaliDateInput value={toDate} onChange={(v) => { setToDate(v); setPage(1); }} />
              </div>
              <div className="flex flex-col gap-1">
                <Label className="text-[12px] text-muted-foreground">نوع سند</Label>
                <select
                  value={typeFilter}
                  onChange={(e) => { setTypeFilter(e.target.value); setPage(1); }}
                  className="h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
                >
                  <option value="all">همه</option>
                  <option value="RECEIVE">دریافت وجه</option>
                  <option value="PAY">پرداخت وجه</option>
                </select>
              </div>
              <div className="flex flex-col gap-1">
                <Label className="text-[12px] text-muted-foreground">وضعیت تایید</Label>
                <select
                  value={verifiedFilter}
                  onChange={(e) => { setVerifiedFilter(e.target.value); setPage(1); }}
                  className="h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
                >
                  <option value="all">همه</option>
                  <option value="1">تاییدشده</option>
                  <option value="0">در انتظار تایید</option>
                </select>
              </div>
            </div>

            <DataTable
              columns={columns}
              rows={rows}
              loading={loading}
              page={page}
              pageSize={50}
              total={total}
              onPageChange={setPage}
              emptyText="سندی در این بازه یافت نشد."
            />

            {/* فوتر جمع (GetFundSumFooter) */}
            {footer ? (
              <div className="grid grid-cols-3 border-t border-[#eef1f7] text-center divide-x divide-x-reverse divide-[#eef1f7]">
                <div className="py-3">
                  <div className="text-[12px] text-muted-foreground">جمع دریافت وجه</div>
                  <div className="text-[15px] font-bold text-[#0e7a3d] mt-0.5">
                    {formatMoney(footer.totalReceive)} ریال
                  </div>
                </div>
                <div className="py-3">
                  <div className="text-[12px] text-muted-foreground">جمع پرداخت وجه</div>
                  <div className="text-[15px] font-bold text-[#c0392b] mt-0.5">
                    {formatMoney(footer.totalPay)} ریال
                  </div>
                </div>
                <div className="py-3 bg-[#e7effc]/60">
                  <div className="text-[12px] text-[#012875]">مانده خزانه</div>
                  <div className="text-[15px] font-bold text-[#012875] mt-0.5">
                    {formatMoney(footer.remain)} ریال
                  </div>
                </div>
              </div>
            ) : null}
          </div>
        </section>
      </div>

      {/* دیالوگ درج/ویرایش سند (InsertEdit) */}
      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="sm:max-w-md">
          <DialogHeader>
            <DialogTitle>{form.id ? "ویرایش سند خزانه" : "درج سند خزانه"}</DialogTitle>
          </DialogHeader>
          <div className="space-y-4">
            {/* نوع سند: دو دکمه دریافت/پرداخت */}
            <div className="grid grid-cols-2 gap-2">
              {(["RECEIVE", "PAY"] as const).map((t) => (
                <button
                  key={t}
                  type="button"
                  onClick={() => setForm((f) => ({ ...f, type: t }))}
                  className={cn(
                    "flex items-center justify-center gap-2 rounded-lg py-2.5 text-[14px] border-2 transition-colors",
                    form.type === t
                      ? t === "RECEIVE"
                        ? "border-[#0e7a3d] bg-[#e8f5ee] text-[#0e7a3d]"
                        : "border-[#c0392b] bg-[#fdecea] text-[#c0392b]"
                      : "border-[#e5e9f2] text-muted-foreground hover:border-[#8598be]"
                  )}
                >
                  {t === "RECEIVE" ? (
                    <ArrowDownToLine className="w-4 h-4" />
                  ) : (
                    <ArrowUpFromLine className="w-4 h-4" />
                  )}
                  {FUND_TRANSACTION_TYPE_LABELS[t]}
                </button>
              ))}
            </div>

            <div className="space-y-1.5">
              <Label>گروه خزانه</Label>
              <select
                value={form.groupId}
                onChange={(e) => setForm((f) => ({ ...f, groupId: e.target.value }))}
                className="w-full h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
              >
                <option value="">— انتخاب کنید —</option>
                {groups.map((g) => (
                  <option key={g.id} value={g.id}>
                    {g.parentId ? `— ${g.name}` : g.name}
                  </option>
                ))}
              </select>
            </div>

            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-1.5">
                <Label>مبلغ (ریال)</Label>
                <Input
                  value={form.amount}
                  onChange={(e) => setForm((f) => ({ ...f, amount: e.target.value }))}
                  placeholder="۰"
                  dir="ltr"
                  className="text-right"
                />
              </div>
              <div className="space-y-1.5">
                <Label>تاریخ سند</Label>
                <JalaliDateInput
                  value={form.date}
                  onChange={(v) => setForm((f) => ({ ...f, date: v ?? new Date().toISOString().slice(0, 10) }))}
                />
              </div>
            </div>

            <div className="space-y-1.5">
              <Label>توضیحات</Label>
              <Input
                value={form.description}
                onChange={(e) => setForm((f) => ({ ...f, description: e.target.value }))}
                placeholder="شرح سند خزانه…"
              />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving} className="bg-[#012875] hover:bg-[#0a3a8f]">
              {saving ? "در حال ذخیره…" : "ذخیره"}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}

/* درخت گروه‌ها — رندر بازگشتی با تورفتگی مثل درخت محصول اصلی */
function GroupTree({
  groups,
  parentId,
  depth,
  selectedId,
  onSelect,
}: {
  groups: FundGroup[];
  parentId: string | null;
  depth: number;
  selectedId: string;
  onSelect: (id: string) => void;
}) {
  const children = groups
    .filter((g) => (g.parentId ?? null) === parentId)
    .sort((a, b) => a.order - b.order);
  if (children.length === 0) return null;

  return (
    <div className={depth > 0 ? "mr-3 border-r border-[#e5e9f2] pr-1" : ""}>
      {children.map((g) => (
        <div key={g.id}>
          <button
            type="button"
            onClick={() => onSelect(g.id)}
            className={cn(
              "w-full flex items-center gap-1.5 text-right px-3 py-1.5 rounded-md text-[13px] transition-colors",
              selectedId === g.id ? "bg-[#e7effc] text-[#012875] font-medium" : "hover:bg-[#f4f6fa]"
            )}
          >
            {g.parentId ? <ChevronLeft className="w-3 h-3 text-[#8598be]" /> : null}
            <span className="flex-1 truncate">{g.name}</span>
            {g._count ? (
              <span className="text-[10px] text-[#8596bd]">{toPersianDigits(g._count.transactions)}</span>
            ) : null}
          </button>
          <GroupTree groups={groups} parentId={g.id} depth={depth + 1} selectedId={selectedId} onSelect={onSelect} />
        </div>
      ))}
    </div>
  );
}
