using IdeaSchemaDump;
using Microsoft.Data.SqlClient;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های سیاست امنیتی IdeaSchemaDump (فاز ۱۱.۱):
///  - Connection String از خط فرمان «به هیچ شکلی» پذیرفته نمی‌شود (--connection، --connection=x،
///    فلگ ناشناخته، آرگومان موقعیتی قاچاقی) — تنها منبع: متغیر محیطی IdealBridge__ConnectionString؛
///  - ApplicationIntent=ReadOnly و Encrypt=true اجباری؛ ApplicationName شناسنامهٔ ابزار؛
///  - هیچ رمز/Connection String در پیام خطا بازتاب نمی‌شود.
/// </summary>
public class IdeaSchemaDumpPolicyTests
{
    private const string SecretPassword = "Sup3r-Secret-Dump-Pwd";

    private static string EnvConnection() =>
        $"Server=SQLSRV\\IDEAL;Database=CRM;User Id=ibk_reader;Password={SecretPassword};Encrypt=False;ApplicationIntent=ReadWrite";

    // ─── ۱) رد صریح Connection String از خط فرمان (همهٔ اشکال) ───

    [Theory]
    [InlineData("--connection", "Server=x;Password=y")]          // شکل قدیمی: مقدار جدا
    [InlineData("--ConnectionString", "Server=x;Password=y")]    // هر شکل پیشوندی دیگر
    [InlineData("--CONNECTION", "Server=x;Password=y")]          // حروف بزرگ/کوچک
    public void CommandLine_Connection_Any_Form_Is_Rejected(string flag, string value)
    {
        var ex = Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ValidateArguments(new[] { flag, value }));
        // پیام خطا راهنمای روش امن را می‌دهد
        Assert.Contains("ممنوع", ex.Message, StringComparison.Ordinal);
        Assert.Contains(SchemaDumpPolicy.EnvVarName, ex.Message, StringComparison.Ordinal);
        // و هرگز مقدارِ پاس‌شده را بازتاب نمی‌دهد
        Assert.DoesNotContain(value, ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void CommandLine_Connection_Equals_Form_Is_Rejected()
    {
        // شکل فلگ=مقدار در یک آرگومان واحد — باز هم رد صریح
        var ex = Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ValidateArguments(new[] { "--connection=Server=x;Password=y" }));
        Assert.Contains("ممنوع", ex.Message, StringComparison.Ordinal);
        Assert.DoesNotContain("Password=y", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Unknown_Flag_Is_Rejected_No_Parameter_Smuggling()
    {
        // فلگ ناشناخته → رد (مسیر دورزدن بسته می‌شود)
        Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ValidateArguments(new[] { "--verbose" }));
        Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ValidateArguments(new[] { "--server", "SQLSRV" }));
    }

    [Fact]
    public void Stray_Positional_Argument_Is_Rejected_No_Connection_Smuggling()
    {
        // آرگومان موقعیتی قاچاقی (بدون فلگ) — مثل چسباندن مستقیم Connection String → رد
        var ex = Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ValidateArguments(new[] { "Server=x;Password=y" }));
        Assert.Contains(SchemaDumpPolicy.EnvVarName, ex.Message, StringComparison.Ordinal);
        Assert.DoesNotContain("Password=y", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Compare_And_Out_Flags_With_Values_Are_Accepted()
    {
        // تنها فلگ‌های مجاز ابزار — حالت مقایسه (بدون اتصال) و مسیر خروجی
        var ex = Record.Exception(() => SchemaDumpPolicy.ValidateArguments(
            new[] { "--compare", "baseline.json", "current.json", "--out", "diff.json" }));
        Assert.Null(ex);
    }

    // ─── ۲) منبع یکتای اتصال: متغیر محیطی ───

    [Fact]
    public void Missing_EnvVar_Throws_Clear_Guidance_With_PowerShell_And_CMD_Hints()
    {
        var ex = Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ResolveConnection(name => null));
        Assert.Contains(SchemaDumpPolicy.EnvVarName, ex.Message, StringComparison.Ordinal);
        Assert.Contains("PowerShell", ex.Message, StringComparison.Ordinal);
        Assert.Contains("setx", ex.Message, StringComparison.OrdinalIgnoreCase);   // معادل CMD
    }

    [Fact]
    public void EnvVar_Connection_Is_Resolved_ReadOnly_And_Encrypt_Forced()
    {
        // مقدار محیطی عمداً ReadWrite و Encrypt=False دارد — ابزار اجباراً ReadOnly و Encrypt می‌کند
        var builder = SchemaDumpPolicy.ResolveConnection(name =>
            name == SchemaDumpPolicy.EnvVarName ? EnvConnection() : null);

        Assert.Equal(ApplicationIntent.ReadOnly, builder.ApplicationIntent);   // اجبار ReadOnly
        Assert.True(builder.Encrypt);                                          // اجبار رمزنگاری
        Assert.Equal("IdeaSchemaDump", builder.ApplicationName);               // شناسنامهٔ ابزار
        Assert.Equal("SQLSRV\\IDEAL", builder.DataSource);
        Assert.Equal("CRM", builder.InitialCatalog);
        Assert.Equal("ibk_reader", builder.UserID);
    }

    [Fact]
    public void Resolved_Connection_Never_Leads_To_Writable_Intent_Even_If_Env_Says_Otherwise()
    {
        foreach (var bad in new[] { "ReadWrite", "readwrite" })
        {
            var cs = $"Server=s;Database=d;User Id=u;Password=p;ApplicationIntent={bad};Encrypt=False";
            var builder = SchemaDumpPolicy.ResolveConnection(name => cs);
            Assert.Equal(ApplicationIntent.ReadOnly, builder.ApplicationIntent);
            Assert.True(builder.Encrypt);
        }
    }

    [Fact]
    public void Malformed_EnvVar_Error_Contains_No_Secret()
    {
        // مقدار خراب حاوی رمز — پیام خطا محتوای آن را بازتاب نمی‌کند
        var ex = Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ResolveConnection(name => "not###a;;valid;;keyword;;Password=" + SecretPassword));
        Assert.DoesNotContain(SecretPassword, ex.Message, StringComparison.Ordinal);
        Assert.Contains("ساختار معتبر", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Empty_EnvVar_Is_Treated_As_Missing()
    {
        Assert.Throws<SchemaDumpPolicyException>(
            () => SchemaDumpPolicy.ResolveConnection(name => "   "));
    }
}
