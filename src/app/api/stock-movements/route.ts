import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery } from "@/lib/http";
import { MOVEMENT_TYPES, MOVEMENT_TYPE_LABELS } from "@/lib/constants";
import { applyMovement, type MovementType } from "@/lib/stock";
import type { Prisma } from "@prisma/client";

// GET /api/stock-movements — movement history
// filters: search (product name), type, warehouseId (from OR to), productId, refType
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("inventory", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req, 20);
    const url = new URL(req.url);
    const type = (url.searchParams.get("type") ?? "").trim();
    const warehouseIdRaw = (url.searchParams.get("warehouseId") ?? "").trim();
    const warehouseId = warehouseIdRaw && warehouseIdRaw !== "ALL" ? warehouseIdRaw : "";
    const productId = (url.searchParams.get("productId") ?? "").trim();
    const refType = (url.searchParams.get("refType") ?? "").trim();

    const where: Prisma.StockMovementWhereInput = {
      ...(MOVEMENT_TYPES.includes(type as (typeof MOVEMENT_TYPES)[number]) ? { type } : {}),
      ...(productId ? { productId } : {}),
      ...(refType ? { refType } : {}),
      ...(warehouseId
        ? { OR: [{ fromWarehouseId: warehouseId }, { toWarehouseId: warehouseId }] }
        : {}),
      ...(search
        ? { product: { OR: [{ name: { contains: search } }, { code: { contains: search } }] } }
        : {}),
    };

    const [rows, total] = await Promise.all([
      db.stockMovement.findMany({
        where,
        orderBy: [{ movedAt: "desc" }, { createdAt: "desc" }],
        skip,
        take,
        include: {
          product: { select: { name: true, code: true, unit: true } },
          fromWarehouse: { select: { name: true } },
          toWarehouse: { select: { name: true } },
          user: { select: { firstName: true, lastName: true } },
        },
      }),
      db.stockMovement.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/stock-movements — register a manual movement (IN/OUT/TRANSFER/ADJUST)
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("inventory", "create");
    const body = await req.json().catch(() => null);
    const type = String(body?.type ?? "");
    if (!MOVEMENT_TYPES.includes(type as (typeof MOVEMENT_TYPES)[number])) {
      return apiError("نوع گردش نامعتبر است.", 400);
    }
    const productId = String(body?.productId ?? "");
    if (!productId) return apiError("انتخاب کالا الزامی است.", 400);

    const quantity = Number(body?.quantity);
    if (!Number.isFinite(quantity)) return apiError("تعداد نامعتبر است.", 400);

    const unitCost =
      body?.unitCost === null || body?.unitCost === undefined || body?.unitCost === ""
        ? null
        : Number(body.unitCost);

    const movement = await applyMovement({
      type: type as MovementType,
      productId,
      fromWarehouseId: body?.fromWarehouseId || null,
      toWarehouseId: body?.toWarehouseId || null,
      quantity,
      unitCost: unitCost != null && !isNaN(unitCost) ? unitCost : null,
      refType: "MANUAL",
      note: body?.note?.toString().trim() || null,
      userId: user.id,
      movedAt: body?.movedAt ? new Date(String(body.movedAt)) : new Date(),
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "stockMovement",
        entity: "product",
        entityId: productId,
        meta: `${MOVEMENT_TYPE_LABELS[type]} — تعداد ${quantity}`,
      },
    });
    return json(movement, 201);
  });
}
