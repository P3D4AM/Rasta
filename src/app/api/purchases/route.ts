import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery, nextDocNumber } from "@/lib/http";
import { PURCHASE_STATUSES } from "@/lib/constants";
import { computeTotals, clean, dateOr, dateOrNull, type ItemInput } from "@/lib/purchase";
import type { Prisma } from "@prisma/client";

// GET /api/purchases
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("purchases", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req, 20);
    const url = new URL(req.url);
    const status = (url.searchParams.get("status") ?? "").trim();

    const where: Prisma.PurchaseOrderWhereInput = {
      ...(PURCHASE_STATUSES.includes(status as (typeof PURCHASE_STATUSES)[number]) ? { status } : {}),
      ...(search
        ? {
            OR: [
              { supplier: { name: { contains: search } } },
              { note: { contains: search } },
            ],
          }
        : {}),
    };

    const [rows, total] = await Promise.all([
      db.purchaseOrder.findMany({
        where,
        orderBy: [{ issueDate: "desc" }, { number: "desc" }],
        skip,
        take,
        include: {
          supplier: { select: { id: true, name: true } },
          warehouse: { select: { id: true, name: true } },
          _count: { select: { items: true } },
        },
      }),
      db.purchaseOrder.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/purchases
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("purchases", "create");
    const body = await req.json().catch(() => null);

    const supplierId = String(body?.supplierId ?? "");
    if (!supplierId) return apiError("انتخاب تأمین‌کننده الزامی است.", 400);
    const supplier = await db.company.findUnique({ where: { id: supplierId } });
    if (!supplier) return apiError("شرکت تأمین‌کننده یافت نشد.", 404);

    const warehouseId = body?.warehouseId ? String(body.warehouseId) : null;
    if (warehouseId) {
      const wh = await db.warehouse.findUnique({ where: { id: warehouseId } });
      if (!wh) return apiError("انبار یافت نشد.", 404);
    }

    const rawItems = Array.isArray(body?.items) ? body.items : [];
    const valid = rawItems.filter(
      (it: ItemInput) => it.productId || String(it.description ?? "").trim()
    );
    if (valid.length === 0) return apiError("حداقل یک ردیف کالا وارد کنید.", 400);

    const { rows, subtotal, taxTotal, total } = computeTotals(valid);
    const number = await nextDocNumber("purchaseOrder");

    const order = await db.purchaseOrder.create({
      data: {
        number,
        supplierId,
        warehouseId,
        issueDate: dateOr(body?.issueDate, new Date()),
        expectedAt: dateOrNull(body?.expectedAt),
        note: clean(body?.note),
        ownerId: user.id,
        status: "DRAFT",
        subtotal,
        taxTotal,
        total,
        items: { create: rows },
      },
      include: {
        supplier: { select: { id: true, name: true } },
        warehouse: { select: { id: true, name: true } },
        items: { include: { product: { select: { name: true, unit: true } } } },
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "purchaseOrder",
        entityId: order.id,
        meta: `سفارش خرید ${number} — ${supplier.name}`,
      },
    });
    return json(order, 201);
  });
}
