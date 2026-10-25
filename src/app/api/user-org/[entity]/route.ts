import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/user-org/[entity] — تعاریف ساختار سازمانی (frmMain/actDefine*)
 * entity ∈ positions | groups | departments
 */

const s = (v: unknown): string | null => {
  const x = typeof v === "string" ? v.trim() : "";
  return x.length ? x : null;
};

const PERM: Record<string, string> = {
  positions: "actDefineUserPositions",
  groups: "actDefineUserGroups",
  departments: "actDefineDepartments",
};

export async function GET(req: Request, { params }: { params: Promise<{ entity: string }> }) {
  return handle(async () => {
    await requirePerm("frmMain", "actView");
    const { entity } = await params;
    if (entity === "positions") {
      const rows = await db.userPosition.findMany({
        orderBy: [{ orderView: "asc" }, { name: "asc" }],
        include: { parent: true, _count: { select: { users: true, children: true } } },
      });
      return json({ rows });
    }
    if (entity === "groups") {
      const rows = await db.userGroup.findMany({ orderBy: { name: "asc" }, include: { _count: { select: { users: true } } } });
      return json({ rows });
    }
    if (entity === "departments") {
      const rows = await db.userDepartment.findMany({ orderBy: { name: "asc" }, include: { _count: { select: { users: true } } } });
      return json({ rows });
    }
    return apiError("نوع تعریف نامعتبر است.", 404);
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ entity: string }> }) {
  return handle(async () => {
    const { entity } = await params;
    const perm = PERM[entity];
    if (!perm) return apiError("نوع تعریف نامعتبر است.", 404);
    await requirePerm("frmMain", perm);
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام الزامی است.", 400);

    if (entity === "positions") {
      const row = await db.userPosition.create({
        data: {
          name,
          code: s(body?.code),
          manager: s(body?.manager),
          tel: s(body?.tel),
          email: s(body?.email),
          address: s(body?.address),
          orderView: Number(body?.orderView) || 0,
          parentId: s(body?.parentId),
        },
      });
      return json(row, 201);
    }
    if (entity === "groups") {
      const row = await db.userGroup.create({ data: { name, description: s(body?.description) } });
      return json(row, 201);
    }
    const row = await db.userDepartment.create({ data: { name, description: s(body?.description) } });
    return json(row, 201);
  });
}
