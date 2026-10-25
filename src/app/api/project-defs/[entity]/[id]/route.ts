import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * /api/project-defs/[entity]/[id] — ویرایش/حذف تعاریف پایه پروژه‌ها
 * حذفِ موجودیتِ در حال استفاده مسدود می‌شود (با ذکر تعداد و جایی که استفاده شده — صادقانه، بدون حذف آبشاری پنهان)
 */

const s = (v: unknown): string | null => {
  const x = typeof v === "string" ? v.trim() : "";
  return x.length ? x : null;
};
const num = (v: unknown): number | null | undefined =>
  v === undefined || v === null || v === "" ? undefined : Number.isFinite(Number(v)) ? Number(v) : null;

type EntityHandlers = {
  perm: string;
  usage: (id: string) => Promise<{ count: number; label: string } | null>;
  update: (id: string, b: Record<string, unknown>) => Promise<unknown>;
  remove: (id: string) => Promise<unknown>;
};

async function usageCount(model: "project" | "projectTitle" | "projectConversation" | "projectCategory" | "cnvsStatus" | "projectPriority" | "projectGrade" | "projectGroup", where: Record<string, string>): Promise<number> {
  // @ts-expect-error dynamic model count
  return db[model].count({ where });
}

const HANDLERS: Record<string, EntityHandlers> = {
  titles: {
    perm: "actDefineProjectTitle",
    usage: async (id) => {
      const cnt = await db.project.count({ where: { title: (await db.projectTitle.findUnique({ where: { id } }))?.title ?? "" } });
      return cnt ? { count: cnt, label: "پروژه با همین عنوان" } : null;
    },
    update: (id, b) =>
      db.projectTitle.update({
        where: { id },
        data: {
          title: String(b.title ?? "").trim(),
          titleGroupId: s(b.titleGroupId),
          statusGroupId: s(b.statusGroupId),
          gradeId: s(b.gradeId),
          priorityId: s(b.priorityId),
          description: s(b.description),
          activeNumRWithTitle: Boolean(b.activeNumRWithTitle),
          postFix: s(b.postFix),
          remindDay: num(b.remindDay) ?? null,
          foCmpCanSee: Boolean(b.foCmpCanSee),
          isTicket: Boolean(b.isTicket),
        },
      }),
    remove: (id) => db.projectTitle.delete({ where: { id } }),
  },
  titleGroups: {
    perm: "actDefineProjectTitleGroup",
    usage: async (id) => {
      const cnt = await db.project.count({ where: { titleGroupId: id } });
      const titles = await db.projectTitle.count({ where: { titleGroupId: id } });
      return cnt || titles
        ? { count: cnt + titles, label: `پروژه (${cnt}) یا عنوان پیش‌فرض (${titles})` }
        : null;
    },
    update: (id, b) =>
      db.projectTitleGroup.update({
        where: { id },
        data: {
          name: String(b.name ?? "").trim(),
          description: s(b.description),
          color: s(b.color),
          agreementActive: Boolean(b.agreementActive),
          agreementDesc: s(b.agreementDesc),
          subjectDefaultContext: s(b.subjectDefaultContext),
          ticketAllowInCurrentCount: num(b.ticketAllowInCurrentCount) ?? null,
          orderView: num(b.orderView) ?? 0,
        },
      }),
    remove: (id) => db.projectTitleGroup.delete({ where: { id } }),
  },
  groups: {
    perm: "actDefinePrjGroup",
    usage: async (id) => {
      const cnt = await usageCount("project", { groupId: id });
      return cnt ? { count: cnt, label: "پروژه" } : null;
    },
    update: (id, b) =>
      db.projectGroup.update({
        where: { id },
        data: { name: String(b.name ?? "").trim(), description: s(b.description), orderView: num(b.orderView) ?? 0 },
      }),
    remove: (id) => db.projectGroup.delete({ where: { id } }),
  },
  grades: {
    perm: "actDefinePrjGrade",
    usage: async (id) => {
      const cnt = await usageCount("project", { gradeId: id });
      const titles = await db.projectTitle.count({ where: { gradeId: id } });
      return cnt || titles ? { count: cnt + titles, label: `پروژه (${cnt}) یا عنوان (${titles})` } : null;
    },
    update: (id, b) =>
      db.projectGrade.update({
        where: { id },
        data: { name: String(b.name ?? "").trim(), description: s(b.description), orderView: num(b.orderView) ?? 0 },
      }),
    remove: (id) => db.projectGrade.delete({ where: { id } }),
  },
  priorities: {
    perm: "actDefinePrjPriority",
    usage: async (id) => {
      const cnt = await usageCount("project", { priorityId: id });
      const titles = await db.projectTitle.count({ where: { priorityId: id } });
      return cnt || titles ? { count: cnt + titles, label: `پروژه (${cnt}) یا عنوان (${titles})` } : null;
    },
    update: (id, b) =>
      db.projectPriority.update({
        where: { id },
        data: { name: String(b.name ?? "").trim(), color: s(b.color), description: s(b.description), orderView: num(b.orderView) ?? 0 },
      }),
    remove: (id) => db.projectPriority.delete({ where: { id } }),
  },
  categories: {
    perm: "actDefinePrjCategory",
    usage: async (id) => {
      const cnt = await usageCount("project", { categoryId: id });
      const children = await db.projectCategory.count({ where: { parentId: id } });
      return cnt || children ? { count: cnt + children, label: `پروژه (${cnt}) یا زیردسته (${children})` } : null;
    },
    update: (id, b) =>
      db.projectCategory.update({
        where: { id },
        data: { name: String(b.name ?? "").trim(), parentId: s(b.parentId), statusGroupId: s(b.statusGroupId), orderView: num(b.orderView) ?? 0 },
      }),
    remove: (id) => db.projectCategory.delete({ where: { id } }),
  },
  statusGroups: {
    perm: "actDefinecnvsStatusGroups",
    usage: async (id) => {
      const cnt = await usageCount("project", { statusGroupId: id });
      const statuses = await db.cnvsStatus.count({ where: { groupId: id } });
      return cnt || statuses ? { count: cnt + statuses, label: `پروژه (${cnt}) یا وضعیت (${statuses})` } : null;
    },
    update: (id, b) =>
      db.cnvsStatusGroup.update({
        where: { id },
        data: {
          name: String(b.name ?? "").trim(),
          description: s(b.description),
          orderView: num(b.orderView) ?? 0,
          isActive: b.isActive !== false,
        },
      }),
    remove: (id) => db.cnvsStatusGroup.delete({ where: { id } }),
  },
  statuses: {
    perm: "actDefinecnvsStatus",
    usage: async (id) => {
      const cnt = await usageCount("projectConversation", { statusId: id });
      return cnt ? { count: cnt, label: "مذاکره" } : null;
    },
    update: (id, b) =>
      db.cnvsStatus.update({
        where: { id },
        data: {
          name: String(b.name ?? "").trim(),
          progressPercent: Math.min(100, Math.max(0, num(b.progressPercent) ?? 0)),
          orderView: num(b.orderView) ?? 0,
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
    remove: (id) => db.cnvsStatus.delete({ where: { id } }),
  },
};

export async function PUT(req: Request, { params }: { params: Promise<{ entity: string; id: string }> }) {
  return handle(async () => {
    const { entity, id } = await params;
    const h = HANDLERS[entity];
    if (!h) return apiError("نوع تعریف نامعتبر است.", 404);
    await requirePerm("frmMain", h.perm);
    const body = await req.json().catch(() => null);
    if (!body) return apiError("بدنه درخواست نامعتبر است.", 400);
    const updated = await h.update(id, body);
    return json(updated);
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ entity: string; id: string }> }) {
  return handle(async () => {
    const { entity, id } = await params;
    const h = HANDLERS[entity];
    if (!h) return apiError("نوع تعریف نامعتبر است.", 404);
    await requirePerm("frmMain", h.perm);
    const usage = await h.usage(id);
    if (usage) {
      return apiError(`${usage.count} ${usage.label} از این مورد استفاده کرده است؛ حذف امکان‌پذیر نیست.`, 409);
    }
    await h.remove(id);
    return json({ deleted: true });
  });
}
