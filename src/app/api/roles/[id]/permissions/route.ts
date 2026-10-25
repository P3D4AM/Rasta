import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { FORMS, FORMS_BY_ID } from "@/lib/constants";

/**
 * /api/roles/[id]/permissions — بازسازی RollPermissionDefine (ماتریس مجوز خود محصول)
 * GET   → رجیستری فرم‌ها + مجموعه مجوزهای تخصیص‌یافته نقش
 * PUT   → {formId, actionId, granted} — تخصیص/حذف یک اکشن (RollPermissionAssigneAction / RemoveAssigneAction)
 * POST  → {formId} — تخصیص همه اکشن‌های فرم (RollPermissionAssigneAllAction)
 * DELETE ?formId= → حذف همه اکشن‌های فرم (RollPermissionRemoveAssigneAllAction)
 * PATCH → {sourceRoleId} — کپی همه مجوزهای نقش مبدأ (RollPermissionPasteAllPermission — کپی/انتقال خود محصول)
 */

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmRollPermission", "actView");
    const { id } = await params;
    const role = await db.role.findUnique({ where: { id }, include: { permissions: true } });
    if (!role) return apiError("نقش یافت نشد.", 404);
    return json({
      forms: FORMS,
      assigned: role.permissions.map((p) => `${p.formId}:${p.actionId}`),
    });
  });
}

export async function PUT(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmRollPermission", "actView");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const formId = String(body?.formId ?? "");
    const actionId = String(body?.actionId ?? "");
    const granted = Boolean(body?.granted);

    const form = FORMS_BY_ID[formId];
    if (!form || !form.actions.includes(actionId)) {
      return apiError("فرم یا اکشن در رجیستری مجوزها معتبر نیست.", 400);
    }

    if (granted) {
      await db.rolePermission.upsert({
        where: { roleId_formId_actionId: { roleId: id, formId, actionId } },
        create: { roleId: id, formId, actionId },
        update: {},
      });
    } else {
      await db.rolePermission.deleteMany({ where: { roleId: id, formId, actionId } });
    }
    return json({ ok: true, formId, actionId, granted });
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmRollPermission", "actView");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const formId = String(body?.formId ?? "");
    const form = FORMS_BY_ID[formId];
    if (!form) return apiError("فرم نامعتبر است.", 400);
    // توجه: createMany در SQLite از skipDuplicates پشتیبانی نمی‌کند → پاک‌سازی قبلی
    await db.rolePermission.deleteMany({ where: { roleId: id, formId, actionId: { in: form.actions } } });
    await db.rolePermission.createMany({
      data: form.actions.map((actionId) => ({ roleId: id, formId, actionId })),
    });
    return json({ ok: true, formId, granted: form.actions.length });
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmRollPermission", "actView");
    const { id } = await params;
    const url = new URL(req.url);
    const formId = url.searchParams.get("formId") ?? "";
    const form = FORMS_BY_ID[formId];
    if (!formId || !form) return apiError("فرم نامعتبر است.", 400);
    await db.rolePermission.deleteMany({ where: { roleId: id, formId } });
    return json({ ok: true, formId, removed: form.actions.length });
  });
}

export async function PATCH(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmRollPermission", "actView");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const sourceRoleId = String(body?.sourceRoleId ?? "");
    if (!sourceRoleId || sourceRoleId === id) {
      return apiError("نقش مبدأ نامعتبر است.", 400);
    }
    const source = await db.role.findUnique({ where: { id: sourceRoleId }, include: { permissions: true } });
    if (!source) return apiError("نقش مبدأ یافت نشد.", 404);

    // کپی/انتقال همه مجوزها — جایگزینی کامل مجوزهای مقصد (RollPermissionPasteAllPermission)
    const valid = new Set<string>();
    for (const f of FORMS) for (const a of f.actions) valid.add(`${f.id}:${a}`);
    const rows = source.permissions
      .filter((p) => valid.has(`${p.formId}:${p.actionId}`))
      .map((p) => ({ roleId: id, formId: p.formId, actionId: p.actionId }));

    await db.$transaction([
      db.rolePermission.deleteMany({ where: { roleId: id } }),
      ...rows.map((r) => db.rolePermission.create({ data: r })),
    ]);
    return json({ ok: true, copied: rows.length });
  });
}
