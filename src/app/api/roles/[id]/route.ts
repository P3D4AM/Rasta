import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/roles/[id] — ویرایش/حذف نقش (RollsDefineInsert/Edit/Delete)
 * PUT    → فیلدهای نقش (نام/توضیح/سقف تخفیف‌ها) — مجوزها از مسیر جدا مدیریت می‌شوند
 * DELETE → حذف نقشِ بدون کاربر (با کاربرِ اختصاص‌یافته مسدود)
 */

export async function PUT(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmUserRoll", "actEdit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.role.findUnique({ where: { id } });
    if (!existing) return apiError("نقش یافت نشد.", 404);

    const name = String(body?.name ?? existing.name).trim();
    const dup = await db.role.findFirst({ where: { name, id: { not: id } } });
    if (dup) return apiError("نقشی با این نام وجود دارد.", 409);

    const role = await db.role.update({
      where: { id },
      data: {
        name,
        description: clean(body?.description),
        limitPreOrderDiscountActive: body?.limitPreOrderDiscountActive !== undefined ? Boolean(body.limitPreOrderDiscountActive) : existing.limitPreOrderDiscountActive,
        limitPreOrderDiscountPercent: body?.limitPreOrderDiscountPercent !== undefined ? numPercent(body.limitPreOrderDiscountPercent) : existing.limitPreOrderDiscountPercent,
        limitOrderDiscountActive: body?.limitOrderDiscountActive !== undefined ? Boolean(body.limitOrderDiscountActive) : existing.limitOrderDiscountActive,
        limitOrderDiscountPercent: body?.limitOrderDiscountPercent !== undefined ? numPercent(body.limitOrderDiscountPercent) : existing.limitOrderDiscountPercent,
      },
    });
    return json(role);
  });
}

export async function DELETE(_req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmUserRoll", "actDelete");
    const { id } = await params;
    const inUse = await db.user.count({ where: { roleId: id } });
    if (inUse > 0) {
      return apiError(`این نقش به ${inUse} کاربر اختصاص یافته است.`, 409);
    }
    await db.role.delete({ where: { id } });
    return json({ deleted: true });
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
