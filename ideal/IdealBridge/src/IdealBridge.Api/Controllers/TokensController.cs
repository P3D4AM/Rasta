using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;
using IdealBridge.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>
/// مدیریت توکن‌های IdealBridge — با کلید مدیر (Environment Variable IdealBridge__AdminKey).
/// کلید مدیر در هدر X-Admin-Key ارسال می‌شود و از توکن‌های عادی جدا است.
/// </summary>
[ApiController]
[Route("api/v1/tokens")]
public class TokensController : ControllerBase
{
    private readonly TokenService _tokens;
    private readonly IdealBridgeOptions _options;
    private readonly ILogger<TokensController> _logger;

    public TokensController(TokenService tokens, Microsoft.Extensions.Options.IOptions<IdealBridgeOptions> options, ILogger<TokensController> logger)
    {
        _tokens = tokens;
        _options = options.Value;
        _logger = logger;
    }

    private bool AdminOk()
    {
        var expected = _options.AdminKey;
        if (string.IsNullOrWhiteSpace(expected)) return false;   // بدون کلید ادمین، مدیریت غیرفعال است
        var provided = Request.Headers["X-Admin-Key"].ToString();
        return System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(
            System.Text.Encoding.UTF8.GetBytes(expected),
            System.Text.Encoding.UTF8.GetBytes(provided));
    }

    /// <summary>ساخت توکن جدید برای یک مصرف‌کننده (مثل MedPad). مقدار توکن فقط همین‌جا برگردانده می‌شود.</summary>
    [HttpPost]
    public IActionResult Create([FromBody] CreateTokenRequest req)
    {
        if (!AdminOk())
        {
            _logger.LogWarning("Token create attempt with wrong admin key from {Ip}", HttpContext.Connection.RemoteIpAddress);
            return StatusCode(StatusCodes.Status401Unauthorized, ApiResponse<object>.Failed("کلید مدیر معتبر نیست.", ResultStatus.Error));
        }
        try
        {
            var result = _tokens.Create(req.Name, req.ExpiresInDays);
            _logger.LogInformation("Token created: {Id} name={Name} prefix={Prefix} expires={Exp}",
                result.Record.Id, result.Record.Name, result.Record.TokenPrefix, result.Record.ExpiresAt);
            return Ok(ApiResponse<object>.Ok(new
            {
                token = result.PlainToken,   // فقط این پاسخ
                record = result.Record,
            }, "توکن ساخته شد؛ مقدار آن را ذخیره کنید — دوباره نمایش داده نمی‌شود."));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ApiResponse<object>.Failed(ex.Message, ResultStatus.Fail));
        }
    }

    /// <summary>فهرست توکن‌ها (بدون مقادیر — فقط پیشوند و وضعیت).</summary>
    [HttpGet]
    public IActionResult List()
    {
        if (!AdminOk())
            return StatusCode(StatusCodes.Status401Unauthorized, ApiResponse<object>.Failed("کلید مدیر معتبر نیست.", ResultStatus.Error));
        return Ok(ApiResponse<object>.Ok(_tokens.List()));
    }

    /// <summary>ابطال توکن.</summary>
    [HttpDelete("{id}")]
    public IActionResult Revoke(string id, [FromBody] RevokeRequest? body)
    {
        if (!AdminOk())
            return StatusCode(StatusCodes.Status401Unauthorized, ApiResponse<object>.Failed("کلید مدیر معتبر نیست.", ResultStatus.Error));
        var ok = _tokens.Revoke(id, body?.Reason ?? "revoked via API");
        return ok
            ? Ok(ApiResponse<object>.Ok(new { id }, "توکن ابطال شد."))
            : NotFound(ApiResponse<object>.Failed($"توکن {id} یافت نشد.", ResultStatus.Fail));
    }
}

public class RevokeRequest
{
    public string? Reason { get; set; }
}
