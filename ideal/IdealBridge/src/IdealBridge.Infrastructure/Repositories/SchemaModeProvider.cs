namespace IdealBridge.Infrastructure.Repositories;

/// <summary>تأمین‌کنندهٔ حالت انتخاب‌شدهٔ هر موجودیت (خروجی SchemaProbe).</summary>
public class SchemaModeProvider
{
    private volatile Dictionary<string, string> _modes = new(StringComparer.OrdinalIgnoreCase);
    private readonly object _lock = new();

    public string Get(string entity)
    {
        if (_modes.TryGetValue(entity, out var mode)) return mode;
        // پیش از نخستین کاوش: پیش‌فرض محافظه‌کارانه Table
        return "Table";
    }

    public void SetAll(Dictionary<string, string> modes)
    {
        lock (_lock) { _modes = new Dictionary<string, string>(modes, StringComparer.OrdinalIgnoreCase); }
    }
}
