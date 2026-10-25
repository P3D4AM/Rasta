import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, nextDocNumber } from "@/lib/http";
import { calcTotals, type ItemInput } from "../route";
import { QUOTATION_STATUSES } from "@/lib/constants";

export async function GET(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("quotations", "view");
    const { id } = await params;
    const quotation = await db.quotation.findUnique({
      where: { id },
      include: {
        company: { select: { id: true, name: true, address: true, phone: true } },
        contact: true,
        deal: { select: { id: true, title: true } },
        owner: { select: { firstName: true, lastName: true } },
        items: { include: { product: { select: { name: true, unit: true } } } },
        orders: { select: { id: true, number: true, status: true } },
      },
    });
    if (!quotation) return apiError("پیش‌فاکتور یافت نشد.", 404);
    return json(quotation);
  });
}

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("quotations", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.quotation.findUnique({ where: { id } });
    if (!existing) return apiError("پیش‌فاکتور یافت نشد.", 404);
    if (existing.status === "CONVERTED") {
      return apiError("این پیش‌فاکتور به فاکتور تبدیل شده و قابل ویرایش نیست.", 409);
    }

    const items: ItemInput[] = Array.isArray(body?.items) ? body.items : [];
    if (items.length === 0) return apiError("حداقل یک ردیف کالا وارد کنید.", 400);
    const totals = calcTotals(items);

    const quotation = await db.quotation.update({
      where: { id },
      data: {
        companyId: clean(body?.companyId) ?? existing.companyId,
        contactId: clean(body?.contactId),
        dealId: clean(body?.dealId),
        issueDate: dateOr(body?.issueDate, existing.issueDate),
        validUntil: dateOrNull(body?.validUntil),
        status: clean(body?.status) ?? existing.status,
        note: clean(body?.note),
        subtotal: totals.subtotal,
        discountTotal: totals.discountTotal,
        taxTotal: totals.taxTotal,
        total: totals.total,
        items: {
          deleteMany: {},
          create: totals.items,
        },
      },
      include: { company: { select: { id: true, name: true } } },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "quotation",
        entityId: id,
      },
    });
    return json(quotation);
  });
}

/** PATCH — status change or convert to SalesOrder. */
export async function PATCH(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("quotations", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const action = String(body?.action ?? "");

    const quotation = await db.quotation.findUnique({
      where: { id },
      include: { items: true },
    });
    if (!quotation) return apiError("پیش‌فاکتور یافت نشد.", 404);

    if (action === "setStatus") {
      const status = String(body?.status ?? "");
      if (!QUOTATION_STATUSES.includes(status as never)) {
        return apiError("وضعیت نامعتبر است.", 400);
      }
      const updated = await db.quotation.update({ where: { id }, data: { status } });
      return json(updated);
    }

    if (action === "convert") {
      if (quotation.status === "CONVERTED") {
        return apiError("این پیش‌فاکتور قبلاً تبدیل شده است.", 409);
      }
      const number = await nextDocNumber("salesOrder");

      const order = await db.salesOrder.create({
        data: {
          number,
          quotationId: quotation.id,
          companyId: quotation.companyId,
          issueDate: new Date(),
          status: "ISSUED",
          note: quotation.note,
          ownerId: user.id,
          subtotal: quotation.subtotal,
          discountTotal: quotation.discountTotal,
          taxTotal: quotation.taxTotal,
          total: quotation.total,
          items: {
            create: quotation.items.map((it) => ({
              productId: it.productId,
              description: it.description,
              qty: it.qty,
              unitPrice: it.unitPrice,
              discount: it.discount,
              taxRate: it.taxRate,
              lineTotal: it.lineTotal,
            })),
          },
        },
      });

      await db.quotation.update({ where: { id }, data: { status: "CONVERTED" } });

      // If linked to a deal, move deal to WON when it makes sense
      if (quotation.dealId) {
        await db.deal.updateMany({
          where: { id: quotation.dealId, stage: { in: ["NEW", "CONTACTED", "PROPOSAL", "NEGOTIATION"] } },
          data: { stage: "WON", closedAt: new Date(), probability: 100 },
        });
      }

      await db.activityLog.create({
        data: {
          userId: user.id,
          userName: `${user.firstName} ${user.lastName}`,
          action: "convert-to-order",
          entity: "quotation",
          entityId: id,
          meta: `فاکتور شماره ${number}`,
        },
      });
      return json(order, 201);
    }

    return apiError("عملیات نامعتبر است.", 400);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("quotations", "delete");
    const { id } = await params;
    const quotation = await db.quotation.findUnique({
      where: { id },
      include: { _count: { select: { orders: true } } },
    });
    if (!quotation) return apiError("پیش‌فاکتور یافت نشد.", 404);
    if (quotation._count.orders > 0) {
      return apiError("این پیش‌فاکتور به فاکتور تبدیل شده و قابل حذف نیست.", 409);
    }
    await db.quotation.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "quotation",
        entityId: id,
      },
    });
    return json({ ok: true });
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
  return dateOrNull(v) ?? fallback;
}
