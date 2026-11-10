using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace IdealBridge.Infrastructure.Database;

/// <summary>
/// گارد فقط-خواندنی در سطح کد — لایهٔ نخست از دو لایه (لایهٔ دوم: مجوز SELECT-only در SQL Server).
/// هر دستوری پیش از اجرا اعتبارسنجی می‌شود:
///  - فقط یک دستور مجاز در هر CommandText (بدون ';' یا batch)
///  - فعل آغازین باید SELECT یا WITH (CTE) یا EXEC فقط برای SPهای فهرست‌سفیدِ خواندنی باشد
///  - فهرست سیاه واژه‌های تغییردهنده (INSERT/UPDATE/DELETE/MERGE/TRUNCATE/ALTER/DROP/CREATE/GRANT/BACKUP/RESTORE/...)
///  - فراخوانی SP فقط برای نام‌های مجاز فهرست‌سفید
/// </summary>
public static class ReadOnlyCommandGuard
{
    /// <summary>SPهای خواندنی Ideal که فراخوانی‌شان مجاز است (همگی Apisp/Apifn خواندنی و کاوش فراداده).</summary>
    public static readonly IReadOnlySet<string> AllowedStoredProcedures = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        // خواندن مشتریان
        "ApispSelectCompany", "ApispSelectCompanyById", "ApispSelectCompanyWithIdNumberCode",
        "ApispSelectCompanyPersons", "ApispSelectCompanyPersonsByID", "ApispSelectCompanyPersonWithId",
        "ApispSelectCompanyAddresses",
        // خواندن کاربران
        "ApispSelectUsers", "ApispSelectUsersById", "ApispSelectUsersWithIdOrUserName",
        // خواندن مکالمات/پروژه‌ها/یادآوری‌ها
        "ApispSelectConversation", "ApispSelectProjects", "ApispSelectReminderCartable",
        // تجاری
        "ApispSelectWareHouse", "ApispSelectProducts", "ApispSelectOrder", "ApispSelectPreOrder",
        // جست‌وجو و تنظیمات خواندنی
        "ApispMainSearch", "ApispMainSearchWebSmart", "ApispSelectDefaultCenter",
        "ApispSelectCrmsysSetting", "ApispSelectLanguages",
    };

    private static readonly Regex FirstWordRegex = new(@"\A\s*(SELECT|WITH|EXEC|EXECUTE)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex ForbiddenKeywordRegex = new(
        @"\b(INSERT|UPDATE|DELETE|MERGE|TRUNCATE|ALTER|DROP|CREATE|GRANT|REVOKE|DENY|BACKUP|RESTORE|KILL|SHUTDOWN|OPENROWSET|OPENQUERY|OPENDATASOURCE|BULK|EXEC\s*@|sp_executesql|DBCC|SET\s+IDENTITY_INSERT)\b",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>اعتبارسنجی متن دستور. در صورت تخلف، ReadOnlyViolationException پرتاب می‌شود.</summary>
    public static void Validate(string commandText, CommandType commandType)
    {
        if (string.IsNullOrWhiteSpace(commandText))
            throw new ReadOnlyViolationException("متن دستور خالی است.");

        // مسیر SP: نام باید در فهرست سفید باشد
        if (commandType == CommandType.StoredProcedure)
        {
            var name = commandText.Trim().TrimStart('[').Split(']', '.')[0].Trim();
            if (!AllowedStoredProcedures.Contains(name))
                throw new ReadOnlyViolationException($"فراخوانی Stored Procedure «{commandText}» مجاز نیست (فهرست سفید فقط-خواندنی).");
            return;
        }

        if (commandType != CommandType.Text)
            throw new ReadOnlyViolationException($"نوع دستور {commandType} پشتیبانی نمی‌شود.");

        var text = commandText.Trim();

        // فقط یک دستور — بدون batch separation
        if (text.Contains(';', StringComparison.Ordinal))
            throw new ReadOnlyViolationException("اجرای چند دستور در یک فراخوانی (batch) مجاز نیست.");

        var match = FirstWordRegex.Match(text);
        if (!match.Success)
            throw new ReadOnlyViolationException("دستور باید با SELECT، WITH یا EXEC (فهرست‌سفید SP) شروع شود.");

        var firstWord = match.Groups[1].Value.ToUpperInvariant();
        if (firstWord is "EXEC" or "EXECUTE")
        {
            var rest = text.Substring(match.Length).Trim();
            var spName = rest.TrimStart('[').Split(']', '.', '(', ' ', '\t', '\r', '\n')[0].Trim();
            if (!AllowedStoredProcedures.Contains(spName))
                throw new ReadOnlyViolationException($"EXEC فقط برای SPهای فهرست سفید مجاز است: «{spName}» مجاز نیست.");
            // EXEC ... باید فقط نام SP باشد؛ جلوگیری از EXEC('...') داینامیک
            if (rest.StartsWith("(") || rest.StartsWith("'") || rest.StartsWith("N'"))
                throw new ReadOnlyViolationException("EXEC داینامیک (رشته‌ای) مجاز نیست.");
            return;
        }

        // SELECT/WITH — بررسی فهرست سیاه در کل متن
        var forbidden = ForbiddenKeywordRegex.Match(text);
        if (forbidden.Success)
            throw new ReadOnlyViolationException($"دستور شامل واژهٔ ممنوع «{forbidden.Value}» است؛ فقط SELECT مجاز است.");
    }
}

/// <summary>تخلف از سیاست فقط-خواندنی — هرگز جزئیات SQL داخلی را افشا نمی‌کند.</summary>
public class ReadOnlyViolationException : Exception
{
    public ReadOnlyViolationException(string message) : base(message) { }
}
