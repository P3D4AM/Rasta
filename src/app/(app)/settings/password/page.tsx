"use client";

/** تغییر رمز عبور — ChangePassword خود محصول (رمز فعلی/جدید/تکرار) */

import { useState } from "react";
import { useRouter } from "next/navigation";
import { KeyRound } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { PageHeader } from "@/components/rasta/page-header";
import { useToast } from "@/hooks/use-toast";
import { api } from "@/hooks/use-list";

export default function ChangePasswordPage() {
  const { toast } = useToast();
  const router = useRouter();
  const [form, setForm] = useState({ currentPassword: "", newPassword: "", repeatPassword: "" });
  const [saving, setSaving] = useState(false);

  async function save() {
    if (!form.currentPassword || !form.newPassword || !form.repeatPassword) {
      return toast({ title: "هر سه فیلد الزامی است.", variant: "destructive" });
    }
    if (form.newPassword.length < 6) {
      return toast({ title: "رمز جدید باید حداقل ۶ کاراکتر باشد.", variant: "destructive" });
    }
    if (form.newPassword !== form.repeatPassword) {
      return toast({ title: "تکرار رمز جدید مطابقت ندارد.", variant: "destructive" });
    }
    setSaving(true);
    try {
      await api("/api/auth/change-password", { method: "POST", body: form });
      toast({ title: "رمز عبور تغییر کرد." });
      router.push("/dashboard");
    } catch (e) {
      toast({ title: "خطا", description: (e as Error).message, variant: "destructive" });
    } finally {
      setSaving(false);
    }
  }

  return (
    <div className="max-w-md mx-auto">
      <PageHeader title="تغییر رمز عبور" />
      <Card>
        <CardHeader className="pb-2">
          <CardTitle className="text-sm flex items-center gap-1.5"><KeyRound className="w-4 h-4 text-muted-foreground" />رمز عبور حساب کاربری شما</CardTitle>
        </CardHeader>
        <CardContent className="space-y-3">
          <div className="space-y-1.5">
            <Label>رمز عبور فعلی *</Label>
            <Input dir="ltr" type="password" value={form.currentPassword} onChange={(e) => setForm({ ...form, currentPassword: e.target.value })} />
          </div>
          <div className="space-y-1.5">
            <Label>رمز عبور جدید *</Label>
            <Input dir="ltr" type="password" value={form.newPassword} onChange={(e) => setForm({ ...form, newPassword: e.target.value })} />
          </div>
          <div className="space-y-1.5">
            <Label>تکرار رمز عبور جدید *</Label>
            <Input dir="ltr" type="password" value={form.repeatPassword} onChange={(e) => setForm({ ...form, repeatPassword: e.target.value })} />
          </div>
          <Button className="w-full" onClick={save} disabled={saving}>{saving ? "در حال ثبت…" : "تغییر رمز عبور"}</Button>
        </CardContent>
      </Card>
    </div>
  );
}
