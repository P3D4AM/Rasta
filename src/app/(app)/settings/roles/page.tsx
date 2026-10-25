"use client";

/**
 * تعریف نقش‌ها + ماتریس مجوز — بازسازی RollsDefine + RollPermissionDefine خود CRMIdeal:
 *  - گرید نقش‌ها (نام/توضیح/سقف تخفیف پیش‌فاکتور/فاکتور/تعداد کاربر/تعداد مجوز)
 *  - فرم درج/ویرایش با سقف درصد تخفیف (LimitPreOrderDiscount و LimitOrderDiscount)
 *  - دیالوگ ماتریس: درخت فرم‌ها (گروه‌بندی‌شده با شمارنده) + اکشن‌های تخصیص‌یافته/نشده
 *    + تخصیص/حذف تکی + تخصیص همه/حذف همه + کپی/انتقال از نقش دیگر (actPasteAllRoll)
 */

import { useCallback, useEffect, useMemo, useState } from "react";
import { Plus, Pencil, Trash2, ShieldCheck, Copy, Search } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Checkbox } from "@/components/ui/checkbox";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from "@/components/ui/dialog";
import { PageHeader } from "@/components/rasta/page-header";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";
import { fetchMe } from "@/lib/client-me";
import { toPersianDigits } from "@/lib/jalali";

type Role = {
  id: string; name: string; description: string | null;
  limitPreOrderDiscountActive: boolean; limitPreOrderDiscountPercent: number;
  limitOrderDiscountActive: boolean; limitOrderDiscountPercent: number;
  usersCount: number; permsCount: number;
};

type FormMeta = { id: string; label: string; section: string; actions: string[] };

export default function RolesPage() {
  const { toast } = useToast();
  const [rows, setRows] = useState<Role[]>([]);
  const [loading, setLoading] = useState(true);
  const [me, setMe] = useState<{ isAdmin: boolean; permissions: Record<string, string[]> } | null>(null);

  const [dialogOpen, setDialogOpen] = useState(false);
  const [form, setForm] = useState({ id: "", name: "", description: "", limitPreOrderDiscountActive: false, limitPreOrderDiscountPercent: "0", limitOrderDiscountActive: false, limitOrderDiscountPercent: "0" });
  const [saving, setSaving] = useState(false);

  const [permOpen, setPermOpen] = useState(false);
  const [permRole, setPermRole] = useState<Role | null>(null);
  const [forms, setForms] = useState<FormMeta[]>([]);
  const [assigned, setAssigned] = useState<Set<string>>(new Set());
  const [selectedForm, setSelectedForm] = useState<string>("");
  const [formSearch, setFormSearch] = useState("");
  const [allRoles, setAllRoles] = useState<{ id: string; name: string }[]>([]);
  const [copySource, setCopySource] = useState("");

  const has = useCallback((act: string) => !!me && (me.isAdmin || (me.permissions["frmUserRoll"] ?? []).includes(act)), [me]);
  const canMatrix = useCallback(() => !!me && (me.isAdmin || (me.permissions["frmRollPermission"] ?? []).includes("actView")), [me]);

  const load = useCallback(async () => {
    setLoading(true);
    try {
      const data = await api<{ rows: Role[] }>("/api/roles");
      setRows(data.rows);
      setAllRoles(data.rows.map((r) => ({ id: r.id, name: r.name })));
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setLoading(false);
    }
  }, [toast]);

  useEffect(() => {
    load();
    fetchMe().then((m) => { if (m) setMe(m); });
  }, [load]);

  function openDialog(role: Role | null) {
    setForm({
      id: role?.id ?? "",
      name: role?.name ?? "",
      description: role?.description ?? "",
      limitPreOrderDiscountActive: role?.limitPreOrderDiscountActive ?? false,
      limitPreOrderDiscountPercent: String(role?.limitPreOrderDiscountPercent ?? 0),
      limitOrderDiscountActive: role?.limitOrderDiscountActive ?? false,
      limitOrderDiscountPercent: String(role?.limitOrderDiscountPercent ?? 0),
    });
    setDialogOpen(true);
  }

  async function save() {
    if (!form.name.trim()) return toast({ title: "نام نقش الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      const body = {
        name: form.name,
        description: form.description || null,
        limitPreOrderDiscountActive: form.limitPreOrderDiscountActive,
        limitPreOrderDiscountPercent: Number(form.limitPreOrderDiscountPercent) || 0,
        limitOrderDiscountActive: form.limitOrderDiscountActive,
        limitOrderDiscountPercent: Number(form.limitOrderDiscountPercent) || 0,
      };
      if (form.id) await api(`/api/roles/${form.id}`, { method: "PUT", body });
      else await api("/api/roles", { method: "POST", body });
      toast({ title: form.id ? "نقش ویرایش شد." : "نقش ایجاد شد." });
      setDialogOpen(false);
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function remove(role: Role) {
    if (!confirm(`حذف نقش «${role.name}»؟`)) return;
    try {
      await api(`/api/roles/${role.id}`, { method: "DELETE" });
      toast({ title: "نقش حذف شد." });
      load();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function openMatrix(role: Role) {
    setPermRole(role);
    setCopySource("");
    setSelectedForm("");
    setFormSearch("");
    try {
      const data = await api<{ forms: FormMeta[]; assigned: string[] }>(`/api/roles/${role.id}/permissions`);
      setForms(data.forms);
      setAssigned(new Set(data.assigned));
      setPermOpen(true);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function togglePerm(formId: string, actionId: string, granted: boolean) {
    if (!permRole) return;
    try {
      await api(`/api/roles/${permRole.id}/permissions`, { method: "PUT", body: { formId, actionId, granted } });
      setAssigned((prev) => {
        const next = new Set(prev);
        if (granted) next.add(`${formId}:${actionId}`);
        else next.delete(`${formId}:${actionId}`);
        return next;
      });
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function assignAll(formId: string) {
    if (!permRole) return;
    try {
      await api(`/api/roles/${permRole.id}/permissions`, { method: "POST", body: { formId } });
      const form = forms.find((f) => f.id === formId);
      setAssigned((prev) => {
        const next = new Set(prev);
        form?.actions.forEach((a) => next.add(`${formId}:${a}`));
        return next;
      });
      toast({ title: "همه اکشن‌های فرم تخصیص یافت." });
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function removeAll(formId: string) {
    if (!permRole) return;
    try {
      await api(`/api/roles/${permRole.id}/permissions?formId=${formId}`, { method: "DELETE" });
      setAssigned((prev) => {
        const next = new Set(prev);
        [...next].filter((k) => k.startsWith(`${formId}:`)).forEach((k) => next.delete(k));
        return next;
      });
      toast({ title: "همه اکشن‌های فرم حذف شد." });
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function copyFrom(source: string) {
    if (!permRole || !source) return;
    if (!confirm(`همه مجوزهای نقش جاری با مجوزهای نقش مبدأ جایگزین شود؟`)) return;
    try {
      const res = await api<{ copied: number }>(`/api/roles/${permRole.id}/permissions`, { method: "PATCH", body: { sourceRoleId: source } });
      toast({ title: `${toPersianDigits(res.copied)} مجوز کپی شد.` });
      await openMatrix(permRole);
      setPermOpen(true);
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const sections = useMemo(() => {
    const filtered = forms.filter(
      (f) => !formSearch || f.label.includes(formSearch) || f.id.includes(formSearch)
    );
    const map = new Map<string, FormMeta[]>();
    for (const f of filtered) {
      map.set(f.section, [...(map.get(f.section) ?? []), f]);
    }
    return [...map.entries()];
  }, [forms, formSearch]);

  const currentForm = forms.find((f) => f.id === selectedForm) ?? null;

  return (
    <div>
      <PageHeader
        title="تعریف نقش‌های کاربری"
        subtitle="نقش‌ها، سقف تخفیف و ماتریس مجوز فرم×اکشن — مطابق CrmsysRolls/CrmsysRollPermission"
        actions={has("actInsert") && (
          <Button size="sm" onClick={() => openDialog(null)}><Plus className="w-4 h-4 me-1" />نقش جدید</Button>
        )}
      />

      <div className="border rounded-xl overflow-x-auto bg-card">
        <table className="w-full text-xs min-w-[760px]">
          <thead className="bg-muted/60 text-muted-foreground">
            <tr>
              <th className="px-3 py-2.5 text-start font-medium">نقش</th>
              <th className="px-3 py-2.5 text-start font-medium">توضیح</th>
              <th className="px-3 py-2.5 text-start font-medium">سقف تخفیف پیش‌فاکتور</th>
              <th className="px-3 py-2.5 text-start font-medium">سقف تخفیف فاکتور فروش</th>
              <th className="px-3 py-2.5 text-start font-medium">کاربران</th>
              <th className="px-3 py-2.5 text-start font-medium">مجوزها</th>
              <th className="px-3 py-2.5" />
            </tr>
          </thead>
          <tbody>
            {loading ? (
              <tr><td colSpan={7} className="text-center py-8 text-muted-foreground">در حال بارگذاری…</td></tr>
            ) : rows.length === 0 ? (
              <tr><td colSpan={7} className="text-center py-8 text-muted-foreground">نقشی ثبت نشده است.</td></tr>
            ) : (
              rows.map((r) => (
                <tr key={r.id} className="border-t hover:bg-muted/30">
                  <td className="px-3 py-2.5 font-medium">{r.name}</td>
                  <td className="px-3 py-2.5 text-muted-foreground">{r.description ?? "—"}</td>
                  <td className="px-3 py-2.5">{r.limitPreOrderDiscountActive ? `${toPersianDigits(r.limitPreOrderDiscountPercent)}٪` : "—"}</td>
                  <td className="px-3 py-2.5">{r.limitOrderDiscountActive ? `${toPersianDigits(r.limitOrderDiscountPercent)}٪` : "—"}</td>
                  <td className="px-3 py-2.5 font-bold">{toPersianDigits(r.usersCount)}</td>
                  <td className="px-3 py-2.5">
                    {canMatrix() ? (
                      <button className="text-primary hover:underline font-bold" onClick={() => openMatrix(r)}>
                        {toPersianDigits(r.permsCount)}
                      </button>
                    ) : toPersianDigits(r.permsCount)}
                  </td>
                  <td className="px-3 py-2.5 text-end">
                    <div className="flex justify-end gap-1">
                      {canMatrix() && (
                        <Button variant="ghost" size="icon" className="h-7 w-7" title="ماتریس مجوز" onClick={() => openMatrix(r)}>
                          <ShieldCheck className="w-4 h-4" />
                        </Button>
                      )}
                      {has("actEdit") && (
                        <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => openDialog(r)} title="ویرایش">
                          <Pencil className="w-3.5 h-3.5" />
                        </Button>
                      )}
                      {has("actDelete") && (
                        <Button variant="ghost" size="icon" className="h-7 w-7 text-destructive hover:text-destructive" onClick={() => remove(r)} title="حذف">
                          <Trash2 className="w-3.5 h-3.5" />
                        </Button>
                      )}
                    </div>
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      </div>

      {/* ── دیالوگ درج/ویرایش نقش ── */}
      <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle>{form.id ? "ویرایش نقش" : "نقش جدید"}</DialogTitle></DialogHeader>
          <div className="space-y-3">
            <div className="space-y-1.5">
              <Label>نام نقش *</Label>
              <Input value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
            </div>
            <div className="space-y-1.5">
              <Label>توضیح</Label>
              <Input value={form.description} onChange={(e) => setForm({ ...form, description: e.target.value })} />
            </div>
            <div className="rounded-xl border p-3 space-y-3">
              <p className="text-xs font-bold">سقف درصد تخفیف به تفکیک نقش (مثل CrmsysRolls)</p>
              <span className="flex items-center gap-2 text-xs">
                <Checkbox id="p1" checked={form.limitPreOrderDiscountActive} onCheckedChange={(v) => setForm({ ...form, limitPreOrderDiscountActive: Boolean(v) })} />
                <Label htmlFor="p1" className="cursor-pointer">سقف تخفیف پیش‌فاکتور</Label>
                {form.limitPreOrderDiscountActive && (
                  <Input dir="ltr" className="w-20 h-8" value={form.limitPreOrderDiscountPercent} onChange={(e) => setForm({ ...form, limitPreOrderDiscountPercent: e.target.value })} />
                )}
              </span>
              <span className="flex items-center gap-2 text-xs">
                <Checkbox id="p2" checked={form.limitOrderDiscountActive} onCheckedChange={(v) => setForm({ ...form, limitOrderDiscountActive: Boolean(v) })} />
                <Label htmlFor="p2" className="cursor-pointer">سقف تخفیف فاکتور فروش</Label>
                {form.limitOrderDiscountActive && (
                  <Input dir="ltr" className="w-20 h-8" value={form.limitOrderDiscountPercent} onChange={(e) => setForm({ ...form, limitOrderDiscountPercent: e.target.value })} />
                )}
              </span>
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setDialogOpen(false)}>انصراف</Button>
            <Button onClick={save} disabled={saving}>{saving ? "در حال ذخیره…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* ── دیالوگ ماتریس مجوز — RollPermissionDefine خود محصول ── */}
      <Dialog open={permOpen} onOpenChange={setPermOpen}>
        <DialogContent className="max-w-4xl h-[80vh] overflow-hidden flex flex-col">
          <DialogHeader>
            <DialogTitle>ماتریس مجوز — نقش «{permRole?.name}»</DialogTitle>
          </DialogHeader>
          <div className="flex items-center gap-2 pb-2 border-b">
            <div className="relative flex-1">
              <Search className="w-4 h-4 absolute right-2.5 top-2.5 text-muted-foreground" />
              <Input className="h-9 ps-8" placeholder="جستجوی فرم…" value={formSearch} onChange={(e) => setFormSearch(e.target.value)} />
            </div>
            <Select value={copySource || undefined} onValueChange={(v) => { setCopySource(v); copyFrom(v); }}>
              <SelectTrigger className="w-56 h-9"><SelectValue placeholder="کپی/انتقال از نقش دیگر…" /></SelectTrigger>
              <SelectContent>
                {allRoles.filter((r) => r.id !== permRole?.id).map((r) => (
                  <SelectItem key={r.id} value={r.id}>{r.name}</SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
          <div className="grid grid-cols-1 lg:grid-cols-[280px_1fr] gap-3 flex-1 overflow-hidden">
            {/* درخت فرم‌ها — مثل درخت فرم‌های RollPermissionDefine با شمارنده */}
            <div className="overflow-y-auto border rounded-xl bg-card">
              {sections.map(([section, list]) => (
                <div key={section}>
                  <div className="px-3 py-1.5 bg-muted/50 text-[11px] font-bold text-muted-foreground sticky top-0">{section}</div>
                  {list.map((f) => {
                    const cnt = f.actions.filter((a) => assigned.has(`${f.id}:${a}`)).length;
                    return (
                      <button
                        key={f.id}
                        type="button"
                        onClick={() => setSelectedForm(f.id)}
                        className={`w-full flex items-center justify-between px-3 py-2 text-xs text-start hover:bg-muted/40 ${selectedForm === f.id ? "bg-primary/10 text-primary font-bold" : ""}`}
                      >
                        <span className="truncate">{f.label}</span>
                        <span className={`shrink-0 text-[10px] ${cnt ? "text-primary font-bold" : "text-muted-foreground"}`}>
                          {toPersianDigits(cnt)}/{toPersianDigits(f.actions.length)}
                        </span>
                      </button>
                    );
                  })}
                </div>
              ))}
            </div>
            {/* اکشن‌های فرم انتخاب‌شده — دو ستون تخصیص‌یافته/نشده */}
            <div className="overflow-y-auto">
              {!currentForm ? (
                <p className="text-xs text-muted-foreground text-center py-10">فرمی را از فهرست انتخاب کنید.</p>
              ) : (
                <Card>
                  <CardContent className="p-4 space-y-3">
                    <div className="flex items-center justify-between">
                      <p className="text-xs font-bold">{currentForm.label}</p>
                      <div className="flex gap-1.5">
                        <Button size="sm" variant="outline" className="h-7 text-xs" onClick={() => assignAll(currentForm.id)}>تخصیص همه</Button>
                        <Button size="sm" variant="outline" className="h-7 text-xs text-destructive hover:text-destructive" onClick={() => removeAll(currentForm.id)}>حذف همه</Button>
                      </div>
                    </div>
                    <div className="grid grid-cols-1 sm:grid-cols-2 gap-2">
                      {currentForm.actions.map((a) => {
                        const on = assigned.has(`${currentForm.id}:${a}`);
                        return (
                          <button
                            key={a}
                            type="button"
                            onClick={() => togglePerm(currentForm.id, a, !on)}
                            className={`flex items-center gap-2 rounded-lg border px-3 py-2 text-xs transition-colors text-start ${
                              on ? "border-primary/40 bg-primary/5 text-primary" : "border-border text-muted-foreground hover:bg-muted/40"
                            }`}
                          >
                            <Checkbox checked={on} />
                            <span className="flex-1">{ACT_LABELS_LOCAL[a] ?? a}</span>
                            <code className="text-[9px] opacity-60" dir="ltr">{a}</code>
                          </button>
                        );
                      })}
                    </div>
                    <p className="text-[10px] text-muted-foreground">
                      هر دکمه در برنامه با همین جفت (فرم، اکشن) کنترل می‌شود — معادل UserLogin.IsUserAccess خود CRMIdeal.
                    </p>
                  </CardContent>
                </Card>
              )}
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setPermOpen(false)}>بستن</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}

const ACT_LABELS_LOCAL: Record<string, string> = {
  actView: "مشاهده", actInsert: "درج", actEdit: "ویرایش", actDelete: "حذف", actPost: "ثبت",
  actprjInsert: "درج پروژه", actCanSetArchive: "اجازه آرشیو پروژه", actCanSetPrjIsTicket: "تعیین نوع تیکت",
  actCanChangePrjToDoTime: "تعیین زمان انجام", actDeleteCmpProjectWithDep: "حذف پروژه با وابستگی‌ها",
  actDeleteAllCmpProjectsWithDep: "حذف همه پروژه‌ها با وابستگی‌ها", actVerify: "تایید / لغو تایید",
  actEditMoreInfo: "ویرایش اطلاعات تکمیلی", actAssignRoll: "تخصیص نقش", actUploadSignature: "بارگذاری امضا",
  actManageBankingAccounts: "مدیریت حساب‌های بانکی", actLoginAllowedTimes: "تعیین ساعت ورود",
  actShowDetailsUserCount: "نمایش جزئیات تعداد کاربران", actDefineProjectTitle: "تعریف عنوان‌های پیش‌فرض پروژه",
  actDefineProjectTitleGroup: "تعریف سرفصل‌های پروژه", actDefinePrjGroup: "تعریف گروه پروژه",
  actDefinePrjGrade: "تعریف مقطع پروژه", actDefinePrjPriority: "تعریف اولویت پروژه",
  actDefinePrjCategory: "تعریف دسته‌بندی پروژه", actDefinecnvsStatusGroups: "تعریف مدل‌های پیشرفت",
  actDefinecnvsStatus: "تعریف وضعیت‌های مذاکره", actDefineUserPositions: "تعریف سمت‌های سازمانی",
  actDefineUserGroups: "تعریف گروه‌های کاربری", actDefineDepartments: "تعریف دپارتمان‌ها",
};
