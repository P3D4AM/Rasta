// ═══════════════════════════════════════════════════════════════
// IdeaSchemaDump — ابزار مستقل استخراج فرادادهٔ دیتابیس Ideal CRM
// ───────────────────────────────────────────────────────────────
// فقط-خواندنی: هیچ دستوری به‌جز SELECT روی sys.* اجرا نمی‌شود.
// خروجی: گزارش JSON شامل جداول/ستون‌ها/کلیدها/SPها + مقایسه با
// انتظارات IdealBridge (نسخهٔ مرجع 3.1.18.187).
//
// اجرا:
//   dotnet run --project tools/IdeaSchemaDump -- --connection "Server=...;Database=...;User Id=...;Password=...;" [--out report.json]
//   یا با متغیر محیطی: IdealBridge__ConnectionString
// ═══════════════════════════════════════════════════════════════

using System.Data;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

var connString = Args("--connection") ?? Environment.GetEnvironmentVariable("IdealBridge__ConnectionString");
var outFile = Args("--out") ?? "ideal-schema-report.json";

if (string.IsNullOrWhiteSpace(connString))
{
    Console.Error.WriteLine("خطا: Connection String لازم است.");
    Console.Error.WriteLine("dotnet run -- --connection \"Server=...;Database=...;User Id=...;Password=...\" [--out report.json]");
    return 2;
}

// گارد فقط-خواندنی در سطح ابزار — هر SELECT فقط با شروع SELECT مجاز است
static void AssertReadOnly(string sql)
{
    var t = sql.Trim();
    if (!Regex.IsMatch(t, @"\A(SELECT|WITH)\b", RegexOptions.IgnoreCase))
        throw new InvalidOperationException("ABORT: non-SELECT command blocked: " + t[..Math.Min(60, t.Length)]);
    if (Regex.IsMatch(t, @"\b(INSERT|UPDATE|DELETE|MERGE|TRUNCATE|ALTER|DROP|CREATE|GRANT|BACKUP|RESTORE|DBCC)\b", RegexOptions.IgnoreCase))
        throw new InvalidOperationException("ABORT: mutation keyword blocked");
    if (t.Contains(';')) throw new InvalidOperationException("ABORT: batch blocked");
}

var report = new Dictionary<string, object?>
{
    ["generatedAt"] = DateTimeOffset.UtcNow,
    ["tool"] = "IdeaSchemaDump v1.0 (read-only)",
};

await using var con = new SqlConnection(connString);
try
{
    await con.OpenAsync();
}
catch (Exception ex)
{
    Console.Error.WriteLine("خطای اتصال: " + ex.GetType().Name + " — " + ex.Message);
    return 1;
}
Console.WriteLine($"متصل: {con.DataSource} / {con.Database}");

async Task<DataTable> Query(string sql)
{
    AssertReadOnly(sql);
    await using var cmd = con.CreateCommand();
    cmd.CommandText = sql;
    var dt = new DataTable();
    using var r = await cmd.ExecuteReaderAsync();
    dt.Load(r);
    return dt;
}

// ── ۱. اطلاعات سرور
var ver = await Query("SELECT @@SERVERNAME AS ServerName, DB_NAME() AS DbName, @@VERSION AS Version, SERVERPROPERTY('ProductVersion') AS ProductVersion");
report["server"] = new Dictionary<string, object?>
{
    ["serverName"] = ver.Rows[0]["ServerName"],
    ["database"] = ver.Rows[0]["DbName"],
    ["productVersion"] = ver.Rows[0]["ProductVersion"],
    ["fullVersion"] = (ver.Rows[0]["Version"] as string)?.Split('\n').FirstOrDefault()?.Trim(),
};

// ── ۲. جداول و ستون‌ها (فقط dbo)
var tables = await Query(@"
SELECT t.name AS TableName, c.column_id, c.name AS ColumnName, ty.name AS TypeName,
       c.max_length, c.is_nullable, c.is_identity
FROM sys.tables t
JOIN sys.columns c ON c.object_id = t.object_id
JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE t.schema_id = 1
ORDER BY t.name, c.column_id");

var tablesMap = new Dictionary<string, List<Dictionary<string, object?>>>();
foreach (DataRow row in tables.Rows)
{
    var tname = (string)row["TableName"];
    if (!tablesMap.TryGetValue(tname, out var cols)) tablesMap[tname] = cols = new();
    cols.Add(new Dictionary<string, object?>
    {
        ["name"] = row["ColumnName"],
        ["type"] = row["TypeName"],
        ["maxLength"] = row["max_length"],
        ["nullable"] = row["is_nullable"],
        ["identity"] = row["is_identity"],
    });
}
report["tables"] = tablesMap;
Console.WriteLine($"جداول: {tablesMap.Count}");

// ── ۳. کلیدهای اصلی و خارجی
var fks = await Query(@"
SELECT tp.name AS ParentTable, cp.name AS ParentColumn, tr.name AS ReferencedTable, cr.name AS ReferencedColumn
FROM sys.foreign_keys fk
JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
JOIN sys.tables tp ON tp.object_id = fkc.parent_object_id
JOIN sys.columns cp ON cp.object_id = fkc.parent_object_id AND cp.column_id = fkc.parent_column_id
JOIN sys.tables tr ON tr.object_id = fkc.referenced_object_id
JOIN sys.columns cr ON cr.object_id = fkc.referenced_object_id AND cr.column_id = fkc.referenced_column_id
WHERE fk.schema_id = 1
ORDER BY tp.name");
var fkList = (from DataRow r in fks.Rows
              select new Dictionary<string, object?>
              {
                  ["table"] = r["ParentTable"], ["column"] = r["ParentColumn"],
                  ["referencesTable"] = r["ReferencedTable"], ["referencesColumn"] = r["ReferencedColumn"],
              }).ToList();
report["foreignKeys"] = fkList;
Console.WriteLine($"کلیدهای خارجی: {fkList.Count}");

// ── ۴. SPها و پارامترها
var sps = await Query(@"
SELECT p.name AS SpName, pr.name AS ParamName, ty.name AS TypeName, pr.parameter_id
FROM sys.procedures p
LEFT JOIN sys.parameters pr ON pr.object_id = p.object_id AND pr.is_output = 0
JOIN sys.types ty ON ty.user_type_id = pr.user_type_id
WHERE p.schema_id = 1
ORDER BY p.name, pr.parameter_id");
var spMap = new Dictionary<string, List<string>>();
foreach (DataRow r in sps.Rows)
{
    var name = (string)r["SpName"];
    if (!spMap.TryGetValue(name, out var plist)) spMap[name] = plist = new();
    if (r["ParamName"] != DBNull.Value) plist.Add($"{r["ParamName"]}:{r["TypeName"]}");
}
report["storedProcedures"] = spMap;
Console.WriteLine($"SPها: {spMap.Count}");

// ── ۵. مقایسه با انتظارات IdealBridge (جدول‌های موردنیاز)
var expectedTables = new Dictionary<string, string[]>
{
    ["CrmCompany"] = new[] { "CompanyID", "cmpNumber", "cmpCode", "cmpName", "cmpTitleId", "cmpGroupId", "cmpTel", "cmpMobile", "cmpCountryId", "cmpProvinceId", "cmpCityId", "cmpAddress", "cmpEmail", "cmpWebSite", "RegisterDate", "UserId", "cmpReferUserId", "cmpIsDraft", "cmpKind", "cmpMainPersonId", "FirstRegisterDate", "ImportDateTime", "cmpCoordinateLatitude", "cmpCoordinateLongitude" },
    ["CrmCompanyPersons"] = new[] { "CompanyPersonID", "prsCompanyId", "prsFName", "prsLName", "prsTitleId", "prsMobile", "prsEmail", "prsTel", "prsCountryId", "prsProvinceId", "prsCityId", "prsAddress", "prsNationalCode", "prsWorkingOut" },
    ["Users"] = new[] { "UserId", "FName", "LName", "UserName", "IsAdmin", "IsActive", "UserIsActiveInWebApp", "Mobile" },
    ["CrmConversation"] = new[] { "ConversationID", "cnvsCompanyId", "cnvsProjectId", "cnvsDateTime", "cnvsSubject", "cnvsUserId", "cnvsStatusId" },
    ["CrmProjects"] = new[] { "ProjectID", "prjCompanyId", "prjTitle", "prjIsFinished", "RegisterDate" },
    ["CrmUserTasks"] = new[] { "UserTaskId", "UserTaskTitle", "UserId", "UserTaskDate", "UserTaskDidIt" },
    ["WsWareHouse"] = new[] { "WareHouseID", "WrhsName", "WrhsCode", "WrhsDeActive" },
    ["WSProducts"] = new[] { "ProductID", "PrdGroupID", "PrdCode", "PrdName", "PrdInActive" },
    ["WSOrder"] = new[] { "OrderID", "ordNumber", "ordCompanyId", "ordIsVerified", "ordTotalAmount" },
    ["WSPreOrder"] = new[] { "PreOrderID", "pordNumber", "pordCompanyId", "pordIsVerified", "pordTotalAmount" },
    ["CrmCompanyAddresses"] = new[] { "CompanyAddressId", "cmpaddCompanyId", "CompanyAddress" },
};
var expectedSps = new[]
{
    "ApispSelectCompany", "ApispSelectCompanyPersons", "ApispSelectUsers", "ApispSelectConversation",
    "ApispSelectProjects", "ApispSelectWareHouse", "ApispSelectProducts", "ApispSelectOrder", "ApispSelectPreOrder",
};

var compat = new Dictionary<string, object?>
{
    ["missingTables"] = expectedTables.Keys.Where(t => !tablesMap.ContainsKey(t)).ToList(),
    ["missingColumns"] = expectedTables.Where(t => tablesMap.ContainsKey(t.Key))
        .ToDictionary(t => t.Key, t => t.Value.Where(c => !tablesMap[t.Key].Any(x => (string)x["name"]! == c)).ToList()),
    ["expectedSpPresence"] = expectedSps.ToDictionary(s => s, s => spMap.ContainsKey(s)),
    ["spSignatures"] = expectedSps.Where(s => spMap.ContainsKey(s)).ToDictionary(s => s, s => spMap[s]),
};
report["idealBridgeCompatibility"] = compat;

var missingTables = (List<string>)compat["missingTables"]!;
var missingCols = (Dictionary<string, List<string>>)compat["missingColumns"]!;
var missingSp = expectedSps.Where(s => !spMap.ContainsKey(s)).ToList();
Console.WriteLine();
Console.WriteLine("═══ مقایسه با انتظارات IdealBridge ═══");
Console.WriteLine(missingTables.Count == 0
    ? "✔ همهٔ جدول‌های موردانتظار موجودند"
    : "✖ جداول مفقود: " + string.Join(", ", missingTables));
foreach (var (t, cols) in missingCols)
    if (cols.Count > 0) Console.WriteLine($"△ {t}: ستون‌های مفقود: {string.Join(", ", cols)}");
Console.WriteLine(missingSp.Count == 0
    ? "✔ همهٔ SPهای موردانتظار موجودند"
    : "△ SPهای ناموجود: " + string.Join(", ", missingSp));

// ── خروجی JSON
var json = JsonSerializer.Serialize(report, new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
});
await File.WriteAllTextAsync(outFile, json);
Console.WriteLine();
Console.WriteLine($"گزارش کامل در «{Path.GetFullPath(outFile)}» ذخیره شد.");
return 0;

static string? Args(string name)
{
    for (var i = 0; i < Environment.GetCommandLineArgs().Length - 1; i++)
        if (Environment.GetCommandLineArgs()[i] == name)
            return Environment.GetCommandLineArgs()[i + 1];
    return null;
}
