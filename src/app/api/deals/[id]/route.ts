import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

export async function GET(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    await requirePermission("deals", "view");
    const { id } = await params;
    const deal = await db.deal.findUnique({
      where: { id },
      include: {
        company: { select: { id: true, name: true } },
        contact: true,
        owner: { select: { id: true, firstName: true, lastName: true } },
        activities: {
          orderBy: { occurredAt: "desc" },
          take: 50,
          include: { user: { select: { firstName: true, lastName: true } } },
        },
        tasks: { include: { assignee: { select: { firstName: true, lastName: true } } } },
        quotations: { orderBy: { createdAt: "desc" } },
      },
    });
    if (!deal) return apiError("فرصت یافت نشد.", 404);
    return json(deal);
  });
}

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("deals", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.deal.findUnique({ where: { id } });
    if (!existing) return apiError("فرصت یافت نشد.", 404);

    const deal = await db.deal.update({
      where: { id },
      data: {
        title: String(body?.title ?? existing.title).trim(),
        companyId: clean(body?.companyId) ?? existing.companyId,
        contactId: clean(body?.contactId),
        stage: clean(body?.stage) ?? existing.stage,
        amount: numOrNull(body?.amount),
        probability: body?.probability ? Math.min(100, Math.max(0, Number(body.probability) || 0)) : null,
        priority: clean(body?.priority) ?? existing.priority,
        expectedCloseAt: dateOrNull(body?.expectedCloseAt),
        ownerId: clean(body?.ownerId) ?? existing.ownerId,
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "deal",
        entityId: id,
      },
    });
    return json(deal);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("deals", "delete");
    const { id } = await params;
    const used = await db.quotation.count({ where: { dealId: id } });
    if (used > 0) return apiError("برای این فرصت پیش‌فاکتور صادر شده است.", 409);
    await db.deal.delete({ where: { id } });
    await db.activityLog.create({
      data: { userId: user.id, userName: `${user.firstName} ${user.lastName}`, action: "delete", entity: "deal", entityId: id },
    });
    return json({ ok: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
function numOrNull(v: unknown): number | null {
  if (v === null || v === undefined || v === "") return null;
  const n = Number(v);
  return isNaN(n) ? null : n;
}
function dateOrNull(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(String(v));
  return isNaN(d.getTime()) ? null : d;
}
