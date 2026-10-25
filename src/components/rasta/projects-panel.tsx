"use client";

/**
 * پنل پروژه‌های مخاطب — بازسازی بخش پروژه در تب خلاصهٔ صفحه مشتری خود CRMIdeal:
 * تب‌های «جاری / آرشیو / تیکت‌ها» با شمارنده (CRMspSelectCompanyProjectsCount)،
 * جستجوی درخت (txtSearchPrjTree)، درخت پروژه‌ها (عنوان + درصد + تاریخ یادآوری — قرمز برای عقب‌افتاده)
 * با فرزندانِ مذاکرات همان پروژه.
 */

import { useCallback, useEffect, useState } from "react";
import Link from "next/link";
import { Plus, Search, ChevronDown, ChevronLeft, FolderOpen, Ticket, PauseCircle, Archive } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { formatDate, formatDateTime } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";

type ProjectRow = {
  id: string; number: number; title: string; postFix: string | null; referenceNumber: string | null;
  subject: string | null; isFinished: boolean; isTicket: boolean; ticketStop: boolean;
  remindDate: string | null; remindOverdue: boolean;
  lastStatusName: string | null; lastStatusPercent: number; lastStatusColor: string | null;
  priorityName: string | null; priorityColor: string | null;
  starterName: string | null; conversationsCount: number; statusGroupId: string;
};

type Counters = { projectActive: number; projectArchive: number; ticketActive: number; ticketArchive: number };

type Conversation = {
  id: string; description: string; cnvsDate: string; doingTimeSec: number | null;
  statusName: string; statusPercent: number; statusColor: string | null;
  referUserName: string | null; registeredByName: string | null;
};

export function ProjectsPanel({ companyId }: { companyId: string }) {
  const { toast } = useToast();
  const [tab, setTab] = useState<"current" | "archive" | "ticket">("current");
  const [ticketMode, setTicketMode] = useState<"all" | "current" | "archive">("all");
  const [search, setSearch] = useState("");
  const [rows, setRows] = useState<ProjectRow[]>([]);
  const [counters, setCounters] = useState<Counters>({ projectActive: 0, projectArchive: 0, ticketActive: 0, ticketArchive: 0 });
  const [loading, setLoading] = useState(true);
  const [expanded, setExpanded] = useState<string | null>(null);
  const [convs, setConvs] = useState<Record<string, Conversation[]>>({});
  const [canInsert, setCanInsert] = useState(false);
  const [canCnvs, setCanCnvs] = useState(false);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const q = new URLSearchParams({ companyId, tab, ticketMode, search });
      const data = await api<{ rows: ProjectRow[]; counters: Counters }>(`/api/projects?${q}`);
      setRows(data.rows);
      setCounters(data.counters);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setLoading(false);
    }
  }, [companyId, tab, ticketMode, search, toast]);

  useEffect(() => { load(); }, [load]);

  useEffect(() => {
    api<{ isAdmin: boolean; permissions: Record<string, string[]> }>("/api/auth/me").then((me) => {
      const has = (form: string, act: string) => me.isAdmin || (me.permissions[form] ?? []).includes(act);
      setCanInsert(has("frmDefineProjects", "actPost"));
      setCanCnvs(has("frmConversations", "actInsert"));
    }).catch(() => {});
  }, []);

  async function toggleExpand(id: string) {
    if (expanded === id) { setExpanded(null); return; }
    setExpanded(id);
    if (!convs[id]) {
      try {
        const res = await fetch(`/api/projects/${id}`);
        const data = await res.json();
        setConvs((c) => ({ ...c, [id]: (data.conversations ?? []) as Conversation[] }));
      } catch {
        setConvs((c) => ({ ...c, [id]: [] }));
      }
    }
  }

  const tabBtn = (key: "current" | "archive" | "ticket", label: string, count: number) => (
    <button
      type="button"
      onClick={() => setTab(key)}
      className={`px-3 py-1.5 text-xs rounded-t-lg border-b-2 transition-colors font-medium ${
        tab === key ? "border-primary text-primary bg-primary/5" : "border-transparent text-muted-foreground hover:text-foreground"
      }`}
    >
      {label} ({toPersianDigits(count)})
    </button>
  );

  return (
    <div>
      {/* نوار تب‌ها + جستجو + دکمه درج — مثل پنل پروژه صفحه مخاطب */}
      <div className="flex flex-wrap items-center justify-between gap-2 border-b">
        <div className="flex items-center gap-1">
          {tabBtn("current", "جاری", counters.projectActive)}
          {tabBtn("archive", "آرشیو", counters.projectArchive)}
          {tabBtn("ticket", "تیکت‌ها", counters.ticketActive + counters.ticketArchive)}
        </div>
        <div className="flex items-center gap-2 pb-1">
          {tab === "ticket" && (
            <Select value={ticketMode} onValueChange={(v) => setTicketMode(v as typeof ticketMode)}>
              <SelectTrigger className="h-8 w-36 text-xs"><SelectValue /></SelectTrigger>
              <SelectContent>
                <SelectItem value="all">همه ({toPersianDigits(counters.ticketActive + counters.ticketArchive)})</SelectItem>
                <SelectItem value="current">جاری ({toPersianDigits(counters.ticketActive)})</SelectItem>
                <SelectItem value="archive">آرشیو ({toPersianDigits(counters.ticketArchive)})</SelectItem>
              </SelectContent>
            </Select>
          )}
          <div className="relative">
            <Search className="w-4 h-4 absolute right-2.5 top-2.5 text-muted-foreground" />
            <Input
              className="h-8 w-48 text-xs ps-8"
              placeholder="جستجوی درخت پروژه‌ها…"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
          </div>
          {canInsert && (
            <Button size="sm" className="h-8" asChild>
              <Link href={`/companies/${companyId}/projects/new`}>
                <Plus className="w-4 h-4 me-1" />درج پروژه
              </Link>
            </Button>
          )}
        </div>
      </div>

      {/* درخت پروژه‌ها — هر پروژه با مذاکراتش باز می‌شود */}
      <div className="divide-y">
        {loading ? (
          <p className="text-sm text-muted-foreground text-center py-8">در حال بارگذاری…</p>
        ) : rows.length === 0 ? (
          <p className="text-sm text-muted-foreground text-center py-8">
            {tab === "archive" ? "پروژه آرشیوشده‌ای وجود ندارد." : "پروژه‌ای ثبت نشده است."}
          </p>
        ) : (
          rows.map((p) => (
            <div key={p.id}>
              <button
                type="button"
                onClick={() => toggleExpand(p.id)}
                className="w-full flex items-center gap-2 px-3 py-2.5 hover:bg-muted/40 text-start"
              >
                {expanded === p.id
                  ? <ChevronDown className="w-4 h-4 text-muted-foreground shrink-0" />
                  : <ChevronLeft className="w-4 h-4 text-muted-foreground shrink-0" />}
                <FolderOpen className="w-4 h-4 text-[#0288d1] shrink-0" />
                <span className="text-sm font-medium hover:underline">
                  <Link href={`/projects/${p.id}`} onClick={(e) => e.stopPropagation()}>{p.title}</Link>
                </span>
                {p.isTicket && <Ticket className="w-3.5 h-3.5 text-amber-600 shrink-0" />}
                {p.ticketStop && <PauseCircle className="w-3.5 h-3.5 text-rose-500 shrink-0" />}
                {p.isFinished && <Archive className="w-3.5 h-3.5 text-muted-foreground shrink-0" />}
                {p.priorityName && (
                  <span
                    className="text-[10px] px-1.5 py-0.5 rounded-full shrink-0"
                    style={{ backgroundColor: (p.priorityColor ?? "#999") + "22", color: p.priorityColor ?? "#666" }}
                  >
                    {p.priorityName}
                  </span>
                )}
                <span className="text-[11px] text-muted-foreground shrink-0">({toPersianDigits(p.conversationsCount)} مذاکره)</span>
                <span className="flex-1" />
                {p.lastStatusName && (
                  <span className="flex items-center gap-1.5 shrink-0">
                    <span className="text-[11px] text-muted-foreground">{p.lastStatusName}</span>
                    <span className="w-16 h-1.5 rounded-full bg-muted overflow-hidden inline-block">
                      <span
                        className="block h-full rounded-full"
                        style={{ width: `${p.lastStatusPercent}%`, backgroundColor: p.lastStatusColor ?? "#0288d1" }}
                      />
                    </span>
                    <span className="text-[10px] font-bold text-muted-foreground">{toPersianDigits(p.lastStatusPercent)}٪</span>
                  </span>
                )}
                {p.remindDate && (
                  <span
                    className={`text-[10px] shrink-0 flex items-center gap-1 ${p.remindOverdue ? "text-rose-600 font-bold" : "text-muted-foreground"}`}
                    title="تاریخ یادآوری"
                  >
                    {formatDate(p.remindDate)}
                    {p.remindOverdue && "!"}
                  </span>
                )}
              </button>

              {expanded === p.id && (
                <div className="bg-muted/30 px-6 pb-3">
                  {(convs[p.id] ?? []).length === 0 ? (
                    <p className="text-xs text-muted-foreground py-3">مذاکره‌ای ثبت نشده است.</p>
                  ) : (
                    (convs[p.id] ?? []).map((c) => (
                      <div key={c.id} className="flex items-start gap-2 py-2 border-b last:border-0">
                        <span
                          className="text-[10px] px-1.5 py-0.5 rounded-full shrink-0 mt-0.5"
                          style={{ backgroundColor: (c.statusColor ?? "#0288d1") + "22", color: c.statusColor ?? "#0288d1" }}
                        >
                          {c.statusName} — {toPersianDigits(c.statusPercent)}٪
                        </span>
                        <div className="flex-1 min-w-0">
                          <p className="text-xs">{c.description}</p>
                          <p className="text-[10px] text-muted-foreground mt-0.5">
                            {c.registeredByName}
                            {c.referUserName ? ` → ارجاع به ${c.referUserName}` : ""}
                            {" · "}{formatDateTime(c.cnvsDate)}
                            {c.doingTimeSec ? ` · مدت: ${toPersianDigits(Math.round(c.doingTimeSec / 60))} دقیقه` : ""}
                          </p>
                        </div>
                      </div>
                    ))
                  )}
                  {canCnvs && (
                    <Button size="sm" variant="outline" className="mt-2 h-7 text-xs" asChild>
                      <Link href={`/projects/${p.id}#conversations`}>
                        <Plus className="w-3.5 h-3.5 me-1" />ثبت مذاکره
                      </Link>
                    </Button>
                  )}
                </div>
              )}
            </div>
          ))
        )}
      </div>
    </div>
  );
}
