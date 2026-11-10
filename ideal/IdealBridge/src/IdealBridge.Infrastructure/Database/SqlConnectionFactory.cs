using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace IdealBridge.Infrastructure.Database;

/// <summary>
/// سازندهٔ اتصال به دیتابیس Ideal — نقطهٔ واحد عبور تمام کوئری‌ها.
/// هیچ SqlCommand خارج از این کلاس ساخته نمی‌شود تا گارد فقط-خواندنی قابل اثبات باشد.
/// </summary>
public interface IDbConnectionFactory
{
    Task<DbConnection> OpenConnectionAsync(CancellationToken ct = default);
    string ConnectionDescription { get; }
}

public class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    private readonly string _description;

    public SqlConnectionFactory(IdealBridgeOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ConnectionString))
            throw new InvalidOperationException(
                "Connection string تنظیم نشده است. متغیر محیطی IdealBridge__ConnectionString یا ConnectionString در appsettings.Production.json را مقدار دهید.");
        var b = new SqlConnectionStringBuilder(options.ConnectionString)
        {
            ApplicationName = "IdealBridge",
            // اتصال فقط-خواندنی در سطح intent — محدودیت نهایی با مجوز SQL Login اعمال می‌شود
            ApplicationIntent = ApplicationIntent.ReadOnly
        };
        _connectionString = b.ConnectionString;
        _description = $"{b.DataSource} / {b.InitialCatalog}";
    }

    public string ConnectionDescription => _description;

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
            await con.DisposeAsync();
            throw;
        }
    }
}
