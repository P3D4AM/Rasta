"use client";

/**
 * تعریف کاربران — بازسازی UserDefine.cshtml خود CRMIdeal:
 *  - فیلتر رادیویی فعال/غیرفعال/همه + جستجو
 *  - تب «اطلاعات کاربر»: پنل با ناوبری اول/قبلی/بعدی/آخر + دکمه‌های مجوزدار
 *    (درج/ویرایش/حذف/اطلاعات بیشتر/امضا/تعیین ساعت ورود/شمارش کاربران)
 *  - تب «لیست کاربران»: گرید با ستون‌های خود محصول (نام/فامیل/کد پرسنلی/نام کاربری/نقش/فعال)
 *  - تب «اطلاعات بیشتر»: ویرایش مشخصات شناسنامه‌ای (actEditMoreInfo)
 *  - تب «حساب‌های بانکی»: حساب‌های بانکی کاربر (actManageBankingAccounts)
 */

import { useCallback, useEffect, useMemo, useState } from "react";
import {
  Plus, Pencil, Trash2, ChevronsRight, ChevronRight, ChevronLeft, ChevronsLeft,
  UserRound, KeyRound, Clock, Users2, Landmark, Search,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Checkbox } from "@/components/ui/checkbox";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from "@/components/ui/dialog";
import { JalaliDateInput } from "@/components/rasta/jalali-date-input";
import { PageHeader } from "@/components/rasta/page-header";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { fetchMe } from "@/lib/client-me";
import { formatDate } from "@/lib/format";
import { toPersianDigits } from "@/lib/jalali";
import { WEEK_DAYS } from "@/lib/constants";

type URow = {
  id: string; firstName: string; lastName: string; nickName: string | null; persCode: string | null;
  username: string; isAdmin: boolean; isActive: boolean; roleId: string | null; roleName: string | null;
  positionName: string | null; departmentName: string | null; userGroupName: string | null;
  mobile: string | null; email: string | null; expireDate: string | null; lastLoginAt: string | null;
};

type UDetail = URow & {
  fatherName: string | null; nationalCode: string | null; identityNumber: string | null; insuranceCode: string | null;
  mobileII: string | null; address: string | null; tel: string | null; telDesc: string | null; description: string | null;
  extensions: string | null; callPreNumber: string | null; startDate: string | null; defCmpPrjTitle: string | null;
  disableInternalMessageAlarmVoice: boolean; disableReceiveCnvsInfoAllarm: boolean;
  accessDailyChartAllUsers: boolean; accessSaleChartAllUsers: boolean;
  userGroupId: string | null; positionId: string | null; departmentId: string | null; responsibleUserId: string | null;
  hasSignature: boolean; responsibleName: string | null;
};

type LoginTime = { id: string; dayOfWeek: number | null; fromTime: string; toTime: string; fromDate: string | null; toDate: string | null; ipAddress: string | null };
type BankAcc = { id: string; accountTypeName: string; accountNumber: string; cardNumber: string | null; shabaNumber: string | null; accountTitle: string; bankName: string | null; branchName: string | null; isDefault: boolean };

type emptyUser = Record<string, string | boolean>;
const emptyForm: emptyUser = {
  username: "", password: "", firstName: "", lastName: "", nickName: "", persCode: "",
  email: "", phone: "", mobile: "", mobileII: "", fatherName: "", nationalCode: "",
  identityNumber: "", insuranceCode: "", tel: "", telDesc: "", address: "", description: "",
  extensions: "", callPreNumber: "", defCmpPrjTitle: "", roleId: "", isAdmin: false, isActive: true,
  disableInternalMessageAlarmVoice: false, disableReceiveCnvsInfoAllarm: false,
  accessDailyChartAllUsers: false, accessSaleChartAllUsers: false,
  userGroupId: "", positionId: "", departmentId: "", responsibleUserId: "", startDate: "", expireDate: "",
};

export default function UsersPage() {
  const { toast } = useToast();
  const [filter, setFilter] = useState<"active" | "inactive" | "all">("active");
  const [search, setSearch] = useState("");
  const [rows, setRows] = useState<URow[]>([]);
  const [idx, setIdx] = useState(0);
  const [detail, setDetail] = useState<UDetail | null>(null);
  const [loading, setLoading] = useState(true);
  const [me, setMe] = useState<{ id?: string; isAdmin: boolean; permissions: Record<string, string[]> } | null>(null);

  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState<emptyUser>(emptyForm);
  const [saving, setSaving] = useState(false);
  const [roles, setRoles] = useState<{ id: string; name: string }[]>([]);
  const [positions, setPositions] = useState<{ id: string; name: string }[]>([]);
  const [departments, setDepartments] = useState<{ id: string; name: string }[]>([]);
  const [userGroups, setUserGroups] = useState<{ id: string; name: string }[]>([]);
  const [usersLight, setUsersLight] = useState<{ id: string; firstName: string; lastName: string }[]>([]);

  const [sigOpen, setSigOpen] = useState(false);
  const [timesOpen, setTimesOpen] = useState(false);
  const [countOpen, setCountOpen] = useState(false);
  const [bankOpen, setBankOpen] = useState(false);
  const [loginTimes, setLoginTimes] = useState<LoginTime[]>([]);
  const [timeForm, setTimeForm] = useState({ dayOfWeek: "__ALL__", fromTime: "08:00", toTime: "18:00", fromDate: "", toDate: "", ipAddress: "" });
  const [bankAccs, setBankAccs] = useState<BankAcc[]>([]);
  const [bankForm, setBankForm] = useState({ branchId: "", accountTypeId: "", accountNumber: "", cardNumber: "", shabaNumber: "", desc: "" });
  const [branches, setBranches] = useState<{ id: string; name: string; bank: { name: string } }[]>([]);
  const [accTypes, setAccTypes] = useState<{ id: string; name: string }[]>([]);
  const [count, setCount] = useState<{ total: number; active: number; inactive: number; admins: number; byRole: { name: string; count: number }[] } | null>(null);

  const has = useCallback((act: string) => !!me && (me.isAdmin || (me.permissions["frmDefineUsers"] ?? []).includes(act)), [me]);
  const current = rows[idx] ?? null;

  const loadList = useCallback(async () => {
    setLoading(true);
    try {
      const q = new URLSearchParams({ filter, search });
      const data = await api<{ rows: URow[] }>(`/api/users?${q}`);
      setRows(data.rows);
      setIdx((i) => Math.min(i, Math.max(0, data.rows.length - 1)));
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setLoading(false);
    }
  }, [filter, search, toast]);

  useEffect(() => { loadList(); }, [loadList]);

  useEffect(() => {
    fetchMe().then((m) => { if (m) setMe(m); });
    Promise.all([
      api<{ rows: { id: string; name: string }[] }>("/api/roles?light=1"),
      api<{ rows: { id: string; name: string }[] }>("/api/user-org/positions"),
      api<{ rows: { id: string; name: string }[] }>("/api/user-org/departments"),
      api<{ rows: { id: string; name: string }[] }>("/api/user-org/groups"),
      api<{ rows: { id: string; firstName: string; lastName: string }[] }>("/api/users?light=1"),
    ]).then(([r, p, d, g, u]) => {
      setRoles(r.rows); setPositions(p.rows); setDepartments(d.rows); setUserGroups(g.rows);
      setUsersLight(u.rows.filter((x) => x.id !== me?.id));
    }).catch(() => {});
  }, []);

  const loadDetail = useCallback(async (id: string) => {
    try {
      const d = await api<UDetail>(`/api/users/${id}`);
      setDetail(d);
    } catch { setDetail(null); }
  }, []);

  useEffect(() => { if (current) loadDetail(current.id); else setDetail(null); }, [current, loadDetail]);

  const nameOf = (u: { firstName: string; lastName: string } | null) => (u ? `${u.firstName} ${u.lastName}` : "—");

  async function openDialog(edit: boolean) {
    if (edit && detail) {
      const d = detail;
      setForm({
        ...emptyForm,
        username: d.username, firstName: d.firstName, lastName: d.lastName, nickName: d.nickName ?? "",
        persCode: d.persCode ?? "", email: d.email ?? "", mobile: d.mobile ?? "", mobileII: d.mobileII ?? "",
        fatherName: d.fatherName ?? "", nationalCode: d.nationalCode ?? "", identityNumber: d.identityNumber ?? "",
        insuranceCode: d.insuranceCode ?? "", tel: d.tel ?? "", telDesc: d.telDesc ?? "", address: d.address ?? "",
        description: d.description ?? "", extensions: d.extensions ?? "", callPreNumber: d.callPreNumber ?? "",
        defCmpPrjTitle: d.defCmpPrjTitle ?? "", roleId: d.roleId ?? "", isAdmin: d.isAdmin, isActive: d.isActive,
        disableInternalMessageAlarmVoice: d.disableInternalMessageAlarmVoice,
        disableReceiveCnvsInfoAllarm: d.disableReceiveCnvsInfoAllarm,
        accessDailyChartAllUsers: d.accessDailyChartAllUsers, accessSaleChartAllUsers: d.accessSaleChartAllUsers,
        userGroupId: d.userGroupId ?? "", positionId: d.positionId ?? "", departmentId: d.departmentId ?? "",
        responsibleUserId: d.responsibleUserId ?? "",
        startDate: d.startDate ? d.startDate.slice(0, 10) : "", expireDate: d.expireDate ? d.expireDate.slice(0, 10) : "",
      });
    } else {
      setForm(emptyForm);
    }
    setDialogOpen(true);
  }

  async function save() {
    if (!String(form.firstName).trim() || !String(form.lastName).trim() || !String(form.username).trim()) {
      return toast({ title: "نام، نام خانوادگی و نام کاربری الزامی است.", variant: "destructive" });
    }
    if (!form.roleId) return toast({ title: "تخصیص نقش الزامی است.", variant: "destructive" });
    if (!detail && String(form.password).length < 6) {
      return toast({ title: "رمز عبور باید حداقل ۶ کاراکتر باشد.", variant: "destructive" });
    }
    setSaving(true);
    try {
      const body = { ...form };
      if (detail && !String(body.password)) delete (body as Record<string, unknown>).password;
      if (detail) await api(`/api/users/${detail.id}`, { method: "PUT", body });
      else await api("/api/users", { method: "POST", body });
      toast({ title: detail ? "کاربر ویرایش شد." : "کاربر ایجاد شد." });
      setDialogOpen(false);
      loadList();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function deactivate() {
    if (!detail) return;
    if (!confirm(`غیرفعال‌سازی حساب «${detail.firstName} ${detail.lastName}»؟`)) return;
    try {
      await api(`/api/users/${detail.id}`, { method: "DELETE" });
      toast({ title: "کاربر غیرفعال شد." });
      loadList();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function openTimes() {
    if (!detail) return;
    try {
      const d = await api<{ rows: LoginTime[] }>(`/api/users/${detail.id}/login-times`);
      setLoginTimes(d.rows);
      setTimesOpen(true);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function addTime() {
    if (!detail) return;
    try {
      await api(`/api/users/${detail.id}/login-times`, {
        method: "POST",
        body: {
          dayOfWeek: timeForm.dayOfWeek === "__ALL__" ? null : Number(timeForm.dayOfWeek),
          fromTime: timeForm.fromTime, toTime: timeForm.toTime,
          fromDate: timeForm.fromDate || null, toDate: timeForm.toDate || null,
          ipAddress: timeForm.ipAddress || null,
        },
      });
      const d = await api<{ rows: LoginTime[] }>(`/api/users/${detail.id}/login-times`);
      setLoginTimes(d.rows);
      toast({ title: "قاعده ساعت ورود ثبت شد." });
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function removeTime(timeId: string) {
    if (!detail) return;
    try {
      await api(`/api/users/${detail.id}/login-times/${timeId}`, { method: "DELETE" });
      setLoginTimes((r) => r.filter((x) => x.id !== timeId));
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function openBank() {
    if (!detail) return;
    try {
      // فراخوانی نوع‌ها/شعبه‌ها از API بانک‌داری (نیازمند frmBanking/actView)؛ بدون دسترسی فقط لیست حساب‌های کاربر باز می‌شود
      const accs = await api<{ rows: BankAcc[] }>(`/api/users/${detail.id}/bank-accounts`);
      setBankAccs(accs.rows);
      try {
        const meta = await api<{ types: { id: string; name: string }[]; branches: { id: string; name: string; bank: { name: string } }[] }>("/api/banking/accounts");
        setBranches(meta.branches);
        setAccTypes(meta.types);
      } catch {
        setBranches([]);
        setAccTypes([]);
      }
      setBankOpen(true);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function uploadSignature(file: File) {
    if (!detail) return;
    if (file.size > 300 * 1024) return toast({ title: "حجم فایل بیش از ۳۰۰KB است.", variant: "destructive" });
    const b64 = await new Promise<string>((resolve, reject) => {
      const fr = new FileReader();
      fr.onload = () => resolve(String(fr.result));
      fr.onerror = reject;
      fr.readAsDataURL(file);
    });
    try {
      await api(`/api/users/${detail.id}/signature`, { method: "POST", body: { base64: b64 } });
      toast({ title: "امضا بارگذاری شد." });
      loadDetail(detail.id);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function removeSignature() {
    if (!detail) return;
    try {
      await api(`/api/users/${detail.id}/signature`, { method: "DELETE" });
      toast({ title: "امضا حذف شد." });
      loadDetail(detail.id);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function openCount() {
    try {
      const d = await api<{ total: number; active: number; inactive: number; admins: number; byRole: { name: string; count: number }[] }>("/api/users/count");
      setCount(d);
      setCountOpen(true);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const F = (label: string, value: string | null | undefined) => (
    <div className="min-w-0">
      <p className="text-[10px] text-muted-foreground">{label}</p>
      <p className="text-xs font-medium truncate">{value || "—"}</p>
    </div>
  );

  const navBtn = (icon: React.ReactNode, disabled: boolean, onClick: () => void, title: string) => (
    <Button variant="outline" size="icon" className="h-8 w-8" disabled={disabled || loading || rows.length === 0} onClick={onClick} title={title}>
      {icon}
    </Button>
  );

  const total = rows.length;
  const posLabel = total ? `رکورد ${toPersianDigits(idx + 1)} از ${toPersianDigits(total)}` : "بدون رکورد";

  return (
    <div>
      <PageHeader
        title="تعریف کاربران"
        subtitle={posLabel}
        actions={
          <div className="flex items-center gap-2">
            {has("actShowDetailsUserCount") && (
              <Button variant="outline" size="sm" onClick={openCount}><Users2 className="w-4 h-4 me-1" />نمایش جزئیات تعداد کاربران</Button>
            )}
            {has("actInsert") && (
              <Button size="sm" onClick={() => openDialog(false)}><Plus className="w-4 h-4 me-1" />درج کاربر</Button>
            )}
          </div>
        }
      />

      {/* فیلتر رادیویی + جستجو — مثل UserDefIsActive/UserDefInActive/UserDefAll + SearchUserValue */}
      <div className="flex flex-wrap items-center gap-3 mb-4">
        <div className="flex items-center gap-1.5 text-xs">
          {(["active", "inactive", "all"] as const).map((f) => (
            <label key={f} className="flex items-center gap-1.5 cursor-pointer">
              <input type="radio" checked={filter === f} onChange={() => setFilter(f)} className="accent-primary" />
              {f === "active" ? "فعال" : f === "inactive" ? "غیرفعال" : "همه"}
            </label>
          ))}
        </div>
        <div className="relative ms-auto">
          <Search className="w-4 h-4 absolute right-2.5 top-2.5 text-muted-foreground" />
          <Input className="h-9 w-64 ps-8" placeholder="جستجوی نام / نام‌کاربری / کد پرسنلی…" value={search} onChange={(e) => setSearch(e.target.value)} />
        </div>
      </div>

      <Tabs defaultValue="info" dir="rtl">
        <TabsList className="mb-4">
          <TabsTrigger value="info"><UserRound className="w-4 h-4 me-1" />اطلاعات کاربر</TabsTrigger>
          <TabsTrigger value="list">لیست کاربران</TabsTrigger>
          <TabsTrigger value="more">اطلاعات بیشتر</TabsTrigger>
          <TabsTrigger value="bank"><Landmark className="w-4 h-4 me-1" />حساب‌های بانکی</TabsTrigger>
        </TabsList>

        {/* ── تب اطلاعات کاربر — پنل + ناوبری ── */}
        <TabsContent value="info">
          <Card>
            <CardContent className="p-4">
              <div className="flex flex-wrap items-center gap-1.5 pb-3 border-b mb-4">
                {navBtn(<ChevronsRight className="w-4 h-4" />, idx <= 0, () => setIdx(0), "اول")}
                {navBtn(<ChevronRight className="w-4 h-4" />, idx <= 0, () => setIdx(idx - 1), "قبلی")}
                {navBtn(<ChevronLeft className="w-4 h-4" />, idx >= total - 1, () => setIdx(idx + 1), "بعدی")}
                {navBtn(<ChevronsLeft className="w-4 h-4" />, idx >= total - 1, () => setIdx(total - 1), "آخر")}
                <span className="mx-2 text-[11px] text-muted-foreground">{posLabel}</span>
                <span className="flex-1" />
                {has("actEdit") && detail && <Button variant="outline" size="sm" className="h-8" onClick={() => openDialog(true)}><Pencil className="w-4 h-4 me-1" />ویرایش</Button>}
                {has("actDelete") && detail && me?.id !== detail.id && (
                  <Button variant="outline" size="sm" className="h-8 text-destructive hover:text-destructive" onClick={deactivate}><Trash2 className="w-4 h-4 me-1" />حذف/غیرفعال</Button>
                )}
                {has("actEditMoreInfo") && detail && (
                  <Button variant="outline" size="sm" className="h-8" onClick={() => openDialog(true)}>اطلاعات بیشتر</Button>
                )}
                {has("actUploadSignature") && detail && (
                  <Button variant="outline" size="sm" className="h-8" onClick={() => setSigOpen(true)}><KeyRound className="w-4 h-4 me-1" />امضای دیجیتال</Button>
                )}
                {has("actLoginAllowedTimes") && detail && (
                  <Button variant="outline" size="sm" className="h-8" onClick={openTimes}><Clock className="w-4 h-4 me-1" />تعیین ساعت ورود</Button>
                )}
              </div>

              {!detail ? (
                <p className="text-sm text-muted-foreground text-center py-10">{loading ? "در حال بارگذاری…" : "کاربری در این فیلتر یافت نشد."}</p>
              ) : (
                <div className="grid grid-cols-2 sm:grid-cols-4 lg:grid-cols-5 gap-3">
                  {F("نام", detail.firstName)}
                  {F("نام خانوادگی", detail.lastName)}
                  {F("نام مستعار", detail.nickName)}
                  {F("نام کاربری", detail.username)}
                  {F("کد پرسنلی", detail.persCode)}
                  {F("نقش", detail.roleName)}
                  {F("سمت", detail.positionName)}
                  {F("دپارتمان", detail.departmentName)}
                  {F("گروه کاربری", detail.userGroupName)}
                  {F("مسئول مستقیم", detail.responsibleName)}
                  {F("موبایل", detail.mobile)}
                  {F("ایمیل", detail.email)}
                  {F("شماره‌های داخلی", detail.extensions)}
                  {F("تاریخ شروع", detail.startDate ? formatDate(detail.startDate) : null)}
                  {F("تاریخ انقضا", detail.expireDate ? formatDate(detail.expireDate) : null)}
                  {F("آخرین ورود", detail.lastLoginAt ? formatDate(detail.lastLoginAt) : null)}
                  <div>
                    <p className="text-[10px] text-muted-foreground">وضعیت</p>
                    <p className={`text-xs font-bold ${detail.isActive ? "text-emerald-600" : "text-rose-600"}`}>{detail.isActive ? "فعال" : "غیرفعال"}</p>
                  </div>
                  <div>
                    <p className="text-[10px] text-muted-foreground">امضا</p>
                    <p className="text-xs font-medium">{detail.hasSignature ? "ثبت شده" : "—"}</p>
                  </div>
                  {detail.description && <div className="col-span-2 sm:col-span-4 lg:col-span-5">{F("توضیحات", detail.description)}</div>}
                </div>
              )}
            </CardContent>
          </Card>
        </TabsContent>

        {/* ── تب لیست کاربران — گرید خود محصول ── */}
        <TabsContent value="list">
          <div className="border rounded-xl overflow-x-auto bg-card">
            <table className="w-full text-xs min-w-[720px]">
              <thead className="bg-muted/60 text-muted-foreground">
                <tr>
                  <th className="px-3 py-2.5 text-start font-medium">ردیف</th>
                  <th className="px-3 py-2.5 text-start font-medium">نام</th>
                  <th className="px-3 py-2.5 text-start font-medium">نام خانوادگی</th>
                  <th className="px-3 py-2.5 text-start font-medium">کد پرسنلی</th>
                  <th className="px-3 py-2.5 text-start font-medium">نام کاربری</th>
                  <th className="px-3 py-2.5 text-start font-medium">نقش</th>
                  <th className="px-3 py-2.5 text-start font-medium">فعال (وب)</th>
                  <th className="px-3 py-2.5" />
                </tr>
              </thead>
              <tbody>
                {loading ? (
                  <tr><td colSpan={8} className="text-center py-8 text-muted-foreground">در حال بارگذاری…</td></tr>
                ) : rows.length === 0 ? (
                  <tr><td colSpan={8} className="text-center py-8 text-muted-foreground">کاربری یافت نشد.</td></tr>
                ) : (
                  rows.map((u, i) => (
                    <tr key={u.id} className={`border-t cursor-pointer hover:bg-muted/30 ${idx === i ? "bg-primary/5" : ""}`} onClick={() => setIdx(i)}>
                      <td className="px-3 py-2.5 text-muted-foreground">{toPersianDigits(i + 1)}</td>
                      <td className="px-3 py-2.5 font-medium">{u.firstName}</td>
                      <td className="px-3 py-2.5 font-medium">{u.lastName}</td>
                      <td className="px-3 py-2.5 text-muted-foreground">{u.persCode ?? "—"}</td>
                      <td className="px-3 py-2.5" dir="ltr">{u.username}</td>
                      <td className="px-3 py-2.5 text-muted-foreground">{u.roleName ?? "—"}</td>
                      <td className="px-3 py-2.5">
                        <span className={`font-bold ${u.isActive ? "text-emerald-600" : "text-rose-600"}`}>{u.isActive ? "فعال" : "غیرفعال"}</span>
                      </td>
                      <td className="px-3 py-2.5 text-end" onClick={(e) => e.stopPropagation()}>
                        {has("actEdit") && (
                          <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => { setIdx(i); openDialog(true); }} title="ویرایش">
                            <Pencil className="w-3.5 h-3.5" />
                          </Button>
                        )}
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        </TabsContent>

        {/* ── تب اطلاعات بیشتر ── */}
        <TabsContent value="more">
          <Card>
            <CardContent className="p-4">
              {!detail ? (
                <p className="text-sm text-muted-foreground text-center py-10">ابتدا کاربری را انتخاب کنید.</p>
              ) : (
                <>
                  <div className="grid grid-cols-2 sm:grid-cols-4 gap-3">
                    {F("نام پدر", detail.fatherName)}
                    {F("کد ملی", detail.nationalCode)}
                    {F("شماره شناسنامه", detail.identityNumber)}
                    {F("کد بیمه", detail.insuranceCode)}
                    {F("موبایل دوم", detail.mobileII)}
                    {F("تلفن", detail.tel)}
                    {F("توضیح تلفن", detail.telDesc)}
                    {F("عنوان پیش‌فرض پروژه", detail.defCmpPrjTitle)}
                  </div>
                  <div className="mt-3 space-y-2">
                    {F("نشانی", detail.address)}
                    {F("توضیحات", detail.description)}
                  </div>
                  {has("actEditMoreInfo") && (
                    <Button size="sm" className="mt-4" onClick={() => openDialog(true)}>
                      <Pencil className="w-4 h-4 me-1" />ویرایش اطلاعات تکمیلی
                    </Button>
                  )}
                </>
              )}
            </CardContent>
          </Card>
        </TabsContent>

        {/* ── تب حساب‌های بانکی ── */}
        <TabsContent value="bank">
          <Card>
            <CardContent className="p-0">
              <div className="flex items-center justify-between px-4 py-3 border-b">
                <h3 className="text-sm font-bold">حساب‌های بانکی {detail ? `«${detail.firstName} ${detail.lastName}»` : ""}</h3>
                {has("actManageBankingAccounts") && detail && (
                  <Button size="sm" className="h-8" onClick={openBank}><Plus className="w-4 h-4 me-1" />درج حساب</Button>
                )}
              </div>
              {!detail ? (
                <p className="text-sm text-muted-foreground text-center py-10">ابتدا کاربری را انتخاب کنید.</p>
              ) : (
                <table className="w-full text-xs">
                  <thead className="bg-muted/50 text-muted-foreground">
                    <tr>
                      <th className="px-3 py-2 text-start font-medium">نوع</th>
                      <th className="px-3 py-2 text-start font-medium">بانک / شعبه</th>
                      <th className="px-3 py-2 text-start font-medium">شماره حساب</th>
                      <th className="px-3 py-2 text-start font-medium">شبا</th>
                      <th className="px-3 py-2 text-start font-medium">صاحب حساب</th>
                    </tr>
                  </thead>
                  <tbody>
                    {bankAccs.length === 0 ? (
                      <tr><td colSpan={5} className="text-center py-6 text-muted-foreground">حسابی ثبت نشده است.</td></tr>
                    ) : (
                      bankAccs.map((b) => (
                        <tr key={b.id} className="border-t">
                          <td className="px-3 py-2">{b.accountTypeName}</td>
                          <td className="px-3 py-2 text-muted-foreground">{[b.bankName, b.branchName].filter(Boolean).join(" / ") || "—"}</td>
                          <td className="px-3 py-2" dir="ltr">{toPersianDigits(b.accountNumber)}</td>
                          <td className="px-3 py-2 text-muted-foreground" dir="ltr">{b.shabaNumber ?? "—"}</td>
                          <td className="px-3 py-2">{b.accountTitle}</td>
                        </tr>
                      ))
                    )}
                  </tbody>
                </table>
              )}
            </CardContent>
          </Card>
        </TabsContent>
      </Tabs>

      {/* ── دیالوگ درج/ویرایش کاربر — با بخش‌بندی box-header خود محصول ── */}
      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-3xl max-h-[85vh] overflow-y-auto">
          <DialogHeader><DialogTitle>{detail ? "ویرایش کاربر" : "درج کاربر"}</DialogTitle></DialogHeader>
          <div className="space-y-5">
            <Section title="مشخصات کاربر">
              <div className="grid grid-cols-2 sm:grid-cols-3 gap-3">
                <T label="نام *"><Input value={String(form.firstName)} onChange={(e) => setForm({ ...form, firstName: e.target.value })} /></T>
                <T label="نام خانوادگی *"><Input value={String(form.lastName)} onChange={(e) => setForm({ ...form, lastName: e.target.value })} /></T>
                <T label="نام مستعار"><Input value={String(form.nickName)} onChange={(e) => setForm({ ...form, nickName: e.target.value })} /></T>
                <T label="نام کاربری *"><Input dir="ltr" value={String(form.username)} disabled={!!detail} onChange={(e) => setForm({ ...form, username: e.target.value })} /></T>
                <T label={detail ? "رمز عبور جدید (اختیاری)" : "رمز عبور *"}><Input dir="ltr" type="password" value={String(form.password)} onChange={(e) => setForm({ ...form, password: e.target.value })} /></T>
                <T label="کد پرسنلی"><Input dir="ltr" value={String(form.persCode)} onChange={(e) => setForm({ ...form, persCode: e.target.value })} /></T>
                <T label="ایمیل"><Input dir="ltr" type="email" value={String(form.email)} onChange={(e) => setForm({ ...form, email: e.target.value })} /></T>
                <T label="موبایل"><Input dir="ltr" value={String(form.mobile)} onChange={(e) => setForm({ ...form, mobile: e.target.value })} /></T>
                <T label="موبایل دوم"><Input dir="ltr" value={String(form.mobileII)} onChange={(e) => setForm({ ...form, mobileII: e.target.value })} /></T>
              </div>
            </Section>

            <Section title="ساختار سازمانی">
              <div className="grid grid-cols-2 sm:grid-cols-3 gap-3">
                <T label="سمت سازمانی">
                  <Select value={String(form.positionId) || undefined} onValueChange={(v) => setForm({ ...form, positionId: v === "__E__" ? "" : v })}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      <SelectItem value="__E__">—</SelectItem>
                      {positions.map((p) => <SelectItem key={p.id} value={p.id}>{p.name}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </T>
                <T label="دپارتمان">
                  <Select value={String(form.departmentId) || undefined} onValueChange={(v) => setForm({ ...form, departmentId: v === "__E__" ? "" : v })}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      <SelectItem value="__E__">—</SelectItem>
                      {departments.map((d) => <SelectItem key={d.id} value={d.id}>{d.name}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </T>
                <T label="گروه کاربری">
                  <Select value={String(form.userGroupId) || undefined} onValueChange={(v) => setForm({ ...form, userGroupId: v === "__E__" ? "" : v })}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      <SelectItem value="__E__">—</SelectItem>
                      {userGroups.map((g) => <SelectItem key={g.id} value={g.id}>{g.name}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </T>
                <T label="مسئول مستقیم">
                  <Select value={String(form.responsibleUserId) || undefined} onValueChange={(v) => setForm({ ...form, responsibleUserId: v === "__E__" ? "" : v })}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      <SelectItem value="__E__">—</SelectItem>
                      {usersLight.map((u) => <SelectItem key={u.id} value={u.id}>{u.firstName} {u.lastName}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </T>
                <T label="تاریخ شروع"><JalaliDateInput value={String(form.startDate) || null} onChange={(v) => setForm({ ...form, startDate: v ?? "" })} /></T>
                <T label="تاریخ انقضای حساب"><JalaliDateInput value={String(form.expireDate) || null} onChange={(v) => setForm({ ...form, expireDate: v ?? "" })} /></T>
              </div>
            </Section>

            <Section title="اطلاعات تکمیلی (شناسنامه‌ای)">
              <div className="grid grid-cols-2 sm:grid-cols-3 gap-3">
                <T label="نام پدر"><Input value={String(form.fatherName)} onChange={(e) => setForm({ ...form, fatherName: e.target.value })} /></T>
                <T label="کد ملی"><Input dir="ltr" value={String(form.nationalCode)} onChange={(e) => setForm({ ...form, nationalCode: e.target.value })} /></T>
                <T label="شماره شناسنامه"><Input dir="ltr" value={String(form.identityNumber)} onChange={(e) => setForm({ ...form, identityNumber: e.target.value })} /></T>
                <T label="کد بیمه"><Input dir="ltr" value={String(form.insuranceCode)} onChange={(e) => setForm({ ...form, insuranceCode: e.target.value })} /></T>
                <T label="تلفن"><Input dir="ltr" value={String(form.tel)} onChange={(e) => setForm({ ...form, tel: e.target.value })} /></T>
                <T label="توضیح تلفن"><Input value={String(form.telDesc)} onChange={(e) => setForm({ ...form, telDesc: e.target.value })} /></T>
                <div className="col-span-2 sm:col-span-3">
                  <T label="نشانی"><Textarea rows={2} value={String(form.address)} onChange={(e) => setForm({ ...form, address: e.target.value })} /></T>
                </div>
              </div>
            </Section>

            <Section title="تنظیمات و دسترسی">
              <div className="grid grid-cols-2 sm:grid-cols-3 gap-3">
                <T label="نقش *">
                  <Select value={String(form.roleId) || undefined} onValueChange={(v) => setForm({ ...form, roleId: v })}>
                    <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                    <SelectContent>
                      {roles.map((r) => <SelectItem key={r.id} value={r.id}>{r.name}</SelectItem>)}
                    </SelectContent>
                  </Select>
                </T>
                <T label="عنوان پیش‌فرض پروژه"><Input value={String(form.defCmpPrjTitle)} onChange={(e) => setForm({ ...form, defCmpPrjTitle: e.target.value })} /></T>
                <T label="شماره‌های داخلی"><Input dir="ltr" value={String(form.extensions)} onChange={(e) => setForm({ ...form, extensions: e.target.value })} /></T>
                <T label="پیش‌شماره تماس"><Input dir="ltr" value={String(form.callPreNumber)} onChange={(e) => setForm({ ...form, callPreNumber: e.target.value })} /></T>
                <div className="col-span-2 sm:col-span-3 grid grid-cols-2 gap-2">
                  <Chk id="isActive" label="فعال" form={form} setForm={setForm} k="isActive" />
                  {me?.isAdmin && <Chk id="isAdmin" label="مدیر سیستم (دسترسی کامل)" form={form} setForm={setForm} k="isAdmin" />}
                  <Chk id="d1" label="قطع صدای آلارم پیام داخلی" form={form} setForm={setForm} k="disableInternalMessageAlarmVoice" />
                  <Chk id="d2" label="قطع آلارم گفتگوهای دیگران" form={form} setForm={setForm} k="disableReceiveCnvsInfoAllarm" />
                  <Chk id="d3" label="دسترسی به نمودار روزانه همه کاربران" form={form} setForm={setForm} k="accessDailyChartAllUsers" />
                  <Chk id="d4" label="دسترسی به نمودار فروش همه کاربران" form={form} setForm={setForm} k="accessSaleChartAllUsers" />
                </div>
                <div className="col-span-2 sm:col-span-3">
                  <T label="توضیحات"><Textarea rows={2} value={String(form.description)} onChange={(e) => setForm({ ...form, description: e.target.value })} /></T>
                </div>
              </div>
            </Section>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* ── دیالوگ امضای دیجیتال ── */}
      <Dialog open={sigOpen} onOpenChange={setSigOpen}>
        <DialogContent className="max-w-sm">
          <DialogHeader><DialogTitle>امضای دیجیتال — {detail ? nameOf(detail) : ""}</DialogTitle></DialogHeader>
          {detail?.hasSignature && (
            <div className="border rounded-lg p-3 bg-muted/30">
              <img src={`/api/users/${detail.id}/signature`} alt="امضا" className="max-h-32 mx-auto" />
            </div>
          )}
          <div className="space-y-2">
            <Input
              type="file"
              accept="image/png,image/jpeg,image/gif"
              onChange={(e) => { const f = e.target.files?.[0]; if (f) uploadSignature(f); }}
            />
            <p className="text-[11px] text-muted-foreground">فقط JPG/PNG/GIF، حداکثر ۳۰۰ کیلوبایت.</p>
          </div>
          <DialogFooter>
            {detail?.hasSignature && (
              <Button variant="outline" className="text-destructive hover:text-destructive" onClick={removeSignature}>حذف امضا</Button>
            )}
            <Button variant="outline" onClick={() => setSigOpen(false)}>بستن</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* ── دیالوگ تعیین ساعت ورود ── */}
      <Dialog open={timesOpen} onOpenChange={setTimesOpen}>
        <DialogContent className="max-w-xl">
          <DialogHeader><DialogTitle>تعیین ساعت ورود — {detail ? nameOf(detail) : ""}</DialogTitle></DialogHeader>
          <p className="text-[11px] text-muted-foreground">
            اگر هیچ قاعده‌ای ثبت نشود، ورود در همه ساعات مجاز است. با ثبت قواعد، ورود فقط در بازه‌های مجاز ممکن می‌شود.
          </p>
          <div className="border rounded-lg overflow-hidden">
            <table className="w-full text-xs">
              <thead className="bg-muted/60 text-muted-foreground">
                <tr>
                  <th className="px-2 py-2 text-start font-medium">روز هفته</th>
                  <th className="px-2 py-2 text-start font-medium">از ساعت</th>
                  <th className="px-2 py-2 text-start font-medium">تا ساعت</th>
                  <th className="px-2 py-2 text-start font-medium">بازه تاریخ</th>
                  <th className="px-2 py-2" />
                </tr>
              </thead>
              <tbody>
                {loginTimes.length === 0 ? (
                  <tr><td colSpan={5} className="text-center py-4 text-muted-foreground">بدون محدودیت (قاعده‌ای ثبت نشده)</td></tr>
                ) : (
                  loginTimes.map((t) => (
                    <tr key={t.id} className="border-t">
                      <td className="px-2 py-2">{t.dayOfWeek == null ? "هر روز" : WEEK_DAYS[t.dayOfWeek]}</td>
                      <td className="px-2 py-2" dir="ltr">{t.fromTime}</td>
                      <td className="px-2 py-2" dir="ltr">{t.toTime}</td>
                      <td className="px-2 py-2 text-muted-foreground">
                        {t.fromDate || t.toDate ? `${t.fromDate ? formatDate(t.fromDate) : ""} تا ${t.toDate ? formatDate(t.toDate) : ""}` : "—"}
                      </td>
                      <td className="px-2 py-2 text-end">
                        <Button variant="ghost" size="icon" className="h-7 w-7 text-destructive hover:text-destructive" onClick={() => removeTime(t.id)}>
                          <Trash2 className="w-3.5 h-3.5" />
                        </Button>
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
          <div className="grid grid-cols-2 sm:grid-cols-4 gap-2 items-end">
            <T label="روز هفته">
              <Select value={timeForm.dayOfWeek} onValueChange={(v) => setTimeForm({ ...timeForm, dayOfWeek: v })}>
                <SelectTrigger className="h-9 text-xs"><SelectValue /></SelectTrigger>
                <SelectContent>
                  <SelectItem value="__ALL__">هر روز</SelectItem>
                  {WEEK_DAYS.map((d, i) => <SelectItem key={d} value={String(i)}>{d}</SelectItem>)}
                </SelectContent>
              </Select>
            </T>
            <T label="از ساعت (HH:mm)"><Input dir="ltr" value={timeForm.fromTime} onChange={(e) => setTimeForm({ ...timeForm, fromTime: e.target.value })} /></T>
            <T label="تا ساعت (HH:mm)"><Input dir="ltr" value={timeForm.toTime} onChange={(e) => setTimeForm({ ...timeForm, toTime: e.target.value })} /></T>
            <Button size="sm" onClick={addTime}>افزودن قاعده</Button>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setTimesOpen(false)}>بستن</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* ── دیالوگ شمارش کاربران ── */}
      <Dialog open={countOpen} onOpenChange={setCountOpen}>
        <DialogContent className="max-w-sm">
          <DialogHeader><DialogTitle>جزئیات تعداد کاربران</DialogTitle></DialogHeader>
          {count && (
            <div className="space-y-2 text-xs">
              <div className="grid grid-cols-3 gap-2">
                <Stat label="کل" value={count.total} />
                <Stat label="فعال" value={count.active} />
                <Stat label="غیرفعال" value={count.inactive} />
              </div>
              <div className="border rounded-lg overflow-hidden">
                <table className="w-full text-xs">
                  <thead className="bg-muted/60"><tr><th className="px-2 py-2 text-start font-medium">نقش</th><th className="px-2 py-2 text-start font-medium">تعداد</th></tr></thead>
                  <tbody>
                    {count.byRole.map((r) => (
                      <tr key={r.name} className="border-t">
                        <td className="px-2 py-1.5">{r.name}</td>
                        <td className="px-2 py-1.5 font-bold">{toPersianDigits(r.count)}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
              <p className="text-[11px] text-muted-foreground">
                سقف لایسنس کاربران در رستا فعال نیست (فعال‌سازی لایسنس به تصمیم مالک موکول شده).
              </p>
            </div>
          )}
          <DialogFooter><Button variant="outline" onClick={() => setCountOpen(false)}>بستن</Button></DialogFooter>
        </DialogContent>
      </Dialog>

      {/* ── دیالوگ درج حساب بانکی ── */}
      <Dialog open={bankOpen} onOpenChange={setBankOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle>درج حساب بانکی برای {detail ? nameOf(detail) : ""}</DialogTitle></DialogHeader>
          <div className="grid grid-cols-2 gap-3">
            <T label="شعبه">
              <Select value={bankForm.branchId || undefined} onValueChange={(v) => setBankForm({ ...bankForm, branchId: v })}>
                <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                <SelectContent>
                  {branches.map((b) => <SelectItem key={b.id} value={b.id}>{`${b.bank?.name ?? ""} — ${b.name}`}</SelectItem>)}
                </SelectContent>
              </Select>
            </T>
            <T label="نوع حساب">
              <Select value={bankForm.accountTypeId || undefined} onValueChange={(v) => setBankForm({ ...bankForm, accountTypeId: v })}>
                <SelectTrigger><SelectValue placeholder="—" /></SelectTrigger>
                <SelectContent>
                  {accTypes.map((t) => <SelectItem key={t.id} value={t.id}>{t.name}</SelectItem>)}
                </SelectContent>
              </Select>
            </T>
            <T label="شماره حساب *"><Input dir="ltr" value={bankForm.accountNumber} onChange={(e) => setBankForm({ ...bankForm, accountNumber: e.target.value })} /></T>
            <T label="شماره کارت"><Input dir="ltr" value={bankForm.cardNumber} onChange={(e) => setBankForm({ ...bankForm, cardNumber: e.target.value })} /></T>
            <T label="شماره شبا"><Input dir="ltr" value={bankForm.shabaNumber} onChange={(e) => setBankForm({ ...bankForm, shabaNumber: e.target.value })} /></T>
            <T label="توضیح"><Input value={bankForm.desc} onChange={(e) => setBankForm({ ...bankForm, desc: e.target.value })} /></T>
          </div>
          <DialogFooter>
            <Button
              onClick={async () => {
                if (!detail) return;
                try {
                  await api(`/api/users/${detail.id}/bank-accounts`, { method: "POST", body: { ...bankForm, accountOwner: `${detail.firstName} ${detail.lastName}` } });
                  toast({ title: "حساب ثبت شد." });
                  setBankOpen(false);
                  setBankForm({ branchId: "", accountTypeId: "", accountNumber: "", cardNumber: "", shabaNumber: "", desc: "" });
                  const accs = await api<{ rows: BankAcc[] }>(`/api/users/${detail.id}/bank-accounts`);
                  setBankAccs(accs.rows);
                } catch (e) {
                  toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
                }
              }}
            >
              ثبت
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}

function T({ label, children }: { label: string; children: React.ReactNode }) {
  return (
    <div className="space-y-1.5">
      <Label className="text-xs">{label}</Label>
      {children}
    </div>
  );
}

function Section({ title, children }: { title: string; children: React.ReactNode }) {
  return (
    <div className="rounded-xl border">
      <div className="px-4 py-2 border-b bg-muted/40 text-xs font-bold">{title}</div>
      <div className="p-4">{children}</div>
    </div>
  );
}

function Chk({ id, label, form, setForm, k }: { id: string; label: string; form: emptyUser; setForm: (f: emptyUser) => void; k: keyof emptyUser }) {
  return (
    <span className="flex items-center gap-2">
      <Checkbox id={id} checked={Boolean(form[k])} onCheckedChange={(v) => setForm({ ...form, [k]: Boolean(v) })} />
      <Label htmlFor={id} className="cursor-pointer text-xs">{label}</Label>
    </span>
  );
}

function Stat({ label, value }: { label: string; value: number }) {
  return (
    <div className="rounded-lg bg-muted/50 px-3 py-2 text-center">
      <p className="text-[10px] text-muted-foreground">{label}</p>
      <p className="font-extrabold">{toPersianDigits(value)}</p>
    </div>
  );
}
