"use client";

import { useCallback, useEffect, useRef, useState } from "react";

export type ListState<T> = {
  rows: T[];
  total: number;
  error: string | null;
  /** url of the last successfully loaded page */
  loadedUrl: string | null;
  /** raw response (includes extras like `footer`) */
  data: unknown;
};

/**
 * Fetch list data from an API endpoint.
 * `loading` is derived (no setState-in-effect): true while current url differs from loadedUrl.
 */
export function useList<T>(url: string | null) {
  const [state, setState] = useState<ListState<T>>({
    rows: [],
    total: 0,
    error: null,
    loadedUrl: null,
    data: null,
  });
  const [refreshKey, setRefreshKey] = useState(0);
  const mounted = useRef(true);

  useEffect(() => {
    mounted.current = true;
    return () => {
      mounted.current = false;
    };
  }, []);

  useEffect(() => {
    if (!url) return;
    let current = true;
    fetch(url)
      .then(async (res) => {
        const data = await res.json().catch(() => ({}));
        if (!res.ok) throw new Error(data.error ?? "خطا در دریافت اطلاعات");
        return data;
      })
      .then((data) => {
        if (!current || !mounted.current) return;
        setState({
          rows: data.rows ?? [],
          total: data.total ?? 0,
          error: null,
          loadedUrl: url,
          data,
        });
      })
      .catch((e: Error) => {
        if (!current || !mounted.current) return;
        setState((s) => ({ ...s, error: e.message, rows: [], total: 0, loadedUrl: url, data: null }));
      });
    return () => {
      current = false;
    };
  }, [url, refreshKey]);

  const refresh = useCallback(() => setRefreshKey((k) => k + 1), []);

  const loading = url !== null && state.loadedUrl !== url;
  return {
    rows: state.rows,
    total: state.total,
    error: state.error,
    loading,
    refresh,
    data: state.data as { footer?: { totalReceive: number; totalPay: number; remain: number } } | null,
  };
}

export async function api<T = unknown>(
  url: string,
  options: { method?: string; body?: unknown } = {}
): Promise<T> {
  const res = await fetch(url, {
    method: options.method ?? "GET",
    headers: options.body ? { "Content-Type": "application/json" } : undefined,
    body: options.body ? JSON.stringify(options.body) : undefined,
  });
  const data = await res.json().catch(() => ({}));
  if (!res.ok) throw new Error(data.error ?? "خطا در ارتباط با سرور");
  return data as T;
}
