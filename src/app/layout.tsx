import type { Metadata } from "next";
import "./globals.css";
import { Toaster } from "@/components/ui/toaster";

export const metadata: Metadata = {
  title: {
    default: "رستا | سامانه مدیریت ارتباط با مشتری",
    template: "%s | رستا",
  },
  description:
    "رستا — نرم‌افزار تحت وب مدیریت ارتباط با مشتری، فروش و کارتابل سازمانی",
  keywords: ["رستا", "Rasta", "CRM", "مدیریت ارتباط با مشتری", "فروش", "کارتابل"],
  icons: {
    icon: "/favicon.svg",
  },
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="fa" dir="rtl" suppressHydrationWarning>
      <body className="antialiased bg-background text-foreground min-h-screen">
        {children}
        <Toaster />
      </body>
    </html>
  );
}
