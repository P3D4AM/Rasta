import { db } from "@/lib/db";
import { requirePermission, handle, json, parseListQuery } from "@/lib/http";

// GET /api/users — for pickers & management (admin)
export async function GET(req: Request) {
  return handle(async () => {
    const user = await requirePermission("users", "view");
    const { take, skip, page, pageSize, search } = parseListQuery(req, 500);
    const url = new URL(req.url);
    const light = url.searchParams.get("light") === "1";

    const users = await db.user.findMany({
      orderBy: { createdAt: "desc" },
      skip,
      take,
      where: search
        ? {
            OR: [
              { firstName: { contains: search } },
              { lastName: { contains: search } },
              { username: { contains: search } },
            ],
          }
        : {},
      select: light
        ? { id: true, firstName: true, lastName: true }
        : {
            id: true,
            username: true,
            firstName: true,
            lastName: true,
            email: true,
            phone: true,
            isAdmin: true,
            isActive: true,
            roleId: true,
            role: { select: { id: true, name: true } },
            lastLoginAt: true,
            createdAt: true,
          },
    });
    const total = await db.user.count();
    return json({ rows: users, total, page, pageSize, currentUserId: user.id });
  });
}

// POST /api/users — create user (admin)
export async function POST(req: Request) {
  return handle(async () => {
    const admin = await requirePermission("users", "create");
    const body = await req.json().catch(() => null);
    const username = String(body?.username ?? "").trim().toLowerCase();
    const password = String(body?.password ?? "");
    const firstName = String(body?.firstName ?? "").trim();
    const lastName = String(body?.lastName ?? "").trim();

    if (!username || !password || !firstName || !lastName) {
      return json({ error: "همه فیلدهای ستاره‌دار الزامی است." }, 400);
    }
    if (password.length < 6) {
      return json({ error: "رمز عبور باید حداقل ۶ کاراکتر باشد." }, 400);
    }
    const dup = await db.user.findUnique({ where: { username } });
    if (dup) return json({ error: "این نام کاربری قبلاً ثبت شده است." }, 409);

    const { hashPassword } = await import("@/lib/auth");
    const user = await db.user.create({
      data: {
        username,
        passwordHash: hashPassword(password),
        firstName,
        lastName,
        email: clean(body?.email),
        phone: clean(body?.phone),
        isAdmin: Boolean(body?.isAdmin) && admin.isAdmin,
        roleId: clean(body?.roleId),
      },
    });

    return json({ ...user, passwordHash: undefined }, 201);
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
