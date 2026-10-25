import { db } from "@/lib/db";
import { requirePermission, handle, json } from "@/lib/http";
import { hashPassword } from "@/lib/auth";

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const admin = await requirePermission("users", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.user.findUnique({ where: { id } });
    if (!existing) return json({ error: "کاربر یافت نشد." }, 404);

    // A non-admin cannot edit admins or grant admin
    if (!admin.isAdmin && existing.isAdmin) {
      return json({ error: "اجازه ویرایش مدیر سیستم را ندارید." }, 403);
    }

    const password = String(body?.password ?? "");
    const user = await db.user.update({
      where: { id },
      data: {
        firstName: String(body?.firstName ?? existing.firstName).trim(),
        lastName: String(body?.lastName ?? existing.lastName).trim(),
        email: clean(body?.email),
        phone: clean(body?.phone),
        isActive: body?.isActive ?? existing.isActive,
        roleId: clean(body?.roleId),
        isAdmin: admin.isAdmin ? Boolean(body?.isAdmin) : existing.isAdmin,
        ...(password ? (password.length >= 6 ? { passwordHash: hashPassword(password) } : {}) : {}),
      },
      select: {
        id: true, username: true, firstName: true, lastName: true, email: true,
        phone: true, isAdmin: true, isActive: true, roleId: true, lastLoginAt: true,
      },
    });
    return json(user);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const admin = await requirePermission("users", "delete");
    const { id } = await params;
    if (id === admin.id) return json({ error: "نمی‌توانید حساب خود را حذف کنید." }, 400);
    const existing = await db.user.findUnique({ where: { id } });
    if (!existing) return json({ error: "کاربر یافت نشد." }, 404);
    if (existing.isAdmin && !admin.isAdmin) {
      return json({ error: "اجازه حذف مدیر سیستم را ندارید." }, 403);
    }
    await db.user.update({ where: { id }, data: { isActive: false } });
    return json({ ok: true, deactivated: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
