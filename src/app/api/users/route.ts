import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError, parseListQuery } from "@/lib/http";
import { hashPassword } from "@/lib/auth";

/**
 * /api/users — بازسازی AccountsController.UserDefine (گرید لیست کاربران)
 * GET  ?filter=active|inactive|all&search= → ستون‌های گرید خود محصول:
 *      ردیف / نام / فامیل / کد پرسنلی / نام کاربری / نقش / فعال(وب)
 * POST → UserDefineInsert (فیلدهای الزامی: نام‌خانوادگی/نام‌کاربری/رمز — ChkBeforeSubmitUser)
 */

export async function GET(req: Request) {
  return handle(async () => {
    const me = await requirePerm("frmDefineUsers", "actView");
    const url = new URL(req.url);
    const light = url.searchParams.get("light") === "1";
    if (light) {
      const rows = await db.user.findMany({
        where: { isActive: true },
        select: { id: true, firstName: true, lastName: true },
        orderBy: { firstName: "asc" },
      });
      return json({ rows });
    }

    const { page, pageSize, take, skip, search } = parseListQuery(req, 500);
    const filter = url.searchParams.get("filter") ?? "active"; // active | inactive | all — رادیوی خود محصول

    const where: Record<string, unknown> = {};
    if (filter === "active") where.isActive = true;
    else if (filter === "inactive") where.isActive = false;
    if (search) {
      where.OR = [
        { firstName: { contains: search } },
        { lastName: { contains: search } },
        { username: { contains: search } },
        { persCode: { contains: search } },
      ];
    }

    const [users, total] = await Promise.all([
      db.user.findMany({
        where,
        orderBy: [{ lastName: "asc" }, { firstName: "asc" }],
        skip,
        take,
        include: {
          role: { select: { id: true, name: true } },
          position: { select: { id: true, name: true } },
          department: { select: { id: true, name: true } },
          userGroup: { select: { id: true, name: true } },
        },
      }),
      db.user.count({ where }),
    ]);

    return json({
      rows: users.map((u) => ({
        id: u.id,
        firstName: u.firstName,
        lastName: u.lastName,
        nickName: u.nickName,
        persCode: u.persCode,
        username: u.username,
        isAdmin: u.isAdmin,
        isActive: u.isActive,
        roleId: u.roleId,
        roleName: u.role?.name ?? null,
        positionName: u.position?.name ?? null,
        departmentName: u.department?.name ?? null,
        userGroupName: u.userGroup?.name ?? null,
        mobile: u.mobile,
        email: u.email,
        expireDate: u.expireDate,
        lastLoginAt: u.lastLoginAt,
      })),
      total,
      page,
      pageSize,
      currentUserId: me.id,
    });
  });
}

export async function POST(req: Request) {
  return handle(async () => {
    const admin = await requirePerm("frmDefineUsers", "actInsert");
    const body = await req.json().catch(() => null);
    const username = String(body?.username ?? "").trim().toLowerCase();
    const password = String(body?.password ?? "");
    const firstName = String(body?.firstName ?? "").trim();
    const lastName = String(body?.lastName ?? "").trim();
    const roleId = String(body?.roleId ?? "").trim();

    // ChkBeforeSubmitUser خود محصول: نام‌خانوادگی/نام‌کاربری/رمز اجباری
    if (!username || !password || !firstName || !lastName) {
      return apiError("نام، نام خانوادگی، نام کاربری و رمز عبور الزامی است.", 400);
    }
    if (password.length < 6) {
      return apiError("رمز عبور باید حداقل ۶ کاراکتر باشد.", 400);
    }
    if (!roleId) {
      return apiError("تخصیص نقش الزامی است (بدون نقش فعال، ورود ممکن نیست).", 400);
    }
    const role = await db.role.findUnique({ where: { id: roleId } });
    if (!role) return apiError("نقش انتخاب‌شده یافت نشد.", 400);
    // CRMspCheckDuplicateUserName
    const dup = await db.user.findUnique({ where: { username } });
    if (dup) return apiError("این نام کاربری قبلاً ثبت شده است.", 409);

    const user = await db.user.create({
      data: {
        username,
        passwordHash: hashPassword(password),
        firstName,
        lastName,
        email: clean(body?.email),
        phone: clean(body?.phone),
        isAdmin: Boolean(body?.isAdmin) && admin.isAdmin,
        roleId,
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
        disableInternalMessageAlarmVoice: Boolean(body?.disableInternalMessageAlarmVoice),
        disableReceiveCnvsInfoAllarm: Boolean(body?.disableReceiveCnvsInfoAllarm),
        accessDailyChartAllUsers: Boolean(body?.accessDailyChartAllUsers),
        accessSaleChartAllUsers: Boolean(body?.accessSaleChartAllUsers),
        isActive: body?.isActive !== false,
      },
    });

    return json({ ...user, passwordHash: undefined, signature: undefined }, 201);
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
