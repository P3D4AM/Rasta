import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * حساب بانکی کاربر — ویرایش/حذف (BankingAccountInsertEdit/BankingAccountDelete)
 * PUT/DELETE /api/users/[id]/bank-accounts/[accountId]
 */

export async function PUT(req: Request, { params }: { params: Promise<{ id: string; accountId: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actManageBankingAccounts");
    const { id, accountId } = await params;
    const acc = await db.bankAccount.findUnique({ where: { id: accountId } });
    if (!acc || acc.userId !== id) return apiError("حساب بانکی یافت نشد.", 404);
    const body = await req.json().catch(() => null);

    const accountNumber = String(body?.accountNumber ?? acc.accountNumber).trim();
    if (accountNumber !== acc.accountNumber) {
      const dup = await db.bankAccount.findUnique({ where: { accountNumber } });
      if (dup) return apiError("این شماره حساب قبلاً ثبت شده است.", 409);
    }
    const updated = await db.bankAccount.update({
      where: { id: accountId },
      data: {
        accountNumber,
        branchId: clean(body?.branchId) ?? acc.branchId,
        accountTypeId: clean(body?.accountTypeId) ?? acc.accountTypeId,
        cardNumber: clean(body?.cardNumber),
        shabaNumber: clean(body?.shabaNumber),
        accountOwner: String(body?.accountOwner ?? acc.accountOwner).trim(),
        isDefault: body?.isDefault !== undefined ? Boolean(body.isDefault) : acc.isDefault,
        desc: clean(body?.desc),
      },
    });
    return json(updated);
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string; accountId: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actManageBankingAccounts");
    const { id, accountId } = await params;
    const acc = await db.bankAccount.findUnique({ where: { id: accountId } });
    if (!acc || acc.userId !== id) return apiError("حساب بانکی یافت نشد.", 404);
    await db.bankAccount.delete({ where: { id: accountId } });
    return json({ deleted: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
