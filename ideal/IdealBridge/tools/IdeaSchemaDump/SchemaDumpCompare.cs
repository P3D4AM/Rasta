using System.Text.Encodings.Web;
using System.Text.Json;

namespace IdeaSchemaDump;

/// <summary>
/// مقایسهٔ دو گزارش IdeaSchemaDump (baseline vs current) — برای کشف تفاوت ساختاری
/// بین دو نسخهٔ دیتابیس Ideal (مثلاً 3.1.16 در برابر 3.1.18).
/// بدون هیچ اتصال به دیتابیس؛ فقط دو فایل JSON.
/// خروجی: diff ساختاریافته (جداول/ستون‌ها/نوع‌ها/کلیدها/ایندکس‌ها/ویوها/SPها/پارامترها).
/// </summary>
public static class SchemaDumpCompare
{
    private static readonly JsonSerializerOptions ReadOpts = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public static int Run(string baselinePath, string currentPath, string outPath)
    {
        if (!File.Exists(baselinePath)) { Console.Error.WriteLine($"خطا: فایل baseline یافت نشد: {baselinePath}"); return 2; }
        if (!File.Exists(currentPath)) { Console.Error.WriteLine($"خطا: فایل current یافت نشد: {currentPath}"); return 2; }

        using var baselineDoc = JsonDocument.Parse(File.ReadAllText(baselinePath));
        using var currentDoc = JsonDocument.Parse(File.ReadAllText(currentPath));
        var baseline = baselineDoc.RootElement;
        var current = currentDoc.RootElement;

        var diff = new Dictionary<string, object?>
        {
            ["comparedAt"] = DateTimeOffset.UtcNow,
            ["baseline"] = new Dictionary<string, object?>
            {
                ["generatedAt"] = GetString(baseline, "generatedAt"),
                ["server"] = GetString(baseline, "server", "serverName"),
                ["database"] = GetString(baseline, "server", "database"),
                ["productVersion"] = GetString(baseline, "server", "productVersion"),
            },
            ["current"] = new Dictionary<string, object?>
            {
                ["generatedAt"] = GetString(current, "generatedAt"),
                ["server"] = GetString(current, "server", "serverName"),
                ["database"] = GetString(current, "server", "database"),
                ["productVersion"] = GetString(current, "server", "productVersion"),
            },
        };

        // ── جداول و ستون‌ها ──
        var bTables = TableColumns(baseline);
        var cTables = TableColumns(current);
        var tablesDiff = new Dictionary<string, object?>
        {
            ["added"] = cTables.Keys.Except(bTables.Keys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList(),
            ["removed"] = bTables.Keys.Except(cTables.Keys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList(),
        };
        var columnChanges = new List<object?>();
        foreach (var table in bTables.Keys.Intersect(cTables.Keys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x))
        {
            var bCols = bTables[table];
            var cCols = cTables[table];
            var added = cCols.Keys.Except(bCols.Keys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList();
            var removed = bCols.Keys.Except(cCols.Keys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList();
            var typeChanged = cCols.Where(kv => bCols.TryGetValue(kv.Key, out var b)
                    && !ColumnsEqual(b, kv.Value))
                .Select(kv => new { table, column = kv.Key, baseline = Describe(bCols[kv.Key]), current = Describe(kv.Value) })
                .Cast<object?>()
                .ToList();
            if (added.Count > 0 || removed.Count > 0 || typeChanged.Count > 0)
                columnChanges.Add(new Dictionary<string, object?>
                {
                    ["table"] = table,
                    ["columnsAdded"] = added,
                    ["columnsRemoved"] = removed,
                    ["columnsChanged"] = typeChanged,
                });
        }
        tablesDiff["columnChanges"] = columnChanges;
        diff["tables"] = tablesDiff;

        // ── کلیدهای اصلی ──
        diff["primaryKeys"] = CompareStringLists(baseline, current, "primaryKeys");

        // ── کلیدهای خارجی ──
        diff["foreignKeys"] = CompareRawArrays(baseline, current, "foreignKeys");

        // ── ایندکس‌ها ──
        diff["indexes"] = CompareRawArrays(baseline, current, "indexes");

        // ── ویوها ──
        diff["views"] = CompareStringLists(baseline, current, "views");

        // ── SPها (فرادادهٔ امضا) ──
        diff["storedProcedures"] = CompareStringLists(baseline, current, "storedProcedures");

        // ── Defaultها ──
        diff["defaultConstraints"] = CompareRawArrays(baseline, current, "defaultConstraints");

        // ── خلاصه ──
        var addedTables = ((List<string>)tablesDiff["added"]!).Count;
        var removedTables = ((List<string>)tablesDiff["removed"]!).Count;
        var changedTables = columnChanges.Count;
        diff["summary"] = new Dictionary<string, object?>
        {
            ["tablesAdded"] = addedTables,
            ["tablesRemoved"] = removedTables,
            ["tablesWithColumnChanges"] = changedTables,
        };

        var json = JsonSerializer.Serialize(diff, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        });
        File.WriteAllText(outPath, json);

        Console.WriteLine("═══ مقایسهٔ اسکیمای دو دیتابیس Ideal ═══");
        Console.WriteLine($"Baseline: {GetString(baseline, "server", "serverName")} / {GetString(baseline, "server", "database")} ({GetString(baseline, "server", "productVersion")})");
        Console.WriteLine($"Current : {GetString(current, "server", "serverName")} / {GetString(current, "server", "database")} ({GetString(current, "server", "productVersion")})");
        Console.WriteLine($"جداول: +{addedTables} اضافه، -{removedTables} حذف، {changedTables} جدول با تغییر ستون‌ها");
        foreach (var entry in columnChanges)
        {
            var e = (Dictionary<string, object?>)entry!;
            var t = (string)e["table"]!;
            var add = ((List<string>)e["columnsAdded"]!);
            var rem = ((List<string>)e["columnsRemoved"]!);
            var chg = ((List<object?>)e["columnsChanged"]!);
            var parts = new List<string>();
            if (add.Count > 0) parts.Add("+" + string.Join(",+", add));
            if (rem.Count > 0) parts.Add("-" + string.Join(",-", rem));
            if (chg.Count > 0) parts.Add($"~{chg.Count} تغییر نوع");
            Console.WriteLine($"  {t}: {string.Join(" | ", parts)}");
        }
        Console.WriteLine();
        Console.WriteLine($"گزارش کامل در «{Path.GetFullPath(outPath)}» ذخیره شد.");
        return 0;
    }

    private static string? GetString(JsonElement root, string section, string? key = null)
    {
        if (key is null) return root.TryGetProperty(section, out var v) && v.ValueKind == JsonValueKind.String ? v.GetString() : null;
        return root.TryGetProperty(section, out var s) && s.TryGetProperty(key, out var v2) && v2.ValueKind == JsonValueKind.String ? v2.GetString() : null;
    }

    private static Dictionary<string, Dictionary<string, JsonElement>> TableColumns(JsonElement root)
    {
        var map = new Dictionary<string, Dictionary<string, JsonElement>>(StringComparer.OrdinalIgnoreCase);
        if (!root.TryGetProperty("tables", out var tables) || tables.ValueKind != JsonValueKind.Object) return map;
        foreach (var table in tables.EnumerateObject())
        {
            var cols = new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);
            if (table.Value.ValueKind == JsonValueKind.Array)
                foreach (var col in table.Value.EnumerateArray())
                    if (col.TryGetProperty("name", out var n) && n.ValueKind == JsonValueKind.String)
                        cols[n.GetString()!] = col;
            map[table.Name] = cols;
        }
        return map;
    }

    private static bool ColumnsEqual(JsonElement a, JsonElement b)
    {
        static string? Get(JsonElement c, string k) =>
            c.TryGetProperty(k, out var v) && v.ValueKind == JsonValueKind.String ? v.GetString() : null;
        return Get(a, "type") == Get(b, "type")
               && Get(a, "maxLength") == Get(b, "maxLength")
               && Get(a, "nullable") == Get(b, "nullable");
    }

    private static string Describe(JsonElement c)
    {
        static string? Get(JsonElement c, string k) =>
            c.TryGetProperty(k, out var v) && v.ValueKind == JsonValueKind.String ? v.GetString() : null;
        return $"{Get(c, "type")}({Get(c, "maxLength")}) nullable={Get(c, "nullable")}";
    }

    private static object CompareStringLists(JsonElement baseline, JsonElement current, string section)
    {
        var bKeys = new List<string>();
        var cKeys = new List<string>();
        if (baseline.TryGetProperty(section, out var b) && b.ValueKind == JsonValueKind.Object)
            bKeys = b.EnumerateObject().Select(p => p.Name).ToList();
        if (current.TryGetProperty(section, out var c) && c.ValueKind == JsonValueKind.Object)
            cKeys = c.EnumerateObject().Select(p => p.Name).ToList();
        var changed = new List<object?>();
        foreach (var key in bKeys.Intersect(cKeys, StringComparer.OrdinalIgnoreCase))
        {
            var bv = Serialize(b.GetProperty(key));
            var cv = Serialize(c.GetProperty(key));
            if (bv != cv)
                changed.Add(new { name = key, baseline = Truncate(bv), current = Truncate(cv) });
        }
        return new Dictionary<string, object?>
        {
            ["added"] = cKeys.Except(bKeys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList(),
            ["removed"] = bKeys.Except(cKeys, StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList(),
            ["changed"] = changed,
        };
    }

    private static object CompareRawArrays(JsonElement baseline, JsonElement current, string section)
    {
        var bJson = baseline.TryGetProperty(section, out var b) ? Serialize(b) : "[]";
        var cJson = current.TryGetProperty(section, out var c) ? Serialize(c) : "[]";
        return new Dictionary<string, object?> { ["identical"] = bJson == cJson };
    }

    private static string Serialize(JsonElement e) => JsonSerializer.Serialize(e);

    private static string Truncate(string s, int max = 400) => s.Length <= max ? s : s[..max] + "…";
}
