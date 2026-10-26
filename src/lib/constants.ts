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

// ── سیستم مجوز فرم×اکشن — بازسازی CrmsysRollPermission خود CRMIdeal ──
// در CRMIdeal مجوز = رکورد (نقش × فرم × اکشن)؛ فرم‌ها frm* و اکشن‌ها act* نام‌گذاری شده‌اند
// و هر دکمهٔ UI جداگانه با UserLogin.IsUserAccess(formName, actionName) کنترل می‌شود.

export type FormId =
  | "frmHomePage" | "frmMain" | "frmCompanyI" | "frmCompanyPersons"
  | "frmDefineProjects" | "frmProjectPreview" | "frmConversations"
  | "frmDeals" | "frmActivities" | "frmTasks"
  | "frmPreOrder" | "frmOrder" | "frmProduct" | "frmBuyOrder"
  | "frmWareHouse" | "frmStock" | "frmFund" | "frmBanking" | "frmOnlinePayment"
  | "frmReports" | "frmDefineUsers" | "frmUserRoll" | "frmRollPermission" | "frmSetting"
  | "frmDefineCountry" | "frmDefineProvince" | "frmDefineCity";

export const STD_ACTS = ["actView", "actInsert", "actEdit", "actDelete"] as const;

export type FormMeta = { id: FormId; label: string; section: string; actions: string[] };

export const FORMS: FormMeta[] = [
  { id: "frmHomePage", label: "صفحه اصلی", section: "خانه", actions: ["actView"] },
  // بانک اطلاعاتی مشتریان
  { id: "frmCompanyI", label: "مشتریان (طرف حساب‌ها)", section: "بانک اطلاعاتی مشتریان", actions: [...STD_ACTS, "actprjInsert"] },
  { id: "frmCompanyPersons", label: "افراد مخاطب", section: "بانک اطلاعاتی مشتریان", actions: [...STD_ACTS] },
  { id: "frmDefineProjects", label: "درج/ویرایش پروژه", section: "بانک اطلاعاتی مشتریان", actions: ["actPost", "actCanSetArchive", "actCanSetPrjIsTicket", "actCanChangePrjToDoTime"] },
  { id: "frmProjectPreview", label: "نمایش پروژه", section: "بانک اطلاعاتی مشتریان", actions: ["actView", "actDelete", "actDeleteCmpProjectWithDep", "actDeleteAllCmpProjectsWithDep"] },
  { id: "frmConversations", label: "مذاکرات پروژه", section: "بانک اطلاعاتی مشتریان", actions: [...STD_ACTS] },
  { id: "frmDeals", label: "فرصت‌های فروش (افزونه رستا)", section: "بانک اطلاعاتی مشتریان", actions: [...STD_ACTS] },
  // کارتابل
  { id: "frmTasks", label: "کارها و یادآورها", section: "کارتابل‌ها", actions: [...STD_ACTS] },
  { id: "frmActivities", label: "فعالیت‌ها (افزونه رستا)", section: "کارتابل‌ها", actions: [...STD_ACTS] },
  // خرید - فروش - انبار
  { id: "frmPreOrder", label: "پیش‌فاکتور", section: "خرید - فروش - انبار", actions: [...STD_ACTS] },
  { id: "frmOrder", label: "فاکتور فروش", section: "خرید - فروش - انبار", actions: [...STD_ACTS] },
  { id: "frmBuyOrder", label: "سفارش خرید", section: "خرید - فروش - انبار", actions: [...STD_ACTS] },
  { id: "frmProduct", label: "کالا و خدمات", section: "خرید - فروش - انبار", actions: [...STD_ACTS] },
  { id: "frmWareHouse", label: "انبارها", section: "خرید - فروش - انبار", actions: [...STD_ACTS] },
  { id: "frmStock", label: "موجودی و گردش کالا", section: "خرید - فروش - انبار", actions: ["actView", "actInsert"] },
  // خزانه - بانک
  { id: "frmFund", label: "خزانه", section: "خزانه - بانک - پرداخت", actions: [...STD_ACTS, "actVerify"] },
  { id: "frmBanking", label: "بانک‌داری", section: "خزانه - بانک - پرداخت", actions: [...STD_ACTS] },
  { id: "frmOnlinePayment", label: "پرداخت آنلاین", section: "خزانه - بانک - پرداخت", actions: ["actView", "actInsert"] },
  // گزارش‌ها
  { id: "frmReports", label: "گزارش‌ها", section: "گزارش‌ها", actions: ["actView"] },
  // ارتباطات و امنیت کاربران
  { id: "frmDefineUsers", label: "تعریف کاربران", section: "ارتباطات و امنیت کاربران", actions: [
    "actView", "actInsert", "actEdit", "actDelete", "actEditMoreInfo", "actAssignRoll",
    "actUploadSignature", "actManageBankingAccounts", "actLoginAllowedTimes", "actShowDetailsUserCount",
  ] },
  { id: "frmUserRoll", label: "تعریف نقش‌های کاربری", section: "ارتباطات و امنیت کاربران", actions: [...STD_ACTS] },
  { id: "frmRollPermission", label: "تخصیص مجوز برای هر نقش", section: "ارتباطات و امنیت کاربران", actions: ["actView"] },
  { id: "frmSetting", label: "تنظیمات", section: "اطلاعات پایه - تنظیمات", actions: ["actView", "actEdit"] },
  // اقدامات frmMain — تعاریف پایه (مثل خود CRMIdeal که تعاریف با frmMain/actDefine* گیت می‌شوند)
  { id: "frmMain", label: "تعاریف پایه (اقدامات اصلی)", section: "اطلاعات پایه - تنظیمات", actions: [
    "actDefineProjectTitle", "actDefineProjectTitleGroup", "actDefinePrjGroup", "actDefinePrjGrade",
    "actDefinePrjPriority", "actDefinePrjCategory", "actDefinecnvsStatusGroups", "actDefinecnvsStatus",
    "actDefineUserPositions", "actDefineUserGroups", "actDefineDepartments",
    "actDefineCountry", "actDefineProvince", "actDefineCity",
  ] },
  // تعاریف جغرافیایی — بازسازی CompanyDefine{Country,Province,City} (CompanyInfoController):
  // actInsert/actEdit فقط گیتِ بازکردن فرم‌ها هستند؛ عمل ثبت/ویرایش با actPost گیت می‌شود
  // (DynamicAuthorize روی POST هر دو CompanyDefineXInsert و CompanyDefineXEdit = actPost) و حذف با actDelete.
  { id: "frmDefineCountry", label: "تعریف کشورها", section: "اطلاعات پایه - تنظیمات", actions: ["actInsert", "actPost", "actEdit", "actDelete"] },
  { id: "frmDefineProvince", label: "تعریف استان‌ها", section: "اطلاعات پایه - تنظیمات", actions: ["actInsert", "actPost", "actEdit", "actDelete"] },
  { id: "frmDefineCity", label: "تعریف شهرها", section: "اطلاعات پایه - تنظیمات", actions: ["actInsert", "actPost", "actEdit", "actDelete"] },
];

export const FORMS_BY_ID: Record<string, FormMeta> = Object.fromEntries(FORMS.map((f) => [f.id, f]));

export const ACT_LABELS: Record<string, string> = {
  actView: "مشاهده", actInsert: "درج", actEdit: "ویرایش", actDelete: "حذف", actPost: "ثبت",
  actprjInsert: "درج پروژه",
  actCanSetArchive: "اجازه آرشیو پروژه",
  actCanSetPrjIsTicket: "تعیین نوع تیکت",
  actCanChangePrjToDoTime: "تعیین زمان انجام",
  actDeleteCmpProjectWithDep: "حذف پروژه با وابستگی‌ها",
  actDeleteAllCmpProjectsWithDep: "حذف همه پروژه‌ها با وابستگی‌ها",
  actVerify: "تایید / لغو تایید",
  actEditMoreInfo: "ویرایش اطلاعات تکمیلی",
  actAssignRoll: "تخصیص نقش",
  actUploadSignature: "بارگذاری امضا",
  actManageBankingAccounts: "مدیریت حساب‌های بانکی",
  actLoginAllowedTimes: "تعیین ساعت ورود",
  actShowDetailsUserCount: "نمایش جزئیات تعداد کاربران",
  actDefineProjectTitle: "تعریف عنوان‌های پیش‌فرض پروژه",
  actDefineProjectTitleGroup: "تعریف سرفصل‌های پروژه",
  actDefinePrjGroup: "تعریف گروه پروژه",
  actDefinePrjGrade: "تعریف مقطع پروژه",
  actDefinePrjPriority: "تعریف اولویت پروژه",
  actDefinePrjCategory: "تعریف دسته‌بندی پروژه",
  actDefinecnvsStatusGroups: "تعریف مدل‌های پیشرفت",
  actDefinecnvsStatus: "تعریف وضعیت‌های مذاکره",
  actDefineUserPositions: "تعریف سمت‌های سازمانی",
  actDefineUserGroups: "تعریف گروه‌های کاربری",
  actDefineDepartments: "تعریف دپارتمان‌ها",
  actDefineCountry: "تعریف کشورها",
  actDefineProvince: "تعریف استان‌ها",
  actDefineCity: "تعریف شهرها",
};

// نگاشت ماژول‌های قدیمی رستا به فرم‌های CRMIdeal (برای مسیرهای API موجود)
export const MODULE_TO_FORM: Record<ModuleKey, FormId> = {
  dashboard: "frmHomePage",
  companies: "frmCompanyI",
  contacts: "frmCompanyPersons",
  deals: "frmDeals",
  activities: "frmActivities",
  tasks: "frmTasks",
  products: "frmProduct",
  quotations: "frmPreOrder",
  orders: "frmOrder",
  warehouses: "frmWareHouse",
  inventory: "frmStock",
  purchases: "frmBuyOrder",
  users: "frmDefineUsers",
  roles: "frmUserRoll",
  reports: "frmReports",
  settings: "frmSetting",
  fund: "frmFund",
  banking: "frmBanking",
  payments: "frmOnlinePayment",
};

export const ACTION_TO_ACT: Record<ActionKey, string> = {
  view: "actView",
  create: "actInsert",
  edit: "actEdit",
  delete: "actDelete",
};

// ── روزهای هفته (تعیین ساعت ورود — UserLoginAllowedTimes) ──
export const WEEK_DAYS = ["شنبه", "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه"] as const;

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
