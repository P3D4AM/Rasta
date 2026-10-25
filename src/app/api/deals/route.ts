import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";
import { DEAL_STAGES } from "@/lib/constants";

// GET /api/deals — list with stage filter
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("deals", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const stage = url.searchParams.get("stage") ?? null;
    const mine = url.searchParams.get("mine") === "1";
    const userId = url.searchParams.get("userId");

    const where: Prisma.DealWhereInput = {
      ...(stage && stage !== "ALL" ? { stage } : {}),
      ...((mine || userId) ? { ownerId: userId ?? undefined } : {}),
      ...(search
        ? {
            OR: [
              { title: { contains: search } },
              { company: { is: { name: { contains: search } } } },
              { contact: { is: { firstName: { contains: search } } } },
              { contact: { is: { lastName: { contains: search } } } },
            ],
          }
        : {}),
    };

    const [rows, total, stageGroups] = await Promise.all([
      db.deal.findMany({
        where,
        orderBy: { updatedAt: "desc" },
        skip,
        take,
        include: {
          company: { select: { id: true, name: true } },
          contact: { select: { firstName: true, lastName: true } },
          owner: { select: { firstName: true, lastName: true } },
        },
      }),
      db.deal.count({ where }),
      db.deal.groupBy({
        by: ["stage"],
        _count: { _all: true },
        _sum: { amount: true },
      }),
    ]);

    const stages = Object.fromEntries(stageGroups.map((g) => [g.stage, { count: g._count._all, sum: g._sum.amount ?? 0 }]));

    return json({ rows, total, page, pageSize, stages });
  });
}

// POST /api/deals — create
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("deals", "create");
    const body = await req.json().catch(() => null);
    const title = String(body?.title ?? "").trim();
    const companyId = String(body?.companyId ?? "");
    if (!title) return apiError("عنوان فرصت الزامی است.", 400);
    if (!companyId) return apiError("انتخاب شرکت الزامی است.", 400);

    const company = await db.company.findUnique({ where: { id: companyId } });
    if (!company) return apiError("شرکت یافت نشد.", 404);

    const stage = DEAL_STAGES.includes(body?.stage) ? body.stage : "NEW";

    const deal = await db.deal.create({
      data: {
        title,
        companyId,
        contactId: clean(body?.contactId),
        stage,
        amount: numOrNull(body?.amount),
        probability: body?.probability ? Math.min(100, Math.max(0, Number(body.probability) || 0)) : null,
        priority: clean(body?.priority) ?? "NORMAL",
        expectedCloseAt: dateOrNull(body?.expectedCloseAt),
        ownerId: clean(body?.ownerId) ?? user.id,
      },
      include: {
        company: { select: { id: true, name: true } },
        owner: { select: { firstName: true, lastName: true } },
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "deal",
        entityId: deal.id,
        meta: title,
      },
    });
    return json(deal, 201);
  });
}

// PATCH /api/deals — bulk stage update (used by pipeline board)
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requirePermission("deals", "edit");
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    const stage = String(body?.stage ?? "");
    if (!id || !DEAL_STAGES.includes(stage as (typeof DEAL_STAGES)[number])) {
      return apiError("درخواست نامعتبر است.", 400);
    }

    const isClose = stage === "WON" || stage === "LOST";
    const deal = await db.deal.update({
      where: { id },
      data: {
        stage,
        ...(isClose ? { closedAt: new Date(), probability: stage === "WON" ? 100 : 0 } : {}),
        ...(stage === "WON" ? { closeNote: clean(body?.note) } : {}),
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: isClose ? `close-${stage.toLowerCase()}` : "stage-change",
        entity: "deal",
        entityId: id,
        meta: stage,
      },
    });
    return json(deal);
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
