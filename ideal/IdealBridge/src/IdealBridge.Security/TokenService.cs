using System.Security.Cryptography;

namespace IdealBridge.Security;

/// <summary>رکورد یک توکن API (MedPad) — فقط هش SHA-256 ذخیره می‌شود، هرگز خود توکن.</summary>
public class ApiTokenRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = string.Empty;      // نام مصرف‌کننده، مثل «MedPad-Integration»
    public string TokenHash { get; set; } = string.Empty; // Base64(SHA-256(token))
    public string TokenPrefix { get; set; } = string.Empty; // ۸ کاراکتر اول برای شناسایی در لاگ
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }
    public string? RevokedReason { get; set; }
    public string Scopes { get; set; } = "read";          // نقش‌ها؛ فعلاً read

    [System.Text.Json.Serialization.JsonIgnore]
    public bool IsActive => RevokedAt is null && (ExpiresAt is null || ExpiresAt > DateTime.UtcNow);
}

public class CreateTokenRequest
{
    public string Name { get; set; } = string.Empty;
    public int? ExpiresInDays { get; set; }
}

public class CreateTokenResult
{
    public ApiTokenRecord Record { get; set; } = null!;
    /// <summary>مقدار توتن — فقط یک‌بار هنگام ساخت نمایش داده می‌شود.</summary>
    public string PlainToken { get; set; } = string.Empty;
}

/// <summary>
/// سرویس توکن مستقل IdealBridge:
///  - تولید توکن تصادفی ۲۵۶ بیتی (prefix ibk_ + base64url)
///  - ذخیرهٔ فقط هش SHA-256 در فایل JSON (بدون وابستگی به دیتابیس)
///  - اعتبارسنجی + انقضا + ابطال
/// </summary>
public class TokenService
{
    private readonly string _filePath;
    private readonly object _lock = new();
    private List<ApiTokenRecord> _tokens;

    public TokenService(string filePath)
    {
        _filePath = filePath;
        _tokens = Load();
    }

    private List<ApiTokenRecord> Load()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var tokens = System.Text.Json.JsonSerializer.Deserialize<List<ApiTokenRecord>>(json);
                if (tokens != null) return tokens;
            }
        }
        catch
        {
            // فایل خراب → شروع خالی؛ توکن‌های قبلی باید دوباره ساخته شوند
        }
        return new List<ApiTokenRecord>();
    }

    private void Persist()
    {
        lock (_lock)
        {
            var dir = Path.GetDirectoryName(Path.GetFullPath(_filePath));
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
            var json = System.Text.Json.JsonSerializer.Serialize(_tokens, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
                // بدون گریز از + و / و حروف فارسی — این فایل محلی است و در HTML رندر نمی‌شود
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            });
            // نوشتن اتمیک
            var tmp = _filePath + ".tmp";
            File.WriteAllText(tmp, json);
            File.Move(tmp, _filePath, overwrite: true);
        }
    }

    private static string Base64Url(byte[] data)
        => Convert.ToBase64String(data).TrimEnd('=').Replace('+', '-').Replace('/', '_');

    /// <summary>ساخت توکن جدید — مقدار ساده فقط همین‌جا برمی‌گردد.</summary>
    public CreateTokenResult Create(string name, int? expiresInDays, string scopes = "read")
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("نام توکن الزامی است.");
        var bytes = RandomNumberGenerator.GetBytes(32);
        var plain = "ibk_" + Base64Url(bytes);
        var rec = new ApiTokenRecord
        {
            Name = name.Trim(),
            TokenHash = Convert.ToBase64String(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(plain))),
            TokenPrefix = plain[..Math.Min(12, plain.Length)],
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = expiresInDays is > 0 ? DateTime.UtcNow.AddDays(expiresInDays.Value) : null,
            Scopes = scopes,
        };
        lock (_lock) { _tokens.Add(rec); Persist(); }
        return new CreateTokenResult { Record = rec, PlainToken = plain };
    }

    /// <summary>اعتبارسنجی توکن خام — در صورت معتبر بودن رکوردش را برمی‌گرداند.</summary>
    public ApiTokenRecord? Validate(string plainToken)
    {
        if (string.IsNullOrEmpty(plainToken)) return null;
        var hash = Convert.ToBase64String(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(plainToken)));
        ApiTokenRecord? found;
        lock (_lock) { found = _tokens.FirstOrDefault(t => t.TokenHash == hash); }
        if (found == null) return null;
        if (!found.IsActive) return null;
        return found;
    }

    public bool Revoke(string id, string reason)
    {
        lock (_lock)
        {
            var t = _tokens.FirstOrDefault(x => x.Id == id);
            if (t == null) return false;
            t.RevokedAt = DateTime.UtcNow;
            t.RevokedReason = reason;
            Persist();
            return true;
        }
    }

    public IReadOnlyList<ApiTokenRecord> List() { lock (_lock) return _tokens.ToList(); }
}
