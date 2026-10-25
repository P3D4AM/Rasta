import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/project-defs/[entity] — تعاریف پایه پروژه‌ها (فرم‌های تعریف خود CRMIdeal با مجوز frmMain/actDefine*)
 * entity ∈ titles | titleGroups | groups | grades | priorities | categories | statusGroups | statuses
 */

type EntityConf = {
  list: () => Promise<unknown[]>;
  create: (b: Record<string, unknown>, userId: string) => Promise<unknown>;
  perm: string;
};

const s = (v: unknown): string | null => {
  const x = typeof v === "string" ? v.trim() : "";
  return x.length ? x : null;
};
const n = (v: unknown): number | null | undefined =>
  v === undefined || v === null || v === "" ? undefined : v === null ? null : Number.isFinite(Number(v)) ? Number(v) : null;

const CONF: Record<string, EntityConf> = {
  titles: {
    perm: "actDefineProjectTitle",
    list: () =>
      db.projectTitle.findMany({
        orderBy: { title: "asc" },
        include: { titleGroup: true, statusGroup: true, grade: true, priority: true },
      }),
    create: (b) =>
      db.projectTitle.create({
        data: {
          title: String(b.title ?? "").trim(),
          titleGroupId: s(b.titleGroupId),
          statusGroupId: s(b.statusGroupId),
          gradeId: s(b.gradeId),
          priorityId: s(b.priorityId),
          description: s(b.description),
          activeNumRWithTitle: Boolean(b.activeNumRWithTitle),
          postFix: s(b.postFix),
          remindDay: n(b.remindDay) ?? null,
          foCmpCanSee: Boolean(b.foCmpCanSee),
          isTicket: Boolean(b.isTicket),
        },
      }),
  },
  titleGroups: {
    perm: "actDefineProjectTitleGroup",
    list: () => db.projectTitleGroup.findMany({ orderBy: [{ orderView: "asc" }, { name: "asc" }] }),
    create: (b) =>
      db.projectTitleGroup.create({
        data: {
          name: String(b.name ?? "").trim(),
          description: s(b.description),
          color: s(b.color),
          agreementActive: Boolean(b.agreementActive),
          agreementDesc: s(b.agreementDesc),
          subjectDefaultContext: s(b.subjectDefaultContext),
          ticketAllowInCurrentCount: n(b.ticketAllowInCurrentCount) ?? null,
          orderView: n(b.orderView) ?? 0,
        },
      }),
  },
  groups: {
    perm: "actDefinePrjGroup",
    list: () => db.projectGroup.findMany({ orderBy: [{ orderView: "asc" }, { name: "asc" }] }),
    create: (b) =>
      db.projectGroup.create({
        data: { name: String(b.name ?? "").trim(), description: s(b.description), orderView: n(b.orderView) ?? 0 },
      }),
  },
  grades: {
    perm: "actDefinePrjGrade",
    list: () => db.projectGrade.findMany({ orderBy: [{ orderView: "asc" }, { name: "asc" }] }),
    create: (b) =>
      db.projectGrade.create({
        data: { name: String(b.name ?? "").trim(), description: s(b.description), orderView: n(b.orderView) ?? 0 },
      }),
  },
  priorities: {
    perm: "actDefinePrjPriority",
    list: () => db.projectPriority.findMany({ orderBy: [{ orderView: "asc" }, { name: "asc" }] }),
    create: (b) =>
      db.projectPriority.create({
        data: { name: String(b.name ?? "").trim(), color: s(b.color), description: s(b.description), orderView: n(b.orderView) ?? 0 },
      }),
  },
  categories: {
    perm: "actDefinePrjCategory",
    list: () =>
      db.projectCategory.findMany({
        orderBy: [{ orderView: "asc" }, { name: "asc" }],
        include: { parent: true, statusGroup: true, _count: { select: { children: true, projects: true } } },
      }),
    create: (b) =>
      db.projectCategory.create({
        data: {
          name: String(b.name ?? "").trim(),
          parentId: s(b.parentId),
          statusGroupId: s(b.statusGroupId),
          orderView: n(b.orderView) ?? 0,
        },
      }),
  },
  statusGroups: {
    perm: "actDefinecnvsStatusGroups",
    list: () =>
      db.cnvsStatusGroup.findMany({
        orderBy: [{ orderView: "asc" }, { name: "asc" }],
        include: { statuses: { orderBy: { orderView: "asc" } }, _count: { select: { statuses: true, projects: true } } },
      }),
    create: (b) =>
      db.cnvsStatusGroup.create({
        data: {
          name: String(b.name ?? "").trim(),
          description: s(b.description),
          orderView: n(b.orderView) ?? 0,
          isActive: b.isActive !== false,
        },
      }),
  },
  statuses: {
    perm: "actDefinecnvsStatus",
    list: () => db.cnvsStatus.findMany({ orderBy: [{ groupId: "asc" }, { orderView: "asc" }], include: { group: true } }),
    create: (b) =>
      db.cnvsStatus.create({
        data: {
          groupId: String(b.groupId ?? "").trim(),
          name: String(b.name ?? "").trim(),
          progressPercent: Math.min(100, Math.max(0, n(b.progressPercent) ?? 0)),
          orderView: n(b.orderView) ?? 0,
          prjFinished: Boolean(b.prjFinished),
          addPrjActive: Boolean(b.addPrjActive),
          issuePreOrderActive: Boolean(b.issuePreOrderActive),
          issueOrderActive: Boolean(b.issueOrderActive),
          noCnvsDup: Boolean(b.noCnvsDup),
          isDefault: Boolean(b.isDefault),
          isActive: b.isActive !== false,
          color: s(b.color),
        },
      }),
  },
};

export async function GET(req: Request, { params }: { params: Promise<{ entity: string }> }) {
  return handle(async () => {
    await requirePerm("frmMain", "actView");
    const { entity } = await params;
    const conf = CONF[entity];
    if (!conf) return apiError("نوع تعریف نامعتبر است.", 404);
    const rows = await conf.list();
    return json({ rows });
  });
}

export async function POST(req: Request, { params }: { params: Promise<{ entity: string }> }) {
  return handle(async () => {
    const { entity } = await params;
    const conf = CONF[entity];
    if (!conf) return apiError("نوع تعریف نامعتبر است.", 404);
    await requirePerm("frmMain", conf.perm);
    const body = await req.json().catch(() => null);
    if (!body) return apiError("بدنه درخواست نامعتبر است.", 400);
    // جلوگیری از مقدار خالی نام/عنوان
    const nameKey = entity === "titles" ? "title" : "name";
    const nameVal = String(body[nameKey] ?? "").trim();
    if (!nameVal) return apiError("نام/عنوان الزامی است.", 400);
    const created = await conf.create(body, "");
    return json(created, 201);
  });
}
