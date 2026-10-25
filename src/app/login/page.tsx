"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { motion } from "framer-motion";
import { Building2, Lock, LogIn, User, AlertCircle } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Toaster } from "@/components/ui/toaster";
import { useToast } from "@/hooks/use-toast";

export default function LoginPage() {
  const router = useRouter();
  const { toast } = useToast();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  async function onSubmit(e: React.FormEvent) {
    e.preventDefault();
    if (!username.trim() || !password) {
      setError("نام کاربری و رمز عبور را وارد کنید.");
      return;
    }
    setLoading(true);
    setError(null);
    try {
      const res = await fetch("/api/auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ username: username.trim(), password }),
      });
      const data = await res.json().catch(() => ({}));
      if (!res.ok) {
        setError(data.error ?? "خطا در ورود. دوباره تلاش کنید.");
        return;
      }
      toast({ title: "خوش آمدید 👋", description: `${data.user.firstName} ${data.user.lastName}` });
      router.replace("/dashboard");
      router.refresh();
    } catch {
      setError("ارتباط با سرور برقرار نشد.");
    } finally {
      setLoading(false);
    }
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-[oklch(0.21_0.03_170)] via-[oklch(0.24_0.04_168)] to-[oklch(0.17_0.02_165)] p-4">
      <motion.div
        initial={{ opacity: 0, y: 24 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5, ease: "easeOut" }}
        className="w-full max-w-md"
      >
        <div className="bg-card/95 backdrop-blur rounded-2xl shadow-2xl border border-border overflow-hidden">
          {/* Header */}
          <div className="px-8 pt-10 pb-6 text-center">
            <div className="mx-auto w-16 h-16 rounded-2xl bg-primary flex items-center justify-center shadow-lg mb-4">
              <Building2 className="w-8 h-8 text-primary-foreground" />
            </div>
            <h1 className="text-2xl font-extrabold tracking-tight">رستا</h1>
            <p className="text-sm text-muted-foreground mt-2">
              سامانه مدیریت ارتباط با مشتری، فروش و کارتابل سازمانی
            </p>
          </div>

          {/* Form */}
          <form onSubmit={onSubmit} className="px-8 pb-8 space-y-5">
            <div className="space-y-2">
              <Label htmlFor="username">نام کاربری</Label>
              <div className="relative">
                <User className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
                <Input
                  id="username"
                  className="ps-9"
                  placeholder="نام کاربری خود را وارد کنید"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  autoComplete="username"
                  autoFocus
                />
              </div>
            </div>

            <div className="space-y-2">
              <Label htmlFor="password">رمز عبور</Label>
              <div className="relative">
                <Lock className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground" />
                <Input
                  id="password"
                  type="password"
                  className="ps-9"
                  placeholder="••••••••"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  autoComplete="current-password"
                />
              </div>
            </div>

            {error && (
              <div className="flex items-start gap-2 rounded-lg bg-destructive/10 text-destructive px-3 py-2.5 text-sm">
                <AlertCircle className="w-4 h-4 mt-0.5 shrink-0" />
                <span>{error}</span>
              </div>
            )}

            <Button type="submit" className="w-full font-bold" disabled={loading}>
              {loading ? (
                <span className="animate-pulse">در حال ورود…</span>
              ) : (
                <>
                  <LogIn className="w-4 h-4 me-1" />
                  ورود به سامانه
                </>
              )}
            </Button>

            <p className="text-center text-xs text-muted-foreground leading-relaxed">
              نسخه ۱.۰ — بازطراحی مدرن نرم‌افزار CRM ایده‌آل
            </p>
          </form>
        </div>
      </motion.div>
    </div>
  );
}
