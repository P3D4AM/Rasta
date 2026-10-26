// /api/base-info/cities — تعریف شهرها (بازسازی CompanyDefineCity + Apisp{Select,Insert}City)
// فیلتر ?provinceId= → ApispSelectCity WHERE ProvinceId
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { listGeo, createGeo, GEO_META } from "@/lib/baseinfo";

export async function GET(req: Request) {
  return handle(async () => {
    await requirePerm("frmMain", GEO_META.city.defineAct);
    const url = new URL(req.url);
    const provinceId = url.searchParams.get("provinceId");
    return json(
      await listGeo("city", {
        ...(provinceId ? { parentId: Number(provinceId) } : {}),
      })
    );
  });
}

export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePerm(GEO_META.city.form, "actPost");
    const body = await req.json().catch(() => ({}));
    const r = await createGeo("city", body, user);
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}
