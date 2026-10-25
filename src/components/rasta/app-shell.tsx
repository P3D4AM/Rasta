"use client";

import { useState } from "react";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import {
  Building2,
  LayoutDashboard,
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
  LogOut,
} from "lucide-react";
import type { SessionUser } from "@/lib/auth";
import { MODULES, type ModuleKey } from "@/lib/constants";
import {
  SidebarProvider,
  Sidebar,
  SidebarHeader,
  SidebarContent,
  SidebarGroup,
  SidebarGroupLabel,
  SidebarGroupContent,
  SidebarMenu,
  SidebarMenuItem,
  SidebarMenuButton,
  SidebarFooter,
  SidebarTrigger,
  SidebarInset,
} from "@/components/ui/sidebar";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { Avatar, AvatarFallback } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import { cn } from "@/lib/utils";

const ICONS: Record<string, React.ComponentType<{ className?: string }>> = {
  LayoutDashboard,
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
};

const NAV_GROUPS: { label: string; modules: ModuleKey[] }[] = [
  { label: "اصلی", modules: ["dashboard", "tasks", "activities", "deals"] },
  { label: "اطلاعات پایه", modules: ["companies", "contacts", "products"] },
  { label: "فروش", modules: ["quotations", "orders", "reports"] },
  { label: "مدیریت", modules: ["users", "roles"] },
];

export function AppShell({ user, children }: { user: SessionUser; children: React.ReactNode }) {
  const pathname = usePathname();
  const router = useRouter();
  const [loggingOut, setLoggingOut] = useState(false);

  const visibleGroups = NAV_GROUPS.map((g) => ({
    ...g,
    modules: g.modules.filter((m) =>
      user.isAdmin || user.permissions[m]?.canView
    ),
  })).filter((g) => g.modules.length > 0);

  async function logout() {
    setLoggingOut(true);
    await fetch("/api/auth/logout", { method: "POST" });
    router.replace("/login");
    router.refresh();
  }

  const initials = `${user.firstName?.[0] ?? ""}${user.lastName?.[0] ?? ""}`;

  return (
    <SidebarProvider>
      <Sidebar side="right" dir="rtl" variant="inset">
        <SidebarHeader className="p-4 border-b border-sidebar-border/60">
          <Link href="/dashboard" className="flex items-center gap-2.5 group">
            <div className="w-9 h-9 rounded-xl bg-sidebar-primary text-sidebar-primary-foreground flex items-center justify-center font-black text-lg shadow-md group-hover:scale-105 transition-transform">
              ر
            </div>
            <div className="leading-tight">
              <div className="font-extrabold text-sidebar-foreground text-base tracking-tight">
                رستا
              </div>
              <div className="text-[11px] text-sidebar-foreground/60">
                مدیریت ارتباط با مشتری
              </div>
            </div>
          </Link>
        </SidebarHeader>

        <SidebarContent>
          {visibleGroups.map((group) => (
            <SidebarGroup key={group.label}>
              <SidebarGroupLabel>{group.label}</SidebarGroupLabel>
              <SidebarGroupContent>
                <SidebarMenu>
                  {group.modules.map((m) => {
                    const Icon = ICONS[MODULES[m].icon] ?? LayoutDashboard;
                    const href = MODULES[m].href;
                    const active = pathname.startsWith(href);
                    return (
                      <SidebarMenuItem key={m}>
                        <SidebarMenuButton asChild isActive={active}>
                          <Link href={href}>
                            <Icon className="w-4 h-4" />
                            <span>{MODULES[m].label}</span>
                          </Link>
                        </SidebarMenuButton>
                      </SidebarMenuItem>
                    );
                  })}
                </SidebarMenu>
              </SidebarGroupContent>
            </SidebarGroup>
          ))}
        </SidebarContent>

        <SidebarFooter className="p-3 border-t border-sidebar-border/60">
          <div className="flex items-center gap-2 px-2 text-[11px] text-sidebar-foreground/50">
            <span>رستا ۱.۰ — بازطراحی مدرن CRM ایده‌آل</span>
          </div>
        </SidebarFooter>
      </Sidebar>

      <SidebarInset className="min-h-screen flex flex-col">
        <header className="sticky top-0 z-30 flex h-14 items-center gap-3 border-b bg-background/80 backdrop-blur px-4">
          <SidebarTrigger />
          <div className="flex-1" />
          <span className="hidden sm:block text-xs text-muted-foreground">
            {user.roleName ? `نقش: ${user.roleName}` : user.isAdmin ? "مدیر سیستم" : ""}
          </span>
          <DropdownMenu>
            <DropdownMenuTrigger asChild>
              <Button variant="ghost" className="gap-2 h-10 px-2 hover:bg-accent">
                <Avatar className="w-8 h-8">
                  <AvatarFallback className="bg-primary text-primary-foreground text-xs font-bold">
                    {initials || "؟"}
                  </AvatarFallback>
                </Avatar>
                <span className="text-sm font-medium hidden sm:block">
                  {user.firstName} {user.lastName}
                </span>
              </Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent align="end" className="w-52">
              <DropdownMenuLabel className="text-xs text-muted-foreground">
                {user.username}
              </DropdownMenuLabel>
              <DropdownMenuSeparator />
              <DropdownMenuItem onClick={logout} disabled={loggingOut} className="text-destructive focus:text-destructive">
                <LogOut className="w-4 h-4 me-2" />
                {loggingOut ? "در حال خروج…" : "خروج از حساب"}
              </DropdownMenuItem>
            </DropdownMenuContent>
          </DropdownMenu>
        </header>

        <main className="flex-1 p-4 lg:p-6">
          <div className={cn("mx-auto w-full max-w-[1400px]")}>{children}</div>
        </main>

        <footer className="mt-auto border-t bg-muted/40 py-3 px-6">
          <div className="mx-auto max-w-[1400px] flex flex-col sm:flex-row items-center justify-between gap-1 text-[11px] text-muted-foreground">
            <span>سامانه رستا — نسخه ۱.۰</span>
            <span>© ۱۴۰۵ رستا · تمامی حقوق محفوظ است</span>
          </div>
        </footer>
      </SidebarInset>
    </SidebarProvider>
  );
}
