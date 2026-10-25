import { db } from "@/lib/db";
import { requirePermission, handle, json } from "@/lib/http";

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("roles", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.role.findUnique({ where: { id } });
    if (!existing) return json({ error: "نقش یافت نشد." }, 404);

    const name = String(body?.name ?? existing.name).trim();
    const dup = await db.role.findFirst({ where: { name, id: { not: id } } });
    if (dup) return json({ error: "نقشی با این نام وجود دارد." }, 409);

    const perms = Array.isArray(body?.permissions) ? body.permissions : [];

    const role = await db.role.update({
      where: { id },
      data: {
        name,
        description: clean(body?.description),
        permissions: {
          deleteMany: {},
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
    return json(role);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("roles", "delete");
    const { id } = await params;
    const inUse = await db.user.count({ where: { roleId: id } });
    if (inUse > 0) {
      return json({ error: `این نقش به ${inUse} کاربر اختصاص یافته است.` }, 409);
    }
    await db.role.delete({ where: { id } });
    return json({ ok: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
