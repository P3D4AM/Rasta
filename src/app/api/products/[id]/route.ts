import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("products", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.product.findUnique({ where: { id } });
    if (!existing) return apiError("محصول یافت نشد.", 404);

    const code = clean(body?.code);
    if (code && code !== existing.code) {
      const dup = await db.product.findUnique({ where: { code } });
      if (dup) return apiError("کد محصول تکراری است.", 409);
    }

    const product = await db.product.update({
      where: { id },
      data: {
        name: String(body?.name ?? existing.name).trim(),
        code,
        unit: clean(body?.unit) ?? existing.unit,
        price: num(body?.price, existing.price),
        cost: numOrNull(body?.cost),
        taxRate: num(body?.taxRate, existing.taxRate),
        isActive: body?.isActive ?? existing.isActive,
        description: clean(body?.description),
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "product",
        entityId: id,
      },
    });
    return json(product);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("products", "delete");
    const { id } = await params;
    const used =
      (await db.quotationItem.count({ where: { productId: id } })) +
      (await db.salesOrderItem.count({ where: { productId: id } }));
    if (used > 0) {
      // soft-delete: keep history intact
      await db.product.update({ where: { id }, data: { isActive: false } });
      return json({ ok: true, softDeleted: true });
    }
    await db.product.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "product",
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
function num(v: unknown, fallback: number): number {
  const n = Number(v);
  return isNaN(n) ? fallback : n;
}
function numOrNull(v: unknown): number | null {
  if (v === null || v === undefined || v === "") return null;
  const n = Number(v);
  return isNaN(n) ? null : n;
}
