using System.Data;
using System.Text;

namespace IdealBridge.Infrastructure.Database;

/// <summary>
/// گارد فقط-خواندنی در سطح کد — لایهٔ نخست از دو لایه (لایهٔ دوم: مجوز SELECT-only در SQL Server).
///
/// فاز ۱۱ — بازنویسی کامل با «توکنایزر T-SQL» به‌جای جست‌وجوی رشته‌ای:
///  - متن دستور اول توکن‌بندی می‌شود (رشته‌ها، شناسه‌های [براکت‌دار]، "کوتیشن‌دار"، N'...'،
///    کامنت‌های -- و /* */ و اعداد، همگی به‌درستی تشخیص داده می‌شوند).
///  - قواعد:
///      ۱. هیچ فراخوانی Stored Procedure مجاز نیست — نه با نام، نه با EXEC، نه با CommandType.StoredProcedure.
///         (در فاز ۱۱ «هیچ SP صرفاً بر اساس نام مجاز شناخته نمی‌شود» و فهرست سفید قبلی حذف شد.)
///      ۲. فقط «یک» دستور مجاز است: توکن «;» یا GO = batch چندبخشی → رد.
///      ۳. فعل آغازین باید SELECT یا WITH باشد.
///      ۴. واژهٔ کلیدی ممنوع در «هر» جای دستور → رد (INSERT/UPDATE/DELETE/MERGE/TRUNCATE/ALTER/DROP/
///         CREATE/GRANT/REVOKE/DENY/BACKUP/RESTORE/KILL/SHUTDOWN/EXEC/EXECUTE/DBCC/INTO/SET/WAITFOR/
///         OPENROWSET/OPENQUERY/OPENDATASOURCE/OPENXML/BULK/...).
///         «INTO» یعنی SELECT ... INTO (ساخت جدول) → ممنوع. «SET» هم مسیر تغییر state است → ممنوع.
///      ۵. شناسهٔ برهنهٔ sp_* یا xp_* (پروسیجرهای سیستمی) → رد.
///      ۶. رشتهٔ نیمه‌تمام یا کامنت نیمه‌بسته → خطای توکنایزر → رد.
///  - چیزهایی که «فریب نمی‌خورند»: واژهٔ کلیدی داخل کامنت یا رشته‌آدرس، «;» داخل رشته،
///    EXEC مخفی در کامنت، نام ستون [UPDATE] براکت‌دار، دستور بعد از GO، ...
///
/// خاموش‌کردن: EnforceReadOnlyGuard فقط در محیط Development معتبر است؛ در Production
/// توسط Program.cs به‌اجبار true می‌شود (تست ReadOnlyGuardPolicyTests). گارد «لایهٔ دفاعی» است —
/// امنیت اصلی باید با مجوزهای SQL Server (حساب فقط db_datareader) تأمین شود.
/// </summary>
public static class ReadOnlyCommandGuard
{
    public static void Validate(string commandText, CommandType commandType)
    {
        if (commandType == CommandType.StoredProcedure)
            throw new ReadOnlyViolationException(
                "فراخوانی Stored Procedure مجاز نیست — در این نسخه هیچ SP اجرا نمی‌شود (سیاست فقط-خواندنی فاز ۱۱).");

        if (commandType != CommandType.Text)
            throw new ReadOnlyViolationException($"نوع دستور {commandType} پشتیبانی نمی‌شود (فقط Text).");

        if (string.IsNullOrWhiteSpace(commandText))
            throw new ReadOnlyViolationException("متن دستور خالی است.");

        List<Token> tokens;
        try
        {
            tokens = Tokenize(commandText);
        }
        catch (FormatException fex)
        {
            throw new ReadOnlyViolationException($"دستور قابل توکن‌بندی امن نیست: {fex.Message}");
        }

        if (tokens.Count == 0)
            throw new ReadOnlyViolationException("دستور هیچ محتوای اجرایی ندارد.");

        // ۱) فقط یک دستور — بدون «;» و بدون GO
        if (tokens.Any(t => t.Kind == TokenKind.Semicolon))
            throw new ReadOnlyViolationException("اجرای چند دستور در یک فراخوانی (batch با «;») مجاز نیست.");
        if (tokens.Any(t => t is { Kind: TokenKind.Word, Text: "GO" }))
            throw new ReadOnlyViolationException("جداکنندهٔ batch «GO» مجاز نیست — فقط یک دستور SELECT.");

        // ۲) فعل آغازین
        var first = tokens[0];
        if (first is not { Kind: TokenKind.Word, Text: "SELECT" or "WITH" })
            throw new ReadOnlyViolationException(
                $"دستور باید با SELECT یا WITH شروع شود (شروع‌شده با «{first.Text}»).");

        // ۳) واژه‌های کلیدی ممنوع در کل دستور (فقط Wordهای «برهنه» — نه [براکت‌دار]، نه رشته)
        foreach (var t in tokens)
        {
            if (t.Kind != TokenKind.Word) continue;
            if (ForbiddenKeywords.Contains(t.Text))
                throw new ReadOnlyViolationException(
                    $"واژهٔ ممنوع «{t.Text}» در دستور یافت شد — فقط SELECT خواندنی مجاز است.");
            if (t.Text.StartsWith("SP_", StringComparison.Ordinal) ||
                t.Text.StartsWith("XP_", StringComparison.Ordinal))
                throw new ReadOnlyViolationException(
                    $"فراخوانی پروسیجر سیستمی «{t.Text}» مجاز نیست.");
        }
    }

    /// <summary>واژه‌های کلیدی ممنوع — همیشه روی فرم UPPER مقایسه می‌شوند.</summary>
    private static readonly HashSet<string> ForbiddenKeywords = new(StringComparer.Ordinal)
    {
        // نوشتن/تغییر داده یا ساختار
        "INSERT", "UPDATE", "DELETE", "MERGE", "TRUNCATE", "ALTER", "DROP", "CREATE",
        "INTO",                       // SELECT ... INTO (ساخت جدول)
        // مجوزها و مدیریت سرور
        "GRANT", "REVOKE", "DENY", "BACKUP", "RESTORE", "KILL", "SHUTDOWN", "DBCC",
        // اجرای کد
        "EXEC", "EXECUTE",            // هر فراخوانی SP/داینامیک
        // تغییر وضعیت نشست / تزریق زمان‌محور
        "SET", "WAITFOR",
        // توابع جدولی/چندسروری (استفادهٔ خارجی/داینامیک)
        "OPENROWSET", "OPENQUERY", "OPENDATASOURCE", "OPENXML", "BULK",
        // تریگرها
        "ENABLE", "DISABLE",
    };

    // ───────────────────────── توکنایزر T-SQL ─────────────────────────

    internal enum TokenKind { Word, String, QuotedIdentifier, Semicolon, Other }

    internal sealed record Token(TokenKind Kind, string Text);

    /// <summary>
    /// توکن‌بندی امن T-SQL: رشته‌ها و شناسه‌های نقل‌قولی «محتوایشان» هرگز به‌عنوان واژهٔ کلیدی
    /// دیده نمی‌شوند؛ کامنت‌ها کاملاً حذف می‌شوند؛ رشته/کامنت نیمه‌تمام خطا می‌دهد.
    /// (internal برای تست واحد توکنایزر)
    /// </summary>
    internal static List<Token> TokenizeInternal(string sql) => Tokenize(sql);

    private static List<Token> Tokenize(string sql)
    {
        var tokens = new List<Token>();
        int i = 0, n = sql.Length;

        while (i < n)
        {
            var c = sql[i];

            // فاصله‌ها
            if (char.IsWhiteSpace(c)) { i++; continue; }

            // کامنت خطی --  (تا انتهای خط، محتوا نادیده)
            if (c == '-' && i + 1 < n && sql[i + 1] == '-')
            {
                while (i < n && sql[i] != '\n') i++;
                continue;
            }

            // کامنت بلوکی /* */ (محتوا نادیده — حتی اگر شامل ; یا EXEC باشد)
            if (c == '/' && i + 1 < n && sql[i + 1] == '*')
            {
                i += 2;
                while (i + 1 < n && !(sql[i] == '*' && sql[i + 1] == '/')) i++;
                if (i + 1 >= n) throw new FormatException("کامنت بلوکی بسته نشده است.");
                i += 2;
                continue;
            }

            // رشتهٔ N'...' یا '...'
            if (c == 'N' && i + 1 < n && sql[i + 1] == '\'')
            {
                i = ReadString(sql, i + 1, tokens);
                continue;
            }
            if (c == '\'')
            {
                i = ReadString(sql, i, tokens);
                continue;
            }

            // شناسهٔ براکت‌دار [name] — «;» و واژه‌های کلیدی داخل آن بی‌اثرند
            if (c == '[')
            {
                var sb = new StringBuilder();
                i++;
                while (true)
                {
                    if (i >= n) throw new FormatException("شناسهٔ [براکت‌دار] بسته نشده است.");
                    if (sql[i] == ']')
                    {
                        if (i + 1 < n && sql[i + 1] == ']') { sb.Append(']'); i += 2; continue; }
                        i++;
                        break;
                    }
                    sb.Append(sql[i]);
                    i++;
                }
                tokens.Add(new Token(TokenKind.QuotedIdentifier, sb.ToString()));
                continue;
            }

            // شناسهٔ "کوتیشن‌دار" (QUOTED_IDENTIFIER ON)
            if (c == '"')
            {
                var sb = new StringBuilder();
                i++;
                while (true)
                {
                    if (i >= n) throw new FormatException("شناسهٔ \"کوتیشن‌دار\" بسته نشده است.");
                    if (sql[i] == '"')
                    {
                        if (i + 1 < n && sql[i + 1] == '"') { sb.Append('"'); i += 2; continue; }
                        i++;
                        break;
                    }
                    sb.Append(sql[i]);
                    i++;
                }
                tokens.Add(new Token(TokenKind.QuotedIdentifier, sb.ToString()));
                continue;
            }

            // جداکنندهٔ دستور
            if (c == ';')
            {
                tokens.Add(new Token(TokenKind.Semicolon, ";"));
                i++;
                continue;
            }

            // واژه: حرف آغازین → حروف/ارقام/_/@/#/$ — «برهنه» (کلیدواژه بودنش معتبر است)
            if (char.IsLetter(c) || c == '_' || c == '@' || c == '#')
            {
                var start = i;
                while (i < n && (char.IsLetterOrDigit(sql[i]) || sql[i] == '_' || sql[i] == '@' || sql[i] == '#' || sql[i] == '$'))
                    i++;
                var raw = sql[start..i];
                // واژهٔ برهنهٔ ۲+حرفی که فقط از @/$/# ساخته شده توکن Word نیست
                tokens.Add(new Token(TokenKind.Word, raw.ToUpperInvariant()));
                continue;
            }

            // سایر: عملگرها، نقطه، پرانتز، اعداد و ...
            tokens.Add(new Token(TokenKind.Other, c.ToString()));
            i++;
        }

        return tokens;
    }

    /// <summary>خواندن رشتهٔ '...' با گریز '' — محتوای رشته هرگز توکن کلیدواژه نمی‌شود.</summary>
    private static int ReadString(string sql, int quotePos, List<Token> tokens)
    {
        var i = quotePos + 1;
        var sb = new StringBuilder();
        while (true)
        {
            if (i >= sql.Length) throw new FormatException("رشتهٔ متنی بسته نشده است.");
            if (sql[i] == '\'')
            {
                if (i + 1 < sql.Length && sql[i + 1] == '\'') { sb.Append('\''); i += 2; continue; }
                i++;
                break;
            }
            sb.Append(sql[i]);
            i++;
        }
        tokens.Add(new Token(TokenKind.String, sb.ToString()));
        return i;
    }
}

/// <summary>تخلف از سیاست فقط-خواندنی — هرگز جزئیات SQL داخلی را افشا نمی‌کند.</summary>
public class ReadOnlyViolationException : Exception
{
    public ReadOnlyViolationException(string message) : base(message) { }
}

/// <summary>
/// سیاست مؤثر گارد: در Production هرگز قابل خاموش‌کردن نیست.
/// Program.cs از همین متد استفاده می‌کند تا رفتار در دو محیط «مستند و قطعی» باشد.
/// </summary>
public static class ReadOnlyGuardPolicy
{
    /// <summary>گارد در Production همیشه روشن است؛ فقط در Development/Testing قابل خاموش‌کردن برای آزمایش است.</summary>
    public static bool Effective(bool configuredValue, bool isProductionEnvironment)
        => isProductionEnvironment || configuredValue;
}
