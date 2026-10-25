import { db } from "@/lib/db";
import { requireUser, handle, json, apiError } from "@/lib/http";

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requireUser();
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.task.findUnique({ where: { id } });
    if (!existing) return apiError("وظیفه یافت نشد.", 404);
    if (existing.assigneeId !== user.id && existing.creatorId !== user.id && !user.isAdmin) {
      return apiError("اجازه ویرایش این وظیفه را ندارید.", 403);
    }

    const task = await db.task.update({
      where: { id },
      data: {
        title: String(body?.title ?? existing.title).trim(),
        description: clean(body?.description),
        dueAt: dateOrNull(body?.dueAt),
        priority: clean(body?.priority) ?? existing.priority,
        status: clean(body?.status) ?? existing.status,
        doneAt: body?.status === "DONE" ? (existing.doneAt ?? new Date()) : null,
      },
    });
    return json(task);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requireUser();
    const { id } = await params;
    const existing = await db.task.findUnique({ where: { id } });
    if (!existing) return apiError("وظیفه یافت نشد.", 404);
    if (existing.assigneeId !== user.id && existing.creatorId !== user.id && !user.isAdmin) {
      return apiError("اجازه حذف این وظیفه را ندارید.", 403);
    }
    await db.task.delete({ where: { id } });
    return json({ ok: true });
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
