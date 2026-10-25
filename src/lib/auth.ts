// Rasta CRM — Authentication & RBAC
// Replaces legacy Forms Auth + SimpleMembership + IsUserAccess(formName, action).
// JWT (jose) in HttpOnly cookie + scrypt password hashing (zero extra deps).

import "server-only";
import { randomBytes, scryptSync, timingSafeEqual } from "crypto";
import { cookies } from "next/headers";
import { SignJWT, jwtVerify } from "jose";
import { db } from "@/lib/db";
import type { FormId } from "@/lib/constants";

const SESSION_COOKIE = "rasta_session";
const SESSION_TTL_HOURS = 48; // same as legacy 48h, but sliding JWT

// ── Password hashing (scrypt: built into Node, no external dependency) ──

export function hashPassword(password: string): string {
  const salt = randomBytes(16).toString("hex");
  const hash = scryptSync(password, salt, 64).toString("hex");
  return `${salt}:${hash}`;
}

export function verifyPassword(password: string, stored: string): boolean {
  try {
    const [salt, hash] = stored.split(":");
    const hashBuf = Buffer.from(hash, "hex");
    const testBuf = scryptSync(password, salt, 64);
    return timingSafeEqual(hashBuf, testBuf);
  } catch {
    return false;
  }
}

// ── JWT Session ──

function getSecret(): Uint8Array {
  const secret = process.env.AUTH_SECRET || "rasta-dev-fallback-secret";
  return new TextEncoder().encode(secret);
}

export async function createSession(userId: string): Promise<void> {
  const token = await new SignJWT({ sub: userId, app: "rasta" })
    .setProtectedHeader({ alg: "HS256" })
    .setIssuedAt()
    .setExpirationTime(`${SESSION_TTL_HOURS}h`)
    .sign(getSecret());

  const jar = await cookies();
  jar.set(SESSION_COOKIE, token, {
    httpOnly: true,
    sameSite: "lax",
    secure: process.env.NODE_ENV === "production",
    path: "/",
    maxAge: SESSION_TTL_HOURS * 3600,
  });
}

export async function destroySession(): Promise<void> {
  const jar = await cookies();
  jar.set(SESSION_COOKIE, "", { httpOnly: true, path: "/", maxAge: 0 });
}

export async function getSessionUserId(): Promise<string | null> {
  const jar = await cookies();
  const token = jar.get(SESSION_COOKIE)?.value;
  if (!token) return null;
  try {
    const { payload } = await jwtVerify(token, getSecret());
    return payload.sub ?? null;
  } catch {
    return null;
  }
}

export type SessionUser = {
  id: string;
  username: string;
  firstName: string;
  lastName: string;
  email: string | null;
  isAdmin: boolean;
  roleId: string | null;
  roleName: string | null;
  // فرم → فهرست اکشن‌های مجاز — مثل کش مجوز CRMIdeal (Cache/User/Permissions)
  permissions: Record<string, string[]>;
};

/** Load full user + permission map. Returns null when unauthenticated. */
export async function getCurrentUser(): Promise<SessionUser | null> {
  const userId = await getSessionUserId();
  if (!userId) return null;

  const user = await db.user.findUnique({
    where: { id: userId },
    include: {
      role: { include: { permissions: true } },
    },
  });
  if (!user || !user.isActive) return null;

  const permissions: Record<string, string[]> = {};
  for (const p of user.role?.permissions ?? []) {
    permissions[p.formId] = [...(permissions[p.formId] ?? []), p.actionId];
  }

  return {
    id: user.id,
    username: user.username,
    firstName: user.firstName,
    lastName: user.lastName,
    email: user.email,
    isAdmin: user.isAdmin,
    roleId: user.roleId,
    roleName: user.role?.name ?? null,
    permissions,
  };
}

/**
 * آیا کاربر به (فرم، اکشن) دسترسی دارد؟ — معادل UserLogin.IsUserAccess(formName, actionName)
 * ادمین سیستم همه‌چیز را دارد (مثل کاربر adm در CRMIdeal).
 */
export function can(user: SessionUser, form: FormId | string, action: string): boolean {
  if (user.isAdmin) return true;
  const acts = user.permissions[form];
  if (!acts) return false;
  return acts.includes(action);
}
