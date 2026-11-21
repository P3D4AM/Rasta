namespace IdealBridge.Api.Middleware;

/// <summary>ثبت زمان و نتیجهٔ هر درخواست (بدون لاگ مقدار توکن — فقط پیشوند).</summary>
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            await _next(context);
        }
        finally
        {
            sw.Stop();
            var prefix = context.User.FindFirst("token_prefix")?.Value ?? "-";
            _logger.LogInformation(
                "REQ {Method} {Path} → {Status} in {Elapsed}ms token={Prefix} user={User}",
                context.Request.Method, context.Request.Path, context.Response.StatusCode,
                sw.ElapsedMilliseconds, prefix, context.User.Identity?.Name ?? "-");
        }
    }
}
