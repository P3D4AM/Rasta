import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

/**
 * /api/banking/banks — بانک‌ها و شعب
 * بازسازی Banking/HomeController (Index بانک‌ها + Branch شعب)
 */

// GET: لیست بانک‌ها همراه شعب
export async function GET() {
  return handle(async () => {
    await requirePermission("banking", "view");
    const banks = await db.bank.findMany({
      orderBy: { name: "asc" },
      include: { branches: { orderBy: { name: "asc" } } },
    });
    return json({ rows: banks });
  });
}

// POST: ایجاد بانک یا شعبه (type=branch → شعبه)
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("banking", "create");
    const body = await req.json().catch(() => null);

    if (body?.type === "branch") {
      const bankId = String(body.bankId ?? "");
      const name = String(body.name ?? "").trim();
      if (!bankId || !name) return apiError("بانک و نام شعبه الزامی است.", 400);
      const branch = await db.bankBranch.create({
        data: { bankId, name, tel: String(body.tel ?? "").trim() || null },
      });
      await db.activityLog.create({
        data: {
          userId: user.id, userName: `${user.firstName} ${user.lastName}`,
          action: "create", entity: "bankBranch", entityId: branch.id, meta: name,
        },
      });
      return json(branch, 201);
    }

    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام بانک الزامی است.", 400);
    const bank = await db.bank.create({
      data: { name, code: String(body.code ?? "").trim() || null, desc: String(body.desc ?? "").trim() || null },
    });
    await db.activityLog.create({
      data: {
        userId: user.id, userName: `${user.firstName} ${user.lastName}`,
        action: "create", entity: "bank", entityId: bank.id, meta: name,
      },
    });
    return json(bank, 201);
  });
}

// PATCH: ویرایش بانک یا شعبه
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requirePermission("banking", "edit");
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    if (!id) return apiError("شناسه الزامی است.", 400);

    if (body?.type === "branch") {
      const name = String(body.name ?? "").trim();
      if (!name) return apiError("نام شعبه الزامی است.", 400);
      const branch = await db.bankBranch.update({
        where: { id },
        data: { name, tel: String(body.tel ?? "").trim() || null },
      });
      await db.activityLog.create({
        data: {
          userId: user.id, userName: `${user.firstName} ${user.lastName}`,
          action: "edit", entity: "bankBranch", entityId: id, meta: name,
        },
      });
      return json(branch);
    }

    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام بانک الزامی است.", 400);
    const bank = await db.bank.update({
      where: { id },
      data: {
        name,
        code: String(body.code ?? "").trim() || null,
        desc: String(body.desc ?? "").trim() || null,
      },
    });
    await db.activityLog.create({
      data: {
        userId: user.id, userName: `${user.firstName} ${user.lastName}`,
        action: "edit", entity: "bank", entityId: id, meta: name,
      },
    });
    return json(bank);
  });
}

// DELETE: حذف بانک (با شعب/حساب‌ها) یا شعبه
export async function DELETE(req: Request) {
  return handle(async () => {
    const user = await requirePermission("banking", "delete");
    const url = new URL(req.url);
    const id = url.searchParams.get("id") ?? "";
    const type = url.searchParams.get("type") ?? "bank";
    if (!id) return apiError("شناسه الزامی است.", 400);

    if (type === "branch") {
      const accCount = await db.bankAccount.count({ where: { branchId: id } });
      if (accCount > 0) return apiError("این شعبه دارای حساب است و قابل حذف نیست.", 409);
      await db.bankBranch.delete({ where: { id } });
    } else {
      await db.bank.delete({ where: { id } }); // Cascade: شعب و حساب‌ها
    }
    await db.activityLog.create({
      data: {
        userId: user.id, userName: `${user.firstName} ${user.lastName}`,
        action: "delete", entity: type === "branch" ? "bankBranch" : "bank", entityId: id,
      },
    });
    return json({ ok: true });
  });
}
