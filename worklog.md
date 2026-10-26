# Worklog

---
Task ID: 1
Agent: main (Z.ai)
Task: Download and analyze CRMIdeal CRM project from filebin (https://filebin.net/x3vt5etfa6e58r7x)

Work Log:
- Downloaded `crm web full-187.zip` (187MB) with resume to /home/z/my-project/project-analysis/crm-web.zip
- Extracted to /home/z/my-project/project-analysis/crm-project (12,564 files)
- Identified: published ASP.NET MVC 5 build (no .cs source; 1446 .cshtml views; compiled DLLs in bin/)
- Launched 4 parallel Explore agents: Areas analysis, Config/stack analysis, Frontend analysis, DLL/API analysis

Stage Summary:
- Project = CRMIdeal v3.1.18.187 by KaraAfzar (Iranian multi-tenant CRM)
- Stack: .NET FW 4.7, MVC 5.2.9, WebAPI 2, EF5 (7 EDMX models), SignalR 2.2.0, Kendo UI, SQL Server
- 46 Areas, 279 controllers in CRMIdeal.dll + 26 API controllers (CRMIdealApi.dll) + ~97 in Mobile.dll
- Full findings delivered to user in Persian

---
Task ID: 2
Agent: main (Z.ai)
Task: Decompile all DLLs of CRMIdeal

Work Log:
- Installed .NET 8 SDK to /home/z/.dotnet (user-local, no root) + ilspycmd 8.2.0.7535 (DOTNET_ROLL_FORWARD=Major)
- Decompiled ALL main assemblies with `ilspycmd -p --nested-directories` to /home/z/my-project/project-analysis/decompiled/:
  - CRMIdeal.dll → 1246 files (34MB source) — 404 controllers, 46 areas
  - CRMIdealApi.dll → 805 files (12MB) — 26 Api* controllers
  - Mobile.dll → 1650 files (18MB) — ~97 controllers (HRM/FO/CIC)
  - Models.dll → 4943 files (52MB) — 4766 entity classes, 7 EF DbContexts
  - General.dll (48), OtherWebServices.dll (289), RegisterCompany.dll (30), Resources.dll (5.1MB)
- TOTAL: 8,970 C# files (~120MB of readable source)
- Analyzed core entities (CrmCompany, CrmCompanyPersons, CrmProjects, WSOrder, Users, UsersPermission) to design the new schema

Stage Summary:
- Full source recovery achieved (no encryption/licensing enabled, per user request — deferred to later)
- Legacy domain model mapped: Companies/Persons/Projects/Conversations + WSOrder/WSPreOrder + RBAC (Rolls/UsersPermission)

---
Task ID: 3
Agent: main (Z.ai)
Task: Rebuild CRMIdeal as modern product "Rasta" (رستا)

Work Log:
- Loaded fullstack-dev skill; initialized Next.js 16 scaffold
- Designed & pushed Prisma schema (13 models: User, Role, RolePermission, Company, Contact, Deal, Activity, Task, Product, Quotation+Items, SalesOrder+Items, Payment, Setting, ActivityLog) — SQLite dev, PostgreSQL-ready
- Wrote core libs: src/lib/auth.ts (scrypt + jose JWT HttpOnly cookie + RBAC), jalali.ts (Jalali calendar, Persian digits), http.ts (API guards), constants.ts (Persian labels), format.ts
- Built 15 REST API routes (auth login/logout/me, companies, contacts, deals incl. stage PATCH, activities, tasks incl. toggle, products, quotations incl. convert-to-order, orders incl. payments, users, roles, dashboard, reports)
- Built UI: RTL Persian shell (shadcn sidebar side="right" for RTL, fixed left-overlay bug), Vazirmatn local font, emerald theme, login page, dashboard (KPIs + Recharts funnel + cartable widget + activity feed), companies list/detail (tabs), contacts, deals (Kanban board + list), activities timeline, tasks cartable, products, quotations (items editor + totals + print view), orders (payments dialog), users, roles (permission matrix), reports (3 charts + top-10)
- Seeded realistic Persian demo data (4 users, 3 roles, 8 companies, 7 contacts, 8 deals, 6 activities, 6 tasks, 8 products, 2 quotations, 2 orders, payments) via prisma/seed.ts
- Fixed: Cascade casing, SQLite no-autoincrement-on-non-id (numbers computed in code), role unique(module), jalali-input setState-in-effect (React render-adjust pattern), useList loading derived, Sidebar side="right"
- Lint: clean (0 errors). Dev server restarted (was dead) via .zscripts/dev.sh
- E2E browser verification (agent-browser): login admin/admin123 → dashboard KPIs render; companies CRUD dialog works (created "شرکت تست رستا"); deals board shows 8 cards; tasks scope toggle works; quotations dialog (items+totals) works; reports 3 charts render; logout works; 0 console errors

Stage Summary:
- Rasta v1.0 MVP delivered: modern rewrite of CRMIdeal core — Next.js 16 + TS + Prisma + shadcn/ui, single clean codebase
- Login: admin/admin123 (also manager/manager123, sales1/sales123, sales2/sales123)
- Decompiled legacy source preserved at project-analysis/decompiled/ for future module porting (inventory, HR, SMS, AI, accounting links...)

---
Task ID: 4
Agent: main (Z.ai)
Task: Bootstrap GitHub repo P3D4AM/Rasta — push all project files, create develop branch, commit/push all future work

Work Log:
- Checked remote via API: repo exists, private, empty, default branch main, full admin/push permissions
- Local .git was polluted: auto-snapshot history contained the 187MB legacy zip + 600MB crm-project site (GitHub 100MB/file limit would reject the push) and tracked .env (AUTH_SECRET)
- Decision: restart history from one clean orphan baseline commit (1275fdaf); old history preserved LOCALLY as branch archive/scaffold-history (never pushed)
- Hardened .gitignore: secrets (.gh_token/.gh_credentials/.env), runtime db, env artifacts (.zscripts, Caddyfile, tool-results, examples, mini-services, tests, upload, download, skills), legacy raw binaries (zip + site)
- Renamed package to "rasta" v0.1.0; added .env.example; moved MVP screenshots to docs/screenshots/; wrote README.md, docs/analysis/01-legacy-crm-analysis.md, docs/roadmap.md
- Baseline pushed to origin main (9,158 files: MVP app + ~9k decompiled reference files + docs)
- Created develop from main and pushed; BRANCH POLICY: all future work ONLY on develop until owner approves initial release; main is the release line (merge only with owner approval)

Stage Summary:
- Repo live: https://github.com/P3D4AM/Rasta (private) — branches: main (baseline 1275fdaf) + develop (active)
- Auth: PAT at /home/z/my-project/.gh_token; git credential store at /home/z/my-project/.gh_credentials (both gitignored — NEVER commit)
- FUTURE SESSIONS MUST: `git checkout develop && git pull` before work; commit + push to develop after every task
- Local-only (not in repo): archive/scaffold-history branch, legacy zip + site under project-analysis/

ADDENDUM (post-push, same task): the sandbox auto-snapshot mechanism flips HEAD to local main between tool calls and can absorb uncommitted changes (it caused the first worklog commit to land on local main instead of develop). State corrected: develop reset to d1780812 (worklog commit, pushed), local main reset back to baseline 1275fdaf (= remote main). Remote verified: main=1275fdaf (frozen release line), develop=d1780812 (active).

Countermeasure protocol for ALL future sessions:
1. `git checkout develop && git pull` at session start
2. `git branch --show-current` before EVERY commit
3. edit + commit + push in the smallest possible window (one atomic Bash when touching files that differ across branches); leave nothing uncommitted
4. local main may accumulate UUID auto-snapshot commits — NEVER push local main; remote main stays frozen at baseline until owner-approved release

---
Task ID: 4
Agent: main (Z.ai)
Task: Enforce Git workflow (repo P3D4AM/Rasta, work only on develop) + deliver Phase 2 (انبار و خرید)

Work Log:
- Verified git state: main & develop in sync with origin; confirmed token in local credential store (.gh_credentials, gitignored); switched to develop as the only working branch per owner directive
- Tried to set GitHub default branch to develop via API — blocked: fine-grained PAT lacks repo Administration permission (owner can switch manually in Settings → Branches)
- Phase 2 schema: Warehouse, StockLevel (unique product×warehouse), StockMovement (IN/OUT/TRANSFER/ADJUST + refType/refId), PurchaseOrder(+Item) with supplier/warehouse/owner relations
- Stock engine src/lib/stock.ts: transactional applyMovementTx (validates availability, Persian 409 errors), reverseMovementsTx (cancel restore), issueStockForOrder (sales issue deducts from default warehouse); src/lib/purchase.ts totals helpers
- New APIs: /api/warehouses (CRUD + soft-deactivate on history), /api/inventory (levels + summary + low-stock threshold 5), /api/stock-movements (history + manual create), /api/purchases + /api/purchases/[id] (GET/PUT/DELETE/PATCH: setStatus | receive → IN movements + RECEIVED)
- Orders API integration: issue → OUT movements from default warehouse (409 on shortage with product name & current stock); cancel of issued order → movements reversed & stock restored
- UI: nav group «انبار و خرید» — /warehouses (CRUD dialog, default star, value per warehouse), /inventory (4 summary cards + levels/movements tabs + movement dialog with 4 types + product stock card), /purchases (items editor with cost-prefill, ORDERED→receive flow, read-only view mode); JalaliDateInput gained disabled prop; StatusBadge new colors (ORDERED/RECEIVED/IN/OUT/TRANSFER/ADJUST)
- Seed: 2 warehouses, 15 historical movements (opening, PO receipt, sales issues, transfers, adjust), 8 stock levels (PRN left at 2 for low-stock demo), 2 POs (RECEIVED + ORDERED), 2 new supplier companies, RBAC modules warehouses/inventory/purchases (manager full, sales view)
- Bugs fixed during E2E: (1) warehouseId=ALL sentinel leaked into Prisma where → empty tables, (2) purchases page `total` name collision → build error, (3) ESLint OOM on legacy 160MB JS — project-analysis/** now ignored in eslint config
- E2E (agent-browser, admin login): inventory shows 8 levels + summary; IN movement 81→86; PO 1002 receive → CRT 86→126 & MON 25→35; order issue 126→124 and cancel 124→126; 5000-unit order blocked with «موجودی کافی نیست…» 409; orders/roles pages intact; lint 0 errors
- Screenshots: docs/screenshots/rasta-phase2-{inventory,purchases,warehouses}.png
- All work committed & pushed to develop in 5 logical commits

Stage Summary:
- Phase 2 (انبار و خرید) delivered, E2E-verified and pushed to develop; branch policy: main = release line (untouched), develop = active
- Next per roadmap: Phase 3 مالی (خزانه/بانک/درگاه پرداخت) — awaiting owner go-ahead

---
Task ID: 5
Agent: main (Z.ai)
Task: بازسازی میلیمتری UI مطابق CRMIdeal + فاز ۳ (مالی) — دستور مالک پروژه

Work Log:
- استخراج دقیق سیستم طراحی از سورس اصلی: MainStyleNew.css، StyPublic.css، StyLogin.css، StyHomePage.css، _LayoutMain.cshtml، sidebar-menu.js، jsPublicFunction.js، Areas/Fund+Banking+OnlinePayment، Models دیکامپایل‌شده (CrmFund/CrmFundGroups/CrmBanking*)، Resources.Menus.resx (۸۷۷ کلید)
- توکن‌های طراحی: فونت Ravi (۸ وزن، کپی به public/fonts)، ریل سرمه‌ای #012875، متن منو #e7eaf2، قرص‌ها #e7effc، حاشیه pill #8598be، هدر کارت #528fcc، لاگین #509ACF/#0373BD
- بازسازی globals.css: فونت‌فیس Ravi + پالت کامل CRMIdeal به‌صورت توکن (--crm-navy و…) + کلاس‌های crm-rail/crm-pill/crm-section/crm-qa-item با متریک میلیمتری
- بازسازی app-shell.tsx مطابق _LayoutMain: ریل آیکونی تمام‌قد سرمه‌ای (۸۰px→۲۶۰px با زیرمنوی کشویی و رفتار ShowSideBarMenuIcons)، هدر ۱۱۰px با pill جستجو + بخش کاربر (کره/ایمیل #fdcc3b/پیامک/زنگ #df63a0/زنگ #29b2c2/پروفایل با دراپ‌داون ۱۹۵px) + باکس لوگوی شرکت
- درخت منو مطابق mu* های CRMIdeal: خانه/مشتریان/فروش/انبار و خرید (با صفحات فاز ۲)/خزانه و بانک (فاز ۳)/ارتباطات/کارتابل/گزارش‌ها/مدیریت و تنظیمات + خروج
- بازسازی صفحه ورود مطابق Login.cshtml: پنل آبی #509ACF + آیکون‌های چسبیده #0373BD + دکمه سه‌بعدی + پنل معرفی #f3f3f3
- بازسازی داشبورد مطابق HomePage.cshtml: ۸ قرص دسترسی سریع (#e7effc، ۱۷px ravi-regular، فلش #50a5d2) + تب نمودارها + KPI + کارتابل + اطلاعیه گوشه پایین
- فاز ۳ — اسکیمای Prisma: FundGroup (درخت) + FundTransaction (شماره سند خودکار، دریافت/پرداخت، گردش کار تایید) + Bank/BankBranch/BankAccountType/BankAccount (کارت/شبا/پیش‌فرض) + OnlinePayment (زرین‌پال/ملت/پارسیان)
- فاز ۳ — API: /api/fund/groups (CRUD درخت)، /api/fund/transactions (لیست+فیلتر تاریخ/گروه/نوع/تایید + فوتر جمع GetFundSumFooter + درج/ویرایش/تایید/لغو تایید)، /api/banking/banks (بانک+شعبه)، /api/banking/accounts، /api/payments/gateways (تنظیمات درگاه)، /api/payments/online (شروع پرداخت زرین‌پال sandbox + تایید دستی)
- فاز ۳ — UI: /fund (درخت گروه‌ها + جدول + فوتر جمع + دیالوگ دریافت/پرداخت با تاریخ جلالی)، /banking (تب بانک‌ها و شعب / حساب‌ها)، /settings/payments (۳ کارت درگاه + لیست پرداخت‌ها)
- merge با فاز ۲ موجود روی develop: ادغام اسکیما/سید/constants/http/app-shell (منوی انبار و خرید با لینک‌های واقعی warehouses/inventory/purchases)، رفع تداخل‌ها، رفع باگ MODULES تکراری
- فیکس تایپ‌های باقی‌مانده از قبل: reports route (کلید تکراری/ایندکس null)، reports page (recharts label)، roles orderBy، orders include، quotations export، layout cast، nextDocNumber union
- tsconfig: exclude examples/skills/agent-ctx → tsc --noEmit = 0 خطا، eslint = 0 خطا/هشدار
- E2E (agent-browser): لاگین، داشبورد جدید، باز/بسته شدن ریل + زیرمنوها، درج سند خزانه (تست موفق)، فوتر جمع، بانک‌داری (هر دو تب)، پرداخت آنلاین، صفحات فاز ۲ با UI جدید — ۰ خطای کنسول؛ تأیید بصری VLM برای داشبورد و لاگین
- داده دموی فاز ۳: ۶ گروه خزانه درختی، ۹ سند رسید/پرداخت، ۴ بانک، ۴ شعبه، ۳ نوع حساب، ۴ حساب بانکی، ۱ پرداخت آنلاین pending، تنظیمات درگاه‌ها

Stage Summary:
- UI رستا از این پس بازسازی میلیمتری CRMIdeal است (فونت Ravi + پالت کامل + ریل سرمه‌ای + pillها + الگوی کارت #528fcc)
- فاز ۳ (مالی) کامل: خزانه + بانک‌داری + پرداخت آنلاین — E2E تست‌شده
- نسخه 0.2.0 — ورود: admin/admin123

---
Task ID: 6
Agent: main (Z.ai)
Task: اصلاح UI بر اساس بازخورد مالک — «هنوز کلی فاصله داره؛ رنگ‌بندی و آیکون‌ها و ساختار صفحات مثل خود CRMIdeal نیست»

Work Log:
- ریشه‌یابی از سورس واقعی محصول: _LayoutMain.cshtml (157KB) + ترتیب واقعی CSS از BundleConfig: fonts→icofont→flag→bootstrap-4-1→MainStyle→RepMainStyle→StySetting→StyPublic→کامپوننت‌ها→MainStyleNew
- کشف کلیدی در MainStyleNew.css: ریل منو (#s-m-t) سرمه‌ای #012875 تمام‌قد با گوشه گرد 10px و عرض ~79px؛ آیکون/عنوان #e7eaf2 با !important (رنگ‌بندی قدیمی هر-منو در نسخه 3.1.18 override شده)
- آیکون‌های واقعی: فونت Font Awesome 4.4 خود محصول؛ هدر و کارتابل‌ها SVG خطی inline — لوگو 75px بسته / 104px باز + شعار ravi-medium 9px
- درخت منوی واقعی از CRM.Resources.Menus.resx (878 کلید mu/mnu) + کلاس‌های s-b-mnu: ۱۸ منوی ریشه CRMIdeal با زیرمنوها
- پروتوتایپ استاتیک در سندباکست: project-analysis/crm-project/__prototype__/index.html با خود CSS/فونت/تصاویر محصول — تأیید مرورگر+VLM
- قرص کارتابل (Cartables-RowBox): خانه/جستجو/یادآور/کارنامه روزانه/وضعیت/نشانک‌ها/کارهای داخلی/حضور و غیاب/دانش‌نامه/فراموشی‌ها/تلگرام
- انتقال به رستا: کپی fontawesome-webfont از Content/fonts محصول + app-shell بازنویسی با آیکون‌های FA4 و درخت منوی کامل + جدول Kendo Bootstrap در data-table
- tsc/lint پاک؛ E2E کامل + VLM تأیید؛ رفع دو بار تداخل auto-snapshot با cherry-pick/reset

Stage Summary:
- ظاهر رستا از خود سورس CRMIdeal استخراج شد: ریل سرمه‌ای #012875 + آیکون‌های FA4 محصول + درخت منو + قرص کارتابل + جدول Kendo
- پروتوتایپ مرجع: project-analysis/crm-project/__prototype__/index.html
- develop = 63195a7f + این commit؛ main فروزن روی 1275fdaf

---
Task ID: 7
Agent: main (Z.ai)
Task: فاز ۴ — بازسازی ماژول «پروژه‌ها» و «تعریف کاربران» مطابق سورس واقعی CRMIdeal + پوش فایل filebin به main/ideal

Work Log:
- پوش بستهٔ اصلی مالک (crm web full-187.zip، ۱۷۸MB) به main در پوشه ideal — تقسیم دو‌تکه (95MB+83MB) به دلیل سقف ۱۰۰MB گیت‌هاب + README بازسازی/SHA-256 (کامیت 2f5534f5 روی main؛ ریموت main از این پس شامل مرجع فروزن محصول است)
- کنکاش عمیق دو ماژول با عامل‌های Explore از سورس دیکامپایل‌شده + ویوها:
  * پروژه‌ها: CrmProjects (۶۰+ فیلد) + CrmConversation* + عنوان/سرفصل/گروه/مقطع/اولویت/دسته‌بندی/مدل پیشرفت + نتیجه‌های وضعیت (PrjFinished/Issue*/...) + SLA تیکت + شماره‌گذاری prjNumR/ActivePrjNumRWithTitle + کارتابل یادآور — گانت/زمان‌بند/وظیفه/عضو در سورس وجود ندارد (ساخته نشد)
  * کاربران: AccountsController (10,274 خط) — درخت فرم×اکشن مجوز (CrmsysRollPermission)، ۱۲ بخش فرم کاربر، نقش با سقف تخفیف، ساعت ورود، امضا، سمت درختی، پیام داخلی/زبان/دسترسی نمودارها
- اسکیمای فاز ۴: ProjectTitleGroup/ProjectTitle/ProjectGroup/Grade/Priority/Category/CnvsStatusGroup/CnvsStatus (با نتیجه‌های وضعیت) /Project (بازسازی کامل CrmProjects: آرشیو/تیکت/SLA/ToDo/FO) /ProjectConversation + ستون‌های واقعی Users (پرسنلی/سمت/دپارتمان/مسئول/انقضا/امضا/داخلی/...) + CrmsysRolls (سقف تخفیف) + RolePermission نو (فرم×اکشن) + UserPosition(درخت)/UserGroup/UserDepartment/UserLoginAllowedTime + BankAccount.userId
- بازسازی کامل سیستم مجوز: رجیستری FORMS/ACT_LABELS با نام‌گذاری frm*/act* خود CRMIdeal (۲۴ فرم، ۹۶ اکشن شامل actDefine* تعاریف پایه روی frmMain) — requirePerm فرم×اکشن + نگاشت سازگار ماژول‌های قدیمی (MODULE_TO_FORM)
- ورود: چک‌های ترتیبی خود محصول (انقضای حساب msgErrorUsernameExpired / نقش فعال / ساعت-روز-تاریخ مجاز UserLoginAllowedTimes)
- API: پروژه‌ها (درخت+شمارنده‌ها CRMspSelectCompanyProjectsCount/درج با چک تکراری و شماره‌گذاری/پیش‌نمایش با ناوبری prev-next و SLA اولین مطالعه/مذاکره با اعمال نتیجه‌های وضعیت: NoCnvsDup، اولین پاسخ/اقدام، آرشیو خودکار PrjFinished/آرشیو/توقف تیکت/حذف سه‌گانه/یادآور) + تعاریف (۸ موجودیت با مجوز actDefine* و بلاک حذفِ در حال استفاده) + کاربران v۲ (پنل/گرید خود محصول/امضا Bytes/حساب بانکی/ساعت ورود/شمارش) + نقش‌ها v۲ (سقف تخفیف + ماتریس GET/تک‌تخصیص/همه/کپی بین نقش‌ها) + ساختار سازمانی + تغییر رمز + اعمال سقف تخفیف نقش در پیش‌فاکتور/فاکتور
- UI: پنل پروژه‌های مخاطب (تب جاری/آرشیو/تیکت‌ها با شمارنده + درخت مذاکرات + جستجو) + فرم درج/ویرایش (قالب عنوان پیش‌فرض، دو تب، آرشیو/تیکت مجوزدار) + پیش‌نمایش (وضعیت+progress+نمودار دایره‌ای/باکس شروع/پایان/SLA/توافق‌نامه سرفصل/مذاکرات/حذف سه‌گانه/آرشیو/توقف) + لیست سراسری /projects + کارتابل یادآور در tasks + تعاریف پایه (۷ تب) + بازسازی کامل users (پنل+ناوبری رکورد ۴ دکمه مجوزدار+۵ تب دیالوگ) + roles (ماتریس درختی با شمارنده/تخصیص همه/کپی) + user-org (درخت سمت‌ها) + /settings/password + منو (muProject→/projects، اطلاعات پایه‌پروژه‌ها/کاربران، لینک تغییر رمز در پروفایل)
- Seed: نقش‌ها با مجوزهای فرم×اکشن + سقف ۱۵٪ کارشناس فروش + ساختار سازمانی + ۲ سرفصل با توافق‌نامه + ۲ مدل پیشرفت (چرخه فروش/پشتیبانی) + ۶ عنوان + ۱۰ پروژه/۲۲ مذاکره (عقب‌افتاده/آرشیو/تیکت/توقف/SLA)
- E2E (مرورگر): ورود، لیست پروژه‌ها (جاری۵/آرشیو۲/تیکت۳)، پیش‌نمایش (٪۵۵/SLA/توافق‌نامه)، ثبت مذاکره با «موفق» → آرشیو خودکار پروژه (جاری ۵→۴، آرشیو ۲→۳ ✓ نتیجهٔ وضعیت مثل CRMIdeal)، درج پروژه با قالب (auto-fill سرفصل/مدل/مقطع/اولویت/پسوند/یادآوری ✓ شماره ۱۱)، صفحه مشتری تب جاری بدون تیکت، تعریف کاربران (رکورد ۱ از ۴ + پنل نقش/سمت/دپارتمان)، ماتریس مجوز (۹۶→۹۵→۹۶ toggle ✓)، تعاریف (۶ عنوان)، کارتابل یادآور (۱ عقب‌افتاده)؛ tsc=0، eslint=0
- جنگ با سازوکار snapshot: local main فست‌فوروارد به develop (فلیپ‌ها بی‌اثر شدند — ریموت main فروزن ماند) + الگوی بکاپ‌وبرگرداندن فایل‌های tracked + کشته‌شدن dev server → اجرای setsid دتاچ

Stage Summary:
- develop = c3223956 (v0.3.0) — فاز ۴ کامل: پروژه‌ها + کاربران بازسازی‌شده از سورس واقعی؛ ۶ کامیت پوش‌شده
- main = 2f5534f5 شامل ideal/ (بستهٔ ۱۷۸MB دو‌تکه + README)
- گزارش صادقانه درباره‌ی اقلام پیاده‌سازی‌نشده در پایان همین تسک به مالک تحویل شد

---
Task ID: 8
Agent: main (Z.ai)
Task: بازبینی کامل پروژه با کاتالوگ دیتابیس — عیان‌سازی ساختار DB در رستا (دستور مالک: هرچه در دیتابیس هست و نداشتیم، عیناً پیاده شود)

Work Log:
- ⚠️ «کاتالوگ دستورات SQL» مالک در سندباکس نرسید (پوشهٔ upload خالی؛ filebin فقط زیپ اصلی) → بدون جعل، همان کار از «مرجع قطعی داخل خود محصول» انجام شد: CRMTabel.ssdl (اسکیمای ذخیره‌شده در Models.dll) + پایش در هر commit برای رسیدن فایل
- بازیابی بستهٔ اصلی از خود ریپو: بازسازی zip از دو تکهٔ main/ideal (SHA-256 ✓) و استخراج مجدد ۱۰,۸۵۶ فایل سایت در سندباکس؛ جستجوی *.sql در بسته → صفر (بستهٔ publish است، بدون دیتابیس)
- ممیزی کامل: ۶۳۳ جدول اصلی (۳۸۰ پایه + ۲۵۳ ترجمه) + ۳۴۳۸ SP در ۵ اسکیمای EF → docs/analysis/02-original-db-catalog.md (کاتالوگ مستند همه جدول‌ها/ستون‌ها/کلیدها + گروه‌بندی کارکردی + نقشه پوشش) — کامیت 7f6a8c7
- کشف ساختاری مهم: نام واقعی جداول کاربران/سازمان (Users/UserPositions/UserDepartments/UserGroups/UserLoginAllowedTimes بدون پیشوند Crm)، وظایف = CrmUserTasks (نه Task)، خزانه = CrmFund/FundGroups، فرصت فروش = ندارد (قیف فروش از CrmConversationStatusSalesFunnelSteps)، ثبت فرم/اکشن در DB = CrmsysForms/CrmsysFormActions، درختچه اطلاعات پروژه = CrmProjectFieldTitle/FieldValueType/Informations
- بازسازی کامل prisma/schema.prisma در دو بخش:
  * بخش ۱ — ۲۶ مدل فعال با @@map/@map عین روی نام جدول/ستون اصلی + افزودن تک‌تک ستون‌های غایب (Users 101، CrmCompany 120، CrmCompanyPersons 80، CrmProjects 82، CrmConversation 59، CrmConversationStatus 54، ...) — صحت‌سنجی خودکار: هر ۱۰۶۳ ستون اصلی حاضر و بی‌تکرار
  * بخش ۲ — ۳۵۴ مدل تولیدشده از SSDL برای همه جدول‌های باقی‌مانده (نام فیلد=نام ستون اصلی، نوع اصلی، PK identity، @@id مرکب) — کلیدهای مرکب مثل CrmCompanyMultiGroups
  * تصمیم‌های مستند در خود اسکیما: _Lang‌ها تولید نشدند (فارسی‌اول)، FKهای رشته‌ای روی ستون اصلی برای تداوم اپ، مدل‌های اختصاصی رستا (Deal/Activity/Product/Quotation/...) با ارجاع به جدول اصلی‌شان در بخش ۲
- ابزار در ریپو: scripts/gen_rasta_schema.py (تولید) + verify_schema_vs_ssdl.py (صحت‌سنجی) + schema_head.prisma (بخش دستی)
- تاییدها: prisma validate ✓ | db push → ۳۹۶ جدول SQLite با نام‌های اصلی ✓ | seed کامل (۱۰ پروژه/۲۴ مذاکره/۱۸۲ مجوز) ✓ | tsc=0 | eslint=0
- E2E smoke روی اسکیمای جدید: ورود ✓، درخت پروژه‌ها (جاری۵/آرشیو۲/تیکت۳) ✓، تعاریف (۷ موجودیت) ✓، ثبت مذاکره موفق → آرشیو خودکار (جاری ۵→۴، آرشیو ۲→۳) مثل رفتار CRMIdeal ✓، کاربران/نقش‌ها/کارتابل ✓، همه صفحات ۲۰۰ ✓
- لاگ Prisma تأیید می‌کند همه کوئری‌ها حالا روی نام‌های اصلی اجرا می‌شوند (CrmProjects.prjTitle، Users.UserName، CrmsysRollPermission.RollId، ...)

Stage Summary:
- develop = a86a2d0 — اسکیمای رستا آینهٔ ساختاری CRMIdeal است: ۳۹۶ جدول فیزیکی با نام‌های اصلی؛ پایهٔ سیم‌کابی فازهای بعدی (پیامک/ایمیل/تلگرام/حضورغیاب/فرم‌ساز/اتصال مالی)
- تسک «پوش کاتالوگ SQL به main/ideal + README مخصوص» به‌دلیل نرسیدن فایل در سندباکس انجام‌نشده ماند — صادقانه به مالک گزارش شد؛ پس از دریافت فایل در همان جلسه انجام می‌شود

---
Task ID: 9
Agent: main (Z.ai)
Task: دریافت کاتالوگ SQL مالک (filebin جدید) — پوش به main/ideal + README مخصوص + بازبینی کل پروژه و اعمال عیناً

Work Log:
- دانلود SQL_Catalog_Word_v1.0.zip از filebin (۱۲.۸MB، SHA-256 تأیید ✓) — ۵۹٬۱۲۴ دستور SQL از CRM__Update_187.exe در ۱۱ جلد Word + CHECKSUMS همه ✓
- پوش: main/ideal/SQL_Catalog_Word_v1.0.zip + ideal/README_SQL_Catalog.md (کامیت fbe2938)
- پارسر کامل ۵۹٬۱۲۴ مدخل (scripts سندباکس) → استخراج: ۴۶۲ CREATE TABLE/۳٬۹۹۴ ستون، ۳٬۲۱۴ ALTER-ADD، ۲۷۰ DEFAULT، ۱۵۶ ایندکس، ۵۰۱ PK، ۹۴۸ FK، ۵٬۳۰۲ SP (۱٬۴۴۴ متن کامل)، ۲۱۴ تابع، ۳۵ نما، ۷ تریگر
- اعمال عیناً: ۱۲ پیش‌فرض (GUId=newid در ۱۰ جدول، Users.Mob 100/60) + ۶ ایندکس فیزیکی (IX_CrmCompanyPersons/_CmpId، IX_CrmConversation_CompanyId/ProjectId/StatusId، IX_CrmProjects_CompanyId) + ۶ ستون مهاجرتی (Company.FirstRegisterDateTime/cmpOfficialKind، Contact.FirstRegisterDateTime، CnvsStatusGroup.NoRegCnvsOlderStatue، Task.UserTaskTimeNext، UserDepartment.DefaultReferUserIdForCnvs) (کامیت 95d2b58)
- اصلاح رفتاری چک ورود از متن کامل CRMspCheckUserLoginAllowedTimes: ابعاد مستقل، ردیف=پنجرهٔ ممنوع (معنای قبلی معکوس بود)، IP، انباشت Reason — E2E ۱۲ سنجه PASS
- قابلیت جدید «عناوین پروژهٔ ممنوع» عیناً از CrmProjectsForbiddenForUser + دو SP + کوئری فرم‌ها: API/فیلتر titles?forMe=1/فیلتر لیست پروژه/گارد ۴۰۳/دیالوگ UI/rastaUserId نگاشت cuid — E2E ۱۴ سنجه PASS (کامیت c11ee25)
- گزارش فاز: docs/analysis/03-sql-catalog-application.md + کشف کاربر متصل نوع ۲۴ + صف فاز بعد (ماتریس Forbidden/JustAccess مخاطب، V5–V8 بریده) (کامیت 280dd69)

Stage Summary:
- main = fbe2938 · develop = 280dd69 · tsc=0 · eslint=0 · E2E 26/26 PASS
- تسک معوقهٔ تسک ۸ (پوش کاتالوگ) بسته شد

---
Task ID: 10
Agent: main (Z.ai)
Task: فاز صفر — ممیزی کامل و تعیین خط مبنا (دستور مادر جدید مالک)

Work Log:
- جریان Git اجباری: fetch/pull روی develop (پایه 2c39365)، درخت پاک، وضعیت آغاز ثبت شد
- فهرست‌وارسی مکانیکی نسخهٔ قدیمی از سورس دیکامپایل ریپو + بستهٔ مرجع: ۴۶ Area (کنترلر/نما به تفکیک)، ۳۱۸ کنترلر CRMIdeal، ۲۶ کنترلر API با ۴۶۳ اکشن POST (ApiBaseInfo تنها ۲۳۳)، ۸۲ کنترلر Mobile، ۱٬۴۲۷ نما، ۱۰۱ کلید منویی، ۲۲+ یکپارچه‌سازی
- ممیزی رستا: ۳۰ صفحه، ۵۹ فایل route با ۱۲۸ متد REST، ۴۲ مدل فعال بخش ۱ (۲۶ نگاشت‌یافته + ۱۶ رستا-بومی) — همه در کد استفاده می‌شوند؛ بخش ۲: ۳۵۴ مدل فقط کاتالوگ (تنها CrmProjectsForbiddenForUser سیم‌کابی شده)
- شکاف منو: پس از یکسان‌سازی پیشوندها، ۶۰ کلید قدیمی بدون معادل (اتصال حسابداری، ارسال به مودیان، تماس‌ها، پرونده‌ها، مراکز، سازمان‌ها، مشخصات فنی کالا…) — همه در feature-matrix §۳
- شکاف داده: ۲۷/۳۸۰ جدول اصلی سیم‌کابی (۷٫۱٪)؛ ۸۴ FK خروجی فعال، ۴۲۹ FK ورودی (Users با ۳۹۳!)؛ ۲۴۸ DEFAULT باقی؛ ۵٬۳۰۲ SP که فقط ۲ رفتار VERIFIED دارد؛ کوپلینگ SP↔جدول محاسبه شد (Users ۲۳۱، CrmCompany ۲۲۳…)
- اجرای واقعی صحت‌سنجی: tsc=0 ✓ | eslint=0 ✓ | prisma validate ✓ | build موفق ۵۶/۵۶ صفحه + standalone ✓ | E2E ۱۲/۱۲ + ۱۴/۱۴ PASS (26/26 بازتولید شد)
- یافتهٔ صداقت: ادعاهای worklog گذشته همه بازتولید شدند؛ ولی تست‌های فازهای ۱–۳ اسکریپت ماندگار ندارند (فقط curl دستی آن زمان) → در ماتریس ⚠️ ثبت شد؛ هیچ فریم‌ورک تست واحد/E2E پایدار وجود ندارد
- ممیزی امنیتی تک‌به‌تک ۵۹ route: ۵۵ گارد requirePerm/requirePermission/requireUser + ۴ مسیر auth (login عمومی، سه‌تای دیگر نشست داخلی با ۴۰۱) — ادعای «همه محافظت‌شده» تأیید شد
- چهار سند اجباری + roadmap: docs/parity/{legacy-module-inventory, feature-matrix, data-model-gaps, ui-comparison-plan}.md + بازچینش وابستگی‌محور فازها ۵–۱۳ در roadmap (زیرساخت تست+تعاریف پایه → ارتباطات → FormBase/DyForms → گزارش → HR → مالی/مودیان → ماژول‌های مستقل → موبایل → سخت‌سازی)
- رفع دو خطای نگارشی در خود اسناد حین بازبینی (نویسهٔ چینی اشتباه در roadmap؛ شمارش دقیق متدها و جداول ارتباطات)

Stage Summary:
- چهار سند فاز صفر کامل شد — همهٔ اعداد شمارش مکانیکی با روش ثبت‌شده، بدون تخمین
- خط مبنا: هسته‌های فروش/انبار/مالی/پروژه/کاربر IMPLEMENTED ولی هیچ Area به VERIFIED کامل نمی‌رسد (فقط ۲ رفتار SP با E2E)؛ ۳۱ Area هنوز NOT_ANALYZED
- مسدودهای فعال به مالک: متن ۳٬۱۱۰ SP بریده (CRM_SQL_Runner)؛ اسکرین‌شات محصول اصلی برای مقایسهٔ UI
- فاز پیشنهادی بعد (۵): زیرساخت تست vitest/playwright + بازسازی ApiBaseInfo (۲۳۳ اکشن تعاریف پایه)
