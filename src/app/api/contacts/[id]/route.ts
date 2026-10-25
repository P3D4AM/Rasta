import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";

export async function PUT(
  req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("contacts", "edit");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const existing = await db.contact.findUnique({ where: { id } });
    if (!existing) return apiError("فرد یافت نشد.", 404);

    const contact = await db.contact.update({
      where: { id },
      data: {
        firstName: String(body?.firstName ?? existing.firstName).trim(),
        lastName: String(body?.lastName ?? existing.lastName).trim(),
        jobTitle: clean(body?.jobTitle),
        phone: clean(body?.phone),
        mobile: clean(body?.mobile),
        email: clean(body?.email),
        isPrimary: body?.isPrimary ?? existing.isPrimary,
        note: clean(body?.note),
      },
    });

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "contact",
        entityId: id,
      },
    });
    return json(contact);
  });
}

export async function DELETE(
  _req: Request,
  { params }: { params: Promise<{ id: string }> }
) {
  return handle(async () => {
    const user = await requirePermission("contacts", "delete");
    const { id } = await params;
    const used = await db.deal.count({ where: { contactId: id } });
    if (used > 0) return apiError("این فرد در فرصت‌های فروش استفاده شده است.", 409);
    await db.contact.delete({ where: { id } });
    await db.activityLog.create({
      data: { userId: user.id, userName: `${user.firstName} ${user.lastName}`, action: "delete", entity: "contact", entityId: id },
    });
    return json({ ok: true });
  });
}

function clean(v: unknown): string | null {
  const s = typeof v === "string" ? v.trim() : "";
  return s.length ? s : null;
}
