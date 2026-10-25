import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { hashPassword, can } from "@/lib/auth";

/**
 * /api/users/[id] — بازسازی AccountsController (UserDefineEdit / _PartialUserInfo / UserDefineDelete)
 * GET    → پنل اطلاعات کاربر (تمام فیلدها + نقش + سمت/دپارتمان/گروه + امضا/ساعت ورود)
 * PUT    → ویرایش (نام کاربری غیرقابل تغییر — مثل خود محصول؛ تغییر نقش نیازمند actAssignRoll)
 * DELETE → غیرفعال‌سازی (IsActive=false) — حذف فیزیکی کاربرِ دارای داده در خود محصول هم صورت نمی‌گیرد
 */

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actView");
    const { id } = await params;
    const u = await db.user.findUnique({
      where: { id },
      include: {
        role: { select: { id: true, name: true, description: true } },
        position: { select: { id: true, name: true } },
        department: { select: { id: true, name: true } },
        userGroup: { select: { id: true, name: true } },
        responsible: { select: { id: true, firstName: true, lastName: true } },
      },
    });
    if (!u) return apiError("کاربر یافت نشد.", 404);
    return json({
      ...u,
      passwordHash: undefined,
      signature: undefined,
      hasSignature: u.signature != null,
      signatureLength: u.signature?.length ?? 0,
      roleName: u.role?.name ?? null,
      positionName: u.position?.name ?? null,
      departmentName: u.department?.name ?? null,
      userGroupName: u.userGroup?.name ?? null,
      responsibleName: u.responsible ? `${u.responsible.firstName} ${u.responsible.lastName}` : null,
      loginAllowedTimes: await db.userLoginAllowedTime.findMany({ where: { userId: id }, orderBy: { createdAt: "asc" } }),
      bankAccountsCount: await db.bankAccount.count({ where: { userId: id } }),
    });
  });
}

export async function PUT(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const admin = await requirePerm("frmDefineUsers", "actEdit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.user.findUnique({ where: { id } });
    if (!existing) return apiError("کاربر یافت نشد.", 404);

    // غیرادمین نمی‌تواند مدیر سیستم را ویرایش کند یا مدیریتی اهدا کند
    if (!admin.isAdmin && existing.isAdmin) {
      return apiError("اجازه ویرایش مدیر سیستم را ندارید.", 403);
    }

    // تغییر نقش — نیازمند actAssignRoll (مثل actInsertRoll/actEditRoll خود محصول)
    const roleId = clean(body?.roleId) ?? existing.roleId;
    if (roleId !== existing.roleId) {
      if (!can(admin, "frmDefineUsers", "actAssignRoll")) {
        return apiError("شما مجوز تغییر نقش کاربران را ندارید.", 403);
      }
      const role = await db.role.findUnique({ where: { id: roleId ?? "" } });
      if (!role) return apiError("نقش انتخاب‌شده یافت نشد.", 400);
    }

    const password = String(body?.password ?? "");
    const user = await db.user.update({
      where: { id },
      data: {
        firstName: String(body?.firstName ?? existing.firstName).trim(),
        lastName: String(body?.lastName ?? existing.lastName).trim(),
        email: clean(body?.email),
        phone: clean(body?.phone),
        isActive: body?.isActive !== undefined ? Boolean(body.isActive) : existing.isActive,
        roleId,
        isAdmin: admin.isAdmin ? body?.isAdmin !== undefined ? Boolean(body.isAdmin) : existing.isAdmin : existing.isAdmin,
        nickName: clean(body?.nickName),
        persCode: clean(body?.persCode),
        fatherName: clean(body?.fatherName),
        nationalCode: clean(body?.nationalCode),
        identityNumber: clean(body?.identityNumber),
        insuranceCode: clean(body?.insuranceCode),
        mobile: clean(body?.mobile),
        mobileII: clean(body?.mobileII),
        address: clean(body?.address),
        tel: clean(body?.tel),
        telDesc: clean(body?.telDesc),
        description: clean(body?.description),
        userGroupId: clean(body?.userGroupId),
        positionId: clean(body?.positionId),
        departmentId: clean(body?.departmentId),
        responsibleUserId: clean(body?.responsibleUserId),
        alternativeUserIds: clean(body?.alternativeUserIds),
        extensions: clean(body?.extensions),
        callPreNumber: clean(body?.callPreNumber),
        startDate: dateVal(body?.startDate),
        expireDate: dateVal(body?.expireDate),
        defCmpPrjTitle: clean(body?.defCmpPrjTitle),
        disableInternalMessageAlarmVoice: body?.disableInternalMessageAlarmVoice !== undefined ? Boolean(body.disableInternalMessageAlarmVoice) : existing.disableInternalMessageAlarmVoice,
        disableReceiveCnvsInfoAllarm: body?.disableReceiveCnvsInfoAllarm !== undefined ? Boolean(body.disableReceiveCnvsInfoAllarm) : existing.disableReceiveCnvsInfoAllarm,
        accessDailyChartAllUsers: body?.accessDailyChartAllUsers !== undefined ? Boolean(body.accessDailyChartAllUsers) : existing.accessDailyChartAllUsers,
        accessSaleChartAllUsers: body?.accessSaleChartAllUsers !== undefined ? Boolean(body.accessSaleChartAllUsers) : existing.accessSaleChartAllUsers,
        ...(password ? (password.length >= 6 ? { passwordHash: hashPassword(password) } : {}) : {}),
      },
    });
    return json({ ...user, passwordHash: undefined, signature: undefined });
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const admin = await requirePerm("frmDefineUsers", "actDelete");
    const { id } = await params;
    if (id === admin.id) return apiError("نمی‌توانید حساب خود را غیرفعال کنید.", 400);
    const existing = await db.user.findUnique({ where: { id } });
    if (!existing) return apiError("کاربر یافت نشد.", 404);
    if (existing.isAdmin && !admin.isAdmin) {
      return apiError("اجازه غیرفعال‌کردن مدیر سیستم را ندارید.", 403);
    }
    // مثل خود محصول: کاربرِ دارای رکوردها حذف فیزیکی نمی‌شود؛ IsActive=false می‌شود
    await db.user.update({ where: { id }, data: { isActive: false } });
    return json({ ok: true, deactivated: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}

function dateVal(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(v as string);
  return isNaN(d.getTime()) ? null : d;
}
