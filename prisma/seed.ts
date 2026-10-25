/**
 * Rasta CRM — Database seed
 * Run: bun prisma/seed.ts
 * Creates roles, users (admin/admin123), companies, deals, activities, tasks, products, quotations, orders.
 */
import { PrismaClient } from "@prisma/client";
import { randomBytes, scryptSync } from "crypto";

const db = new PrismaClient();

function hashPassword(password: string): string {
  const salt = randomBytes(16).toString("hex");
  const hash = scryptSync(password, salt, 64).toString("hex");
  return `${salt}:${hash}`;
}

const MODULES = [
  "dashboard", "companies", "contacts", "deals", "activities", "tasks",
  "products", "quotations", "orders", "warehouses", "inventory", "purchases",
  "reports", "users", "roles",
  "fund", "banking", "payments", "settings",
];

function fullPerms() {
  return MODULES.map((m) => ({
    module: m,
    canView: true, canCreate: true, canEdit: true, canDelete: true,
  }));
}

function salesPerms() {
  return [
    { module: "dashboard", canView: true, canCreate: false, canEdit: false, canDelete: false },
    { module: "companies", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "contacts", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "deals", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "activities", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "tasks", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "products", canView: true, canCreate: false, canEdit: false, canDelete: false },
    { module: "quotations", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "orders", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "inventory", canView: true, canCreate: false, canEdit: false, canDelete: false },
    { module: "fund", canView: true, canCreate: true, canEdit: false, canDelete: false },
  ];
}

function purchasePerms() {
  return [
    { module: "warehouses", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "inventory", canView: true, canCreate: true, canEdit: true, canDelete: false },
    { module: "purchases", canView: true, canCreate: true, canEdit: true, canDelete: true },
  ];
}

async function main() {
  console.log("🌱 Seeding Rasta CRM database…");

  // ── wipe (children first) ──
  await db.stockMovement.deleteMany();
  await db.stockLevel.deleteMany();
  await db.purchaseOrderItem.deleteMany();
  await db.purchaseOrder.deleteMany();
  await db.warehouse.deleteMany();
  await db.activityLog.deleteMany();
  await db.onlinePayment.deleteMany();
  await db.bankAccount.deleteMany();
  await db.bankAccountType.deleteMany();
  await db.bankBranch.deleteMany();
  await db.bank.deleteMany();
  await db.fundTransaction.deleteMany();
  await db.fundGroup.deleteMany();
  await db.payment.deleteMany();
  await db.salesOrderItem.deleteMany();
  await db.salesOrder.deleteMany();
  await db.quotationItem.deleteMany();
  await db.quotation.deleteMany();
  await db.activity.deleteMany();
  await db.task.deleteMany();
  await db.deal.deleteMany();
  await db.contact.deleteMany();
  await db.company.deleteMany();
  await db.product.deleteMany();
  await db.rolePermission.deleteMany();
  await db.role.deleteMany();
  await db.user.deleteMany();
  await db.setting.deleteMany();

  // ── settings ──
  await db.setting.createMany({
    data: [
      { key: "app.name", value: "رستا" },
      { key: "app.version", value: "0.2.0" },
      { key: "org.name", value: "شرکت نمونه پارس" },
      { key: "fiscal.taxRate", value: "9" },
      // درگاه‌های پرداخت (فاز ۳ — مثل Areas/OnlinePayment محصول اصلی)
      { key: "gateway.zarinpal.enabled", value: "false" },
      { key: "gateway.zarinpal.merchantId", value: "" },
      { key: "gateway.zarinpal.sandbox", value: "true" },
      { key: "gateway.mellat.enabled", value: "false" },
      { key: "gateway.mellat.terminalId", value: "" },
      { key: "gateway.mellat.userName", value: "" },
      { key: "gateway.parsian.enabled", value: "false" },
      { key: "gateway.parsian.pin", value: "" },
    ],
  });

  // ── roles ──
  const adminRole = await db.role.create({
    data: {
      name: "مدیر سیستم",
      description: "دسترسی کامل به تمام بخش‌ها",
      permissions: { create: fullPerms() },
    },
  });
  const salesManagerRole = await db.role.create({
    data: {
      name: "مدیر فروش",
      description: "مدیریت فروش و مشتریان",
      permissions: {
        create: Object.values(
          [
            ...salesPerms(),
            ...purchasePerms(),
            { module: "reports", canView: true, canCreate: false, canEdit: false, canDelete: false },
          ].reduce<Record<string, { module: string; canView: boolean; canCreate: boolean; canEdit: boolean; canDelete: boolean }>>(
            (acc, p) => {
              acc[p.module] = p; // later entries override earlier
              return acc;
            },
            {}
          )
        ),
      },
    },
  });
  const salesRole = await db.role.create({
    data: {
      name: "کارشناس فروش",
      description: "پیگیری مشتریان و ثبت فروش",
      permissions: { create: salesPerms() },
    },
  });

  // ── users ──
  const admin = await db.user.create({
    data: {
      username: "admin",
      passwordHash: hashPassword("admin123"),
      firstName: "مدیر",
      lastName: "سیستم",
      email: "admin@rasta.local",
      isAdmin: true,
      roleId: adminRole.id,
    },
  });
  const manager = await db.user.create({
    data: {
      username: "manager",
      passwordHash: hashPassword("manager123"),
      firstName: "مریم",
      lastName: "محمدی",
      email: "manager@rasta.local",
      isAdmin: true,
      roleId: salesManagerRole.id,
    },
  });
  const sales1 = await db.user.create({
    data: {
      username: "sales1",
      passwordHash: hashPassword("sales123"),
      firstName: "علی",
      lastName: "رضایی",
      email: "sales1@rasta.local",
      roleId: salesRole.id,
    },
  });
  const sales2 = await db.user.create({
    data: {
      username: "sales2",
      passwordHash: hashPassword("sales123"),
      firstName: "زهرا",
      lastName: "کریمی",
      email: "sales2@rasta.local",
      roleId: salesRole.id,
    },
  });

  // ── products ──
  const products = await Promise.all(
    [
      { name: "لپ‌تاپ سازمانی Dell Latitude 5540", code: "LAP-5540", price: 820000000, cost: 740000000, taxRate: 9, unit: "دستگاه", description: "لپ‌تاپ سازمانی ۱۵ اینچ" },
      { name: "مانیتور LG 27 4K", code: "MON-27-4K", price: 210000000, cost: 175000000, taxRate: 9, unit: "دستگاه" },
      { name: "پرینتر لیزری HP M404", code: "PRN-M404", price: 145000000, cost: 120000000, taxRate: 9, unit: "دستگاه" },
      { name: "سوئیچ شبکه ۲۴ پورت TP-Link", code: "SW-24P", price: 98000000, cost: 78000000, taxRate: 9, unit: "دستگاه" },
      { name: "روتر Mikrotik hEX", code: "RTR-HEX", price: 62000000, cost: 51000000, taxRate: 9, unit: "دستگاه" },
      { name: "کارتریج لیزری ۶۵۰A", code: "CRT-650A", price: 28500000, cost: 22000000, taxRate: 9, unit: "عدد" },
      { name: "نصب و راه‌اندازی شبکه", code: "SRV-NET", price: 95000000, cost: 40000000, taxRate: 9, unit: "سرویس" },
      { name: "پشتیبانی سالانه (اشتراک)", code: "SRV-SUP1Y", price: 240000000, cost: 90000000, taxRate: 9, unit: "سال" },
    ].map((p) => db.product.create({ data: p }))
  );

  // ── companies ──
  const companiesData = [
    { name: "فناوری داده‌پرداز پارس", type: "CUSTOMER", industry: "فناوری اطلاعات", city: "تهران", province: "تهران", phone: "021-88776655", email: "info@dastehpardaz.ir", taxId: "41135678901", econCode: "411223456789" },
    { name: "صنایع غذایی گلبرگ", type: "CUSTOMER", industry: "صنایع غذایی", city: "اصفهان", province: "اصفهان", phone: "031-36655443", email: "sales@golbarg.ir", taxId: "41098765432", econCode: "410112223334" },
    { name: "بازرگانی پویا تجارت خاورمیانه", type: "PROSPECT", industry: "بازرگانی", city: "تهران", province: "تهران", phone: "021-33445566", email: "info@pooyatrade.ir" },
    { name: "کلینیک تخصصی سلامت نو", type: "PROSPECT", industry: "خدمات درمانی", city: "شیراز", province: "فارس", phone: "071-22334455", email: "contact@salamatno.ir" },
    { name: "آموزشگاه زبان پارسا", type: "CUSTOMER", industry: "آموزش", city: "مشهد", province: "خراسان رضوی", phone: "051-38112233", email: "info@parsa-lang.ir" },
    { name: "شرکت مهندسی راه‌سازان البرق", type: "SUPPLIER", industry: "راه‌سازی", city: "کرج", province: "البرز", phone: "026-34445566" },
    { name: "پخش سراسری باران", type: "CUSTOMER", industry: "پخش و توزیع", city: "تبریز", province: "آذربایجان شرقی", phone: "041-35556677", email: "sales@baran-dist.ir" },
    { name: "هتل پنج‌ستاره دریا نور", type: "PARTNER", industry: "هتلداری", city: "بندرعباس", province: "هرمزگان", phone: "076-33445566", email: "info@daryanoor.ir" },
    { name: "توزیع تجهیزات دیجیتال آریا", type: "SUPPLIER", industry: "توزیع سخت‌افزار", city: "تهران", province: "تهران", phone: "021-66778899", email: "sales@aria-dist.ir" },
    { name: "پارس سیستم کارون", type: "SUPPLIER", industry: "شبکه و امنیت", city: "اهواز", province: "خوزستان", phone: "061-3334455", email: "info@karoon-sys.ir" },
  ];
  const companies = await Promise.all(
    companiesData.map((c, i) =>
      db.company.create({
        data: { ...c, ownerId: i % 2 === 0 ? sales1.id : sales2.id, address: `${c.city}، خیابان اصلی، پلاک ${10 + i * 3}` },
      })
    )
  );

  // ── contacts ──
  const contactsData = [
    { companyId: companies[0].id, firstName: "حسین", lastName: "احمدی", jobTitle: "مدیر فناوری اطلاعات", mobile: "0912-1112233", email: "h.ahmadi@dastehpardaz.ir", isPrimary: true },
    { companyId: companies[0].id, firstName: "نرگس", lastName: "صادقی", jobTitle: "کارشناس خرید", mobile: "0912-4445566" },
    { companyId: companies[1].id, firstName: "مهدی", lastName: "طاهری", jobTitle: "مدیرعامل", mobile: "0913-2223344", isPrimary: true },
    { companyId: companies[2].id, firstName: "سعید", lastName: "قاسمی", jobTitle: "مدیر بازرگانی", mobile: "0912-7778899", isPrimary: true },
    { companyId: companies[3].id, firstName: "لیلا", lastName: "موسوی", jobTitle: "مدیر دفتر", mobile: "0917-3334455", isPrimary: true },
    { companyId: companies[4].id, firstName: "امیر", lastName: "نجفی", jobTitle: "مدیر آموزش", mobile: "0915-5556677", isPrimary: true },
    { companyId: companies[6].id, firstName: "رضا", lastName: "بهرامی", jobTitle: "مدیر فروش", mobile: "0914-8889900", isPrimary: true },
  ];
  const contacts = await Promise.all(contactsData.map((c) => db.contact.create({ data: c })));

  // ── deals ──
  const now = new Date();
  const daysAgo = (n: number) => new Date(now.getTime() - n * 86400000);
  const daysAhead = (n: number) => new Date(now.getTime() + n * 86400000);

  const dealsData = [
    { title: "تأمین زیرساخت شبکه دفتر مرکزی", companyId: companies[0].id, contactId: contacts[0].id, stage: "PROPOSAL", amount: 1850000000, probability: 70, priority: "HIGH", ownerId: sales1.id, expectedCloseAt: daysAhead(12) },
    { title: "قرارداد پشتیبانی سالانه ۱۴۰۵", companyId: companies[0].id, stage: "NEGOTIATION", amount: 960000000, probability: 80, priority: "NORMAL", ownerId: sales1.id, expectedCloseAt: daysAhead(6) },
    { title: "خرید ۵۰ دستگاه مانیتور", companyId: companies[1].id, contactId: contacts[2].id, stage: "CONTACTED", amount: 10500000000, probability: 40, priority: "NORMAL", ownerId: sales2.id, expectedCloseAt: daysAhead(20) },
    { title: "راه‌اندازی نرم‌افزار نوبت‌دهی", companyId: companies[3].id, contactId: contacts[4].id, stage: "NEW", amount: 750000000, probability: 20, priority: "NORMAL", ownerId: sales2.id },
    { title: "بروزرسانی کلاس‌های هوشمند", companyId: companies[4].id, contactId: contacts[5].id, stage: "PROPOSAL", amount: 480000000, probability: 60, priority: "LOW", ownerId: sales1.id, expectedCloseAt: daysAhead(15) },
    { title: "سیستم انبار سردخانه", companyId: companies[6].id, contactId: contacts[6].id, stage: "WON", amount: 2400000000, probability: 100, priority: "HIGH", ownerId: sales2.id, closedAt: daysAgo(9), closeNote: "پرداخت نقدی و تحویل دو مرحله‌ای" },
    { title: "شبکه بی‌سیم هتل", companyId: companies[7].id, stage: "LOST", amount: 1350000000, probability: 0, priority: "NORMAL", ownerId: sales1.id, closedAt: daysAgo(4), closeNote: "قیمت رقیب پایین‌تر بود" },
    { title: "خرید سالانه تجهیزات اداری", companyId: companies[5].id, stage: "WON", amount: 620000000, probability: 100, priority: "NORMAL", ownerId: sales2.id, closedAt: daysAgo(28) },
  ];
  const deals = await Promise.all(dealsData.map((d) => db.deal.create({ data: d })));

  // ── activities ──
  const activitiesData = [
    { type: "CALL", direction: "OUTGOING", subject: "پیگیری پیشنهاد ارسالی", body: "آقای احمدی پیشنهاد را بررسی کردند، جلسه فنی هفته آینده", companyId: companies[0].id, dealId: deals[0].id, userId: sales1.id, occurredAt: daysAgo(1), nextStep: "جلسه فنی با تیم زیرساخت", nextAt: daysAhead(3) },
    { type: "MEETING", subject: "جلسه معرفی محصول", companyId: companies[1].id, dealId: deals[2].id, userId: sales2.id, occurredAt: daysAgo(2), body: "حضوری در دفتر مشتری. مانیتورهای ۲۷ اینچ مورد پسند بود." },
    { type: "EMAIL", direction: "OUTGOING", subject: "ارسال پیش‌فاکتور شماره ۱۰۰۲", companyId: companies[4].id, userId: sales1.id, occurredAt: daysAgo(3) },
    { type: "NOTE", subject: "یادداشت از نمایشگاه", body: "در غرفه رقیب، روی تخفیف نقدی مانور می‌دهند.", userId: sales1.id, occurredAt: daysAgo(5) },
    { type: "SMS", direction: "OUTGOING", subject: "یادآوری جلسه", companyId: companies[3].id, userId: sales2.id, occurredAt: daysAgo(1) },
    { type: "CALL", direction: "INCOMING", subject: "استعلام قیمت کارتریج", companyId: companies[6].id, userId: sales2.id, occurredAt: new Date(now.getTime() - 7200000) },
  ];
  await Promise.all(activitiesData.map((a) => db.activity.create({ data: a })));

  // ── tasks ──
  const tasksData = [
    { title: "ارسال قرارداد پشتیبانی برای امضا", assigneeId: sales1.id, creatorId: manager.id, companyId: companies[0].id, dealId: deals[1].id, dueAt: daysAhead(1), priority: "HIGH" },
    { title: "پیگیری تلفنی آقای طاهری", assigneeId: sales2.id, creatorId: sales2.id, companyId: companies[1].id, dueAt: daysAhead(2), priority: "NORMAL" },
    { title: "تهیه پیشنهاد قیمت شبکه هتل", assigneeId: sales1.id, creatorId: manager.id, dueAt: daysAhead(4), priority: "NORMAL" },
    { title: "بستن پرونده فرصت از‌دست‌رفته و ثبت دلایل", assigneeId: sales1.id, creatorId: manager.id, dueAt: daysAgo(1), priority: "LOW" },
    { title: "تماس با کلینیک سلامت نو", assigneeId: sales2.id, creatorId: sales2.id, companyId: companies[3].id, dueAt: daysAhead(0), priority: "URGENT" },
    { title: "ثبت رسید نقدی فاکتور ۱۰۰۳", assigneeId: sales2.id, creatorId: sales2.id, dueAt: daysAhead(-2), priority: "HIGH" },
  ];
  await Promise.all(
    tasksData.map((t) =>
      db.task.create({
        data: { ...t, status: t.dueAt && t.dueAt < now && t.title.includes("بستن") ? "DONE" : "OPEN", doneAt: t.title.includes("بستن") ? now : null },
      })
    )
  );

  // ── quotation ──
  const q1 = await db.quotation.create({
    data: {
      number: 1001,
      companyId: companies[0].id,
      contactId: contacts[0].id,
      dealId: deals[0].id,
      issueDate: daysAgo(6),
      validUntil: daysAhead(24),
      status: "SENT",
      ownerId: sales1.id,
      note: "تحویل مرحله‌ای، گارانتی ۱۸ ماهه",
      items: {
        create: [
          { productId: products[0].id, qty: 8, unitPrice: 820000000, taxRate: 9, lineTotal: 8 * 820000000 * 1.09 },
          { productId: products[1].id, qty: 8, unitPrice: 210000000, taxRate: 9, lineTotal: 8 * 210000000 * 1.09 },
          { productId: products[4].id, qty: 2, unitPrice: 62000000, taxRate: 9, lineTotal: 2 * 62000000 * 1.09 },
          { productId: products[6].id, qty: 1, unitPrice: 95000000, taxRate: 9, lineTotal: 95000000 * 1.09 },
        ],
      },
    },
  });
  await db.quotation.update({
    where: { id: q1.id },
    data: {
      subtotal: 8 * 820000000 + 8 * 210000000 + 2 * 62000000 + 95000000,
      taxTotal: 0.09 * (8 * 820000000 + 8 * 210000000 + 2 * 62000000 + 95000000),
      total: 1.09 * (8 * 820000000 + 8 * 210000000 + 2 * 62000000 + 95000000),
    },
  });

  const q2 = await db.quotation.create({
    data: {
      number: 1002,
      companyId: companies[4].id,
      dealId: deals[4].id,
      issueDate: daysAgo(3),
      validUntil: daysAhead(27),
      status: "ACCEPTED",
      ownerId: sales1.id,
      items: {
        create: [
          { productId: products[2].id, qty: 2, unitPrice: 145000000, taxRate: 9, lineTotal: 2 * 145000000 * 1.09 },
          { productId: products[5].id, qty: 4, unitPrice: 28500000, taxRate: 9, lineTotal: 4 * 28500000 * 1.09 },
        ],
      },
    },
  });
  await db.quotation.update({
    where: { id: q2.id },
    data: {
      subtotal: 2 * 145000000 + 4 * 28500000,
      taxTotal: 0.09 * (2 * 145000000 + 4 * 28500000),
      total: 1.09 * (2 * 145000000 + 4 * 28500000),
    },
  });

  // ── orders ──
  const o1 = await db.salesOrder.create({
    data: {
      number: 1001,
      quotationId: null,
      companyId: companies[6].id,
      issueDate: daysAgo(9),
      status: "ISSUED",
      ownerId: sales2.id,
      subtotal: 2400000000,
      taxTotal: 216000000,
      total: 2616000000,
      items: {
        create: [
          { productId: products[3].id, qty: 10, unitPrice: 98000000, taxRate: 9, lineTotal: 10 * 98000000 * 1.09 },
          { productId: products[4].id, qty: 20, unitPrice: 62000000, taxRate: 9, lineTotal: 20 * 62000000 * 1.09 },
        ],
      },
    },
  });
  await db.payment.create({
    data: { orderId: o1.id, amount: 1500000000, method: "TRANSFER", paidAt: daysAgo(8), note: "واریز نیمه اول" },
  });
  await db.salesOrder.update({ where: { id: o1.id }, data: { paidTotal: 1500000000 } });

  const o2 = await db.salesOrder.create({
    data: {
      number: 1002,
      quotationId: q2.id,
      companyId: q2.companyId,
      issueDate: daysAgo(28),
      status: "PAID",
      ownerId: sales1.id,
      subtotal: 2 * 145000000 + 4 * 28500000,
      taxTotal: 0.09 * (2 * 145000000 + 4 * 28500000),
      total: 1.09 * (2 * 145000000 + 4 * 28500000),
      items: {
        create: [
          { productId: products[2].id, qty: 2, unitPrice: 145000000, taxRate: 9, lineTotal: 2 * 145000000 * 1.09 },
          { productId: products[5].id, qty: 4, unitPrice: 28500000, taxRate: 9, lineTotal: 4 * 28500000 * 1.09 },
        ],
      },
    },
  });
  await db.quotation.update({ where: { id: q2.id }, data: { status: "CONVERTED" } });
  const total2 = 1.09 * (2 * 145000000 + 4 * 28500000);
  await db.payment.create({
    data: { orderId: o2.id, amount: total2, method: "CASH", paidAt: daysAgo(27) },
  });
  await db.salesOrder.update({ where: { id: o2.id }, data: { paidTotal: total2 } });

  // ── warehouses & stock (Phase 2) ──
  const wh1 = await db.warehouse.create({
    data: { name: "انبار مرکزی", code: "WH-Main", location: "تهران، خیابان کارگر شمالی", isDefault: true, note: "انبار اصلی محصولات فیزیکی" },
  });
  const wh2 = await db.warehouse.create({
    data: { name: "انبار شعبه اصفهان", code: "WH-Isf", location: "اصفهان، خیابان چهارباغ بالا" },
  });

  // movement history (sums match the final stock levels below)
  const movementsData = [
    // opening receipt — 30 days ago
    ...[1, 2, 3, 4, 5].map((pi) => ({
      type: "IN" as const,
      productId: products[pi].id,
      toWarehouseId: wh1.id,
      quantity: [0, 35, 18, 40, 50, 100][pi],
      unitCost: products[pi].cost,
      refType: "MANUAL",
      note: "موجودی اولیه دوره",
      userId: admin.id,
      movedAt: daysAgo(30),
    })),
    // received purchase order 1001 — 20 days ago (20 laptops)
    {
      type: "IN" as const,
      productId: products[0].id,
      toWarehouseId: wh1.id,
      quantity: 20,
      unitCost: 740000000,
      refType: "PURCHASE_ORDER",
      note: "رسید خرید سفارش شماره 1001",
      userId: manager.id,
      movedAt: daysAgo(20),
    },
    // sales order 1002 issue — 27 days ago (2 printers + 4 cartridges)
    { type: "OUT" as const, productId: products[2].id, fromWarehouseId: wh1.id, quantity: 2, refType: "SALES_ORDER", note: "صدور فاکتور فروش شماره 1002", userId: sales1.id, movedAt: daysAgo(27) },
    { type: "OUT" as const, productId: products[5].id, fromWarehouseId: wh1.id, quantity: 4, refType: "SALES_ORDER", note: "صدور فاکتور فروش شماره 1002", userId: sales1.id, movedAt: daysAgo(27) },
    // project sale — 10 days ago (14 printers, leaves low stock for demo)
    { type: "OUT" as const, productId: products[2].id, fromWarehouseId: wh1.id, quantity: 14, refType: "MANUAL", note: "فروش پروژه‌ای دانشگاه", userId: sales1.id, movedAt: daysAgo(10) },
    // sales order 1001 issue — 8 days ago (10 switches + 20 routers)
    { type: "OUT" as const, productId: products[3].id, fromWarehouseId: wh1.id, quantity: 10, refType: "SALES_ORDER", note: "صدور فاکتور فروش شماره 1001", userId: sales2.id, movedAt: daysAgo(8) },
    { type: "OUT" as const, productId: products[4].id, fromWarehouseId: wh1.id, quantity: 20, refType: "SALES_ORDER", note: "صدور فاکتور فروش شماره 1001", userId: sales2.id, movedAt: daysAgo(8) },
    // transfer to Isfahan branch — 5 days ago
    { type: "TRANSFER" as const, productId: products[1].id, fromWarehouseId: wh1.id, toWarehouseId: wh2.id, quantity: 10, refType: "MANUAL", note: "تأمین موجودی شعبه", userId: manager.id, movedAt: daysAgo(5) },
    { type: "TRANSFER" as const, productId: products[4].id, fromWarehouseId: wh1.id, toWarehouseId: wh2.id, quantity: 10, refType: "MANUAL", note: "تأمین موجودی شعبه", userId: manager.id, movedAt: daysAgo(5) },
    // counter sale — 4 days ago
    { type: "OUT" as const, productId: products[5].id, fromWarehouseId: wh1.id, quantity: 12, refType: "MANUAL", note: "فروش حضوری", userId: sales2.id, movedAt: daysAgo(4) },
    // damage adjustment — 2 days ago
    { type: "ADJUST" as const, productId: products[5].id, toWarehouseId: wh1.id, quantity: -3, refType: "MANUAL", note: "نقص و شکست در انبارشماری", userId: admin.id, movedAt: daysAgo(2) },
  ];
  for (const m of movementsData) {
    await db.stockMovement.create({ data: m });
  }

  // final stock levels (match movement history)
  const levelsData = [
    { p: 0, w: wh1.id, q: 20 },   // لپ‌تاپ
    { p: 1, w: wh1.id, q: 25 },   // مانیتور
    { p: 1, w: wh2.id, q: 10 },
    { p: 2, w: wh1.id, q: 2 },    // پرینتر — رو به اتمام (دموی هشدار)
    { p: 3, w: wh1.id, q: 30 },   // سوئیچ
    { p: 4, w: wh1.id, q: 20 },   // روتر
    { p: 4, w: wh2.id, q: 10 },
    { p: 5, w: wh1.id, q: 81 },   // کارتریج
  ];
  for (const l of levelsData) {
    await db.stockLevel.create({
      data: { productId: products[l.p].id, warehouseId: l.w, quantity: l.q },
    });
  }

  // ── purchase orders ──
  const po1Sub = 20 * 740000000;
  await db.purchaseOrder.create({
    data: {
      number: 1001,
      supplierId: companies[8].id,
      warehouseId: wh1.id,
      issueDate: daysAgo(21),
      expectedAt: daysAgo(20),
      receivedAt: daysAgo(20),
      status: "RECEIVED",
      note: "خرید یکجای لپ‌تاپ‌های سازمانی",
      ownerId: manager.id,
      subtotal: po1Sub,
      taxTotal: po1Sub * 0.09,
      total: po1Sub * 1.09,
      items: {
        create: [
          { productId: products[0].id, description: products[0].name, qty: 20, unitPrice: 740000000, taxRate: 9, lineTotal: 20 * 740000000 * 1.09 },
        ],
      },
    },
  });

  const po2Sub = 10 * 175000000 + 40 * 22000000;
  await db.purchaseOrder.create({
    data: {
      number: 1002,
      supplierId: companies[9].id,
      warehouseId: wh1.id,
      issueDate: daysAgo(2),
      expectedAt: daysAhead(5),
      status: "ORDERED",
      note: "در انتظار تحویل — ترجیحاً قبل از پایان هفته",
      ownerId: manager.id,
      subtotal: po2Sub,
      taxTotal: po2Sub * 0.09,
      total: po2Sub * 1.09,
      items: {
        create: [
          { productId: products[1].id, description: products[1].name, qty: 10, unitPrice: 175000000, taxRate: 9, lineTotal: 10 * 175000000 * 1.09 },
          { productId: products[5].id, description: products[5].name, qty: 40, unitPrice: 22000000, taxRate: 9, lineTotal: 40 * 22000000 * 1.09 },
        ],
      },
    },
  });

  /* ═══════════════ فاز ۳ — مالی: خزانه + بانک‌داری + پرداخت آنلاین ═══════════════ */

  // ── درخت گروه‌های خزانه (مثل _PartialFundGroupTree) ──
  const gCash = await db.fundGroup.create({ data: { name: "تنخواه نقدی", order: 1 } });
  const gBank = await db.fundGroup.create({ data: { name: "حساب‌های بانکی", order: 2 } });
  const gPetty = await db.fundGroup.create({
    data: { name: "پتی‌کاسپند", parentId: gCash.id, order: 1 },
  });
  const gMain = await db.fundGroup.create({
    data: { name: "تنخواه مرکزی", parentId: gCash.id, order: 2 },
  });
  const gIncome = await db.fundGroup.create({
    data: { name: "دریافت‌های فروش", parentId: gBank.id, order: 1 },
  });
  const gExpense = await db.fundGroup.create({
    data: { name: "هزینه‌های جاری", parentId: gBank.id, order: 2 },
  });

  // ── اسناد خزانه (رسید/پرداخت — مثل CrmFund با FundDebit/FundCredit) ──
  const fundRows: {
    number: number; group: string; type: "RECEIVE" | "PAY"; amount: number;
    day: number; desc: string; verified: boolean;
  }[] = [
    { number: 1, group: gMain.id, type: "RECEIVE", amount: 500_000_000, day: 40, desc: "شارژ اولیه تنخواه مرکزی از حساب شرکت", verified: true },
    { number: 2, group: gPetty.id, type: "RECEIVE", amount: 60_000_000, day: 35, desc: "انتقال وجه به پتی‌کاسپند واحد فروش", verified: true },
    { number: 3, group: gIncome.id, type: "RECEIVE", amount: 145_800_000, day: 28, desc: "دریافت وجه فاکتور فروش شماره ۲", verified: true },
    { number: 4, group: gExpense.id, type: "PAY", amount: 18_500_000, day: 25, desc: "هزینه تبلیغات بنری نمایشگاه", verified: true },
    { number: 5, group: gPetty.id, type: "PAY", amount: 4_200_000, day: 20, desc: "خرید لوازم اداری", verified: false },
    { number: 6, group: gIncome.id, type: "RECEIVE", amount: 98_000_000, day: 14, desc: "چک مشتری — شرکت آریا صنعت", verified: false },
    { number: 7, group: gExpense.id, type: "PAY", amount: 32_000_000, day: 10, desc: "پرداخت اجاره دفتر مرکزی", verified: true },
    { number: 8, group: gMain.id, type: "RECEIVE", amount: 210_000_000, day: 5, desc: "دریافت پیش‌پرداخت پروژه پارس‌داده", verified: false },
    { number: 9, group: gExpense.id, type: "PAY", amount: 9_800_000, day: 2, desc: "هزینه پذیرایی جلسات مشتریان", verified: false },
  ];
  for (const row of fundRows) {
    await db.fundTransaction.create({
      data: {
        number: row.number,
        groupId: row.group,
        custodianId: admin.id,
        type: row.type,
        amount: row.amount,
        date: daysAgo(row.day),
        description: row.desc,
        isVerified: row.verified,
        verifiedById: row.verified ? manager.id : null,
        verifiedAt: row.verified ? daysAgo(row.day - 1) : null,
        createdById: admin.id,
      },
    });
  }

  // ── بانک‌ها و شعب (مثل Areas/Banking: بانک → شعبه → حساب) ──
  const bankMelli = await db.bank.create({ data: { code: "01", name: "بانک ملی ایران" } });
  const bankMellat = await db.bank.create({ data: { code: "12", name: "بانک ملت" } });
  const bankSaman = await db.bank.create({ data: { code: "56", name: "بانک سامان" } });
  const bankParsian = await db.bank.create({ data: { code: "54", name: "بانک پارسیان" } });

  const brMelliMarkazi = await db.bankBranch.create({
    data: { bankId: bankMelli.id, name: "شعبه مرکزی تهران", tel: "021-33901111" },
  });
  const brMellatSadeghiye = await db.bankBranch.create({
    data: { bankId: bankMellat.id, name: "شعبه صادقیه", tel: "021-44670000" },
  });
  const brSamanVanak = await db.bankBranch.create({
    data: { bankId: bankSaman.id, name: "شعبه ونک", tel: "021-88960000" },
  });
  const brParsianValiasr = await db.bankBranch.create({
    data: { bankId: bankParsian.id, name: "شعبه ولیعصر", tel: "021-88770000" },
  });

  // ── انواع حساب (BankAccountType) ──
  const accCurrent = await db.bankAccountType.create({ data: { name: "جاری" } });
  const accSaving = await db.bankAccountType.create({ data: { name: "سپرده" } });
  const accGharz = await db.bankAccountType.create({ data: { name: "قرض‌الحسنه" } });

  // ── حساب‌های بانکی (BankAccount) ──
  await db.bankAccount.createMany({
    data: [
      {
        branchId: brMelliMarkazi.id, accountTypeId: accCurrent.id,
        accountNumber: "0104567890011", cardNumber: "6104-3378-1234-5678",
        shabaNumber: "IR820120010000004567890011", accountOwner: "شرکت نمونه پارس", isDefault: true,
        desc: "حساب اصلی درآمد فروش",
      },
      {
        branchId: brMellatSadeghiye.id, accountTypeId: accCurrent.id,
        accountNumber: "1234567890", cardNumber: "6104-3378-8765-4321",
        shabaNumber: "IR120120000000001234567890", accountOwner: "شرکت نمونه پارس",
        desc: "حساب هزینه‌های جاری",
      },
      {
        branchId: brSamanVanak.id, accountTypeId: accSaving.id,
        accountNumber: "8888-7777-6666-5555", shabaNumber: "IR560560000000888877776666",
        accountOwner: "شرکت نمونه پارس", desc: "سپرده سرمایه‌گذاری کوتاه‌مدت",
      },
      {
        branchId: brParsianValiasr.id, accountTypeId: accGharz.id,
        accountNumber: "5544-3322-1100-9988", accountOwner: "خیریه نیکوکار",
        desc: "حساب قرض‌الحسنه پرسنلی",
      },
    ],
  });

  // ── یک پرداخت آنلاین نمونه (درگاه غیرفعال → وضعیت Pending) ──
  await db.onlinePayment.create({
    data: {
      gateway: "ZARINPAL",
      amount: 25_000_000,
      description: "پرداخت آنلاین فاکتور فروش شماره ۱ — درگاه هنوز فعال نیست",
      status: "PENDING",
      payerName: "شرکت آریا صنعت",
      payerMobile: "09121234567",
    },
  });

  console.log("✅ Seed complete!");
  console.log("   ورود: admin/admin123 · manager/manager123 · sales1/sales123 · sales2/sales123");
}

main()
  .catch((e) => {
    console.error("❌ Seed failed:", e);
    process.exit(1);
  })
  .finally(() => db.$disconnect());
