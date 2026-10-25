import { db } from "@/lib/db";
import { requirePerm, handle, json, apiError } from "@/lib/http";

/**
 * امضای دیجیتال کاربر — بازسازی UserSignatureUpload/GetSignatureImage/DeleteSignatureFile
 * POST body: { base64 } (jpg/png/gif — سقف ~300KB مثل MaxImageSizeForUploadKb خود محصول)
 * GET → تصویر امضا | DELETE → حذف امضا
 */

const MAX_BYTES = 300 * 1024;

function detectMime(buf: Uint8Array): string | null {
  if (buf.length > 8 && buf[0] === 0x89 && buf[1] === 0x50 && buf[2] === 0x4e && buf[3] === 0x47) return "image/png";
  if (buf.length > 3 && buf[0] === 0xff && buf[1] === 0xd8 && buf[2] === 0xff) return "image/jpeg";
  if (buf.length > 6 && buf[0] === 0x47 && buf[1] === 0x49 && buf[2] === 0x46) return "image/gif";
  return null;
}

export async function POST(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actUploadSignature");
    const { id } = await params;
    const user = await db.user.findUnique({ where: { id } });
    if (!user) return apiError("کاربر یافت نشد.", 404);

    const body = await req.json().catch(() => null);
    const b64 = String(body?.base64 ?? "").replace(/^data:image\/\w+;base64,/, "");
    if (!b64) return apiError("فایل امضا ارسال نشده است.", 400);
    const buf = Buffer.from(b64, "base64");
    if (buf.length > MAX_BYTES) return apiError("حجم فایل امضا بیش از حد مجاز (۳۰۰KB) است.", 400);
    if (!detectMime(buf)) return apiError("فقط تصویر JPG/PNG/GIF مجاز است.", 400);

    await db.user.update({ where: { id }, data: { signature: buf } });
    return json({ uploaded: true, size: buf.length });
  });
}

export async function GET(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actView");
    const { id } = await params;
    const user = await db.user.findUnique({ where: { id }, select: { signature: true } });
    if (!user?.signature) return apiError("امضایی ثبت نشده است.", 404);
    const mime = detectMime(user.signature) ?? "image/png";
    return new Response(new Uint8Array(user.signature), {
      headers: { "Content-Type": mime, "Cache-Control": "no-store" },
    });
  });
}

export async function DELETE(req: Request, { params }: { params: Promise<{ id: string }> }) {
  return handle(async () => {
    await requirePerm("frmDefineUsers", "actUploadSignature");
    const { id } = await params;
    await db.user.update({ where: { id }, data: { signature: null } });
    return json({ deleted: true });
  });
}
