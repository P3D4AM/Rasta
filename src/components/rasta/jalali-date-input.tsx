"use client";

import { useState } from "react";
import { formatJalali, parseJalali, toPersianDigits, toEnglishDigits } from "@/lib/jalali";
import { Input } from "@/components/ui/input";
import { CalendarDays, X } from "lucide-react";

type InnerState = { val: string | null; text: string; error: boolean };

/**
 * Jalali date text input with live validation.
 * Value: ISO string (YYYY-MM-DD) | null — controlled by parent.
 * Displays as 1403/08/15 (Persian digits), accepts typed Jalali dates.
 */
export function JalaliDateInput({
  value,
  onChange,
  placeholder = "۱۴۰۴/۰۱/۰۱",
  className,
}: {
  value: string | null;
  onChange: (iso: string | null) => void;
  placeholder?: string;
  className?: string;
}) {
  // Official React "adjust state during render" pattern (replaces setState-in-effect)
  const [inner, setInner] = useState<InnerState>(() => ({
    val: value,
    text: value ? formatJalali(value, true) : "",
    error: false,
  }));
  if (inner.val !== value) {
    setInner({ val: value, text: value ? formatJalali(value, true) : "", error: false });
  }

  function handleChange(raw: string) {
    const v = toPersianDigits(raw);
    if (!v.trim()) {
      setInner({ val: null, text: v, error: false });
      onChange(null);
      return;
    }
    const parsed = parseJalali(toEnglishDigits(v));
    if (parsed) {
      const iso = `${parsed.getFullYear()}-${String(parsed.getMonth() + 1).padStart(2, "0")}-${String(
        parsed.getDate()
      ).padStart(2, "0")}`;
      setInner({ val: iso, text: v, error: false });
      onChange(iso);
    } else {
      setInner({ ...inner, text: v, error: true });
    }
  }

  function clear() {
    setInner({ val: null, text: "", error: false });
    onChange(null);
  }

  return (
    <div className="relative">
      <CalendarDays className="absolute start-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground pointer-events-none" />
      <Input
        dir="ltr"
        className={`ps-9 pe-8 text-left ${inner.error ? "border-destructive focus-visible:ring-destructive" : ""} ${className ?? ""}`}
        placeholder={placeholder}
        value={inner.text}
        onChange={(e) => handleChange(e.target.value)}
      />
      {inner.text && (
        <button
          type="button"
          className="absolute end-2 top-1/2 -translate-y-1/2 text-muted-foreground hover:text-foreground"
          onClick={clear}
          aria-label="پاک کردن تاریخ"
        >
          <X className="w-3.5 h-3.5" />
        </button>
      )}
      {inner.error && (
        <p className="text-[11px] text-destructive mt-1">قالب تاریخ نامعتبر است (مثال: ۱۴۰۴/۰۱/۱۵)</p>
      )}
    </div>
  );
}
