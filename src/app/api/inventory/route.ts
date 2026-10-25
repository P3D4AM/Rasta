import { db } from "@/lib/db";
import { requirePermission, handle, json } from "@/lib/http";
import { LOW_STOCK_THRESHOLD } from "@/lib/constants";
import type { Prisma } from "@prisma/client";

// GET /api/inventory — stock levels + summary
// filters: search (product name/code), warehouseId, availability (IN_STOCK | OUT_OF_STOCK), productId
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("inventory", "view");
    const url = new URL(req.url);
    const page = Math.max(1, Number(url.searchParams.get("page") ?? 1) || 1);
    const pageSize = Math.min(
      200,
      Math.max(1, Number(url.searchParams.get("pageSize") ?? 20) || 20)
    );
    const search = (url.searchParams.get("search") ?? "").trim();
    const warehouseIdRaw = (url.searchParams.get("warehouseId") ?? "").trim();
    const warehouseId = warehouseIdRaw && warehouseIdRaw !== "ALL" ? warehouseIdRaw : "";
    const availability = (url.searchParams.get("availability") ?? "ALL").trim();
    const productId = (url.searchParams.get("productId") ?? "").trim();

    const qtyFilter: Prisma.FloatFilter | undefined =
      availability === "IN_STOCK"
        ? { gt: 0 }
        : availability === "OUT_OF_STOCK"
          ? { lte: 0 }
          : undefined;

    const where: Prisma.StockLevelWhereInput = {
      ...(warehouseId ? { warehouseId } : {}),
      ...(productId ? { productId } : {}),
      ...(qtyFilter ? { quantity: qtyFilter } : {}),
      ...(search
        ? {
            product: {
              OR: [{ name: { contains: search } }, { code: { contains: search } }],
            },
          }
        : {}),
    };

    // Fetch all matching rows (dev-scale) to compute summary + paginate in memory.
    // TODO(postgres): move summary to a SQL aggregate view.
    const all = await db.stockLevel.findMany({
      where,
      include: {
        product: { select: { id: true, name: true, code: true, unit: true, cost: true, price: true } },
        warehouse: { select: { id: true, name: true } },
      },
      orderBy: [{ product: { name: "asc" } }, { warehouse: { name: "asc" } }],
    });

    const summary = {
      itemCount: all.filter((l) => l.quantity > 0).length,
      totalValue: all.reduce(
        (sum, l) => sum + l.quantity * (l.product.cost ?? l.product.price),
        0
      ),
      lowCount: all.filter((l) => l.quantity > 0 && l.quantity < LOW_STOCK_THRESHOLD).length,
      outCount: all.filter((l) => l.quantity <= 0).length,
    };

    const total = all.length;
    const rows = all.slice((page - 1) * pageSize, page * pageSize);

    return json({ rows, total, page, pageSize, summary });
  });
}
