// /api/base-info/countries/[id] — ویرایش/حذف کشور
// گیت‌ها: ویرایش = frmDefineCountry×actPost (DynamicAuthorize روی POST اکشن Edit خود CRMIdeal)؛
// حذف = frmDefineCountry×actDelete (CompanyDefineCountryDelete → IsUserAccess)
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { updateGeo, deleteGeo, listGeo, GEO_META } from "@/lib/baseinfo";

type Params = { params: Promise<{ id: string }> };

export async function GET(_req: Request, { params }: Params) {
  return handle(async () => {
    await requirePerm("frmMain", GEO_META.country.defineAct);
    const { id } = await params;
    const rows = await listGeo("country", { id: Number(id) });
    if (!rows.length) return apiError("کشور یافت نشد.", 404);
    return json(rows[0]);
  });
}

export async function PUT(req: Request, { params }: Params) {
  return handle(async () => {
    const user = await requirePerm(GEO_META.country.form, "actPost");
    const { id } = await params;
    const body = await req.json().catch(() => ({}));
    const r = await updateGeo("country", Number(id), body, user);
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}

export async function DELETE(_req: Request, { params }: Params) {
  return handle(async () => {
    await requirePerm(GEO_META.country.form, "actDelete");
    const { id } = await params;
    const r = await deleteGeo("country", Number(id));
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}
