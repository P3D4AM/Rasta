"use client";

import { useEffect, useState } from "react";
import Link from "next/link";
import {
  Building2, Target, PhoneCall, ClipboardList, Package, TrendingUp,
  AlertTriangle, FileText, Users, ArrowLeft, Activity as ActivityIcon,
} from "lucide-react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Skeleton } from "@/components/ui/skeleton";
import { PageHeader } from "@/components/rasta/page-header";
import { StatusBadge } from "@/components/rasta/status-badge";
import { useList, api } from "@/hooks/use-list";
import { formatMoney, formatDate, formatDateTime } from "@/lib/format";
import { formatJalaliLong, toPersianDigits, JALALI_MONTHS, gregorianToJalali } from "@/lib/jalali";
import {
  ACTIVITY_TYPE_LABELS, DEAL_STAGE_LABELS, DEAL_STAGES,
} from "@/lib/constants";
import {
  ResponsiveContainer, BarChart, Bar, XAxis, YAxis, Tooltip, CartesianGrid,
} from "recharts";
import { useToast } from "@/hooks/use-toast";

type DashboardData = {
  kpis: {
    totalCompanies: number; activeCompanies: number; totalProducts: number;
    openDeals: number; openDealsValue: number; wonThisMonth: number;
    wonThisMonthValue: number; lostThisMonth: number; activitiesToday: number;
    myOpenTasks: number; myOverdueTasks: number; myQuotationsCount: number;
  };
  stages: Record<string, { count: number; sum: number }>;
  salesByMonth: { label: string; total: number }[];
  recentActivities: {
    id: string; type: string; subject: string; occurredAt: string;
    user: { firstName: string; lastName: string };
    company: { id: string; name: string } | null;
  }[];
};

type TaskRow = {
  id: string; title: string; dueAt: string | null; priority: string;
  status: string; company: { name: string } | null;
};

export default function DashboardPage() {
  const [data, setData] = useState<DashboardData | null>(null);
  const { toast } = useToast();
  const myTasks = useList<TaskRow>("/api/tasks?status=OPEN&scope=mine&pageSize=5");

  useEffect(() => {
    api<DashboardData>("/api/dashboard")
      .then(setData)
      .catch((e) => toast({ title: "خطا", description: e.message, variant: "destructive" }));
  }, []);

  async function toggleTask(id: string, done: boolean) {
    try {
      await api("/api/tasks", { method: "PATCH", body: { id, done } });
      myTasks.refresh();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const today = new Date();
  const [, jm] = gregorianToJalali(today.getFullYear(), today.getMonth() + 1, today.getDate());

  const kpi = data?.kpis;
  const pipeline = DEAL_STAGES.map((s) => ({
    stage: s,
    label: DEAL_STAGE_LABELS[s],
    count: data?.stages[s]?.count ?? 0,
    sum: data?.stages[s]?.sum ?? 0,
  }));

  return (
    <div>
      <PageHeader
        title="داشبورد"
        subtitle={`${formatJalaliLong(today)} — ${JALALI_MONTHS[jm - 1]}`}
        actions={
          <Button asChild variant="outline" size="sm">
            <Link href="/activities">
              <PhoneCall className="w-4 h-4 me-1" />
              ثبت فعالیت
            </Link>
          </Button>
        }
      />

      {/* KPI cards */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-4">
        <KpiCard icon={Building2} label="کل مشتریان" value={kpi ? toPersianDigits(kpi.totalCompanies) : "…"} sub={kpi ? `${toPersianDigits(kpi.activeCompanies)} فعال` : ""} tone="emerald" />
        <KpiCard icon={Target} label="فرصت‌های باز" value={kpi ? toPersianDigits(kpi.openDeals) : "…"} sub={kpi ? `ارزش: ${formatMoney(kpi.openDealsValue)} ریال` : ""} tone="sky" />
        <KpiCard icon={TrendingUp} label="فروش موفق این ماه" value={kpi ? toPersianDigits(kpi.wonThisMonth) : "…"} sub={kpi ? `${formatMoney(kpi.wonThisMonthValue)} ریال` : ""} tone="amber" />
        <KpiCard
          icon={AlertTriangle}
          label="وظایف من"
          value={kpi ? toPersianDigits(kpi.myOpenTasks) : "…"}
          sub={kpi && kpi.myOverdueTasks > 0 ? `${toPersianDigits(kpi.myOverdueTasks)} مورد عقب‌افتاده` : "بدون تأخیر"}
          tone={kpi && kpi.myOverdueTasks > 0 ? "rose" : "slate"}
        />
      </div>

      <div className="grid lg:grid-cols-3 gap-4 mt-4">
        {/* Pipeline funnel */}
        <Card className="lg:col-span-2">
          <CardHeader className="pb-2">
            <CardTitle className="text-base font-bold flex items-center gap-2">
              <Target className="w-4 h-4 text-primary" />
              قیف فروش
            </CardTitle>
          </CardHeader>
          <CardContent>
            <div className="h-72">
              <ResponsiveContainer width="100%" height="100%">
                <BarChart data={pipeline} margin={{ top: 8, right: 8, bottom: 0, left: 8 }}>
                  <CartesianGrid strokeDasharray="3 3" className="stroke-muted" />
                  <XAxis dataKey="label" tick={{ fontSize: 11 }} reversed />
                  <YAxis tick={{ fontSize: 11 }} orientation="right" allowDecimals={false} />
                  <Tooltip
                    contentStyle={{ fontFamily: "inherit", fontSize: 12, borderRadius: 8 }}
                    formatter={(_, __, item) => [
                      `${toPersianDigits(item.payload.count)} فرصت`,
                      item.payload.label,
                    ]}
                  />
                  <Bar dataKey="count" fill="oklch(0.508 0.118 165.612)" radius={[8, 8, 0, 0]} />
                </BarChart>
              </ResponsiveContainer>
            </div>
          </CardContent>
        </Card>

        {/* My tasks today */}
        <Card>
          <CardHeader className="pb-2">
            <CardTitle className="text-base font-bold flex items-center justify-between">
              <span className="flex items-center gap-2">
                <ClipboardList className="w-4 h-4 text-primary" />
                کارتابل من
              </span>
              <Button asChild variant="ghost" size="sm" className="text-xs">
                <Link href="/tasks">
                  همه
                  <ArrowLeft className="w-3.5 h-3.5" />
                </Link>
              </Button>
            </CardTitle>
          </CardHeader>
          <CardContent className="max-h-72 overflow-y-auto">
            {myTasks.loading ? (
              Array.from({ length: 4 }).map((_, i) => <Skeleton key={i} className="h-12 mb-2" />)
            ) : myTasks.rows.length === 0 ? (
              <p className="text-sm text-muted-foreground text-center py-8">وظیفه بازی ندارید 🎉</p>
            ) : (
              myTasks.rows.map((t) => (
                <TaskItem key={t.id} task={t} onToggle={toggleTask} />
              ))
            )}
          </CardContent>
        </Card>
      </div>

      <div className="grid lg:grid-cols-2 gap-4 mt-4">
        {/* Recent activities */}
        <Card>
          <CardHeader className="pb-2">
            <CardTitle className="text-base font-bold flex items-center gap-2">
              <ActivityIcon className="w-4 h-4 text-primary" />
              آخرین فعالیت‌ها
            </CardTitle>
          </CardHeader>
          <CardContent className="max-h-80 overflow-y-auto">
            {!data ? (
              Array.from({ length: 5 }).map((_, i) => <Skeleton key={i} className="h-14 mb-2" />)
            ) : data.recentActivities.length === 0 ? (
              <p className="text-sm text-muted-foreground text-center py-8">فعالیتی ثبت نشده است.</p>
            ) : (
              data.recentActivities.map((a) => (
                <div key={a.id} className="flex items-start gap-3 py-2.5 border-b last:border-0">
                  <StatusBadge value={a.type} label={ACTIVITY_TYPE_LABELS[a.type] ?? a.type} />
                  <div className="flex-1 min-w-0">
                    <p className="text-sm font-medium truncate">{a.subject}</p>
                    <p className="text-xs text-muted-foreground mt-0.5">
                      {a.user.firstName} {a.user.lastName}
                      {a.company && <> · {a.company.name}</>}
                      {" · "}
                      {formatDateTime(a.occurredAt)}
                    </p>
                  </div>
                </div>
              ))
            )}
          </CardContent>
        </Card>

        {/* Quick stats grid */}
        <div className="grid grid-cols-2 gap-4 content-start">
          <MiniStat icon={PhoneCall} label="فعالیت‌های امروز" value={kpi ? toPersianDigits(kpi.activitiesToday) : "…"} />
          <MiniStat icon={FileText} label="پیش‌فاکتورهای باز من" value={kpi ? toPersianDigits(kpi.myQuotationsCount) : "…"} />
          <MiniStat icon={Users} label="مشتریان فعال" value={kpi ? toPersianDigits(kpi.activeCompanies) : "…"} />
          <MiniStat icon={Package} label="محصولات" value={kpi ? toPersianDigits(kpi.totalProducts) : "…"} />
          <Card className="col-span-2">
            <CardHeader className="pb-2">
              <CardTitle className="text-sm font-bold">فرصت‌های ناموفق این ماه</CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-2xl font-extrabold text-rose-600">
                {kpi ? toPersianDigits(kpi.lostThisMonth) : "…"}
              </p>
              <p className="text-xs text-muted-foreground mt-1">
                بررسی دلایل شکست به بهبود فرایند فروش کمک می‌کند.
              </p>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
}

const TONES: Record<string, string> = {
  emerald: "bg-emerald-500/10 text-emerald-600",
  sky: "bg-sky-500/10 text-sky-600",
  amber: "bg-amber-500/10 text-amber-600",
  rose: "bg-rose-500/10 text-rose-600",
  slate: "bg-slate-500/10 text-slate-600",
};

function KpiCard({
  icon: Icon, label, value, sub, tone,
}: {
  icon: React.ComponentType<{ className?: string }>;
  label: string; value: string; sub?: string; tone: string;
}) {
  return (
    <Card className="hover:shadow-md transition-shadow">
      <CardContent className="p-4">
        <div className="flex items-start justify-between">
          <div>
            <p className="text-xs text-muted-foreground">{label}</p>
            <p className="text-2xl font-extrabold mt-1.5">{value}</p>
            {sub && <p className="text-[11px] text-muted-foreground mt-1">{sub}</p>}
          </div>
          <div className={`rounded-xl p-2.5 ${TONES[tone]}`}>
            <Icon className="w-5 h-5" />
          </div>
        </div>
      </CardContent>
    </Card>
  );
}

function MiniStat({
  icon: Icon, label, value,
}: {
  icon: React.ComponentType<{ className?: string }>;
  label: string; value: string;
}) {
  return (
    <Card className="hover:shadow-md transition-shadow">
      <CardContent className="p-4 flex items-center gap-3">
        <div className="rounded-lg bg-primary/10 text-primary p-2">
          <Icon className="w-4 h-4" />
        </div>
        <div>
          <p className="text-xs text-muted-foreground">{label}</p>
          <p className="text-lg font-extrabold">{value}</p>
        </div>
      </CardContent>
    </Card>
  );
}

function TaskItem({
  task, onToggle,
}: {
  task: TaskRow;
  onToggle: (id: string, done: boolean) => void;
}) {
  const overdue = task.dueAt && new Date(task.dueAt) < new Date();
  return (
    <div className="flex items-start gap-2.5 py-2 border-b last:border-0">
      <input
        type="checkbox"
        className="mt-1 w-4 h-4 accent-emerald-600 rounded"
        onChange={(e) => onToggle(task.id, e.target.checked)}
        aria-label={`انجام: ${task.title}`}
      />
      <div className="flex-1 min-w-0">
        <p className="text-sm font-medium truncate">{task.title}</p>
        <p className="text-[11px] text-muted-foreground">
          {task.company?.name && <>{task.company.name} · </>}
          {overdue ? (
            <span className="text-rose-600 font-bold">سررسید گذشته — </span>
          ) : null}
          {formatDate(task.dueAt)}
        </p>
      </div>
      <StatusBadge value={task.priority} label={task.priority === "URGENT" ? "فوری" : task.priority === "HIGH" ? "مهم" : ""} />
    </div>
  );
}
