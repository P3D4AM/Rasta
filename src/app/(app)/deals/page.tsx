"use client";

import { useMemo, useState } from "react";
import { Search, Plus, LayoutGrid, List, ArrowLeft, ArrowRight, Trash2, ChevronLeft } from "lucide-react";
import Link from "next/link";
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
import {
  DEAL_STAGES, DEAL_STAGE_LABELS, PRIORITIES, PRIORITY_LABELS,
} from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Deal = {
  id: string; title: string; stage: string; amount: number | null;
  probability: number | null; priority: string; expectedCloseAt: string | null;
  company: { id: string; name: string };
  contact: { firstName: string; lastName: string } | null;
  owner: { firstName: string; lastName: string } | null;
};

type StageInfo = { count: number; sum: number };

const emptyForm = {
  id: "", title: "", companyId: "", contactId: "", stage: "NEW",
  amount: "", probability: "", priority: "NORMAL", expectedCloseAt: null as string | null,
};

export default function DealsPage() {
  const { toast } = useToast();
  const [view, setView] = useState<"board" | "list">("board");
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [stageFilter, setStageFilter] = useState("ALL");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);
  const [companies, setCompanies] = useState<{ id: string; name: string; contacts: { id: string; firstName: string; lastName: string }[] }[]>([]);

  const url = useMemo(
    () => `/api/deals?page=${page}&search=${encodeURIComponent(search)}&stage=${stageFilter}&pageSize=${view === "board" ? 200 : 20}`,
    [page, search, stageFilter, view]
  );
  const { rows, total, loading, refresh, error } = useList<Deal & { stages?: Record<string, StageInfo> }>(url);
  const stagesMeta = (rows as never as { stages?: Record<string, StageInfo> }) as never;
  const [stageInfo, setStageInfo] = useState<Record<string, StageInfo>>({});

  // fetch stage aggregates separately for the board view
  useMemo(() => {
    fetch("/api/deals?stage=ALL&pageSize=1")
      .then((r) => r.json())
      .then((d) => setStageInfo(d.stages ?? {}))
      .catch(() => {});
  }, [total]);

  async function openDialog() {
    const res = await fetch("/api/companies?pageSize=200");
    const data = await res.json();
    setCompanies(
      (data.rows ?? []).map((c: { id: string; name: string; contacts?: unknown[] }) => ({
        id: c.id,
        name: c.name,
        contacts: [],
      }))
    );
    setForm(emptyForm);
    setDialogOpen(true);
  }

  async function save() {
    if (!form.title.trim()) return toast({ title: "عنوان الزامی است.", variant: "destructive" });
    if (!form.companyId) return toast({ title: "انتخاب شرکت الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/deals", { method: "POST", body: form });
      toast({ title: "فرصت جدید ایجاد شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function moveStage(id: string, stage: string) {
    try {
      await api("/api/deals", { method: "PATCH", body: { id, stage } });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function remove(d: Deal) {
    if (!confirm(`حذف فرصت «${d.title}»؟`)) return;
    try {
      await api(`/api/deals/${d.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const columns: Column<Deal>[] = [
    {
      key: "title",
      header: "عنوان",
      render: (d) => (
        <div>
          <p className="font-bold">{d.title}</p>
          <Link href={`/companies/${d.company.id}`} className="text-xs text-muted-foreground hover:text-primary">
            {d.company.name}
          </Link>
        </div>
      ),
    },
    { key: "amount", header: "مبلغ", render: (d) => <span>{formatMoney(d.amount)}</span> },
    {
      key: "stage",
      header: "مرحله",
      render: (d) => <StatusBadge value={d.stage} label={DEAL_STAGE_LABELS[d.stage] ?? d.stage} />,
    },
    {
      key: "owner",
      header: "مسئول",
      render: (d) => (
        <span className="text-muted-foreground text-xs">
          {d.owner ? `${d.owner.firstName} ${d.owner.lastName}` : "—"}
        </span>
      ),
    },
    { key: "due", header: "پیش‌بینی بستن", render: (d) => <span className="text-muted-foreground text-xs">{formatDate(d.expectedCloseAt)}</span> },
    {
      key: "actions",
      header: "",
      className: "w-20 text-end",
      render: (d) => (
        <div className="flex justify-end" onClick={(e) => e.stopPropagation()}>
          <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(d)} aria-label="حذف">
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  const selectedCompany = companies.find((c) => c.id === form.companyId);

  return (
    <div>
      <PageHeader
        title="فرصت‌های فروش"
        subtitle={`${toPersianDigits(total)} فرصت`}
        actions={
          <div className="flex gap-2">
            <div className="flex rounded-lg border overflow-hidden">
              <button
                className={`px-3 py-2 text-xs font-bold flex items-center gap-1 ${view === "board" ? "bg-primary text-primary-foreground" : ""}`}
                onClick={() => setView("board")}
                aria-label="نمای بورد"
              >
                <LayoutGrid className="w-3.5 h-3.5" />بورد
              </button>
              <button
                className={`px-3 py-2 text-xs font-bold flex items-center gap-1 ${view === "list" ? "bg-primary text-primary-foreground" : ""}`}
                onClick={() => setView("list")}
                aria-label="نمای لیست"
              >
                <List className="w-3.5 h-3.5" />لیست
              </button>
            </div>
            <Button onClick={openDialog}>
              <Plus className="w-4 h-4 me-1" />
              فرصت جدید
            </Button>
          </div>
        }
      />

      {view === "list" ? (
        <>
          <div className="flex flex-col sm:flex-row gap-2 mb-4">
            <form className="flex-1" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
              <div className="relative max-w-md">
                <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
                <Input className="ps-9" placeholder="جستجو…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
              </div>
            </form>
            <Select value={stageFilter} onValueChange={(v) => { setStageFilter(v); setPage(1); }}>
              <SelectTrigger className="w-full sm:w-44"><SelectValue /></SelectTrigger>
              <SelectContent>
                <SelectItem value="ALL">همه مراحل</SelectItem>
                {DEAL_STAGES.map((s) => (
                  <SelectItem key={s} value={s}>{DEAL_STAGE_LABELS[s]}</SelectItem>
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
          />
        </>
      ) : (
        <div className="overflow-x-auto pb-4">
          <div className="flex gap-4 min-w-max">
            {DEAL_STAGES.map((stage) => {
              const deals = (rows as Deal[]).filter((d) => d.stage === stage);
              const info = stageInfo[stage] ?? { count: 0, sum: 0 };
              const idx = DEAL_STAGES.indexOf(stage);
              return (
                <div key={stage} className="w-72 shrink-0">
                  <div className="flex items-center justify-between px-3 py-2 rounded-t-xl bg-muted font-bold text-sm">
                    <span>{DEAL_STAGE_LABELS[stage]}</span>
                    <span className="text-xs text-muted-foreground">
                      {toPersianDigits(info.count || deals.length)}
                    </span>
                  </div>
                  <div className="rounded-b-xl bg-muted/40 border border-t-0 p-2 min-h-[300px] space-y-2">
                    {deals.length === 0 && (
                      <p className="text-xs text-muted-foreground text-center py-6">خالی</p>
                    )}
                    {deals.map((d) => (
                      <div key={d.id} className="bg-card border rounded-lg p-3 shadow-sm hover:shadow transition-shadow">
                        <p className="text-sm font-bold line-clamp-2">{d.title}</p>
                        <Link href={`/companies/${d.company.id}`} className="text-[11px] text-muted-foreground hover:text-primary mt-1 block truncate">
                          {d.company.name}
                        </Link>
                        <div className="flex items-center justify-between mt-2">
                          <span className="text-xs font-bold text-primary">{formatMoney(d.amount)}</span>
                          {d.priority !== "NORMAL" && (
                            <StatusBadge value={d.priority} label={PRIORITY_LABELS[d.priority]} />
                          )}
                        </div>
                        {idx < 5 && (
                          <div className="flex justify-between mt-2 pt-2 border-t">
                            <button
                              className="text-[11px] text-muted-foreground hover:text-foreground flex items-center gap-0.5 disabled:opacity-30"
                              onClick={() => moveStage(d.id, DEAL_STAGES[Math.max(0, idx - 1)])}
                              disabled={idx === 0}
                              aria-label="مرحله قبل"
                            >
                              <ArrowRight className="w-3 h-3" />قبلی
                            </button>
                            <button
                              className="text-[11px] text-primary hover:underline flex items-center gap-0.5"
                              onClick={() => moveStage(d.id, DEAL_STAGES[idx + 1])}
                              aria-label="مرحله بعد"
                            >
                              بعدی<ArrowLeft className="w-3 h-3" />
                            </button>
                          </div>
                        )}
                      </div>
                    ))}
                  </div>
                </div>
              );
            })}
          </div>
        </div>
      )}

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-xl">
          <DialogHeader>
            <DialogTitle>فرصت فروش جدید</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5 sm:col-span-2">
              <Label>عنوان *</Label>
              <Input value={form.title} onChange={(e) => setForm({ ...form, title: e.target.value })} placeholder="مثلاً تأمین تجهیزات شبکه" />
            </div>
            <div className="space-y-1.5">
              <Label>شرکت *</Label>
              <Select value={form.companyId} onValueChange={(v) => setForm({ ...form, companyId: v, contactId: "" })}>
                <SelectTrigger><SelectValue placeholder="انتخاب شرکت" /></SelectTrigger>
                <SelectContent>
                  {companies.map((c) => (
                    <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>مرحله</Label>
              <Select value={form.stage} onValueChange={(v) => setForm({ ...form, stage: v })}>
                <SelectTrigger><SelectValue /></SelectTrigger>
                <SelectContent>
                  {DEAL_STAGES.map((s) => (
                    <SelectItem key={s} value={s}>{DEAL_STAGE_LABELS[s]}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>مبلغ (ریال)</Label>
              <Input dir="ltr" type="number" value={form.amount} onChange={(e) => setForm({ ...form, amount: e.target.value })} placeholder="مثلاً 1200000000" />
            </div>
            <div className="space-y-1.5">
              <Label>احتمال موفقیت (٪)</Label>
              <Input dir="ltr" type="number" min={0} max={100} value={form.probability} onChange={(e) => setForm({ ...form, probability: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>اولویت</Label>
              <Select value={form.priority} onValueChange={(v) => setForm({ ...form, priority: v })}>
                <SelectTrigger><SelectValue /></SelectTrigger>
                <SelectContent>
                  {PRIORITIES.map((p) => (
                    <SelectItem key={p} value={p}>{PRIORITY_LABELS[p]}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>پیش‌بینی بستن</Label>
              <JalaliDateInput value={form.expectedCloseAt} onChange={(iso) => setForm({ ...form, expectedCloseAt: iso })} />
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
