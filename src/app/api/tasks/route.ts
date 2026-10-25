import { db } from "@/lib/db";
import { requireUser, handle, json, apiError, parseListQuery } from "@/lib/http";
import { Prisma } from "@prisma/client";

// GET /api/tasks — cartable (my tasks + all if permission)
export async function GET(req: Request) {
  return handle(async () => {
    const user = await requireUser();
    const { take, skip, page, pageSize, search } = parseListQuery(req);
    const url = new URL(req.url);
    const status = url.searchParams.get("status") ?? "OPEN";
    const scope = url.searchParams.get("scope") ?? "mine"; // mine | all

    const canSeeAll =
      user.isAdmin ||
      (user.permissions["tasks"] && Object.values(user.permissions["tasks"]).some(Boolean)) ||
      (user.permissions["users"] && Object.values(user.permissions["users"]).some(Boolean));

    const where: Prisma.TaskWhereInput = {
      ...(status !== "ALL" ? { status } : {}),
      ...(scope === "mine" || !canSeeAll ? { assigneeId: user.id } : {}),
      ...(search ? { title: { contains: search } } : {}),
    };

    const [rows, total, openCount, overdueCount] = await Promise.all([
      db.task.findMany({
        where,
        orderBy: [{ dueAt: "asc" }, { createdAt: "desc" }],
        skip,
        take,
        include: {
          assignee: { select: { firstName: true, lastName: true } },
          creator: { select: { firstName: true, lastName: true } },
          company: { select: { id: true, name: true } },
          deal: { select: { id: true, title: true } },
        },
      }),
      db.task.count({ where }),
      db.task.count({ where: { assigneeId: user.id, status: "OPEN" } }),
      db.task.count({
        where: {
          assigneeId: user.id,
          status: "OPEN",
          dueAt: { lt: new Date() },
        },
      }),
    ]);

    return json({ rows, total, page, pageSize, openCount, overdueCount });
  });
}

// POST /api/tasks — create (assign to self or others)
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requireUser();
    const body = await req.json().catch(() => null);
    const title = String(body?.title ?? "").trim();
    if (!title) return apiError("عنوان وظیفه الزامی است.", 400);

    const assigneeId = String(body?.assigneeId ?? user.id);
    const assignee = await db.user.findUnique({ where: { id: assigneeId } });
    if (!assignee) return apiError("کاربر تعیین‌شده یافت نشد.", 404);

    const task = await db.task.create({
      data: {
        title,
        description: clean(body?.description),
        dueAt: dateOrNull(body?.dueAt),
        priority: clean(body?.priority) ?? "NORMAL",
        assigneeId,
        creatorId: user.id,
        companyId: clean(body?.companyId),
        dealId: clean(body?.dealId),
      },
      include: {
        assignee: { select: { firstName: true, lastName: true } },
        company: { select: { id: true, name: true } },
      },
    });

    return json(task, 201);
  });
}

// PATCH /api/tasks/[id] handled via [id] route; PATCH bulk not needed.
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requireUser();
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    const done = Boolean(body?.done);
    if (!id) return apiError("شناسه وظیفه الزامی است.", 400);

    const task = await db.task.findUnique({ where: { id } });
    if (!task) return apiError("وظیفه یافت نشد.", 404);

    const updated = await db.task.update({
      where: { id },
      data: {
        status: done ? "DONE" : "OPEN",
        doneAt: done ? new Date() : null,
      },
    });
    return json(updated);
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
