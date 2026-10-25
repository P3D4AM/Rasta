import { db } from "@/lib/db";
import { requirePermission } from "@/lib/http";
import { handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";

// GET /api/companies — paginated, searchable list
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("companies", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const type = url.searchParams.get("type") ?? null;
    const status = url.searchParams.get("status") ?? null;

    const where: Prisma.CompanyWhereInput = {
      ...(type && type !== "ALL" ? { type } : {}),
      ...(status && status !== "ALL" ? { status } : {}),
      ...(search
        ? {
            OR: [
              { name: { contains: search } },
              { nameEn: { contains: search } },
              { phone: { contains: search } },
              { email: { contains: search } },
              { taxId: { contains: search } },
              { city: { contains: search } },
            ],
          }
        : {}),
    };

    const [rows, total] = await Promise.all([
      db.company.findMany({
        where,
        orderBy: { createdAt: "desc" },
        skip,
        take,
        include: {
          _count: { select: { contacts: true, deals: true, orders: true } },
          owner: { select: { firstName: true, lastName: true } },
        },
      }),
      db.company.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/companies — create
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("companies", "create");
    const body = await req.json().catch(() => null);
    const name = String(body?.name ?? "").trim();
    if (!name) return apiError("نام شرکت الزامی است.", 400);

    const company = await db.company.create({
      data: {
        name,
        nameEn: strOrNull(body.nameEn),
        type: strOrNull(body.type) ?? "CUSTOMER",
        industry: strOrNull(body.industry),
        taxId: strOrNull(body.taxId),
        econCode: strOrNull(body.econCode),
        phone: strOrNull(body.phone),
        email: strOrNull(body.email),
        website: strOrNull(body.website),
        province: strOrNull(body.province),
        city: strOrNull(body.city),
        address: strOrNull(body.address),
        description: strOrNull(body.description),
        ownerId: user.id,
      },
    });

    await logActivity(user, "create", "company", company.id, name);
    return json(company, 201);
  });
}

function strOrNull(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}

async function logActivity(
  user: { id: string; username: string; firstName: string; lastName: string },
  action: string,
  entity: string,
  entityId: string,
  title?: string
) {
  await db.activityLog.create({
    data: {
      userId: user.id,
      userName: `${user.firstName} ${user.lastName}`,
      action,
      entity,
      entityId,
      meta: title,
    },
  });
}
