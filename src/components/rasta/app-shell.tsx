"use client";

/**
 * پوسته اصلی رستا — بازسازی میلیمتری _LayoutMain.cshtml محصول CRMIdeal v3.1.18
 *
 * ساختار (RTL):
 *  page-wrapper
 *  ├─ page-main-header (۱۱۰px، سایه 0 3px 7px #ddf0f9، padding-right برای ریل)
 *  │   └─ bxh-Content: bxh-Search (pill جستجو) + bxh-User (pill کاربر) + bxh-CompanyLogo
 *  ├─ s-m-t (ریل سرمه‌ای #012875 تمام‌قد، گوشه 10px، حالت آیکونی 80px / باز 260px)
 *  └─ page-body (سفید، padding-right 80px)
 *
 * منبع استایل‌ها: Content/MainStyleNew.css + StyPublic.css + sidebar-menu.js
 */

import { useMemo, useState } from "react";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import {
  Home,
  Users,
  Target,
  FileText,
  ShoppingCart,
  Warehouse,
  Wallet,
  MessageSquare,
  ClipboardList,
  BarChart3,
  Settings,
  Power,
  ChevronLeft,
  Search,
  SlidersHorizontal,
  X,
  Globe,
  Mail,
  MessageCircle,
  Bell,
  BellRing,
  Lock,
  UserRound,
  KeyRound,
  Image as ImageIcon,
  RefreshCcw,
  LogOut,
  CalendarDays,
  CheckCheck,
  User,
  FileChartColumnIncreasing,
  ChartColumn,
  Tickets,
  ChartNoAxesCombined,
  GitPullRequestArrow,
  ArrowLeft,
  Building2,
  Package,
  ReceiptText,
  PhoneCall,
  Landmark,
  CreditCard,
  UserCog,
  ShieldCheck,
} from "lucide-react";
import type { SessionUser } from "@/lib/auth";
import { MODULES, type ModuleKey } from "@/lib/constants";
import { cn } from "@/lib/utils";

/* ─────────── منو: بازسازی درخت منوی CRMIdeal (ریل آیکونی + زیرمنو) ─────────── */

type RailChild = {
  key: string;
  title: string;
  href?: string;
  module?: ModuleKey; // کنترل دسترسی
  soon?: boolean; // مثل کلاس IsDisabled در محصول اصلی
};

type RailRoot = {
  key: string;
  title: string;
  icon: React.ComponentType<{ className?: string; strokeWidth?: number }>;
  href?: string; // بدون زیرمنو → لینک مستقیم
  module?: ModuleKey;
  children?: RailChild[];
  dividerAfter?: boolean;
};

const RAIL_MENU: RailRoot[] = [
  {
    key: "mnuHome",
    title: "خانه",
    icon: Home,
    href: "/dashboard",
    module: "dashboard",
    dividerAfter: true,
  },
  {
    key: "mnuCompany",
    title: "مشتریان",
    icon: Users,
    children: [
      { key: "mnuCmpList", title: "شرکت‌ها", href: "/companies", module: "companies" },
      { key: "mnuPrsList", title: "افراد و مخاطبین", href: "/contacts", module: "contacts" },
      { key: "mnuCustomerDb", title: "بانک اطلاعاتی مشتریان", soon: true },
    ],
  },
  {
    key: "mnuSales",
    title: "فروش",
    icon: ShoppingCart,
    children: [
      { key: "mnuPrj", title: "فرصت‌های فروش", href: "/deals", module: "deals" },
      { key: "mnuPreOrder", title: "پیش‌فاکتورها", href: "/quotations", module: "quotations" },
      { key: "mnuOrder", title: "فاکتورهای فروش", href: "/orders", module: "orders" },
    ],
    dividerAfter: true,
  },
  {
    key: "mnuBuySellWh",
    title: "انبار و خرید",
    icon: Warehouse,
    children: [
      { key: "mnuProducts", title: "محصولات", href: "/products", module: "products" },
      { key: "mnuWareHouse", title: "انبارها", href: "/warehouses", module: "warehouses" },
      { key: "mnuInventory", title: "موجودی و گردش کالا", href: "/inventory", module: "inventory" },
      { key: "mnuBuyOrder", title: "سفارشات خرید", href: "/purchases", module: "purchases" },
    ],
  },
  {
    key: "mnuFundBank",
    title: "خزانه و بانک",
    icon: Wallet,
    children: [
      { key: "mnuFund", title: "خزانه (رسید/پرداخت)", href: "/fund", module: "fund" },
      { key: "mnuBanking", title: "بانک‌ها و حساب‌ها", href: "/banking", module: "banking" },
      { key: "mnuOnlinePay", title: "پرداخت آنلاین", href: "/settings/payments", module: "payments" },
    ],
    dividerAfter: true,
  },
  {
    key: "mnuSmartCommunication",
    title: "ارتباطات",
    icon: MessageSquare,
    children: [
      { key: "mnuSms", title: "پیامک", soon: true },
      { key: "mnuEmails", title: "ایمیل", soon: true },
      { key: "mnuLetters", title: "مکاتبات", soon: true },
    ],
  },
  {
    key: "mnuCartables",
    title: "کارتابل",
    icon: ClipboardList,
    children: [
      { key: "mnuInternalTask", title: "کارتابل وظایف", href: "/tasks", module: "tasks" },
      { key: "mnuActivities", title: "فعالیت‌ها", href: "/activities", module: "activities" },
    ],
  },
  {
    key: "mnuReports",
    title: "گزارش‌ها",
    icon: BarChart3,
    href: "/reports",
    module: "reports",
    dividerAfter: true,
  },
  {
    key: "mnuSettings",
    title: "مدیریت و تنظیمات",
    icon: Settings,
    children: [
      { key: "mnuUsers", title: "کاربران", href: "/settings/users", module: "users" },
      { key: "mnuSecurity", title: "نقش‌ها و دسترسی‌ها", href: "/settings/roles", module: "roles" },
      { key: "mnuSysSetting", title: "تنظیمات سامانه", href: "/settings", module: "settings" },
    ],
  },
];

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

  // حالت ریل: باز/بسته + ایندکس ریشه انتخاب‌شده (رفتار ShowSideBarSubMenu)
  const [railOpen, setRailOpen] = useState(false);
  const [openRoot, setOpenRoot] = useState<string | null>(null);
  const [profileOpen, setProfileOpen] = useState(false);
  const [loggingOut, setLoggingOut] = useState(false);
  const [searchQ, setSearchQ] = useState("");

  const railWidth = railOpen ? 260 : 80;

  function toggleRoot(key: string) {
    // مثل ShowSideBarMenuIcons: کلیک روی ریشه → ریل باز + زیرمنوی همان ریشه
    if (openRoot === key && railOpen) {
      setRailOpen(false);
      setOpenRoot(null);
    } else {
      setRailOpen(true);
      setOpenRoot(key);
    }
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
      {/* ═══════════ هدر اصلی (page-main-header) ═══════════ */}
      <header
        className="fixed top-0 right-0 left-0 z-[500] bg-white h-[110px] flex items-center transition-[padding] duration-300"
        style={{
          boxShadow: "0 3px 7px #ddf0f9",
          paddingRight: railWidth,
        }}
      >
        <div className="flex items-center w-full h-full px-4 lg:px-8 gap-4">
          {/* ── جستجوی اصلی (bxh-Search → pill) ── */}
          <div className="flex-1 flex justify-center min-w-0">
            <div className="crm-pill w-full max-w-2xl flex items-center gap-1 bg-white px-4 py-1.5">
              <Search className="w-[22px] h-[22px] shrink-0" style={{ color: "#48659c" }} strokeWidth={1} />
              <input
                value={searchQ}
                onChange={(e) => setSearchQ(e.target.value)}
                className="flex-1 min-w-0 bg-transparent outline-none border-0 text-[16px] font-light placeholder:text-[#9aa8c4]"
                placeholder="جستجو..."
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
                className="hidden md:flex items-center gap-1.5 rounded-full px-4 py-2 text-[14px] whitespace-nowrap"
                style={{ backgroundColor: "#dae6fe", color: "#8596bd" }}
              >
                <SlidersHorizontal className="w-4 h-4" />
                <span>شرایط جستجو</span>
              </button>
            </div>
          </div>

          {/* ── بخش کاربر (bxh-User → pill) ── */}
          <div className="crm-pill hidden lg:flex items-center gap-1 bg-white pl-3 pr-4 py-1.5 shrink-0">
            {/* زبان (fa-globe #012875) */}
            <button
              type="button"
              className="w-8 flex flex-col items-center justify-center rounded-full py-1 transition-colors hover:bg-[#ddf0f9]"
              style={{ color: "#012875" }}
              title="فارسی"
            >
              <Globe className="w-[21px] h-[21px]" strokeWidth={1.5} />
              <span className="text-[10px] font-medium leading-3 mt-0.5">FA</span>
            </button>

            <span className="h-8 w-px" style={{ backgroundColor: "#a3b2cc" }} />

            {/* ایمیل (#fdcc3b) */}
            <button
              type="button"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="ایمیل"
            >
              <Mail className="w-[26px] h-[26px]" style={{ color: "#fdcc3b" }} strokeWidth={1.5} />
            </button>

            {/* پیامک (#fdcc3b در آیکون اصلی) */}
            <button
              type="button"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="پیامک"
            >
              <MessageCircle className="w-[26px] h-[26px]" style={{ color: "#fdcc3b" }} strokeWidth={1.5} />
            </button>

            <span className="h-8 w-px" style={{ backgroundColor: "#a3b2cc" }} />

            {/* زنگ پیام‌ها (#df63a0) */}
            <Link
              href="/tasks"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="پیام‌های خوانده‌نشده"
            >
              <Bell className="w-[26px] h-[26px]" style={{ color: "#df63a0" }} strokeWidth={1.5} />
            </Link>

            {/* زنگ یادآورها (#29b2c2) */}
            <Link
              href="/tasks"
              className="relative w-8 h-9 flex items-center justify-center rounded-full transition-colors hover:bg-[#ddf0f9]"
              title="یادآورها و تاییدها"
            >
              <BellRing className="w-[26px] h-[26px]" style={{ color: "#29b2c2" }} strokeWidth={1.5} />
            </Link>

            {/* پروفایل (ai-item → userProfiler) */}
            <div className="relative">
              <button
                type="button"
                onClick={() => setProfileOpen((v) => !v)}
                className="flex items-center gap-2 rounded-full py-1 px-1.5 transition-colors hover:bg-[#ddf0f9]"
              >
                <span className="hidden xl:flex flex-col items-start leading-tight">
                  <span className="text-[14px] font-semibold text-[#575757] max-w-[90px] truncate">
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

              {/* profile-dropdown: 195px، سفید، گوشه 7px، سایه #cacaca */
              profileOpen ? (
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
              { }
              <img src="/images/logo/rasta-mark-navy.svg" alt="رستا" className="w-[46px] h-[46px]" />
            </span>
          </div>
        </div>
      </header>

      {/* ═══════════ ریل منو (s-m-t) — سرمه‌ای تمام‌قد ═══════════ */}
      <aside
        className={cn(
          "crm-rail fixed top-0 bottom-0 right-0 z-[503] flex flex-col text-white transition-[width] duration-300 overflow-hidden",
          railOpen ? "shadow-[_-4px_0_14px_rgba(1,40,117,0.35)]" : ""
        )}
        style={{ width: railWidth }}
      >
        {/* لوگو (s-m-app-icon): بسته 75px / باز 104px */}
        <div className="pt-4 pb-3 flex flex-col items-center shrink-0" style={{ marginBottom: railOpen ? 24 : 40 }}>
          <Link href="/dashboard" className="flex flex-col items-center">
            {railOpen ? (
               
              <img src="/images/logo/rasta-logo-text-white.svg" alt="رستا" className="h-[104px] w-auto" />
            ) : (
               
              <img src="/images/logo/rasta-mark-white.svg" alt="رستا" className="w-[75px] h-[75px]" />
            )}
          </Link>
        </div>

        {/* آیتم‌های منو (s-m-t-content) */}
        <nav className="flex-1 overflow-y-auto crm-scroll px-1.5 pb-4">
          {RAIL_MENU.map((root) => {
            const visible =
              root.href ? can(root.module) : (root.children ?? []).some((c) => !c.soon && can(c.module));
            if (!visible) return null;

            const rootActive = root.href ? pathname.startsWith(root.href) : false;
            const isOpen = openRoot === root.key && railOpen;

            return (
              <div key={root.key}>
                <div
                  className={cn("crm-rail-node", isOpen && "Selected")}
                  title={!railOpen ? root.title : undefined}
                >
                  {/* سربرگ ریشه (s-b-head): آیکون + عنوان (hidable) */}
                  {root.href ? (
                    <Link
                      href={root.href}
                      onClick={() => {
                        setRailOpen(false);
                        setOpenRoot(null);
                      }}
                      className="flex items-center gap-0 px-2 py-2.5"
                    >
                      <root.icon className="w-[30px] h-[30px] crm-rail-icon shrink-0" strokeWidth={1.3} />
                      <span className="crm-rail-item-title px-2.5 truncate" style={{ display: railOpen ? "block" : "none" }}>
                        {root.title}
                      </span>
                    </Link>
                  ) : (
                    <button
                      type="button"
                      onClick={() => toggleRoot(root.key)}
                      className="w-full flex items-center gap-0 px-2 py-2.5"
                    >
                      <root.icon className="w-[30px] h-[30px] crm-rail-icon shrink-0" strokeWidth={1.3} />
                      <span
                        className="crm-rail-item-title px-2.5 truncate flex-1 text-right"
                        style={{ display: railOpen ? "block" : "none" }}
                      >
                        {root.title}
                      </span>
                      {/* فلش باز/بسته (fa-caret) */}
                      {railOpen ? (
                        <ChevronLeft
                          className={cn(
                            "w-4 h-4 crm-rail-icon transition-transform duration-300",
                            isOpen ? "-rotate-90" : "rotate-0"
                          )}
                          strokeWidth={2}
                        />
                      ) : null}
                    </button>
                  )}
                </div>

                {/* زیرمنو (child-node): margin-right 25px مثل محصول اصلی */}
                {root.children && railOpen ? (
                  <div
                    className={cn(
                      "transition-all duration-300 overflow-hidden",
                      isOpen ? "max-h-[600px] opacity-100" : "max-h-0 opacity-0"
                    )}
                  >
                    <div className="mr-[25px] pr-2.5 pl-1.5 py-1">
                      {root.children.map((child) => {
                        if (child.soon) {
                          return (
                            <div
                              key={child.key}
                              className="flex items-center gap-2 px-2 py-1.5 opacity-40 cursor-not-allowed"
                              title="در نسخه‌های بعدی رستا"
                            >
                              <span className="w-1.5 h-1.5 rounded-full bg-[#8e8ddb] shrink-0" />
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
                            onClick={() => {
                              setRailOpen(false);
                              setOpenRoot(null);
                            }}
                            className={cn(
                              "crm-rail-node flex items-center gap-2 px-2 py-1.5",
                              active && "Selected"
                            )}
                          >
                            <span className="w-1.5 h-1.5 rounded-full bg-[#8e8ddb] shrink-0" />
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

          {/* خروج — ته ریل */}
          <div className="crm-rail-divider" />
          <div className="crm-rail-node" title={!railOpen ? "خروج" : undefined}>
            <button
              type="button"
              onClick={logout}
              disabled={loggingOut}
              className="w-full flex items-center gap-0 px-2 py-2.5"
            >
              <Power className="w-[30px] h-[30px] crm-rail-icon shrink-0" strokeWidth={1.3} />
              <span className="crm-rail-item-title px-2.5" style={{ display: railOpen ? "block" : "none" }}>
                {loggingOut ? "در حال خروج…" : "خروج"}
              </span>
            </button>
          </div>
        </nav>

        {/* نسخه (lblVer): پایین ریل در حالت باز */}
        <div
          className="text-white/50 text-[10px] text-center pb-2 shrink-0"
          dir="ltr"
          style={{ display: railOpen ? "block" : "none" }}
        >
          Rasta 0.2.0
        </div>
      </aside>

      {/* ═══════════ بدنه صفحه (page-body) ═══════════ */}
      <main
        className="min-h-screen bg-white transition-[padding] duration-300"
        style={{ paddingTop: 110, paddingRight: railWidth }}
      >
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
   بازسازی ۸ قرص StyHomePage.css: bg #e7effc، radius 50px،
   padding 12px 20px، فونت ravi-regular 17px، فلش #50a5d2 */

export const QUICK_ACCESS = [
  { href: "/tasks", icon: CalendarDays, label: "تقویم کاری" },
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
    <div className="relative z-[200] max-w-[600px] mx-auto mt-[70px] lg:mt-[90px]">
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
  LayoutDashboard: Home,
  Building2,
  Users,
  Target,
  PhoneCall,
  ClipboardList,
  Package,
  FileText,
  ReceiptText,
  BarChart3,
  UserCog,
  ShieldCheck,
  Settings,
  Wallet,
  Landmark,
  CreditCard,
};
