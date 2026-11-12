// ═══════════════════════════════════════════════════════════════
// سیاست امنیتی IdeaSchemaDump (فاز ۱۱.۱)
// ───────────────────────────────────────────────────────────────
// ۱) Connection String «فقط» از متغیر محیطی IdealBridge__ConnectionString —
//    دریافت از خط فرمان (ـ--connection و هر شکل دیگر) ممنوع و صریحاً رد می‌شود
//    (رمز در Process Arguments/تاریخچهٔ ترمینال افشا می‌شود).
// ۲) ApplicationIntent=ReadOnly و Encrypt=true در خود ابزار اجباری می‌شود
//    (حتی اگر مقدار دیگری در Connection String آمده باشد).
// ۳) هیچ Connection String/رمز/Secret در پیام خطا یا لاگ بازتاب نمی‌شود.
// این کلاس internal→public برای تست واحد (tests/IdealBridge.UnitTests) است.
// ═══════════════════════════════════════════════════════════════

using Microsoft.Data.SqlClient;

namespace IdeaSchemaDump;

/// <summary>خطای سیاست امنیتی ابزار — پیام امن فارسی بدون هیچ Secret.</summary>
public class SchemaDumpPolicyException : Exception
{
    public SchemaDumpPolicyException(string message) : base(message) { }
}

/// <summary>
/// اعتبارسنجی آرگومان‌ها + منبع یکتای Connection String ابزار کاوش.
/// تمام مسیرهای ورود اطلاعات اتصال اینجا بسته شده‌اند:
///  - هر آرگومانی با پیشوند «--connection» (شکل مقدار جدا یا =مقدار) → رد صریح؛
///  - هر فلگ ناشناختهٔ دیگر → رد (جلوگیری از قاچاق پارامتر)؛
///  - هر آرگومان موقعیتی خارج از مقادیر --compare/--out → رد؛
///  - تنها منبع اتصال: متغیر محیطی IdealBridge__ConnectionString.
/// </summary>
public static class SchemaDumpPolicy
{
    /// <summary>نام متغیر محیطی منبع یکتای Connection String ابزار.</summary>
    public const string EnvVarName = "IdealBridge__ConnectionString";

    private static readonly string[] AllowedFlags = { "--compare", "--out" };

    /// <summary>
    /// اعتبارسنجی آرگومان‌های خط فرمان — فقط --compare (دو فایل) و --out (یک فایل) با مقادیرشان مجازند.
    /// هر شکل دریافت Connection String از خط فرمان صریحاً و با پیام راهنما رد می‌شود.
    /// توجه امنیتی: متن آرگومان‌ها «هرگز» در پیام خطا بازتاب نمی‌شود (ممکن است حاوی رمز باشد).
    /// </summary>
    public static void ValidateArguments(string[] args)
    {
        int expectedValues = 0;   // چند آرگومان بعدی، مقدارِ فلگ مجازند
        foreach (var arg in args)
        {
            if (expectedValues > 0 && !arg.StartsWith("--", StringComparison.Ordinal))
            {
                expectedValues--;   // مقدار فلگ مجاز (مسیر فایل مقایسه/خروجی)
                continue;
            }
            expectedValues = 0;

            if (arg.StartsWith("--connection", StringComparison.OrdinalIgnoreCase))
                throw new SchemaDumpPolicyException(
                    "دریافت Connection String از خط فرمان ممنوع است — رمز در Process Arguments و تاریخچهٔ ترمینال افشا می‌شود. " +
                    $"Connection String را فقط در متغیر محیطی «{EnvVarName}» قرار دهید (روش تنظیم در PowerShell و CMD: سند ۰۴ نصب).");

            if (arg.StartsWith("--", StringComparison.Ordinal))
            {
                if (AllowedFlags.Contains(arg, StringComparer.Ordinal))
                {
                    expectedValues = arg == "--compare" ? 2 : 1;   // == روی string ترتیبی (ordinal) است
                    continue;
                }
                throw new SchemaDumpPolicyException(
                    "آرگومان ناشناخته — تنها فلگ‌های مجاز: --compare <baseline> <current> و --out <فایل خروجی>؛ " +
                    "اتصال فقط از متغیر محیطی IdealBridge__ConnectionString خوانده می‌شود.");
            }

            throw new SchemaDumpPolicyException(
                "آرگومان موقعیتی مجاز نیست — مقادیر فقط پس از --compare یا --out می‌آیند؛ " +
                "Connection String فقط از متغیر محیطی IdealBridge__ConnectionString خوانده می‌شود.");
        }
    }

    /// <summary>
    /// منبع یکتای اتصال: متغیر محیطی — با اعمال اجباری قواعد فقط-خواندنی و رمزنگاری.
    /// (envLookup برای تست واحد تزریق می‌شود؛ پیش‌فرض همان Environment.GetEnvironmentVariable.)
    /// </summary>
    public static SqlConnectionStringBuilder ResolveConnection(Func<string, string?>? envLookup = null)
    {
        var lookup = envLookup ?? Environment.GetEnvironmentVariable;
        var connectionString = lookup(EnvVarName);

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new SchemaDumpPolicyException(
                $"متغیر محیطی «{EnvVarName}» تنظیم نشده است — ابزار بدون آن اجرا نمی‌شود. " +
                "تنظیم امن (PowerShell): [Environment]::SetEnvironmentVariable('" + EnvVarName + "', '...', 'User') — " +
                "و (CMD): setx " + EnvVarName + " \"...\" — رمز واقعی هرگز در Git، فایل عمومی، Screenshot یا Log قرار نگیرد.");

        SqlConnectionStringBuilder builder;
        try
        {
            builder = new SqlConnectionStringBuilder(connectionString);
        }
        catch (Exception)
        {
            // متن خام ممکن است حاوی رمز باشد — هرگز بازتاب نمی‌شود
            throw new SchemaDumpPolicyException(
                $"مقدار متغیر محیطی «{EnvVarName}» ساختار معتبر Connection String ندارد — مقدار را بازبینی کنید (بدون بازتاب محتوا).");
        }

        // قواعد اجباری ابزار — فارغ از آنچه در Connection String آمده است
        builder.ApplicationIntent = ApplicationIntent.ReadOnly;   // اجبار ReadOnly
        builder.ApplicationName = "IdeaSchemaDump";
        builder.Encrypt = true;                                    // اجبار رمزنگاری مسیر
        return builder;
    }
}
