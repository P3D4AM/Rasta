# مستند Swagger / OpenAPI

> سند ۱۱ — دسترسی به مستند زندهٔ IdealBridge

## فعال‌بودن

- **Development:** همیشه فعال.
- **Production:** به‌طور پیش‌فرض فعال (سرویس شبکهٔ داخلی). خاموش‌کردن:

```powershell
# PowerShell
$env:IdealBridge__EnableSwagger = "false"
```

```bash
# Linux
export IdealBridge__EnableSwagger=false
```

## آدرس‌ها

| آدرس | توضیح |
|---|---|
| `http://<host>:<port>/swagger` | رابط تعاملی Swagger UI |
| `http://<host>:<port>/swagger/v1/swagger.json` | فایل OpenAPI 3.0 (قابل Import در Postman/Insomnia/کدژن) |

## امنیت تعریف‌شده در OpenAPI

سند OpenAPI، طرح امنیتی `X-API-Key` دارد:
- در Swagger UI دکمهٔ **Authorize** را بزنید؛
- مقدار توکن (`ibk_...`) را وارد کنید؛
- حالا همهٔ endpointهای محافظت‌شده مستقیم از UI قابل تست‌اند.

`GET /health/live` بدون احراز هویت است؛ بقیه نیازمندند.

## نمونهٔ تولید کد کلاینت (برای MedPad Integration Service)

با OpenAPI Generator (بدون وابستگی به این مخزن):

```powershell
# PowerShell — کلاینت C#
npm i -g @openapitools/openapi-generator-cli
openapi-generator-cli generate -i http://localhost:5100/swagger/v1/swagger.json -g csharp-netcore -o .\medpad-client --additional-properties=packageName=IdealBridge.Client
```

```bash
# Linux — معادل همان
openapi-generator-cli generate -i http://localhost:5100/swagger/v1/swagger.json -g csharp-netcore -o ./medpad-client
```

> پیشنهاد: مستند زنده مرجع اصلی است؛ همین فایل JSON را در مخزن MedPad نسخه‌بندی کنید تا قرارداد بین دو تیم منجمد و قابل ردیابی باشد.

## خروجی نمونه (برگرفته از swagger.json)

```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "IdealBridge API",
    "version": "v1",
    "description": "سرویس پل فقط-خواندنی بین دیتابیس Ideal CRM و MedPad — احراز هویت با هدر X-API-Key"
  },
  "paths": {
    "/api/v1/companies": {
      "get": {
        "tags": ["Companies"],
        "summary": "فهرست مشتریان با فیلتر و صفحه‌بندی",
        "security": [{ "X-API-Key": [] }]
      }
    }
  },
  "components": {
    "securitySchemes": {
      "X-API-Key": { "type": "apiKey", "in": "header", "name": "X-API-Key" }
    }
  }
}
```

## تست دستی سریع با curl

```bash
# گرفتن swagger.json
curl http://localhost:5100/swagger/v1/swagger.json -o swagger.json

# فراخوانی نمونهٔ محافظت‌شده
curl -H "X-API-Key: ibk_YOUR_TOKEN" http://localhost:5100/api/v1/companies?pageSize=3
```
