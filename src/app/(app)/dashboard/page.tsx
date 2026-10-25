"use client";

/**
 * داشبورد رستا — بازسازی Cartables/HomePage.cshtml محصول CRMIdeal
 *
 * ساختار اصلی:
 *  ۱) quick-access-box: هشت قرص دسترسی سریع (StyHomePage.css:
 *     600px وسط‌چین، bg #e7effc، radius 50px، padding 12px 20px)
 *  ۲) تب‌های نمودار (فعالیت روزانه / سفارش روزانه / سفارش ماهانه)
 *     معادل _PartialChartDailyActivity و ... در ناحیه Cartables
 *  ۳) box-PublicNotice: اطلاعیه سامانه (گوشه پایین، border #8598be)
 *  ۴) کارت‌های KPI و کارتابل شخصی (ادامه صفحه)
 */

import { useEffect, useState } from "react";
import Link from "next/link";
import {
  Building2, Target, PhoneCall, ClipboardList, TrendingUp,
  AlertTriangle, ArrowLeft, Activity as ActivityIcon, Megaphone,
} from "lucide-react";
import { Skeleton } from "@/components/ui/skeleton";
import { QuickAccessBox } from "@/components/rasta/app-shell";
import { StatusBadge } from "@/components/rasta/status-badge";
import { useList, api } from "@/hooks/use-list";
import { formatMoney, formatDateTime } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";
import { ACTIVITY_TYPE_LABELS } from "@/lib/constants";
import {
  ResponsiveContainer, BarChart, Bar, XAxis, YAxis, Tooltip, CartesianGrid,
} from "recharts";
import { useToast } from "@/hooks/use-toast";
import { cn } from "@/lib/utils";

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

/* تب‌های نمودار — معادل تب‌های Charts در صفحه اصلی محصول */
const CHART_TABS = [
  { key: "sales", label: "مدیریت فروش روزانه" },
  { key: "activity", label: "فعالیت روزانه" },
  { key: "monthly", label: "مدیریت فروش ماهانه" },
] as const;

type ChartTabKey = (typeof CHART_TABS)[number]["key"];

export default function DashboardPage() {
  const [data, setData] = useState<DashboardData | null>(null);
  const [chartTab, setChartTab] = useState<ChartTabKey>("sales");
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

  const kpi = data?.kpis;

  /* دادهٔ نمودار بر اساس تب انتخابی (مثل DrawChartDailyOrders) */
  const chartData =
    chartTab === "sales"
      ? (data?.salesByMonth ?? []).map((m) => ({ name: m.label, value: m.total }))
      : chartTab === "monthly"
      ? (data?.salesByMonth ?? []).map((m) => ({ name: m.label, value: m.total }))
      : (data?.recentActivities ?? []).slice(0, 8).map((a) => ({
          name: a.subject.slice(0, 14),
          value: 1,
        }));

  return (
    <div className="relative pb-16">
      {/* ═══ ۱) دسترسی سریع — قلب صفحه اصلی CRMIdeal ═══ */}
      <QuickAccessBox />

      {/* ═══ ۲) تب نمودارها (Rep-p-r-l-10 → نمودار در تب) ═══ */}
      <section className="crm-section mt-10">
        <div className="crm-section-header flex flex-wrap items-center justify-between gap-2 px-4 py-2.5">
          <h6 className="text-[15px] font-semibold flex items-center gap-2">
            <TrendingUp className="w-4 h-4" />
            {CHART_TABS.find((t) => t.key === chartTab)?.label}
          </h6>
          <div className="flex items-center gap-1.5">
            {CHART_TABS.map((t) => (
              <button
                key={t.key}
                type="button"
                onClick={() => setChartTab(t.key)}
                className={cn(
                  "px-3 py-1 rounded-full text-[13px] transition-colors",
                  chartTab === t.key
                    ? "bg-white text-[#528fcc] font-medium"
                    : "text-white/85 hover:bg-white/15"
                )}
              >
                {t.label}
              </button>
            ))}
          </div>
        </div>
        <div className="p-4 h-72">
          {data ? (
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={chartData} margin={{ top: 8, right: 8, bottom: 0, left: 8 }}>
                <CartesianGrid strokeDasharray="3 3" stroke="#e5e9f2" />
                <XAxis dataKey="name" tick={{ fontSize: 11 }} reversed />
                <YAxis tick={{ fontSize: 11 }} orientation="right" allowDecimals={false} />
                <Tooltip
                  contentStyle={{
                    fontFamily: "inherit",
                    fontSize: 12,
                    borderRadius: 8,
                    direction: "rtl",
                  }}
                  formatter={(v: number) => [toPersianDigits(v), "مقدار"]}
                />
                <Bar dataKey="value" fill="#509acf" radius={[8, 8, 0, 0]} />
              </BarChart>
            </ResponsiveContainer>
          ) : (
            <Skeleton className="w-full h-full" />
          )}
        </div>
      </section>

      {/* ═══ ۳) KPI ها ═══ */}
      <div className="grid grid-cols-2 lg:grid-cols-4 gap-4 mt-4">
        <KpiCard icon={Building2} label="کل مشتریان" value={kpi ? toPersianDigits(kpi.totalCompanies) : "…"} sub={kpi ? `${toPersianDigits(kpi.activeCompanies)} فعال` : ""} />
        <KpiCard icon={Target} label="فرصت‌های باز" value={kpi ? toPersianDigits(kpi.openDeals) : "…"} sub={kpi ? `ارزش: ${formatMoney(kpi.openDealsValue)} ریال` : ""} />
        <KpiCard icon={TrendingUp} label="فروش موفق این ماه" value={kpi ? toPersianDigits(kpi.wonThisMonth) : "…"} sub={kpi ? `${formatMoney(kpi.wonThisMonthValue)} ریال` : ""} />
        <KpiCard
          icon={AlertTriangle}
          label="وظایف من"
          value={kpi ? toPersianDigits(kpi.myOpenTasks) : "…"}
          sub={kpi && kpi.myOverdueTasks > 0 ? `${toPersianDigits(kpi.myOverdueTasks)} مورد عقب‌افتاده` : "بدون تأخیر"}
          tone={kpi && kpi.myOverdueTasks > 0 ? "rose" : "plain"}
        />
      </div>

      {/* ═══ ۴) کارتابل من + آخرین فعالیت‌ها ═══ */}
      <div className="grid lg:grid-cols-2 gap-4 mt-4">
        {/* کارتابل من (Cartables-RowBox) */}
        <section className="crm-section">
          <div className="crm-section-header flex items-center justify-between px-4 py-2.5">
            <h6 className="text-[15px] font-semibold flex items-center gap-2">
              <ClipboardList className="w-4 h-4" />
              کارتابل من
            </h6>
            <Link href="/tasks" className="text-[12px] text-white/90 hover:text-white flex items-center gap-1">
              همه
              <ArrowLeft className="w-3.5 h-3.5" />
            </Link>
          </div>
          <div className="p-3 max-h-72 overflow-y-auto crm-scroll">
            {myTasks.loading ? (
              Array.from({ length: 4 }).map((_, i) => <Skeleton key={i} className="h-12 mb-2" />)
            ) : myTasks.rows.length === 0 ? (
              <p className="text-sm text-muted-foreground text-center py-8">وظیفه بازی ندارید</p>
            ) : (
              myTasks.rows.map((t) => (
                <TaskItem key={t.id} task={t} onToggle={toggleTask} />
              ))
            )}
          </div>
        </section>

        {/* آخرین فعالیت‌ها */}
        <section className="crm-section">
          <div className="crm-section-header flex items-center justify-between px-4 py-2.5">
            <h6 className="text-[15px] font-semibold flex items-center gap-2">
              <ActivityIcon className="w-4 h-4" />
              آخرین فعالیت‌ها
            </h6>
            <Link href="/activities" className="text-[12px] text-white/90 hover:text-white flex items-center gap-1">
              همه
              <ArrowLeft className="w-3.5 h-3.5" />
            </Link>
          </div>
          <div className="p-3 max-h-72 overflow-y-auto crm-scroll">
            {!data ? (
              Array.from({ length: 5 }).map((_, i) => <Skeleton key={i} className="h-14 mb-2" />)
            ) : data.recentActivities.length === 0 ? (
              <p className="text-sm text-muted-foreground text-center py-8">فعالیتی ثبت نشده است.</p>
            ) : (
              data.recentActivities.map((a) => (
                <div key={a.id} className="flex items-start gap-3 py-2.5 border-b border-[#eef1f7] last:border-0">
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
          </div>
        </section>
      </div>

      {/* ═══ اطلاعیه سامانه (box-PublicNotice — گوشه پایین سمت چپ) ═══ */}
      <div className="fixed bottom-4 left-4 z-[100] hidden lg:block">
        <div className="bg-white rounded-lg border border-[#8598be] p-3 w-56 shadow-sm">
          <h3 className="text-[13px] font-semibold flex items-center gap-1.5 mb-1.5 text-[#1f2733]">
            <Megaphone className="w-4 h-4 text-[#528fcc]" />
            اطلاعیه سامانه
          </h3>
          <p className="text-[11.5px] leading-5 text-muted-foreground">
            خوش آمدید! سامانه رستا — بازسازی مدرن و سبک CRM ایده‌آل. ماژول خزانه و بانک‌داری فعال شد.
          </p>
        </div>
      </div>
    </div>
  );
}

/* کارت KPI با ظاهر هماهنگ با قرص‌های CRMIdeal */
function KpiCard({
  icon: Icon,
  label,
  value,
  sub,
  tone = "plain",
}: {
  icon: React.ComponentType<{ className?: string }>;
  label: string;
  value: string;
  sub?: string;
  tone?: "plain" | "rose";
}) {
  return (
    <div
      className={cn(
        "rounded-[8px] p-4 border",
        tone === "rose" ? "bg-[#fdeef3] border-[#f3c3d4]" : "bg-[#e7effc] border-[#d3e0f7]"
      )}
    >
      <div className="flex items-center gap-2 mb-1.5">
        <span className="w-8 h-8 rounded-full bg-white flex items-center justify-center">
          <Icon className="w-4 h-4 text-[#012875]" />
        </span>
        <span className="text-[13px] text-[#012875]">{label}</span>
      </div>
      <div className="text-2xl font-bold text-[#012875]">{value}</div>
      {sub ? <div className="text-[11px] text-[#5c6b8a] mt-1">{sub}</div> : null}
    </div>
  );
}

function TaskItem({
  task,
  onToggle,
}: {
  task: TaskRow;
  onToggle: (id: string, done: boolean) => void;
}) {
  return (
    <div className="flex items-center gap-3 py-2.5 border-b border-[#eef1f7] last:border-0">
      <input
        type="checkbox"
        className="w-4 h-4 accent-[#012875]"
        checked={task.status === "DONE"}
        onChange={(e) => onToggle(task.id, e.target.checked)}
      />
      <div className="flex-1 min-w-0">
        <p className="text-sm font-medium truncate">{task.title}</p>
        <p className="text-xs text-muted-foreground">
          {task.company?.name ?? "—"}
          {task.dueAt ? ` · ${formatDateTime(task.dueAt)}` : ""}
        </p>
      </div>
      <StatusBadge value={task.priority} label={task.priority} />
    </div>
  );
}
