import { db } from "@/lib/db";
import { requireUser, handle, json } from "@/lib/http";

// GET /api/dashboard — KPI cards + charts + recent items
export async function GET() {
  return handle(async () => {
    const user = await requireUser();

    const now = new Date();
    const startOfMonth = new Date(now.getFullYear(), now.getMonth(), 1);
    const startOfToday = new Date(now.getFullYear(), now.getMonth(), now.getDate());

    const [
      totalCompanies,
      activeCompanies,
      totalProducts,
      openDeals,
      openDealsValue,
      wonThisMonth,
      wonThisMonthValue,
      lostThisMonth,
      activitiesToday,
      myOpenTasks,
      myOverdueTasks,
      stageGroups,
      recentActivities,
      monthlySales,
      myQuotationsCount,
    ] = await Promise.all([
      db.company.count(),
      db.company.count({ where: { status: "ACTIVE" } }),
      db.product.count(),
      db.deal.count({ where: { stage: { in: ["NEW", "CONTACTED", "PROPOSAL", "NEGOTIATION"] } } }),
      db.deal.aggregate({
        where: { stage: { in: ["NEW", "CONTACTED", "PROPOSAL", "NEGOTIATION"] } },
        _sum: { amount: true },
      }),
      db.deal.count({
        where: { stage: "WON", closedAt: { gte: startOfMonth } },
      }),
      db.deal.aggregate({
        where: { stage: "WON", closedAt: { gte: startOfMonth } },
        _sum: { amount: true },
      }),
      db.deal.count({
        where: { stage: "LOST", closedAt: { gte: startOfMonth } },
      }),
      db.activity.count({ where: { occurredAt: { gte: startOfToday } } }),
      db.task.count({ where: { assigneeId: user.id, status: "OPEN" } }),
      db.task.count({
        where: { assigneeId: user.id, status: "OPEN", dueAt: { lt: now } },
      }),
      db.deal.groupBy({
        by: ["stage"],
        _count: { _all: true },
        _sum: { amount: true },
      }),
      db.activity.findMany({
        orderBy: { occurredAt: "desc" },
        take: 8,
        include: {
          user: { select: { firstName: true, lastName: true } },
          company: { select: { id: true, name: true } },
        },
      }),
      db.salesOrder.groupBy({
        by: ["issueDate"],
        _sum: { total: true },
        where: { issueDate: { gte: new Date(now.getFullYear(), now.getMonth() - 5, 1) } },
      }),
      db.quotation.count({
        where: { ownerId: user.id, status: { in: ["DRAFT", "SENT"] } },
      }),
    ]);

    // last 6 months sales (grouped by month, computed in JS for simplicity)
    const salesByMonth: { label: string; total: number }[] = [];
    for (let i = 5; i >= 0; i--) {
      const start = new Date(now.getFullYear(), now.getMonth() - i, 1);
      const end = new Date(now.getFullYear(), now.getMonth() - i + 1, 1);
      const total = monthlySales
        .filter((r) => r.issueDate >= start && r.issueDate < end)
        .reduce((acc, r) => acc + (r._sum.total ?? 0), 0);
      salesByMonth.push({ label: `${i === 0 ? "" : "-"}${i}`, total: Math.round(total) });
    }

    const stages = Object.fromEntries(
      stageGroups.map((g) => [g.stage, { count: g._count._all, sum: g._sum.amount ?? 0 }])
    );

    return json({
      kpis: {
        totalCompanies,
        activeCompanies,
        totalProducts,
        openDeals,
        openDealsValue: openDealsValue._sum.amount ?? 0,
        wonThisMonth,
        wonThisMonthValue: wonThisMonthValue._sum.amount ?? 0,
        lostThisMonth,
        activitiesToday,
        myOpenTasks,
        myOverdueTasks,
        myQuotationsCount,
      },
      stages,
      salesByMonth,
      recentActivities,
    });
  });
}
