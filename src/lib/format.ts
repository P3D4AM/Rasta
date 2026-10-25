// Rasta CRM — client-side formatting helpers (money, dates via jalali utils).

import { toPersianDigits, formatJalali, formatJalaliDateTime } from "@/lib/jalali";

export function formatMoney(amount: number | null | undefined, persian = true): string {
  if (amount == null) return "—";
  const s = Math.round(amount).toLocaleString("en-US");
  return persian ? toPersianDigits(s) : s;
}

export function formatDate(d: string | Date | null | undefined): string {
  return formatJalali(d as never);
}

export function formatDateTime(d: string | Date | null | undefined): string {
  return formatJalaliDateTime(d as never);
}

export function fullName(first?: string | null, last?: string | null): string {
  return `${first ?? ""} ${last ?? ""}`.trim() || "—";
}
