# اجرای IdealBridge در Windows

> سند ۰۷ — از اجرای کنسولی تا سرویس Windows و IIS

## گزینهٔ الف — اجرای کنسولی (تست/شروع سریع)

```powershell
cd C:\path\to\Rasta\ideal\IdealBridge

# متغیرها (اگر با setx ماندگار نکرده‌اید)
$env:IdealBridge__ConnectionString = "Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"
$env:IdealBridge__AdminKey = "کلید-ادمین"
$env:ASPNETCORE_URLS = "http://0.0.0.0:5100"

dotnet src\IdealBridge.Api\bin\Release\net8.0\IdealBridge.Api.dll
```

## گزینهٔ ب — سرویس Windows با sc.exe (پایدار، پیشنهادی)

### ۱) Publish

```powershell
cd C:\path\to\Rasta\ideal\IdealBridge
dotnet publish src\IdealBridge.Api -c Release -o C:\IdealBridge
```

### ۲) ساخت سرویس

PowerShell **به‌عنوان Administrator**:

```powershell
# حساب سرویس (اختیاری اما توصیه‌شده) — حداقل دسترسی:
# اگر می‌خواهید از NetworkService استفاده کنید همین کافی است:
$svcUser = "NT AUTHORITY\NetworkService"

sc.exe create IdealBridge binPath= "C:\Program Files\dotnet\dotnet.exe C:\IdealBridge\IdealBridge.Api.dll" start= auto DisplayName= "IdealBridge API (Ideal CRM Read-Only Bridge)"
sc.exe description IdealBridge "سرویس پل فقط-خواندنی Ideal CRM به MedPad — پورت 5100"
sc.exe failure IdealBridge reset= 86400 actions= restart/60000/restart/60000/restart/120000
```

### ۳) متغیرهای محیطی سرویس

متغیرهای `setx` برای سرویس‌ها اعمال نمی‌شوند. با رجیستریِ آن سرویس تنظیم کنید:

```powershell
$hex = @'
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\IdealBridge\Environment]
"IdealBridge__ConnectionString"="Server=SQLSRV\\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True"
"IdealBridge__AdminKey"="کلید-ادمین"
"ASPNETCORE_URLS"="http://0.0.0.0:5100"
"ASPNETCORE_ENVIRONMENT"="Production"
'@
# رمز واقعی را جایگزین *** کنید، سپس:
$hex | Out-File -Encoding unicode C:\IdealBridge\env.reg
reg import C:\IdealBridge\env.reg
# فایل env.reg را بعد از import حذف کنید:
Remove-Item C:\IdealBridge\env.reg
```

> روش امن‌تر: `Environment` را روی پوشهٔ سرویس با ACL قفل کنید یا از Windows Credential/Secret Store سازمانی استفاده کنید. رمز هرگز در Git/مستندات نیست.

### ۴) شروع و پایش

```powershell
sc.exe start IdealBridge
sc.exe query IdealBridge

# لاگ‌های سرویس (Event Viewer → Windows Logs → Application، منبع dotnet)
Get-EventLog -LogName Application -Source "dotnet" -Newest 20

# تست سلامت
Invoke-RestMethod -Uri "http://localhost:5100/health/live"
```

### ۵) فایروال

```powershell
New-NetFirewallRule -DisplayName "IdealBridge API 5100" -Direction Inbound -Protocol TCP -LocalPort 5100 -Action Allow
```

> فقط IP سرور MedPad را مجاز کنید:
> ```powershell
> New-NetFirewallRule -DisplayName "IdealBridge API 5100 (MedPad only)" -Direction Inbound -Protocol TCP -LocalPort 5100 -RemoteAddress 192.168.1.50 -Action Allow
> ```

### ۶) مدیریت (توقف/حذف)

```powershell
sc.exe stop IdealBridge
sc.exe delete IdealBridge
```

## گزینهٔ ج — IIS (در صورت ترجیح سازمانی)

1. نصب ماژول **Hosting Bundle** (ASP.NET Core 8) روی سرور IIS.
2. Publish به `C:\inetpub\IdealBridge`.
3. IIS Manager → Add Website → Physical path همان پوشه، App Pool **No Managed Code**.
4. متغیرهای محیطی از طریق `web.config` داخل پوشهٔ publish:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
     <location path="." inheritInChildApplications="false">
       <system.webServer>
         <aspNetCore processPath="dotnet" arguments=".\IdealBridge.Api.dll" stdoutLogEnabled="true" stdoutLogFile=".\logs\stdout">
           <environmentVariables>
             <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Production" />
             <environmentVariable name="IdealBridge__ConnectionString" value="Server=SQLSRV\IDEAL;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True" />
             <environmentVariable name="IdealBridge__AdminKey" value="کلید-ادمین" />
           </environmentVariables>
         </aspNetCore>
       </system.webServer>
     </location>
   </configuration>
   ```
5. `web.config` شامل رمز است → آن را از Git مستثنا کنید (`appsettings.Production.json` و هر فایل حاوی Secret در `.gitignore` پروژه بلاک شده).

## نکات Windows-specific

- **مسیر لاگ توکن‌ها:** `C:\IdealBridge\tokens.json` (کنار DLL، طبق `TokenStorePath` نسبی) — از آن بکاپ بگیرید.
- **آپدیت:** stop → publish جدید → start. توکن‌ها در `tokens.json` باقی می‌مانند.
- **زمان‌بندی:** سرویس با `start= auto` بعد از ریبوت خودکار بالا می‌آید.
- معادل Linux این سند: سند ۰۸.
