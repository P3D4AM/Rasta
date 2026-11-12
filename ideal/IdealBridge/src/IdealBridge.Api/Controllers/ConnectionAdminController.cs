using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>
/// Endpoint مدیریتی وضعیت اتصال SQL Server — فقط با هدر X-Admin-Key.
/// فاز ۱۱.۱:
///  - GET پیش‌فرض «هیچ اتصالی برقرار نمی‌کند» — فقط وضعیت (State) و پیکربندی امن را گزارش می‌دهد
///    (قابل استفاده حتی وقتی هیچ Connection String تنظیم نشده — Unconfigured).
///  - GET ?test=true آزمون زندهٔ اتصال انجام می‌دهد و State را به Connected/ConnectionFailed به‌روز می‌کند.
/// خروجی: وضعیت چهارگانه (Unconfigured/Configured/Connected/ConnectionFailed) + خلاصهٔ امن پیکربندی
/// (بدون رمز/Connection String) + نتیجهٔ آزمون زنده با دستهٔ خطا.
/// </summary>
[ApiController]
[Route("api/v1/admin/connection")]
public class ConnectionAdminController : ControllerBase
{
    private readonly IDbConnectionFactory _factory;
    private readonly IdealBridgeOptions _options;
    private readonly ILogger<ConnectionAdminController> _logger;

    public ConnectionAdminController(IDbConnectionFactory factory,
        Microsoft.Extensions.Options.IOptions<IdealBridgeOptions> options,
        ILogger<ConnectionAdminController> logger)
    {
        _factory = factory;
        _options = options.Value;
        _logger = logger;
    }

    private bool AdminOk()
    {
        var expected = _options.AdminKey;
        if (string.IsNullOrWhiteSpace(expected)) return false;
        var provided = Request.Headers["X-Admin-Key"].ToString();
        return System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(
            System.Text.Encoding.UTF8.GetBytes(expected),
            System.Text.Encoding.UTF8.GetBytes(provided));
    }

    /// <summary>
    /// وضعیت اتصال — بدون برقراری اتصال (پیش‌فرض).
    /// state یکی از: Unconfigured | Configured | Connected | ConnectionFailed.
    /// با ?test=true آزمون زندهٔ اتصال انجام می‌شود (تنها در این حالت Connection ساخته می‌شود).
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Status(CancellationToken ct, [FromQuery] bool test = false)
    {
        if (!AdminOk())
        {
            _logger.LogWarning("Connection status attempt with wrong admin key from {Ip}", HttpContext.Connection.RemoteIpAddress);
            return StatusCode(StatusCodes.Status401Unauthorized, ApiResponse<object>.Failed("کلید مدیر معتبر نیست.", ResultStatus.Error));
        }

        ConnectionTestResult? liveTest = null;
        if (test)
        {
            liveTest = await _factory.TestConnectionAsync(ct);
            if (!liveTest.Ok)
                _logger.LogWarning("Connection test failed: {Kind} — {Msg}", liveTest.ErrorKind, liveTest.SafeMessage);
        }

        return Ok(ApiResponse<object>.Ok(new
        {
            state = _factory.State.ToString(),          // Unconfigured | Configured | Connected | ConnectionFailed
            configuration = _factory.Summary,          // Server/Database/AuthMode/Encrypt/TrustCert/Timeout — بدون رمز
            configurationError = _factory.ConfigurationError,  // null یا پیام امن فارسی (بدون Secret)
            lastLiveTest = _factory.LastLiveTest is null ? null : ToDto(_factory.LastLiveTest),   // آخرین آزمون ثبت‌شده (null = هنوز آزمونی نیست)
            liveTest = liveTest is null ? null : ToDto(liveTest),   // فقط با ?test=true
        }));
    }

    /// <summary>شکل امن و پایدار خروجی آزمون اتصال — هم‌نام با قرارداد فاز ۱۱ (message، نه SafeMessage).</summary>
    private static object ToDto(ConnectionTestResult t) => new
    {
        ok = t.Ok,
        errorKind = t.ErrorKind.ToString(),
        message = t.SafeMessage,                        // پیام امن فارسی — بدون جزئیات داخلی
        serverName = t.ServerName,
        databaseName = t.DatabaseName,
        serverVersion = t.ServerVersion,
        latencyMs = t.LatencyMs,
        checkedAt = t.CheckedAt,
    };
}
