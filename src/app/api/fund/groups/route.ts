import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

/**
 * /api/fund/groups — گروه‌بندی درختی خزانه
 * بازسازی Fund/GroupsController (درخت گروه‌ها مثل _PartialFundGroupTree)
 */

// GET: درخت گروه‌ها
export async function GET() {
  return handle(async () => {
    await requirePermission("fund", "view");
    const all = await db.fundGroup.findMany({
      orderBy: [{ order: "asc" }, { name: "asc" }],
      include: { _count: { select: { transactions: true } } },
    });
    return json({ rows: all });
  });
}

// POST: ایجاد گروه
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("fund", "create");
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام گروه الزامی است.", 400);

    const group = await db.fundGroup.create({
      data: {
        name,
        parentId: body?.parentId ? String(body.parentId) : null,
        order: Number(body?.order ?? 0) || 0,
      },
    });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "fundGroup",
        entityId: group.id,
        meta: name,
      },
    });
    return json(group, 201);
  });
}

// PATCH: ویرایش گروه
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requirePermission("fund", "edit");
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    if (!id) return apiError("شناسه گروه الزامی است.", 400);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام گروه الزامی است.", 400);

    const group = await db.fundGroup.update({
      where: { id },
      data: {
        name,
        parentId: body?.parentId ? String(body.parentId) : null,
        order: Number(body?.order ?? 0) || 0,
      },
    });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "fundGroup",
        entityId: id,
        meta: name,
      },
    });
    return json(group);
  });
}

// DELETE: حذف گروه (فقط بدون سند)
export async function DELETE(req: Request) {
  return handle(async () => {
    const user = await requirePermission("fund", "delete");
    const url = new URL(req.url);
    const id = url.searchParams.get("id") ?? "";
    if (!id) return apiError("شناسه گروه الزامی است.", 400);

    const count = await db.fundTransaction.count({ where: { groupId: id } });
    if (count > 0) return apiError("این گروه دارای سند خزانه است و قابل حذف نیست.", 409);

    await db.fundGroup.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "fundGroup",
        entityId: id,
      },
    });
    return json({ ok: true });
  });
}
