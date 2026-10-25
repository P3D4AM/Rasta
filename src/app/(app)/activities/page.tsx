"use client";

import { useMemo, useState } from "react";
import { Search, Plus, Trash2, Pencil, Clock } from "lucide-react";
import { useSearchParams } from "next/navigation";
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
import { StatusBadge } from "@/components/rasta/status-badge";
import { JalaliDateInput } from "@/components/rasta/jalali-date-input";
import { useList, api } from "@/hooks/use-list";
import { formatDateTime } from "@/lib/format";
import { ACTIVITY_TYPES, ACTIVITY_TYPE_LABELS } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Activity = {
  id: string; type: string; direction: string | null; subject: string;
  body: string | null; occurredAt: string; nextStep: string | null; nextAt: string | null;
  user: { firstName: string; lastName: string };
  company: { id: string; name: string } | null;
  deal: { id: string; title: string } | null;
};

const emptyForm = {
  id: "", type: "CALL", direction: "OUTGOING", subject: "", body: "",
  companyId: "", dealId: "", occurredAt: null as string | null,
  nextStep: "", nextAt: null as string | null,
};

export default function ActivitiesPage() {
  const { toast } = useToast();
  const sp = useSearchParams();
  const companyParam = sp.get("companyId");
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [typeFilter, setTypeFilter] = useState("ALL");
  const [mineOnly, setMineOnly] = useState(false);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);
  const [companies, setCompanies] = useState<{ id: string; name: string }[]>([]);

  const url = useMemo(
    () =>
      `/api/activities?page=${page}&search=${encodeURIComponent(search)}&type=${typeFilter}` +
      `&mine=${mineOnly ? 1 : 0}${companyParam ? `&companyId=${companyParam}` : ""}`,
    [page, search, typeFilter, mineOnly, companyParam]
  );
  const { rows, total, loading, refresh } = useList<Activity>(url);

  async function openDialog() {
    const res = await fetch("/api/companies?pageSize=200");
    const data = await res.json();
    setCompanies(data.rows ?? []);
    setForm({ ...emptyForm, companyId: companyParam ?? "" });
    setDialogOpen(true);
  }

  async function save() {
    if (!form.subject.trim()) return toast({ title: "موضوع الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/activities", { method: "POST", body: form });
      toast({ title: "فعالیت ثبت شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(a: Activity) {
    if (!confirm("حذف این فعالیت؟")) return;
    try {
      await api(`/api/activities/${a.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  return (
    <div>
      <PageHeader
        title="فعالیت‌ها"
        subtitle={`${toPersianDigits(total)} سجل تعامل`}
        actions={
          <Button onClick={openDialog}>
            <Plus className="w-4 h-4 me-1" />
            ثبت فعالیت
          </Button>
        }
      />

      <div className="flex flex-col sm:flex-row gap-2 mb-4">
        <form className="flex-1" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
          <div className="relative max-w-md">
            <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
            <Input className="ps-9" placeholder="جستجو در موضوع…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
          </div>
        </form>
        <Select value={typeFilter} onValueChange={(v) => { setTypeFilter(v); setPage(1); }}>
          <SelectTrigger className="w-full sm:w-40"><SelectValue /></SelectTrigger>
          <SelectContent>
            <SelectItem value="ALL">همه انواع</SelectItem>
            {ACTIVITY_TYPES.map((t) => (
              <SelectItem key={t} value={t}>{ACTIVITY_TYPE_LABELS[t]}</SelectItem>
            ))}
          </SelectContent>
        </Select>
        <Button
          variant={mineOnly ? "default" : "outline"}
          onClick={() => { setMineOnly(!mineOnly); setPage(1); }}
        >
          فقط من
        </Button>
      </div>

      <div className="rounded-xl border bg-card overflow-hidden">
        {loading ? (
          <p className="text-center py-14 text-muted-foreground text-sm">در حال بارگذاری…</p>
        ) : rows.length === 0 ? (
          <p className="text-center py-14 text-muted-foreground text-sm">فعالیتی یافت نشد.</p>
        ) : (
          rows.map((a) => (
            <div key={a.id} className="flex items-start gap-4 px-5 py-4 border-b last:border-0 hover:bg-muted/30 transition-colors">
              <div className="min-w-24 text-center">
                <StatusBadge value={a.type} label={ACTIVITY_TYPE_LABELS[a.type] ?? a.type} />
                {a.direction && (
                  <p className="text-[10px] text-muted-foreground mt-1">
                    {a.direction === "INCOMING" ? "ورودی" : "خروجی"}
                  </p>
                )}
              </div>
              <div className="flex-1 min-w-0">
                <p className="font-bold text-sm">{a.subject}</p>
                {a.body && <p className="text-sm text-muted-foreground mt-1 whitespace-pre-wrap">{a.body}</p>}
                <p className="text-[11px] text-muted-foreground mt-1.5 flex flex-wrap gap-x-3">
                  <span>{a.user.firstName} {a.user.lastName}</span>
                  <span>· {formatDateTime(a.occurredAt)}</span>
                  {a.company && <span>· {a.company.name}</span>}
                </p>
                {(a.nextStep || a.nextAt) && (
                  <p className="text-[11px] mt-1.5 text-primary flex items-center gap-1">
                    <Clock className="w-3 h-3" />
                    اقدام بعدی: {a.nextStep ?? "—"} {a.nextAt && `(${formatDateTime(a.nextAt)})`}
                  </p>
                )}
              </div>
              <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive shrink-0" onClick={() => remove(a)} aria-label="حذف">
                <Trash2 className="w-3.5 h-3.5" />
              </Button>
            </div>
          ))
        )}
      </div>

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-xl">
          <DialogHeader>
            <DialogTitle>ثبت فعالیت جدید</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5">
              <Label>نوع فعالیت</Label>
              <Select value={form.type} onValueChange={(v) => setForm({ ...form, type: v })}>
                <SelectTrigger><SelectValue /></SelectTrigger>
                <SelectContent>
                  {ACTIVITY_TYPES.map((t) => (
                    <SelectItem key={t} value={t}>{ACTIVITY_TYPE_LABELS[t]}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>جهت</Label>
              <Select value={form.direction ?? ""} onValueChange={(v) => setForm({ ...form, direction: v })}>
                <SelectTrigger><SelectValue /></SelectTrigger>
                <SelectContent>
                  <SelectItem value="OUTGOING">خروجی</SelectItem>
                  <SelectItem value="INCOMING">ورودی</SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5 sm:col-span-2">
              <Label>موضوع *</Label>
              <Input value={form.subject} onChange={(e) => setForm({ ...form, subject: e.target.value })} placeholder="مثلاً پیگیری پیشنهاد ارسالی" />
            </div>
            <div className="space-y-1.5 sm:col-span-2">
              <Label>شرح</Label>
              <Textarea rows={3} value={form.body} onChange={(e) => setForm({ ...form, body: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>شرکت</Label>
              <Select value={form.companyId} onValueChange={(v) => setForm({ ...form, companyId: v })}>
                <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                <SelectContent>
                  {companies.map((c) => (
                    <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-1.5">
              <Label>تاریخ</Label>
              <JalaliDateInput value={form.occurredAt} onChange={(iso) => setForm({ ...form, occurredAt: iso })} />
            </div>
            <div className="space-y-1.5">
              <Label>اقدام بعدی</Label>
              <Input value={form.nextStep} onChange={(e) => setForm({ ...form, nextStep: e.target.value })} placeholder="مثلاً ارسال قرارداد" />
            </div>
            <div className="space-y-1.5">
              <Label>سررسید اقدام بعدی</Label>
              <JalaliDateInput value={form.nextAt} onChange={(iso) => setForm({ ...form, nextAt: iso })} />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ثبت"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
