#!/usr/bin/env node
/**
 * release/build-release.mjs — ساخت بستهٔ توسعه‌ای ویندوز رستا (Rasta Dev Release)
 * ═══════════════════════════════════════════════════════════════════════════
 * ورودی‌ها:
 *   - خروجی standalone برنامه (`.next/standalone`) — باید قبلاً `npm run build` زده شده باشد
 *   - node.exe ویندوزی (از کش release/.cache یا دانلود خودکار از nodejs.org)
 *
 * خروجی‌ها:
 *   - release/Rasta-Dev-Windows/          ← بستهٔ کامل قابل اجرا (اسکریپت‌ها و راهنماها از قبل داخلش هستند)
 *   - release/Rasta-Dev-Windows-v<ver>-win-x64.zip + .sha256
 *
 * طراحی (مستند):
 *   • استراتژی اجرا: Next.js standalone — استاندارد خود Next برای استقرار؛ سرور node.js سبک
 *     بدون نیاز به node_modules کامل پروژه. node.exe به‌همراه بسته می‌آید تا کاربر ویندوزی
 *     هیچ ابزار توسعه‌ای نصب نکند.
 *   • دیتابیس: SQLite مستقل داخل بسته (data/rasta.db) که در اولین اجرا از نسخهٔ پاک
 *     seed/rasta-seed.db کپی می‌شود — بدون نیاز به prisma CLI روی سیستم کاربر.
 *     نسخهٔ seed با `prisma db push` (بدون accept-data-loss) + `prisma/seed.ts` ساخته می‌شود.
 *   • پاک‌سازی برای ویندوز (حجم ~۱۱۰MB کم می‌شود):
 *       - node_modules/@img + sharp → فقط برای بهینه‌سازی next/image است که در رستا استفاده نشده
 *       - node_modules/typescript → ابزار build، در اجرای production نقشی ندارد
 *       - libquery_engine-linux*.so.node → موتور لینوکسی (موتور ویندوزی query_engine-windows.dll.node می‌ماند)
 *       - @prisma/client/runtime/*wasm-base64* → فقط برای runtime edge/wasm؛ رستا روی Node استاندارد اجرا می‌شود
 *
 * اجرا (از ریشهٔ مخزن):
 *   npm run build && node release/build-release.mjs
 */
import { execSync, spawnSync } from 'node:child_process'
import { createHash } from 'node:crypto'
import fs from 'node:fs'
import path from 'node:path'
import os from 'node:os'

const ROOT = path.resolve(path.dirname(new URL(import.meta.url).pathname), '..')
const PKG = path.join(ROOT, 'release', 'Rasta-Dev-Windows')
const CACHE = path.join(ROOT, 'release', '.cache')
const STANDALONE = path.join(ROOT, '.next', 'standalone')

const NODE_VERSION = '24.22.1' // LTS فعلی — همان خط اصلی که در محیط توسعه تست شده
const NODE_ZIP_NAME = `node-v${NODE_VERSION}-win-x64.zip`
const NODE_URL = `https://nodejs.org/dist/v${NODE_VERSION}/${NODE_ZIP_NAME}`

const fail = (msg) => { console.error(`\n✗ ${msg}\n`); process.exit(1) }
const ok = (msg) => console.log(`✓ ${msg}`)
const info = (msg) => console.log(`  ${msg}`)

// ─── ۰) پیش‌شرط‌ها ───
if (!fs.existsSync(path.join(STANDALONE, 'server.js'))) {
  fail('خروجی standalone پیدا نشد. اول `npm run build` را اجرا کنید.')
}
const pkgJson = JSON.parse(fs.readFileSync(path.join(ROOT, 'package.json'), 'utf8'))
const REL_VERSION = `${pkgJson.version}-dev.1`

let baseSha = ''
try {
  baseSha = execSync('git rev-parse HEAD', { cwd: ROOT }).toString().trim()
  if (execSync('git rev-parse --abbrev-ref HEAD', { cwd: ROOT }).toString().trim() !== 'develop') {
    info('توجه: شاخهٔ فعلی develop نیست — بسته از همین شاخه ساخته می‌شود.')
  }
} catch { baseSha = 'unknown' }

// ─── ۱) node.exe ویندوزی ───
fs.mkdirSync(CACHE, { recursive: true })
const nodeZipPath = path.join(CACHE, NODE_ZIP_NAME)
if (!fs.existsSync(nodeZipPath)) {
  info(`دانلود ${NODE_URL} ...`)
  const res = await fetch(NODE_URL)
  if (!res.ok) fail(`دانلود Node.js ناموفق: HTTP ${res.status}`)
  fs.writeFileSync(nodeZipPath, Buffer.from(await res.arrayBuffer()))
  ok(`Node.js دانلود شد (${(fs.statSync(nodeZipPath).size / 1e6).toFixed(1)}MB)`)
} else {
  ok(`Node.js از کش: ${NODE_ZIP_NAME}`)
}
const nodeExeExtract = path.join(CACHE, `node-v${NODE_VERSION}-win-x64`)
if (!fs.existsSync(path.join(nodeExeExtract, 'node.exe'))) {
  execSync(`unzip -qo "${nodeZipPath}" -d "${CACHE}"`)
}
if (!fs.existsSync(path.join(nodeExeExtract, 'node.exe'))) fail('استخراج node.exe ناموفق بود.')

// ─── ۲) ساخت پوشهٔ بسته ───
for (const sub of ['app', 'runtime', 'data', 'seed', 'logs']) {
  fs.rmSync(path.join(PKG, sub), { recursive: true, force: true })
  fs.mkdirSync(path.join(PKG, sub), { recursive: true })
}

// ─── ۳) کپی standalone → app ───
info('کپی خروجی standalone...')
execSync(`cp -r "${STANDALONE}/." "${path.join(PKG, 'app')}/"`)
// static و public را اسکریپت npm run build داخل standalone کپی کرده؛ اگر نشده بود اینجا اطمینان می‌گیریم
const staticSrc = path.join(ROOT, '.next', 'static')
if (!fs.existsSync(path.join(PKG, 'app', '.next', 'static'))) {
  execSync(`cp -r "${staticSrc}" "${path.join(PKG, 'app', '.next')}/"`)
}
if (!fs.existsSync(path.join(PKG, 'app', 'public'))) {
  execSync(`cp -r "${path.join(ROOT, 'public')}" "${path.join(PKG, 'app')}/"`)
}
ok('کپی انجام شد')

// ─── ۴) پاک‌سازی مخصوص ویندوز ───
const rm = (p) => { const f = path.join(PKG, 'app', p); fs.rmSync(f, { recursive: true, force: true }) }
info('پاک‌سازی فایل‌های غیرلازم برای اجرای ویندوزی...')
rm('node_modules/@img')
rm('node_modules/sharp')
rm('node_modules/typescript')
// موتور لینوکسی (ویندوزی می‌ماند)
for (const f of fs.readdirSync(path.join(PKG, 'app', 'node_modules', '.prisma', 'client'))) {
  if (f.startsWith('libquery_engine-') && f.endsWith('.so.node')) {
    rm(`node_modules/.prisma/client/${f}`)
    info(`  حذف ${f}`)
  }
}
// موتورهای wasm-base64 فقط برای runtime edge/wasm
let wasmSaved = 0
for (const f of fs.readdirSync(path.join(PKG, 'app', 'node_modules', '@prisma', 'client', 'runtime'))) {
  if (f.includes('wasm-base64')) {
    fs.rmSync(path.join(PKG, 'app', 'node_modules', '@prisma', 'client', 'runtime', f))
    wasmSaved++
  }
}
info(`  حذف ${wasmSaved} فایل wasm-base64 از runtime پرایسما`)
if (!fs.existsSync(path.join(PKG, 'app', 'node_modules', '.prisma', 'client', 'query_engine-windows.dll.node'))) {
  fail('موتور کوئری ویندوزی در کلاینت پرایسما نیست! `npx prisma generate` باید با binaryTargets=["native","windows"] اجرا شده باشد (در schema.prisma تنظیم شده).')
}
ok('موتور کوئری ویندوزی حاضر است: query_engine-windows.dll.node')

// ─── ۵) node.exe ───
fs.copyFileSync(path.join(nodeExeExtract, 'node.exe'), path.join(PKG, 'runtime', 'node.exe'))
ok(`runtime/node.exe (${(fs.statSync(path.join(PKG, 'runtime', 'node.exe')).size / 1e6).toFixed(0)}MB)`)

// ─── ۶) دیتابیس اولیه (seed) — با روش خود پروژه: prisma db push + seed ───
info('ساخت دیتابیس اولیه با prisma db push (بدون accept-data-loss) + seed...')
const seedDb = path.join(PKG, 'seed', 'rasta-seed.db')
fs.rmSync(seedDb, { force: true })
const envPush = { ...process.env, DATABASE_URL: `file:${seedDb}` }
const run = (cmd) => spawnSync(cmd, { cwd: ROOT, env: envPush, shell: true, stdio: 'pipe', encoding: 'utf8' })
let r = run('npx prisma db push')
if (r.status !== 0) fail('prisma db push ناموفق:\n' + (r.stderr || r.stdout || '').slice(-800))
r = run('bun prisma/seed.ts')
if (r.status !== 0) fail('seed ناموفق:\n' + (r.stderr || r.stdout || '').slice(-800))
ok(`seed/rasta-seed.db (${(fs.statSync(seedDb).size / 1e6).toFixed(1)}MB)`)

// ─── ۷) VERSION.txt ───
const buildDate = new Date().toISOString().replace('T', ' ').slice(0, 16) + ' UTC'
fs.writeFileSync(path.join(PKG, 'VERSION.txt'), `Rasta CRM — Dev Release (Windows)
نسخه / Version: v${REL_VERSION}
تاریخ ساخت / Build date: ${buildDate}
کامیت مبنا / Base commit: ${baseSha} (develop — github.com/P3D4AM/Rasta)
اجرای برنامه / Runtime: Node.js v${NODE_VERSION} win-x64 (همراه بسته — نصب جداگانه لازم نیست)
دیتابیس / Database: SQLite مستقل داخل بسته (data/rasta.db — دادهٔ نمونه)
وضعیت تست ویندوز / Windows verification: NOT VERIFIED ON WINDOWS
  (بسته در لینوکس ساخته و به‌صورت معادل تست شده است؛ اجرای واقعی روی ویندوز بر عهدهٔ دریافت‌کننده)

حساب‌های آزمایشی / Demo accounts: admin/admin123 · manager/manager123 · sales1/sales123 · sales2/sales123
`)

// ─── ۸) ZIP + SHA-256 ───
// پیش از ZIP: هیچ اثر اجرای محلی (env/دیتابیس/لاگ) نباید وارد بسته شود
// توجه: next build فایل .env مخزن را داخل standalone کپی می‌کند (رفتار استاندارد Next)
// شامل DATABASE_URL مطلقِ محیط ساخت — باید حذف شود تا در ویندوز تلهٔ پیکربندی نشود.
fs.rmSync(path.join(PKG, '.env'), { force: true })
for (const f of fs.readdirSync(path.join(PKG, 'app'))) {
  if (f.startsWith('.env')) fs.rmSync(path.join(PKG, 'app', f), { force: true })
}
for (const dir of ['data', 'logs']) {
  const d = path.join(PKG, dir)
  fs.mkdirSync(d, { recursive: true })
  for (const f of fs.readdirSync(d)) fs.rmSync(path.join(d, f), { force: true })
}
info('ساخت فایل ZIP...')
const zipName = `Rasta-Dev-Windows-v${REL_VERSION}-win-x64.zip`
const zipPath = path.join(ROOT, 'release', zipName)
fs.rmSync(zipPath, { force: true })
execSync(`cd "${path.join(ROOT, 'release')}" && zip -qr9 "${zipName}" "Rasta-Dev-Windows"`, { stdio: 'pipe' })
const sha = createHash('sha256').update(fs.readFileSync(zipPath)).digest('hex')
fs.writeFileSync(`${zipPath}.sha256`, `${sha}  ${zipName}\n`)
ok(`${zipName} (${(fs.statSync(zipPath).size / 1e6).toFixed(1)}MB)`)
ok(`SHA-256: ${sha}`)

// ─── ۹) خلاصه ───
const du = execSync(`du -sh "${PKG}"`).toString().trim().split('\t')[0]
console.log(`
════════════════════════════════════════════════════
  بستهٔ توسعه‌ای رستا ساخته شد
  پوشهٔ بسته : release/Rasta-Dev-Windows  (${du})
  فایل ZIP   : release/${zipName}
  SHA-256    : ${sha}
  نسخه       : v${REL_VERSION} (کامیت ${baseSha.slice(0, 8)})
════════════════════════════════════════════════════
`)
