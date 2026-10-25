import { db } from "@/lib/db";
import { requirePerm, handle, json } from "@/lib/http";

/**
 * کارتابل یادآور پروژه‌ها — بازسازی _PartialReminderProject (CRMspSelectCompanyProjectFromRemindDate)
 * پروژه‌های جاری با تاریخ یادآوری رسیده یا گذشته، مرتب از قدیمی‌ترین.
 */
export async function GET(req: Request) {
  return handle(async () => {
    await requirePerm("frmTasks", "actView");
    const url = new URL(req.url);
    const onlyMine = url.searchParams.get("mine") === "1";
    const user = await (await import("@/lib/auth")).getCurrentUser();

    const endOfToday = new Date();
    endOfToday.setHours(23, 59, 59, 999);

    const rows = await db.project.findMany({
      where: {
        isFinished: false,
        remindDate: { lte: endOfToday },
        ...(onlyMine && user ? { OR: [{ starterUserId: user.id }, { registeredById: user.id }] } : {}),
      },
      orderBy: { remindDate: "asc" },
      take: 100,
      include: {
        priority: true,
        grade: true,
        group: true,
        company: { select: { id: true, name: true, econCode: true, province: true, city: true } },
        starter: { select: { firstName: true, lastName: true } },
        registeredBy: { select: { firstName: true, lastName: true } },
        conversations: { orderBy: { cnvsDate: "desc" }, take: 1, include: { status: true } },
      },
    });

    return json({
      rows: rows.map((p) => ({
        id: p.id,
        number: p.number,
        title: p.postFix ? `${p.title} - ${p.postFix}` : p.title,
        remindDate: p.remindDate,
        isTicket: p.isTicket,
        ticketStop: p.ticketStop,
        companyName: p.company.name,
        companyCode: p.company.econCode,
        province: p.company.province,
        city: p.company.city,
        groupName: p.group?.name ?? null,
        gradeName: p.grade?.name ?? null,
        priorityName: p.priority?.name ?? null,
        priorityColor: p.priority?.color ?? null,
        starterName: p.starter ? `${p.starter.firstName} ${p.starter.lastName}` : null,
        registeredByName: p.registeredBy ? `${p.registeredBy.firstName} ${p.registeredBy.lastName}` : null,
        lastStatusName: p.conversations[0]?.status.name ?? null,
        lastStatusPercent: p.conversations[0]?.status.progressPercent ?? 0,
      })),
    });
  });
}
