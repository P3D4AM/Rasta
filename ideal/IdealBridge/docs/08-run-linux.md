# اجرای IdealBridge در Linux

> سند ۰۸ — پشتیبانی کامل Linux (systemd / Nginx) — با معادل Windows هر دستور

## ۱) نصب پیش‌نیاز

```bash
# Ubuntu/Debian — ASP.NET Core Runtime 8 (برای اجرا؛ برای build همان dotnet-sdk-8.0)
sudo apt-get update && sudo apt-get install -y aspnetcore-runtime-8.0
```

> **معادل Windows:** دانلود ASP.NET Core Runtime 8 از dotnet.microsoft.com و نصب MSI.

## ۲) Publish و مسیر استقرار

```bash
cd /opt
git clone -b ideal https://github.com/P3D4AM/Rasta.git rasta
cd rasta/ideal/IdealBridge
dotnet publish src/IdealBridge.Api -c Release -o /opt/idealbridge
```

> **معادل Windows:** `dotnet publish src\IdealBridge.Api -c Release -o C:\IdealBridge`

## ۳) متغیرهای محیطی — فایل محافظت‌شدهٔ سرویس

```bash
sudo nano /opt/idealbridge/idealbridge.env
```

محتوا (رمز واقعی را بگذارید):

```env
IdealBridge__ConnectionString=Server=sqlsrv;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True
IdealBridge__AdminKey=کلید-ادمین
ASPNETCORE_URLS=http://0.0.0.0:5100
ASPNETCORE_ENVIRONMENT=Production
```

```bash
sudo chmod 600 /opt/idealbridge/idealbridge.env
sudo chown root:root /opt/idealbridge/idealbridge.env
```

> **معادل Windows:** کلید `HKLM\SYSTEM\CurrentControlSet\Services\IdealBridge\Environment` (سند ۰۷).
> این فایل هرگز Git نمی‌شود (الگوی `*.env` خارج از مخزن است).

## ۴) سرویس systemd

```bash
sudo nano /etc/systemd/system/idealbridge.service
```

```ini
[Unit]
Description=IdealBridge API (Ideal CRM Read-Only Bridge)
After=network.target

[Service]
WorkingDirectory=/opt/idealbridge
ExecStart=/usr/bin/dotnet /opt/idealbridge/IdealBridge.Api.dll
EnvironmentFile=/opt/idealbridge/idealbridge.env
Restart=always
RestartSec=10
User=www-data
Group=www-data

# امنیت
NoNewPrivileges=true
ProtectSystem=strict
ReadWritePaths=/opt/idealbridge

[Install]
WantedBy=multi-user.target
```

```bash
sudo systemctl daemon-reload
sudo systemctl enable --now idealbridge
sudo systemctl status idealbridge
journalctl -u idealbridge -n 50 --no-pager
```

> **معادل Windows:** `sc.exe create IdealBridge ...` + `sc.exe failure ...` (سند ۰۷).

## ۵) فایروال (فقط MedPad)

```bash
sudo ufw allow from 192.168.1.50 to any port 5100 proto tcp
sudo ufw enable
```

> **معادل Windows:** `New-NetFirewallRule -RemoteAddress 192.168.1.50 ...` (سند ۰۷).

## ۶) اجرای تستی بدون سرویس (معادل اجرای کنسولی)

```bash
export IdealBridge__ConnectionString='Server=sqlsrv;Database=CRM;User Id=ibk_reader;Password=***;TrustServerCertificate=True'
export IdealBridge__AdminKey='کلید-ادمین'
ASPNETCORE_URLS="http://0.0.0.0:5100" dotnet /opt/idealbridge/IdealBridge.Api.dll
```

## ۷) Nginx به‌عنوان Reverse Proxy با HTTPS (اختیاری)

```nginx
server {
    listen 443 ssl;
    server_name idealbridge.internal.example;

    ssl_certificate     /etc/ssl/certs/idealbridge.pem;
    ssl_certificate_key /etc/ssl/private/idealbridge.key;

    location / {
        proxy_pass         http://127.0.0.1:5100;
        proxy_http_version 1.1;
        proxy_set_header   Host $host;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}
```

در این حالت `ASPNETCORE_URLS=http://127.0.0.1:5100` بگذارید تا سرویس فقط از Nginx قابل دسترس باشد، و در Program.cs هدرهای Forwarded فعال‌اند (استاندارد ASP.NET Core 8 با `UseHttpsRedirection`/ForwardedHeaders قابل افزودن است).

> **معادل Windows:** IIS Reverse Proxy (ARR) یا مستقیم روی Kestrel با HTTP internal.

## ۸) به‌روزرسانی و نگهداری

```bash
sudo systemctl stop idealbridge
cd /opt/rasta/ideal/IdealBridge && git pull --ff-only origin ideal
dotnet publish src/IdealBridge.Api -c Release -o /opt/idealbridge
sudo systemctl start idealbridge
```

- فایل `tokens.json` در `/opt/idealbridge` حین publish بازنویسی **نمی‌شود** (در .gitignore و خارج از سورس) — بکاپ داشته باشید.
- لاگ‌ها: `journalctl -u idealbridge -f`

## ۹) چک‌لیست Post-deployment (هر دو OS)

```bash
curl -s http://localhost:5100/health/live                      # زنده؟
curl -s -H "X-API-Key: ibk_..." http://localhost:5100/health/db | head -40   # اتصال + اسکیما؟
curl -s -H "X-API-Key: ibk_..." "http://localhost:5100/api/v1/companies?pageSize=3"
```
