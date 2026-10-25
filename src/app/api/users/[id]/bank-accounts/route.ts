import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * حساب‌های بانکی کاربر — بازسازی UserBankingAccounts_Read + BankingAccountInsertEdit/Delete
 * GET  → لیست حساب‌های کاربر (با بانک/شعبه/نوع)
 * POST → افزودن حساب برای کاربر
 */

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actManageBankingAccounts");
    const { id } = await params;
    const rows = await db.bankAccount.findMany({
      where: { userId: id },
      include: {
        accountType: true,
        branch: { include: { bank: true } },
      },
    });
    return json({
      rows: rows.map((r) => ({
        id: r.id,
        accountTypeName: r.accountType.name,
        accountTitle: r.accountOwner,
        accountNumber: r.accountNumber,
        shabaNumber: r.shabaNumber,
        cardNumber: r.cardNumber,
        bankName: r.branch?.bank?.name ?? null,
        branchName: r.branch?.name ?? null,
        isDefault: r.isDefault,
        desc: r.desc,
      })),
    });
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actManageBankingAccounts");
    const { id } = await params;
    const user = await db.user.findUnique({ where: { id } });
    if (!user) return apiError("کاربر یافت نشد.", 404);
    const body = await req.json().catch(() => null);
    const accountNumber = String(body?.accountNumber ?? "").trim();
    const branchId = String(body?.branchId ?? "").trim();
    const accountTypeId = String(body?.accountTypeId ?? "").trim();
    const accountOwner = String(body?.accountOwner ?? "").trim() || `${user.firstName} ${user.lastName}`;
    if (!accountNumber || !branchId || !accountTypeId) {
      return apiError("شماره حساب، شعبه و نوع حساب الزامی است.", 400);
    }
    const dup = await db.bankAccount.findUnique({ where: { accountNumber } });
    if (dup) return apiError("این شماره حساب قبلاً ثبت شده است.", 409);
    const created = await db.bankAccount.create({
      data: {
        branchId,
        accountTypeId,
        accountNumber,
        cardNumber: clean(body?.cardNumber),
        shabaNumber: clean(body?.shabaNumber),
        accountOwner,
        isDefault: Boolean(body?.isDefault),
        desc: clean(body?.desc),
        userId: id,
      },
    });
    return json(created, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
