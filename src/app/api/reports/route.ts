import { db } from "@/lib/db";
import { requirePermission, handle, json } from "@/lib/http";

// GET /api/reports — sales & activity analytics
export async function GET() {
  return handle(async () => {
    await requirePermission("reports", "view");

    const now = new Date();

    const [
      salesByUser,
      dealsByStage,
      salesByCompanyTop,
      activitiesByType,
      dealsWonLostByMonth,
      ordersSummary,
    ] = await Promise.all([
      db.salesOrder.groupBy({
        by: ["ownerId"],
        _sum: { total: true },
        _count: { _all: true },
        where: { status: { not: "CANCELED" } },
      }),
      db.deal.groupBy({ by: ["stage"], _count: { _all: true }, _sum: { amount: true } }),
      db.salesOrder.findMany({
        where: { status: { not: "CANCELED" } },
        orderBy: { total: "desc" },
        take: 10,
        select: {
          id: true,
          number: true,
          total: true,
          issueDate: true,
          company: { select: { name: true } },
          owner: { select: { firstName: true, lastName: true } },
        },
      }),
      db.activity.groupBy({ by: ["type"], _count: { _all: true } }),
      db.deal.findMany({
        where: { closedAt: { not: null }, closedAt: { gte: new Date(now.getFullYear(), now.getMonth() - 5, 1) } },
        select: { stage: true, closedAt: true, amount: true },
      }),
      db.salesOrder.aggregate({
        where: { status: { not: "CANCELED" } },
        _sum: { total: true, paidTotal: true },
        _count: { _all: true },
      }),
    ]);

    const users = await db.user.findMany({
      select: { id: true, firstName: true, lastName: true },
    });
    const userMap = Object.fromEntries(users.map((u) => [u.id, `${u.firstName} ${u.lastName}`]));

    const wonLost: { month: string; won: number; lost: number }[] = [];
    for (let i = 5; i >= 0; i--) {
      const start = new Date(now.getFullYear(), now.getMonth() - i, 1);
      const end = new Date(now.getFullYear(), now.getMonth() - i + 1, 1);
      const rows = dealsWonLostByMonth.filter(
        (d) => d.closedAt && d.closedAt >= start && d.closedAt < end
      );
      wonLost.push({
        month: String(i),
        won: rows.filter((r) => r.stage === "WON").length,
        lost: rows.filter((r) => r.stage === "LOST").length,
      });
    }

    return json({
      salesByUser: salesByUser.map((r) => ({
        name: userMap[r.ownerId] ?? "—",
        total: Math.round(r._sum.total ?? 0),
        count: r._count._all,
      })),
      dealsByStage: dealsByStage.map((r) => ({
        stage: r.stage,
        count: r._count._all,
        sum: r._sum.amount ?? 0,
      })),
      topOrders: salesByCompanyTop,
      activitiesByType: activitiesByType.map((r) => ({ type: r.type, count: r._count._all })),
      wonLost,
      summary: {
        totalSales: Math.round(ordersSummary._sum.total ?? 0),
        totalPaid: Math.round(ordersSummary._sum.paidTotal ?? 0),
        orderCount: ordersSummary._count._all,
      },
    });
  });
}
