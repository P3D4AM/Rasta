using IdeaSchemaDump;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های خروجی تشخیصی ConnectionDiagnostics (فاز ۱۲.۵.۱):
///  - زنجیرهٔ کامل استثنا (Type/Message/HResult/Stack) چاپ می‌شود؛
///  - هر Message پیش از چاپ از SecretRedactor می‌گذرد (Password= و Pwd=)؛
///  - حالت واقعی خطای نسخهٔ dev-12.5.1 (NotSupportedException «Globalization
///    Invariant Mode is not supported.») با پیام کامل قابل مشاهده است —
///    همان چیزی که با خروجی قدیمی (فقط نام نوع) گم می‌شد.
/// </summary>
public class IdeaSchemaDumpConnectionDiagnosticsTests
{
    private const string SecretPassword = "Sup3r-Secret-Diag-Pwd";

    [Fact]
    public void Describe_InvariantGlobalizationFailure_ShowsFullTypeMessageHResult()
    {
        // همان استثنای واقعی نسخهٔ dev-12.5.1 — پیام باید کامل دیده شود
        var ex = new NotSupportedException("Globalization Invariant Mode is not supported.");
        var text = ConnectionDiagnostics.Describe(ex);
        Assert.StartsWith("جزئیات فنی: ", text, StringComparison.Ordinal);
        Assert.Contains("System.NotSupportedException", text, StringComparison.Ordinal);
        Assert.Contains("Globalization Invariant Mode is not supported.", text, StringComparison.Ordinal);
        Assert.Contains("HResult=0x80131515", text, StringComparison.Ordinal);
    }

    [Fact]
    public void Describe_SecretsInMessages_AreRedacted()
    {
        // متن استثنا به‌اشتباه حاوی رمز — باید Mask شود و هرگز بازتاب نشود
        var ex = new InvalidOperationException(
            $"Keyword not supported: 'x'. Server=SQLSRV;User Id=ibk_reader;Password={SecretPassword};Extra=1");
        var text = ConnectionDiagnostics.Describe(ex);
        Assert.DoesNotContain(SecretPassword, text, StringComparison.Ordinal);
        Assert.Contains("Password=***", text, StringComparison.Ordinal);
    }

    [Fact]
    public void Describe_PwdVariant_IsRedactedToo()
    {
        var ex = new Exception($"connection failed with Pwd={SecretPassword} before login");
        var text = ConnectionDiagnostics.Describe(ex);
        Assert.DoesNotContain(SecretPassword, text, StringComparison.Ordinal);
        Assert.Contains("Pwd=***", text, StringComparison.Ordinal);
    }

    [Fact]
    public void Describe_InnerChain_RenderedInOrderWithMarkers()
    {
        var innermost = new ArgumentException("bad keyword 'foo'");
        var inner = new InvalidOperationException("login phase failed", innermost);
        var outer = new Exception("outer failure", inner);
        var text = ConnectionDiagnostics.Describe(outer);
        Assert.Contains("جزئیات فنی: System.Exception", text, StringComparison.Ordinal);
        Assert.Contains("[1] استثنای داخلی → System.InvalidOperationException", text, StringComparison.Ordinal);
        Assert.Contains("[2] استثنای داخلی → System.ArgumentException", text, StringComparison.Ordinal);
        // ترتیب: سطح ۱ پیش از سطح ۲
        Assert.True(text.IndexOf("[1]", StringComparison.Ordinal) < text.IndexOf("[2]", StringComparison.Ordinal),
            "زنجیره باید از بیرونی به داخلی چاپ شود");
    }

    [Fact]
    public void Describe_MultiLineMessage_IsFlattenedToOneLine()
    {
        var ex = new Exception("line1\nline2\r\nline3");
        var text = ConnectionDiagnostics.Describe(ex);
        Assert.Contains("line1 line2 line3", text, StringComparison.Ordinal);
    }

    [Fact]
    public void Describe_EmptyMessage_DoesNotCrash()
    {
        var text = ConnectionDiagnostics.Describe(new Exception(""));
        Assert.Contains("System.Exception", text, StringComparison.Ordinal);
        Assert.Contains("HResult=0x", text, StringComparison.Ordinal);
    }

    [Fact]
    public void Describe_StackFrames_IndentedAndContainsThrowSite()
    {
        Exception caught;
        try { throw new InvalidOperationException("boom"); }
        catch (Exception e) { caught = e; }
        var text = ConnectionDiagnostics.Describe(caught);
        Assert.Contains("    at ", text, StringComparison.Ordinal);   // تورفتگی فریم‌ها
        Assert.Contains(nameof(Describe_StackFrames_IndentedAndContainsThrowSite), text, StringComparison.Ordinal);
    }
}
