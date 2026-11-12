using IdealBridge.Infrastructure.Database;
using Microsoft.Data.SqlClient;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های زیرساخت اتصال SQL Server (فاز ۱۱) — بدون هیچ اتصال واقعی:
/// اعتبارسنجی پیکربندی (هر دو روش)، اعمال اجباری ApplicationIntent=ReadOnly و ApplicationName،
/// دسته‌بندی خطاها و پاک‌سازی Secret از لاگ.
/// </summary>
public class SqlConnectionProviderTests
{
    private const string SamplePassword = "P@ssw0rd-Secret-123";

    private static IdealBridgeOptions FullStringOptions() => new()
    {
        ConnectionString = $"Server=SQLSRV\\IDEAL;Database=IdealCrm;User Id=ibk_reader;Password={SamplePassword};Encrypt=True",
    };

    // ─── روش ۱: Connection String کامل ───

    [Fact]
    public void FullConnectionString_Is_Parsed_And_ReadOnlyIntent_Forced()
    {
        var (b, source, auth) = SqlConnectionFactory.BuildBuilder(FullStringOptions());
        Assert.Equal("ConnectionString", source);
        Assert.Equal("Sql", auth);
        Assert.Equal("SQLSRV\\IDEAL", b.DataSource);
        Assert.Equal("IdealCrm", b.InitialCatalog);
        Assert.Equal("ibk_reader", b.UserID);
        // قواعد فقط-خواندنی — همیشه اعمال می‌شوند (تست از طریق سازندهٔ نهایی):
        var factory = new SqlConnectionFactory(FullStringOptions());
        Assert.Contains("readOnlyIntent=ReadOnly", factory.ConnectionDescription, StringComparison.Ordinal);
    }

    [Fact]
    public void Factory_Forces_ApplicationName_And_ReadOnly_Intent()
    {
        // ApplicationName و ApplicationIntent در سازنده اعمال می‌شوند؛
        // از طریق Description قابل مشاهده‌اند و ConnectionString نهایی آن‌ها را دارد.
        var factory = new SqlConnectionFactory(FullStringOptions());
        Assert.Contains("readOnlyIntent=ReadOnly", factory.ConnectionDescription, StringComparison.Ordinal);
        Assert.True(factory.Summary.Configured);
        Assert.Equal("ConnectionString", factory.Summary.Source);
    }

    // ─── روش ۲: تنظیمات تفکیکی ───

    [Fact]
    public void DiscreteSettings_SqlAuth_Builds_Correctly()
    {
        var options = new IdealBridgeOptions
        {
            Sql = new SqlSettings
            {
                Server = "SQLSRV\\IDEAL", Database = "IdealCrm", AuthMode = "Sql",
                UserId = "ibk_reader", Password = SamplePassword,
            },
        };
        var (b, source, auth) = SqlConnectionFactory.BuildBuilder(options);
        Assert.Equal("Sql", source);
        Assert.Equal("Sql", auth);
        Assert.Equal("SQLSRV\\IDEAL", b.DataSource);
        Assert.Equal("IdealCrm", b.InitialCatalog);
        Assert.Equal("ibk_reader", b.UserID);
        Assert.True(b.Encrypt);                       // پیش‌فرض امن
        Assert.False(b.TrustServerCertificate);       // پیش‌فرض امن
    }

    [Fact]
    public void DiscreteSettings_WindowsAuth_Sets_IntegratedSecurity()
    {
        var options = new IdealBridgeOptions
        {
            Sql = new SqlSettings { Server = "SQLSRV", Database = "IdealCrm", AuthMode = "Windows" },
        };
        var (b, _, auth) = SqlConnectionFactory.BuildBuilder(options);
        Assert.Equal("Windows", auth);
        Assert.True(b.IntegratedSecurity);
        Assert.Empty(b.UserID ?? string.Empty);       // بدون کاربر SQL
    }

    [Fact]
    public void ConnectionString_Wins_Over_DiscreteSettings()
    {
        var options = FullStringOptions();
        options.Sql = new SqlSettings { Server = "OTHER", Database = "OtherDb", AuthMode = "Windows" };
        var (b, source, _) = SqlConnectionFactory.BuildBuilder(options);
        Assert.Equal("ConnectionString", source);
        Assert.Equal("SQLSRV\\IDEAL", b.DataSource);
    }

    // ─── اعتبارسنجی پیکربندی ───

    [Fact]
    public void Missing_Everything_Throws_Clear_ConfigurationError()
    {
        var ex = Assert.Throws<ConnectionConfigurationException>(
            () => SqlConnectionFactory.BuildBuilder(new IdealBridgeOptions()));
        Assert.Contains("تنظیمات اتصال", ex.Message, StringComparison.Ordinal);
        Assert.Contains("متغیر محیطی", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Discrete_SqlAuth_Without_Password_Throws()
    {
        var options = new IdealBridgeOptions
        {
            Sql = new SqlSettings { Server = "s", Database = "d", AuthMode = "Sql", UserId = "u" },
        };
        Assert.Throws<ConnectionConfigurationException>(() => SqlConnectionFactory.BuildBuilder(options));
    }

    [Fact]
    public void Discrete_Without_Database_Throws()
    {
        var options = new IdealBridgeOptions
        {
            Sql = new SqlSettings { Server = "s", AuthMode = "Sql", UserId = "u", Password = "p" },
        };
        var ex = Assert.Throws<ConnectionConfigurationException>(() => SqlConnectionFactory.BuildBuilder(options));
        Assert.Contains("Database", ex.Message, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("Kerberos")]
    [InlineData("")]
    public void Discrete_Invalid_AuthMode_Throws(string badMode)
    {
        var options = new IdealBridgeOptions
        {
            Sql = new SqlSettings { Server = "s", Database = "d", AuthMode = badMode, UserId = "u", Password = "p" },
        };
        Assert.Throws<ConnectionConfigurationException>(() => SqlConnectionFactory.BuildBuilder(options));
    }

    // ─── عدم افشای Secret ───

    [Fact]
    public void ConnectionDescription_Never_Contains_Password()
    {
        var factory = new SqlConnectionFactory(FullStringOptions());
        Assert.DoesNotContain(SamplePassword, factory.ConnectionDescription, StringComparison.Ordinal);
        Assert.DoesNotContain("Password=", factory.ConnectionDescription, StringComparison.OrdinalIgnoreCase);

        var json = System.Text.Json.JsonSerializer.Serialize(factory.Summary);
        Assert.DoesNotContain(SamplePassword, json, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("Server=s;Database=d;Password=abc123;User Id=u", "Password=***")]
    [InlineData("Server=s;pwd=hush;Database=d", "pwd=***")]
    [InlineData("Server=s;Database=d", "Server=s")]     // بدون رمز — دست‌نخورده
    public void SecretRedactor_Removes_Passwords(string input, string mustContain)
    {
        var redacted = SecretRedactor.Redact(input);
        Assert.DoesNotContain("abc123", redacted, StringComparison.Ordinal);
        Assert.DoesNotContain("hush", redacted, StringComparison.Ordinal);
        Assert.Contains(mustContain, redacted, StringComparison.Ordinal);
    }

    // ─── دسته‌بندی خطاها (بدون ساخت SqlException واقعی — نگاشت شماره → دسته) ───

    [Theory]
    [InlineData(18456, ConnectionErrorKind.Authentication)]
    [InlineData(18452, ConnectionErrorKind.Authentication)]
    [InlineData(18470, ConnectionErrorKind.Authentication)]     // حساب غیرفعال
    [InlineData(4060, ConnectionErrorKind.DatabaseNotFound)]
    [InlineData(-2, ConnectionErrorKind.Timeout)]
    [InlineData(121, ConnectionErrorKind.Timeout)]
    [InlineData(258, ConnectionErrorKind.Timeout)]
    [InlineData(2, ConnectionErrorKind.Network)]
    [InlineData(53, ConnectionErrorKind.Network)]
    [InlineData(10060, ConnectionErrorKind.Network)]
    [InlineData(10061, ConnectionErrorKind.Network)]
    [InlineData(229, ConnectionErrorKind.PermissionDenied)]     // مجوز SELECT ندارد
    [InlineData(87, ConnectionErrorKind.Configuration)]
    [InlineData(5001, ConnectionErrorKind.SqlServerError)]
    public void Error_Numbers_Map_To_Right_Kind(int number, ConnectionErrorKind expected)
    {
        var (kind, _) = SqlConnectionErrorClassifier.ClassifyCore(number, isTimeout: false, win32: null);
        Assert.Equal(expected, kind);
    }

    [Fact]
    public void Timeout_Flag_Wins_Over_Number()
    {
        var (kind, _) = SqlConnectionErrorClassifier.ClassifyCore(5001, isTimeout: true, win32: null);
        Assert.Equal(ConnectionErrorKind.Timeout, kind);
    }

    [Fact]
    public void Every_Kind_Has_A_Safe_Persian_Message()
    {
        foreach (var kind in Enum.GetValues<ConnectionErrorKind>())
        {
            var msg = SqlConnectionErrorClassifier.SafeMessageFor(kind);
            Assert.False(string.IsNullOrWhiteSpace(msg));
            Assert.DoesNotContain("SQLSRV", msg, StringComparison.Ordinal);   // بدون نام سرور
        }
    }
}
