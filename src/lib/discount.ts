import type { SessionUser } from "@/lib/auth";
import { HttpError } from "@/lib/http";
import { db } from "@/lib/db";

/**
 * سقف درصد تخفیف به تفکیک نقش — بازسازی CrmsysRolls.LimitPreOrderDiscount* / LimitOrderDiscount*
 * در CRMIdeal هنگام درج/ویرایش پیش‌فاکتور و فاکتور فروش چک می‌شود؛
 * اگر فعال باشد و درصد تخفیف سقف را رد کند، ثبت با پیام خطا رد می‌شود.
 */

export async function assertDiscountLimit(
  user: SessionUser,
  kind: "preOrder" | "order",
  discountTotal: number,
  subtotal: number
): Promise<void> {
  if (user.isAdmin || !user.roleId) return;
  const role = await db.role.findUnique({ where: { id: user.roleId } });
  if (!role) return;

  const active = kind === "preOrder" ? role.limitPreOrderDiscountActive : role.limitOrderDiscountActive;
  const limit = kind === "preOrder" ? role.limitPreOrderDiscountPercent : role.limitOrderDiscountPercent;
  if (!active || !limit || limit <= 0) return;

  if (subtotal <= 0) return;
  const percent = (discountTotal / subtotal) * 100;
  if (percent > limit) {
    throw new HttpError(
      403,
      `سقف درصد تخفیف نقش شما ${Math.round(limit)}٪ است؛ درصد تخفیف فعلی ${Math.round(percent * 10) / 10}٪ است.`
    );
  }
}
