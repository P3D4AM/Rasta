import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

/**
 * /api/banking/accounts — حساب‌های بانکی
 * بازسازی Banking/Accounts.cshtml (حساب/شماره کارت/شبا/صاحب حساب/پیش‌فرض)
 */

// GET: لیست حساب‌ها + انواع حساب + بانک‌ها و شعب برای فرم
export async function GET() {
  return handle(async () => {
    await requirePermission("banking", "view");
    const [accounts, types, branches] = await Promise.all([
      db.bankAccount.findMany({
        orderBy: { createdAt: "desc" },
        include: {
          branch: { include: { bank: { select: { id: true, name: true } } } },
          accountType: true,
        },
      }),
      db.bankAccountType.findMany({ orderBy: { name: "asc" } }),
      db.bankBranch.findMany({
        orderBy: { name: "asc" },
        include: { bank: { select: { id: true, name: true } } },
      }),
    ]);
    return json({ rows: accounts, types, branches });
  });
}

// POST: ایجاد حساب
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("banking", "create");
    const body = await req.json().catch(() => null);
    const branchId = String(body?.branchId ?? "");
    const accountTypeId = String(body?.accountTypeId ?? "");
    const accountNumber = String(body?.accountNumber ?? "").trim();
    const accountOwner = String(body?.accountOwner ?? "").trim();

    if (!branchId) return apiError("شعبه بانک الزامی است.", 400);
    if (!accountTypeId) return apiError("نوع حساب الزامی است.", 400);
    if (!accountNumber) return apiError("شماره حساب الزامی است.", 400);
    if (!accountOwner) return apiError("صاحب حساب الزامی است.", 400);

    const dup = await db.bankAccount.findUnique({ where: { accountNumber } });
    if (dup) return apiError("این شماره حساب قبلاً ثبت شده است.", 409);

    // اگر پیش‌فرض است، پیش‌فرض قبلی برداشته شود
    if (body?.isDefault) {
      await db.bankAccount.updateMany({ data: { isDefault: false } });
    }

    const account = await db.bankAccount.create({
      data: {
        branchId,
        accountTypeId,
        accountNumber,
        cardNumber: String(body?.cardNumber ?? "").trim() || null,
        shabaNumber: String(body?.shabaNumber ?? "").trim() || null,
        accountOwner,
        isDefault: Boolean(body?.isDefault),
        desc: String(body?.desc ?? "").trim() || null,
      },
      include: {
        branch: { include: { bank: { select: { id: true, name: true } } } },
        accountType: true,
      },
    });
    await db.activityLog.create({
      data: {
        userId: user.id, userName: `${user.firstName} ${user.lastName}`,
        action: "create", entity: "bankAccount", entityId: account.id, meta: accountNumber,
      },
    });
    return json(account, 201);
  });
}

// PATCH: ویرایش حساب
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requirePermission("banking", "edit");
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    if (!id) return apiError("شناسه حساب الزامی است.", 400);

    const existing = await db.bankAccount.findUnique({ where: { id } });
    if (!existing) return apiError("حساب یافت نشد.", 404);

    if (body?.isDefault) {
      await db.bankAccount.updateMany({ data: { isDefault: false } });
    }

    const account = await db.bankAccount.update({
      where: { id },
      data: {
        branchId: body?.branchId ? String(body.branchId) : existing.branchId,
        accountTypeId: body?.accountTypeId ? String(body.accountTypeId) : existing.accountTypeId,
        accountNumber: body?.accountNumber ? String(body.accountNumber).trim() : existing.accountNumber,
        cardNumber: body?.cardNumber !== undefined ? String(body.cardNumber).trim() || null : existing.cardNumber,
        shabaNumber: body?.shabaNumber !== undefined ? String(body.shabaNumber).trim() || null : existing.shabaNumber,
        accountOwner: body?.accountOwner ? String(body.accountOwner).trim() : existing.accountOwner,
        isDefault: body?.isDefault ?? existing.isDefault,
        desc: body?.desc !== undefined ? String(body.desc).trim() || null : existing.desc,
      },
      include: {
        branch: { include: { bank: { select: { id: true, name: true } } } },
        accountType: true,
      },
    });
    await db.activityLog.create({
      data: {
        userId: user.id, userName: `${user.firstName} ${user.lastName}`,
        action: "edit", entity: "bankAccount", entityId: id,
      },
    });
    return json(account);
  });
}

// DELETE: حذف حساب
export async function DELETE(req: Request) {
  return handle(async () => {
    const user = await requirePermission("banking", "delete");
    const url = new URL(req.url);
    const id = url.searchParams.get("id") ?? "";
    if (!id) return apiError("شناسه حساب الزامی است.", 400);

    await db.bankAccount.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id, userName: `${user.firstName} ${user.lastName}`,
        action: "delete", entity: "bankAccount", entityId: id,
      },
    });
    return json({ ok: true });
  });
}
