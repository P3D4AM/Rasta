import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError, parseListQuery } from "@/lib/http";
import { FORMS, FORMS_BY_ID } from "@/lib/constants";

/**
 * /api/roles — بازسازی RollsDefine (CrmsysRolls + CrmsysRollPermission)
 * GET  → لیست نقش‌ها با تعداد مجوز و کاربر + سقف تخفیف‌ها
 * POST → درج نقش (با مجوزهای اولیه اختیاری به شکل [{formId, actionId}])
 */

export async function GET(req: Request) {
  return handle(async () => {
    await requirePerm("frmUserRoll", "actView");
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
        include: { _count: { select: { users: true, permissions: true } } },
      }),
      db.role.count(),
    ]);
    return json({
      rows: rows.map((r) => ({
        id: r.id,
        name: r.name,
        description: r.description,
        limitPreOrderDiscountActive: r.limitPreOrderDiscountActive,
        limitPreOrderDiscountPercent: r.limitPreOrderDiscountPercent,
        limitOrderDiscountActive: r.limitOrderDiscountActive,
        limitOrderDiscountPercent: r.limitOrderDiscountPercent,
        usersCount: r._count.users,
        permsCount: r._count.permissions,
      })),
      total,
      page,
      pageSize,
    });
  });
}

export async function POST(req: Request) {
  return handle(async () => {
    await requirePerm("frmUserRoll", "actInsert");
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام نقش الزامی است.", 400);
    const dup = await db.role.findUnique({ where: { name } });
    if (dup) return apiError("نقشی با این نام وجود دارد.", 409);

    // مجوزهای اولیه — فقط جفت‌های معتبر رجیستری (مثل CrmsysFormActions)
    const rawPerms = Array.isArray(body?.permissions) ? body.permissions : [];
    const valid = new Set<string>();
    for (const f of FORMS) for (const a of f.actions) valid.add(`${f.id}:${a}`);
    const perms = rawPerms
      .map((p: { formId?: unknown; actionId?: unknown }) => ({ formId: String(p.formId ?? ""), actionId: String(p.actionId ?? "") }))
      .filter((p: { formId: string; actionId: string }) => valid.has(`${p.formId}:${p.actionId}`));

    const role = await db.role.create({
      data: {
        name,
        description: clean(body?.description),
        limitPreOrderDiscountActive: Boolean(body?.limitPreOrderDiscountActive),
        limitPreOrderDiscountPercent: numPercent(body?.limitPreOrderDiscountPercent),
        limitOrderDiscountActive: Boolean(body?.limitOrderDiscountActive),
        limitOrderDiscountPercent: numPercent(body?.limitOrderDiscountPercent),
        permissions: { create: perms },
      },
      include: { permissions: true },
    });
    return json(role, 201);
  });
}

function numPercent(v: unknown): number {
  const n = Number(v);
  if (!Number.isFinite(n) || n < 0) return 0;
  return Math.min(100, n);
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
