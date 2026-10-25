// Rasta CRM — domain constants & Persian labels
// Replaces the legacy string-enum sprawl (46 areas × form-access flags) with a typed registry.

export type ModuleKey =
  | "dashboard"
  | "companies"
  | "contacts"
  | "deals"
  | "activities"
  | "products"
  | "quotations"
  | "orders"
  | "warehouses"
  | "inventory"
  | "purchases"
  | "tasks"
  | "users"
  | "roles"
  | "reports"
  | "settings"
  | "fund"
  | "banking"
  | "payments";

export type ActionKey = "view" | "create" | "edit" | "delete";

export const MODULES: Record<ModuleKey, { label: string; href: string; icon: string }> = {
  dashboard: { label: "داشبورد", href: "/dashboard", icon: "LayoutDashboard" },
  companies: { label: "مشتریان", href: "/companies", icon: "Building2" },
  contacts: { label: "افراد", href: "/contacts", icon: "Users" },
  deals: { label: "فرصت‌های فروش", href: "/deals", icon: "Target" },
  activities: { label: "فعالیت‌ها", href: "/activities", icon: "PhoneCall" },
  tasks: { label: "کارتابل", href: "/tasks", icon: "ClipboardList" },
  products: { label: "محصولات", href: "/products", icon: "Package" },
  quotations: { label: "پیش‌فاکتورها", href: "/quotations", icon: "FileText" },
  orders: { label: "فاکتورها", href: "/orders", icon: "ReceiptText" },
  warehouses: { label: "انبارها", href: "/warehouses", icon: "Warehouse" },
  inventory: { label: "موجودی و گردش کالا", href: "/inventory", icon: "Boxes" },
  purchases: { label: "سفارشات خرید", href: "/purchases", icon: "ShoppingCart" },
  reports: { label: "گزارش‌ها", href: "/reports", icon: "BarChart3" },
  users: { label: "کاربران", href: "/settings/users", icon: "UserCog" },
  roles: { label: "نقش‌ها", href: "/settings/roles", icon: "ShieldCheck" },
  settings: { label: "تنظیمات", href: "/settings", icon: "Settings" },
  fund: { label: "خزانه", href: "/fund", icon: "Wallet" },
  banking: { label: "بانک‌داری", href: "/banking", icon: "Landmark" },
  payments: { label: "پرداخت آنلاین", href: "/settings/payments", icon: "CreditCard" },
};

export const ACTIONS: Record<ActionKey, string> = {
  view: "مشاهده",
  create: "ایجاد",
  edit: "ویرایش",
  delete: "حذف",
};

// ── Company ──
export const COMPANY_TYPES = ["CUSTOMER", "PROSPECT", "PARTNER", "SUPPLIER", "OTHER"] as const;
export const COMPANY_TYPE_LABELS: Record<string, string> = {
  CUSTOMER: "مشتری",
  PROSPECT: "پیش‌مشتری",
  PARTNER: "همکار",
  SUPPLIER: "تأمین‌کننده",
  OTHER: "سایر",
};

// ── Deal ──
export const DEAL_STAGES = ["NEW", "CONTACTED", "PROPOSAL", "NEGOTIATION", "WON", "LOST"] as const;
export const DEAL_STAGE_LABELS: Record<string, string> = {
  NEW: "جدید",
  CONTACTED: "تماس گرفته‌شده",
  PROPOSAL: "پیشنهاد ارسالی",
  NEGOTIATION: "در مذاکره",
  WON: "موفق",
  LOST: "ناموفق",
};
export const OPEN_DEAL_STAGES = DEAL_STAGES.slice(0, 4) as readonly string[];

// ── Activity ──
export const ACTIVITY_TYPES = ["CALL", "MEETING", "EMAIL", "SMS", "NOTE"] as const;
export const ACTIVITY_TYPE_LABELS: Record<string, string> = {
  CALL: "تماس تلفنی",
  MEETING: "جلسه",
  EMAIL: "ایمیل",
  SMS: "پیامک",
  NOTE: "یادداشت",
};
export const ACTIVITY_DIRECTIONS: Record<string, string> = {
  INCOMING: "ورودی",
  OUTGOING: "خروجی",
};

// ── Priority ──
export const PRIORITIES = ["LOW", "NORMAL", "HIGH", "URGENT"] as const;
export const PRIORITY_LABELS: Record<string, string> = {
  LOW: "کم",
  NORMAL: "معمولی",
  HIGH: "زیاد",
  URGENT: "فوری",
};

// ── Quotation ──
export const QUOTATION_STATUSES = ["DRAFT", "SENT", "ACCEPTED", "REJECTED", "EXPIRED", "CONVERTED"] as const;
export const QUOTATION_STATUS_LABELS: Record<string, string> = {
  DRAFT: "پیش‌نویس",
  SENT: "ارسال‌شده",
  ACCEPTED: "تأییدشده",
  REJECTED: "ردشده",
  EXPIRED: "منقضی",
  CONVERTED: "تبدیل به فاکتور",
};

// ── Order ──
export const ORDER_STATUSES = ["DRAFT", "ISSUED", "PAID", "CANCELED"] as const;
export const ORDER_STATUS_LABELS: Record<string, string> = {
  DRAFT: "پیش‌نویس",
  ISSUED: "صادرشده",
  PAID: "تسویه‌شده",
  CANCELED: "لغوشده",
};

// ── Task ──
export const TASK_STATUSES = ["OPEN", "DONE", "CANCELED"] as const;
export const TASK_STATUS_LABELS: Record<string, string> = {
  OPEN: "باز",
  DONE: "انجام‌شده",
  CANCELED: "لغوشده",
};

// ── Payment ──
export const PAYMENT_METHODS = ["CASH", "CARD", "TRANSFER", "GATEWAY", "CHEQUE"] as const;
export const PAYMENT_METHOD_LABELS: Record<string, string> = {
  CASH: "نقدی",
  CARD: "کارت‌خوان",
  TRANSFER: "کارت به کارت",
  GATEWAY: "درگاه پرداخت",
  CHEQUE: "چک",
};

export const CURRENCY = "ریال";

// ── Stock Movement (Phase 2) ──
export const MOVEMENT_TYPES = ["IN", "OUT", "TRANSFER", "ADJUST"] as const;
export const MOVEMENT_TYPE_LABELS: Record<string, string> = {
  IN: "رسید ورود",
  OUT: "حواله خروج",
  TRANSFER: "انتقال بین انبار",
  ADJUST: "اصلاح موجودی",
};
export const MOVEMENT_REF_LABELS: Record<string, string> = {
  MANUAL: "دستی",
  PURCHASE_ORDER: "سفارش خرید",
  SALES_ORDER: "فاکتور فروش",
};

// ── Purchase Order (Phase 2) ──
export const PURCHASE_STATUSES = ["DRAFT", "ORDERED", "RECEIVED", "CANCELED"] as const;
export const PURCHASE_STATUS_LABELS: Record<string, string> = {
  DRAFT: "پیش‌نویس",
  ORDERED: "سفارش داده‌شده",
  RECEIVED: "تحویل‌شده",
  CANCELED: "لغوشده",
};

/** آستانه هشدار رو به اتمام شدن موجودی */
export const LOW_STOCK_THRESHOLD = 5;

// ── Fund (خزانه) — مطابق CRMIdeal.Areas.Fund ──
// در خزانه CRMIdeal: FundDebit = دریافت وجه (ورود نقد به خزانه)، FundCredit = پرداخت وجه
export const FUND_TRANSACTION_TYPES = ["RECEIVE", "PAY"] as const;
export const FUND_TRANSACTION_TYPE_LABELS: Record<string, string> = {
  RECEIVE: "دریافت وجه",
  PAY: "پرداخت وجه",
};

// ── Banking (بانک‌داری) — مطابق CRMIdeal.Areas.Banking ──
export const BANK_ACCOUNT_TYPES = ["CURRENT", "SAVING", "GHARZ", "SHORT_TERM"] as const;
export const BANK_ACCOUNT_TYPE_LABELS: Record<string, string> = {
  CURRENT: "جاری",
  SAVING: "سپرده",
  GHARZ: "قرض‌الحسنه",
  SHORT_TERM: "کوتاه‌مدت",
};

// ── درگاه‌های پرداخت آنلاین (مثل CRMIdeal.Areas.OnlinePayment) ──
export const PAYMENT_GATEWAYS = ["ZARINPAL", "MELLAT", "PARSIAN"] as const;
export const PAYMENT_GATEWAY_LABELS: Record<string, string> = {
  ZARINPAL: "زرین‌پال",
  MELLAT: "ملت",
  PARSIAN: "پارسیان",
};
