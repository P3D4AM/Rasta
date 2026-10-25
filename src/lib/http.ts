// Rasta CRM — API route helpers: auth guard, permission guard, uniform errors & JSON.

import { NextResponse } from "next/server";
import { getCurrentUser, can, type SessionUser } from "@/lib/auth";
import type { ActionKey, ModuleKey } from "@/lib/constants";

export function json(data: unknown, status = 200) {
  return NextResponse.json(data, { status });
}

export function apiError(message: string, status = 400) {
  return NextResponse.json({ error: message }, { status });
}

export class HttpError extends Error {
  constructor(
    public status: number,
    message: string
  ) {
    super(message);
  }
}

/** Throws HttpError(401) if not logged in. */
export async function requireUser(): Promise<SessionUser> {
  const user = await getCurrentUser();
  if (!user) throw new HttpError(401, "ابتدا وارد حساب کاربری خود شوید.");
  return user;
}

/** Throws HttpError(403) if module:action is not permitted. */
export async function requirePermission(
  module: ModuleKey,
  action: ActionKey
): Promise<SessionUser> {
  const user = await requireUser();
  if (!can(user, module, action)) {
    throw new HttpError(403, "شما به این بخش دسترسی ندارید.");
  }
  return user;
}

/** Wrap a route handler with uniform error → JSON conversion. */
export async function handle(fn: () => Promise<NextResponse>): Promise<NextResponse> {
  try {
    return await fn();
  } catch (err) {
    if (err instanceof HttpError) {
      return apiError(err.message, err.status);
    }
    console.error("[rasta-api]", err);
    const message = err instanceof Error ? err.message : "خطای غیرمنتظره در سرور";
    return apiError(message, 500);
  }
}

// ── shared list-Query parsing (pagination + search) ──

export type ListQuery = {
  page: number;
  pageSize: number;
  search: string;
  take: number;
  skip: number;
};

export function parseListQuery(req: Request, defaultPageSize = 20): ListQuery {
  const url = new URL(req.url);
  const page = Math.max(1, Number(url.searchParams.get("page") ?? 1) || 1);
  const pageSize = Math.min(
    200,
    Math.max(1, Number(url.searchParams.get("pageSize") ?? defaultPageSize) || defaultPageSize)
  );
  const search = (url.searchParams.get("search") ?? "").trim();
  return { page, pageSize, search, take: pageSize, skip: (page - 1) * pageSize };
}

/** Next document number for Quotation/SalesOrder/PurchaseOrder (SQLite has no autoincrement on non-id). */
export async function nextDocNumber(
  model: "quotation" | "salesOrder" | "purchaseOrder"
): Promise<number> {
  const last =
    model === "quotation"
      ? await db.quotation.findFirst({ orderBy: { number: "desc" }, select: { number: true } })
      : model === "salesOrder"
        ? await db.salesOrder.findFirst({ orderBy: { number: "desc" }, select: { number: true } })
        : await db.purchaseOrder.findFirst({ orderBy: { number: "desc" }, select: { number: true } });
  return (last?.number ?? 1000) + 1;
}

import { db } from "@/lib/db";
