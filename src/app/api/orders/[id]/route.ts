import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";
import { PAYMENT_METHODS } from "@/lib/constants";
import { issueStockForOrder, reverseMovementsTx } from "@/lib/stock";

export async function GET(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("orders", "view");
    const { id } = await params;
    const order = await db.salesOrder.findUnique({
      where: { id },
      include: {
        company: { select: { id: true, name: true, address: true, phone: true, taxId: true } },
        owner: { select: { firstName: true, lastName: true } },
        quotation: { select: { id: true, number: true } },
        items: { include: { product: { select: { name: true, unit: true } } } },
        payments: true,
      },
    });
    if (!order) return apiError("فاکتور یافت نشد.", 404);
    return json(order);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("orders", "delete");
    const { id } = await params;
    const order = await db.salesOrder.findUnique({ where: { id } });
    if (!order) return apiError("فاکتور یافت نشد.", 404);
    if (order.paidTotal > 0) {
      return apiError("برای این فاکتور پرداخت ثبت شده است. ابتدا پرداخت‌ها را حذف کنید.", 409);
    }
    await db.salesOrder.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "order",
        entityId: id,
      },
    });
    return json({ ok: true });
  });
}

/** PATCH — add payment / set status / cancel */
export async function PATCH(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("orders", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const action = String(body?.action ?? "");
    const order = await db.salesOrder.findUnique({ where: { id } });
    if (!order) return apiError("فاکتور یافت نشد.", 404);

    if (action === "addPayment") {
      const amount = Number(body?.amount);
      if (!amount || amount <= 0) return apiError("مبلغ پرداخت نامعتبر است.", 400);
      const method = PAYMENT_METHODS.includes(body?.method) ? body.method : "CASH";
      const paidAt = body?.paidAt ? new Date(String(body.paidAt)) : new Date();
      if (isNaN(paidAt.getTime())) return apiError("تاریخ پرداخت نامعتبر است.", 400);

      const payment = await db.payment.create({
        data: { orderId: id, amount, method, paidAt, note: clean(body?.note) },
      });

      const paidTotal = order.paidTotal + amount;
      await db.salesOrder.update({
        where: { id },
        data: {
          paidTotal,
          status: paidTotal >= order.total - 0.01 && order.status !== "DRAFT" ? "PAID" : order.status,
        },
      });

      return json(payment, 201);
    }

    if (action === "setStatus") {
      const status = String(body?.status ?? "");
      if (!["DRAFT", "ISSUED", "PAID", "CANCELED"].includes(status)) {
        return apiError("وضعیت نامعتبر است.", 400);
      }
      if (order.paidTotal > 0 && status === "CANCELED") {
        return apiError("فاکتور دارای پرداخت قابل لغو نیست.", 409);
      }

      // ── Phase 2: warehouse integration ──
      // Issuing a sales order reserves/deducts stock (OUT movements from the
      // default warehouse); canceling an issued order returns goods to stock.
      if (status === "ISSUED" && order.status !== "ISSUED") {
        await issueStockForOrder(id, user.id);
      }
      if (status === "CANCELED" && order.status === "ISSUED") {
        await db.$transaction(async (tx) => {
          await reverseMovementsTx(tx, { refType: "SALES_ORDER", refId: id });
        });
      }

      const updated = await db.salesOrder.update({ where: { id }, data: { status } });
      return json(updated);
    }

    if (action === "deletePayment") {
      const paymentId = String(body?.paymentId ?? "");
      const payment = await db.payment.findUnique({ where: { id: paymentId } });
      if (!payment || payment.orderId !== id) return apiError("پرداخت یافت نشد.", 404);
      await db.payment.delete({ where: { id: paymentId } });
      const paidTotal = Math.max(0, order.paidTotal - payment.amount);
      const updated = await db.salesOrder.update({
        where: { id },
        data: {
          paidTotal,
          status: paidTotal >= order.total - 0.01 ? "PAID" : paidTotal > 0 ? "ISSUED" : order.status === "PAID" ? "ISSUED" : order.status,
        },
      });
      return json(updated);
    }

    return apiError("عملیات نامعتبر است.", 400);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
