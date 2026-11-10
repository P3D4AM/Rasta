using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace IdealBridge.IntegrationTests;

/// <summary>
/// دوقلوی آزمونشی برای SqlConnection — بدون نیاز به SQL Server واقعی.
/// رفتار: متن هر دستور به ScriptHandler داده می‌شود و DataTable نتیجه برمی‌گردد.
/// کاوش فراداده (sys.tables/sys.columns/sys.procedures/sys.parameters) هم همین‌جا شبیه‌سازی می‌شود.
/// </summary>
/// <summary>خطای شبیه‌سازی‌شدهٔ دیتابیس — از DbException مشتق می‌شود تا مسیر مدیریت خطای واقعی آزموده شود.</summary>
public class SimulatedDbException : DbException
{
    public SimulatedDbException(string message) : base(message) { }
}

public class FakeDbConnection : DbConnection
{
    private ConnectionState _state = ConnectionState.Closed;

    /// <summary>sql (normalized) → DataTable نتیجه. اگر null برگرداند → خالی.</summary>
    public Func<string, DataTable?>? ScriptHandler { get; set; }

    /// <summary>اگر set شده باشد، OpenAsync این خطا را می‌دهد (شبیه‌سازی قطع اتصال).</summary>
    public Exception? FailOnOpen { get; set; }

    /// <summary>هر متنی که در متن دستور پیدا شود → پرتاب خطای SQL شبیه‌سازی‌شده.</summary>
    public string? FailWhenSqlContains { get; set; }

    public List<string> ExecutedCommands { get; } = new();

    private string Normalize(string sql) => Regex.Replace(sql, @"\s+", " ").Trim();

    public DataTable? ExecuteScript(string sql)
    {
        ExecutedCommands.Add(Normalize(sql));
        if (FailWhenSqlContains != null && sql.Contains(FailWhenSqlContains, StringComparison.OrdinalIgnoreCase))
            throw new SimulatedDbException("SIMULATED_SQL_FAILURE: simulated database error");
        return ScriptHandler?.Invoke(Normalize(sql));
    }

    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel) => throw new NotSupportedException();
    public override void ChangeDatabase(string databaseName) => throw new NotSupportedException();
    public override void Close() => _state = ConnectionState.Closed;
    public override void Open() => OpenAsync(CancellationToken.None).GetAwaiter().GetResult();
    public override async Task OpenAsync(CancellationToken cancellationToken)
    {
        if (FailOnOpen != null) throw FailOnOpen;
        await Task.CompletedTask;
        _state = ConnectionState.Open;
    }
    public override string ConnectionString { get; set; } = "Server=fake;Database=IdealDb;User Id=ibk_reader;Password=***";
    public override string Database => "IdealDb";
    public override ConnectionState State => _state;
    public override string DataSource => "FAKESERVER";
    public override string ServerVersion => "15.00.2000 (Fake)";
    protected override DbCommand CreateDbCommand() => new FakeDbCommand { Connection = this };
}

public class FakeDbCommand : DbCommand
{
    private FakeDbConnection? FakeConn => Connection as FakeDbConnection;
    private readonly FakeDbParameterCollection _parameters = new();

    public override string CommandText { get; set; } = "";
    public override int CommandTimeout { get; set; }
    public override CommandType CommandType { get; set; }
    public override bool DesignTimeVisible { get; set; }
    public override UpdateRowSource UpdatedRowSource { get; set; }
    protected override DbConnection? DbConnection { get; set; }
    protected override DbParameterCollection DbParameterCollection => _parameters;
    protected override DbTransaction? DbTransaction { get; set; }

    public override void Cancel() { }
    public override int ExecuteNonQuery() => throw new NotSupportedException("IdealBridge فقط خواندنی است");
    public override object ExecuteScalar()
    {
        var table = FakeConn!.ExecuteScript(CommandText);
        if (table == null || table.Rows.Count == 0 || table.Columns.Count == 0) return 0;
        return table.Rows[0][0];
    }
    public override void Prepare() { }

    protected override DbParameter CreateDbParameter() => new FakeDbParameter();

    protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        => ExecuteFake();

    public override Task<object> ExecuteScalarAsync(CancellationToken cancellationToken)
        => Task.FromResult(ExecuteScalar());

    protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken)
        => await Task.Run(() => (DbDataReader)ExecuteFake());

    /// <summary>
    /// شبیه‌سازی WHERE/OFFSET/FETCH بر اساس پارامترهای متصل:
    ///  - @afterId: فیلتر keyset روی ستون کلید (ستون اول)
    ///  - @id: تطابق دقیق روی ستون کلید
    ///  - @skip/@take: صفحه‌بندی OFFSET/FETCH
    ///  - @companyId/@cid: فیلتر روی ستون دوم CompanyId (لیست‌های فرعی)
    /// </summary>
    private FakeDbDataReader ExecuteFake()
    {
        var table = FakeConn!.ExecuteScript(CommandText) ?? new DataTable();
        var result = table.Copy();
        object? Param(string name)
        {
            var idx = _parameters.IndexOf(name);
            if (idx < 0) return null;
            var v = _parameters[idx]?.Value;
            return v is DBNull ? null : v;
        }

        var afterId = Param("@afterId") as int?;
        var id = Param("@id") as int?;
        var skip = Param("@skip") as int?;
        var take = Param("@take") as int?;
        var companyId = (Param("@companyId") ?? Param("@cid")) as int?;

        if (result.Columns.Count > 0)
        {
            var keyCol = result.Columns[0];
            IEnumerable<DataRow> rows = result.Rows.Cast<DataRow>();
            if (afterId.HasValue)
                rows = rows.Where(r => Convert.ToInt32(r[keyCol]) > afterId.Value);
            if (id.HasValue)
                rows = rows.Where(r => Convert.ToInt32(r[keyCol]) == id.Value);
            if (companyId.HasValue && result.Columns.Count > 1 && result.Columns[1].ColumnName.Contains("CompanyId", StringComparison.OrdinalIgnoreCase))
                rows = rows.Where(r => r[result.Columns[1]] != DBNull.Value && Convert.ToInt32(r[result.Columns[1]]) == companyId.Value);
            if (skip.HasValue)
                rows = rows.Skip(skip.Value);
            if (take.HasValue)
                rows = rows.Take(take.Value);
            var filtered = result.Clone();
            foreach (var r in rows.ToList()) filtered.ImportRow(r);
            return new FakeDbDataReader(filtered);
        }
        return new FakeDbDataReader(result);
    }
}

public class FakeDbParameter : DbParameter
{
    public override DbType DbType { get; set; }
    public override ParameterDirection Direction { get; set; } = ParameterDirection.Input;
    public override bool IsNullable { get; set; }
    public override string ParameterName { get; set; } = "";
    public override string SourceColumn { get; set; } = "";
    public override bool SourceColumnNullMapping { get; set; }
    public override int Size { get; set; }
    public override object? Value { get; set; }
    public override void ResetDbType() { }
}

public class FakeDbParameterCollection : DbParameterCollection
{
    private readonly List<DbParameter> _list = new();
    public override int Count => _list.Count;
    public override object SyncRoot => _list;

    public override int Add(object value) { _list.Add((DbParameter)value); return _list.Count - 1; }
    public override void AddRange(Array values) { foreach (var v in values) _list.Add((DbParameter)v!); }
    public override void Clear() => _list.Clear();
    public override bool Contains(object value) => _list.Contains((DbParameter)value);
    public override bool Contains(string value) => _list.Any(p => p.ParameterName == value);
    public override void CopyTo(Array array, int index) { }
    public override System.Collections.IEnumerator GetEnumerator() => _list.GetEnumerator();
    public override int IndexOf(object value) => _list.IndexOf((DbParameter)value);
    public override int IndexOf(string parameterName) => _list.FindIndex(p => p.ParameterName == parameterName);
    public override void Insert(int index, object value) => _list.Insert(index, (DbParameter)value);
    public override void Remove(object value) => _list.Remove((DbParameter)value);
    public override void RemoveAt(int index) => _list.RemoveAt(index);
    public override void RemoveAt(string parameterName) => _list.RemoveAt(IndexOf(parameterName));
    protected override DbParameter GetParameter(int index) => _list[index];
    protected override DbParameter GetParameter(string parameterName) => _list[IndexOf(parameterName)];
    protected override void SetParameter(int index, DbParameter value) => _list[index] = value;
    protected override void SetParameter(string parameterName, DbParameter value) => _list[IndexOf(parameterName)] = value;
}

public class FakeDbDataReader : DbDataReader
{
    private readonly DataTable _table;
    private int _row = -1;
    public FakeDbDataReader(DataTable table) => _table = table;

    public override bool Read() { _row++; return _row < _table.Rows.Count; }
    public override int FieldCount => _table.Columns.Count;
    public override int GetOrdinal(string name)
    {
        var col = _table.Columns.IndexOf(name);
        if (col < 0) throw new IndexOutOfRangeException($"Column {name} not found in fake result (columns: {string.Join(",", _table.Columns.Cast<DataColumn>().Select(c => c.ColumnName))})");
        return col;
    }
    public override bool IsDBNull(int ordinal) => _table.Rows[_row][ordinal] is DBNull or null;
    public override object GetValue(int ordinal) => _table.Rows[_row][ordinal];
    public override bool GetBoolean(int ordinal) => (bool)GetValue(ordinal);
    public override byte GetByte(int ordinal) => (byte)GetValue(ordinal);
    public override long GetBytes(int ordinal, long dataOffset, byte[]? buffer, int bufferOffset, int length) => 0;
    public override char GetChar(int ordinal) => (char)GetValue(ordinal);
    public override long GetChars(int ordinal, long dataOffset, char[]? buffer, int bufferOffset, int length) => 0;
    public override string GetDataTypeName(int ordinal) => _table.Columns[ordinal].DataType.Name;
    public override DateTime GetDateTime(int ordinal) => (DateTime)GetValue(ordinal);
    public override decimal GetDecimal(int ordinal) => (decimal)GetValue(ordinal);
    public override double GetDouble(int ordinal) => (double)GetValue(ordinal);
    public override System.Collections.IEnumerator GetEnumerator() => _table.Rows.GetEnumerator();
    public override Type GetFieldType(int ordinal) => _table.Columns[ordinal].DataType;
    public override float GetFloat(int ordinal) => (float)GetValue(ordinal);
    public override Guid GetGuid(int ordinal) => (Guid)GetValue(ordinal);
    public override short GetInt16(int ordinal) => (short)GetValue(ordinal);
    public override int GetInt32(int ordinal) => (int)GetValue(ordinal);
    public override long GetInt64(int ordinal) => (long)GetValue(ordinal);
    public override string GetName(int ordinal) => _table.Columns[ordinal].ColumnName;
    public override int GetValues(object[] values) { for (int i = 0; i < FieldCount; i++) values[i] = GetValue(i); return FieldCount; }
    public override bool HasRows => _table.Rows.Count > 0;
    public override bool IsClosed => false;
    public override int RecordsAffected => 0;
    public override object this[int ordinal] => GetValue(ordinal);
    public override object this[string name] => GetValue(GetOrdinal(name));
    public override int Depth => 0;
    public override string GetString(int ordinal) => (string)GetValue(ordinal);
    public override bool NextResult() => false;
}

/// <summary>کارخانهٔ اتصال ساختگی برای تزریق در DI.</summary>
public class FakeDbConnectionFactory : IdealBridge.Infrastructure.Database.IDbConnectionFactory
{
    public FakeDbConnection Connection { get; set; } = new();
    public Task<DbConnection> OpenConnectionAsync(CancellationToken ct = default)
    {
        if (Connection.FailOnOpen != null) throw Connection.FailOnOpen;
        if (Connection.State != ConnectionState.Open) Connection.Open();
        return Task.FromResult<DbConnection>(Connection);
    }
    public string ConnectionDescription => "FAKESERVER / IdealDb (test double)";
}
