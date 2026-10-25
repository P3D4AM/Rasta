import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";
import { getDefaultWarehouseId, applyMovementTx } from "@/lib/stock";
import { computeTotals, clean, dateOr, dateOrNull } from "@/lib/purchase";

// GET /api/purchases/[id] — full detail
export async function GET(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("purchases", "view");
    const { id } = await params;
    const order = await db.purchaseOrder.findUnique({
      where: { id },
      include: {
        supplier: { select: { id: true, name: true } },
        warehouse: { select: { id: true, name: true } },
        owner: { select: { firstName: true, lastName: true } },
        items: { include: { product: { select: { id: true, name: true, unit: true } } } },
      },
    });
    if (!order) return apiError("سفارش خرید یافت نشد.", 404);
    return json(order);
  });
}

// PUT /api/purchases/[id] — edit (DRAFT only)
export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("purchases", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);

    const existing = await db.purchaseOrder.findUnique({ where: { id } });
    if (!existing) return apiError("سفارش خرید یافت نشد.", 404);
    if (existing.status !== "DRAFT") {
      return apiError("فقط سفارش‌های در وضعیت پیش‌نویس قابل ویرایش هستند.", 409);
    }

    const supplierId = String(body?.supplierId ?? existing.supplierId);
    const supplier = await db.company.findUnique({ where: { id: supplierId } });
    if (!supplier) return apiError("شرکت تأمین‌کننده یافت نشد.", 404);

    const warehouseId = body?.warehouseId ? String(body.warehouseId) : null;

    const rawItems = Array.isArray(body?.items) ? body.items : [];
    const valid = rawItems.filter(
      (it: { productId?: string; description?: string }) =>
        it.productId || String(it.description ?? "").trim()
    );
    if (valid.length === 0) return apiError("حداقل یک ردیف کالا وارد کنید.", 400);

    const { rows, subtotal, taxTotal, total } = computeTotals(valid);

    const updated = await db.$transaction(async (tx) => {
      await tx.purchaseOrderItem.deleteMany({ where: { purchaseOrderId: id } });
      return tx.purchaseOrder.update({
        where: { id },
        data: {
          supplierId,
          warehouseId,
          issueDate: body?.issueDate ? dateOr(body.issueDate, existing.issueDate) : existing.issueDate,
          expectedAt: body?.expectedAt !== undefined ? dateOrNull(body.expectedAt) : existing.expectedAt,
          note: clean(body?.note),
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
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "purchaseOrder",
        entityId: id,
        meta: `سفارش خرید ${existing.number}`,
      },
    });
    return json(updated);
  });
}

// DELETE /api/purchases/[id] — DRAFT/CANCELED only
export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("purchases", "delete");
    const { id } = await params;
    const existing = await db.purchaseOrder.findUnique({ where: { id } });
    if (!existing) return apiError("سفارش خرید یافت نشد.", 404);
    if (!["DRAFT", "CANCELED"].includes(existing.status)) {
      return apiError("سفارش‌های ارسال‌شده یا تحویل‌شده قابل حذف نیستند.", 409);
    }
    await db.purchaseOrder.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "purchaseOrder",
        entityId: id,
        meta: `سفارش خرید ${existing.number}`,
      },
    });
    return json({ ok: true });
  });
}

// PATCH /api/purchases/[id] — actions: setStatus | receive
export async function PATCH(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("purchases", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const action = String(body?.action ?? "");
    const order = await db.purchaseOrder.findUnique({
      where: { id },
      include: { items: true },
    });
    if (!order) return apiError("سفارش خرید یافت نشد.", 404);

    if (action === "setStatus") {
      const status = String(body?.status ?? "");
      if (!["DRAFT", "ORDERED", "RECEIVED", "CANCELED"].includes(status)) {
        return apiError("وضعیت نامعتبر است.", 400);
      }
      if (status === "RECEIVED") {
        return apiError("برای تحویل از عملیات «دریافت کالا» استفاده کنید.", 400);
      }
      if (order.status === "RECEIVED") {
        return apiError("سفارش تحویل‌شده قابل تغییر نیست.", 409);
      }
      if (status === "ORDERED" && order.status !== "DRAFT") {
        return apiError("فقط پیش‌نویس می‌تواند به سفارش تبدیل شود.", 409);
      }
      const updated = await db.purchaseOrder.update({ where: { id }, data: { status } });
      return json(updated);
    }

    if (action === "receive") {
      if (order.status === "RECEIVED") {
        return apiError("این سفارش قبلاً تحویل شده است.", 409);
      }
      if (order.status === "CANCELED") {
        return apiError("سفارش لغوشده قابل تحویل نیست.", 409);
      }
      const warehouseId = order.warehouseId ?? (await getDefaultWarehouseId());
      if (!warehouseId) {
        return apiError(
          "انباری برای ورود کالا تعیین نشده است. ابتدا انبار تعریف کنید یا انبار پیش‌فرض بسازید.",
          409
        );
      }

      const updated = await db.$transaction(async (tx) => {
        for (const it of order.items) {
          if (!it.productId) continue;
          await applyMovementTx(tx, {
            type: "IN",
            productId: it.productId,
            toWarehouseId: warehouseId,
            quantity: it.qty,
            unitCost: it.unitPrice,
            refType: "PURCHASE_ORDER",
            refId: order.id,
            note: `رسید خرید سفارش شماره ${order.number}`,
            userId: user.id,
          });
        }
        return tx.purchaseOrder.update({
          where: { id },
          data: { status: "RECEIVED", receivedAt: new Date(), warehouseId },
          include: {
            supplier: { select: { id: true, name: true } },
            warehouse: { select: { id: true, name: true } },
            items: { include: { product: { select: { name: true, unit: true } } } },
          },
        });
      });

      await db.activityLog.create({
        data: {
          userId: user.id,
          userName: `${user.firstName} ${user.lastName}`,
          action: "receive",
          entity: "purchaseOrder",
          entityId: id,
          meta: `دریافت کالا سفارش ${order.number}`,
        },
      });
      return json(updated);
    }

    return apiError("عملیات نامعتبر است.", 400);
  });
}
