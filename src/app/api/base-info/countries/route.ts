// /api/base-info/countries — تعریف کشورها (بازسازی CompanyDefineCountry + Apisp{Select,Insert}Country)
// گیت‌ها (DynamicAuthorize خود CRMIdeal): مشاهدهٔ گرید = frmMain×actDefineCountry؛ ثبت = frmDefineCountry×actPost
import { requirePerm, handle, json, apiError } from "@/lib/http";
import { listGeo, createGeo, GEO_META } from "@/lib/baseinfo";

export async function GET() {
  return handle(async () => {
    await requirePerm("frmMain", GEO_META.country.defineAct);
    return json(await listGeo("country"));
  });
}

export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePerm(GEO_META.country.form, "actPost");
    const body = await req.json().catch(() => ({}));
    const r = await createGeo("country", body, user);
    if ("error" in r && r.error) return apiError(r.error, r.status);
    return json(r.data, r.status);
  });
}
