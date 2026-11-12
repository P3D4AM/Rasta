using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>
/// Endpoint مدیریتی وضعیت اتصال SQL Server (فاز ۱۱) — فقط با هدر X-Admin-Key.
/// خروجی: خلاصهٔ امن پیکربندی (بدون رمز/Connection String) + نتیجهٔ آزمون زندهٔ اتصال با دستهٔ خطا.
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
    /// وضعیت اتصال: پیکربندی (بدون مقادیر محرمانه) + آزمون زندهٔ اتصال.
    /// برای بررسی سریع سلامت اتصال توسط ادمین — بدون نیاز به توکن دادهٔ MedPad.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Status(CancellationToken ct)
    {
        if (!AdminOk())
        {
            _logger.LogWarning("Connection status attempt with wrong admin key from {Ip}", HttpContext.Connection.RemoteIpAddress);
            return StatusCode(StatusCodes.Status401Unauthorized, ApiResponse<object>.Failed("کلید مدیر معتبر نیست.", ResultStatus.Error));
        }

        var test = await _factory.TestConnectionAsync(ct);
        if (!test.Ok)
            _logger.LogWarning("Connection test failed: {Kind} — {Msg}", test.ErrorKind, test.SafeMessage);

        return Ok(ApiResponse<object>.Ok(new
        {
            configuration = _factory.Summary,          // Server/Database/AuthMode/Encrypt/TrustCert/Timeout — بدون رمز
            liveTest = new
            {
                ok = test.Ok,
                errorKind = test.ErrorKind.ToString(),
                message = test.SafeMessage,            // پیام امن فارسی — بدون جزئیات داخلی
                serverName = test.ServerName,
                databaseName = test.DatabaseName,
                serverVersion = test.ServerVersion,
                latencyMs = test.LatencyMs,
                checkedAt = test.CheckedAt,
            },
        }));
    }
}
