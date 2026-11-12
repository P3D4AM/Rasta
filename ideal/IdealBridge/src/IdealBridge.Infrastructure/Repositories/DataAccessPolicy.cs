using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;

namespace IdealBridge.Infrastructure.Repositories;

/// <summary>
/// سیاست مرکزی و یکپارچهٔ انتخاب مسیر دسترسی به داده — تنها مرجع تصمیم برای همهٔ Repositoryها.
/// (جایگزین SchemaModeProvider و DataAccessModeSelector قدیمی — فاز ۱۱)
///
/// قواعد این نسخه (فاز ۱۱):
///  ۱. مقدار پیش‌فرض و توصیه‌شده: «Table».
///  ۲. «Auto» معادل Table است؛ در این نسخه هیچ‌وقت Sp برنمی‌گرداند.
///  ۳. «Sp» در راه‌اندازی با خطای واضح رد می‌شود — مسیر اجرای SP به‌کلی از کد حذف شده است
///     (IdealDb.QuerySpAsync وجود ندارد و ReadOnlyCommandGuard هر فراخوانی SP را می‌بندد)
///     تا زمانی که بدنهٔ واقعی SPها بازبینی و مجوزها تأیید شود.
///  ۴. اگر جدول پشتیبان موجودیت مفقود/ناقص باشد، موجودیت «Blocked» می‌شود و
///     هر درخواست با DataAccessUnavailableException (و پیام شفاف) رد می‌شود —
///     هرگز آرایهٔ خالی بی‌صدا برگردانده نمی‌شود.
/// </summary>
public interface IDataAccessPolicy
{
    /// <summary>آیا این نسخهٔ IdealBridge اصلاً مسیر اجرای SP دارد؟ (در فاز ۱۱: همیشه false)</summary>
    bool StoredProceduresSupported { get; }

    /// <summary>حالت پیکربندی‌شده (نرمال‌شده): "table" یا "auto".</summary>
    string ConfiguredMode { get; }

    /// <summary>
    /// حالت مؤثر موجودیت را برمی‌گرداند؛ اگر Blocked باشد DataAccessUnavailableException پرتاب می‌شود.
    /// پیش از نخستین کاوش اسکیما، محافظه‌کارانه «Table» برمی‌گرداند (خطای اتصال در صورت خرابی از مسیر DB می‌آید).
    /// </summary>
    DataAccessMode Resolve(string entity);

    /// <summary>اعمال گزارش کاوش اسکیما (در راه‌اندازی و پس از هر /health/db تازه می‌شود).</summary>
    void ApplySchemaReport(SchemaReport report);

    /// <summary>وضعیت جاری همهٔ موجودیت‌ها (برای گزارش سلامت).</summary>
    IReadOnlyDictionary<string, EntityAccessInfo> CurrentModes();
}

public sealed class DataAccessPolicy : IDataAccessPolicy
{
    /// <summary>جدول پشتیبان هر موجودیت (مسیر اجرایی تنها و یکسان برای همه).</summary>
    private static readonly Dictionary<string, string> EntityTables = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Companies"]     = "CrmCompany",
        ["Persons"]       = "CrmCompanyPersons",
        ["Users"]         = "Users",
        ["Conversations"] = "CrmConversation",
        ["Projects"]      = "CrmProjects",
        ["Reminders"]     = "CrmUserTasks",
        ["Warehouses"]    = "WsWareHouse",
        ["Products"]      = "WSProducts",
        ["Orders"]        = "WSOrder",
        ["PreOrders"]     = "WSPreOrder",
    };

    /// <summary>ثابت ساختاری این نسخه: هیچ مسیر اجرای Stored Procedure در کد وجود ندارد.</summary>
    public const bool SpExecutionSupported = false;

    public bool StoredProceduresSupported => SpExecutionSupported;
    public string ConfiguredMode { get; }

    private volatile Dictionary<string, EntityAccessInfo> _modes = new(StringComparer.OrdinalIgnoreCase);

    public DataAccessPolicy(IdealBridgeOptions options)
        => ConfiguredMode = NormalizeConfiguredMode(options.DataAccessMode);

    /// <summary>اعتبارسنجی حالت پیکربندی — مقدار نامعتبر یا Sp باید در راه‌اندازی، واضح شکست بخورد.</summary>
    public static string NormalizeConfiguredMode(string? raw)
    {
        var m = (raw ?? "Table").Trim().ToLowerInvariant();
        switch (m)
        {
            case "table":
            case "auto":   // در این نسخه auto معادل table است
                return m;
            case "sp":
                throw new InvalidOperationException(
                    "IdealBridge:DataAccessMode=Sp مجاز نیست — در این نسخه اجرای Stored Procedure به‌کلی غیرفعال است " +
                    "(مسیر اجرا حذف شده؛ تا بازبینی بدنهٔ SPها و تأیید مجوزها). مقدارهای مجاز: Table (پیش‌فرض) یا Auto.");
            default:
                throw new InvalidOperationException(
                    $"IdealBridge:DataAccessMode نامعتبر است: «{raw}». مقدارهای مجاز: Table (پیش‌فرض) | Auto.");
        }
    }

    public void ApplySchemaReport(SchemaReport report)
    {
        var modes = new Dictionary<string, EntityAccessInfo>(StringComparer.OrdinalIgnoreCase);
        foreach (var (entity, table) in EntityTables)
        {
            var tableAvailable = report.TablesAvailable.Contains(table, StringComparer.OrdinalIgnoreCase);
            var columnsMissing = report.ColumnsMissing.TryGetValue(table, out var missing) && missing is { Count: > 0 };

            if (tableAvailable && !columnsMissing)
                modes[entity] = new EntityAccessInfo { Mode = DataAccessMode.Table, Reason = $"جدول هستهٔ «{table}» سالم است." };
            else if (!tableAvailable)
                modes[entity] = new EntityAccessInfo { Mode = DataAccessMode.Blocked, Reason = $"جدول «{table}» در دیتابیس Ideal یافت نشد." };
            else
                modes[entity] = new EntityAccessInfo { Mode = DataAccessMode.Blocked, Reason = $"ستون‌های لازم در «{table}» مفقودند: {string.Join(", ", missing!)}" };
        }
        _modes = modes;
    }

    public DataAccessMode Resolve(string entity)
    {
        if (_modes.TryGetValue(entity, out var info))
        {
            if (info.Mode == DataAccessMode.Blocked)
                throw new DataAccessUnavailableException(entity, info.Reason);
            return info.Mode;
        }
        // پیش از نخستین کاوش: محافظه‌کارانهٔ Table — اگر اتصال خراب باشد، خطای DB پاسخ می‌دهد.
        return DataAccessMode.Table;
    }

    public IReadOnlyDictionary<string, EntityAccessInfo> CurrentModes() => _modes;
}
