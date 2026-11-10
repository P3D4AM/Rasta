using System.Data;
using System.Data.Common;
using IdealBridge.Infrastructure.Database;
using Microsoft.Data.SqlClient;

namespace IdealBridge.Infrastructure.Database;

/// <summary>گزینه‌های IdealBridge از IConfiguration.</summary>
public class IdealBridgeOptions
{
    public const string SectionName = "IdealBridge";

    /// <summary>Connection String دیتابیس Ideal — مقدار واقعی فقط از Environment Variable / Secret.</summary>
    public string? ConnectionString { get; set; }

    /// <summary>حالت دسترسی به داده: Auto (پیش‌فرض) | Table | Sp.</summary>
    public string DataAccessMode { get; set; } = "Auto";

    /// <summary>حالت فقط-خواندنی را در سطح کد اعمال کن (همیشه true؛ فقط برای تست غیرفعال می‌شود).</summary>
    public bool EnforceReadOnlyGuard { get; set; } = true;

    /// <summary>مسیر ذخیرهٔ توکن‌ها.</summary>
    public string TokenStorePath { get; set; } = "tokens.json";

    /// <summary>کلید اصلی ادمین برای مدیریت توکن‌ها (Environment Variable توصیه می‌شود).</summary>
    public string? AdminKey { get; set; }
}

/// <summary>
/// اجراکنندهٔ یکپارچهٔ کوئری‌های فقط-خواندنی: ساخت دستور از روی Connection موجود + گارد + اجرا + نگاشت.
/// </summary>
public class IdealDb
{
    private readonly IDbConnectionFactory _factory;
    private readonly bool _enforceGuard;

    public IdealDb(IDbConnectionFactory factory, IdealBridgeOptions options)
    {
        _factory = factory;
        _enforceGuard = options.EnforceReadOnlyGuard;
    }

    public IDbConnectionFactory Factory => _factory;

    /// <summary>کوئری متن SELECT پارامتری و نگاشت سطرها.</summary>
    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, Action<DbParameterCollection>? bind, Func<DbDataReader, T> map, CancellationToken ct = default)
    {
        await using var con = await _factory.OpenConnectionAsync(ct);
        return await QueryOnAsync(con, sql, bind, map, ct);
    }

    /// <summary>اجرای کوئری روی اتصال باز (برای تراکنش‌های خواندنی ترکیبی).</summary>
    public async Task<IReadOnlyList<T>> QueryOnAsync<T>(DbConnection con, string sql, Action<DbParameterCollection>? bind, Func<DbDataReader, T> map, CancellationToken ct = default)
    {
        using var cmd = con.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        if (_enforceGuard) ReadOnlyCommandGuard.Validate(cmd.CommandText, cmd.CommandType);
        bind?.Invoke(cmd.Parameters);
        var list = new List<T>();
        await using var reader = await cmd.ExecuteReaderAsync(ct);
        while (await reader.ReadAsync(ct)) list.Add(map(reader));
        return list;
    }

    /// <summary>فراخوانی SP فقط-خواندنی از فهرست سفید.</summary>
    public async Task<IReadOnlyList<T>> QuerySpAsync<T>(string spName, Action<DbParameterCollection>? bind, Func<DbDataReader, T> map, CancellationToken ct = default)
    {
        await using var con = await _factory.OpenConnectionAsync(ct);
        using var cmd = con.CreateCommand();
        cmd.CommandText = spName;
        cmd.CommandType = CommandType.StoredProcedure;
        if (_enforceGuard) ReadOnlyCommandGuard.Validate(cmd.CommandText, cmd.CommandType);
        bind?.Invoke(cmd.Parameters);
        var list = new List<T>();
        await using var reader = await cmd.ExecuteReaderAsync(ct);
        while (await reader.ReadAsync(ct)) list.Add(map(reader));
        return list;
    }

    /// <summary>اجرای اسکالر (COUNT و ...) — فقط برای متن SELECT.</summary>
    public async Task<long> CountAsync(string sql, Action<DbParameterCollection>? bind, CancellationToken ct = default)
    {
        await using var con = await _factory.OpenConnectionAsync(ct);
        using var cmd = con.CreateCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        if (_enforceGuard) ReadOnlyCommandGuard.Validate(cmd.CommandText, cmd.CommandType);
        bind?.Invoke(cmd.Parameters);
        var result = await cmd.ExecuteScalarAsync(ct);
        return result == null || result == DBNull.Value ? 0 : Convert.ToInt64(result);
    }
}

/// <summary>کمکی ساخت پارامتر برای SqlCommand.</summary>
public static class DbParamExtensions
{
    public static DbParameter Add(this DbParameterCollection col, string name, object? value)
    {
        var p = new SqlParameter(name, value ?? DBNull.Value) { Direction = ParameterDirection.Input };
        col.Add(p);
        return p;
    }
}
