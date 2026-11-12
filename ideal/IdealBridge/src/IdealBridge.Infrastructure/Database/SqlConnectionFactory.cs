using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace IdealBridge.Infrastructure.Database;

/// <summary>نوع احراز هویت SQL Server.</summary>
public enum SqlAuthMode
{
    /// <summary>Connection String کامل در IdealBridge:ConnectionString (یا متغیر محیطی معادل).</summary>
    ConnectionString,

    /// <summary>تنظیمات تفکیکی + SQL Authentication (UserId/Password).</summary>
    Sql,

    /// <summary>تنظیمات تفکیکی + Windows Authentication (Integrated Security) — فقط روی Windows (در Linux نیازمند Kerberos).</summary>
    Windows,
}

/// <summary>تنظیمات تفکیکی اتصال (IdealBridge:Sql) — جایگزین سرراست Connection String.</summary>
public class SqlSettings
{
    /// <summary>نمونه/آدرس سرور، مثل SQLSRV یا SQLSRV\IDEAL یا sqlsrv.local,1433.</summary>
    public string? Server { get; set; }

    /// <summary>نام دیتابیس Ideal (حدس زده نمی‌شود — از محیط نصب پرسیده شود).</summary>
    public string? Database { get; set; }

    /// <summary>نوع احراز هویت: ConnectionString (پیش‌فرض) | Sql | Windows.</summary>
    public string? AuthMode { get; set; }

    /// <summary>کاربر SQL (فقط در حالت Sql) — از Environment Variable توصیه می‌شود.</summary>
    public string? UserId { get; set; }

    /// <summary>رمز عبور (فقط در حالت Sql) — هرگز در فایل/لاگ/Git قرار نمی‌گیرد؛ Environment Variable یا Secret.</summary>
    public string? Password { get; set; }

    /// <summary>رمزنگاری مسیر (پیش‌فرض true — الزام Microsoft.Data.SqlClient 4+).</summary>
    public bool? Encrypt { get; set; }

    /// <summary>اعتماد به گواهی سرور (فقط برای آزمایش داخلی؛ در Production به‌همراه گواهی معتبر false بماند).</summary>
    public bool? TrustServerCertificate { get; set; }

    /// <summary>مهلت برقراری اتصال (ثانیه، پیش‌فرض ۱۵).</summary>
    public int? ConnectTimeoutSeconds { get; set; }
}

/// <summary>خلاصهٔ ساختاریافتهٔ امن اتصال — بدون رمز و بدون Connection String خام.</summary>
public class ConnectionSummary
{
    public bool Configured { get; init; }
    /// <summary>منبع پیکربندی: ConnectionString | Sql | None.</summary>
    public string Source { get; init; } = "None";
    public string? Server { get; init; }
    public string? Database { get; init; }
    /// <summary>ConnectionString | Sql | Windows.</summary>
    public string AuthMode { get; init; } = "-";
    public bool Encrypt { get; init; }
    public bool TrustServerCertificate { get; init; }
    public int ConnectTimeoutSeconds { get; init; }
    public const string ApplicationIntent = "ReadOnly";
    public string ApplicationName => "IdealBridge";
}

/// <summary>خطای دسته‌بندی‌شدهٔ اتصال — برای گزارش سلامت و پیام‌های شفاف.</summary>
public enum ConnectionErrorKind
{
    None = 0,
    /// <summary>سرور در دسترس نیست / شبکه / DNS / پورت بسته.</summary>
    Network,
    /// <summary>ورود ناموفق (رمز/کاربر اشتباه، حساب غیرفعال).</summary>
    Authentication,
    /// <summary>دیتابیس موردنظر باز نشد (نام غلط یا دسترسی).</summary>
    DatabaseNotFound,
    /// <summary>زمان اتصال تمام شد.</summary>
    Timeout,
    /// <summary>مقدارهای پیکربندی نامعتبر.</summary>
    Configuration,
    /// <summary>مجوز کافی روی آبجکت‌ها وجود ندارد (مثلاً SELECT/VIEW DEFINITION داده نشده).</summary>
    PermissionDenied,
    /// <summary>سایر خطاهای SQL Server.</summary>
    SqlServerError,
    Unknown,
}

/// <summary>
/// دسته‌بندی خطای اتصال SQL Server بر اساس SqlException.Number و ساختار استثنا —
/// بدون افشای جزئیات داخلی؛ برای پیام شفاف به کاربر و لاگ.
/// </summary>
public static class SqlConnectionErrorClassifier
{
    /// <summary>دستهٔ خطا + پیام امن (فارسی) برای هر دسته.</summary>
    public static (ConnectionErrorKind Kind, string SafeMessage) Classify(Exception ex)
    {
        switch (ex)
        {
            case SqlException se:
                // مهلت: SqlException شمارهٔ -2 (attention) یا مسیر TimeoutException پایین‌تر
                return ClassifyCore(se.Number, isTimeout: false, se.InnerException as System.ComponentModel.Win32Exception);
            case System.ComponentModel.Win32Exception win:
                return (ConnectionErrorKind.Network, SafeMessageFor(ConnectionErrorKind.Network));
            case TimeoutException or OperationCanceledException:
                return (ConnectionErrorKind.Timeout, SafeMessageFor(ConnectionErrorKind.Timeout));
            case ArgumentException:
                return (ConnectionErrorKind.Configuration, SafeMessageFor(ConnectionErrorKind.Configuration));
            case InvalidOperationException ioe when ioe.Message.Contains("Connection string", StringComparison.Ordinal):
                return (ConnectionErrorKind.Configuration, SafeMessageFor(ConnectionErrorKind.Configuration));
            default:
                return (ConnectionErrorKind.Unknown, SafeMessageFor(ConnectionErrorKind.Unknown));
        }
    }

    /// <summary>هستهٔ نگاشت شمارهٔ خطا → دسته (برای تست واحد بدون ساخت SqlException واقعی).</summary>
    internal static (ConnectionErrorKind, string) ClassifyCore(int number, bool isTimeout, System.ComponentModel.Win32Exception? win32)
    {
        if (isTimeout) return (ConnectionErrorKind.Timeout, SafeMessageFor(ConnectionErrorKind.Timeout));

        ConnectionErrorKind kind = number switch
        {
            // احراز هویت
            18456 or 18452 or 18450 or 18461 or 18465 or 18470 or 18471 or 18488
                => ConnectionErrorKind.Authentication,
            // دیتابیس باز نشد
            4060 => ConnectionErrorKind.DatabaseNotFound,
            // زمان‌انتظار
            121 or 258 or -2 => ConnectionErrorKind.Timeout,
            // شبکه / سرور در دسترس نیست
            2 or 53 or 64 or 10053 or 10054 or 10057 or 10060 or 10061 or 11001 or 1231 or 2580 => ConnectionErrorKind.Network,
            // مجوز روی آبجکت
            229 or 230 or 262 or 300 or 3310 => ConnectionErrorKind.PermissionDenied,
            // پیکربندی
            87 => ConnectionErrorKind.Configuration,
            _ => ConnectionErrorKind.SqlServerError,
        };
        return (kind, SafeMessageFor(kind));
    }

    /// <summary>پیام امن هر دسته — بدون نام سرور/کاربر/رمز یا جزئیات داخلی SQL.</summary>
    public static string SafeMessageFor(ConnectionErrorKind kind) => kind switch
    {
        ConnectionErrorKind.Network =>
            "سرور SQL در دسترس نیست — نام Instance، شبکه/فایروال و روشن‌بودن سرویس SQL Server را بررسی کنید.",
        ConnectionErrorKind.Authentication =>
            "احراز هویت SQL ناموفق بود — نام کاربری/رمز حساب فقط-خواندنی و فعال‌بودن آن را بررسی کنید.",
        ConnectionErrorKind.DatabaseNotFound =>
            "دیتابیس Ideal باز نشد — نام دیتابیس در تنظیمات و دسترسی حساب به آن را بررسی کنید.",
        ConnectionErrorKind.Timeout =>
            "مهلت برقراری اتصال به SQL Server تمام شد — پاسخ‌گویی سرور و شبکه را بررسی کنید.",
        ConnectionErrorKind.Configuration =>
            "تنظیمات اتصال نامعتبر است — مقدارهای IdealBridge:Sql / ConnectionString را بازبینی کنید.",
        ConnectionErrorKind.PermissionDenied =>
            "حساب SQL مجوز لازم برای خواندن این آبجکت را ندارد — مجوز SELECT (و در صورت نیاز VIEW DEFINITION) بدهید.",
        ConnectionErrorKind.SqlServerError =>
            "خطای SQL Server هنگام پردازش درخواست — لاگ سرویس را برای جزئیات بررسی کنید.",
        _ => "خطای ناشناختهٔ اتصال به دیتابیس — لاگ سرویس را بررسی کنید.",
    };
}

/// <summary>خطای پیکربندی اتصال — با پیام فارسی شفاف؛ در راه‌اندازی یا نخستین درخواست رخ می‌دهد.</summary>
public class ConnectionConfigurationException : InvalidOperationException
{
    public ConnectionConfigurationException(string message) : base(message) { }
}

/// <summary>نتیجهٔ آزمون اتصال — فقط اطلاعات امن (بدون Connection String/رمز).</summary>
public class ConnectionTestResult
{
    public bool Ok { get; init; }
    public ConnectionErrorKind ErrorKind { get; init; }
    public string SafeMessage { get; init; } = string.Empty;
    public string? ServerName { get; init; }
    public string? DatabaseName { get; init; }
    public string? ServerVersion { get; init; }
    public int LatencyMs { get; init; }
    public DateTime CheckedAt { get; init; } = DateTime.UtcNow;
}

/// <summary>
/// سازندهٔ اتصال به دیتابیس Ideal — نقطهٔ واحد عبور تمام کوئری‌ها.
/// هیچ SqlCommand خارج از IdealDb ساخته نمی‌شود تا گارد فقط-خواندنی قابل اثبات باشد.
///
/// فاز ۱۱: دو روش پیکربندی —
///  ۱. IdealBridge:ConnectionString (کامل)؛
///  ۲. IdealBridge:Sql با فیلدهای تفکیکی (Server/Database/AuthMode/UserId/Password/Encrypt/
///     TrustServerCertificate/ConnectTimeoutSeconds) — رمز فقط از Environment Variable.
/// در هر دو حالت: ApplicationName=IdealBridge، ApplicationIntent=ReadOnly و مهلت اتصال اعمال می‌شود.
/// </summary>
public interface IDbConnectionFactory
{
    Task<DbConnection> OpenConnectionAsync(CancellationToken ct = default);
    string ConnectionDescription { get; }
    /// <summary>آزمون اتصال با دسته‌بندی خطا — برای Health Check و endpoint مدیریتی.</summary>
    Task<ConnectionTestResult> TestConnectionAsync(CancellationToken ct = default);
    /// <summary>خلاصهٔ امن پیکربندی اتصال — بدون هیچ مقدار محرمانه.</summary>
    ConnectionSummary Summary { get; }
}

public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    private readonly string _description;
    private readonly ConnectionSummary _summary;

    public SqlConnectionFactory(IdealBridgeOptions options)
    {
        var (builder, source, authMode) = BuildBuilder(options);
        // در هر دو روش پیکربندی: قواعد فقط-خواندنی و شناسایی سرویس اعمال می‌شود
        builder.ApplicationName = "IdealBridge";
        builder.ApplicationIntent = ApplicationIntent.ReadOnly;   // intent — جایگزین مجوز SQL نیست
        if (!builder.TryGetValue("Connect Timeout", out _))
            builder.ConnectTimeout = 15;
        _connectionString = builder.ConnectionString;
        _description = $"{builder.DataSource} / {builder.InitialCatalog}";
        _summary = new ConnectionSummary
        {
            Configured = true,
            Source = source,
            Server = builder.DataSource,
            Database = builder.InitialCatalog,
            AuthMode = authMode,
            Encrypt = builder.Encrypt,
            TrustServerCertificate = builder.TrustServerCertificate,
            ConnectTimeoutSeconds = builder.ConnectTimeout,
        };
    }

    /// <summary>ساخت SqlConnectionStringBuilder از پیکربندی — internal برای تست واحد (بدون اتصال واقعی).</summary>
    internal static (SqlConnectionStringBuilder b, string source, string authMode) BuildBuilder(IdealBridgeOptions options)
    {
        var sql = options.Sql;

        if (!string.IsNullOrWhiteSpace(options.ConnectionString))
        {
            var b = new SqlConnectionStringBuilder(options.ConnectionString);
            return (b, "ConnectionString", b.IntegratedSecurity ? "Windows" : "Sql");
        }

        if (sql is { Server: not null })
        {
            var mode = (sql.AuthMode ?? "Sql").Trim().ToLowerInvariant() switch
            {
                "sql" => SqlAuthMode.Sql,
                "windows" or "integrated" or "integratedsecurity" => SqlAuthMode.Windows,
                _ => throw new ConnectionConfigurationException(
                    $"IdealBridge:Sql:AuthMode نامعتبر است: «{sql.AuthMode}» — مقادیر مجاز: Sql | Windows."),
            };
            if (string.IsNullOrWhiteSpace(sql.Database))
                throw new ConnectionConfigurationException(
                    "IdealBridge:Sql:Database تنظیم نشده است (نام دیتابیس Ideal از محیط نصب دریافت شود — حدس زده نمی‌شود).");

            var b = new SqlConnectionStringBuilder
            {
                DataSource = sql.Server,
                InitialCatalog = sql.Database,
                Encrypt = sql.Encrypt ?? true,
                TrustServerCertificate = sql.TrustServerCertificate ?? false,
            };
            if (sql.ConnectTimeoutSeconds is int t && t > 0)
                b.ConnectTimeout = t;
            if (mode == SqlAuthMode.Sql)
            {
                if (string.IsNullOrWhiteSpace(sql.UserId) || string.IsNullOrWhiteSpace(sql.Password))
                    throw new ConnectionConfigurationException(
                        "در IdealBridge:Sql:AuthMode=Sql مقدار UserId و Password الزامی است (Password فقط از متغیر محیطی IdealBridge__Sql__Password).");
                b.UserID = sql.UserId;
                b.Password = sql.Password;
            }
            else
            {
                b.IntegratedSecurity = true;   // Windows Authentication — روی ویندوز؛ در Linux نیازمند Kerberos
            }
            return (b, "Sql", mode == SqlAuthMode.Sql ? "Sql" : "Windows");
        }

        throw new ConnectionConfigurationException(
            "تنظیمات اتصال دیتابیس Ideal کامل نشده است. یا IdealBridge:ConnectionString را تنظیم کنید " +
            "یا IdealBridge:Sql (Server/Database/AuthMode/UserId/Password) را — مقادیر واقعی از متغیر محیطی/Secret.");
    }

    /// <summary>توصیف امن اتصال — بدون رمز و بدون Connection String خام (برای لاگ/مدیریت).</summary>
    public string ConnectionDescription =>
        $"{_description} [auth={_summary.AuthMode}, encrypt={_summary.Encrypt}, trustCert={_summary.TrustServerCertificate}, " +
        $"timeout={_summary.ConnectTimeoutSeconds}s, readOnlyIntent={ConnectionSummary.ApplicationIntent}]";

    public ConnectionSummary Summary => _summary;

    public async Task<DbConnection> OpenConnectionAsync(CancellationToken ct = default)
    {
        var con = new SqlConnection(_connectionString);
        try
        {
            await con.OpenAsync(ct);
            return con;
        }
        catch
        {
            await con.DisposeAsync();   // جلوگیری از نشت اتصال در شکست Open
            throw;
        }
    }

    public async Task<ConnectionTestResult> TestConnectionAsync(CancellationToken ct = default)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            await using var con = await OpenConnectionAsync(ct);
            await using var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT @@SERVERNAME, DB_NAME(), @@VERSION";
            cmd.CommandType = CommandType.Text;
            await using var r = await cmd.ExecuteReaderAsync(ct);
            string? server = null, db = null, version = null;
            if (await r.ReadAsync(ct))
            {
                server = r.IsDBNull(0) ? null : r.GetString(0);
                db = r.IsDBNull(1) ? null : r.GetString(1);
                version = (r.IsDBNull(2) ? null : r.GetString(2))?.Split('\n').FirstOrDefault()?.Trim();
            }
            sw.Stop();
            return new ConnectionTestResult
            {
                Ok = true,
                ErrorKind = ConnectionErrorKind.None,
                SafeMessage = "اتصال برقرار است.",
                ServerName = server,
                DatabaseName = db,
                ServerVersion = version,
                LatencyMs = (int)sw.ElapsedMilliseconds,
            };
        }
        catch (Exception ex)
        {
            sw.Stop();
            var (kind, safe) = SqlConnectionErrorClassifier.Classify(ex);
            return new ConnectionTestResult
            {
                Ok = false,
                ErrorKind = kind,
                SafeMessage = safe,
                LatencyMs = (int)sw.ElapsedMilliseconds,
            };
        }
    }
}

/// <summary>پاک‌ساز رشته‌ها برای لاگ — رمز/Connection String هرگز در لاگ نمی‌نشیند.</summary>
public static class SecretRedactor
{
    /// <summary>جایگزینی مقدار Password در هر متنی که به‌اشتباه ممکن است حاوی Connection String باشد.</summary>
    public static string Redact(string input)
    {
        if (string.IsNullOrEmpty(input)) return input ?? string.Empty;
        // Password=...; یا Pwd=...; تا نقطه‌ویرگول یا انتها
        var redacted = System.Text.RegularExpressions.Regex.Replace(
            input, @"(?i)(password|pwd)\s*=\s*[^;]*", "$1=***");
        return redacted;
    }
}
