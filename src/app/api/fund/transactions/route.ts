import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";

/**
 * /api/fund/transactions — اسناد خزانه (رسید/پرداخت)
 * بازسازی Fund/HomeController: Fund_Read (فیلتر کاربر/تاریخ/گروه) + GetFundSumFooter
 * + InsertEdit + VerifyFund/ExitFromVerifyFund
 */

const INCLUDE = {
  group: true,
  custodian: { select: { id: true, firstName: true, lastName: true, username: true } },
  verifier: { select: { id: true, firstName: true, lastName: true } },
  createdBy: { select: { id: true, firstName: true, lastName: true } },
} satisfies Prisma.FundTransactionInclude;

// GET: لیست اسناد + جمع دریافتی/پرداختی/مانده (فوتر مثل GetFundSumFooter)
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("fund", "view");
    const { take, skip, page, pageSize } = parseListQuery(req, 50);
    const url = new URL(req.url);
    const groupId = url.searchParams.get("groupId");
    const type = url.searchParams.get("type");
    const from = url.searchParams.get("from");
    const to = url.searchParams.get("to");
    const verified = url.searchParams.get("verified");

    const where: Prisma.FundTransactionWhereInput = {
      ...(groupId && groupId !== "all" ? { groupId } : {}),
      ...(type && type !== "all" ? { type } : {}),
      ...(verified === "1" ? { isVerified: true } : verified === "0" ? { isVerified: false } : {}),
      ...(from || to
        ? {
            date: {
              ...(from ? { gte: new Date(from) } : {}),
              ...(to ? { lte: new Date(`${to}T23:59:59`) } : {}),
            },
          }
        : {}),
    };

    const [rows, total, all] = await Promise.all([
      db.fundTransaction.findMany({
        where,
        include: INCLUDE,
        orderBy: [{ date: "desc" }, { number: "desc" }],
        skip,
        take,
      }),
      db.fundTransaction.count({ where }),
      db.fundTransaction.findMany({ where, select: { type: true, amount: true } }),
    ]);

    // جمع فوتر (GetFundSumFooter): دریافت − پرداخت = مانده
    const totalReceive = all.filter((r) => r.type === "RECEIVE").reduce((s, r) => s + r.amount, 0);
    const totalPay = all.filter((r) => r.type === "PAY").reduce((s, r) => s + r.amount, 0);

    return json({
      rows,
      total,
      page,
      pageSize,
      footer: { totalReceive, totalPay, remain: totalReceive - totalPay },
    });
  });
}

// POST: ثبت سند جدید (InsertEdit — شماره سند خودکار مثل FundNumber)
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("fund", "create");
    const body = await req.json().catch(() => null);
    const groupId = String(body?.groupId ?? "");
    const type = String(body?.type ?? "");
    const amount = Number(body?.amount ?? 0);
    const dateStr = String(body?.date ?? "");

    if (!groupId) return apiError("گروه خزانه الزامی است.", 400);
    if (type !== "RECEIVE" && type !== "PAY") return apiError("نوع سند نامعتبر است.", 400);
    if (!(amount > 0)) return apiError("مبلغ باید بزرگ‌تر از صفر باشد.", 400);
    const date = dateStr ? new Date(dateStr) : new Date();
    if (isNaN(date.getTime())) return apiError("تاریخ سند نامعتبر است.", 400);

    const last = await db.fundTransaction.findFirst({ orderBy: { number: "desc" }, select: { number: true } });

    const row = await db.fundTransaction.create({
      data: {
        number: (last?.number ?? 0) + 1,
        groupId,
        custodianId: body?.custodianId ? String(body.custodianId) : user.id,
        type,
        amount,
        date,
        description: String(body?.description ?? "").trim() || null,
        createdById: user.id,
      },
      include: INCLUDE,
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "fundTransaction",
        entityId: row.id,
        meta: `سند ${row.number} — ${type === "RECEIVE" ? "دریافت" : "پرداخت"} ${amount}`,
      },
    });
    return json(row, 201);
  });
}

// PATCH: ویرایش سند یا تایید/لغو تایید (VerifyFund / ExitFromVerifyFund)
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requirePermission("fund", "edit");
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    if (!id) return apiError("شناسه سند الزامی است.", 400);

    const existing = await db.fundTransaction.findUnique({ where: { id } });
    if (!existing) return apiError("سند یافت نشد.", 404);

    // حالت تایید/لغو تایید (action=verify | unverify)
    const action = String(body?.action ?? "");
    if (action === "verify" || action === "unverify") {
      const row = await db.fundTransaction.update({
        where: { id },
        data: {
          isVerified: action === "verify",
          verifiedById: action === "verify" ? user.id : null,
          verifiedAt: action === "verify" ? new Date() : null,
        },
        include: INCLUDE,
      });
      await db.activityLog.create({
        data: {
          userId: user.id,
          userName: `${user.firstName} ${user.lastName}`,
          action: action === "verify" ? "verify" : "unverify",
          entity: "fundTransaction",
          entityId: id,
          meta: `سند ${row.number}`,
        },
      });
      return json(row);
    }

    // ویرایش کامل
    const amount = Number(body?.amount ?? existing.amount);
    if (!(amount > 0)) return apiError("مبلغ باید بزرگ‌تر از صفر باشد.", 400);
    const dateStr = String(body?.date ?? "");
    const date = dateStr ? new Date(dateStr) : existing.date;

    const row = await db.fundTransaction.update({
      where: { id },
      data: {
        groupId: body?.groupId ? String(body.groupId) : existing.groupId,
        type: body?.type === "RECEIVE" || body?.type === "PAY" ? body.type : existing.type,
        amount,
        date: isNaN(date.getTime()) ? existing.date : date,
        description: body?.description !== undefined ? String(body.description).trim() || null : existing.description,
      },
      include: INCLUDE,
    });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "fundTransaction",
        entityId: id,
        meta: `سند ${row.number}`,
      },
    });
    return json(row);
  });
}

// DELETE: حذف سند
export async function DELETE(req: Request) {
  return handle(async () => {
    const user = await requirePermission("fund", "delete");
    const url = new URL(req.url);
    const id = url.searchParams.get("id") ?? "";
    if (!id) return apiError("شناسه سند الزامی است.", 400);

    await db.fundTransaction.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "fundTransaction",
        entityId: id,
      },
    });
    return json({ ok: true });
  });
}
