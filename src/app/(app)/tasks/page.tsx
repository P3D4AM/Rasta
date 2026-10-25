"use client";

import { useEffect, useMemo, useState } from "react";
import { Search, Plus, Trash2, CheckCircle2, AlertTriangle } from "lucide-react";
import Link from "next/link";
import { BellRing, Ticket } from "lucide-react";
import { Card, CardContent } from "@/components/ui/card";
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
import { formatDate } from "@/lib/format";
import { PRIORITIES, PRIORITY_LABELS, TASK_STATUS_LABELS } from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type Task = {
  id: string; title: string; description: string | null; dueAt: string | null;
  status: string; priority: string;
  assignee: { firstName: string; lastName: string };
  creator: { firstName: string; lastName: string } | null;
  company: { id: string; name: string } | null;
  deal: { id: string; title: string } | null;
};

const emptyForm = {
  id: "", title: "", description: "", dueAt: null as string | null,
  priority: "NORMAL", assigneeId: "", companyId: "",
};

type PrjReminder = {
  id: string; number: number; title: string; remindDate: string | null;
  companyName: string; isTicket: boolean; ticketStop: boolean;
  priorityName: string | null; priorityColor: string | null;
  lastStatusName: string | null; lastStatusPercent: number;
};

export default function TasksPage() {
  const [reminders, setReminders] = useState<PrjReminder[]>([]);

  const { toast } = useToast();
  const [page, setPage] = useState(1);
  const [searchText, setSearchText] = useState("");
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState("OPEN");
  const [scope, setScope] = useState("mine");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState(emptyForm);
  const [saving, setSaving] = useState(false);
  const [users, setUsers] = useState<{ id: string; firstName: string; lastName: string }[]>([]);
  const [companies, setCompanies] = useState<{ id: string; name: string }[]>([]);

  // کارتابل یادآور پروژه‌ها — بازسازی _PartialReminderProject خود CRMIdeal
  useEffect(() => {
    fetch("/api/projects/reminders")
      .then((r) => (r.ok ? r.json() : null))
      .then((d) => { if (d?.rows) setReminders(d.rows); })
      .catch(() => {});
  }, []);

  const url = useMemo(
    () => `/api/tasks?page=${page}&search=${encodeURIComponent(search)}&status=${statusFilter}&scope=${scope}`,
    [page, search, statusFilter, scope]
  );
  const { rows, total, loading, refresh } = useList<Task>(url);

  const [meta, setMeta] = useState({ openCount: 0, overdueCount: 0 });
  useMemo(() => {
    fetch(url.replace(/page=\d+/, "page=1"))
      .then((r) => r.json())
      .then((d) => setMeta({ openCount: d.openCount ?? 0, overdueCount: d.overdueCount ?? 0 }))
      .catch(() => {});
  }, [statusFilter, scope]);

  async function openDialog() {
    const [uRes, cRes] = await Promise.all([
      fetch("/api/users?light=1"),
      fetch("/api/companies?pageSize=200"),
    ]);
    const [u, c] = await Promise.all([uRes.json(), cRes.json()]);
    setUsers(u.rows ?? []);
    setCompanies(c.rows ?? []);
    setForm(emptyForm);
    setDialogOpen(true);
  }

  async function save() {
    if (!form.title.trim()) return toast({ title: "عنوان الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/tasks", { method: "POST", body: form });
      toast({ title: "وظیفه ایجاد شد." });
      setDialogOpen(false);
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function toggle(t: Task, done: boolean) {
    try {
      await api("/api/tasks", { method: "PATCH", body: { id: t.id, done } });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function remove(t: Task) {
    if (!confirm(`حذف «${t.title}»؟`)) return;
    try {
      await api(`/api/tasks/${t.id}`, { method: "DELETE" });
      toast({ title: "حذف شد." });
      refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  return (
    <div>
      <PageHeader
        title="کارتابل"
        subtitle={`${toPersianDigits(meta.openCount)} وظیفه باز · ${toPersianDigits(meta.overdueCount)} عقب‌افتاده`}
        actions={
          <Button onClick={openDialog}>
            <Plus className="w-4 h-4 me-1" />
            وظیفه جدید
          </Button>
        }
      />

      <div className="flex flex-col sm:flex-row gap-2 mb-4">
        <form className="flex-1" onSubmit={(e) => { e.preventDefault(); setPage(1); setSearch(searchText); }}>
          <div className="relative max-w-md">
            <Search className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
            <Input className="ps-9" placeholder="جستجو…" value={searchText} onChange={(e) => setSearchText(e.target.value)} />
          </div>
        </form>
        <Select value={statusFilter} onValueChange={(v) => { setStatusFilter(v); setPage(1); }}>
          <SelectTrigger className="w-full sm:w-36"><SelectValue /></SelectTrigger>
          <SelectContent>
            <SelectItem value="OPEN">باز</SelectItem>
            <SelectItem value="DONE">انجام‌شده</SelectItem>
            <SelectItem value="ALL">همه</SelectItem>
          </SelectContent>
        </Select>
        <Button variant={scope === "mine" ? "default" : "outline"} onClick={() => { setScope(scope === "mine" ? "all" : "mine"); setPage(1); }}>
          {scope === "mine" ? "وظایف من" : "همه کاربران"}
        </Button>
      </div>

      <div className="rounded-xl border bg-card overflow-hidden">
        {loading ? (
          <p className="text-center py-14 text-muted-foreground text-sm">در حال بارگذاری…</p>
        ) : rows.length === 0 ? (
          <p className="text-center py-14 text-muted-foreground text-sm">وظیفه‌ای یافت نشد 🎉</p>
        ) : (
          rows.map((t) => {
            const overdue = t.dueAt && new Date(t.dueAt) < new Date() && t.status === "OPEN";
            return (
              <div key={t.id} className="flex items-center gap-3 px-5 py-3.5 border-b last:border-0 hover:bg-muted/30 transition-colors">
                <button
                  className="shrink-0"
                  onClick={() => toggle(t, t.status !== "DONE")}
                  aria-label={t.status === "DONE" ? "بازکردن" : "انجام شد"}
                >
                  <CheckCircle2
                    className={`w-5 h-5 ${t.status === "DONE" ? "text-emerald-600" : "text-muted-foreground/40 hover:text-emerald-600"}`}
                  />
                </button>
                <div className="flex-1 min-w-0">
                  <p className={`text-sm font-bold ${t.status === "DONE" ? "line-through text-muted-foreground" : ""}`}>
                    {t.title}
                    {overdue && (
                      <span className="ms-2 inline-flex items-center gap-1 text-[10px] text-rose-600 font-bold">
                        <AlertTriangle className="w-3 h-3" />سررسید گذشته
                      </span>
                    )}
                  </p>
                  <p className="text-[11px] text-muted-foreground mt-0.5 flex flex-wrap gap-x-3">
                    <span>{t.assignee.firstName} {t.assignee.lastName}</span>
                    {t.company && <span>· {t.company.name}</span>}
                    {t.dueAt && <span>· سررسید: {formatDate(t.dueAt)}</span>}
                    {t.creator && <span>· ثبت: {t.creator.firstName} {t.creator.lastName}</span>}
                  </p>
                </div>
                <div className="flex items-center gap-2 shrink-0">
                  {t.status !== "DONE" && (
                    <StatusBadge value={t.priority} label={PRIORITY_LABELS[t.priority]} />
                  )}
                  {t.status === "DONE" && (
                    <StatusBadge value="DONE" label={TASK_STATUS_LABELS.DONE} />
                  )}
                  <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => remove(t)} aria-label="حذف">
                    <Trash2 className="w-3.5 h-3.5" />
                  </Button>
                </div>
              </div>
            );
          })
        )}
      </div>

      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-xl">
          <DialogHeader>
            <DialogTitle>وظیفه جدید</DialogTitle>
          </DialogHeader>
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div className="space-y-1.5 sm:col-span-2">
              <Label>عنوان *</Label>
              <Input value={form.title} onChange={(e) => setForm({ ...form, title: e.target.value })} placeholder="مثلاً پیگیری تماس با مشتری" />
            </div>
            <div className="space-y-1.5 sm:col-span-2">
              <Label>شرح</Label>
              <Textarea rows={2} value={form.description} onChange={(e) => setForm({ ...form, description: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>مسئول انجام</Label>
              <Select value={form.assigneeId} onValueChange={(v) => setForm({ ...form, assigneeId: v })}>
                <SelectTrigger><SelectValue placeholder="خودم" /></SelectTrigger>
                <SelectContent>
                  {users.map((u) => (
                    <SelectItem key={u.id} value={u.id}>{u.firstName} {u.lastName}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
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
              <Label>سررسید</Label>
              <JalaliDateInput value={form.dueAt} onChange={(iso) => setForm({ ...form, dueAt: iso })} />
            </div>
            <div className="space-y-1.5">
              <Label>شرکت مرتبط</Label>
              <Select value={form.companyId} onValueChange={(v) => setForm({ ...form, companyId: v })}>
                <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                <SelectContent>
                  {companies.map((c) => (
                    <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* یادآور پروژه‌ها — کارتابل سوم خود محصول (ReminderProject) */}
      {reminders.length > 0 && (
        <Card className="mt-6">
          <CardContent className="p-0">
            <div className="flex items-center gap-2 px-4 py-3 border-b">
              <BellRing className="w-4 h-4 text-rose-500" />
              <h3 className="text-sm font-bold">یادآور پروژه‌ها ({toPersianDigits(reminders.length)})</h3>
              <span className="text-[11px] text-muted-foreground">پروژه‌های جاری با تاریخ یادآوری رسیده یا گذشته</span>
            </div>
            {reminders.map((r) => (
              <Link key={r.id} href={`/projects/${r.id}`} className="flex items-center gap-3 px-4 py-2.5 border-b last:border-0 hover:bg-muted/40 text-xs">
                {r.isTicket && <Ticket className="w-3.5 h-3.5 text-amber-600 shrink-0" />}
                <span className="font-medium">{r.title}</span>
                <span className="text-muted-foreground">— {r.companyName}</span>
                {r.priorityName && (
                  <span className="px-1.5 py-0.5 rounded-full" style={{ backgroundColor: (r.priorityColor ?? "#999") + "22", color: r.priorityColor ?? "#666" }}>
                    {r.priorityName}
                  </span>
                )}
                <span className="flex-1" />
                {r.lastStatusName && <span className="text-muted-foreground">{r.lastStatusName} ({toPersianDigits(r.lastStatusPercent)}٪)</span>}
                <span className="text-rose-600 font-bold shrink-0">{formatDate(r.remindDate)}</span>
              </Link>
            ))}
          </CardContent>
        </Card>
      )}
    </div>
  );
}
