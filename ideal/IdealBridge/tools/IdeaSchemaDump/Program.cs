// ═══════════════════════════════════════════════════════════════
// IdeaSchemaDump v2.1 — ابزار مستقل استخراج فرادادهٔ دیتابیس Ideal CRM
// ───────────────────────────────────────────────────────────────
// فقط-خواندنی: تمام کوئری‌ها SELECT روی sys.* / OBJECT_DEFINITION هستند.
// از فاز ۱۱ توکنایزر ReadOnlyCommandGuard مشترک با IdealBridge استفاده می‌کند
// (یک قاعدهٔ اعتبارسنجی واحد) و هیچ SP اجرا نمی‌شود — فقط فراداده/متن تعریف.
//
// فاز ۱۱.۱ — سیاست امنیتی اتصال (SchemaDumpPolicy):
//  - Connection String فقط از متغیر محیطی IdealBridge__ConnectionString؛
//    دریافت از خط فرمان (به هر شکل) ممنوع و صریحاً رد می‌شود (افشای رمز در
//    Process Arguments/تاریخچهٔ ترمینال)؛
//  - ApplicationIntent=ReadOnly و Encrypt=true در خود ابزار اجباری؛
//  - هیچ Connection String/رمز/Secret در پیام خطا یا لاگ بازتاب نمی‌شود.
//
// خروجی: JSON ساختاریافته با زمان استخراج و نسخهٔ SQL Server — قابل مقایسه
// بین دو نسخهٔ دیتابیس با «حالت مقایسه» (نیازی به اتصال ندارد).
//
// اجرا (استخراج) — تنظیم امن در PowerShell:
//   [Environment]::SetEnvironmentVariable('IdealBridge__ConnectionString', 'Server=...;Database=...;User Id=...;Password=...;', 'User')
//   dotnet run --project tools/IdeaSchemaDump -- --out report.json
//   (معادل CMD:  setx IdealBridge__ConnectionString "Server=...;Database=...;..."  — سپس پنجرهٔ جدید)
// اجرا (مقایسهٔ دو گزارش — بدون اتصال):
//   dotnet run --project tools/IdeaSchemaDump -- --compare baseline.json current.json [--out diff.json]
// ═══════════════════════════════════════════════════════════════

using System.Data;
using System.Text.Encodings.Web;
using System.Text.Json;
using IdeaSchemaDump;   // SchemaDumpPolicy — سیاست امنیتی فاز ۱۱.۱
using IdealBridge.Infrastructure.Database;
using Microsoft.Data.SqlClient;

// فاز ۱۱.۱: اعتبارسنجی آرگومان‌ها «پیش از» هر کاری — هیچ مسیر دورزدن سیاست اتصال باقی نماند
var allArgs = Environment.GetCommandLineArgs().Skip(1).ToArray();
try
{
    SchemaDumpPolicy.ValidateArguments(allArgs);
}
catch (SchemaDumpPolicyException pex)
{
    Console.Error.WriteLine("خطا: " + pex.Message);
    return 2;
}

var outFile = Args("--out");
var compareArgs = ArgsValues("--compare");   // دو فایل: baseline + current

// ─────────── حالت مقایسه (بدون اتصال) ───────────
if (compareArgs.Count >= 2)
{
    return IdeaSchemaDump.SchemaDumpCompare.Run(compareArgs[0], compareArgs[1], outFile ?? "ideal-schema-diff.json");
}
if (compareArgs.Count == 1)
{
    Console.Error.WriteLine("خطا: حالت مقایسه دو فایل می‌خواهد: --compare baseline.json current.json");
    return 2;
}

// ─────────── حالت استخراج — اتصال فقط از متغیر محیطی (فاز ۱۱.۱) ───────────
SqlConnectionStringBuilder connectionBuilder;
try
{
    connectionBuilder = SchemaDumpPolicy.ResolveConnection();
}
catch (SchemaDumpPolicyException pex)
{
    Console.Error.WriteLine("خطا: " + pex.Message);
    return 2;
}
outFile ??= "ideal-schema-report.json";

var report = new Dictionary<string, object?>
{
    ["generatedAt"] = DateTimeOffset.UtcNow,
    ["tool"] = "IdeaSchemaDump v2.1 (read-only; env-var connection; shared guard with IdealBridge)",
};

await using var con = new SqlConnection(connectionBuilder.ConnectionString);
try
{
    await con.OpenAsync();
}
catch (Exception ex)
{
    var (kind, safe) = SqlConnectionErrorClassifier.Classify(ex);
    Console.Error.WriteLine($"خطای اتصال ({kind}): {safe}");
    Console.Error.WriteLine("جزئیات فنی: " + ex.GetType().Name);
    return 1;
}
Console.WriteLine($"متصل: {SecretRedactor.Redact(con.DataSource)} / {con.Database}");

async Task<DataTable> Query(string sql)
{
    // گارد مشترک — همان قاعدهٔ سرویس اصلی: فقط SELECT/WITH تک‌دستوری؛ هیچ EXEC و هیچ SP
    ReadOnlyCommandGuard.Validate(sql, CommandType.Text);
    await using var cmd = con.CreateCommand();
    cmd.CommandText = sql;
    cmd.CommandTimeout = 60;
    var dt = new DataTable();
    using var r = await cmd.ExecuteReaderAsync();
    dt.Load(r);
    return dt;
}

// ── ۱. اطلاعات سرور
var ver = await Query("SELECT @@SERVERNAME AS ServerName, DB_NAME() AS DbName, @@VERSION AS Version, SERVERPROPERTY('ProductVersion') AS ProductVersion, SERVERPROPERTY('ProductLevel') AS ProductLevel, SERVERPROPERTY('Edition') AS Edition");
report["server"] = new Dictionary<string, object?>
{
    ["serverName"] = ver.Rows[0]["ServerName"],
    ["database"] = ver.Rows[0]["DbName"],
    ["productVersion"] = ver.Rows[0]["ProductVersion"],
    ["productLevel"] = ver.Rows[0]["ProductLevel"],
    ["edition"] = ver.Rows[0]["Edition"],
    ["fullVersion"] = (ver.Rows[0]["Version"] as string)?.Split('\n').FirstOrDefault()?.Trim(),
};

// ── ۲. جداول و ستون‌ها (نوع داده/Nullability/Identity/Precision/Scale)
var tables = await Query(@"
SELECT t.name AS TableName, c.column_id, c.name AS ColumnName, ty.name AS TypeName,
       c.max_length, c.precision, c.scale, c.is_nullable, c.is_identity, c.is_computed
FROM sys.tables t
JOIN sys.columns c ON c.object_id = t.object_id
JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE t.schema_id = 1
ORDER BY t.name, c.column_id");

var tablesMap = new Dictionary<string, List<Dictionary<string, object?>>>(StringComparer.OrdinalIgnoreCase);
var identityColumns = new List<Dictionary<string, object?>>();
foreach (DataRow row in tables.Rows)
{
    var tname = (string)row["TableName"];
    if (!tablesMap.TryGetValue(tname, out var cols)) tablesMap[tname] = cols = new();
    cols.Add(new Dictionary<string, object?>
    {
        ["name"] = row["ColumnName"],
        ["type"] = row["TypeName"],
        ["maxLength"] = row["max_length"],
        ["precision"] = row["precision"],
        ["scale"] = row["scale"],
        ["nullable"] = row["is_nullable"],
        ["identity"] = row["is_identity"],
        ["computed"] = row["is_computed"],
    });
    if ((bool)row["is_identity"])
        identityColumns.Add(new Dictionary<string, object?> { ["table"] = tname, ["column"] = row["ColumnName"] });
}
report["tables"] = tablesMap;
report["identityColumns"] = identityColumns;
Console.WriteLine($"جداول: {tablesMap.Count} — ستون‌های Identity: {identityColumns.Count}");

// ── ۳. کلیدهای اصلی
var pks = await Query(@"
SELECT t.name AS TableName, c.name AS ColumnName, ic.key_ordinal
FROM sys.key_constraints kc
JOIN sys.tables t ON t.object_id = kc.parent_object_id
JOIN sys.index_columns ic ON ic.object_id = t.object_id AND ic.index_id = kc.unique_index_id
JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = ic.column_id
WHERE kc.type = 'PK' AND t.schema_id = 1
ORDER BY t.name, ic.key_ordinal");
var pkMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in pks.Rows)
{
    var t = (string)r["TableName"];
    if (!pkMap.TryGetValue(t, out var list)) pkMap[t] = list = new();
    list.Add((string)r["ColumnName"]);
}
report["primaryKeys"] = pkMap;
Console.WriteLine($"کلیدهای اصلی: {pkMap.Count}");

// ── ۴. کلیدهای خارجی (با نام Constraint)
var fks = await Query(@"
SELECT fk.name AS ConstraintName, tp.name AS ParentTable, cp.name AS ParentColumn,
       tr.name AS ReferencedTable, cr.name AS ReferencedColumn
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
                  ["constraint"] = r["ConstraintName"],
                  ["table"] = r["ParentTable"], ["column"] = r["ParentColumn"],
                  ["referencesTable"] = r["ReferencedTable"], ["referencesColumn"] = r["ReferencedColumn"],
              }).ToList();
report["foreignKeys"] = fkList;
Console.WriteLine($"کلیدهای خارجی: {fkList.Count}");

// ── ۵. ایندکس‌ها (نوع/یکتا/PK/ستون‌ها)
var idx = await Query(@"
SELECT t.name AS TableName, i.name AS IndexName, i.type_desc, i.is_unique, i.is_primary_key,
       c.name AS ColumnName, ic.key_ordinal, ic.is_included_column
FROM sys.indexes i
JOIN sys.tables t ON t.object_id = i.object_id
JOIN sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id
JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = ic.column_id
WHERE t.schema_id = 1 AND i.name IS NOT NULL
ORDER BY t.name, i.name, ic.key_ordinal");
var idxMap = new Dictionary<string, List<Dictionary<string, object?>>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in idx.Rows)
{
    var t = (string)r["TableName"];
    if (!idxMap.TryGetValue(t, out var list)) idxMap[t] = list = new();
    var name = (string)r["IndexName"];
    var entry = list.FirstOrDefault(x => (string)x["name"]! == name);
    if (entry == null)
    {
        entry = new Dictionary<string, object?>
        {
            ["name"] = name,
            ["type"] = r["type_desc"],
            ["isUnique"] = r["is_unique"],
            ["isPrimaryKey"] = r["is_primary_key"],
            ["columns"] = new List<string>(),
            ["includedColumns"] = new List<string>(),
        };
        list.Add(entry);
    }
    if ((bool)r["is_included_column"]) ((List<string>)entry["includedColumns"]!).Add((string)r["ColumnName"]);
    else ((List<string>)entry["columns"]!).Add((string)r["ColumnName"]);
}
report["indexes"] = idxMap;
Console.WriteLine($"جداول دارای ایندکس: {idxMap.Count}");

// ── ۶. ویوها (ستون‌ها + متن تعریف در صورت مجوز)
var views = await Query(@"
SELECT v.name AS ViewName, c.name AS ColumnName
FROM sys.views v
JOIN sys.columns c ON c.object_id = v.object_id
WHERE v.schema_id = 1
ORDER BY v.name, c.column_id");
var viewMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in views.Rows)
{
    var v = (string)r["ViewName"];
    if (!viewMap.TryGetValue(v, out var list)) viewMap[v] = list = new();
    list.Add((string)r["ColumnName"]);
}
var viewDefinitions = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
var defs = await Query(@"
SELECT v.name AS ViewName, sm.definition AS Definition
FROM sys.views v
LEFT JOIN sys.sql_modules sm ON sm.object_id = v.object_id
WHERE v.schema_id = 1
ORDER BY v.name");
foreach (DataRow r in defs.Rows)
    viewDefinitions[(string)r["ViewName"]] = r["Definition"] is DBNull ? "«بدون مجوز VIEW DEFINITION — متن در دسترس نیست»" : r["Definition"];
report["views"] = viewMap;
report["viewDefinitions"] = viewDefinitions;
Console.WriteLine($"ویوها: {viewMap.Count}");

// ── ۷. Stored Procedureها — فقط فراداده + متن تعریف؛ هرگز اجرا نمی‌شوند
var sps = await Query(@"
SELECT p.name AS SpName, pr.name AS ParamName, ty.name AS TypeName, pr.max_length, pr.is_output, pr.parameter_id
FROM sys.procedures p
LEFT JOIN sys.parameters pr ON pr.object_id = p.object_id
LEFT JOIN sys.types ty ON ty.user_type_id = pr.user_type_id
WHERE p.schema_id = 1
ORDER BY p.name, pr.parameter_id");
var spMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in sps.Rows)
{
    var name = (string)r["SpName"];
    if (!spMap.TryGetValue(name, out var plist)) spMap[name] = plist = new();
    if (r["ParamName"] != DBNull.Value)
        plist.Add($"{r["ParamName"]}:{r["TypeName"]}{((bool)r["is_output"] ? " (output)" : "")}");
}
var spDefinitions = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
var spDefs = await Query(@"
SELECT p.name AS SpName, sm.definition AS Definition
FROM sys.procedures p
LEFT JOIN sys.sql_modules sm ON sm.object_id = p.object_id
WHERE p.schema_id = 1
ORDER BY p.name");
foreach (DataRow r in spDefs.Rows)
    spDefinitions[(string)r["SpName"]] = r["Definition"] is DBNull ? "«بدون مجوز VIEW DEFINITION — متن در دسترس نیست»" : r["Definition"];
report["storedProcedures"] = spMap;
report["storedProcedureDefinitions"] = spDefinitions;
Console.WriteLine($"SPها: {spMap.Count} (فقط فراداده و متن تعریف — اجرا نشدند)");

// ── ۸. Default Constraintها
var dcs = await Query(@"
SELECT t.name AS TableName, c.name AS ColumnName, dc.name AS ConstraintName, dc.definition
FROM sys.default_constraints dc
JOIN sys.tables t ON t.object_id = dc.parent_object_id
JOIN sys.columns c ON c.object_id = dc.parent_object_id AND c.column_id = dc.parent_column_id
WHERE t.schema_id = 1
ORDER BY t.name");
var dcList = (from DataRow r in dcs.Rows
              select new Dictionary<string, object?>
              {
                  ["table"] = r["TableName"], ["column"] = r["ColumnName"],
                  ["constraint"] = r["ConstraintName"], ["definition"] = r["definition"],
              }).ToList();
report["defaultConstraints"] = dcList;
Console.WriteLine($"Default Constraintها: {dcList.Count}");

// ── ۹. مقایسه با انتظارات IdealBridge (جدول‌های موردنیاز)
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
    ["note"] = "اجرای SP در IdealBridge غیرفعال است؛ موجودی/امضای SPها فقط برای گزارش سازگاری نسخه استخراج می‌شود.",
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
    ? "✔ همهٔ SPهای موردانتظار موجودند (اجرای‌شان در IdealBridge غیرفعال است)"
    : "△ SPهای ناموجود: " + string.Join(", ", missingSp));

// ── خروجی JSON — بدون هیچ اطلاعات اتصال
var json = JsonSerializer.Serialize(report, new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
});
await File.WriteAllTextAsync(outFile, json);
Console.WriteLine();
Console.WriteLine($"گزارش کامل در «{Path.GetFullPath(outFile)}» ذخیره شد.");
Console.WriteLine("مقایسهٔ دو گزارش: dotnet run -- --compare baseline.json current.json");
return 0;

// ─────────── کمکی‌ها ───────────
static string? Args(string name)
{
    var argv = Environment.GetCommandLineArgs();
    for (var i = 0; i < argv.Length - 1; i++)
        if (argv[i] == name) return argv[i + 1];
    return null;
}

static List<string> ArgsValues(string name)
{
    var argv = Environment.GetCommandLineArgs();
    var values = new List<string>();
    for (var i = 0; i < argv.Length; i++)
    {
        if (argv[i] == name)
        {
            for (var j = i + 1; j < argv.Length && !argv[j].StartsWith("--"); j++)
                values.Add(argv[j]);
        }
    }
    return values;
}
