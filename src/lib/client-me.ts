"use client";

/** دریافت کاربر جاری + مجوزها در کلاینت — /api/auth/me خروجی { user } دارد */
export type MeUser = {
  id?: string;
  firstName?: string;
  lastName?: string;
  isAdmin: boolean;
  permissions: Record<string, string[]>;
};

export async function fetchMe(): Promise<MeUser | null> {
  try {
    const res = await fetch("/api/auth/me");
    if (!res.ok) return null;
    const data = await res.json();
    return (data?.user as MeUser) ?? null;
  } catch {
    return null;
  }
}
