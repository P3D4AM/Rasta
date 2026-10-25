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
