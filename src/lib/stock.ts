// Rasta CRM — Stock engine (Phase 2)
// Transactional stock-level updates shared by manual movements, purchase receipts
// and sales-order issues. Ported in spirit from legacy WareHouseMovement helper.

import { db } from "@/lib/db";
import { HttpError } from "@/lib/http";
import type { Prisma } from "@prisma/client";

export type MovementType = "IN" | "OUT" | "TRANSFER" | "ADJUST";

export type MovementInput = {
  type: MovementType;
  productId: string;
  fromWarehouseId?: string | null;
  toWarehouseId?: string | null;
  /** IN/OUT/TRANSFER: positive count. ADJUST: signed delta. */
  quantity: number;
  unitCost?: number | null;
  refType?: string | null;
  refId?: string | null;
  note?: string | null;
  userId?: string | null;
  movedAt?: Date | null;
};

const MOVEMENT_INCLUDE = {
  product: { select: { name: true, unit: true } },
  fromWarehouse: { select: { name: true } },
  toWarehouse: { select: { name: true } },
  user: { select: { firstName: true, lastName: true } },
} as const;

/** The active warehouse marked default (falls back to the first active one). */
export async function getDefaultWarehouseId(): Promise<string | null> {
  const wh = await db.warehouse.findFirst({
    where: { isActive: true },
    orderBy: [{ isDefault: "desc" }, { createdAt: "asc" }],
    select: { id: true },
  });
  return wh?.id ?? null;
}

async function getQty(
  tx: Prisma.TransactionClient,
  productId: string,
  warehouseId: string
): Promise<number> {
  const level = await tx.stockLevel.findUnique({
    where: { productId_warehouseId: { productId, warehouseId } },
    select: { quantity: true },
  });
  return level?.quantity ?? 0;
}

async function setQty(
  tx: Prisma.TransactionClient,
  productId: string,
  warehouseId: string,
  quantity: number
) {
  await tx.stockLevel.upsert({
    where: { productId_warehouseId: { productId, warehouseId } },
    create: { productId, warehouseId, quantity },
    update: { quantity },
  });
}

/**
 * Apply a single stock movement atomically (validates availability first).
 * Safe to call inside an existing transaction via `applyMovementTx`.
 */
export function applyMovement(input: MovementInput) {
  return db.$transaction((tx) => applyMovementTx(tx, input));
}

export async function applyMovementTx(
  tx: Prisma.TransactionClient,
  input: MovementInput
) {
  const { type, productId } = input;
  const qty = Number(input.quantity);
  const from = input.fromWarehouseId || null;
  const to = input.toWarehouseId || null;

  if (!productId) throw new HttpError(400, "انتخاب کالا الزامی است.");
  if (!Number.isFinite(qty)) throw new HttpError(400, "تعداد نامعتبر است.");

  const product = await tx.product.findUnique({
    where: { id: productId },
    select: { name: true },
  });
  if (!product) throw new HttpError(404, "کالای انتخاب‌شده یافت نشد.");

  if (type !== "ADJUST" && qty <= 0) {
    throw new HttpError(400, "تعداد باید بزرگ‌تر از صفر باشد.");
  }

  if (type === "IN") {
    if (!to) throw new HttpError(400, "انبار مقصد را انتخاب کنید.");
    const cur = await getQty(tx, productId, to);
    await setQty(tx, productId, to, cur + qty);
  } else if (type === "OUT") {
    if (!from) throw new HttpError(400, "انبار مبدأ را انتخاب کنید.");
    const cur = await getQty(tx, productId, from);
    if (cur < qty) {
      throw new HttpError(
        409,
        `موجودی «${product.name}» در این انبار کافی نیست. موجودی فعلی: ${cur}`
      );
    }
    await setQty(tx, productId, from, cur - qty);
  } else if (type === "TRANSFER") {
    if (!from || !to) throw new HttpError(400, "انبار مبدأ و مقصد را انتخاب کنید.");
    if (from === to) throw new HttpError(400, "انبار مبدأ و مقصد یکسان است.");
    const curFrom = await getQty(tx, productId, from);
    if (curFrom < qty) {
      throw new HttpError(
        409,
        `موجودی «${product.name}» در انبار مبدأ کافی نیست. موجودی فعلی: ${curFrom}`
      );
    }
    const curTo = await getQty(tx, productId, to);
    await setQty(tx, productId, from, curFrom - qty);
    await setQty(tx, productId, to, curTo + qty);
  } else if (type === "ADJUST") {
    if (!to) throw new HttpError(400, "انبار را انتخاب کنید.");
    if (qty === 0) throw new HttpError(400, "مقدار اصلاح نمی‌تواند صفر باشد.");
    const cur = await getQty(tx, productId, to);
    const next = cur + qty;
    if (next < 0) {
      throw new HttpError(
        409,
        `موجودی پس از اصلاح منفی می‌شود. موجودی فعلی «${product.name}»: ${cur}`
      );
    }
    await setQty(tx, productId, to, next);
  } else {
    throw new HttpError(400, "نوع گردش نامعتبر است.");
  }

  return tx.stockMovement.create({
    data: {
      type,
      productId,
      fromWarehouseId: from,
      toWarehouseId: to,
      quantity: qty,
      unitCost: input.unitCost ?? null,
      refType: input.refType ?? "MANUAL",
      refId: input.refId ?? null,
      note: input.note ?? null,
      userId: input.userId ?? null,
      movedAt: input.movedAt ?? new Date(),
    },
    include: MOVEMENT_INCLUDE,
  });
}

/**
 * Reverse & delete movements matching a reference (e.g. canceling an issued
 * sales order returns its goods to stock). Restores levels per movement type.
 */
export async function reverseMovementsTx(
  tx: Prisma.TransactionClient,
  filter: { refType: string; refId: string }
): Promise<number> {
  const movements = await tx.stockMovement.findMany({ where: filter });
  for (const m of movements) {
    if (m.type === "IN" && m.toWarehouseId) {
      const cur = await getQty(tx, m.productId, m.toWarehouseId);
      await setQty(tx, m.productId, m.toWarehouseId, Math.max(0, cur - m.quantity));
    } else if (m.type === "OUT" && m.fromWarehouseId) {
      const cur = await getQty(tx, m.productId, m.fromWarehouseId);
      await setQty(tx, m.productId, m.fromWarehouseId, cur + m.quantity);
    } else if (m.type === "TRANSFER" && m.fromWarehouseId && m.toWarehouseId) {
      const curTo = await getQty(tx, m.productId, m.toWarehouseId);
      await setQty(tx, m.productId, m.toWarehouseId, Math.max(0, curTo - m.quantity));
      const curFrom = await getQty(tx, m.productId, m.fromWarehouseId);
      await setQty(tx, m.productId, m.fromWarehouseId, curFrom + m.quantity);
    } else if (m.type === "ADJUST" && m.toWarehouseId) {
      const cur = await getQty(tx, m.productId, m.toWarehouseId);
      await setQty(tx, m.productId, m.toWarehouseId, Math.max(0, cur - m.quantity));
    }
  }
  await tx.stockMovement.deleteMany({
    where: { id: { in: movements.map((m) => m.id) } },
  });
  return movements.length;
}

/**
 * Deduct stock for a sales order moving to ISSUED.
 * Skips silently when the order has no stock-tracked items or no warehouse
 * is configured; blocks (409) when stock is insufficient.
 */
export async function issueStockForOrder(
  orderId: string,
  userId?: string | null
): Promise<number> {
  const order = await db.salesOrder.findUnique({
    where: { id: orderId },
    include: { items: true },
  });
  if (!order) throw new HttpError(404, "فاکتور یافت نشد.");

  const stockItems = order.items.filter((it) => it.productId);
  if (stockItems.length === 0) return 0;

  const warehouseId = await getDefaultWarehouseId();
  if (!warehouseId) return 0; // warehouse module not configured → bypass

  await db.$transaction(async (tx) => {
    for (const it of stockItems) {
      await applyMovementTx(tx, {
        type: "OUT",
        productId: it.productId as string,
        fromWarehouseId: warehouseId,
        quantity: it.qty,
        refType: "SALES_ORDER",
        refId: orderId,
        note: `صدور فاکتور فروش شماره ${order.number}`,
        userId: userId ?? null,
      });
    }
  });
  return stockItems.length;
}

export { MOVEMENT_INCLUDE };
