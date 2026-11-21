# مستند Endpointهای IdealBridge

> سند ۰۳ — مرجع کامل API نسخهٔ v1 (همین سند در قالب زنده: `/swagger`)

## قواعد عمومی

- **پایه:** `https://<host>:<port>/api/v1`
- **احراز هویت:** همهٔ endpointها (به‌جز `GET /health/live`) نیازمند توکن:
  ```
  X-API-Key: ibk_...
  ```
  یا `Authorization: Bearer ibk_...`
- **پاکت پاسخ:** همیشه `{ data, status, message, pagination? }`.
- **کدهای وضعیت:** `200` موفق · `400` ورودی نامعتبر · `401` توکن نامعتبر/منقضی/ابطال‌شده · `403` تخلف فقط-خواندنی · `404` یافت نشد · `429` عبور از سقف نرخ (۱۲۰ درخواست/دقیقه) · `503` خطای دیتابیس.

## پارامترهای صفحه‌بندی (مشترک)

| پارامتر | توضیح |
|---|---|
| `page` | شمارهٔ صفحهٔ ۱-مبنا |
| `pageSize` | ۱ تا ۵۰۰ (پیش‌فرض ۲۰) |
| `afterId` | پیمایش Keyset — فقط رکوردهای با شناسهٔ بزرگ‌تر (پیشنهادی برای همگام‌سازی) |

پاسخ `pagination` شامل `hasMore` و `nextAfterId` و `nextPageUrl` برای ادامهٔ دریافت است.

---

## اولویت ۱ — مشتریان

### `GET /api/v1/companies`
فیلترها:

| پارامتر | نوع | توضیح |
|---|---|---|
| `code` | string | تطابق دقیق `cmpCode` |
| `name` | string | جست‌وجوی بخشی از نام |
| `number` | int | شمارهٔ مشتری |
| `registeredFrom` / `registeredTo` | date | بازهٔ `RegisterDate` (میلادی) |
| `firstRegisteredFrom` / `firstRegisteredTo` | date | بازهٔ `FirstRegisterDate` |
| `referUserId` | int | بازاریاب/معرف |
| `isDraft` | bool | پیش‌نویس/نهایی |

نمونه: `GET /api/v1/companies?name=آلفا&pageSize=50`

### `GET /api/v1/companies/{id}`
مشتری با شناسهٔ پایدار `CompanyID`. خروجی شامل: هویت، کد/شماره، دسته‌بندی‌ها (گروه/زیرگروه/۱ تا ۴)، تماس‌ها، موقعیت جغرافیایی (`latitude`/`longitude`)، شناسه‌های ثبتی، بازاریاب (`referUserId`+`referUser`)، آخرین ویراستر، شخص اصلی، تاریخ‌ها.

**بدون فیلد رمز عبور** — `ApiCmpPassword` خروجی SP قدیمی Ideal در نگاشت حذف می‌شود.

### `GET /api/v1/companies/{id}/addresses`
آدرس‌های اضافهٔ مشتری (جدول `CrmCompanyAddresses`) با نوع، شهر، مختصات.

---

## اولویت ۲ — اشخاص و کاربران

### `GET /api/v1/persons`
فیلترها: `companyId` · `name` (نام/نام‌خانوادگی) · `mobile` · `workingOut`.

### `GET /api/v1/persons/{id}`

### `GET /api/v1/users`
فهرست کاربران CRM — فقط فیلدهای غیرحساس: `id, firstName, lastName, fullName, userName, personnelCode, isAdmin, isActive, isActiveInWinApp/WebApp/MobApp, mobile, mobile2, tel, positionId, userGroupId, nationalCode, startDate, expireDate, description`.

**ستون `Password` حتی در SELECT آورده نمی‌شود.**

### `GET /api/v1/users/{id}`

---

## اولویت ۳ — سوابق ارتباط و فعالیت

### `GET /api/v1/conversations`
مکالمات/پیگیری‌ها. فیلترها: `companyId` · `projectId` · `userId` · `fromDate`/`toDate` (بازهٔ `cnvsDateTime`).

### `GET /api/v1/projects`
پروژه‌های مشتری. فیلترها: `companyId` · `title` · `registeredFrom/To` · `isFinished`.

### `GET /api/v1/reminders?userId={id}`
یادآوری‌ها/وظایف کارتبل. پارامترها: `userId` (الزامی) · `fromDate`/`toDate` · `includeDone` (پیش‌فرض فقط انجام‌نشده‌ها).

### `GET /api/v1/baseinfo/{kind}`
اطلاعات پایه. مقادیر مجاز `kind`:
`companytitle, companytype, companygroup, companysubgroup, companygroupii, companygroupiii, companygroupiv, companypresentation, companyaddresstype, persontitle, persontype, personjob, persondepartment, persongroup, education, sex, city, province, country, projecttitle, projectgroup, projectgrade, projectpriority`

شهرها/استان‌ها با `parentId` سلسله‌مراتب دارند.

---

## اولویت ۴ — اطلاعات تجاری

### `GET /api/v1/warehouses?includeDeactivated=false`
### `GET /api/v1/products`
فیلترها: `code` · `name` · `groupId` · `registeredFrom/To`.
### `GET /api/v1/orders`
فیلترها: `number` · `companyId` · `fromDate`/`toDate` (تاریخ سند) · `registeredFrom/To` · `isVerified`.
### `GET /api/v1/preorders`
مشابه سفارش‌ها.

---

## همگام‌سازی

### `GET /api/v1/sync/companies`
| پارامتر | توضیح |
|---|---|
| `afterId` | ادامهٔ Keyset از این شناسه |
| `registeredFrom`/`registeredTo` | پنجرهٔ ثبت مشتریان جدید |
| `limit` | حداکثر رکورد در پاسخ (۱-۵۰۰، پیش‌فرض ۱۰۰) |

### `GET /api/v1/sync/persons` — `afterId`, `companyId`, `limit`
### `GET /api/v1/sync/conversations` — `afterId`, `companyId`, `limit`

راهنمای کامل الگوی همگام‌سازی: سند ۱۰.

---

## سلامت و مدیریت

### `GET /health/live` (بدون توکن)
زنده‌بودن سرویس.

### `GET /health/db` (با توکن)
کاوش زندهٔ دیتابیس: وضعیت اتصال، نام دیتابیس/سرور، جدول‌ها/ستون‌های موجود و مفقود، SPهای در دسترس، و حالت انتخاب‌شدهٔ هر موجودیت (`Sp|Table|Blocked`).

### `POST /api/v1/tokens` (هدر `X-Admin-Key`)
```json
{ "name": "MedPad-Integration", "expiresInDays": 90 }
```
پاسخ شامل `token` (فقط این یک‌بار نمایش داده می‌شود).

### `GET /api/v1/tokens` (هدر `X-Admin-Key`)
فهرست توکن‌ها (بدون مقادیر).

### `DELETE /api/v1/tokens/{id}` (هدر `X-Admin-Key`)
ابطال فوری.

---

## نمونهٔ فراخوانی (PowerShell)

```powershell
# متغیرها
$base = "http://localhost:5100"
$token = "ibk_YOUR_TOKEN"

# فهرست مشتریان (صفحهٔ دوم)
Invoke-RestMethod -Uri "$base/api/v1/companies?page=2&pageSize=50" `
  -Headers @{ "X-API-Key" = $token }

# ادامهٔ Keyset
Invoke-RestMethod -Uri "$base/api/v1/companies?afterId=100&pageSize=100" `
  -Headers @{ "X-API-Key" = $token }

# مشتری مشخص
Invoke-RestMethod -Uri "$base/api/v1/companies/123" -Headers @{ "X-API-Key" = $token }
```

معادل Linux (curl):
```bash
curl -H "X-API-Key: ibk_YOUR_TOKEN" "http://localhost:5100/api/v1/companies?page=2&pageSize=50"
```

---

## فاز ۱۱ — endpoint جدید

### `GET /api/v1/admin/connection` (هدر `X-Admin-Key`)

وضعیت اتصال SQL Server — بدون افشای رمز/Connection String.

**فاز ۱۱.۱:** فراخوانی پیش‌فرض «هیچ اتصالی برقرار نمی‌کند» — فقط وضعیت و پیکربندی امن را گزارش می‌دهد (قابل استفاده حتی وقتی هیچ Connection String تنظیم نشده است). با `?test=true` آزمون زندهٔ اتصال انجام می‌شود و `state` به‌روز می‌شود:

- `state` یکی از چهار وضعیت:
  - `Unconfigured` — هیچ تنظیمات اتصالی وجود ندارد (سرویس بالا می‌آید ولی endpointهای داده ۵۰۳ می‌دهند)؛
  - `Configured` — تنظیمات موجود است ولی هنوز آزمون زنده‌ای ثبت نشده (یا تنظیمات نامعتبر است — `configurationError` را ببینید)؛
  - `Connected` — آخرین آزمون زندهٔ اتصال موفق بوده است؛
  - `ConnectionFailed` — آخرین آزمون زنده شکست خورده (دستهٔ خطا در `lastLiveTest.errorKind`).

```json
{
  "data": {
    "state": "Connected",
    "configuration": {
      "configured": true, "source": "ConnectionString",
      "server": "SQLSRV\\IDEAL", "database": "IdealCrm",
      "authMode": "Sql", "encrypt": true, "trustServerCertificate": false,
      "connectTimeoutSeconds": 15, "applicationIntent": "ReadOnly", "applicationName": "IdealBridge"
    },
    "configurationError": null,
    "lastLiveTest": {
      "ok": true, "errorKind": "None", "message": "اتصال برقرار است.",
      "serverName": "SQLSRV", "databaseName": "IdealCrm",
      "serverVersion": "Microsoft SQL Server 2019 ...",
      "latencyMs": 14, "checkedAt": "2026-11-12T10:00:00Z"
    },
    "liveTest": { "...": "فقط با ?test=true — نتیجهٔ همین آزمون" }
  },
  "status": "Success", "message": "..."
}
```

`errorKind` یکی از: `Network` / `Authentication` / `DatabaseNotFound` / `Timeout` / `Configuration` / `PermissionDenied` / `SqlServerError` / `Unknown`.

> در حالت `Unconfigured` پاسخ HTTP برابر **200** است (گزارش وضعیت، نه خطا) اما endpointهای داده (مثل `/api/v1/companies`) و `/health/db` پاسخ کنترل‌شدهٔ **503** با پیام دقیق می‌دهند.

```powershell
# وضعیت بدون برقراری اتصال:
Invoke-RestMethod -Uri "http://localhost:5100/api/v1/admin/connection" -Headers @{ "X-Admin-Key" = $env:IdealBridge__AdminKey }
# آزمون زندهٔ اتصال:
Invoke-RestMethod -Uri "http://localhost:5100/api/v1/admin/connection?test=true" -Headers @{ "X-Admin-Key" = $env:IdealBridge__AdminKey }
```

### تغییر رفتار endpointهای داده (فاز ۱۱)

- `entityModes` در `GET /health/db` حالا `{mode, reason}` برای هر موجودیت است و `mode` فقط `Table` یا `Blocked` می‌تواند باشد (اجرای SP غیرفعال است).
- اگر جدول پشتیبان موجودیت مفقود باشد → پاسخ **503** با پیام «جدول X در دیتابیس Ideal یافت نشد» (نه آرایهٔ خالی).
