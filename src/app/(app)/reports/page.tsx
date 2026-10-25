"use client";

import { useEffect, useState } from "react";
import {
  ResponsiveContainer, BarChart, Bar, XAxis, YAxis, Tooltip, CartesianGrid,
  PieChart, Pie, Cell, Legend,
} from "recharts";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Skeleton } from "@/components/ui/skeleton";
import { PageHeader } from "@/components/rasta/page-header";
import { api } from "@/hooks/use-list";
import { formatMoney } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";
import {
  DEAL_STAGE_LABELS, ACTIVITY_TYPE_LABELS,
} from "@/lib/constants";

type ReportData = {
  salesByUser: { name: string; total: number; count: number }[];
  dealsByStage: { stage: string; count: number; sum: number }[];
  topOrders: {
    id: string; number: number; total: number; issueDate: string;
    company: { name: string };
    owner: { firstName: string; lastName: string } | null;
  }[];
  activitiesByType: { type: string; count: number }[];
  wonLost: { month: string; won: number; lost: number }[];
  summary: { totalSales: number; totalPaid: number; orderCount: number };
};

const MONTH_LABELS = ["این ماه", "-۱", "-۲", "-۳", "-۴", "-۵"];
const STAGE_COLORS: Record<string, string> = {
  NEW: "#0284c7", CONTACTED: "#06b6d4", PROPOSAL: "#f59e0b",
  NEGOTIATION: "#f97316", WON: "#10b981", LOST: "#f43f5e",
};
const TYPE_COLORS = ["#0d9488", "#f59e0b", "#8b5cf6", "#ec4899", "#64748b"];

export default function ReportsPage() {
  const [data, setData] = useState<ReportData | null>(null);

  useEffect(() => {
    api<ReportData>("/api/reports").then(setData).catch(() => {});
  }, []);

  if (!data) {
    return (
      <div>
        <PageHeader title="گزارش‌ها" />
        <div className="grid lg:grid-cols-2 gap-4">
          {Array.from({ length: 4 }).map((_, i) => (
            <Skeleton key={i} className="h-80 rounded-xl" />
          ))}
        </div>
      </div>
    );
  }

  const wonLost = data.wonLost.map((d, i) => ({
    ...d,
    label: MONTH_LABELS[MONTH_LABELS.length - 1 - i] ?? d.month,
  }));

  return (
    <div>
      <PageHeader title="گزارش‌ها" subtitle="تحلیل فروش و عملکرد تیم" />

      <div className="grid grid-cols-3 gap-4 mb-4">
        <Card>
          <CardContent className="p-4">
            <p className="text-xs text-muted-foreground">کل فروش (ریال)</p>
            <p className="text-xl font-extrabold mt-1">{formatMoney(data.summary.totalSales)}</p>
          </CardContent>
        </Card>
        <Card>
          <CardContent className="p-4">
            <p className="text-xs text-muted-foreground">دریافتی (ریال)</p>
            <p className="text-xl font-extrabold mt-1 text-emerald-600">{formatMoney(data.summary.totalPaid)}</p>
          </CardContent>
        </Card>
        <Card>
          <CardContent className="p-4">
            <p className="text-xs text-muted-foreground">تعداد فاکتور</p>
            <p className="text-xl font-extrabold mt-1">{toPersianDigits(data.summary.orderCount)}</p>
          </CardContent>
        </Card>
      </div>

      <div className="grid lg:grid-cols-2 gap-4">
        <Card>
          <CardHeader className="pb-2">
            <CardTitle className="text-sm font-bold">برنده/بازنده — ۶ ماه اخیر</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="h-72">
              <ResponsiveContainer width="100%" height="100%">
                <BarChart data={wonLost}>
                  <CartesianGrid strokeDasharray="3 3" className="stroke-muted" />
                  <XAxis dataKey="label" tick={{ fontSize: 11 }} reversed />
                  <YAxis tick={{ fontSize: 11 }} orientation="right" allowDecimals={false} />
                  <Tooltip contentStyle={{ fontFamily: "inherit", fontSize: 12, borderRadius: 8 }} />
                  <Legend />
                  <Bar dataKey="won" name="موفق" fill="#10b981" radius={[6, 6, 0, 0]} />
                  <Bar dataKey="lost" name="ناموفق" fill="#f43f5e" radius={[6, 6, 0, 0]} />
                </BarChart>
              </ResponsiveContainer>
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader className="pb-2">
            <CardTitle className="text-sm font-bold">فرصت‌ها بر اساس مرحله</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="h-72">
              <ResponsiveContainer width="100%" height="100%">
                <PieChart>
                  <Pie
                    data={data.dealsByStage.map((d) => ({
                      name: DEAL_STAGE_LABELS[d.stage] ?? d.stage,
                      value: d.count,
                      stage: d.stage,
                    }))}
                    dataKey="value"
                    nameKey="name"
                    innerRadius={60}
                    outerRadius={95}
                    label={undefined}
                  >
                    {data.dealsByStage.map((d) => (
                      <Cell key={d.stage} fill={STAGE_COLORS[d.stage] ?? "#64748b"} />
                    ))}
                  </Pie>
                  <Tooltip contentStyle={{ fontFamily: "inherit", fontSize: 12, borderRadius: 8 }} />
                  <Legend />
                </PieChart>
              </ResponsiveContainer>
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader className="pb-2">
            <CardTitle className="text-sm font-bold">فروش به تفکیک کارشناس (میلیون ریال)</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="h-64">
              <ResponsiveContainer width="100%" height="100%">
                <BarChart data={data.salesByUser.map((s) => ({ ...s, m: Math.round(s.total / 1_000_000) }))}>
                  <CartesianGrid strokeDasharray="3 3" className="stroke-muted" />
                  <XAxis dataKey="name" tick={{ fontSize: 11 }} reversed />
                  <YAxis tick={{ fontSize: 11 }} orientation="right" />
                  <Tooltip
                    contentStyle={{ fontFamily: "inherit", fontSize: 12, borderRadius: 8 }}
                    formatter={(v: string | number) => [`${toPersianDigits(v)} میلیون ریال`, "فروش"]}
                  />
                  <Bar dataKey="m" fill="#509acf" radius={[8, 8, 0, 0]} />
                </BarChart>
              </ResponsiveContainer>
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader className="pb-2">
            <CardTitle className="text-sm font-bold">ترکیب فعالیت‌ها</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-2">
              {data.activitiesByType.map((a, i) => {
                const total = data.activitiesByType.reduce((s, x) => s + x.count, 0) || 1;
                return (
                  <div key={a.type}>
                    <div className="flex justify-between text-xs mb-1">
                      <span className="font-medium">{ACTIVITY_TYPE_LABELS[a.type] ?? a.type}</span>
                      <span className="text-muted-foreground">{toPersianDigits(a.count)}</span>
                    </div>
                    <div className="h-2 bg-muted rounded-full overflow-hidden">
                      <div
                        className="h-full rounded-full"
                        style={{ width: `${(a.count / total) * 100}%`, backgroundColor: TYPE_COLORS[i % TYPE_COLORS.length] }}
                      />
                    </div>
                  </div>
                );
              })}
            </div>
          </CardContent>
        </Card>

        <Card className="lg:col-span-2">
          <CardHeader className="pb-2">
            <CardTitle className="text-sm font-bold">۱۰ فاکتور برتر</CardTitle>
          </CardHeader>
          <CardContent className="p-0">
            <table className="w-full text-sm">
              <thead className="bg-muted text-xs">
                <tr>
                  <th className="p-2.5 text-start rounded-s-lg">شماره</th>
                  <th className="p-2.5 text-start">شرکت</th>
                  <th className="p-2.5">کارشناس</th>
                  <th className="p-2.5 text-end rounded-e-lg">مبلغ (ریال)</th>
                </tr>
              </thead>
              <tbody>
                {data.topOrders.map((o) => (
                  <tr key={o.id} className="border-b last:border-0">
                    <td className="p-2.5 font-bold">{toPersianDigits(o.number)}</td>
                    <td className="p-2.5">{o.company.name}</td>
                    <td className="p-2.5 text-center text-xs text-muted-foreground">
                      {o.owner ? `${o.owner.firstName} ${o.owner.lastName}` : "—"}
                    </td>
                    <td className="p-2.5 text-end font-bold">{formatMoney(o.total)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
