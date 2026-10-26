# ═══════════════════════════════════════════════════════════════════════════
#  رستا (Rasta) CRM — نسخهٔ توسعه‌ای ویندوز — اسکریپت اجرا
#  Start-Rasta.ps1
#
#  اجرای برنامه روی ویندوز ۱۰/۱۱ با PowerShell 5.1 یا جدیدتر.
#  این اسکریپت:
#    ۱) پیش‌نیازها را بررسی می‌کند (node.exe همراه بسته، فایل‌های برنامه، دیتابیس اولیه)
#    ۲) در اولین اجرا فایل پیکربندی .env می‌سازد (رمز امضای تصادفی + مسیر دیتابیس)
#    ۳) در اولین اجرا دیتابیس آزمایشی را از نسخهٔ پاکِ seed کپی می‌کند (بدون دستکاری دادهٔ موجود)
#    ۴) اگر پورت پیش‌فرض اشغال باشد به‌صورت امن پورت بعدی آزاد را برمی‌گزیند
#    ۵) سرور را فقط روی 127.0.0.1 اجرا می‌کند، منتظر آماده‌شدن می‌ماند و مرورگر را باز می‌کند
#
#  پارامترها:
#    -Port 3001        اجرا روی پورت مشخص
#    -NoBrowser        مرورگر خودکار باز نشود
#    -ResetDb          بازنشانی دیتابیس به دادهٔ اولیه (ابتدا تأیید می‌گیرد؛ از نسخهٔ پاک seed؛ پشتیبان از قبلی)
# ═══════════════════════════════════════════════════════════════════════════

[CmdletBinding()]
param(
    [int]$Port = 0,
    [switch]$NoBrowser,
    [switch]$ResetDb
)

$ErrorActionPreference = 'Stop'

# نمایش درست متن فارسی در کنسول
try { [Console]::OutputEncoding = [System.Text.Encoding]::UTF8 } catch { }

# ─── مسیرها (همه نسبی به محل این اسکریپت — هیچ وابستگی به مسیر مطلق نیست) ───
$Root    = $PSScriptRoot
$NodeExe = Join-Path $Root 'runtime\node.exe'
$AppDir  = Join-Path $Root 'app'
$ServerJs = Join-Path $AppDir 'server.js'
$DataDir = Join-Path $Root 'data'
$LogDir  = Join-Path $Root 'logs'
$SeedDb  = Join-Path $Root 'seed\rasta-seed.db'
$EnvFile = Join-Path $Root '.env'
$DbFile  = Join-Path $DataDir 'rasta.db'
$PidFile = Join-Path $LogDir 'rasta.pid'
$PortFile = Join-Path $LogDir 'rasta.port'

function Write-Title($text) {
    Write-Host ""
    Write-Host ("=" * 62) -ForegroundColor DarkCyan
    Write-Host "  $text" -ForegroundColor Cyan
    Write-Host ("=" * 62) -ForegroundColor DarkCyan
}

function Write-Fail($msg) {
    Write-Host ""
    Write-Host "  خطا: $msg" -ForegroundColor Red
    Write-Host "  راهنمای خطاهای رایج: TROUBLESHOOTING-FA.md" -ForegroundColor Yellow
    Write-Host ""
    exit 1
}

function Write-Info($msg) { Write-Host "  $msg" -ForegroundColor Gray }
function Write-Ok($msg)   { Write-Host "  [OK] $msg" -ForegroundColor Green }

Write-Title "رستا — نسخهٔ توسعه‌ای (Rasta Dev Release)"

# ─── ۱) بررسی پیش‌نیازها ───
if (-not (Test-Path -LiteralPath $NodeExe)) {
    Write-Fail "فایل runtime\node.exe پیدا نشد. بسته ناقص است — فایل ZIP را دوباره کامل استخراج کنید."
}
if (-not (Test-Path -LiteralPath $ServerJs)) {
    Write-Fail "فایل app\server.js پیدا نشد. بسته ناقص است — فایل ZIP را دوباره کامل استخراج کنید."
}
if (-not (Test-Path -LiteralPath $SeedDb)) {
    Write-Fail "فایل seed\rasta-seed.db (دیتابیس اولیه) پیدا نشد. بسته ناقص است."
}
Write-Ok "پیش‌نیازها: فایل‌های بسته کامل است."

# ساخت پوشه‌های data و logs
try {
    New-Item -ItemType Directory -Force -Path $DataDir | Out-Null
    New-Item -ItemType Directory -Force -Path $LogDir  | Out-Null
} catch {
    Write-Fail "ساخت پوشه‌های data/logs ممکن نشد: $($_.Exception.Message)"
}

# ─── ۲) ساخت .env در اولین اجرا (پیکربندی محلی، جدا از کد برنامه) ───
if (-not (Test-Path -LiteralPath $EnvFile)) {
    Write-Info "اولین اجرا: ساخت فایل پیکربندی محلی (.env) با رمز امضای تصادفی..."

    # رمز امضای تصادفی ۳۲ بایتی (هگز) — سازگار با PowerShell 5.1
    $rng = [System.Security.Cryptography.RandomNumberGenerator]::Create()
    try {
        $bytes = New-Object 'byte[]' 32
        $rng.GetBytes($bytes)
    } finally { $rng.Dispose() }
    $secret = ($bytes | ForEach-Object { $_.ToString('x2') }) -join ''

    # مسیر دیتابیس به‌صورت مطلق با اسلش معمولی (Prisma فاصله را می‌پذیرد؛ %20 نه)
    $dbPathForUrl = $DbFile -replace '\\', '/'

    $envContent = @"
# ─── پیکربندی محلی رستا (نسخهٔ توسعه‌ای) ───
# این فایل در اولین اجرا به‌صورت خودکار ساخته شد. مقادیر را می‌توانید تغییر دهید.

# پورت اجرای برنامه (اگر اشغال باشد، اسکریپت اجرا خودش پورت آزاد بعدی را برمی‌گزیند)
PORT=3000

# فقط روی رابط محلی گوش می‌دهد (دسترسی از شبکهٔ بیرونی بسته است)
HOSTNAME=127.0.0.1

# دیتابیس آزمایشی مستقل این بسته (SQLite) — با دادهٔ نمونه
DATABASE_URL=file:$dbPathForUrl

# راز امضای توکن ورود — به‌صورت تصادفی تولید شد؛ آن را با هیچ‌کس به اشتراک نگذارید
AUTH_SECRET=$secret
"@
    Set-Content -LiteralPath $EnvFile -Value $envContent -Encoding UTF8
    Write-Ok "فایل .env ساخته شد."
}

# ─── ۳) خواندن پیکربندی ───
$cfg = @{}
Get-Content -LiteralPath $EnvFile -Encoding UTF8 | ForEach-Object {
    $line = $_.Trim()
    if ($line -and -not $line.StartsWith('#')) {
        $eq = $line.IndexOf('=')
        if ($eq -gt 0) {
            $cfg[$line.Substring(0, $eq).Trim()] = $line.Substring($eq + 1).Trim()
        }
    }
}

$usePort = $Port
if ($usePort -le 0) {
    if ($cfg.ContainsKey('PORT') -and $cfg['PORT']) { $usePort = [int]$cfg['PORT'] } else { $usePort = 3000 }
}
$dbUrl = $cfg['DATABASE_URL']
if (-not $dbUrl) { Write-Fail "در فایل .env مقدار DATABASE_URL تعیین نشده است." }
$authSecret = $cfg['AUTH_SECRET']
if (-not $authSecret) { Write-Fail "در فایل .env مقدار AUTH_SECRET تعیین نشده است." }

# ─── ۴) دیتابیس: در اولین اجرا از نسخهٔ پاک seed کپی می‌شود (غیرمخرب) ───
if ($ResetDb -and (Test-Path -LiteralPath $DbFile)) {
    $answer = Read-Host "  همهٔ داده‌های آزمایشی فعلی با نسخهٔ اولیه جایگزین شود؟ نسخهٔ فعلی به‌صورت پشتیبان نگه داشته می‌شود (y/N)"
    if ($answer -eq 'y' -or $answer -eq 'Y' -or $answer -eq 'yes') {
        $stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
        $backup = Join-Path $DataDir ("rasta-backup-{0}.db" -f $stamp)
        Move-Item -LiteralPath $DbFile -Destination $backup -Force
        Write-Info "پشتیبان دادهٔ قبلی: $backup"
    } else {
        Write-Info "بازنشانی لغو شد — با همین دادهٔ فعلی ادامه می‌دهیم."
    }
}

if (-not (Test-Path -LiteralPath $DbFile)) {
    Copy-Item -LiteralPath $SeedDb -Destination $DbFile
    Write-Ok "دیتابیس آزمایشی از نسخهٔ اولیه ساخته شد: data\rasta.db"
} else {
    Write-Ok "دیتابیس موجود است (data\rasta.db) — دست نمی‌خورد."
}

# ─── ۵) بررسی اینکه رستا از قبل در حال اجرا نیست ───
if (Test-Path -LiteralPath $PidFile) {
    $oldPid = 0
    try { $oldPid = [int](Get-Content -LiteralPath $PidFile -ErrorAction Stop | Select-Object -First 1) } catch { }
    if ($oldPid -gt 0) {
        $oldProc = Get-Process -Id $oldPid -ErrorAction SilentlyContinue
        if ($oldProc -and -not $oldProc.HasExited) {
            Write-Host ""
            Write-Host "  رستا از قبل در حال اجراست (شناسهٔ فرآیند $oldPid)." -ForegroundColor Yellow
            Write-Host "  برای توقف: Stop-Rasta.ps1  |  برای اجرای نمونهٔ دوم: Start-Rasta.ps1 -Port $usePort" -ForegroundColor Yellow
            Write-Host ""
            exit 0
        }
    }
}

# ─── ۶) انتخاب پورت آزاد (اگر پیش‌فرض اشغال بود، امن به بعدی می‌رود) ───
# با TcpClient probing — بدون نیاز به cmdlet مخصوص ویندوز و بدون نیاز به دسترسی مدیر
function Test-PortBusy([int]$p) {
    $client = New-Object System.Net.Sockets.TcpClient
    try {
        $iar = $client.BeginConnect('127.0.0.1', $p, $null, $null)
        $connected = $iar.AsyncWaitHandle.WaitOne(400)
        if ($connected -and $client.Connected) { return $true }
        return $false
    } catch { return $false } finally {
        try { $client.Close() } catch { }
    }
}

$finalPort = $usePort
$maxPort = $usePort + 10
if (Test-PortBusy $finalPort) {
    Write-Info "پورت $usePort اشغال است — جست‌وجوی پورت آزاد..."
    $found = $false
    for ($p = $usePort + 1; $p -le $maxPort; $p++) {
        if (-not (Test-PortBusy $p)) { $finalPort = $p; $found = $true; break }
    }
    if (-not $found) {
        Write-Fail "پورت‌های $usePort تا $maxPort همگی اشغال‌اند. با Start-Rasta.ps1 -Port <عدد آزاد> اجرا کنید یا برنامهٔ اشغال‌کننده را ببندید."
    }
    Write-Host "  پورت جایگزین انتخاب شد: $finalPort (پورت $usePort اشغال بود)" -ForegroundColor Yellow
}

# ─── ۷) اجرای سرور (فقط loopback) ───
$stamp2 = Get-Date -Format 'yyyyMMdd-HHmmss'
$logOut = Join-Path $LogDir ("rasta-{0}.out.log" -f $stamp2)
$logErr = Join-Path $LogDir ("rasta-{0}.err.log" -f $stamp2)

# متغیرهای محیطی به فرآیند node به ارث می‌رسند (سازگار با PowerShell 5.1)
$env:PORT         = "$finalPort"
$env:HOSTNAME     = '127.0.0.1'
$env:DATABASE_URL = $dbUrl
$env:AUTH_SECRET  = $authSecret
$env:NODE_ENV     = 'production'

Write-Info "در حال اجرای سرور... (پورت $finalPort)"
try {
    $startArgs = @{
        FilePath                  = $NodeExe
        ArgumentList              = ('"{0}"' -f $ServerJs)
        WorkingDirectory          = $AppDir
        RedirectStandardOutput    = $logOut
        RedirectStandardError     = $logErr
        PassThru                  = $true
    }
    # WindowStyle فقط در ویندوز معنا دارد (PowerShell 5.1 = Win32NT)
    if ($PSVersionTable.Platform -eq 'Win32NT') { $startArgs.WindowStyle = 'Hidden' }
    $proc = Start-Process @startArgs
} catch {
    Write-Fail "اجرای node.exe ممکن نشد: $($_.Exception.Message)"
}

if ($null -eq $proc) { Write-Fail "فرآیند سرور ساخته نشد." }
Set-Content -LiteralPath $PidFile -Value $proc.Id -Encoding ASCII
# پورت واقعی استفاده‌شده (ممکن است به‌خاطر اشغال بودن پورت پیش‌فرض جابه‌جا شده باشد)
Set-Content -LiteralPath $PortFile -Value $finalPort -Encoding ASCII

# ─── ۸) انتظار برای آماده‌شدن سرویس (حداکثر ۹۰ ثانیه) ───
Write-Info "منتظر آماده‌شدن برنامه..."
$ready = $false
$deadline = (Get-Date).AddSeconds(90)
while ((Get-Date) -lt $deadline) {
    if ($proc.HasExited) {
        $tail = ''
        if (Test-Path -LiteralPath $logErr) {
            $tail = (Get-Content -LiteralPath $logErr -Tail 12 -ErrorAction SilentlyContinue) -join "`n"
        }
        Write-Fail "سرور هنگام راه‌اندازی متوقف شد. انتهای پیام خطا:`n$tail"
    }
    Start-Sleep -Milliseconds 800
    try {
        $resp = Invoke-WebRequest -Uri ("http://127.0.0.1:{0}/login" -f $finalPort) -UseBasicParsing -TimeoutSec 3
        if ($resp.StatusCode -eq 200) { $ready = $true; break }
    } catch { }
}

if (-not $ready) {
    if (-not $proc.HasExited) { Stop-Process -Id $proc.Id -Force -ErrorAction SilentlyContinue }
    Remove-Item -LiteralPath $PidFile -ErrorAction SilentlyContinue
    Write-Fail "برنامه در ۹۰ ثانیه آماده نشد. لاگ خطا: $logErr — راهنما: TROUBLESHOOTING-FA.md"
}

# ─── ۹) بازکردن مرورگر و نمایش خلاصه ───
$url = "http://127.0.0.1:{0}" -f $finalPort
if (-not $NoBrowser) {
    try { Start-Process $url } catch { Write-Info "مرورگر باز نشد — آدرس را دستی باز کنید: $url" }
}

Write-Title "رستا آماده است"
Write-Host ""
Write-Host ("  آدرس برنامه       : {0}" -f $url) -ForegroundColor White
Write-Host ""
Write-Host "  حساب مدیر سیستم   : نام کاربری  admin   رمز  admin123" -ForegroundColor White
Write-Host "  (حساب‌های دیگر: manager/manager123 · sales1/sales123 · sales2/sales123)" -ForegroundColor Gray
Write-Host ""
Write-Host ("  لاگ اجرا          : {0}" -f $logOut) -ForegroundColor Gray
Write-Host ("  لاگ خطا           : {0}" -f $logErr) -ForegroundColor Gray
Write-Host ("  دیتابیس آزمایشی   : {0}" -f $DbFile) -ForegroundColor Gray
Write-Host ""
Write-Host "  توقف برنامه       : Stop-Rasta.ps1" -ForegroundColor Yellow
Write-Host "  (بستن پنجرهٔ اسکریپت برنامه را متوقف نمی‌کند — سرور در پس‌زمینه می‌ماند؛" -ForegroundColor Gray
Write-Host "   برای توقف حتماً Stop-Rasta.ps1 را اجرا کنید.)" -ForegroundColor Gray
Write-Host ""
Write-Host "  وضعیت قابلیت‌ها   : FEATURE-STATUS.md  (فهرست کامل و صادقانه)" -ForegroundColor Gray
Write-Host ""
