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
    const existing = await db.activity.findUnique({ where: { id } });
    if (!existing) return apiError("فعالیت یافت نشد.", 404);
    if (existing.userId !== user.id && !user.isAdmin) {
      return apiError("فقط ثبت‌کننده فعالیت می‌تواند آن را ویرایش کند.", 403);
    }

    const activity = await db.activity.update({
      where: { id },
      data: {
        type: clean(body?.type) ?? existing.type,
        direction: clean(body?.direction),
        subject: String(body?.subject ?? existing.subject).trim(),
        body: clean(body?.body),
        nextStep: clean(body?.nextStep),
        nextAt: dateOrNull(body?.nextAt),
      },
    });
    return json(activity);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requireUser();
    const { id } = await params;
    const existing = await db.activity.findUnique({ where: { id } });
    if (!existing) return apiError("فعالیت یافت نشد.", 404);
    if (existing.userId !== user.id && !user.isAdmin) {
      return apiError("فقط ثبت‌کننده فعالیت می‌تواند آن را حذف کند.", 403);
    }
    await db.activity.delete({ where: { id } });
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
