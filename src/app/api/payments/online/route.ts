import { db } from "@/lib/db";
import { requirePermission, handle, json, apiError } from "@/lib/http";
import { PAYMENT_GATEWAYS } from "@/lib/constants";

/**
 * /api/payments/online — پرداخت‌های آنلاین
 * بازسازی Areas/OnlinePayment: ایجاد درخواست پرداخت (زرین‌پال sandbox-ready)
 * + GET لیست تراکنش‌ها + POST شروع پرداخت + PATCH تایید دستی
 */

// GET: لیست پرداخت‌های آنلاین
export async function GET(req: Request) {
  return handle(async () => {
    await requirePermission("payments", "view");
    const rows = await db.onlinePayment.findMany({
      orderBy: { createdAt: "desc" },
      take: 100,
    });
    return json({ rows });
  });
}

// POST: شروع پرداخت آنلاین (PaymentRequest زرین‌پال)
export async function POST(req: Request) {
  return handle(async () => {
    const user = await requirePermission("payments", "create");
    const body = await req.json().catch(() => null);
    const amount = Number(body?.amount ?? 0);
    const gateway = String(body?.gateway ?? "ZARINPAL");

    if (!PAYMENT_GATEWAYS.includes(gateway as (typeof PAYMENT_GATEWAYS)[number])) {
      return apiError("درگاه نامعتبر است.", 400);
    }
    if (!(amount > 0)) return apiError("مبلغ باید بزرگ‌تر از صفر باشد.", 400);

    // وضعیت درگاه از تنظیمات
    const enabledKey = `gateway.${gateway.toLowerCase()}.enabled`;
    const setting = await db.setting.findUnique({ where: { key: enabledKey } });
    if (!setting || setting.value !== "true") {
      return apiError("این درگاه فعال نیست. ابتدا از تنظیمات پرداخت آنلاین آن را فعال کنید.", 409);
    }

    // ثبت تراکنش در حالت Pending
    const payment = await db.onlinePayment.create({
      data: {
        gateway,
        amount,
        description: String(body?.description ?? "").trim() || null,
        status: "PENDING",
        orderId: body?.orderId ? String(body.orderId) : null,
        payerName: String(body?.payerName ?? "").trim() || null,
        payerMobile: String(body?.payerMobile ?? "").trim() || null,
      },
    });

    // درخواست از درگاه (زرین‌پال):
    // در حالت توسعه بدون merchantId معتبر، لینک سندبکس برگردانده می‌شود
    const merchantIdRow = await db.setting.findUnique({
      where: { key: `gateway.${gateway.toLowerCase()}.merchantId` },
    });
    const sandboxRow = await db.setting.findUnique({
      where: { key: `gateway.${gateway.toLowerCase()}.sandbox` },
    });
    const merchantId = merchantIdRow?.value ?? "";
    const sandbox = sandboxRow?.value !== "false";

    let startUrl: string;
    let authority: string | null = null;

    if (gateway === "ZARINPAL" && merchantId) {
      try {
        const endpoint = sandbox
          ? "https://sandbox.zarinpal.com/pg/v4/payment/request.json"
          : "https://payment.zarinpal.com/pg/v4/payment/request.json";
        const res = await fetch(endpoint, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            merchant_id: merchantId,
            amount, // ریال
            callback_url: `/api/payments/online/callback`,
            description: payment.description ?? "پرداخت رستا",
          }),
        });
        const data = (await res.json()) as {
          data?: { authority?: string; code?: number };
        };
        if (data?.data?.authority) {
          authority = data.data.authority;
          startUrl = `https://${sandbox ? "sandbox" : "payment"}.zarinpal.com/pg/StartPay/${authority}`;
        } else {
          startUrl = "#";
        }
      } catch {
        startUrl = "#";
      }
    } else {
      // بدون مرچنت — لینک آزمایشی برای ثبت جریان
      startUrl = "#";
      authority = `SIMULATED-${payment.id.slice(0, 8)}`;
    }

    if (authority) {
      await db.onlinePayment.update({ where: { id: payment.id }, data: { authority } });
    }

    await db.activityLog.create({
      data: {
        userId: user.id,
        userName: `${user.firstName} ${user.lastName}`,
        action: "create",
        entity: "onlinePayment",
        entityId: payment.id,
        meta: `${gateway} — ${amount}`,
      },
    });

    return json({ payment: { ...payment, authority }, startUrl }, 201);
  });
}

// PATCH: تایید/لغو دستی تراکنش (برای سندهای شبیه‌سازی‌شده)
export async function PATCH(req: Request) {
  return handle(async () => {
    const user = await requirePermission("payments", "edit");
    const body = await req.json().catch(() => null);
    const id = String(body?.id ?? "");
    const action = String(body?.action ?? "");
    if (!id) return apiError("شناسه تراکنش الزامی است.", 400);

    const payment = await db.onlinePayment.findUnique({ where: { id } });
    if (!payment) return apiError("تراکنش یافت نشد.", 404);

    if (action === "verify") {
      const row = await db.onlinePayment.update({
        where: { id },
        data: { status: "VERIFIED", paidAt: new Date(), refId: payment.refId ?? `MAN-${Date.now()}` },
      });
      return json(row);
    }
    if (action === "cancel") {
      const row = await db.onlinePayment.update({ where: { id }, data: { status: "CANCELED" } });
      return json(row);
    }
    if (action === "fail") {
      const row = await db.onlinePayment.update({ where: { id }, data: { status: "FAILED" } });
      return json(row);
    }
    return apiError("عملیات نامعتبر است.", 400);
  });
}
