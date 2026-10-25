"use client";

/**
 * صفحه بانک‌داری — بازسازی Areas/Banking محصول CRMIdeal
 * تب ۱: بانک‌ها و شعب (Index.cshtml + Branch.cshtml)
 * تب ۲: حساب‌های بانکی (Accounts.cshtml: شماره حساب/کارت/شبا/صاحب حساب/پیش‌فرض)
 */

import { useCallback, useEffect, useState } from "react";
import { Landmark, Plus, Pencil, Trash2, Building, MapPin, CreditCard, Star } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle,
} from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";
import { PageHeader } from "@/components/rasta/page-header";
import { DataTable, type Column } from "@/components/rasta/data-table";
import { api } from "@/hooks/use-list";
import { toPersianDigits } from "@/lib/jalali";
import { cn } from "@/lib/utils";

type Bank = { id: string; code: string | null; name: string; desc: string | null; branches: Branch[] };
type Branch = { id: string; bankId: string; name: string; tel: string | null };
type AccType = { id: string; name: string };
type BranchOption = { id: string; name: string; bank: { id: string; name: string } };
type Account = {
  id: string; accountNumber: string; cardNumber: string | null; shabaNumber: string | null;
  accountOwner: string; isDefault: boolean; desc: string | null;
  branch: { id: string; name: string; bank: { id: string; name: string } };
  accountType: { id: string; name: string };
};

const emptyBank = { id: "", name: "", code: "", desc: "" };
const emptyBranch = { id: "", bankId: "", name: "", tel: "" };
const emptyAccount = {
  id: "", branchId: "", accountTypeId: "", accountNumber: "",
  cardNumber: "", shabaNumber: "", accountOwner: "", isDefault: false, desc: "",
};

export default function BankingPage() {
  const { toast } = useToast();
  const [tab, setTab] = useState<"banks" | "accounts">("banks");

  const [banks, setBanks] = useState<Bank[]>([]);
  const [accounts, setAccounts] = useState<Account[]>([]);
  const [types, setTypes] = useState<AccType[]>([]);
  const [branchOptions, setBranchOptions] = useState<BranchOption[]>([]);

  const [bankDlg, setBankDlg] = useState(false);
  const [branchDlg, setBranchDlg] = useState(false);
  const [accDlg, setAccDlg] = useState(false);
  const [bankForm, setBankForm] = useState(emptyBank);
  const [branchForm, setBranchForm] = useState(emptyBranch);
  const [accForm, setAccForm] = useState(emptyAccount);
  const [saving, setSaving] = useState(false);

  const loadAll = useCallback(() => {
    api<{ rows: Bank[] }>("/api/banking/banks").then((r) => setBanks(r.rows)).catch(() => {});
    api<{ rows: Account[]; types: AccType[]; branches: BranchOption[] }>("/api/banking/accounts")
      .then((r) => {
        setAccounts(r.rows);
        setTypes(r.types);
        setBranchOptions(r.branches);
      })
      .catch(() => {});
  }, []);

  useEffect(loadAll, [loadAll]);

  async function saveBank() {
    if (!bankForm.name.trim()) return toast({ title: "نام بانک الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/banking/banks", {
        method: bankForm.id ? "PATCH" : "POST",
        body: bankForm,
      });
      toast({ title: bankForm.id ? "بانک ویرایش شد." : "بانک ثبت شد." });
      setBankDlg(false);
      loadAll();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function saveBranch() {
    if (!branchForm.bankId) return toast({ title: "بانک را انتخاب کنید.", variant: "destructive" });
    if (!branchForm.name.trim()) return toast({ title: "نام شعبه الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/banking/banks", {
        method: branchForm.id ? "PATCH" : "POST",
        body: { ...branchForm, type: "branch" },
      });
      toast({ title: branchForm.id ? "شعبه ویرایش شد." : "شعبه ثبت شد." });
      setBranchDlg(false);
      loadAll();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function saveAccount() {
    if (!accForm.branchId) return toast({ title: "شعبه بانک را انتخاب کنید.", variant: "destructive" });
    if (!accForm.accountTypeId) return toast({ title: "نوع حساب را انتخاب کنید.", variant: "destructive" });
    if (!accForm.accountNumber.trim()) return toast({ title: "شماره حساب الزامی است.", variant: "destructive" });
    if (!accForm.accountOwner.trim()) return toast({ title: "صاحب حساب الزامی است.", variant: "destructive" });
    setSaving(true);
    try {
      await api("/api/banking/accounts", {
        method: accForm.id ? "PATCH" : "POST",
        body: accForm,
      });
      toast({ title: accForm.id ? "حساب ویرایش شد." : "حساب بانکی ثبت شد." });
      setAccDlg(false);
      loadAll();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  async function removeBank(b: Bank) {
    if (!confirm(`حذف «${b.name}» همراه با همه شعب و حساب‌هایش؟`)) return;
    try {
      await api(`/api/banking/banks?id=${b.id}`, { method: "DELETE" });
      toast({ title: "بانک حذف شد." });
      loadAll();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function removeBranch(br: Branch) {
    if (!confirm(`حذف شعبه «${br.name}»؟`)) return;
    try {
      await api(`/api/banking/banks?type=branch&id=${br.id}`, { method: "DELETE" });
      toast({ title: "شعبه حذف شد." });
      loadAll();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  async function removeAccount(a: Account) {
    if (!confirm(`حذف حساب «${toPersianDigits(a.accountNumber)}»؟`)) return;
    try {
      await api(`/api/banking/accounts?id=${a.id}`, { method: "DELETE" });
      toast({ title: "حساب حذف شد." });
      loadAll();
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    }
  }

  const bankColumns: Column<Bank>[] = [
    {
      key: "name",
      header: "بانک",
      render: (b) => (
        <div className="flex items-center gap-2.5">
          <div className="w-9 h-9 rounded-lg bg-[#e7effc] flex items-center justify-center shrink-0">
            <Building className="w-4 h-4 text-[#012875]" />
          </div>
          <div>
            <p className="font-bold">{b.name}</p>
            {b.code && <p className="text-xs text-muted-foreground" dir="ltr">کد: {b.code}</p>}
          </div>
        </div>
      ),
    },
    { key: "desc", header: "توضیحات", render: (b) => <span className="text-muted-foreground text-[13px]">{b.desc ?? "—"}</span> },
    {
      key: "branches",
      header: "شعب",
      render: (b) => (
        <div className="flex flex-col gap-1">
          {b.branches.map((br) => (
            <span key={br.id} className="text-[12.5px] flex items-center gap-1">
              <MapPin className="w-3 h-3 text-[#528fcc]" />
              {br.name}
              {br.tel ? <span className="text-muted-foreground" dir="ltr">— {br.tel}</span> : null}
              <button
                className="text-[#528fcc] hover:text-[#012875] mr-1"
                onClick={() => { setBranchForm({ id: br.id, bankId: b.id, name: br.name, tel: br.tel ?? "" }); setBranchDlg(true); }}
              >
                <Pencil className="w-3 h-3" />
              </button>
              <button className="text-destructive hover:opacity-75" onClick={() => removeBranch(br)}>
                <Trash2 className="w-3 h-3" />
              </button>
            </span>
          ))}
          <button
            className="text-[12px] text-[#528fcc] hover:text-[#012875] flex items-center gap-1 w-fit"
            onClick={() => { setBranchForm({ ...emptyBranch, bankId: b.id }); setBranchDlg(true); }}
          >
            <Plus className="w-3 h-3" />
            افزودن شعبه
          </button>
        </div>
      ),
    },
    {
      key: "actions",
      header: "عملیات",
      render: (b) => (
        <div className="flex items-center gap-1">
          <Button variant="ghost" size="icon" className="w-7 h-7" onClick={() => { setBankForm({ id: b.id, name: b.name, code: b.code ?? "", desc: b.desc ?? "" }); setBankDlg(true); }}>
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          <Button variant="ghost" size="icon" className="w-7 h-7 text-destructive" onClick={() => removeBank(b)}>
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  const accountColumns: Column<Account>[] = [
    {
      key: "accountNumber",
      header: "شماره حساب",
      render: (a) => (
        <div className="flex items-center gap-2">
          <div className="w-9 h-9 rounded-lg bg-[#e7effc] flex items-center justify-center shrink-0">
            <CreditCard className="w-4 h-4 text-[#012875]" />
          </div>
          <div>
            <p className="font-bold" dir="ltr">{toPersianDigits(a.accountNumber)}</p>
            {a.isDefault ? (
              <span className="text-[11px] text-[#b8860b] flex items-center gap-0.5">
                <Star className="w-3 h-3" />
                حساب پیش‌فرض
              </span>
            ) : null}
          </div>
        </div>
      ),
    },
    { key: "bank", header: "بانک / شعبه", render: (a) => <span>{a.branch.bank.name} — {a.branch.name}</span> },
    { key: "type", header: "نوع حساب", render: (a) => a.accountType.name },
    { key: "cardNumber", header: "شماره کارت", render: (a) => <span dir="ltr" className="text-muted-foreground text-[12.5px]">{a.cardNumber ? toPersianDigits(a.cardNumber) : "—"}</span> },
    { key: "shaba", header: "شماره شبا", render: (a) => <span dir="ltr" className="text-muted-foreground text-[12px]">{a.shabaNumber ?? "—"}</span> },
    { key: "owner", header: "صاحب حساب", render: (a) => a.accountOwner },
    {
      key: "actions",
      header: "عملیات",
      render: (a) => (
        <div className="flex items-center gap-1">
          <Button
            variant="ghost" size="icon" className="w-7 h-7"
            onClick={() => {
              setAccForm({
                id: a.id, branchId: a.branch.id, accountTypeId: a.accountType.id,
                accountNumber: a.accountNumber, cardNumber: a.cardNumber ?? "",
                shabaNumber: a.shabaNumber ?? "", accountOwner: a.accountOwner,
                isDefault: a.isDefault, desc: a.desc ?? "",
              });
              setAccDlg(true);
            }}
          >
            <Pencil className="w-3.5 h-3.5" />
          </Button>
          <Button variant="ghost" size="icon" className="w-7 h-7 text-destructive" onClick={() => removeAccount(a)}>
            <Trash2 className="w-3.5 h-3.5" />
          </Button>
        </div>
      ),
    },
  ];

  return (
    <div>
      <PageHeader
        title="بانک‌ها و حساب‌های بانکی"
        subtitle="مدیریت بانک‌ها، شعب و حساب‌ها"
        icon={<Landmark className="w-4 h-4" />}
        actions={
          tab === "banks" ? (
            <Button onClick={() => { setBankForm(emptyBank); setBankDlg(true); }} className="bg-white text-[#528fcc] hover:bg-[#eef4fb] rounded-full text-[13px] gap-1.5">
              <Plus className="w-4 h-4" />
              درج بانک
            </Button>
          ) : (
            <Button onClick={() => { setAccForm(emptyAccount); setAccDlg(true); }} className="bg-white text-[#528fcc] hover:bg-[#eef4fb] rounded-full text-[13px] gap-1.5">
              <Plus className="w-4 h-4" />
              درج حساب بانکی
            </Button>
          )
        }
      />

      <div className="crm-section">
        {/* تب‌ها */}
        <div className="flex border-b border-[#eef1f7]">
          {([
            { key: "banks", label: "بانک‌ها و شعب" },
            { key: "accounts", label: "حساب‌های بانکی" },
          ] as const).map((t) => (
            <button
              key={t.key}
              type="button"
              onClick={() => setTab(t.key)}
              className={cn(
                "px-5 py-2.5 text-[13.5px] transition-colors relative",
                tab === t.key ? "text-[#012875] font-semibold" : "text-muted-foreground hover:text-[#012875]"
              )}
            >
              {t.label}
              {tab === t.key ? <span className="absolute bottom-0 right-3 left-3 h-0.5 bg-[#012875] rounded-full" /> : null}
            </button>
          ))}
        </div>

        {tab === "banks" ? (
          <DataTable columns={bankColumns} rows={banks} loading={false} page={1} pageSize={100} total={banks.length} onPageChange={() => {}} emptyText="بانکی ثبت نشده است." />
        ) : (
          <DataTable columns={accountColumns} rows={accounts} loading={false} page={1} pageSize={100} total={accounts.length} onPageChange={() => {}} emptyText="حسابی ثبت نشده است." />
        )}
      </div>

      {/* دیالوگ بانک */}
      <Dialog open={bankDlg} onOpenChange={setBankDlg}>
        <DialogContent className="sm:max-w-sm">
          <DialogHeader><DialogTitle>{bankForm.id ? "ویرایش بانک" : "درج بانک"}</DialogTitle></DialogHeader>
          <div className="space-y-4">
            <div className="space-y-1.5">
              <Label>نام بانک</Label>
              <Input value={bankForm.name} onChange={(e) => setBankForm((f) => ({ ...f, name: e.target.value }))} placeholder="مثال: بانک ملی ایران" />
            </div>
            <div className="space-y-1.5">
              <Label>کد بانک</Label>
              <Input value={bankForm.code} onChange={(e) => setBankForm((f) => ({ ...f, code: e.target.value }))} dir="ltr" className="text-right" placeholder="01" />
            </div>
            <div className="space-y-1.5">
              <Label>توضیحات</Label>
              <Input value={bankForm.desc} onChange={(e) => setBankForm((f) => ({ ...f, desc: e.target.value }))} />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setBankDlg(false)}>انصراف</Button>
            <Button onClick={saveBank} disabled={saving} className="bg-[#012875] hover:bg-[#0a3a8f]">{saving ? "…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* دیالوگ شعبه */}
      <Dialog open={branchDlg} onOpenChange={setBranchDlg}>
        <DialogContent className="sm:max-w-sm">
          <DialogHeader><DialogTitle>{branchForm.id ? "ویرایش شعبه" : "درج شعبه"}</DialogTitle></DialogHeader>
          <div className="space-y-4">
            <div className="space-y-1.5">
              <Label>بانک</Label>
              <select
                value={branchForm.bankId}
                onChange={(e) => setBranchForm((f) => ({ ...f, bankId: e.target.value }))}
                className="w-full h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
              >
                <option value="">— انتخاب کنید —</option>
                {banks.map((b) => <option key={b.id} value={b.id}>{b.name}</option>)}
              </select>
            </div>
            <div className="space-y-1.5">
              <Label>نام شعبه</Label>
              <Input value={branchForm.name} onChange={(e) => setBranchForm((f) => ({ ...f, name: e.target.value }))} placeholder="مثال: شعبه مرکزی" />
            </div>
            <div className="space-y-1.5">
              <Label>تلفن</Label>
              <Input value={branchForm.tel} onChange={(e) => setBranchForm((f) => ({ ...f, tel: e.target.value }))} dir="ltr" className="text-right" placeholder="021-xxxxxxxx" />
            </div>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setBranchDlg(false)}>انصراف</Button>
            <Button onClick={saveBranch} disabled={saving} className="bg-[#012875] hover:bg-[#0a3a8f]">{saving ? "…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      {/* دیالوگ حساب */}
      <Dialog open={accDlg} onOpenChange={setAccDlg}>
        <DialogContent className="sm:max-w-md">
          <DialogHeader><DialogTitle>{accForm.id ? "ویرایش حساب بانکی" : "درج حساب بانکی"}</DialogTitle></DialogHeader>
          <div className="space-y-4">
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-1.5">
                <Label>بانک / شعبه</Label>
                <select
                  value={accForm.branchId}
                  onChange={(e) => setAccForm((f) => ({ ...f, branchId: e.target.value }))}
                  className="w-full h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
                >
                  <option value="">— انتخاب کنید —</option>
                  {branchOptions.map((br) => (
                    <option key={br.id} value={br.id}>{br.bank.name} — {br.name}</option>
                  ))}
                </select>
              </div>
              <div className="space-y-1.5">
                <Label>نوع حساب</Label>
                <select
                  value={accForm.accountTypeId}
                  onChange={(e) => setAccForm((f) => ({ ...f, accountTypeId: e.target.value }))}
                  className="w-full h-9 rounded-md border border-input bg-white px-2.5 text-[13px] outline-none focus:border-[#012875]"
                >
                  <option value="">— انتخاب کنید —</option>
                  {types.map((t) => <option key={t.id} value={t.id}>{t.name}</option>)}
                </select>
              </div>
            </div>
            <div className="space-y-1.5">
              <Label>شماره حساب</Label>
              <Input value={accForm.accountNumber} onChange={(e) => setAccForm((f) => ({ ...f, accountNumber: e.target.value }))} dir="ltr" className="text-right" />
            </div>
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-1.5">
                <Label>شماره کارت</Label>
                <Input value={accForm.cardNumber} onChange={(e) => setAccForm((f) => ({ ...f, cardNumber: e.target.value }))} dir="ltr" className="text-right" placeholder="۶۱۰۴-…" />
              </div>
              <div className="space-y-1.5">
                <Label>شماره شبا</Label>
                <Input value={accForm.shabaNumber} onChange={(e) => setAccForm((f) => ({ ...f, shabaNumber: e.target.value }))} dir="ltr" className="text-right" placeholder="IR…" />
              </div>
            </div>
            <div className="space-y-1.5">
              <Label>صاحب حساب</Label>
              <Input value={accForm.accountOwner} onChange={(e) => setAccForm((f) => ({ ...f, accountOwner: e.target.value }))} />
            </div>
            <div className="space-y-1.5">
              <Label>توضیحات</Label>
              <Input value={accForm.desc} onChange={(e) => setAccForm((f) => ({ ...f, desc: e.target.value }))} />
            </div>
            <label className="flex items-center gap-2 text-[13px] cursor-pointer">
              <input
                type="checkbox"
                checked={accForm.isDefault}
                onChange={(e) => setAccForm((f) => ({ ...f, isDefault: e.target.checked }))}
                className="w-4 h-4 accent-[#012875]"
              />
              حساب پیش‌فرض
            </label>
          </div>
          <DialogFooter>
            <Button variant="outline" onClick={() => setAccDlg(false)}>انصراف</Button>
            <Button onClick={saveAccount} disabled={saving} className="bg-[#012875] hover:bg-[#0a3a8f]">{saving ? "…" : "ذخیره"}</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
}
