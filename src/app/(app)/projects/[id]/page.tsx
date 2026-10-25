"use client";

/**
 * پیش‌نمایش پروژه — بازسازی ProjectPreview.cshtml خود CRMIdeal:
 * تولبار قبلی/بعدی + منوی حذف سه‌گانه + باکس‌های شروع/پایان/وضعیت (progress + pie)/مدت انجام/SLA
 * + توافق‌نامه سرفصل + ثبت مذاکره با وضعیت‌های مدل پیشرفت.
 */

import { use, useCallback, useEffect, useState } from "react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import {
  ArrowRight, ArrowLeft, Pencil, Trash2, Plus, Ticket, PauseCircle, PlayCircle,
  Archive, ArchiveRestore, FileWarning, Clock3,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { PieChart, Pie, Cell, ResponsiveContainer } from "recharts";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { formatDateTime } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";

type Status = { id: string; name: string; progressPercent: number; prjFinished: boolean; noCnvsDup: boolean; color: string | null };
type Conversation = {
  id: string; description: string; cnvsDate: string; doingTimeSec: number | null;
  statusName: string; statusPercent: number; statusColor: string | null;
  referUserName: string | null; registeredByName: string | null;
};
type ProjectDetail = {
  project: Record<string, unknown> & {
    id: string; number: number; title: string; postFix: string | null; referenceNumber: string | null;
    inquiryNumber: string | null; subject: string | null; description: string | null; descriptionAdditional: string | null;
    startDate: string | null; startDay: string | null; startTime: string | null;
    isFinished: boolean; finishedDate: string | null; finishedUserName: string | null; finishedDurationSec: number | null;
    remindDate: string | null; isTicket: boolean; ticketStop: boolean; ticketStopUserName: string | null; ticketStopDate: string | null;
    foCmpCanSee: boolean; foCmpCanInsCnvs: boolean; toDoTime: string | null; toDoTimeDone: string | null; toDoTimeSec: number | null;
    readDate: string | null; readUserName: string | null; readDurationSec: number | null;
    responseDate: string | null; responseUserName: string | null; responseDurationSec: number | null;
    firstDoingDate: string | null; firstDoingUserName: string | null; firstDoingDurationSec: number | null;
    registeredByName: string | null; lastEditedByName: string | null; starterName: string | null;
    priorityName: string | null; priorityColor: string | null; gradeName: string | null; groupName: string | null;
    titleGroupName: string | null; categoryName: string | null;
    companyId: string; companyName: string; statusGroup: { id: string; name: string; statuses: Status[] };
    titleGroup: { name: string; agreementActive: boolean; agreementDesc: string | null } | null;
  };
  conversations: Conversation[];
  progressPercent: number;
  lastStatus: { name: string; percent: number; color: string | null } | null;
  totalDoingSec: number;
  prevId: string | null;
  nextId: string | null;
};

const fmtDur = (sec: number | null | undefined) => {
  if (!sec) return "—";
  const d = Math.floor(sec / 86400);
  const h = Math.floor((sec % 86400) / 3600);
  const m = Math.round((sec % 3600) / 60);
  const parts = [d ? `${toPersianDigits(d)} روز` : "", h ? `${toPersianDigits(h)} ساعت` : "", m ? `${toPersianDigits(m)} دقیقه` : ""];
  return parts.filter(Boolean).join(" و ") || "کمتر از یک دقیقه";
};

export default function ProjectPreviewPage({ params }: { params: Promise<{ id: string }> }) {
  const { id } = use(params);
  const router = useRouter();
  const { toast } = useToast();
  const [data, setData] = useState<ProjectDetail | null>(null);
  const [perm, setPerm] = useState({ edit: false, del: false, delDep: false, cnvs: false, archive: false, ticketStop: false });
  const [cnvsOpen, setCnvsOpen] = useState(false);
  const [cnvsForm, setCnvsForm] = useState({ statusId: "", description: "", doingMinutes: "" });
  const [saving, setSaving] = useState(false);

  const load = useCallback(async () => {
    try {
      const res = await fetch(`/api/projects/${id}`);
      if (!res.ok) throw new Error((await res.json())?.error ?? "خطا");
      const d = (await res.json()) as ProjectDetail;
      setData(d);
      setCnvsForm((f) => ({ ...f, statusId: d.project.statusGroup.statuses.find((s) => s.id === (d.lastStatus ? undefined : ""))?.id ?? d.project.statusGroup.statuses[0]?.id ?? "" }));
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }, [id, toast]);

  useEffect(() => { load(); }, [load]);

  useEffect(() => {
    api<{ isAdmin: boolean; permissions: Record<string, string[]> }>("/api/auth/me").then((me) => {
      const has = (form: string, act: string) => me.isAdmin || (me.permissions[form] ?? []).includes(act);
      setPerm({
        edit: has("frmDefineProjects", "actPost"),
        del: has("frmProjectPreview", "actDelete"),
        delDep: has("frmProjectPreview", "actDeleteCmpProjectWithDep"),
        cnvs: has("frmConversations", "actInsert"),
        archive: has("frmDefineProjects", "actCanSetArchive"),
        ticketStop: has("frmDefineProjects", "actCanSetPrjIsTicket"),
      });
    }).catch(() => {});
  }, []);

  async function saveConversation() {
    if (!cnvsForm.statusId || !cnvsForm.description.trim()) {
      return toast({ title: "وضعیت و متن مذاکره الزامی است.", variant: "destructive" });
    }
    setSaving(true);
    try {
      const res = await api(`/api/projects/${id}/conversations`, {
        method: "POST",
        body: {
          statusId: cnvsForm.statusId,
          description: cnvsForm.description,
          doingTimeSec: cnvsForm.doingMinutes ? Number(cnvsForm.doingMinutes) * 60 : null,
        },
      }) as { archivedProject?: boolean };
      toast({ title: res.archivedProject ? "مذاکره ثبت شد — پروژه آرشیو شد." : "مذاکره ثبت شد." });
      setCnvsOpen(false);
      setCnvsForm({ statusId: "", description: "", doingMinutes: "" });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function toggleArchive(next: boolean) {
    try {
      await api(`/api/projects/${id}/archive`, { method: "PATCH", body: { isFinished: next } });
      toast({ title: next ? "پروژه آرشیو شد." : "پروژه از آرشیو خارج شد." });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function toggleTicketStop(next: boolean) {
    try {
      await api(`/api/projects/${id}/ticket-stop`, { method: "PATCH", body: { stop: next } });
      toast({ title: next ? "تیکت متوقف شد." : "تیکت از توقف خارج شد." });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function removeProject(mode: "simple" | "withDep") {
    const msg = mode === "simple"
      ? "حذف پروژه؟ (در صورت وجود مذاکره رد می‌شود)"
      : "حذف پروژه با همه مذاکرات و اطلاعات آن؟";
    if (!confirm(msg)) return;
    try {
      if (mode === "simple") await api(`/api/projects/${id}`, { method: "DELETE" });
      else await api(`/api/projects/${id}/with-dep`, { method: "DELETE" });
      toast({ title: "پروژه حذف شد." });
      router.push(`/companies/${data?.project.companyId ?? ""}`);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  if (!data) return <div className="text-center py-20 text-muted-foreground">در حال بارگذاری…</div>;
  const p = data.project;
  const pieData = [{ name: "پیشرفت", value: data.progressPercent }, { name: "باقی‌مانده", value: 100 - data.progressPercent }];

  return (
    <div className="max-w-5xl mx-auto space-y-4">
      {/* مسیر + تولبار — مثل ProjectPreview: قبلی/بعدی/حذف/ویرایش */}
      <div className="flex flex-wrap items-center justify-between gap-2">
        <div className="flex items-center gap-2 text-sm">
          <Link href={`/companies/${p.companyId}`} className="text-muted-foreground hover:text-foreground flex items-center gap-1">
            <ArrowRight className="w-4 h-4" />{p.companyName}
          </Link>
          <span className="text-muted-foreground">/</span>
          <span className="font-medium">{p.title}{p.postFix ? ` - ${p.postFix}` : ""}</span>
          {p.isTicket && <Ticket className="w-4 h-4 text-amber-600" />}
          {p.isFinished && <span className="text-[10px] bg-muted px-2 py-0.5 rounded-full text-muted-foreground">آرشیو</span>}
        </div>
        <div className="flex items-center gap-1.5">
          {data.prevId && (
            <Button variant="ghost" size="icon" className="h-8 w-8" asChild><Link href={`/projects/${data.prevId}`}><ArrowRight className="w-4 h-4" /></Link></Button>
          )}
          {data.nextId && (
            <Button variant="ghost" size="icon" className="h-8 w-8" asChild><Link href={`/projects/${data.nextId}`}><ArrowLeft className="w-4 h-4" /></Link></Button>
          )}
          {perm.cnvs && !p.isFinished && (
            <Button size="sm" className="h-8" onClick={() => setCnvsOpen(true)}><Plus className="w-4 h-4 me-1" />ثبت مذاکره</Button>
          )}
          {perm.edit && (
            <Button variant="outline" size="sm" className="h-8" asChild>
              <Link href={`/projects/${p.id}/edit`}><Pencil className="w-4 h-4 me-1" />ویرایش</Link>
            </Button>
          )}
          {perm.archive && (
            p.isFinished ? (
              <Button variant="outline" size="sm" className="h-8" onClick={() => toggleArchive(false)}><ArchiveRestore className="w-4 h-4 me-1" />خروج از آرشیو</Button>
            ) : (
              <Button variant="outline" size="sm" className="h-8" onClick={() => toggleArchive(true)}><Archive className="w-4 h-4 me-1" />آرشیو</Button>
            )
          )}
          {p.isTicket && perm.ticketStop && (
            p.ticketStop ? (
              <Button variant="outline" size="sm" className="h-8" onClick={() => toggleTicketStop(false)}><PlayCircle className="w-4 h-4 me-1" />ادامه تیکت</Button>
            ) : (
              <Button variant="outline" size="sm" className="h-8" onClick={() => toggleTicketStop(true)}><PauseCircle className="w-4 h-4 me-1" />توقف تیکت</Button>
            )
          )}
          {(perm.del || perm.delDep) && (
            <div className="flex items-center gap-1.5">
              {perm.del && (
                <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => removeProject("simple")} title="حذف پروژه">
                  <Trash2 className="w-4 h-4" />
                </Button>
              )}
              {perm.delDep && (
                <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive hover:text-destructive" onClick={() => removeProject("withDep")} title="حذف با همه اطلاعات">
                  <FileWarning className="w-4 h-4" />
                </Button>
              )}
            </div>
          )}
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-4">
        {/* ستون راست: شناسنامه */}
        <div className="lg:col-span-2 space-y-4">
          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">مشخصات پروژه</CardTitle></CardHeader>
            <CardContent className="grid grid-cols-2 sm:grid-cols-4 gap-x-4 gap-y-2 text-xs">
              <Field label="شماره" value={toPersianDigits(p.number)} />
              <Field label="شماره عطف" value={p.referenceNumber} />
              <Field label="شماره استعلام" value={p.inquiryNumber} />
              <Field label="سرفصل" value={p.titleGroupName} />
              <Field label="مدل پیشرفت" value={p.statusGroup.name} />
              <Field label="گروه" value={p.groupName} />
              <Field label="مقطع" value={p.gradeName} />
              <Field label="اولویت" value={p.priorityName} colored={p.priorityColor} />
              <Field label="دسته‌بندی" value={p.categoryName} />
              <Field label="آغازگر" value={p.starterName} />
              <Field label="تاریخ یادآوری" value={p.remindDate ? formatDateTime(p.remindDate) : null} />
              <Field label="ثبت‌کننده" value={p.registeredByName} />
              <div className="col-span-2 sm:col-span-4">
                <Field label="موضوع" value={p.subject} />
              </div>
              <div className="col-span-2 sm:col-span-4">
                <Field label="توضیح" value={p.description} />
              </div>
              {p.descriptionAdditional && (
                <div className="col-span-2 sm:col-span-4">
                  <Field label="توضیح تکمیلی" value={p.descriptionAdditional} />
                </div>
              )}
            </CardContent>
          </Card>

          {/* باکس وضعیت — عنوان وضعیت + progress + نمودار دایره‌ای مثل _PartialPrjPreview */}
          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">وضعیت و پیشرفت</CardTitle></CardHeader>
            <CardContent className="flex items-center gap-4">
              <div className="flex-1">
                <p className="text-sm font-bold mb-2" style={{ color: data.lastStatus?.color ?? undefined }}>
                  {data.lastStatus?.name ?? "بدون مذاکره (۰٪)"}
                </p>
                <div className="h-3 rounded-full bg-muted overflow-hidden">
                  <div
                    className="h-full rounded-full transition-all"
                    style={{ width: `${data.progressPercent}%`, backgroundColor: data.lastStatus?.color ?? "#0288d1" }}
                  />
                </div>
                <p className="text-[11px] text-muted-foreground mt-1.5">
                  درصد پیشرفت از وضعیت آخرین مذاکره محاسبه می‌شود.
                </p>
                <div className="grid grid-cols-2 gap-2 mt-3 text-[11px]">
                  <span>مدت انجام مذاکرات: {fmtDur(data.totalDoingSec)}</span>
                  <span>آخرین ویرایش: {p.lastEditedByName ?? "—"}</span>
                </div>
              </div>
              <div className="w-32 h-32 shrink-0">
                <ResponsiveContainer width="100%" height="100%">
                  <PieChart>
                    <Pie data={pieData} dataKey="value" innerRadius={34} outerRadius={56} startAngle={90} endAngle={-270} strokeWidth={0}>
                      <Cell fill={data.lastStatus?.color ?? "#0288d1"} />
                      <Cell fill="#e5eaf2" />
                    </Pie>
                  </PieChart>
                </ResponsiveContainer>
                <p className="text-center text-xs font-bold -mt-6">{toPersianDigits(data.progressPercent)}٪</p>
              </div>
            </CardContent>
          </Card>

          {/* مذاکرات پروژه — CnvsProjectConversations */}
          <Card id="conversations">
            <CardHeader className="pb-2">
              <div className="flex items-center justify-between">
                <CardTitle className="text-sm">مذاکرات پروژه ({toPersianDigits(data.conversations.length)})</CardTitle>
                {perm.cnvs && !p.isFinished && (
                  <Button size="sm" className="h-7 text-xs" onClick={() => setCnvsOpen(true)}><Plus className="w-3.5 h-3.5 me-1" />ثبت مذاکره</Button>
                )}
              </div>
            </CardHeader>
            <CardContent className="p-0">
              {data.conversations.length === 0 ? (
                <p className="text-xs text-muted-foreground text-center py-6">مذاکره‌ای ثبت نشده است.</p>
              ) : (
                data.conversations.map((c) => (
                  <div key={c.id} className="flex items-start gap-2 px-4 py-2.5 border-b last:border-0">
                    <span
                      className="text-[10px] px-1.5 py-0.5 rounded-full shrink-0 mt-0.5"
                      style={{ backgroundColor: (c.statusColor ?? "#0288d1") + "22", color: c.statusColor ?? "#0288d1" }}
                    >
                      {c.statusName}
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
            </CardContent>
          </Card>
        </div>

        {/* ستون چپ: باکس‌های شروع/پایان/تیکت/SLA/توافق‌نامه */}
        <div className="space-y-4">
          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">شروع</CardTitle></CardHeader>
            <CardContent className="space-y-1 text-xs">
              <Field label="آغازگر" value={p.starterName} />
              <Field label="تاریخ" value={p.startDate ? formatDateTime(p.startDate) : null} />
              <Field label="روز" value={p.startDay} />
              <Field label="ساعت" value={p.startTime} />
            </CardContent>
          </Card>

          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">پایان (آرشیو)</CardTitle></CardHeader>
            <CardContent className="space-y-1 text-xs">
              <Field label="آرشیوکننده" value={p.finishedUserName} />
              <Field label="تاریخ" value={p.finishedDate ? formatDateTime(p.finishedDate) : null} />
              <Field label="مدت تا آرشیو" value={fmtDur(p.finishedDurationSec)} />
            </CardContent>
          </Card>

          {p.isTicket && (
            <Card>
              <CardHeader className="pb-2"><CardTitle className="text-sm">تیکت</CardTitle></CardHeader>
              <CardContent className="space-y-1 text-xs">
                <Field label="وضعیت" value={p.ticketStop ? "متوقف" : "در جریان"} />
                {p.ticketStop && <Field label="متوقف‌کننده" value={p.ticketStopUserName} />}
                {p.ticketStop && <Field label="تاریخ توقف" value={p.ticketStopDate ? formatDateTime(p.ticketStopDate) : null} />}
                <Field label="نمایش در باشگاه" value={p.foCmpCanSee ? "بله" : "پنهان"} />
              </CardContent>
            </Card>
          )}

          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">زمان‌بندی انجام (ToDo)</CardTitle></CardHeader>
            <CardContent className="space-y-1 text-xs">
              <Field label="پیش‌بینی" value={p.toDoTime ? formatDateTime(p.toDoTime) : null} />
              <Field label="مدت پیش‌بینی" value={fmtDur(p.toDoTimeSec)} />
              <Field label="تحقق" value={p.toDoTimeDone ? formatDateTime(p.toDoTimeDone) : null} />
            </CardContent>
          </Card>

          {(p.readDate || p.responseDate || p.firstDoingDate) && (
            <Card>
              <CardHeader className="pb-2"><CardTitle className="text-sm">SLA تیکت</CardTitle></CardHeader>
              <CardContent className="space-y-1 text-xs">
                <Field label="اولین مطالعه" value={p.readDate ? `${p.readUserName} · ${fmtDur(p.readDurationSec)}` : null} />
                <Field label="اولین پاسخ" value={p.responseDate ? `${p.responseUserName} · ${fmtDur(p.responseDurationSec)}` : null} />
                <Field label="اولین اقدام" value={p.firstDoingDate ? `${p.firstDoingUserName} · ${fmtDur(p.firstDoingDurationSec)}` : null} />
              </CardContent>
            </Card>
          )}

          {p.titleGroup?.agreementActive && p.titleGroup.agreementDesc && (
            <Card>
              <CardHeader className="pb-2">
                <CardTitle className="text-sm flex items-center gap-1.5"><Clock3 className="w-4 h-4 text-muted-foreground" />توافق‌نامه سرفصل</CardTitle>
              </CardHeader>
              <CardContent>
                <p className="text-[11px] leading-5 text-muted-foreground">{p.titleGroup.agreementDesc}</p>
              </CardContent>
            </Card>
          )}
        </div>
      </div>

      {/* دیالوگ ثبت مذاکره */}
      <Dialog open={cnvsOpen} onOpenChange={setCnvsOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle>ثبت مذاکره</DialogTitle></DialogHeader>
          <div className="space-y-3">
            <div className="space-y-1.5">
              <Label>وضعیت *</Label>
              <Select value={cnvsForm.statusId} onValueChange={(v) => setCnvsForm({ ...cnvsForm, statusId: v })}>
                <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                <SelectContent>
                  {p.statusGroup.statuses.map((s) => (
                    <SelectItem key={s.id} value={s.id}>
                      {s.name} ({toPersianDigits(s.progressPercent)}٪){s.prjFinished ? " — آرشیوکننده" : ""}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <p className="text-[11px] text-muted-foreground">وضعیت‌های «آرشیوکننده» پروژه را آرشیو می‌کنند (نتیجهٔ وضعیت در خود CRMIdeal).</p>
            </div>
            <div className="space-y-1.5">
              <Label>متن مذاکره *</Label>
              <Textarea rows={4} value={cnvsForm.description} onChange={(e) => setCnvsForm({ ...cnvsForm, description: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>مدت انجام (دقیق)</Label>
              <Input dir="ltr" value={cnvsForm.doingMinutes} onChange={(e) => setCnvsForm({ ...cnvsForm, doingMinutes: e.target.value })} placeholder="مثلاً 45" />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setCnvsOpen(false)}>انصراف</Button>
            <Button onClick={saveConversation} disabled={saving}>{saving ? "در حال ثبت…" : "ثبت"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}

function Field({ label, value, colored }: { label: string; value: string | null | undefined; colored?: string | null }) {
  return (
    <div className="min-w-0">
      <p className="text-[10px] text-muted-foreground">{label}</p>
      <p className="font-medium truncate" style={{ color: colored ?? undefined }}>{value || "—"}</p>
    </div>
  );
}
