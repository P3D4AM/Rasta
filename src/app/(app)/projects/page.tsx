"use client";

/**
 * لیست سراسری پروژه‌ها — منوی «پروژه ها» در بانک اطلاعاتی مشتریان.
 * ستون‌ها مطابق گرید کارتابل یادآور خود محصول (ReminderProject_Read):
 * یادآوری / عنوان / مشتری / گروه / مقطع / اولویت / آغازگر / آخرین وضعیت (٪) / نوع
 */

import { useCallback, useEffect, useState } from "react";
import Link from "next/link";
import { Ticket, PauseCircle, Search } from "lucide-react";
import { Input } from "@/components/ui/input";
import { PageHeader } from "@/components/rasta/page-header";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { formatDate } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";

type Row = {
  id: string; number: number; title: string; companyName: string;
  remindDate: string | null; remindOverdue: boolean;
  groupName: string | null; gradeName: string | null;
  priorityName: string | null; priorityColor: string | null;
  starterName: string | null; isTicket: boolean; isFinished: boolean; ticketStop: boolean;
  lastStatusName: string | null; lastStatusPercent: number; lastStatusColor: string | null;
  conversationsCount: number;
};

type Counters = { projectActive: number; projectArchive: number; ticketActive: number; ticketArchive: number };

export default function ProjectsPage() {
  const { toast } = useToast();
  const [tab, setTab] = useState<"current" | "archive" | "ticket">("current");
  const [search, setSearch] = useState("");
  const [rows, setRows] = useState<Row[]>([]);
  const [counters, setCounters] = useState<Counters>({ projectActive: 0, projectArchive: 0, ticketActive: 0, ticketArchive: 0 });
  const [loading, setLoading] = useState(true);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const q = new URLSearchParams({ tab, search });
      const data = await api<{ rows: Row[]; counters: Counters }>(`/api/projects?${q}`);
      setRows(data.rows);
      setCounters(data.counters);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setLoading(false);
    }
  }, [tab, search, toast]);

  useEffect(() => { load(); }, [load]);

  const tabBtn = (key: typeof tab, label: string, count: number) => (
    <button
      type="button"
      onClick={() => setTab(key)}
      className={`px-3 py-1.5 text-xs rounded-full font-medium transition-colors ${
        tab === key ? "bg-primary text-primary-foreground" : "bg-muted text-muted-foreground hover:text-foreground"
      }`}
    >
      {label} ({toPersianDigits(count)})
    </button>
  );

  return (
    <div>
      <PageHeader title="پروژه ها" subtitle="پرونده‌ها و تیکت‌های متصل به مشتریان — مطابق ساختار پروژه در CRMIdeal" />
      <div className="flex flex-wrap items-center gap-2 mb-4">
        {tabBtn("current", "جاری", counters.projectActive)}
        {tabBtn("archive", "آرشیو", counters.projectArchive)}
        {tabBtn("ticket", "تیکت‌ها", counters.ticketActive + counters.ticketArchive)}
        <div className="relative ms-auto">
          <Search className="w-4 h-4 absolute right-2.5 top-2.5 text-muted-foreground" />
          <Input className="h-9 w-64 ps-8" placeholder="جستجوی عنوان / پسوند / شماره عطف…" value={search} onChange={(e) => setSearch(e.target.value)} />
        </div>
      </div>

      <div className="border rounded-xl overflow-x-auto bg-card">
        <table className="w-full text-xs min-w-[900px]">
          <thead className="bg-muted/60 text-muted-foreground">
            <tr>
              <th className="px-3 py-2.5 text-start font-medium">یادآوری</th>
              <th className="px-3 py-2.5 text-start font-medium">عنوان</th>
              <th className="px-3 py-2.5 text-start font-medium">مشتری</th>
              <th className="px-3 py-2.5 text-start font-medium">گروه</th>
              <th className="px-3 py-2.5 text-start font-medium">مقطع</th>
              <th className="px-3 py-2.5 text-start font-medium">اولویت</th>
              <th className="px-3 py-2.5 text-start font-medium">آغازگر</th>
              <th className="px-3 py-2.5 text-start font-medium">آخرین وضعیت</th>
              <th className="px-3 py-2.5 text-start font-medium">مذاکره</th>
            </tr>
          </thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={9} className="text-center py-8 text-muted-foreground">در حال بارگذاری…</td></tr>
            ) : rows.length === 0 ? (
              <tr><td colSpan={9} className="text-center py-8 text-muted-foreground">پروژه‌ای یافت نشد.</td></tr>
            ) : (
              rows.map((r) => (
                <tr key={r.id} className="border-t hover:bg-muted/30">
                  <td className={`px-3 py-2.5 ${r.remindOverdue ? "text-rose-600 font-bold" : "text-muted-foreground"}`}>
                    {r.remindDate ? formatDate(r.remindDate) : "—"}
                    {r.remindOverdue && "!"}
                  </td>
                  <td className="px-3 py-2.5">
                    <Link href={`/projects/${r.id}`} className="font-medium hover:underline flex items-center gap-1.5">
                      {r.isTicket && <Ticket className="w-3.5 h-3.5 text-amber-600" />}
                      {r.ticketStop && <PauseCircle className="w-3.5 h-3.5 text-rose-500" />}
                      {r.title}
                    </Link>
                  </td>
                  <td className="px-3 py-2.5">
                    <span className="text-muted-foreground">{r.companyName}</span>
                  </td>
                  <td className="px-3 py-2.5 text-muted-foreground">{r.groupName ?? "—"}</td>
                  <td className="px-3 py-2.5 text-muted-foreground">{r.gradeName ?? "—"}</td>
                  <td className="px-3 py-2.5">
                    {r.priorityName ? (
                      <span className="px-1.5 py-0.5 rounded-full" style={{ backgroundColor: (r.priorityColor ?? "#999") + "22", color: r.priorityColor ?? "#666" }}>
                        {r.priorityName}
                      </span>
                    ) : "—"}
                  </td>
                  <td className="px-3 py-2.5 text-muted-foreground">{r.starterName ?? "—"}</td>
                  <td className="px-3 py-2.5">
                    {r.lastStatusName ? (
                      <span className="flex items-center gap-1.5">
                        <span style={{ color: r.lastStatusColor ?? undefined }}>{r.lastStatusName}</span>
                        <span className="w-12 h-1.5 rounded-full bg-muted overflow-hidden inline-block">
                          <span className="block h-full rounded-full" style={{ width: `${r.lastStatusPercent}%`, backgroundColor: r.lastStatusColor ?? "#0288d1" }} />
                        </span>
                        <span className="font-bold text-[10px]">{toPersianDigits(r.lastStatusPercent)}٪</span>
                      </span>
                    ) : <span className="text-muted-foreground">بدون مذاکره</span>}
                  </td>
                  <td className="px-3 py-2.5 text-muted-foreground">{toPersianDigits(r.conversationsCount)}</td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
