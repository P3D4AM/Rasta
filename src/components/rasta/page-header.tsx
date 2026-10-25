import { cn } from "@/lib/utils";

/**
 * هدر صفحه — بازسازی الگوی card-header.Mainheader محصول CRMIdeal:
 * نوار آبی #528fcc با متن سفید، عنوان 15px، دکمه‌های عملیاتی داخل همان نوار.
 * (SectionBody label.Mainheader { color:#fff; background-color:#528fcc })
 */
export function PageHeader({
  title,
  subtitle,
  actions,
  icon,
  className,
}: {
  title: string;
  subtitle?: string;
  actions?: React.ReactNode;
  icon?: React.ReactNode;
  className?: string;
}) {
  return (
    <div
      className={cn(
        "crm-section-header flex flex-wrap items-center justify-between gap-2 px-4 py-2.5 mb-4",
        className
      )}
    >
      <h6 className="text-[15px] font-semibold flex items-center gap-2 text-white">
        {icon}
        <span>{title}</span>
        {subtitle ? (
          <span className="text-[12px] font-light text-white/75 hidden sm:inline">— {subtitle}</span>
        ) : null}
      </h6>
      {actions ? (
        <div className="flex flex-wrap items-center gap-2 shrink-0">{actions}</div>
      ) : null}
    </div>
  );
}

/* دکمه‌های نوار هدر صفحه — هم‌سبک دکمه‌های نوار CRMIdeal:
   سفید نیمه‌شفاف روی آبی، متن سفید، hover روشن‌تر */
export function HeaderGhostButton({
  children,
  ...props
}: React.ButtonHTMLAttributes<HTMLButtonElement>) {
  return (
    <button
      type="button"
      {...props}
      className={cn(
        "inline-flex items-center gap-1.5 rounded-full px-3.5 py-1.5 text-[13px] text-white bg-white/15 hover:bg-white/25 transition-colors disabled:opacity-50",
        props.className
      )}
    >
      {children}
    </button>
  );
}
