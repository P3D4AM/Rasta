import { db } from "@/lib/db";
import { requireUser, handle, json, apiError, parseListQuery } from "@/lib/http";
import { ACTIVITY_TYPES } from "@/lib/constants";
import { Prisma } from "@prisma/client";

// GET /api/activities — timeline with filters
export async function GET(req: Request) {
  return handle(async () => {
    const user = await requireUser();
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const type = url.searchParams.get("type");
    const companyId = url.searchParams.get("companyId");
    const dealId = url.searchParams.get("dealId");
    const mine = url.searchParams.get("mine") === "1";

    const where: Prisma.ActivityWhereInput = {
      ...(type && type !== "ALL" ? { type } : {}),
      ...(companyId ? { companyId } : {}),
      ...(dealId ? { dealId } : {}),
      ...(mine ? { userId: user.id } : {}),
      ...(search ? { subject: { contains: search } } : {}),
    };

    const [rows, total] = await Promise.all([
      db.activity.findMany({
        where,
        orderBy: { occurredAt: "desc" },
        skip,
        take,
        include: {
          user: { select: { firstName: true, lastName: true } },
          company: { select: { id: true, name: true } },
          contact: { select: { firstName: true, lastName: true } },
          deal: { select: { id: true, title: true } },
        },
      }),
      db.activity.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/activities — log an interaction
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requireUser();
    const body = await req.json().catch(() => null);
    const subject = String(body?.subject ?? "").trim();
    if (!subject) return apiError("موضوع فعالیت الزامی است.", 400);

    const type = ACTIVITY_TYPES.includes(body?.type) ? body.type : "NOTE";

    let occurredAt = new Date();
    if (body?.occurredAt) {
      const d = new Date(String(body.occurredAt));
      if (!isNaN(d.getTime())) occurredAt = d;
    }

    const activity = await db.activity.create({
      data: {
        type,
        direction: clean(body?.direction),
        subject,
        body: clean(body?.body),
        companyId: clean(body?.companyId),
        contactId: clean(body?.contactId),
        dealId: clean(body?.dealId),
        userId: user.id,
        occurredAt,
        nextStep: clean(body?.nextStep),
        nextAt: dateOrNull(body?.nextAt),
      },
      include: {
        user: { select: { firstName: true, lastName: true } },
        company: { select: { id: true, name: true } },
      },
    });

    return json(activity, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
function dateOrNull(v: unknown): Date | null {
  if (!v) return null;
  const d = new Date(String(v));
  return isNaN(d.getTime()) ? null : d;
}
