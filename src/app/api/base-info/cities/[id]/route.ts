// /api/base-info/cities/[id] — ویرایش/حذف شهر
// گیت‌ها: ویرایش = frmDefineCity×actPost؛ حذف = frmDefineCity×actDelete
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { updateGeo, deleteGeo, listGeo, GEO_META } from "@/lib/baseinfo";

type Params = { params: Promise<{ id: string }> };

export async function GET(_req: Request, { params }: Params) {
  return handle(async () => {
    await requirePerm("frmMain", GEO_META.city.defineAct);
    const { id } = await params;
    const rows = await listGeo("city", { id: Number(id) });
    if (!rows.length) return apiError("شهر یافت نشد.", 404);
    return json(rows[0]);
  });
}

export async function PUT(req: Request, { params }: Params) {
  return handle(async () => {
    const user = await requirePerm(GEO_META.city.form, "actPost");
    const { id } = await params;
    const body = await req.json().catch(() => ({}));
    const r = await updateGeo("city", Number(id), body, user);
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}

export async function DELETE(_req: Request, { params }: Params) {
  return handle(async () => {
    await requirePerm(GEO_META.city.form, "actDelete");
    const { id } = await params;
    const r = await deleteGeo("city", Number(id));
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}
