using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IdealBridge.Security;

/// <summary>گزینه‌های طرح احراز هویت توکن IdealBridge.</summary>
public class IdealBridgeAuthOptions : AuthenticationSchemeOptions
{
    /// <summary>نام Header توکن (پیش‌فرض X-API-Key).</summary>
    public string HeaderName { get; set; } = "X-API-Key";
}

/// <summary>
/// Handler احراز هویت مبتنی بر توکن IdealBridge:
///  - توکن از هدر X-API-Key یا Authorization: Bearer خوانده می‌شود
///  - با TokenService (هش SHA-256 + انقضا + ابطال) اعتبارسنجی می‌شود
///  - کاملاً مستقل از احراز هویت داخلی Ideal CRM (حکم مأموریت)
/// </summary>
public class IdealBridgeAuthHandler : AuthenticationHandler<IdealBridgeAuthOptions>
{
    public const string SchemeName = "IdealBridgeToken";
    private readonly TokenService _tokens;

    public IdealBridgeAuthHandler(IOptionsMonitor<IdealBridgeAuthOptions> options, ILoggerFactory logger,
        UrlEncoder encoder, TokenService tokens)
        : base(options, logger, encoder)
    {
        _tokens = tokens;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string? token = null;
        if (Request.Headers.TryGetValue(Options.HeaderName, out var h) && !string.IsNullOrWhiteSpace(h))
            token = h.ToString().Trim();
        else if (Request.Headers.Authorization.Count > 0)
        {
            var auth = Request.Headers.Authorization.ToString();
            if (auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                token = auth["Bearer ".Length..].Trim();
        }

        if (string.IsNullOrEmpty(token))
            return Task.FromResult(AuthenticateResult.NoResult());

        var record = _tokens.Validate(token);
        if (record == null)
        {
            Logger.LogWarning("Invalid or expired/revoked token presented (prefix unknown)");
            return Task.FromResult(AuthenticateResult.Fail("invalid_token"));
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, record.Id),
            new(ClaimTypes.Name, record.Name),
            new("scope", record.Scopes),
            new("token_prefix", record.TokenPrefix),
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name)));
    }
}
