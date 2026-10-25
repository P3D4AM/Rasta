import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";

// GET /api/orders — sales invoices
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("orders", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const status = url.searchParams.get("status");
    const companyId = url.searchParams.get("companyId");

    const where: Prisma.SalesOrderWhereInput = {
      ...(status && status !== "ALL" ? { status } : {}),
      ...(companyId ? { companyId } : {}),
      ...(search ? { company: { is: { name: { contains: search } } } } : {}),
    };

    const [rows, total] = await Promise.all([
      db.salesOrder.findMany({
        where,
        orderBy: { createdAt: "desc" },
        skip,
        take,
        include: {
          company: { select: { id: true, name: true } },
          owner: { select: { firstName: true, lastName: true } },
          _count: { select: { items: true, payments: true } },
        },
      }),
      db.salesOrder.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/orders — direct create (manual invoice, without quotation)
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("orders", "create");
    const body = await req.json().catch(() => null);
    const companyId = String(body?.companyId ?? "");
    if (!companyId) return apiError("انتخاب شرکت الزامی است.", 400);

    const company = await db.company.findUnique({ where: { id: companyId } });
    if (!company) return apiError("شرکت یافت نشد.", 404);

    const { calcTotals } = await import("../quotations/route");
    const items = Array.isArray(body?.items) ? body.items : [];
    if (items.length === 0) return apiError("حداقل یک ردیف کالا وارد کنید.", 400);
    const totals = calcTotals(items);

    const last = await db.salesOrder.findFirst({ orderBy: { number: "desc" }, select: { number: true } });
    const number = (last?.number ?? 1000) + 1;

    const order = await db.salesOrder.create({
      data: {
        number,
        companyId,
        issueDate: body?.issueDate ? new Date(String(body.issueDate)) : new Date(),
        status: clean(body?.status) ?? "DRAFT",
        note: clean(body?.note),
        ownerId: user.id,
        subtotal: totals.subtotal,
        discountTotal: totals.discountTotal,
        taxTotal: totals.taxTotal,
        total: totals.total,
        items: { create: totals.items },
      },
      include: { company: { select: { id: true, name: true } } },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "order",
        entityId: order.id,
        meta: `فاکتور شماره ${number}`,
      },
    });
    return json(order, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
