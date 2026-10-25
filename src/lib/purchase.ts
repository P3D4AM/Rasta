// Rasta CRM — Purchase order shared helpers (Phase 2)

export type ItemInput = {
  productId?: string | null;
  description?: string | null;
  qty?: number | string;
  unitPrice?: number | string;
  taxRate?: number | string;
};

/** Normalize item rows + compute subtotal/tax/total for a purchase order. */
export function computeTotals(items: ItemInput[]) {
  let subtotal = 0;
  let taxTotal = 0;
  const rows = items.map((it) => {
    const qty = Math.max(0, Number(it.qty) || 0);
    const unitPrice = Math.max(0, Number(it.unitPrice) || 0);
    const taxRate = Math.max(0, Number(it.taxRate) || 0);
    const base = qty * unitPrice;
    const tax = (base * taxRate) / 100;
    subtotal += base;
    taxTotal += tax;
    return {
      productId: it.productId || null,
      description: it.description?.toString().trim() || null,
      qty,
      unitPrice,
      taxRate,
      lineTotal: base + tax,
    };
  });
  return { rows, subtotal, taxTotal, total: subtotal + taxTotal };
}

export function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}

export function dateOr(v: unknown, fallback: Date): Date {
  if (!v) return fallback;
  const d = new Date(String(v));
  return isNaN(d.getTime()) ? fallback : d;
}

export function dateOrNull(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(String(v));
  return isNaN(d.getTime()) ? null : d;
}
