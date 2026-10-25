"use client";

import { use, useEffect, useState } from "react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import {
  ArrowRight, Phone, Mail, MapPin, Hash, Trash2,
  Users, Target, PhoneCall, ClipboardList, FileText, ReceiptText, FolderOpen,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { useToast } from "@/hooks/use-toast";
import { StatusBadge } from "@/components/rasta/status-badge";
import { ProjectsPanel } from "@/components/rasta/projects-panel";
import { api } from "@/hooks/use-list";
import { formatMoney, formatDate, formatDateTime } from "@/lib/format";
import {
  COMPANY_TYPE_LABELS, DEAL_STAGE_LABELS, ACTIVITY_TYPE_LABELS,
  QUOTATION_STATUS_LABELS, ORDER_STATUS_LABELS,
} from "@/lib/constants";
import { toPersianDigits } from "@/lib/jalali";

type CompanyDetail = {
  id: string; name: string; nameEn: string | null; type: string; industry: string | null;
  taxId: string | null; econCode: string | null; phone: string | null; email: string | null;
  website: string | null; province: string | null; city: string | null; address: string | null;
  description: string | null; status: string; createdAt: string;
  owner: { firstName: string; lastName: string } | null;
  contacts: { id: string; firstName: string; lastName: string; jobTitle: string | null; mobile: string | null; email: string | null; isPrimary: boolean }[];
  deals: { id: string; title: string; stage: string; amount: number | null; owner: { firstName: string; lastName: string } | null; expectedCloseAt: string | null }[];
  activities: { id: string; type: string; subject: string; occurredAt: string; user: { firstName: string; lastName: string } }[];
  tasks: { id: string; title: string; dueAt: string | null; priority: string; assignee: { firstName: string; lastName: string } }[];
  quotations: { id: string; number: number; status: string; total: number; createdAt: string; _count: { items: number } }[];
  orders: { id: string; number: number; status: string; total: number; paidTotal: number; createdAt: string; _count: { items: number } }[];
};

export default function CompanyDetailPage({
  params,
}: {
  params: Promise<{ id: string }>;
}) {
  const { id } = use(params);
  const router = useRouter();
  const { toast } = useToast();
  const [company, setCompany] = useState<CompanyDetail | null>(null);
  const [notFound, setNotFound] = useState(false);

  useEffect(() => {
    api<CompanyDetail>(`/api/companies/${id}`)
      .then(setCompany)
      .catch(() => setNotFound(true));
  }, [id]);

  async function remove() {
    if (!company || !confirm(`حذف «${company.name}»؟`)) return;
    try {
      await api(`/api/companies/${id}`, { method: "DELETE" });
      toast({ title: "شرکت حذف شد." });
      router.push("/companies");
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  if (notFound) {
    return (
      <div className="text-center py-20">
        <p className="text-muted-foreground mb-4">شرکت یافت نشد.</p>
        <Button variant="outline" asChild>
          <Link href="/companies"><ArrowRight className="w-4 h-4 me-1" />بازگشت به فهرست</Link>
        </Button>
      </div>
    );
  }

  if (!company) {
    return <div className="text-center py-20 text-muted-foreground">در حال بارگذاری…</div>;
  }

  const stats = [
    { label: "افراد", value: company.contacts.length, icon: Users },
    { label: "فرصت‌ها", value: company.deals.length, icon: Target },
    { label: "فعالیت‌ها", value: company.activities.length, icon: PhoneCall },
    { label: "فاکتورها", value: company.orders.length, icon: ReceiptText },
  ];

  return (
    <div>
      <div className="flex items-center gap-2 mb-4 text-sm">
        <Link href="/companies" className="text-muted-foreground hover:text-foreground flex items-center gap-1">
          <ArrowRight className="w-4 h-4" />
          مشتریان
        </Link>
        <span className="text-muted-foreground">/</span>
        <span className="font-medium">{company.name}</span>
      </div>

      <Card className="mb-4">
        <CardContent className="p-6">
          <div className="flex flex-col lg:flex-row justify-between gap-4">
            <div className="flex items-start gap-4">
              <div className="w-14 h-14 rounded-2xl bg-primary text-primary-foreground flex items-center justify-center font-black text-2xl shrink-0">
                {company.name[0] ?? "؟"}
              </div>
              <div>
                <div className="flex items-center gap-2 flex-wrap">
                  <h1 className="text-xl font-extrabold">{company.name}</h1>
                  <StatusBadge value={company.type} label={COMPANY_TYPE_LABELS[company.type] ?? company.type} />
                </div>
                {company.industry && <p className="text-sm text-muted-foreground mt-1">{company.industry}</p>}
                <div className="flex flex-wrap gap-x-4 gap-y-1.5 mt-3 text-xs text-muted-foreground">
                  {company.phone && <span className="flex items-center gap-1"><Phone className="w-3.5 h-3.5" /><span dir="ltr">{toPersianDigits(company.phone)}</span></span>}
                  {company.email && <span className="flex items-center gap-1"><Mail className="w-3.5 h-3.5" /><span dir="ltr">{company.email}</span></span>}
                  {(company.province || company.city) && <span className="flex items-center gap-1"><MapPin className="w-3.5 h-3.5" />{[company.province, company.city].filter(Boolean).join("، ")}</span>}
                  {company.website && <span className="flex items-center gap-1"><Hash className="w-3.5 h-3.5" /><span dir="ltr">{company.website}</span></span>}
                </div>
                {company.address && <p className="text-xs text-muted-foreground mt-2">{company.address}</p>}
              </div>
            </div>
            <div className="flex items-center gap-2 shrink-0">
              <Button variant="outline" size="sm" onClick={() => router.push(`/activities?companyId=${id}`)}>
                <PhoneCall className="w-4 h-4 me-1" />ثبت فعالیت
              </Button>
              <Button variant="outline" size="sm" className="text-destructive hover:text-destructive" onClick={remove}>
                <Trash2 className="w-4 h-4 me-1" />حذف
              </Button>
            </div>
          </div>
          <div className="grid grid-cols-2 sm:grid-cols-4 gap-3 mt-6">
            {stats.map((s) => (
              <div key={s.label} className="rounded-xl bg-muted/50 px-4 py-3 flex items-center gap-3">
                <s.icon className="w-4 h-4 text-primary" />
                <div>
                  <p className="text-[11px] text-muted-foreground">{s.label}</p>
                  <p className="font-extrabold">{toPersianDigits(s.value)}</p>
                </div>
              </div>
            ))}
          </div>
        </CardContent>
      </Card>

      <Tabs defaultValue="projects" dir="rtl">
        <TabsList className="mb-4">
          <TabsTrigger value="projects"><FolderOpen className="w-4 h-4 me-1" />پروژه‌ها</TabsTrigger>
          <TabsTrigger value="contacts"><Users className="w-4 h-4 me-1" />افراد</TabsTrigger>
          <TabsTrigger value="deals"><Target className="w-4 h-4 me-1" />فرصت‌ها</TabsTrigger>
          <TabsTrigger value="activities"><PhoneCall className="w-4 h-4 me-1" />فعالیت‌ها</TabsTrigger>
          <TabsTrigger value="tasks"><ClipboardList className="w-4 h-4 me-1" />وظایف</TabsTrigger>
          <TabsTrigger value="sales"><ReceiptText className="w-4 h-4 me-1" />اسناد فروش</TabsTrigger>
        </TabsList>

        <TabsContent value="projects">
          <Card>
            <CardContent className="p-0">
              <ProjectsPanel companyId={id} />
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="contacts">
          <Card>
            <CardContent className="p-0">
              {company.contacts.length === 0 ? (
                <Empty text="فردی برای این شرکت ثبت نشده است." />
              ) : (
                company.contacts.map((c) => (
                  <div key={c.id} className="flex items-center justify-between gap-3 px-5 py-3 border-b last:border-0">
                    <div>
                      <p className="text-sm font-bold">
                        {c.firstName} {c.lastName}
                        {c.isPrimary && <span className="ms-2 text-[10px] bg-primary/10 text-primary px-1.5 py-0.5 rounded-full font-bold">مخاطب اصلی</span>}
                      </p>
                      <p className="text-xs text-muted-foreground mt-0.5">{c.jobTitle ?? "—"}</p>
                    </div>
                    <div className="text-xs text-muted-foreground text-end">
                      {c.mobile && <p dir="ltr">{toPersianDigits(c.mobile)}</p>}
                      {c.email && <p dir="ltr">{c.email}</p>}
                    </div>
                  </div>
                ))
              )}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="deals">
          <Card>
            <CardContent className="p-0">
              {company.deals.length === 0 ? (
                <Empty text="فرصت فروشی ثبت نشده است." />
              ) : (
                company.deals.map((d) => (
                  <div key={d.id} className="flex items-center justify-between gap-3 px-5 py-3 border-b last:border-0">
                    <div>
                      <p className="text-sm font-bold">{d.title}</p>
                      <p className="text-xs text-muted-foreground mt-0.5">
                        {d.owner && `${d.owner.firstName} ${d.owner.lastName}`}
                        {d.expectedCloseAt && ` · پیش‌بینی: ${formatDate(d.expectedCloseAt)}`}
                      </p>
                    </div>
                    <div className="flex items-center gap-3">
                      <span className="text-xs text-muted-foreground">{formatMoney(d.amount)} ریال</span>
                      <StatusBadge value={d.stage} label={DEAL_STAGE_LABELS[d.stage] ?? d.stage} />
                    </div>
                  </div>
                ))
              )}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="activities">
          <Card>
            <CardContent className="p-0">
              {company.activities.length === 0 ? (
                <Empty text="فعالیتی ثبت نشده است." />
              ) : (
                company.activities.map((a) => (
                  <div key={a.id} className="flex items-start gap-3 px-5 py-3 border-b last:border-0">
                    <StatusBadge value={a.type} label={ACTIVITY_TYPE_LABELS[a.type] ?? a.type} />
                    <div className="flex-1">
                      <p className="text-sm font-medium">{a.subject}</p>
                      <p className="text-xs text-muted-foreground mt-0.5">
                        {a.user.firstName} {a.user.lastName} · {formatDateTime(a.occurredAt)}
                      </p>
                    </div>
                  </div>
                ))
              )}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="tasks">
          <Card>
            <CardContent className="p-0">
              {company.tasks.length === 0 ? (
                <Empty text="وظیفه بازی برای این شرکت وجود ندارد." />
              ) : (
                company.tasks.map((t) => (
                  <div key={t.id} className="flex items-center justify-between gap-3 px-5 py-3 border-b last:border-0">
                    <div>
                      <p className="text-sm font-medium">{t.title}</p>
                      <p className="text-xs text-muted-foreground mt-0.5">
                        {t.assignee.firstName} {t.assignee.lastName} · سررسید: {formatDate(t.dueAt)}
                      </p>
                    </div>
                    <StatusBadge value={t.priority} label={t.priority === "URGENT" ? "فوری" : t.priority === "HIGH" ? "مهم" : ""} />
                  </div>
                ))
              )}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="sales">
          <div className="space-y-3">
            <Card>
              <CardHeader className="pb-2">
                <CardTitle className="text-sm font-bold">پیش‌فاکتورها</CardTitle>
              </CardHeader>
              <CardContent className="p-0">
                {company.quotations.length === 0 ? (
                  <Empty text="پیش‌فاکتوری صادر نشده است." />
                ) : (
                  company.quotations.map((q) => (
                    <div key={q.id} className="flex items-center justify-between gap-3 px-5 py-3 border-b last:border-0">
                      <div className="flex items-center gap-2 text-sm">
                        <FileText className="w-4 h-4 text-muted-foreground" />
                        پیش‌فاکتور {toPersianDigits(q.number)}
                        <span className="text-xs text-muted-foreground">({toPersianDigits(q._count.items)} ردیف)</span>
                      </div>
                      <div className="flex items-center gap-3">
                        <span className="text-xs text-muted-foreground">{formatMoney(q.total)} ریال</span>
                        <StatusBadge value={q.status} label={QUOTATION_STATUS_LABELS[q.status] ?? q.status} />
                      </div>
                    </div>
                  ))
                )}
              </CardContent>
            </Card>
            <Card>
              <CardHeader className="pb-2">
                <CardTitle className="text-sm font-bold">فاکتورها</CardTitle>
              </CardHeader>
              <CardContent className="p-0">
                {company.orders.length === 0 ? (
                  <Empty text="فاکتوری صادر نشده است." />
                ) : (
                  company.orders.map((o) => (
                    <div key={o.id} className="flex items-center justify-between gap-3 px-5 py-3 border-b last:border-0">
                      <Link href={`/orders?focus=${o.id}`} className="flex items-center gap-2 text-sm hover:underline">
                        <ReceiptText className="w-4 h-4 text-muted-foreground" />
                        فاکتور {toPersianDigits(o.number)}
                      </Link>
                      <div className="flex items-center gap-3">
                        <span className="text-xs text-muted-foreground">
                          {formatMoney(o.paidTotal)} / {formatMoney(o.total)} ریال
                        </span>
                        <StatusBadge value={o.status} label={ORDER_STATUS_LABELS[o.status] ?? o.status} />
                      </div>
                    </div>
                  ))
                )}
              </CardContent>
            </Card>
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
}

function Empty({ text }: { text: string }) {
  return <p className="text-sm text-muted-foreground text-center py-10">{text}</p>;
}
