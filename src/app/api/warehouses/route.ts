import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

// GET /api/warehouses — list with item count & stock value per warehouse
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("warehouses", "view");
    const url = new URL(req.url);
    const search = (url.searchParams.get("search") ?? "").trim();
    const warehouses = await db.warehouse.findMany({
      where: search
        ? { OR: [{ name: { contains: search } }, { code: { contains: search } }, { location: { contains: search } }] }
        : undefined,
      orderBy: [{ isDefault: "desc" }, { createdAt: "asc" }],
      include: {
        stockLevels: {
          where: { quantity: { gt: 0 } },
          select: { quantity: true, product: { select: { cost: true, price: true } } },
        },
      },
    });
    const rows = warehouses.map(({ stockLevels, ...w }) => ({
      ...w,
      itemCount: stockLevels.length,
      totalValue: stockLevels.reduce(
        (sum, l) => sum + l.quantity * (l.product.cost ?? l.product.price),
        0
      ),
    }));
    return json({ rows, total: rows.length });
  });
}

// POST /api/warehouses
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("warehouses", "create");
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام انبار الزامی است.", 400);

    const code = clean(body?.code);
    if (code) {
      const dup = await db.warehouse.findUnique({ where: { code } });
      if (dup) return apiError("کد انبار تکراری است.", 409);
    }

    const isDefault = Boolean(body?.isDefault);
    const warehouse = await db.$transaction(async (tx) => {
      if (isDefault) {
        await tx.warehouse.updateMany({ data: { isDefault: false } });
      }
      return tx.warehouse.create({
        data: {
          name,
          code,
          location: clean(body?.location),
          isDefault,
          isActive: body?.isActive ?? true,
          note: clean(body?.note),
        },
      });
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "warehouse",
        entityId: warehouse.id,
        meta: name,
      },
    });
    return json(warehouse, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
