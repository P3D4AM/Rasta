import { db } from "@/lib/db";
import { requirePerm, handle, json } from "@/lib/http";

/** نمایش جزئیات تعداد کاربران — ShowDetailsUserCount خود محصول (بدون سقف لایسنس؛ لایسنس در رستا فعال نیست) */
export async function GET() {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actShowDetailsUserCount");
    const [total, active, inactive, admins] = await Promise.all([
      db.user.count(),
      db.user.count({ where: { isActive: true } }),
      db.user.count({ where: { isActive: false } }),
      db.user.count({ where: { isAdmin: true } }),
    ]);
    const byRole = await db.role.findMany({
      select: { id: true, name: true, _count: { select: { users: true } } },
      orderBy: { name: "asc" },
    });
    return json({
      total,
      active,
      inactive,
      admins,
      byRole: byRole.map((r) => ({ name: r.name, count: r._count.users })),
    });
  });
}
