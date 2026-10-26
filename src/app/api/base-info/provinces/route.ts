// /api/base-info/provinces — تعریف استان‌ها (بازسازی CompanyDefineProvince + Apisp{Select,Insert}Province)
// فیلتر ?countryId= → ApispSelectProvince WHERE CountryId
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { listGeo, createGeo, GEO_META } from "@/lib/baseinfo";

export async function GET(req: Request) {
  return handle(async () => {
    await requirePerm("frmMain", GEO_META.province.defineAct);
    const url = new URL(req.url);
    const countryId = url.searchParams.get("countryId");
    return json(
      await listGeo("province", {
        ...(countryId ? { parentId: Number(countryId) } : {}),
      })
    );
  });
}

export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePerm(GEO_META.province.form, "actPost");
    const body = await req.json().catch(() => ({}));
    const r = await createGeo("province", body, user);
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}
