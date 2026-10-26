# ═══════════════════════════════════════════════════════════════════════════
#  رستا (Rasta) CRM — نسخهٔ توسعه‌ای ویندوز — اسکریپت توقف
#  Stop-Rasta.ps1
#
#  برنامه را به‌صورت تمیز متوقف می‌کند:
#    ۱) شناسهٔ فرآیند را از logs\rasta.pid می‌خواند و همان فرآیند را می‌بندد
#    ۲) اگر فایل pid نبود، فرآیندِ گوش‌دادن به پورت را پیدا و می‌بندد
#    ۳) آزاد شدن پورت را تأیید می‌کند
#
#  پارامترها:
#    -Port 3000    اگر pid پیدا نشد، توقف بر اساس این پورت
# ═══════════════════════════════════════════════════════════════════════════

[CmdletBinding()]
param(
    [int]$Port = 0
)

$ErrorActionPreference = 'Stop'
try { [Console]::OutputEncoding = [System.Text.Encoding]::UTF8 } catch { }

$Root    = $PSScriptRoot
$PidFile = Join-Path $Root 'logs\rasta.pid'
$PortFile = Join-Path $Root 'logs\rasta.port'
$EnvFile = Join-Path $Root '.env'

function Write-Fail($msg) {
    Write-Host "  خطا: $msg" -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "  توقف رستا..." -ForegroundColor Cyan

# پورت: اول پورت واقعی اجرا (rasta.port — ممکن است به‌خاطر اشغالی جابه‌جا شده باشد)، بعد .env
if ($Port -le 0 -and (Test-Path -LiteralPath $PortFile)) {
    $t = 0
    $pf = (Get-Content -LiteralPath $PortFile -ErrorAction SilentlyContinue | Select-Object -First 1)
    if ([int]::TryParse("$pf".Trim(), [ref]$t) -and $t -gt 0) { $Port = $t }
}
if ($Port -le 0 -and (Test-Path -LiteralPath $EnvFile)) {
    Get-Content -LiteralPath $EnvFile -Encoding UTF8 | ForEach-Object {
        $line = $_.Trim()
        if ($line.StartsWith('PORT=')) { $t = 0; if ([int]::TryParse($line.Substring(5).Trim(), [ref]$t)) { $Port = $t } }
    }
}
if ($Port -le 0) { $Port = 3000 }

# بررسی اشغال بودن پورت — با TcpClient (بدون cmdlet مخصوص ویندوز)
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

$stopped = $false

# ─── روش ۱: فایل pid ───
if (Test-Path -LiteralPath $PidFile) {
    $targetPid = 0
    try { $targetPid = [int](Get-Content -LiteralPath $PidFile -ErrorAction Stop | Select-Object -First 1) } catch { }
    if ($targetPid -gt 0) {
        $p = Get-Process -Id $targetPid -ErrorAction SilentlyContinue
        if ($p -and -not $p.HasExited) {
            # نام فرآیند روی ویندوز «node» است؛ روی لینوکس Next.js عنوانش را «next-server» می‌کند
            if ($p.ProcessName -match 'node|next-server') {
                Stop-Process -Id $targetPid -Force
                # چند لحظه صبر برای آزاد شدن پورت
                $deadline = (Get-Date).AddSeconds(10)
                while ((Get-Date) -lt $deadline) {
                    $alive = Get-Process -Id $targetPid -ErrorAction SilentlyContinue
                    if (-not $alive) { break }
                    Start-Sleep -Milliseconds 300
                }
                Write-Host "  فرآیند node (شناسهٔ $targetPid) متوقف شد." -ForegroundColor Green
                $stopped = $true
            } else {
                Write-Host "  فرآیند $targetPid نام «$($p.ProcessName)» دارد و node نیست — برای امنیت نمی‌بندم." -ForegroundColor Yellow
                Write-Host "  اگر مطمئنید همین برنامه است: Stop-Process -Id $targetPid -Force" -ForegroundColor Gray
            }
        } else {
            Write-Host "  فرآیند قبلی از قبل بسته بود." -ForegroundColor Gray
            $stopped = $true
        }
    }
    Remove-Item -LiteralPath $PidFile -ErrorAction SilentlyContinue
    Remove-Item -LiteralPath $PortFile -ErrorAction SilentlyContinue
}

# ─── روش ۲: جست‌وجو بر اساس پورت (فقط ویندوز — netstat/cmdlet مخصوص) ───
if (-not $stopped) {
    $foundByPort = $false
    try {
        $conns = Get-NetTCPConnection -LocalPort $Port -State Listen -ErrorAction SilentlyContinue
        if ($conns -and $conns.Count -gt 0) {
            $pids = $conns | Select-Object -ExpandProperty OwningProcess -Unique
            foreach ($tp in $pids) {
                if ($tp -and $tp -gt 0) {
                    $p = Get-Process -Id $tp -ErrorAction SilentlyContinue
                    if ($p -and $p.ProcessName -match 'node|next-server') {
                        Stop-Process -Id $tp -Force
                        Write-Host "  فرآیند node روی پورت $Port (شناسهٔ $tp) متوقف شد." -ForegroundColor Green
                        $foundByPort = $true
                    } elseif ($p) {
                        Write-Host "  روی پورت $Port فرآیند غیر node در حال گوش‌دادن است ($($p.ProcessName)) — دست نمی‌زنم." -ForegroundColor Yellow
                    }
                }
            }
        }
    } catch { }
    if (-not $foundByPort -and -not (Test-PortBusy $Port)) {
        Write-Host "  هیچ فرآیند node ای روی پورت $Port در حال گوش‌دادن نیست — برنامه از قبل متوقف است." -ForegroundColor Green
        $stopped = $true
    } elseif ($foundByPort) {
        $stopped = $true
    }
}

# ─── تأیید نهایی ───
Start-Sleep -Milliseconds 500
if (Test-PortBusy $Port) {
    Write-Fail "پورت $Port هنوز اشغال است. برنامهٔ نگه‌دارنده را در Task Manager ببندید."
}

Write-Host ""
Write-Host "  رستا متوقف شد. برای اجرای مجدد: Start-Rasta.ps1" -ForegroundColor Green
Write-Host ""
