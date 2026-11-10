using System.Data.Common;

namespace IdealBridge.Infrastructure.Repositories;

/// <summary>کمکی خواندن امن ستون‌های DbDataReader با نام.</summary>
public static class Reader
{
    public static int GetInt(DbDataReader r, string col) => r.GetOrdinal(col) is var i && r.IsDBNull(i) ? 0 : r.GetInt32(i);
    public static int? GetIntN(DbDataReader r, string col) => r.GetOrdinal(col) is var i && r.IsDBNull(i) ? null : r.GetInt32(i);
    public static long GetLong(DbDataReader r, string col) => r.GetOrdinal(col) is var i && r.IsDBNull(i) ? 0 : r.GetInt64(i);
    public static long? GetLongN(DbDataReader r, string col) => r.GetOrdinal(col) is var i && r.IsDBNull(i) ? null : r.GetInt64(i);
    public static string? GetStr(DbDataReader r, string col) { var i = r.GetOrdinal(col); return r.IsDBNull(i) ? null : r.GetString(i); }
    public static bool? GetBoolN(DbDataReader r, string col) { var i = r.GetOrdinal(col); return r.IsDBNull(i) ? null : r.GetBoolean(i); }
    public static DateTime? GetDateN(DbDataReader r, string col) { var i = r.GetOrdinal(col); return r.IsDBNull(i) ? null : r.GetDateTime(i); }
    public static decimal? GetDecN(DbDataReader r, string col) { var i = r.GetOrdinal(col); return r.IsDBNull(i) ? null : r.GetDecimal(i); }
    public static double? GetDoubleN(DbDataReader r, string col) { var i = r.GetOrdinal(col); return r.IsDBNull(i) ? null : r.GetDouble(i); }

    /// <summary>IsAdmin در Ideal از نوع nvarchar است («True»/«False»/خالی) — تبدیل امن.</summary>
    public static bool? GetBoolLikeN(DbDataReader r, string col)
    {
        var i = r.GetOrdinal(col);
        if (r.IsDBNull(i)) return null;
        var v = r.GetValue(i);
        return v switch
        {
            bool b => b,
            string s when string.IsNullOrWhiteSpace(s) => null,
            string s => bool.TryParse(s, out var b) ? b : (s == "1"),
            int n => n != 0,
            _ => null
        };
    }
}
