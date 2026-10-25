import { db } from "@/lib/db";
import { requirePermission, handle, json } from "@/lib/http";
import { NextResponse } from "next/server";

/**
 * /api/payments/gateways — تنظیمات درگاه‌های پرداخت آنلاین
 * بازسازی Areas/OnlinePayment + Setting (کلیدهای gateway.*)
 * ملت / پارسیان / زرین‌پال
 */

const GATEWAY_KEYS: Record<string, { enabled: string; fields: string[] }> = {
  ZARINPAL: { enabled: "gateway.zarinpal.enabled", fields: ["merchantId", "sandbox"] },
  MELLAT: { enabled: "gateway.mellat.enabled", fields: ["terminalId", "userName"] },
  PARSIAN: { enabled: "gateway.parsian.enabled", fields: ["pin"] },
};

// GET: خواندن تنظیمات همه درگاه‌ها
export async function GET() {
  return handle(async () => {
    await requirePermission("payments", "view");
    const settings = await db.setting.findMany({ where: { key: { startsWith: "gateway." } } });
    const map: Record<string, string> = {};
    for (const s of settings) map[s.key] = s.value;

    const gateways = Object.entries(GATEWAY_KEYS).map(([gw, cfg]) => ({
      gateway: gw,
      enabled: map[cfg.enabled] === "true",
      fields: Object.fromEntries(cfg.fields.map((f) => [f, map[`gateway.${gw.toLowerCase()}.${f}`] ?? ""])),
    }));
    return json({ gateways });
  });
}

// PUT: ذخیره تنظیمات یک درگاه
export async function PUT(req: Request) {
  return handle(async () => {
    const user = await requirePermission("payments", "edit");
    const body = await req.json().catch(() => null);
    const gateway = String(body?.gateway ?? "");
    const cfg = GATEWAY_KEYS[gateway];
    if (!cfg) return NextResponse.json({ error: "درگاه نامعتبر است." }, { status: 400 });

    const enabled = Boolean(body?.enabled);
    const fields: Record<string, string> = body?.fields ?? {};

    const upserts: { key: string; value: string }[] = [
      { key: cfg.enabled, value: enabled ? "true" : "false" },
      ...cfg.fields.map((f) => ({
        key: `gateway.${gateway.toLowerCase()}.${f}`,
        value: String(fields[f] ?? ""),
      })),
    ];
    for (const item of upserts) {
      await db.setting.upsert({
        where: { key: item.key },
        update: { value: item.value },
        create: { key: item.key, value: item.value },
      });
    }

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "edit",
        entity: "paymentGateway",
        entityId: gateway,
        meta: enabled ? "فعال‌سازی" : "ذخیره تنظیمات",
      },
    });

    return json({ ok: true });
  });
}
