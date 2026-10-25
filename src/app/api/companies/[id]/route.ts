import { db } from "@/lib/db";
import { requirePermission } from "@/lib/http";
import { handle, json, apiError } from "@/lib/http";

// GET /api/companies/[id] — full detail with related lists
export async function GET(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("companies", "view");
    const { id } = await params;
    const company = await db.company.findUnique({
      where: { id },
      include: {
        owner: { select: { firstName: true, lastName: true } },
        contacts: { orderBy: { isPrimary: "desc" }, take: 100 },
        deals: {
          orderBy: { createdAt: "desc" },
          take: 50,
          include: { owner: { select: { firstName: true, lastName: true } } },
        },
        activities: {
          orderBy: { occurredAt: "desc" },
          take: 50,
          include: { user: { select: { firstName: true, lastName: true } } },
        },
        tasks: {
          where: { status: { not: "DONE" } },
          orderBy: { dueAt: "asc" },
          take: 30,
          include: { assignee: { select: { firstName: true, lastName: true } } },
        },
        quotations: {
          orderBy: { createdAt: "desc" },
          take: 30,
          include: { _count: { select: { items: true } } },
        },
        orders: {
          orderBy: { createdAt: "desc" },
          take: 30,
          include: { _count: { select: { items: true, payments: true } } },
        },
      },
    });
    if (!company) return apiError("شرکت یافت نشد.", 404);
    return json(company);
  });
}

// PUT /api/companies/[id]
export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("companies", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);

    const existing = await db.company.findUnique({ where: { id } });
    if (!existing) return apiError("شرکت یافت نشد.", 404);

    const company = await db.company.update({
      where: { id },
      data: {
        name: String(body?.name ?? existing.name).trim(),
        nameEn: clean(body?.nameEn),
        type: clean(body?.type) ?? existing.type,
        industry: clean(body?.industry),
        taxId: clean(body?.taxId),
        econCode: clean(body?.econCode),
        phone: clean(body?.phone),
        email: clean(body?.email),
        website: clean(body?.website),
        province: clean(body?.province),
        city: clean(body?.city),
        address: clean(body?.address),
        description: clean(body?.description),
        status: clean(body?.status) ?? existing.status,
        ownerId: clean(body?.ownerId) ?? existing.ownerId,
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "company",
        entityId: id,
        meta: company.name,
      },
    });
    return json(company);
  });
}

// DELETE /api/companies/[id]
export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("companies", "delete");
    const { id } = await params;

    const counts = await db.company.findUnique({
      where: { id },
      select: {
        _count: { select: { deals: true, quotations: true, orders: true, activities: true } },
      },
    });
    if (!counts) return apiError("شرکت یافت نشد.", 404);
    const blocked =
      counts._count.deals > 0 ||
      counts._count.quotations > 0 ||
      counts._count.orders > 0;
    if (blocked) {
      return apiError(
        "این شرکت فرصت فروش، پیش‌فاکتور یا فاکتور ثبت‌شده دارد و قابل حذف نیست. ابتدا سوابق مالی را حذف کنید.",
        409
      );
    }

    await db.company.delete({ where: { id } });
    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "delete",
        entity: "company",
        entityId: id,
      },
    });
    return json({ ok: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
