import { cn } from "@/lib/utils";

const STYLES: Record<string, string> = {
  // generic statuses
  ACTIVE: "bg-emerald-100 text-emerald-800",
  INACTIVE: "bg-slate-100 text-slate-600",
  OPEN: "bg-sky-100 text-sky-800",
  DONE: "bg-emerald-100 text-emerald-800",
  CANCELED: "bg-slate-100 text-slate-500",
  // deals
  NEW: "bg-sky-100 text-sky-800",
  CONTACTED: "bg-cyan-100 text-cyan-800",
  PROPOSAL: "bg-amber-100 text-amber-800",
  NEGOTIATION: "bg-orange-100 text-orange-800",
  WON: "bg-emerald-100 text-emerald-800",
  LOST: "bg-rose-100 text-rose-800",
  // quotations
  DRAFT: "bg-slate-100 text-slate-700",
  SENT: "bg-sky-100 text-sky-800",
  ACCEPTED: "bg-emerald-100 text-emerald-800",
  REJECTED: "bg-rose-100 text-rose-800",
  EXPIRED: "bg-zinc-100 text-zinc-500",
  CONVERTED: "bg-teal-100 text-teal-800",
  ISSUED: "bg-sky-100 text-sky-800",
  PAID: "bg-emerald-100 text-emerald-800",
  // priorities
  LOW: "bg-slate-100 text-slate-600",
  NORMAL: "bg-sky-50 text-sky-700",
  HIGH: "bg-amber-100 text-amber-800",
  URGENT: "bg-rose-100 text-rose-800",
  // company types
  CUSTOMER: "bg-emerald-100 text-emerald-800",
  PROSPECT: "bg-amber-100 text-amber-800",
  PARTNER: "bg-violet-100 text-violet-800",
  SUPPLIER: "bg-cyan-100 text-cyan-800",
  OTHER: "bg-slate-100 text-slate-600",
  // purchase orders
  ORDERED: "bg-indigo-100 text-indigo-800",
  RECEIVED: "bg-emerald-100 text-emerald-800",
  // stock movements
  IN: "bg-emerald-100 text-emerald-800",
  OUT: "bg-rose-100 text-rose-800",
  TRANSFER: "bg-violet-100 text-violet-800",
  ADJUST: "bg-amber-100 text-amber-800",
};

export function StatusBadge({ value, label }: { value: string; label: string }) {
  const style = STYLES[value] ?? "bg-slate-100 text-slate-600";
  return (
    <span
      className={cn(
        "inline-flex items-center rounded-full px-2.5 py-0.5 text-[11px] font-bold whitespace-nowrap",
        style
      )}
    >
      {label}
    </span>
  );
}
