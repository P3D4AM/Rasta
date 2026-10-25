import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery, nextDocNumber } from "@/lib/http";
import { Prisma } from "@prisma/client";

export type ItemInput = {
  productId?: string | null;
  description?: string | null;
  qty?: number | string;
  unitPrice?: number | string;
  discount?: number | string;
  taxRate?: number | string;
};

/** Shared line-item recalculation (single source of truth for totals). */
export function calcTotals(items: ItemInput[]) {
  let subtotal = 0;
  let discountTotal = 0;
  let taxTotal = 0;
  const prepared = items
    .filter((it) => (it.productId ?? it.description ?? "").toString().trim() !== "")
    .map((it) => {
      const qty = Math.max(0, Number(it.qty) || 0);
      const unitPrice = Math.max(0, Number(it.unitPrice) || 0);
      const discount = Math.min(qty * unitPrice, Math.max(0, Number(it.discount) || 0));
      const taxRate = Math.max(0, Number(it.taxRate) || 0);
      const gross = qty * unitPrice;
      const net = gross - discount;
      const tax = (net * taxRate) / 100;
      subtotal += gross;
      discountTotal += discount;
      taxTotal += tax;
      return {
        productId: it.productId || null,
        description: it.description?.trim() || null,
        qty,
        unitPrice,
        discount,
        taxRate,
        lineTotal: net + tax,
      };
    });
  return {
    items: prepared,
    subtotal: round(subtotal),
    discountTotal: round(discountTotal),
    taxTotal: round(taxTotal),
    total: round(subtotal - discountTotal + taxTotal),
  };
}

function round(n: number): number {
  return Math.round(n * 100) / 100;
}

// GET /api/quotations
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("quotations", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const status = url.searchParams.get("status");
    const companyId = url.searchParams.get("companyId");

    const where: Prisma.QuotationWhereInput = {
      ...(status && status !== "ALL" ? { status } : {}),
      ...(companyId ? { companyId } : {}),
      ...(search ? { company: { is: { name: { contains: search } } } } : {}),
    };

    const [rows, total] = await Promise.all([
      db.quotation.findMany({
        where,
        orderBy: { createdAt: "desc" },
        skip,
        take,
        include: {
          company: { select: { id: true, name: true } },
          deal: { select: { id: true, title: true } },
          owner: { select: { firstName: true, lastName: true } },
          _count: { select: { items: true } },
        },
      }),
      db.quotation.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/quotations — create with items
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("quotations", "create");
    const body = await req.json().catch(() => null);
    const companyId = String(body?.companyId ?? "");
    if (!companyId) return apiError("انتخاب شرکت الزامی است.", 400);

    const company = await db.company.findUnique({ where: { id: companyId } });
    if (!company) return apiError("شرکت یافت نشد.", 404);

    const items: ItemInput[] = Array.isArray(body?.items) ? body.items : [];
    if (items.length === 0) return apiError("حداقل یک ردیف کالا وارد کنید.", 400);

    const totals = calcTotals(items);
    const number = await nextDocNumber("quotation");

    const quotation = await db.quotation.create({
      data: {
        number,
        companyId,
        contactId: clean(body?.contactId),
        dealId: clean(body?.dealId),
        issueDate: dateOr(body?.issueDate, new Date()),
        validUntil: dateOrNull(body?.validUntil),
        status: clean(body?.status) ?? "DRAFT",
        note: clean(body?.note),
        ownerId: user.id,
        subtotal: totals.subtotal,
        discountTotal: totals.discountTotal,
        taxTotal: totals.taxTotal,
        total: totals.total,
        items: { create: totals.items },
      },
      include: {
        company: { select: { id: true, name: true } },
        items: { include: { product: { select: { name: true, unit: true } } } },
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "quotation",
        entityId: quotation.id,
        meta: `پیش‌فاکتور شماره ${number}`,
      },
    });
    return json(quotation, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
function dateOrNull(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(String(v));
  return isNaN(d.getTime()) ? null : d;
}
function dateOr(v: unknown, fallback: Date): Date {
  const d = dateOrNull(v);
  return d ?? fallback;
}
