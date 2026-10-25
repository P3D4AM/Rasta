"use client";

/**
 * فرم درج/ویرایش پروژه — بازسازی ProjectInsert.cshtml / ProjectEdit.cshtml خود CRMIdeal
 * دو تب: اطلاعات اصلی + باشگاه مشتریان (فقط در ویرایش) — مطابق lblTabPrjMainInfo / lblTabPrjFo
 * قالب عنوان پیش‌فرض: انتخاب عنوان → پر شدن خودکار سرفصل/مدل پیشرفت/مقطع/اولویت/پسوند/یادآوری
 */

import { useCallback, useEffect, useMemo, useState } from "react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Checkbox } from "@/components/ui/checkbox";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { JalaliDateInput } from "@/components/rasta/jalali-date-input";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { toPersianDigits } from "@/lib/jalali";

type Title = { id: string; title: string; titleGroupId: string | null; statusGroupId: string | null; gradeId: string | null; priorityId: string | null; activeNumRWithTitle: boolean; postFix: string | null; remindDay: number | null; foCmpCanSee: boolean; isTicket: boolean };
type TitleGroup = { id: string; name: string };
type Group = { id: string; name: string };
type Grade = { id: string; name: string };
type Priority = { id: string; name: string; color: string | null };
type Category = { id: string; name: string; parentId: string | null };
type StatusGroup = { id: string; name: string; isActive: boolean };
type Department = { id: string; name: string };
type LightUser = { id: string; firstName: string; lastName: string };
type Me = { isAdmin: boolean; permissions: Record<string, string[]> };

type FormState = {
  title: string;
  referenceNumber: string;
  postFix: string;
  inquiryNumber: string;
  subject: string;
  description: string;
  descriptionAdditional: string;
  titleGroupId: string;
  groupId: string;
  gradeId: string;
  priorityId: string;
  categoryId: string;
  statusGroupId: string;
  starterUserId: string;
  startDate: string | null;
  startTime: string;
  remindDate: string | null;
  orderView: string;
  isFinished: boolean;
  finishedDate: string | null;
  isTicket: boolean;
  userDepartmentId: string;
  foCmpCanSee: boolean;
  foCmpCanInsCnvs: boolean;
  ticketStop: boolean;
  toDoDate: string | null;
  toDoTime: string;
  toDoMinutes: string;
};

const emptyForm: FormState = {
  title: "", referenceNumber: "", postFix: "", inquiryNumber: "", subject: "",
  description: "", descriptionAdditional: "", titleGroupId: "", groupId: "",
  gradeId: "", priorityId: "", categoryId: "", statusGroupId: "", starterUserId: "",
  startDate: null, startTime: "09:00:00", remindDate: null, orderView: "",
  isFinished: false, finishedDate: null, isTicket: false, userDepartmentId: "",
  foCmpCanSee: false, foCmpCanInsCnvs: true, ticketStop: false,
  toDoDate: null, toDoTime: "", toDoMinutes: "",
};

function todayIso(): string {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, "0")}-${String(d.getDate()).padStart(2, "0")}`;
}

export function ProjectForm({ mode, companyId, projectId }: { mode: "insert" | "edit"; companyId: string; projectId?: string }) {
  const router = useRouter();
  const { toast } = useToast();
  const [form, setForm] = useState<FormState>(emptyForm);
  const [defs, setDefs] = useState<{
    titles: Title[]; titleGroups: TitleGroup[]; groups: Group[]; grades: Grade[];
    priorities: Priority[]; categories: Category[]; statusGroups: StatusGroup[];
  }>({ titles: [], titleGroups: [], groups: [], grades: [], priorities: [], categories: [], statusGroups: [] });
  const [users, setUsers] = useState<LightUser[]>([]);
  const [departments, setDepartments] = useState<Department[]>([]);
  const [me, setMe] = useState<Me | null>(null);
  const [number, setNumber] = useState<number | null>(null);
  const [saving, setSaving] = useState(false);
  const [loaded, setLoaded] = useState(false);

  const setF = <K extends keyof FormState>(key: K, value: FormState[K]) => setForm((f) => ({ ...f, [key]: value }));

  const load = useCallback(async () => {
    try {
      const [titles, titleGroups, groups, grades, priorities, categories, statusGroups, usersRes, deps, meRes] = await Promise.all([
        api<{ rows: Title[] }>("/api/project-defs/titles"),
        api<{ rows: TitleGroup[] }>("/api/project-defs/titleGroups"),
        api<{ rows: Group[] }>("/api/project-defs/groups"),
        api<{ rows: Grade[] }>("/api/project-defs/grades"),
        api<{ rows: Priority[] }>("/api/project-defs/priorities"),
        api<{ rows: Category[] }>("/api/project-defs/categories"),
        api<{ rows: StatusGroup[] }>("/api/project-defs/statusGroups"),
        api<{ rows: LightUser[] }>("/api/users?light=1"),
        api<{ rows: Department[] }>("/api/user-org/departments"),
        api<Me>("/api/auth/me"),
      ]);
      setDefs({
        titles: titles.rows, titleGroups: titleGroups.rows, groups: groups.rows,
        grades: grades.rows, priorities: priorities.rows, categories: categories.rows,
        statusGroups: statusGroups.rows.filter((g) => g.isActive),
      });
      setUsers(usersRes.rows);
      setDepartments(deps.rows);
      setMe(meRes);

      if (mode === "edit" && projectId) {
        const res = await fetch(`/api/projects/${projectId}`);
        const data = await res.json();
        const p = data.project;
        const isoDate = (v: string | null) => (v ? v.slice(0, 10) : null);
        const hhmmss = (v: string | null) => (v ? v.slice(11, 19) : "");
        setNumber(p.number);
        setForm({
          ...emptyForm,
          title: p.title,
          referenceNumber: p.referenceNumber ?? "",
          postFix: p.postFix ?? "",
          inquiryNumber: p.inquiryNumber ?? "",
          subject: p.subject ?? "",
          description: p.description ?? "",
          descriptionAdditional: p.descriptionAdditional ?? "",
          titleGroupId: p.titleGroupId ?? "",
          groupId: p.groupId ?? "",
          gradeId: p.gradeId ?? "",
          priorityId: p.priorityId ?? "",
          categoryId: p.categoryId ?? "",
          statusGroupId: p.statusGroupId ?? "",
          starterUserId: p.starterUserId ?? "",
          startDate: isoDate(p.startDate),
          startTime: p.startTime ?? hhmmss(p.startDate) ?? "09:00:00",
          remindDate: isoDate(p.remindDate),
          orderView: p.orderView != null ? String(p.orderView) : "",
          isFinished: p.isFinished,
          finishedDate: isoDate(p.finishedDate),
          isTicket: p.isTicket,
          userDepartmentId: p.userDepartmentId ?? "",
          foCmpCanSee: p.foCmpCanSee,
          foCmpCanInsCnvs: p.foCmpCanInsCnvs,
          ticketStop: p.ticketStop,
          toDoDate: isoDate(p.toDoTime),
          toDoTime: p.toDoTime ? hhmmss(p.toDoTime).slice(0, 5) : "",
          toDoMinutes: p.toDoTimeSec != null ? String(Math.round(p.toDoTimeSec / 60)) : "",
        });
      } else {
        // درج: مقادیر پیش‌فرض — کاربر جاری و امروز
        setF("startDate", todayIso());
        if (meRes) {
          const mine = (usersRes.rows as LightUser[]).find((u) => u.id === (meRes as unknown as { id: string }).id);
          if (mine) setF("starterUserId", mine.id);
        }
      }
    } catch (e) {
      toast({ title: "خطا در بارگذاری داده‌ها", description: (e as Error).message, variant: "destructive" });
    } finally {
      setLoaded(true);
    }
  }, [mode, projectId]);

  useEffect(() => { load(); }, [load]);

  const canArchive = useMemo(() => !!me && (me.isAdmin || (me.permissions["frmDefineProjects"] ?? []).includes("actCanSetArchive")), [me]);
  const canTicket = useMemo(() => !!me && (me.isAdmin || (me.permissions["frmDefineProjects"] ?? []).includes("actCanSetPrjIsTicket")), [me]);

  /** قالب عنوان پیش‌فرض — پر کردن خودکار فیلدها مثل خود CRMIdeal */
  function applyTitle(titleId: string) {
    const t = defs.titles.find((x) => x.id === titleId);
    setForm((f) => ({
      ...f,
      title: t?.title ?? "",
      titleGroupId: t?.titleGroupId ?? "",
      statusGroupId: t?.statusGroupId ?? f.statusGroupId,
      gradeId: t?.gradeId ?? "",
      priorityId: t?.priorityId ?? "",
      postFix: t?.postFix ?? "",
      foCmpCanSee: t?.foCmpCanSee ?? false,
      isTicket: canTicket ? (t?.isTicket ?? false) : f.isTicket,
      remindDate: t?.remindDay != null ? new Date(Date.now() + t.remindDay * 86400000).toISOString().slice(0, 10) : f.remindDate,
    }));
  }

  async function save() {
    if (!form.title.trim()) return toast({ title: "عنوان الزامی است.", variant: "destructive" });
    if (!form.statusGroupId) return toast({ title: "مدل پیشرفت الزامی است.", variant: "destructive" });
    if (!form.startDate) return toast({ title: "تاریخ شروع الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const body: Record<string, unknown> = {
        companyId,
        title: form.title,
        referenceNumber: form.referenceNumber || null,
        postFix: form.postFix || null,
        inquiryNumber: form.inquiryNumber || null,
        subject: form.subject || null,
        description: form.description || null,
        descriptionAdditional: form.descriptionAdditional || null,
        titleGroupId: form.titleGroupId || null,
        groupId: form.groupId || null,
        gradeId: form.gradeId || null,
        priorityId: form.priorityId || null,
        categoryId: form.categoryId || null,
        statusGroupId: form.statusGroupId,
        starterUserId: form.starterUserId || null,
        startDate: form.startDate ? new Date(`${form.startDate}T${form.startTime || "00:00:00"}`).toISOString() : null,
        startTime: form.startTime || null,
        remindDate: form.remindDate ? new Date(`${form.remindDate}T00:00:00`).toISOString() : null,
        orderView: form.orderView ? Number(form.orderView) : null,
        isFinished: form.isFinished,
        finishedDate: form.isFinished && form.finishedDate ? new Date(`${form.finishedDate}T00:00:00`).toISOString() : null,
        isTicket: form.isTicket,
        userDepartmentId: form.userDepartmentId || null,
        foCmpCanSee: form.foCmpCanSee,
        foCmpCanInsCnvs: form.foCmpCanInsCnvs,
        ticketStop: form.ticketStop,
        toDoTime: form.toDoDate ? new Date(`${form.toDoDate}T${form.toDoTime || "00:00"}:00`).toISOString() : null,
        toDoTimeSec: form.toDoMinutes ? Number(form.toDoMinutes) * 60 : null,
      };
      if (mode === "insert") {
        const created = await api<{ id: string }>("/api/projects", { method: "POST", body });
        toast({ title: "پروژه ثبت شد." });
        router.push(`/projects/${created.id}`);
      } else if (projectId) {
        await api(`/api/projects/${projectId}`, { method: "PUT", body });
        toast({ title: "پروژه ویرایش شد." });
        router.push(`/projects/${projectId}`);
      }
    } catch (e) {
      toast({ title: "خطا در ثبت", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  if (!loaded) return <div className="text-center py-20 text-muted-foreground">در حال بارگذاری…</div>;

  return (
    <div className="max-w-5xl mx-auto space-y-4">
      <div className="flex items-center justify-between gap-2">
        <h1 className="text-lg font-extrabold">
          {mode === "insert" ? "درج پروژه" : `ویرایش پروژه${number ? ` — شماره ${toPersianDigits(number)}` : ""}`}
        </h1>
        <Button variant="outline" size="sm" asChild>
          <Link href={mode === "edit" && projectId ? `/projects/${projectId}` : `/companies/${companyId}`}>بازگشت</Link>
        </Button>
      </div>

      <Tabs defaultValue="main" dir="rtl">
        <TabsList>
          <TabsTrigger value="main">اطلاعات اصلی</TabsTrigger>
          <TabsTrigger value="fo">باشگاه مشتریان و تیکت</TabsTrigger>
        </TabsList>

        <TabsContent value="main">
          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">اطلاعات اصلی پروژه</CardTitle></CardHeader>
            <CardContent className="grid grid-cols-1 sm:grid-cols-3 gap-3">
              <div className="space-y-1.5 sm:col-span-2">
                <Label>عنوان *</Label>
                <Select value={form.title} onValueChange={applyTitle}>
                  <SelectTrigger><SelectValue placeholder="انتخاب عنوان پیش‌فرض…" /></SelectTrigger>
                  <SelectContent>
                    {defs.titles.map((t) => <SelectItem key={t.id} value={t.title}>{t.title}</SelectItem>)}
                  </SelectContent>
                </Select>
                <p className="text-[11px] text-muted-foreground">
                  عنوان‌های پیش‌فرض در <Link className="text-primary underline" href="/settings/project-defs">اطلاعات پایه پروژه‌ها</Link> تعریف می‌شوند و با انتخابشان فیلدها خودکار پر می‌شود.
                </p>
              </div>
              <div className="space-y-1.5">
                <Label>شماره (اتومات)</Label>
                <Input value={number ? toPersianDigits(number) : "پس از ثبت تخصیص می‌یابد"} disabled />
              </div>
              <div className="space-y-1.5">
                <Label>شماره عطف</Label>
                <Input dir="ltr" value={form.referenceNumber} onChange={(e) => setF("referenceNumber", e.target.value)} placeholder="مثلاً DP/1404/01" />
              </div>
              <div className="space-y-1.5">
                <Label>پسوند عنوان</Label>
                <Input value={form.postFix} onChange={(e) => setF("postFix", e.target.value)} placeholder="یکتا به تفکیک مخاطب" />
              </div>
              <div className="space-y-1.5">
                <Label>شماره استعلام</Label>
                <Input value={form.inquiryNumber} onChange={(e) => setF("inquiryNumber", e.target.value)} />
              </div>
              <div className="space-y-1.5 sm:col-span-3">
                <Label>موضوع</Label>
                <Textarea rows={2} value={form.subject} onChange={(e) => setF("subject", e.target.value)} />
              </div>
              <div className="space-y-1.5">
                <Label>مدل پیشرفت *</Label>
                <Select value={form.statusGroupId} onValueChange={(v) => setF("statusGroupId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {defs.statusGroups.map((g) => <SelectItem key={g.id} value={g.id}>{g.name}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>سرفصل</Label>
                <Select value={form.titleGroupId} onValueChange={(v) => setF("titleGroupId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {defs.titleGroups.map((g) => <SelectItem key={g.id} value={g.id}>{g.name}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>گروه پروژه</Label>
                <Select value={form.groupId} onValueChange={(v) => setF("groupId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {defs.groups.map((g) => <SelectItem key={g.id} value={g.id}>{g.name}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>مقطع</Label>
                <Select value={form.gradeId} onValueChange={(v) => setF("gradeId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {defs.grades.map((g) => <SelectItem key={g.id} value={g.id}>{g.name}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>اولویت</Label>
                <Select value={form.priorityId} onValueChange={(v) => setF("priorityId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {defs.priorities.map((g) => (
                      <SelectItem key={g.id} value={g.id}>
                        <span className="flex items-center gap-2">
                          {g.color && <span className="w-2.5 h-2.5 rounded-full inline-block" style={{ backgroundColor: g.color }} />}
                          {g.name}
                        </span>
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>دسته‌بندی</Label>
                <Select value={form.categoryId} onValueChange={(v) => setF("categoryId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {defs.categories.map((c) => <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>آغازگر</Label>
                <Select value={form.starterUserId} onValueChange={(v) => setF("starterUserId", v)}>
                  <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                  <SelectContent>
                    {users.map((u) => <SelectItem key={u.id} value={u.id}>{u.firstName} {u.lastName}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>تاریخ شروع *</Label>
                <JalaliDateInput value={form.startDate} onChange={(v) => setF("startDate", v)} />
              </div>
              <div className="space-y-1.5">
                <Label>ساعت شروع</Label>
                <Input dir="ltr" value={form.startTime} onChange={(e) => setF("startTime", e.target.value)} placeholder="09:00:00" />
              </div>
              <div className="space-y-1.5">
                <Label>تاریخ یادآوری / سررسید</Label>
                <JalaliDateInput value={form.remindDate} onChange={(v) => setF("remindDate", v)} />
              </div>
              <div className="space-y-1.5">
                <Label>ترتیب نمایش</Label>
                <Input dir="ltr" value={form.orderView} onChange={(e) => setF("orderView", e.target.value)} placeholder="مثلاً ۱۰" />
              </div>
              <div className="space-y-1.5 sm:col-span-2">
                <Label>توضیح</Label>
                <Textarea rows={2} value={form.description} onChange={(e) => setF("description", e.target.value)} placeholder="یکتا به تفکیک مخاطب" />
              </div>
              <div className="space-y-1.5">
                <Label>توضیح تکمیلی</Label>
                <Textarea rows={2} value={form.descriptionAdditional} onChange={(e) => setF("descriptionAdditional", e.target.value)} />
              </div>
              {canArchive && (
                <div className="sm:col-span-3 space-y-2 rounded-xl border p-3">
                  <span className="flex items-center gap-2">
                    <Checkbox id="isFinished" checked={form.isFinished} onCheckedChange={(v) => setF("isFinished", Boolean(v))} />
                    <Label htmlFor="isFinished" className="cursor-pointer">آرشیو پروژه</Label>
                  </span>
                  <p className="text-[11px] text-muted-foreground">به تب آرشیو منتقل و از نظر اول پنهان می‌شود.</p>
                  {form.isFinished && (
                    <div className="space-y-1.5">
                      <Label>تاریخ آرشیو</Label>
                      <JalaliDateInput value={form.finishedDate ?? todayIso()} onChange={(v) => setF("finishedDate", v)} />
                    </div>
                  )}
                </div>
              )}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="fo">
          <Card>
            <CardHeader className="pb-2"><CardTitle className="text-sm">باشگاه مشتریان و تیکت</CardTitle></CardHeader>
            <CardContent className="grid grid-cols-1 sm:grid-cols-3 gap-3">
              {canTicket && (
                <div className="space-y-1.5">
                  <Label>نوع پروژه</Label>
                  <Select value={form.isTicket ? "ticket" : "project"} onValueChange={(v) => setF("isTicket", v === "ticket")}>
                    <SelectTrigger><SelectValue /></SelectTrigger>
                    <SelectContent>
                      <SelectItem value="project">پروژه عادی</SelectItem>
                      <SelectItem value="ticket">پروژه از نوع تیکت</SelectItem>
                    </SelectContent>
                  </Select>
                </div>
              )}
              {form.isTicket && (
                <div className="space-y-1.5">
                  <Label>واحد سازمانی گیرنده تیکت</Label>
                  <Select value={form.userDepartmentId} onValueChange={(v) => setF("userDepartmentId", v)}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      {departments.map((d) => <SelectItem key={d.id} value={d.id}>{d.name}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </div>
              )}
              <div className="space-y-1.5">
                <Label>نمایش برای مخاطب در باشگاه</Label>
                <Select value={form.foCmpCanSee ? "yes" : "no"} onValueChange={(v) => setF("foCmpCanSee", v === "yes")}>
                  <SelectTrigger><SelectValue /></SelectTrigger>
                  <SelectContent>
                    <SelectItem value="no">پنهان از باشگاه</SelectItem>
                    <SelectItem value="yes">نمایش در باشگاه</SelectItem>
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-1.5">
                <Label>درج مذاکره از باشگاه</Label>
                <Select value={form.foCmpCanInsCnvs ? "yes" : "no"} onValueChange={(v) => setF("foCmpCanInsCnvs", v === "yes")}>
                  <SelectTrigger><SelectValue /></SelectTrigger>
                  <SelectContent>
                    <SelectItem value="yes">امکان درج مذاکره از باشگاه</SelectItem>
                    <SelectItem value="no">عدم امکان درج مذاکره از باشگاه</SelectItem>
                  </SelectContent>
                </Select>
              </div>
              {mode === "edit" && form.isTicket && canTicket && (
                <div className="sm:col-span-3 rounded-xl border p-3 space-y-1">
                  <span className="flex items-center gap-2">
                    <Checkbox id="ticketStop" checked={form.ticketStop} onCheckedChange={(v) => setF("ticketStop", Boolean(v))} />
                    <Label htmlFor="ticketStop" className="cursor-pointer">توقف تیکت</Label>
                  </span>
                  <p className="text-[11px] text-muted-foreground">تا اطلاع بعدی در جریان تیکت‌های هم‌زمان حساب نمی‌شود.</p>
                </div>
              )}
              <div className="space-y-1.5">
                <Label>زمان پیش‌بینی‌شده انجام (تاریخ)</Label>
                <JalaliDateInput value={form.toDoDate} onChange={(v) => setF("toDoDate", v)} />
              </div>
              <div className="space-y-1.5">
                <Label>ساعت پیش‌بینی</Label>
                <Input dir="ltr" value={form.toDoTime} onChange={(e) => setF("toDoTime", e.target.value)} placeholder="14:30" />
              </div>
              <div className="space-y-1.5">
                <Label>مدت پیش‌بینی (دقیق)</Label>
                <Input dir="ltr" value={form.toDoMinutes} onChange={(e) => setF("toDoMinutes", e.target.value)} placeholder="مثلاً ۱۲۰" />
              </div>
            </CardContent>
          </Card>
        </TabsContent>
      </Tabs>

      <div className="flex items-center gap-2 justify-end">
        <Button variant="outline" asChild>
          <Link href={mode === "edit" && projectId ? `/projects/${projectId}` : `/companies/${companyId}`}>انصراف</Link>
        </Button>
        <Button onClick={save} disabled={saving}>{saving ? "در حال ثبت…" : "ثبت"}</Button>
      </div>
    </div>
  );
}
