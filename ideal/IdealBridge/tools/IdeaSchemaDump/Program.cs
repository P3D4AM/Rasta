// ═══════════════════════════════════════════════════════════════
// IdeaSchemaDump v3.0 — استخراج فرادادهٔ زندهٔ دیتابیس Ideal CRM
// ───────────────────────────────────────────────────────────────
// فاز ۱۲.۵ — Live Database Forensics (بازنویسی کامل از v2.1)
//
// سیاست‌های این نسخه (تفکیک‌شده از سرویس IdealBridge):
//  ۱) Connection String «فقط» از متغیر محیطی IdeaSchemaDump__ConnectionString؛
//     سرویس API متغیر جداگانهٔ IdealBridge__ConnectionString را می‌خواند —
//     دو منبع مستقل که هرگز با هم اشتباه نمی‌شوند (SchemaDumpPolicy).
//  ۲) همهٔ کوئری‌ها فقط روی نمای‌های کاتالوگ sys.* هستند — «صفر» خواندن
//     جدول/ویوی کسب‌وکار و صفر خواندن دادهٔ واقعی. هیچ متن تعریف ماژول
//     (sys.sql_modules / OBJECT_DEFINITION) خوانده نمی‌شود؛ ویوها فقط
//     «نام + ستون»، SPها فقط «نام + امضای پارامتر»، توابع فقط «نام +
//     امضا»، تریگرها فقط «نام + والد + رویداد».
//  ۳) همهٔ Schemaهای قابل‌مشاهده پوشش داده می‌شوند (نه فقط dbo) —
//     هیچ محدودیت schema_id = 1 وجود ندارد.
//  ۴) همهٔ کوئری‌ها از ReadOnlyCommandGuard مشترک با سرویس می‌گذرند
//     (SELECT تک‌دستوری) — همان قاعدهٔ واحد، پیش از ارسال به سرور.
//  ۵) ApplicationIntent=ReadOnly + Encrypt=true + ApplicationName=
//     IdeaSchemaDump به‌اجبار در خود ابزار اعمال می‌شود.
//  ۶) کوئری‌های «مکمل» نسخه‌محور (Temporal/Generated Always/Memory-
//     Optimized/Change Tracking/فیلتر ایندکس) در صورت نبودن روی سرور
//     با «هشدار استخراج» ثبت می‌شوند — هرگز مقدار ساختگی نمی‌سازیم.
//  ۷) خروجی: JSON نسخه‌دار ideal-live-schema-report.json با ۲۵+ بلوک؛
//     بدون هیچ Secret/Connection String و بدون هیچ دادهٔ کسب‌وکار.
//     این فایل هرگز وارد Git نمی‌شود (gitignore).
//
// لیست کامل SQL در LiveSchemaSql.cs — تست‌های امنیتی ساختاری
// (LiveSchemaSqlSecurityTests) روی همان فهرست اجرا می‌شوند.
//
// اجرا (استخراج) — تنظیم امن در PowerShell:
//   [Environment]::SetEnvironmentVariable('IdeaSchemaDump__ConnectionString', 'Server=...;Database=crmideal;User Id=ibk_schema_reader;Password=...;', 'User')
//   IdeaSchemaDump.exe --out ideal-live-schema-report.json
//   (معادل CMD:  setx IdeaSchemaDump__ConnectionString "Server=...;..." — سپس پنجرهٔ جدید)
// اجرا (مقایسهٔ دو گزارش — بدون اتصال):
//   IdeaSchemaDump.exe --compare baseline.json current.json [--out diff.json]
// ═══════════════════════════════════════════════════════════════

using System.Data;
using System.Text.Encodings.Web;
using System.Text.Json;
using IdeaSchemaDump;                                  // SchemaDumpPolicy + LiveSchemaSql
using IdealBridge.Infrastructure.Database;             // ReadOnlyCommandGuard + SqlConnectionErrorClassifier + SecretRedactor
using Microsoft.Data.SqlClient;

// اعتبارسنجی آرگومان‌ها «پیش از» هر کاری — هیچ مسیر دورزدن سیاست اتصال باقی نماند
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

// ─────────── حالت استخراج — اتصال فقط از متغیر محیطی اختصاصی ابزار ───────────
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
outFile ??= "ideal-live-schema-report.json";

var warnings = new List<Dictionary<string, object?>>();

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
Console.WriteLine($"متصل (فقط-خواندنی/رمزنگاری‌شده): {SecretRedactor.Redact(con.DataSource)} / {con.Database}");
Console.WriteLine("حساب ابزار: بدون هیچ SELECT روی جدول کسب‌وکار — فقط فرادادهٔ کاتالوگ.");

async Task<DataTable> Query(string sql)
{
    // گارد مشترک — همان قاعدهٔ سرویس اصلی: فقط SELECT/WITH تک‌دستوری
    ReadOnlyCommandGuard.Validate(sql, CommandType.Text);
    await using var cmd = con.CreateCommand();
    cmd.CommandText = sql;
    cmd.CommandTimeout = 60;
    var dt = new DataTable();
    using var r = await cmd.ExecuteReaderAsync();
    dt.Load(r);
    return dt;
}

// کوئری مکمل نسخه‌محور — شکست = «هشدار استخراج» (هرگز مقدار ساختگی)
async Task<DataTable?> TryQuery(string key, string sql)
{
    try
    {
        return await Query(sql);
    }
    catch (Exception ex)
    {
        warnings.Add(new Dictionary<string, object?>
        {
            ["block"] = key,
            ["message"] = $"فراداده در دسترس نیست: {ex.GetType().Name}: {FirstLine(ex.Message)}",
        });
        return null;
    }
}

static string FirstLine(string s)
{
    var i = s.IndexOf('\n');
    return (i < 0 ? s : s[..i]).Trim();
}
static object? V(DataRow r, string col) => r[col] is DBNull ? null : r[col];

// ═══ ۱) سرور و دیتابیس — محیط غیرحساس (بدون @@VERSION کامل) ═══
var serverRow = (await Query(LiveSchemaSql.ServerInfo)).Rows[0];
var dbRows = await Query(LiveSchemaSql.DatabaseInfo);
var dbRow = dbRows.Rows.Count > 0 ? dbRows.Rows[0] : null;
if (dbRow is null)
    warnings.Add(new Dictionary<string, object?> { ["block"] = "database", ["message"] = "ردیف دیتابیس جاری در sys.databases یافت نشد." });

var report = new Dictionary<string, object?>
{
    // ریشهٔ سازگار با حالت مقایسه (SchemaDumpCompare) + بلوک کامل metadata
    ["generatedAt"] = DateTimeOffset.UtcNow,
    ["tool"] = "IdeaSchemaDump v3.0 (live metadata only; all-schemas; no module definitions; shared guard with IdealBridge)",
    ["metadata"] = new Dictionary<string, object?>
    {
        ["tool"] = "IdeaSchemaDump",
        ["toolVersion"] = "3.0",
        ["phase"] = "12.5 — Live Database Forensics",
        ["generatedAt"] = DateTimeOffset.UtcNow,
        ["connection"] = new Dictionary<string, object?>
        {
            ["source"] = "environment variable IdeaSchemaDump__ConnectionString (never command line)",
            ["applicationName"] = "IdeaSchemaDump",
            ["applicationIntent"] = "ReadOnly",
            ["encryption"] = "Mandatory",
            ["note"] = "مستقل از IdealBridge__ConnectionString که فقط سرویس API می‌خواند؛ مقدار هرگز در گزارش بازتاب نمی‌شود.",
        },
        ["policy"] = new Dictionary<string, object?>
        {
            ["moduleDefinitionsExported"] = false,
            ["businessDataRead"] = false,
            ["businessTableSelect"] = false,
            ["allSchemasCovered"] = true,
            ["rowCountsExtracted"] = false,
            ["guard"] = "ReadOnlyCommandGuard shared with IdealBridge service",
        },
    },
    ["sqlServer"] = new Dictionary<string, object?>
    {
        ["serverName"] = V(serverRow, "ServerName"),
        ["productVersion"] = V(serverRow, "ProductVersion"),
        ["productMajorVersion"] = V(serverRow, "ProductMajorVersion"),
        ["productLevel"] = V(serverRow, "ProductLevel"),
        ["edition"] = V(serverRow, "Edition"),
        ["engineEdition"] = V(serverRow, "EngineEdition"),
        ["serverCollation"] = V(serverRow, "ServerCollation"),
        ["note"] = "بدون متن کامل @@VERSION (سیاست فاز ۱۲.۵ §۵) — فقط SERVERPROPERTY.",
    },
    ["database"] = new Dictionary<string, object?>
    {
        ["name"] = dbRow is null ? null : V(dbRow, "DatabaseName"),
        ["compatibilityLevel"] = dbRow is null ? null : V(dbRow, "CompatibilityLevel"),
        ["collation"] = dbRow is null ? null : V(dbRow, "Collation"),
        ["recoveryModel"] = dbRow is null ? null : V(dbRow, "RecoveryModel"),
        ["isReadOnly"] = dbRow is null ? null : V(dbRow, "IsReadOnly"),
        ["state"] = dbRow is null ? null : V(dbRow, "State"),
        ["snapshotIsolation"] = dbRow is null ? null : V(dbRow, "SnapshotIsolation"),
        ["readCommittedSnapshot"] = dbRow is null ? null : V(dbRow, "ReadCommittedSnapshot"),
        ["logReuseWait"] = dbRow is null ? null : V(dbRow, "LogReuseWait"),
        ["isCdcEnabled"] = dbRow is null ? null : V(dbRow, "IsCdcEnabled"),
    },
};

// ═══ ۲) همهٔ Schemaها ═══
var schemaRows = await Query(LiveSchemaSql.Schemas);
var schemaList = (from DataRow r in schemaRows.Rows
                  select new Dictionary<string, object?> { ["id"] = V(r, "schema_id"), ["name"] = V(r, "SchemaName") })
                 .ToList();
report["schemas"] = schemaList;
Console.WriteLine($"Schemaها: {schemaList.Count} (همه — نه فقط dbo)");

// ═══ ۳) جدول‌ها (نقشهٔ object_id → کلید «schema.table») + پرچم‌های همگام‌سازی ═══
var tableRows = await Query(LiveSchemaSql.Tables);
var objectIdToKey = new Dictionary<long, string>();
var tableFlags = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in tableRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["TableName"]}";
    objectIdToKey[Convert.ToInt64(r["object_id"])] = key;
    tableFlags[key] = new Dictionary<string, object?>
    {
        ["replicated"] = V(r, "is_replicated"),
        ["hasReplicationFilter"] = V(r, "has_replication_filter"),
        ["mergePublished"] = V(r, "is_merge_published"),
        ["syncTranSubscribed"] = V(r, "is_sync_tran_subscribed"),
        ["createDate"] = V(r, "create_date"),
        ["modifyDate"] = V(r, "modify_date"),
    };
}
report["tableFlags"] = tableFlags;

// ═══ ۴) ستون‌ها — همهٔ Schemaها ═══
var columnRows = await Query(LiveSchemaSql.Columns);
var tablesMap = new Dictionary<string, List<Dictionary<string, object?>>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in columnRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["TableName"]}";
    if (!tablesMap.TryGetValue(key, out var cols)) tablesMap[key] = cols = new();
    cols.Add(new Dictionary<string, object?>
    {
        ["name"] = V(r, "ColumnName"),
        ["type"] = V(r, "TypeName"),
        ["maxLength"] = V(r, "max_length"),
        ["precision"] = V(r, "precision"),
        ["scale"] = V(r, "scale"),
        ["collation"] = V(r, "collation_name"),
        ["nullable"] = V(r, "is_nullable"),
        ["identity"] = V(r, "is_identity"),
        ["computed"] = V(r, "is_computed"),
        ["sparse"] = V(r, "is_sparse"),
    });
}
report["tables"] = tablesMap;
Console.WriteLine($"جداول: {tablesMap.Count} — مجموع ستون‌ها: {columnRows.Rows.Count}");

// ═══ ۵) کلیدهای اصلی ═══
var pkRows = await Query(LiveSchemaSql.PrimaryKeys);
var pkMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in pkRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["TableName"]}";
    if (!pkMap.TryGetValue(key, out var list)) pkMap[key] = list = new();
    list.Add((string)r["ColumnName"]);
}
report["primaryKeys"] = pkMap;
Console.WriteLine($"جداول دارای PK: {pkMap.Count}");

// ═══ ۶) کلیدهای خارجی — کامل (onDelete/onUpdate/Disabled/NotTrusted) ═══
var fkRows = await Query(LiveSchemaSql.ForeignKeys);
var fkList = (from DataRow r in fkRows.Rows
              select new Dictionary<string, object?>
              {
                  ["constraint"] = V(r, "ConstraintName"),
                  ["schema"] = V(r, "ParentSchema"), ["table"] = V(r, "ParentTable"), ["column"] = V(r, "ParentColumn"),
                  ["referencesSchema"] = V(r, "ReferencedSchema"), ["referencesTable"] = V(r, "ReferencedTable"), ["referencesColumn"] = V(r, "ReferencedColumn"),
                  ["onDelete"] = V(r, "OnDelete"),
                  ["onUpdate"] = V(r, "OnUpdate"),
                  ["isDisabled"] = V(r, "IsDisabled"),
                  ["isNotTrusted"] = V(r, "IsNotTrusted"),
              }).ToList();
report["foreignKeys"] = fkList;
Console.WriteLine($"کلیدهای خارجی: {fkList.Count}");

// ═══ ۷) ایندکس‌ها — هسته + مکمل Filter/Disabled (ادغام در همان بلوک) ═══
var idxRows = await Query(LiveSchemaSql.IndexesCore);
var idxMap = new Dictionary<string, List<Dictionary<string, object?>>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in idxRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["TableName"]}";
    if (!idxMap.TryGetValue(key, out var list)) idxMap[key] = list = new();
    var name = (string)r["IndexName"];
    var entry = list.FirstOrDefault(x => (string)x["name"]! == name);
    if (entry is null)
    {
        entry = new Dictionary<string, object?>
        {
            ["name"] = name,
            ["type"] = V(r, "type_desc"),
            ["isUnique"] = V(r, "is_unique"),
            ["isPrimaryKey"] = V(r, "is_primary_key"),
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

// مکمل ۲۰۰۸+ — اگر در دسترس نبود، همین بلوک با «هشدار» خالی می‌ماند
var filterRows = await TryQuery("indexFilters", LiveSchemaSql.IndexFilters);
if (filterRows is not null)
{
    var disabledCount = 0;
    foreach (DataRow r in filterRows.Rows)
    {
        var key = $"{r["SchemaName"]}.{r["TableName"]}";
        if (!idxMap.TryGetValue(key, out var list)) continue;
        var entry = list.FirstOrDefault(x => (string)x["name"]! == (string)r["IndexName"]);
        if (entry is null) continue;
        entry["isDisabled"] = V(r, "IsDisabled");
        entry["hasFilter"] = V(r, "HasFilter");
        entry["filterDefinition"] = V(r, "FilterDefinition");
        if (V(r, "IsDisabled") is true) disabledCount++;
    }
    if (disabledCount > 0) Console.WriteLine($"ایندکس‌های Disabled: {disabledCount}");
}

// ═══ ۸) ویوها — فقط نام + ستون (بدون متن تعریف) ═══
var viewRows = await Query(LiveSchemaSql.Views);
var viewMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in viewRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["ViewName"]}";
    if (!viewMap.TryGetValue(key, out var list)) viewMap[key] = list = new();
    list.Add((string)r["ColumnName"]);
}
report["views"] = viewMap;
Console.WriteLine($"ویوها: {viewMap.Count} (فقط نام و ستون — بدون متن تعریف)");

// ═══ ۹) SPها — فقط نام + امضای پارامتر (بدون متن تعریف/اجرا) ═══
var spRows = await Query(LiveSchemaSql.StoredProcedures);
var spMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in spRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["SpName"]}";
    if (!spMap.TryGetValue(key, out var plist)) spMap[key] = plist = new();
    if (r["ParamName"] != DBNull.Value)
        plist.Add($"{r["ParamName"]}:{r["TypeName"]}{((bool)r["is_output"] ? " (output)" : "")}");
}
report["storedProcedures"] = spMap;
Console.WriteLine($"SPها: {spMap.Count} (فقط نام و امضا — بدون متن تعریف و بدون اجرا)");

// ═══ ۱۰) توابع — فقط نام + نوع + امضا (بدون متن تعریف/اجرا) ═══
var fnRows = await Query(LiveSchemaSql.Functions);
var fnMap = new Dictionary<string, Dictionary<string, object?>>(StringComparer.OrdinalIgnoreCase);
foreach (DataRow r in fnRows.Rows)
{
    var key = $"{r["SchemaName"]}.{r["FunctionName"]}";
    if (!fnMap.TryGetValue(key, out var entry))
    {
        entry = new Dictionary<string, object?>
        {
            ["type"] = V(r, "FunctionType"),
            ["typeCode"] = V(r, "FunctionTypeCode"),
            ["parameters"] = new List<Dictionary<string, object?>>(),
        };
        fnMap[key] = entry;
    }
    if (r["ParamName"] != DBNull.Value)
    {
        var pid = Convert.ToInt32(r["parameter_id"]);
        ((List<Dictionary<string, object?>>)entry["parameters"]!).Add(new Dictionary<string, object?>
        {
            ["name"] = pid == 0 ? "(return)" : V(r, "ParamName"),
            ["type"] = V(r, "TypeName"),
            ["maxLength"] = V(r, "max_length"),
            ["precision"] = V(r, "precision"),
            ["scale"] = V(r, "scale"),
            ["output"] = V(r, "is_output"),
        });
    }
}
report["functions"] = fnMap;
Console.WriteLine($"توابع: {fnMap.Count} (فقط نام و امضا — بدون متن تعریف و بدون اجرا)");

// ═══ ۱۱) تریگرها + رویدادها (بدون متن تعریف) ═══
var triggerEventRows = await TryQuery("triggerEvents", LiveSchemaSql.TriggerEvents);
var eventsByObjectId = new Dictionary<long, List<string>>();
if (triggerEventRows is not null)
    foreach (DataRow r in triggerEventRows.Rows)
    {
        var oid = Convert.ToInt64(r["object_id"]);
        if (!eventsByObjectId.TryGetValue(oid, out var evs)) eventsByObjectId[oid] = evs = new();
        var t = (string)r["EventType"];
        var grp = r["EventGroupType"];
        evs.Add(grp is null || grp is DBNull ? t : $"{t} (گروه: {grp})");
    }

var triggerRows = await TryQuery("triggers", LiveSchemaSql.Triggers);
var triggerList = new List<Dictionary<string, object?>>();
if (triggerRows is not null)
{
    foreach (DataRow r in triggerRows.Rows)
    {
        var oid = Convert.ToInt64(r["object_id"]);
        triggerList.Add(new Dictionary<string, object?>
        {
            ["schema"] = V(r, "TriggerSchema"),
            ["name"] = V(r, "TriggerName"),
            ["parentClass"] = V(r, "ParentClass"),
            ["parentSchema"] = V(r, "ParentSchema"),
            ["parentTable"] = V(r, "ParentTable"),
            ["type"] = V(r, "TriggerType"),
            ["isDisabled"] = V(r, "IsDisabled"),
            ["events"] = eventsByObjectId.TryGetValue(oid, out var evs) ? evs : new List<string>(),
        });
    }
}
report["triggers"] = triggerList;
Console.WriteLine($"تریگرها: {triggerList.Count} (فقط نام/والد/رویداد — بدون متن تعریف)");

// ═══ ۱۲) Identity (Seed/Increment — بدون last_value) ═══
var idRows = await Query(LiveSchemaSql.IdentityColumns);
var idList = (from DataRow r in idRows.Rows
              select new Dictionary<string, object?>
              {
                  ["table"] = $"{r["SchemaName"]}.{r["TableName"]}",
                  ["column"] = V(r, "ColumnName"),
                  ["seed"] = V(r, "seed_value"),
                  ["increment"] = V(r, "increment_value"),
              }).ToList();
report["identityColumns"] = idList;
Console.WriteLine($"ستون‌های Identity: {idList.Count} (بدون last_value — state زمان اجرا نیست)");

// ═══ ۱۳) ستون‌های محاسباتی (عبارت سطح-ستون) ═══
var ccRows = await Query(LiveSchemaSql.ComputedColumns);
var ccList = (from DataRow r in ccRows.Rows
              select new Dictionary<string, object?>
              {
                  ["table"] = $"{r["SchemaName"]}.{r["TableName"]}",
                  ["column"] = V(r, "ColumnName"),
                  ["expression"] = V(r, "Expression"),
                  ["isPersisted"] = V(r, "IsPersisted"),
              }).ToList();
report["computedColumns"] = ccList;
Console.WriteLine($"ستون‌های محاسباتی: {ccList.Count}");

// ═══ ۱۴) RowVersion — از نام نوع timestamp ═══
var rvRows = await Query(LiveSchemaSql.RowVersionColumns);
var rvList = (from DataRow r in rvRows.Rows
              select new Dictionary<string, object?>
              {
                  ["table"] = $"{r["SchemaName"]}.{r["TableName"]}",
                  ["column"] = V(r, "ColumnName"),
              }).ToList();
report["rowVersionColumns"] = rvList;
Console.WriteLine($"ستون‌های RowVersion: {rvList.Count} (فقط فرادادهٔ ساختار — هیچ مقدار نسخه خوانده نشد)");

// ═══ ۱۵) Default Constraintها ═══
var dcRows = await Query(LiveSchemaSql.DefaultConstraints);
var dcList = (from DataRow r in dcRows.Rows
              select new Dictionary<string, object?>
              {
                  ["table"] = $"{r["SchemaName"]}.{r["TableName"]}",
                  ["column"] = V(r, "ColumnName"),
                  ["constraint"] = V(r, "ConstraintName"),
                  ["defaultValue"] = V(r, "DefaultValue"),
              }).ToList();
report["defaultConstraints"] = dcList;
Console.WriteLine($"Default Constraintها: {dcList.Count}");

// ═══ ۱۶-مکمل) Temporal (SQL 2016+) ═══
var temporalRows = await TryQuery("temporalTables", LiveSchemaSql.TemporalTables);
var temporalList = new List<Dictionary<string, object?>>();
if (temporalRows is not null)
    foreach (DataRow r in temporalRows.Rows)
        temporalList.Add(new Dictionary<string, object?>
        {
            ["schema"] = V(r, "SchemaName"),
            ["table"] = V(r, "TableName"),
            ["temporalType"] = V(r, "TemporalType"),
            ["temporalTypeDesc"] = V(r, "TemporalTypeDesc"),
            ["historySchema"] = V(r, "HistorySchema"),
            ["historyTable"] = V(r, "HistoryTable"),
        });
report["temporalTables"] = temporalList;
Console.WriteLine($"جدول‌های Temporal: {temporalList.Count}");

// ═══ ۱۷-مکمل) Memory-Optimized (SQL 2014+) ═══
var moRows = await TryQuery("memoryOptimizedTables", LiveSchemaSql.MemoryOptimizedTables);
var moList = new List<Dictionary<string, object?>>();
if (moRows is not null)
    foreach (DataRow r in moRows.Rows)
        moList.Add(new Dictionary<string, object?> { ["schema"] = V(r, "SchemaName"), ["table"] = V(r, "TableName") });
report["memoryOptimizedTables"] = moList;

// ═══ ۱۸-مکمل) GENERATED ALWAYS (SQL 2016+) ═══
var gaRows = await TryQuery("generatedAlwaysColumns", LiveSchemaSql.GeneratedAlwaysColumns);
var gaList = new List<Dictionary<string, object?>>();
if (gaRows is not null)
    foreach (DataRow r in gaRows.Rows)
        gaList.Add(new Dictionary<string, object?>
        {
            ["table"] = $"{r["SchemaName"]}.{r["TableName"]}",
            ["column"] = V(r, "ColumnName"),
            ["generatedAlwaysType"] = V(r, "GeneratedAlwaysType"),
            ["generatedAlwaysTypeDesc"] = V(r, "GeneratedAlwaysTypeDesc"),
            ["isHidden"] = V(r, "IsHidden"),
        });
report["generatedAlwaysColumns"] = gaList;

// ═══ ۱۹) CDC — پرچم دیتابیس + اشیای schema «cdc» (بدون خواندن cdc.change_tables) ═══
var cdcEnabled = dbRow is not null && V(dbRow, "IsCdcEnabled") is true;
var cdcObjectRows = await TryQuery("cdcObjects", LiveSchemaSql.CdcObjects);
var cdcObjects = new List<Dictionary<string, object?>>();
if (cdcObjectRows is not null)
    foreach (DataRow r in cdcObjectRows.Rows)
        cdcObjects.Add(new Dictionary<string, object?>
        {
            ["name"] = V(r, "ObjectName"),
            ["type"] = V(r, "ObjectType"),
        });
report["cdc"] = new Dictionary<string, object?>
{
    ["databaseEnabled"] = cdcEnabled,
    ["cdcSchemaObjects"] = cdcObjects,
    ["note"] = "آشکارسازی از sys.databases.is_cdc_enabled و فهرست اشیای schema «cdc» در sys.objects — جدول‌های cdc.change_tables مستقیم خوانده نمی‌شوند (نیازمند SELECT است؛ سیاست فاز ۱۲.۵: درخواست مجوز جدید ممنوع). «تغییرات واقعی» هرگز خوانده نمی‌شود.",
};
Console.WriteLine($"CDC: {(cdcEnabled ? "فعال" : "غیرفعال")} — اشیای schema cdc: {cdcObjects.Count}");

// ═══ ۲۰) Change Tracking — سطح دیتابیس + سطح جدول ═══
var ctDbRows = await TryQuery("changeTrackingDatabase", LiveSchemaSql.ChangeTrackingDatabase);
object? ctDatabase = null;
var ctTablesFinal = new List<Dictionary<string, object?>>();
var ctDbEnabled = false;
if (ctDbRows is null)
{
    ctDatabase = new Dictionary<string, object?> { ["available"] = false };
}
else
{
    var ctRow = ctDbRows.Rows.Count > 0 ? ctDbRows.Rows[0] : null;
    ctDbEnabled = ctRow is not null;
    ctDatabase = new Dictionary<string, object?>
    {
        ["available"] = true,
        ["enabled"] = ctDbEnabled,
        ["isAutoCleanupOn"] = ctRow is null ? false : V(ctRow, "IsAutoCleanupOn"),
        ["retentionPeriod"] = ctRow is null ? null : V(ctRow, "RetentionPeriod"),
        ["retentionPeriodUnits"] = ctRow is null ? null : V(ctRow, "RetentionPeriodUnits"),
        ["note"] = ctRow is null ? "ردیفی در sys.change_tracking_databases نیست = CT در سطح دیتابیس غیرفعال است." : null,
    };
    if (ctDbEnabled)
    {
        var ctTableRows = await TryQuery("changeTrackingTables", LiveSchemaSql.ChangeTrackingTables);
        if (ctTableRows is not null)
            foreach (DataRow r in ctTableRows.Rows)
            {
                var oid = Convert.ToInt64(r["object_id"]);
                ctTablesFinal.Add(new Dictionary<string, object?>
                {
                    ["table"] = objectIdToKey.TryGetValue(oid, out var k) ? k : $"#{oid}",
                    ["isTrackColumnsUpdatedOn"] = V(r, "IsTrackColumnsUpdatedOn"),
                    ["beginVersion"] = V(r, "BeginVersion"),
                    ["cleanupVersion"] = V(r, "CleanupVersion"),
                    ["minValidVersion"] = V(r, "MinValidVersion"),
                });
        }
    }
}
report["changeTracking"] = new Dictionary<string, object?>
{
    ["database"] = ctDatabase,
    ["tables"] = ctTablesFinal,
};
Console.WriteLine($"Change Tracking: {(ctDbEnabled ? "فعال" : "غیرفعال")} — جدول‌های ردیابی‌شده: {ctTablesFinal.Count}");

// ═══ ۲۱) قابلیت‌های همگام‌سازی — فقط از پرچم‌های واقعی، نه از نام ستون‌ها ═══
var replicationFlags = tableFlags.Values
    .Select(f => (Dictionary<string, object?>)f!)
    .Where(f => f["replicated"] is true || f["mergePublished"] is true || f["syncTranSubscribed"] is true || f["hasReplicationFilter"] is true)
    .ToList();
report["syncCapabilities"] = new Dictionary<string, object?>
{
    ["rowVersion"] = new Dictionary<string, object?>
    {
        ["columnCount"] = rvList.Count,
        ["tables"] = rvList.Select(x => x["table"]).Distinct().ToList(),
    },
    ["temporal"] = new Dictionary<string, object?> { ["systemVersionedTables"] = temporalList.Count },
    ["cdc"] = new Dictionary<string, object?>
    {
        ["databaseEnabled"] = cdcEnabled,
        ["captureObjectsDetected"] = cdcObjects.Count,
    },
    ["changeTracking"] = new Dictionary<string, object?>
    {
        ["databaseEnabled"] = ctDbEnabled,
        ["trackedTables"] = ctTablesFinal.Count,
    },
    ["replication"] = new Dictionary<string, object?>
    {
        ["tablesFlagged"] = replicationFlags.Count,
    },
    ["lastModifiedColumns"] = "بر پایهٔ فرادادهٔ واقعی ارزیابی «نمی‌شود» — نام ستون (تاریخ/UserId) به‌تنهایی هرگز «آخرین ویرایش» فرض نمی‌شود (سیاست فاز ۱۲.۵ §۱۲). نیازمند شاهد اجرایی/معنایی مستقل است.",
    ["softDelete"] = "از روی نام ستون فرض نمی‌شود — نیازمند شاهد تعریف/رفتار است؛ در همین گزارش فقط پرچم‌های ساختاری ثبت شده‌اند.",
    ["incrementalJudgment"] = (rvList.Count > 0 || cdcEnabled || ctDbEnabled || temporalList.Count > 0)
        ? "برای زیرمجموعهٔ دارای شاهد ساختاری، امکان ارزیابی وجود دارد — جزئیات در سند IDEAL_SYNC_CAPABILITY_AUDIT."
        : "هیچ شاهد ساختاریِ افزایشی (RowVersion/CDC/CT/Temporal) در دسترس نیست — برای همهٔ جدول‌ها Snapshot کامل لازم است.",
};
Console.WriteLine($"قابلیت‌های همگام‌سازی: RowVersion={rvList.Count}، Temporal={temporalList.Count}، CDC={(cdcEnabled ? "روشن" : "خاموش")}، CT={(ctDbEnabled ? "روشن" : "خاموش")}، پرچم Replication={replicationFlags.Count}");

// ═══ ۲۲) مقایسه با انتظارات IdealBridge (جدول/SPهای موردنیاز مخازن) ═══
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

// حل‌سازی dbo-اول با بازگشت به تطبیق یکتا در سایر Schemaها
string? ResolveTable(string bare) =>
    tablesMap.ContainsKey("dbo." + bare) ? "dbo." + bare
    : tablesMap.Keys.Where(k => string.Equals(k[(k.IndexOf('.') + 1)..], bare, StringComparison.OrdinalIgnoreCase)).ToList() is { Count: 1 } one ? one[0] : null;
string? ResolveSp(string bare) =>
    spMap.ContainsKey("dbo." + bare) ? "dbo." + bare
    : spMap.Keys.Where(k => string.Equals(k[(k.IndexOf('.') + 1)..], bare, StringComparison.OrdinalIgnoreCase)).ToList() is { Count: 1 } one ? one[0] : null;

var missingTables = new List<string>();
var ambiguousTables = new List<string>();
var missingColumns = new Dictionary<string, List<string>>();
foreach (var (t, cols) in expectedTables)
{
    var key = ResolveTable(t);
    if (key is null)
    {
        // ابهام چند-Schemaای هم مثل غیبت گزارش می‌شود، اما جدا فهرست می‌گردد
        var hits = tablesMap.Keys.Where(k => string.Equals(k[(k.IndexOf('.') + 1)..], t, StringComparison.OrdinalIgnoreCase)).ToList();
        if (hits.Count > 1) ambiguousTables.Add($"{t} ({hits.Count} schema: {string.Join(", ", hits)})");
        missingTables.Add(t);
        continue;
    }
    var present = tablesMap[key].Select(x => (string)x["name"]!).ToHashSet(StringComparer.OrdinalIgnoreCase);
    var miss = cols.Where(c => !present.Contains(c)).ToList();
    if (miss.Count > 0) missingColumns[key] = miss;
}
var missingSp = new List<string>();
var spSignatures = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
foreach (var s in expectedSps)
{
    var key = ResolveSp(s);
    if (key is null) { missingSp.Add(s); continue; }
    spSignatures[key] = spMap[key];
}

report["idealBridgeCompatibility"] = new Dictionary<string, object?>
{
    ["note"] = "اجرای SP در IdealBridge غیرفعال است؛ موجودی/امضای SPها فقط برای گزارش سازگاری نسخه استخراج می‌شود.",
    ["missingTables"] = missingTables,
    ["ambiguousTables"] = ambiguousTables,
    ["missingColumns"] = missingColumns,
    ["expectedSpPresence"] = expectedSps.ToDictionary(s => s, s => ResolveSp(s) is not null),
    ["spSignatures"] = spSignatures,
};

Console.WriteLine();
Console.WriteLine("═══ مقایسهٔ زنده با انتظارات IdealBridge ═══");
Console.WriteLine(missingTables.Count == 0
    ? "✔ همهٔ جدول‌های موردانتظار موجودند"
    : "✖ جداول مفقود: " + string.Join(", ", missingTables));
foreach (var (t, cols) in missingColumns)
    Console.WriteLine($"△ {t}: ستون‌های مفقود: {string.Join(", ", cols)}");
Console.WriteLine(missingSp.Count == 0
    ? "✔ همهٔ SPهای موردانتظار موجودند (اجرای‌شان در IdealBridge غیرفعال است)"
    : "△ SPهای ناموجود: " + string.Join(", ", missingSp));

// ═══ ۲۳) هشدارهای استخراج + شمارش بلوک‌ها ═══
report["extractionWarnings"] = warnings;
if (warnings.Count > 0)
{
    Console.WriteLine();
    Console.WriteLine($"△ هشدارهای استخراج: {warnings.Count}");
    foreach (var w in warnings)
        Console.WriteLine($"  - [{w["block"]}]: {w["message"]}");
}

var counts = new Dictionary<string, object?>
{
    ["schemas"] = schemaList.Count,
    ["tables"] = tablesMap.Count,
    ["columns"] = columnRows.Rows.Count,
    ["primaryKeys"] = pkMap.Count,
    ["foreignKeys"] = fkList.Count,
    ["tablesWithIndexes"] = idxMap.Count,
    ["views"] = viewMap.Count,
    ["storedProcedures"] = spMap.Count,
    ["functions"] = fnMap.Count,
    ["triggers"] = triggerList.Count,
    ["identityColumns"] = idList.Count,
    ["computedColumns"] = ccList.Count,
    ["rowVersionColumns"] = rvList.Count,
    ["defaultConstraints"] = dcList.Count,
    ["temporalTables"] = temporalList.Count,
    ["generatedAlwaysColumns"] = gaList.Count,
    ["extractionWarnings"] = warnings.Count,
};
((Dictionary<string, object?>)report["metadata"]!)["counts"] = counts;

// ═══ خروجی JSON — بدون هیچ Connection String/Secret/دادهٔ کسب‌وکار ═══
var json = JsonSerializer.Serialize(report, new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
});
await File.WriteAllTextAsync(outFile, json);
Console.WriteLine();
Console.WriteLine($"گزارش کامل در «{Path.GetFullPath(outFile)}» ذخیره شد.");
Console.WriteLine("این فایل هرگز وارد Git نمی‌شود (اطلاعات زیرساخت شماست، نه کد).");
Console.WriteLine("مقایسهٔ دو گزارش: IdeaSchemaDump.exe --compare baseline.json current.json");
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
