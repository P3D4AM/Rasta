import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/** توقف/ادامه تیکت — prjTicketStop + ثبت کاربر و تاریخ (actCanSetPrjTicketStop) */
export async function PATCH(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    const user = await requirePerm("frmDefineProjects", "actCanSetPrjIsTicket");
    const { id } = await params;
    const body = await req.json().catch(() => null);
    const project = await db.project.findUnique({ where: { id } });
    if (!project) return apiError("پروژه یافت نشد.", 404);
    if (!project.isTicket) return apiError("این پروژه تیکت نیست.", 400);

    const stop = Boolean(body?.stop);
    if (stop === project.ticketStop) return json(project);

    const updated = await db.project.update({
      where: { id },
      data: stop
        ? { ticketStop: true, ticketStopUserId: user.id, ticketStopDate: new Date(), lastEditedById: user.id }
        : { ticketStop: false, ticketStopUserId: null, ticketStopDate: null, lastEditedById: user.id },
    });
    return json(updated);
  });
}
