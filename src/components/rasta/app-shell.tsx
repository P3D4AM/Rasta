"use client";

/**
 * پوسته اصلی رستا — بازسازی میلیمتری _LayoutMain.cshtml محصول CRMIdeal v3.1.18.187
 *
 * ساختار (RTL):
 *  page-wrapper
 *  ├─ page-main-header (۱۱۰px، سایه 0 3px 7px #ddf0f9، padding-right ۷۹px ریل)
 *  │   └─ bxh-Content: bxh-Search (pill جستجو #8598be) + bxh-User (pill کاربر) + bxh-CompanyLogo
 *  ├─ s-m-t (ریل سرمه‌ای #012875 تمام‌قد، گوشه گرد 10px سمت محتوا، آیکون‌های Font Awesome 4.4)
 *  └─ page-body
 *      ├─ Cartables-RowBox (قرص دسترسی سریع #e7effc، آیتم‌ها #1c9cde، جداکننده #61b7e9)
 *      └─ main-contetnt (محتوای صفحه)
 *
 * منابع: MainStyleNew.css + StyPublic.css + MainStyle.css + jsPublicFunction.js
 * آیکون‌های ریل: همان Font Awesome 4.4 خود محصول (فونت کپی‌شده)
 * آیکون‌های هدر/کارتابل: SVG خطی (lucide) مثل آخرین بازطراحی خود CRMIdeal
 */

import { useMemo, useState } from "react";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import {
  Search as SearchIcon,
  X,
  SlidersHorizontal,
  Bell,
  BellRing,
  Power,
  CalendarDays,
  FileChartColumnIncreasing,
  KeyRound,
  Image as ImageIcon,
  RefreshCcw,
  House,
  CalendarCheck,
  Activity,
  Bookmark,
  ListChecks,
  Clock,
  BookOpen,
  HelpingHand,
  Send,
  User,
} from "lucide-react";
import type { SessionUser } from "@/lib/auth";
import { MODULES, type ModuleKey } from "@/lib/constants";
import { cn } from "@/lib/utils";

/* ─────────── درخت منو — مطابق کلیدهای mu و mnu در CRMIdeal (Menus.resx + کلاس‌های s-b) ───────────
   آیکون‌ها = کلاس‌های Font Awesome 4.4 خود محصول (MenuIconClassName از دیتابیس) */

type RailChild = {
  key: string;
  title: string;
  href?: string;
  module?: ModuleKey;
  soon?: boolean; // مثل کلاس IsDisabled در محصول اصلی
};

type RailRoot = {
  key: string;
  title: string;
  icon: string; // کلاس FA4 — مثل خود CRMIdeal
  href?: string;
  module?: ModuleKey;
  soon?: boolean;
  children?: RailChild[];
  dividerAfter?: boolean;
};

const RAIL_MENU: RailRoot[] = [
  /* ── داشبورد (#09ab4b) ── */
  {
    key: "mnuDashboard",
    title: "داشبورد",
    icon: "fa fa-tachometer",
    children: [
      { key: "muHomePage", title: "صفحه اصلی", href: "/dashboard", module: "dashboard" },
      { key: "muCharts", title: "نمودارهای مدیریتی", href: "/reports", module: "reports" },
    ],
    dividerAfter: true,
  },
  /* ── کارتابل‌ها (#2f89fc) ── */
  {
    key: "mnuCartables",
    title: "کارتابل ها",
    icon: "fa fa-inbox",
    children: [
      { key: "muCReminder", title: "یادآورها", href: "/tasks", module: "tasks" },
      { key: "muInternalTask", title: "کارهای داخلی", href: "/tasks", module: "tasks" },
      { key: "muConversations", title: "مکالمات", href: "/activities", module: "activities" },
      { key: "muLetters", title: "نامه های اداری", soon: true },
      { key: "muStatus", title: "وضعیت", soon: true },
    ],
  },
  /* ── بانک اطلاعاتی مشتریان (#2f89fc) ── */
  {
    key: "mnuCustomerDb",
    title: "بانک اطلاعاتی مشتریان",
    icon: "fa fa-database",
    children: [
      { key: "muCompany", title: "مشتریان (طرف حساب ها)", href: "/companies", module: "companies" },
      { key: "muPersons", title: "افراد", href: "/contacts", module: "contacts" },
      { key: "muProject", title: "پروژه ها", href: "/deals", module: "deals" },
      { key: "muFile", title: "پرونده ها", soon: true },
      { key: "muArchiveProject", title: "آرشیو گروهی پروژه ها", soon: true },
    ],
  },
  /* ── ارتباطات هوشمند (#7cb342) ── */
  {
    key: "mnuSmartCommunication",
    title: "ارتباطات هوشمند",
    icon: "fa fa-comments",
    children: [
      { key: "muSmsGroup", title: "ارسال گروهی پیامک", soon: true },
      { key: "muEmailsGroup", title: "ارسال گروهی ایمیل", soon: true },
      { key: "mnuEmailSend", title: "ارسال ایمیل", soon: true },
      { key: "mnuEmailReceive", title: "دریافت ایمیل", soon: true },
    ],
    dividerAfter: true,
  },
  /* ── خرید - فروش - انبار (#00897b) ── */
  {
    key: "mnuBuySellWh",
    title: "خرید - فروش - انبار",
    icon: "fa fa-shopping-cart",
    children: [
      { key: "muPreOrder", title: "پیش فاکتور", href: "/quotations", module: "quotations" },
      { key: "muSaleOrder", title: "فاکتور فروش", href: "/orders", module: "orders" },
      { key: "muBuyOrder", title: "سفارش خرید", href: "/purchases", module: "purchases" },
      { key: "muProducts", title: "محصولات", href: "/products", module: "products" },
      { key: "muWareHouse", title: "انبار", href: "/inventory", module: "inventory" },
      { key: "muWareHouseList", title: "انبارها", href: "/warehouses", module: "warehouses" },
      { key: "muStockSupply", title: "درخواست و رسد تامین کالا", soon: true },
      { key: "muBSWBaseInfo", title: "اطلاعات پایه خرید و فروش", soon: true },
      { key: "muDeliverySchedule", title: "زمان بندی تحویل", soon: true },
    ],
  },
  /* ── پورسانت - خزانه - حقوق (#039be5) ── */
  {
    key: "mnuPayrollFund",
    title: "پورسانت - خزانه - حقوق",
    icon: "fa fa-credit-card",
    children: [
      { key: "muFund", title: "خزانه", href: "/fund", module: "fund" },
      { key: "muBanking", title: "بانک ها و حساب ها", href: "/banking", module: "banking" },
      { key: "muOnlinePayment", title: "پرداخت آنلاین", href: "/settings/payments", module: "payments" },
      { key: "muPayRolls", title: "لیست حقوق", soon: true },
      { key: "muCommission", title: "پورسانت", soon: true },
      { key: "muCostsheet", title: "برگه هزینه", soon: true },
    ],
  },
  /* ── منابع انسانی (#FFCF00) ── */
  {
    key: "mnuHumanResource",
    title: "منابع انسانی",
    icon: "fa fa-users",
    children: [
      { key: "muLeaveMission", title: "مرخصی و ماموریت", soon: true },
      { key: "muTimeAttendance", title: "حضور و غیاب", soon: true },
    ],
  },
  /* ── امتیازدهی مشتریان (#c1586d) ── */
  {
    key: "mnuScore",
    title: "امتیازدهی مشتریان",
    icon: "fa fa-star",
    soon: true,
  },
  /* ── نظرسنجی (#9fbd73) ── */
  {
    key: "mnuSurvey",
    title: "نظرسنجی",
    icon: "fa fa-check-square-o",
    children: [
      { key: "muSurveyDef", title: "تعریف نظرسنجی", soon: true },
      { key: "muSurveyRpt", title: "گزارشات نظرسنجی", soon: true },
    ],
  },
  /* ── باشگاه مشتریان و فروشگاه (#ffc04f) ── */
  {
    key: "mnuFO",
    title: "باشگاه مشتریان و فروشگاه",
    icon: "fa fa-globe",
    children: [
      { key: "muGoToFoUrl", title: "ورود به باشگاه مشتریان", soon: true },
      { key: "muGoToStoreUrl", title: "ورود به فروشگاه آنلاین", soon: true },
    ],
    dividerAfter: true,
  },
  /* ── فرم‌ها (#9ac3d3) ── */
  {
    key: "mnuForms",
    title: "فرم ها",
    icon: "fa fa-list-alt",
    soon: true,
  },
  /* ── فرم‌ساز (#3aa1c3) ── */
  {
    key: "mnuDyForms",
    title: "فرم ساز",
    icon: "fa fa-edit",
    children: [
      { key: "muDyFormDesign", title: "طراحی فرم", soon: true },
      { key: "muDyFormsRpt", title: "گزارشات فرم ساز", soon: true },
    ],
  },
  /* ── گزارش‌ها (#c7c71d) ── */
  {
    key: "mnuReports",
    title: "گزارش ها",
    icon: "fa fa-pie-chart",
    children: [
      { key: "muGeneralReports", title: "گزارش های عمومی", href: "/reports", module: "reports" },
      { key: "muRptChart", title: "نمودارهای گزارشی", href: "/reports", module: "reports" },
      { key: "muDailyActivityChart", title: "نمودار فعالیت روزانه", soon: true },
      { key: "muDailyOrdChart", title: "نمودار مدیریت فروش روزانه", soon: true },
      { key: "muMonthlyOrdChart", title: "نمودار مدیریت فروش ماهانه", soon: true },
      { key: "muRptCall", title: "گزارش های آماری بر اساس تماس", soon: true },
      { key: "muRptPrdSale", title: "گزارش های فروش محصولات", soon: true },
      { key: "muRptWareHouse", title: "گزارش های انبار", soon: true },
    ],
  },
  /* ── هدف‌گذاری فروش (#dd6b6b) ── */
  {
    key: "mnuTargeting",
    title: "هدف گذاری فروش",
    icon: "fa fa-bullseye",
    soon: true,
  },
  /* ── دستیار هوشمند (#6C5CE7) ── */
  {
    key: "mnuAIAssistant",
    title: "دستیار هوشمند",
    icon: "fa fa-magic",
    soon: true,
    dividerAfter: true,
  },
  /* ── ابزارها - راهنما (#546e7a) ── */
  {
    key: "mnuHelpTools",
    title: "ابزارها - راهنما",
    icon: "fa fa-life-ring",
    children: [
      { key: "muHelp", title: "راهنما", soon: true },
      { key: "muTools", title: "ابزارها", soon: true },
      { key: "muShortcuts", title: "میان برها", soon: true },
    ],
  },
  /* ── ارتباطات و امنیت کاربران (#549cf3) ── */
  {
    key: "mnuLinkedUsersAndSecurity",
    title: "ارتباطات و امنیت کاربران",
    icon: "fa fa-shield",
    children: [
      { key: "muLinkedUsers", title: "ارتباط کاربران", href: "/settings/users", module: "users" },
      { key: "muSecurity", title: "امنیت", href: "/settings/roles", module: "roles" },
    ],
  },
  /* ── اطلاعات پایه - تنظیمات (#96a1de) ── */
  {
    key: "mnuBaseInfoSetting",
    title: "اطلاعات پایه - تنظیمات",
    icon: "fa fa-cogs",
    children: [
      { key: "muBaseInfo", title: "اطلاعات پایه", soon: true },
      { key: "muSettings", title: "تنظیمات", href: "/settings", module: "settings" },
      { key: "muSpecificSettings", title: "تنظیمات اختصاصی", href: "/settings/payments", module: "payments" },
    ],
    dividerAfter: true,
  },
];

/* ─────────── ردیف دسترسی سریع کارتابل — Cartables-RowBox خود محصول ───────────
   قرص #e7effc، آیتم‌ها #1c9cde، آیکون SVG خطی (آخرین بازطراحی CRMIdeal)، جداکننده #61b7e9 */

type CartableItem = {
  key: string;
  title: string;
  icon: React.ComponentType<{ className?: string; strokeWidth?: number }>;
  href?: string;
  badge?: number;
  disabled?: boolean; // مثل حالت بدون دسترسی در محصول
};

function useCartables(pathname: string): CartableItem[] {
  return useMemo(
    () => [
      { key: "cHome", title: "خانه", icon: House, href: "/dashboard" },
      { key: "cSearch", title: "جستجو", icon: SearchIcon, href: "/companies" },
      { key: "cReminder", title: "یادآور", icon: BellRing, href: "/tasks" },
      { key: "cDaily", title: "کارنامه روزانه", icon: CalendarCheck, disabled: true },
      { key: "cStatus", title: "وضعیت", icon: Activity, href: "/activities" },
      { key: "cBookMarks", title: "نشانک ها", icon: Bookmark, disabled: true },
      { key: "cInternalTask", title: "کارهای داخلی", icon: ListChecks, href: "/tasks" },
      { key: "cTimeAttendance", title: "حضور و غیاب", icon: Clock, disabled: true },
      { key: "cKnowledge", title: "دانش نامه", icon: BookOpen, disabled: true },
      { key: "cForget", title: "فراموشی ها", icon: HelpingHand, disabled: true },
      { key: "cTelegram", title: "تلگرام", icon: Send, disabled: true },
    ],
    [pathname]
  );
}

/* دسترسی‌پذیری ماژول بر اساس نقش کاربر (مثل UserLogin.IsUserAccess) */
function useModuleAccess(user: SessionUser) {
  return useMemo(() => {
    const can = (m?: ModuleKey) => {
      if (!m) return true;
      return user.isAdmin || user.permissions[m]?.canView !== false;
    };
    return can;
  }, [user]);
}

/* ─────────── پوسته ─────────── */

export function AppShell({ user, children }: { user: SessionUser; children: React.ReactNode }) {
  const pathname = usePathname();
  const router = useRouter();
  const can = useModuleAccess(user);

  // حالت ریل: باز/بسته + ریشه انتخاب‌شده (رفتار ShowSideBarSubMenu / ShowSideBarMenuIcons)
  const [railOpen, setRailOpen] = useState(false);
  const [openRoot, setOpenRoot] = useState<string | null>(null);
  const [profileOpen, setProfileOpen] = useState(false);
  const [loggingOut, setLoggingOut] = useState(false);
  const [searchQ, setSearchQ] = useState("");

  const railWidth = railOpen ? 260 : 79; // بسته ۷۹px مثل خود محصول
  const cartables = useCartables(pathname);

  function toggleRoot(key: string) {
    // مثل ShowSideBarSubMenu: کلیک روی ریشه → ریل باز + زیرمنوی همان ریشه
    if (openRoot === key && railOpen) {
      setRailOpen(false);
      setOpenRoot(null);
    } else {
      setRailOpen(true);
      setOpenRoot(key);
    }
  }

  function navigateAndCloseRail() {
    setRailOpen(false);
    setOpenRoot(null);
  }

  async function logout() {
    setLoggingOut(true);
    await fetch("/api/auth/logout", { method: "POST" });
    router.replace("/login");
    router.refresh();
  }

  const fullName = `${user.firstName ?? ""} ${user.lastName ?? ""}`.trim();
  const initials = `${user.firstName?.[0] ?? ""}${user.lastName?.[0] ?? ""}`;

  return (
    <div className="page-wrapper min-h-screen bg-white" dir="rtl">
      {/* ═══════════ هدر اصلی (page-main-header → bxh-Content 110px) ═══════════ */}
      <header
        className="fixed top-0 right-0 left-0 z-[500] bg-white h-[110px] flex items-center"
        style={{
          boxShadow: "0 3px 7px #ddf0f9",
          paddingRight: 79, /* ثابت مثل Main-Bar محصول — ریل باز روی محتوا می‌افتد (z-index 503) */
        }}
      >
        <div className="flex items-center w-full h-full px-4 lg:px-8 gap-4">
          {/* ── جستجوی اصلی (bxh-Search → bxc-Search-inf-I) ── */}
          <div className="flex-1 flex justify-center min-w-0">
            <div className="crm-pill w-full max-w-2xl flex items-center gap-1 bg-white px-4 py-1.5">
              <SearchIcon className="w-[22px] h-[22px] shrink-0" style={{ color: "#48659c" }} strokeWidth={1} />
              <input
                value={searchQ}
                onChange={(e) => setSearchQ(e.target.value)}
                className="flex-1 min-w-0 bg-transparent outline-none border-0 text-[18px] font-light placeholder:text-[#9aa8c4]"
                placeholder="جستجو ..."
                aria-label="جستجوی سراسری"
              />
              {searchQ ? (
                <button
                  type="button"
                  onClick={() => setSearchQ("")}
                  className="text-[#404040] hover:text-black"
                  aria-label="پاک‌کردن جستجو"
                >
                  <X className="w-[22px] h-[22px]" strokeWidth={1} />
                </button>
              ) : null}
              <button
                type="button"
                className="hidden md:flex items-center gap-1.5 rounded-full px-[17px] py-2 text-[15px] whitespace-nowrap"
                style={{ backgroundColor: "#dae6fe", color: "#8596bd" }}
              >
                <SlidersHorizontal className="w-4 h-4" />
                <span>شرایط جستجو</span>
              </button>
            </div>
          </div>

          {/* ── بخش کاربر (bxh-User → bxc-User-inf) ── */}
          <div className="crm-pill hidden lg:flex items-center gap-1 bg-white pl-3 pr-4 py-1.5 shrink-0">
            {/* زبان — fa-globe #012875، 21px */}
            <button
              type="button"
              className="w-8 flex flex-col items-center justify-center rounded-full py-1 transition-colors hover:bg-[#ddf0f9]"
              style={{ color: "#012875" }}
              title="فارسی"
            >
              <i className="fa fa-globe" style={{ fontSize: 21 }} />
              <span className="text-[10px] font-medium leading-3 mt-0.5">FA</span>
            </button>

            <span className="crm-hrv" />

            {/* ایمیل — fa-envelope-o #fdcc3b، 22px */}
            <button
              type="button"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="ایمیل"
            >
              <i className="fa fa-envelope-o" style={{ fontSize: 22, color: "#fdcc3b" }} />
            </button>

            {/* پیامک — SVG خطی #fdcc3b مثل آخرین بازطراحی محصول */}
            <button
              type="button"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="پیامک"
            >
              <svg width="26" height="26" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path
                  d="M7 8.5H12M7 12H15M9.68375 18H16.2C17.8802 18 18.7202 18 19.362 17.673C19.9265 17.3854 20.3854 16.9265 20.673 16.362C21 15.7202 21 14.8802 21 13.2V7.8C21 6.11984 21 5.27976 20.673 4.63803C20.3854 4.07354 19.9265 3.6146 19.362 3.32698C18.7202 3 17.8802 3 16.2 3H7.8C6.11984 3 5.27976 3 4.63803 3.32698C4.07354 3.6146 3.6146 4.07354 3.32698 4.63803C3 5.27976 3 6.11984 3 7.8V20.3355C3 20.8684 3 21.1348 3.10923 21.2716C3.20422 21.3906 3.34827 21.4599 3.50054 21.4597C3.67563 21.4595 3.88367 21.2931 4.29976 20.9602L6.68521 19.0518C7.17252 18.662 7.41617 18.4671 7.68749 18.3285C7.9282 18.2055 8.18443 18.1156 8.44921 18.0613C8.74767 18 9.0597 18 9.68375 18Z"
                  stroke="#fdcc3b"
                  strokeWidth="2"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                />
              </svg>
            </button>

            <span className="crm-hrv" />

            {/* زنگ تاییدها — SVG خطی #29b2c2 */}
            <Link
              href="/tasks"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="پیام‌های تایید نشده"
            >
              <Bell className="w-[26px] h-[26px]" style={{ color: "#29b2c2" }} strokeWidth={1} />
            </Link>

            {/* زنگ پیام‌ها — SVG خطی #df63a0 */}
            <Link
              href="/tasks"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="کارهای داخلی"
            >
              <BellRing className="w-[26px] h-[26px]" style={{ color: "#df63a0" }} strokeWidth={1} />
            </Link>

            {/* پروفایل (ai-item → userProfiler) */}
            <div className="relative">
              <button
                type="button"
                onClick={() => setProfileOpen((v) => !v)}
                className="flex items-center gap-2 rounded-full py-1 px-1.5 transition-colors hover:bg-[#ddf0f9]"
              >
                <span className="hidden xl:flex flex-col items-start leading-tight">
                  <span className="text-[14px] font-bold text-[#575757] max-w-[90px] truncate">
                    {user.lastName || fullName || user.username}
                  </span>
                  <span className="text-[12px] font-light text-[#575757] max-w-[90px] truncate">
                    {user.roleName ?? (user.isAdmin ? "مدیر سیستم" : "")}
                  </span>
                </span>
                <span
                  className="w-[39px] h-[39px] rounded-full flex items-center justify-center overflow-hidden shrink-0"
                  style={{ backgroundColor: "#012875" }}
                >
                  {initials ? (
                    <span className="text-white text-[15px] font-semibold">{initials}</span>
                  ) : (
                    /* آیکون پیش‌فرض کاربر مثل Images/icon/CRM-User-White.svg */
                    <User className="w-5 h-5 text-white" strokeWidth={1.5} />
                  )}
                </span>
              </button>

              {/* profile-dropdown: 195px، سفید، گوشه 7px، سایه #cacaca */}
              {profileOpen ? (
                <>
                  <div className="fixed inset-0 z-40" onClick={() => setProfileOpen(false)} />
                  <div
                    className="absolute top-[52px] left-0 z-50 w-[195px] bg-white rounded-[7px] p-1.5"
                    style={{ boxShadow: "0 0 5px #cacaca" }}
                  >
                    <div className="px-3 py-2 border-b border-[#e5e7eb] mb-1">
                      <div className="text-[14px] font-semibold text-[#1f2733] truncate">{fullName || user.username}</div>
                      <div className="text-[11px] text-[#b3b3b3]">{user.roleName ?? ""}</div>
                    </div>
                    <MenuRow icon={CalendarDays} label="حاضری امروز" />
                    <MenuRow icon={FileChartColumnIncreasing} label="یادداشت روزانه" />
                    <MenuRow icon={KeyRound} label="تغییر رمز عبور" />
                    <MenuRow icon={ImageIcon} label="تغییر تصویر کاربر" />
                    <MenuRow icon={RefreshCcw} label="به‌روزرسانی حافظه" />
                    <button
                      type="button"
                      onClick={logout}
                      disabled={loggingOut}
                      className="w-full flex items-center gap-2 px-3 py-2 rounded-md text-[13px] text-[#e80c4d] hover:bg-[#f7f9fc] transition-colors"
                    >
                      <Power className="w-4 h-4" />
                      {loggingOut ? "در حال خروج…" : "خروج"}
                    </button>
                  </div>
                </>
              ) : null}
            </div>
          </div>

          {/* ── لوگوی شرکت (bxh-CompanyLogo) ── */}
          <div className="hidden xl:flex items-center gap-2 shrink-0 max-w-[310px]">
            <div className="flex flex-col items-start leading-tight">
              <span className="text-[18px] font-bold max-w-[180px] truncate" style={{ color: "#022873" }}>
                رستا
              </span>
              <span className="text-[12px] ltr:text-left w-full text-right" style={{ color: "#b3b3b3" }} dir="ltr">
                rasta.crm
              </span>
            </div>
            <span
              className="w-[65px] h-[65px] rounded-full bg-white flex items-center justify-center shrink-0"
              style={{ filter: "drop-shadow(4px 2px 6px #cacaca)" }}
            >
              <img src="/images/logo/rasta-mark-navy.svg" alt="رستا" className="w-[46px] h-[46px]" />
            </span>
          </div>
        </div>
      </header>

      {/* ═══════════ ریل منو (#s-m-t) — سرمه‌ای تمام‌قد، گوشه گرد، آیکون‌های FA4 ═══════════ */}
      <aside
        className={cn(
          "crm-rail fixed top-0 bottom-0 right-0 z-[503] flex flex-col text-white transition-[width] duration-300 overflow-hidden",
          railOpen ? "shadow-[_-4px_0_14px_rgba(1,40,117,0.35)]" : ""
        )}
        style={{ width: railWidth }}
        onMouseLeave={() => {
          /* رفتار خود محصول: خروج موس از ریل → جمع شدن (ShowSideBarMenuIcons(true)) */
          setRailOpen(false);
          setOpenRoot(null);
        }}
      >
        {/* لوگو (s-m-app-icon): بسته 75px / باز 104px + شعار */}
        <div className="crm-rail-logo pt-4 flex flex-col items-center shrink-0">
          <Link href="/dashboard" className="flex flex-col items-center" onClick={navigateAndCloseRail}>
            {railOpen ? (
              <img src="/images/logo/rasta-logo-text-white.svg" alt="رستا" className="h-[104px] w-auto" />
            ) : (
              <img src="/images/logo/rasta-mark-white.svg" alt="رستا" className="w-[75px] h-[75px]" />
            )}
          </Link>
          {railOpen ? (
            <label className="text-white text-[9px] pr-[78px] self-start font-medium">مدیریت ارتباط با مشتری</label>
          ) : null}
        </div>

        {/* آیتم‌های منو (#s-m-t-content) */}
        <nav className="flex-1 overflow-y-auto crm-scroll px-1.5 pb-4" style={{ height: "calc(100% - 140px)" }}>
          {RAIL_MENU.map((root) => {
            const rootSoon = root.soon === true;
            const visible = rootSoon
              ? true // آیتم‌های غیرفعال هم مثل محصول نمایش داده می‌شوند (کلاس IsDisabled)
              : root.href
                ? can(root.module)
                : (root.children ?? []).some((c) => !c.soon && can(c.module)) || (root.children ?? []).length === 0;
            if (!visible) return null;

            const rootActive = root.href ? pathname.startsWith(root.href) : false;
            const isOpen = openRoot === root.key && railOpen;
            const hasChildren = (root.children ?? []).length > 0;

            return (
              <div key={root.key}>
                <div
                  className={cn("crm-rail-node", isOpen && "Selected")}
                  title={!railOpen ? root.title : undefined}
                >
                  {/* سربرگ ریشه (s-b-head): آیکون FA + عنوان hidable */}
                  {root.href && !rootSoon ? (
                    <Link
                      href={root.href}
                      onClick={navigateAndCloseRail}
                      className="crm-rail-head flex items-center w-full"
                    >
                      <i className={cn(root.icon, "crm-rail-icon shrink-0")} />
                      <span
                        className="crm-rail-item-title truncate flex-1 text-right"
                        style={{ display: railOpen ? "block" : "none" }}
                      >
                        {root.title}
                      </span>
                    </Link>
                  ) : (
                    <button
                      type="button"
                      onClick={() => (rootSoon || !hasChildren ? undefined : toggleRoot(root.key))}
                      className={cn("crm-rail-head flex items-center w-full", rootSoon && "opacity-40 cursor-not-allowed")}
                    >
                      <i className={cn(root.icon, "crm-rail-icon shrink-0")} />
                      <span
                        className="crm-rail-item-title truncate flex-1 text-right"
                        style={{ display: railOpen ? "block" : "none" }}
                      >
                        {root.title}
                      </span>
                      {/* فلش باز/بسته — fa-caret-left/down رنگ #8e8ddb مثل محصول */}
                      {railOpen && hasChildren && !rootSoon ? (
                        <i
                          className={cn(
                            "fa crm-rail-caret transition-transform duration-300",
                            isOpen ? "fa-caret-down" : "fa-caret-left"
                          )}
                        />
                      ) : null}
                    </button>
                  )}
                </div>

                {/* زیرمنو (child-node): margin-right 25px مثل محصول */}
                {root.children && railOpen && !rootSoon ? (
                  <div
                    className={cn(
                      "transition-all duration-300 overflow-hidden",
                      isOpen ? "max-h-[600px] opacity-100" : "max-h-0 opacity-0"
                    )}
                  >
                    <div className="crm-rail-child">
                      {root.children.map((child) => {
                        if (child.soon) {
                          /* آیتم‌های غیرفعال — مثل کلاس IsDisabled با نقطه fa-circle 5px */
                          return (
                            <div
                              key={child.key}
                              className="flex items-center gap-2 px-2 py-1.5 opacity-40 cursor-not-allowed"
                              title="در نسخه‌های بعدی رستا"
                            >
                              <i className="fa fa-circle crm-rail-leaf-dot shrink-0" />
                              <span className="crm-rail-item-title text-[13px]">{child.title}</span>
                            </div>
                          );
                        }
                        if (!can(child.module)) return null;
                        const active = child.href ? pathname.startsWith(child.href) : false;
                        return (
                          <Link
                            key={child.key}
                            href={child.href ?? "#"}
                            onClick={navigateAndCloseRail}
                            className={cn("crm-rail-node flex items-center gap-2 px-2 py-1.5", active && "Selected")}
                          >
                            <i className="fa fa-circle crm-rail-leaf-dot shrink-0" />
                            <span className="crm-rail-item-title text-[13px] truncate">{child.title}</span>
                          </Link>
                        );
                      })}
                    </div>
                  </div>
                ) : null}

                {root.dividerAfter ? <div className="crm-rail-divider" /> : null}
              </div>
            );
          })}

          {/* خروج — انتهای ریل (muExit) */}
          <div className="crm-rail-divider" />
          <div className="crm-rail-node" title={!railOpen ? "خروج" : undefined}>
            <button
              type="button"
              onClick={logout}
              disabled={loggingOut}
              className="crm-rail-head flex items-center w-full"
            >
              <i className="fa fa-power-off crm-rail-icon shrink-0" />
              <span
                className="crm-rail-item-title truncate flex-1 text-right"
                style={{ display: railOpen ? "block" : "none" }}
              >
                {loggingOut ? "در حال خروج…" : "خروج"}
              </span>
            </button>
          </div>
        </nav>

        {/* نسخه (lblVer): پایین ریل در حالت باز */}
        <div
          className="crm-rail-ver text-[10px] text-center pb-2 shrink-0"
          style={{ display: railOpen ? "block" : "none" }}
          dir="ltr"
        >
          Rasta 0.3.0
        </div>
      </aside>

      {/* ═══════════ بدنه صفحه (page-body) — padding-right ثابت ۷۹px مثل .main-contetnt محصول ═══════════ */}
      <main className="min-h-screen bg-white" style={{ paddingTop: 110, paddingRight: 79 }}>
        {/* ردیف دسترسی سریع کارتابل (Cartables-RowBox) — در همه صفحات مثل خود محصول */}
        <div className="px-4 lg:px-6 pt-1">
          <div className="flex justify-center">
            <div className="crm-cartables-strip">
              {cartables.map((c) => {
                const inner = (
                  <>
                    <c.icon className="w-[26px] h-[26px] shrink-0" strokeWidth={1} />
                    <span className="text-[13px] font-medium whitespace-nowrap">{c.title}</span>
                  </>
                );
                if (c.disabled) {
                  return (
                    <span key={c.key} className="crm-cartable-item is-disabled px-1 mx-0.5" title="در نسخه‌های بعدی">
                      {inner}
                    </span>
                  );
                }
                return (
                  <Link key={c.key} href={c.href ?? "#"} className="crm-cartable-item px-1 mx-0.5">
                    {inner}
                  </Link>
                );
              })}
            </div>
          </div>
        </div>

        <div className="p-4 lg:p-6">{children}</div>
      </main>
    </div>
  );
}

function MenuRow({
  icon: Icon,
  label,
}: {
  icon: React.ComponentType<{ className?: string }>;
  label: string;
}) {
  return (
    <button
      type="button"
      className="w-full flex items-center gap-2 px-3 py-2 rounded-md text-[13px] text-[#1f2733] hover:bg-[#f7f9fc] transition-colors"
    >
      <Icon className="w-4 h-4 text-[#528fcc]" />
      {label}
    </button>
  );
}

/* ─────────── دسترسی سریع داشبورد (quick-access-box) ───────────
   بازسازی قرص‌های StyHomePage.css: bg #e7effc، radius 50px،
   padding 12px 20px، فونت ravi-regular 17px، فلش #50a5d2 */

import {
  CheckCheck,
  ChartColumn,
  Tickets,
  ChartNoAxesCombined,
  GitPullRequestArrow,
  ArrowLeft,
} from "lucide-react";

export const QUICK_ACCESS = [
  { href: "/tasks", icon: CalendarCheck, label: "تقویم کاری" },
  { href: "/tasks", icon: CheckCheck, label: "مهم‌ترین پیگیری‌ها" },
  { href: "/companies", icon: User, label: "وضعیت مشتریان" },
  { href: "/quotations", icon: FileChartColumnIncreasing, label: "لیست پیش‌فاکتورها" },
  { href: "/reports", icon: ChartColumn, label: "گزارش‌ساز" },
  { href: "/tasks", icon: Tickets, label: "لیست کارهای جاری" },
  { href: "/reports", icon: ChartNoAxesCombined, label: "داشبورد فروش" },
  { href: "/tasks", icon: GitPullRequestArrow, label: "کارهای ارجاع‌شده" },
] as const;

export function QuickAccessBox() {
  return (
    <div className="relative z-[200] max-w-[600px] mx-auto mt-[40px] lg:mt-[50px]">
      <div className="flex flex-wrap justify-center">
        {QUICK_ACCESS.map((qa, i) => (
          <Link
            key={qa.label}
            href={qa.href}
            className={cn(
              "crm-qa-item group flex items-center gap-2 w-[calc(50%-10px)]",
              i % 2 === 0 ? "ml-[15px]" : "ml-0"
            )}
          >
            <span className="w-[30px] shrink-0 flex items-center justify-center">
              <qa.icon className="w-6 h-6 text-black" strokeWidth={1.6} />
            </span>
            <span className="flex-1 text-right text-[16px] lg:text-[17px] font-normal text-black truncate">
              {qa.label}
            </span>
            <span className="w-[30px] shrink-0 flex items-center justify-center">
              <ArrowLeft className="w-[26px] h-[26px]" style={{ fill: "#50a5d2", color: "#50a5d2" }} />
            </span>
          </Link>
        ))}
      </div>
    </div>
  );
}

/* نگاشت آیکون ماژول‌ها برای استفاده در سایر اجزا */
export const MODULE_ICONS: Record<string, React.ComponentType<{ className?: string }>> = {
  Building2: House,
};
