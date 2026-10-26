# ═══════════════════════════════════════════════════════════════════════════
#  رستا (Rasta) CRM — نسخهٔ توسعه‌ای ویندوز — اسکریپت آماده‌سازی اولیه (اختیاری)
#  Install-Rasta.ps1
#
#  این بسته «نصب» لازم ندارد — Start-Rasta.ps1 به‌تنهایی کافی است.
#  این اسکریپت فقط کارهای زیر را انجام می‌دهد:
#    ۱) بررسی سلامت بسته (node.exe، server.js، دیتابیس اولیه)
#    ۲) بررسی نسخهٔ PowerShell و فضای دیسک
#    ۳) رفع «Mark of the Web» (که ویندوز روی فایل‌های دانلودشده می‌گذارد)
#    ۴) ساخت میان‌بر دسکتاپ برای اجرا (اختیاری، با تأیید شما)
#
#  نیازی به دسترسی مدیر (Run as Administrator) ندارد.
# ═══════════════════════════════════════════════════════════════════════════

[CmdletBinding()]
param(
    [switch]$NoShortcut
)

$ErrorActionPreference = 'Stop'
try { [Console]::OutputEncoding = [System.Text.Encoding]::UTF8 } catch { }

$Root = $PSScriptRoot

function Write-Ok($msg)   { Write-Host "  [OK] $msg" -ForegroundColor Green }
function Write-Info($msg) { Write-Host "  $msg" -ForegroundColor Gray }
function Write-Warn2($msg) { Write-Host "  [توجه] $msg" -ForegroundColor Yellow }

Write-Host ""
Write-Host "  آماده‌سازی بستهٔ رستا (نسخهٔ توسعه‌ای)" -ForegroundColor Cyan
Write-Host ("  محل بسته: {0}" -f $Root)
Write-Host ""

# ─── ۱) نسخهٔ PowerShell ───
if ($PSVersionTable.PSVersion.Major -lt 5) {
    Write-Warn2 "نسخهٔ PowerShell شما کمتر از 5 است ($($PSVersionTable.PSVersion)). ویندوز ۱۰/۱۱ به‌صورت پیش‌فرض 5.1 دارد؛ بهتر است از powershell.exe استفاده کنید."
} else {
    Write-Ok "نسخهٔ PowerShell: $($PSVersionTable.PSVersion)"
}

# ─── ۲) سلامت بسته ───
$required = @(
    'runtime\node.exe',
    'app\server.js',
    'seed\rasta-seed.db',
    'Start-Rasta.ps1',
    'Stop-Rasta.ps1'
)
$missing = @()
foreach ($f in $required) {
    if (-not (Test-Path -LiteralPath (Join-Path $Root $f))) { $missing += $f }
}
if ($missing.Count -gt 0) {
    Write-Host "  خطا: این فایل‌ها در بسته نیستند:" -ForegroundColor Red
    $missing | ForEach-Object { Write-Host "    - $_" -ForegroundColor Red }
    Write-Host "  فایل ZIP را کامل و بدون خطا استخراج کنید." -ForegroundColor Red
    exit 1
}
Write-Ok "فایل‌های ضروری بسته موجود است."

# ─── ۳) فضای دیسک (حداقل ۳۰۰MB روی درایو بسته) ───
try {
    $drive = (Get-PSDrive -Name ($Root.Substring(0, 1)) -ErrorAction Stop)
    $freeMb = [math]::Round($drive.Free / 1MB)
    if ($freeMb -lt 300) {
        Write-Warn2 "فضای آزاد این درایو کم است ($freeMb MB). حداقل 300MB لازم است."
    } else {
        Write-Ok "فضای آزاد درایو: $freeMb MB"
    }
} catch { Write-Warn2 "فضای دیسک بررسی نشد." }

# ─── ۴) رفع Mark of the Web (جلوگیری از پیام امنیتی ویندوز) ───
try {
    $unblocked = 0
    Get-ChildItem -LiteralPath $Root -Recurse -File -ErrorAction SilentlyContinue | ForEach-Object {
        $z = Get-Content -LiteralPath $_.FullName -Stream Zone.Identifier -ErrorAction SilentlyContinue
        if ($z) { Unblock-File -LiteralPath $_.FullName -ErrorAction SilentlyContinue; $unblocked++ }
    }
    if ($unblocked -gt 0) { Write-Ok "علامت امنیتی ویندوز از $unblocked فایل برداشته شد." }
    else { Write-Ok "فایل‌ها علامت امنیتی نداشتند (استخراج سالم)." }
} catch { Write-Warn2 "بررسی Mark of the Web انجام نشد (مشکل جدی نیست)." }

# ─── ۵) میان‌بر دسکتاپ ───
if (-not $NoShortcut) {
    $answer = Read-Host "  میان‌بر «رستا» روی دسکتاپ ساخته شود؟ (y/N)"
    if ($answer -eq 'y' -or $answer -eq 'Y' -or $answer -eq 'yes') {
        try {
            $desktop = [Environment]::GetFolderPath('Desktop')
            $lnkPath = Join-Path $desktop 'Rasta CRM.lnk'
            $shell = New-Object -ComObject WScript.Shell
            $shortcut = $shell.CreateShortcut($lnkPath)
            $shortcut.TargetPath = Join-Path $Root 'Start-Rasta.bat'
            $shortcut.WorkingDirectory = $Root
            $shortcut.Description = 'Rasta CRM — Dev Release'
            $shortcut.Save()
            Write-Ok "میان‌بر ساخته شد: $lnkPath"
        } catch {
            Write-Warn2 "ساخت میان‌بر ممکن نشد: $($_.Exception.Message)"
        }
    } else {
        Write-Info "ساخت میان‌بر رد شد."
    }
}

Write-Host ""
Write-Host "  آماده است! برای اجرای برنامه:" -ForegroundColor Green
Write-Host "    - روی Start-Rasta.bat دوبار کلیک کنید، یا" -ForegroundColor White
Write-Host "    - در PowerShell این دستور را بزنید:" -ForegroundColor White
Write-Host ("      {0}" -f (Join-Path $Root 'Start-Rasta.ps1')) -ForegroundColor White
Write-Host ""
