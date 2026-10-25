import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

// PUT /api/warehouses/[id]
export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("warehouses", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام انبار الزامی است.", 400);

    const existing = await db.warehouse.findUnique({ where: { id } });
    if (!existing) return apiError("انبار یافت نشد.", 404);

    const code = clean(body?.code);
    if (code) {
      const dup = await db.warehouse.findFirst({
        where: { code, id: { not: id } },
      });
      if (dup) return apiError("کد انبار تکراری است.", 409);
    }

    const isDefault = Boolean(body?.isDefault);
    const updated = await db.$transaction(async (tx) => {
      if (isDefault) {
        await tx.warehouse.updateMany({ where: { id: { not: id } }, data: { isDefault: false } });
      }
      return tx.warehouse.update({
        where: { id },
        data: {
          name,
          code,
          location: clean(body?.location),
          isDefault,
          isActive: body?.isActive ?? existing.isActive,
          note: clean(body?.note),
        },
      });
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "warehouse",
        entityId: id,
        meta: name,
      },
    });
    return json(updated);
  });
}

// DELETE /api/warehouses/[id] — soft-deactivates when movements/stock exist
export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("warehouses", "delete");
    const { id } = await params;
    const existing = await db.warehouse.findUnique({
      where: { id },
      include: {
        _count: { select: { movementsFrom: true, movementsTo: true } },
      },
    });
    if (!existing) return apiError("انبار یافت نشد.", 404);

    const hasHistory =
      (existing._count.movementsFrom ?? 0) + (existing._count.movementsTo ?? 0) > 0;
    const hasStock = await db.stockLevel.count({
      where: { warehouseId: id, quantity: { gt: 0 } },
    });

    if (hasHistory || hasStock > 0) {
      await db.warehouse.update({
        where: { id },
        data: { isActive: false, isDefault: false },
      });
      await db.activityLog.create({
        data: {
          userId: user.id,
          userName: `${user.firstName} ${user.lastName}`,
          action: "deactivate",
          entity: "warehouse",
          entityId: id,
          meta: existing.name,
        },
      });
      return json({ ok: true, deactivated: true });
    }

    await db.warehouse.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "warehouse",
        entityId: id,
        meta: existing.name,
      },
    });
    return json({ ok: true, deactivated: false });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
