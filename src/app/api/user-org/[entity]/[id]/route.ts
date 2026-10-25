import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/user-org/[entity]/[id] — ویرایش/حذف ساختار سازمانی
 * حذف سمتِ دارای کاربر یا فرزند مسدود می‌شود.
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

export async function PUT(req: Request, { params }: { params: Promise<{ entity: string; id: string }> }) {
  return handle(async () => {
    const { entity, id } = await params;
    const perm = PERM[entity];
    if (!perm) return apiError("نوع تعریف نامعتبر است.", 404);
    await requirePerm("frmMain", perm);
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام الزامی است.", 400);

    if (entity === "positions") {
      const row = await db.userPosition.update({
        where: { id },
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
      return json(row);
    }
    if (entity === "groups") {
      const row = await db.userGroup.update({ where: { id }, data: { name, description: s(body?.description) } });
      return json(row);
    }
    const row = await db.userDepartment.update({ where: { id }, data: { name, description: s(body?.description) } });
    return json(row);
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ entity: string; id: string }> }) {
  return handle(async () => {
    const { entity, id } = await params;
    const perm = PERM[entity];
    if (!perm) return apiError("نوع تعریف نامعتبر است.", 404);
    await requirePerm("frmMain", perm);

    if (entity === "positions") {
      const users = await db.user.count({ where: { positionId: id } });
      const children = await db.userPosition.count({ where: { parentId: id } });
      if (users || children) {
        return apiError(`${users} کاربر و ${children} سمت فرزند به این سمت متصل‌اند؛ حذف امکان‌پذیر نیست.`, 409);
      }
      await db.userPosition.delete({ where: { id } });
      return json({ deleted: true });
    }
    if (entity === "groups") {
      const users = await db.user.count({ where: { userGroupId: id } });
      if (users) return apiError(`${users} کاربر در این گروه است؛ ابتدا کاربران را منتقل کنید.`, 409);
      await db.userGroup.delete({ where: { id } });
      return json({ deleted: true });
    }
    const users = await db.user.count({ where: { departmentId: id } });
    if (users) return apiError(`${users} کاربر در این دپارتمان است؛ ابتدا کاربران را منتقل کنید.`, 409);
    await db.userDepartment.delete({ where: { id } });
    return json({ deleted: true });
  });
}
