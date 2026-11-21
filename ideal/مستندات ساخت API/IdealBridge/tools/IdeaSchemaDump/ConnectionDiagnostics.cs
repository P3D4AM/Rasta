// ═══════════════════════════════════════════════════════════════
// ConnectionDiagnostics v1.0 — خروجی تشخیصی امنِ خطای اتصال ابزار کاوش
// ───────────────────────────────────────────────────────────────
// فاز ۱۲.۵.۱ — در نسخهٔ dev-12.5.1 خطای اتصال ابزار فقط «نام نوع» را چاپ
// می‌کرد (جزئیات فنی: NotSupportedException) و پیام واقعی استثنا هرگز دیده
// نمی‌شد؛ ریشه‌یابی بدون اجرای مجدد ممکن نبود. این کلاس زنجیرهٔ کامل
// استثنا (بیرونی → داخلی) را چاپ می‌کند:
//    Type کامل + Message + HResult (هگز) + پشتهٔ فریم‌ها
// سیاست‌ها:
//  ۱) هرگز Connection String/Password چاپ نمی‌شود — «هر» Message پیش از
//     چاپ از SecretRedactor.Redact می‌گذرد (حتی اگر متن استثنا به‌اشتباه
//     حاوی رمز باشد؛ مثل ArgumentExceptionهای Connection String).
//  ۲) Messageهای چندخطی به یک خط تخت می‌شوند (خروجی کنسول مرتب می‌ماند).
//  ۳) پشتهٔ هر سطح به MaxStackFramesPerLevel فریم محدود می‌شود.
//  ۴) Connection String خود ابزار «هرگز» ورودی این کلاس نیست و نیست.
// ═══════════════════════════════════════════════════════════════

using System.Text;
using IdealBridge.Infrastructure.Database;   // SecretRedactor (همان پاک‌ساز سرویس)

namespace IdeaSchemaDump;

/// <summary>خروجی تشخیصی امن خطای اتصال — زنجیرهٔ کامل استثنا بدون هیچ Secret.</summary>
public static class ConnectionDiagnostics
{
    /// <summary>حداکثر فریم‌های پشته که برای هر سطح استثنا چاپ می‌شود.</summary>
    public const int MaxStackFramesPerLevel = 8;

    /// <summary>
    /// شرح کامل زنجیرهٔ استثنا (بیرونی → داخلی). سطح صفر با پیشوند
    /// «جزئیات فنی: » شروع می‌شود (همان قالب قبلی، ادامه‌دار) و هر سطح
    /// داخلی با «[n] استثنای داخلی → » مشخص می‌شود.
    /// </summary>
    public static string Describe(Exception ex)
    {
        var sb = new StringBuilder();
        var level = 0;
        for (Exception? e = ex; e is not null; e = e.InnerException, level++)
        {
            sb.Append(level == 0 ? "جزئیات فنی: " : $"  [{level}] استثنای داخلی → ");
            sb.Append(e.GetType().FullName).Append(" — ");
            sb.Append(SecretRedactor.Redact(e.Message ?? string.Empty).ReplaceLineEndings(" "));
            sb.Append($" (HResult=0x{e.HResult:X8})").AppendLine();
            AppendStack(sb, e);
        }
        return sb.ToString().TrimEnd();
    }

    private static void AppendStack(StringBuilder sb, Exception e)
    {
        if (string.IsNullOrEmpty(e.StackTrace))
            return;   // استثنای بدون پشته (مثل استثنای ساخت‌شده در تست) — چیزی برای چاپ نیست
        var frames = e.StackTrace.Split('\n');
        var count = Math.Min(frames.Length, MaxStackFramesPerLevel);
        for (var i = 0; i < count; i++)
            sb.Append("    ").Append(frames[i].TrimEnd()).AppendLine();
        if (frames.Length > count)
            sb.Append($"    … (+{frames.Length - count} فریم دیگر)").AppendLine();
    }
}
