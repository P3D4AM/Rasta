using System.Net;
using System.Text.Json;
using IdealBridge.Domain.Common;

namespace IdealBridge.Api.Middleware;

/// <summary>
/// مدیریت یکنواخت خطاها:
///  - ReadOnlyViolationException → 403 (تخلف فقط-خواندنی — هرگز متن SQL برنمی‌گردد)
///  - SqlException/DB خطا → 503 با پیام عمومی (بدون افشای جزئیات داخلی SQL Server)
///  - خطای اعتبارسنجی → 400
///  - خطای ناشناخته → 500 با شناسهٔ ردیابی
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (IdealBridge.Infrastructure.Database.ReadOnlyViolationException ex)
        {
            _logger.LogWarning("Read-only guard violation on {Path}: {Msg}", context.Request.Path, ex.Message);
            await Write(context, HttpStatusCode.Forbidden, ResultStatus.Error, "درخواست با سیاست فقط-خواندنی سرویس ناسازگار است.");
        }
        catch (IdealBridge.Domain.Common.DataAccessUnavailableException ex)
        {
            // جدول پشتیبان مفقود/ناقص — پیام شفاف و بدون جزئیات داخلی SQL
            _logger.LogWarning("Data access blocked on {Path}: {Entity} — {Msg}", context.Request.Path, ex.Entity, ex.Message);
            await Write(context, HttpStatusCode.ServiceUnavailable, ResultStatus.Error, ex.Message);
        }
        catch (System.Data.Common.DbException ex)
        {
            // جزئیات SQL فقط در لاگ داخلی — پاسخ عمومی
            _logger.LogError(ex, "Database error on {Path}", context.Request.Path);
            var msg = "خطای دیتابیس در پردازش درخواست؛ وضعیت اتصال یا مجوزهای SQL Login را با مدیر سیستم بررسی کنید.";
            if (ex is Microsoft.Data.SqlClient.SqlException se && se.Number is 4060 or 18456 or 1 or 2 or 53)
                msg = "اتصال به دیتابیس Ideal برقرار نشد؛ تنظیمات اتصال یا مجوز SQL Login را بررسی کنید.";
            await Write(context, HttpStatusCode.ServiceUnavailable, ResultStatus.Error, msg);
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Connection string", StringComparison.Ordinal))
        {
            _logger.LogError("Connection string not configured");
            await Write(context, HttpStatusCode.ServiceUnavailable, ResultStatus.Error, "تنظیمات اتصال دیتابیس Ideal تکمیل نشده است.");
        }
        catch (BadHttpRequestException) when (context.Response.StatusCode == 400)
        {
            await Write(context, HttpStatusCode.BadRequest, ResultStatus.Fail, "درخواست نامعتبر است.");
        }
        catch (Exception ex)
        {
            var traceId = context.TraceIdentifier;
            _logger.LogError(ex, "Unhandled error on {Path} trace={Trace}", context.Request.Path, traceId);
            var detail = context.RequestServices.GetService<Microsoft.Extensions.Configuration.IConfiguration>()
                ?.GetValue("IdealBridge:ShowErrorDetails", false) == true
                ? $" || {ex.GetType().Name}: {ex.Message}"
                : string.Empty;
            await Write(context, HttpStatusCode.InternalServerError, ResultStatus.Error,
                $"خطای داخلی سرویس. شناسهٔ ردیابی: {traceId}{detail}");
        }
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        // هم‌خوان با کنترلرها: status به‌صورت رشته («Success»/«Fail»/«Error») نه عدد
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() },
    };

    private static async Task Write(HttpContext ctx, HttpStatusCode status, ResultStatus result, string message)
    {
        if (ctx.Response.HasStarted) return;
        ctx.Response.Clear();
        ctx.Response.StatusCode = (int)status;
        ctx.Response.ContentType = "application/json; charset=utf-8";
        var body = JsonSerializer.Serialize(ApiResponse<object>.Failed(message, result), JsonOptions);
        await ctx.Response.WriteAsync(body);
    }
}
