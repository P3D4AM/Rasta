"use client";

/**
 * صفحه ورود رستا — بازسازی Views/Account/Login.cshtml محصول CRMIdeal
 *
 * ساختار (StyLogin.css):
 *  container-fluid > row
 *  ├─ box-left (col-lg-3، #509ACF): لوگو + فرم لاگین + دکمه ورود (#0373BD سه‌بعدی)
 *  └─ box-right (col-lg-9، #f3f3f3): تصویر معرفی وسط‌چین
 *
 * جزئیات میلیمتری: آیکون‌های چسبیده به اینپوت (39×38، #0373BD، گوشه گرد سمت راست)،
 * دکمه SubmitButton با سایه سه‌بعدی 0 3px 0 #055A92، جعبه خطا #e80c4d با درخشش.
 */

import { useState } from "react";
import { useRouter } from "next/navigation";
import { UserRound, Lock, Power } from "lucide-react";
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
      toast({ title: "خوش آمدید", description: `${data.user.firstName} ${data.user.lastName}` });
      router.replace("/dashboard");
      router.refresh();
    } catch {
      setError("ارتباط با سرور برقرار نشد.");
    } finally {
      setLoading(false);
    }
  }

  return (
    <div className="min-h-screen w-full flex" dir="rtl">
      <div className="flex flex-col lg:flex-row w-full min-h-screen">
        {/* ═══════════ box-left: پنل آبی ورود (#509ACF) ═══════════ */}
        <div
          className="lg:w-[25%] w-full flex flex-col items-center px-4 py-8 lg:py-10 overflow-y-auto"
          style={{ backgroundColor: "#509ACF", boxShadow: "0 0 5px rgba(0,0,0,.3)" }}
        >
          {/* لوگو (div-logo) */}
          <div className="mb-6 flex flex-col items-center">
            { }
            <img src="/images/logo/rasta-logo-text-white.svg" alt="رستا" className="h-24 w-auto" />
          </div>

          {/* جعبه ورود (box-login) */}
          <div className="w-[90%] max-w-[330px]">
            {/* خطا (Error-Login): قرمز #e80c4d با درخشش */}
            {error ? (
              <div
                className="mb-4 rounded-[5px] px-3 py-2 text-white text-center text-[13px] animate-pulse"
                style={{ backgroundColor: "#e80c4d", boxShadow: "0 0 5px 1px #e80c4d" }}
              >
                {error}
              </div>
            ) : null}

            <form onSubmit={onSubmit} id="form-login">
              {/* نام کاربری: آیکون چسبیده #0373BD + اینپوت */}
              <div className="flex items-stretch mb-2">
                <span
                  className="w-[39px] shrink-0 flex items-center justify-center text-white rounded-r-[4px]"
                  style={{ backgroundColor: "#0373BD" }}
                >
                  <UserRound className="w-5 h-5" strokeWidth={1.7} />
                </span>
                <input
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  className="flex-1 min-w-0 h-[38px] px-3 rounded-l-[4px] rounded-r-none border border-[#cacaca] outline-none text-[14px] focus:border-[#0373BD]"
                  placeholder="نام کاربری"
                  autoComplete="username"
                  dir="ltr"
                  style={{ textAlign: "right" }}
                />
              </div>

              {/* رمز عبور: آیکون چسبیده #0373BD + اینپوت */}
              <div className="flex items-stretch mb-4">
                <span
                  className="w-[39px] shrink-0 flex items-center justify-center text-white rounded-r-[4px]"
                  style={{ backgroundColor: "#0373BD" }}
                >
                  <Lock className="w-5 h-5" strokeWidth={1.7} />
                </span>
                <input
                  type="password"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  className="flex-1 min-w-0 h-[38px] px-3 rounded-l-[4px] rounded-r-none border border-[#cacaca] outline-none text-[14px] focus:border-[#0373BD]"
                  placeholder="رمز عبور"
                  autoComplete="current-password"
                  dir="ltr"
                  style={{ textAlign: "right" }}
                />
              </div>

              {/* دکمه ورود (SubmitButton): #0373BD سه‌بعدی */}
              <button
                type="submit"
                disabled={loading}
                className="w-full h-[40px] rounded-[8px] text-white text-[15px] font-medium transition-all active:translate-y-[2px] active:shadow-none disabled:opacity-70"
                style={{
                  backgroundColor: "#0373BD",
                  boxShadow: "0 3px 0 #055A92, 0 3px 6px rgba(0,0,0,.35)",
                }}
              >
                {loading ? "در حال ورود…" : "ورود"}
              </button>
            </form>
          </div>

          {/* تماس با ما (div-contactUs) */}
          <div className="mt-auto pt-10 flex flex-col items-center gap-2 w-full">
            <a
              href="mailto:support@rasta.crm"
              className="block rounded-[8px] bg-white/95 hover:bg-white transition-colors px-6 py-2.5 text-[13px] font-medium"
              style={{ color: "#0373BD", boxShadow: "0 0 5px rgba(0,0,0,.25)" }}
            >
              تماس با پشتیبانی
            </a>
            {/* نسخه (div-DateTime) */}
            <label className="text-white/85 text-[11px] mt-1" dir="ltr">
              Version: Rasta 0.2.0
            </label>
          </div>
        </div>

        {/* ═══════════ box-right: پنل معرفی (#f3f3f3) ═══════════ */}
        <div className="lg:w-[75%] w-full flex items-center justify-center p-8" style={{ backgroundColor: "#f3f3f3" }}>
          <div className="max-w-xl text-center">
            {/* جای تصویر معرفی (div-mainLogo) */}
            <div className="mx-auto mb-8 w-56 h-56 rounded-full bg-white flex items-center justify-center" style={{ boxShadow: "0 0 12px rgba(0,0,0,.08)" }}>
              { }
              <img src="/images/logo/rasta-mark-navy.svg" alt="رستا" className="w-32 h-32" />
            </div>

            <h1 className="text-3xl font-bold mb-3" style={{ color: "#012875" }}>
              سامانه مدیریت ارتباط با مشتری رستا
            </h1>
            <p className="text-[15px] leading-8 text-[#5c6b8a] max-w-lg mx-auto">
              بازسازی مدرن و سبک نرم‌افزار CRM ایده‌آل — مدیریت مشتریان، فرصت‌های فروش، پیش‌فاکتور،
              سفارش، خزانه، بانک‌داری و پرداخت آنلاین در یک سامانه یکپارچه فارسی.
            </p>

            <div className="flex flex-wrap justify-center gap-3 mt-8">
              {["مشتریان و مخاطبین", "قیف فروش", "خزانه و بانک", "گزارش‌های زنده"].map((f) => (
                <span
                  key={f}
                  className="px-4 py-1.5 rounded-full text-[13px]"
                  style={{ backgroundColor: "#e7effc", color: "#012875" }}
                >
                  {f}
                </span>
              ))}
            </div>

            <div className="flex items-center justify-center gap-2 mt-10 text-[12px] text-[#b3b3b3]">
              <Power className="w-3.5 h-3.5" />
              <span>سامانه تحت وب رستا — نسخه بازسازی‌شده</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
