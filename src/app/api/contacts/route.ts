import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";

// GET /api/contacts
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("contacts", "view");
    const { take, skip, pageSize, page, search } = parseListQuery(req);
    const url = new URL(req.url);
    const companyId = url.searchParams.get("companyId");

    const where: Prisma.ContactWhereInput = {
      ...(companyId ? { companyId } : {}),
      ...(search
        ? {
            OR: [
              { firstName: { contains: search } },
              { lastName: { contains: search } },
              { mobile: { contains: search } },
              { email: { contains: search } },
              { jobTitle: { contains: search } },
              { company: { is: { name: { contains: search } } } },
            ],
          }
        : {}),
    };

    const [rows, total] = await Promise.all([
      db.contact.findMany({
        where,
        orderBy: { createdAt: "desc" },
        skip,
        take,
        include: { company: { select: { id: true, name: true } } },
      }),
      db.contact.count({ where }),
    ]);

    return json({ rows, total, page, pageSize });
  });
}

// POST /api/contacts
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("contacts", "create");
    const body = await req.json().catch(() => null);
    const companyId = String(body?.companyId ?? "");
    const firstName = String(body?.firstName ?? "").trim();
    const lastName = String(body?.lastName ?? "").trim();
    if (!companyId) return apiError("انتخاب شرکت الزامی است.", 400);
    if (!firstName || !lastName) return apiError("نام و نام خانوادگی الزامی است.", 400);

    const company = await db.company.findUnique({ where: { id: companyId } });
    if (!company) return apiError("شرکت یافت نشد.", 404);

    const contact = await db.contact.create({
      data: {
        companyId,
        firstName,
        lastName,
        jobTitle: clean(body?.jobTitle),
        phone: clean(body?.phone),
        mobile: clean(body?.mobile),
        email: clean(body?.email),
        isPrimary: Boolean(body?.isPrimary),
        note: clean(body?.note),
      },
      include: { company: { select: { id: true, name: true } } },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "contact",
        entityId: contact.id,
        meta: `${firstName} ${lastName}`,
      },
    });
    return json(contact, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
