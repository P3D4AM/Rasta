import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";

// GET /api/products
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("products", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const active = url.searchParams.get("active");

    const where: Prisma.ProductWhereInput = {
      ...(active === "1" ? { isActive: true } : active === "0" ? { isActive: false } : {}),
      ...(search
        ? {
            OR: [
              { name: { contains: search } },
              { code: { contains: search } },
              { description: { contains: search } },
            ],
          }
        : {}),
    };

    const [rows, total] = await Promise.all([
      db.product.findMany({ where, orderBy: { createdAt: "desc" }, skip, take }),
      db.product.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/products
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("products", "create");
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام محصول الزامی است.", 400);

    const code = clean(body?.code);
    if (code) {
      const dup = await db.product.findUnique({ where: { code } });
      if (dup) return apiError("کد محصول تکراری است.", 409);
    }

    const product = await db.product.create({
      data: {
        name,
        code,
        unit: clean(body?.unit) ?? "عدد",
        price: num(body?.price, 0),
        cost: numOrNull(body?.cost),
        taxRate: num(body?.taxRate, 0),
        isActive: body?.isActive ?? true,
        description: clean(body?.description),
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "product",
        entityId: product.id,
        meta: name,
      },
    });
    return json(product, 201);
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
