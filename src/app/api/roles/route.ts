import { db } from "@/lib/db";
import { requirePermission, handle, json, parseListQuery } from "@/lib/http";

// GET /api/roles
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("roles", "view");
    const { take, skip, page, pageSize } = parseListQuery(req, 100);
    const url = new URL(req.url);
    const light = url.searchParams.get("light") === "1";

    if (light) {
      const roles = await db.role.findMany({
        select: { id: true, name: true },
        orderBy: { name: "asc" },
      });
      return json({ rows: roles, total: roles.length, page: 1, pageSize: 100 });
    }

    const [rows, total] = await Promise.all([
      db.role.findMany({
        orderBy: { name: "asc" },
        skip,
        take,
        include: { permissions: true, _count: { select: { users: true } } },
      }),
      db.role.count(),
    ]);
    return json({ rows, total, page, pageSize });
  });
}

// POST /api/roles — create with permission matrix
export async function POST(req: Request) {
  return handle(async () => {
    await requirePermission("roles", "create");
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return json({ error: "نام نقش الزامی است." }, 400);
    const dup = await db.role.findUnique({ where: { name } });
    if (dup) return json({ error: "نقشی با این نام وجود دارد." }, 409);

    const perms = Array.isArray(body?.permissions) ? body.permissions : [];
    const role = await db.role.create({
      data: {
        name,
        description: clean(body?.description),
        permissions: {
          create: perms
            .filter((p: Record<string, unknown>) => p.module)
            .map((p: Record<string, unknown>) => ({
              module: String(p.module),
              canView: Boolean(p.canView),
              canCreate: Boolean(p.canCreate),
              canEdit: Boolean(p.canEdit),
              canDelete: Boolean(p.canDelete),
            })),
        },
      },
      include: { permissions: true },
    });
    return json(role, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
