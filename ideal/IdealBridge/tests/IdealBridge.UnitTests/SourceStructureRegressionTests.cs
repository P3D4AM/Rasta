using System.Text.RegularExpressions;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های ساختاری ضد-بازگشت (فاز ۱۱) — از بازگشت دو رده باگ جلوگیری می‌کنند:
///  ۱. «Repository در مسیر پشتیبانی‌نشده آرایهٔ خالی بی‌صدا برمی‌گرداند» (باگ تاریخی PersonRepository)
///  ۲. «اجرای Stored Procedure از مسیری از کد ممکن است» (مسیر SP باید به‌کلی حذف بماند)
/// این تست‌ها روی متن سورس کار می‌کنند — مثل اثبات ساختاری گارد IdealDb.
/// </summary>
public class SourceStructureRegressionTests
{
    /// <summary>حذف کامنت‌های // و /* */ از سورس — فقط کد واقعی بررسی شود، نه توضیحات.</summary>
    private static string StripComments(string src)
    {
        // رشته‌ها را موقتاً محافظت می‌کنیم تا کامنت‌مانند داخل رشته، کد را مخفی نکند
        var withoutStrings = System.Text.RegularExpressions.Regex.Replace(src,
            @"N?'(?:[^']|'')*'", "''");
        var noBlock = System.Text.RegularExpressions.Regex.Replace(withoutStrings,
            @"/\*[\s\S]*?\*/", " ", System.Text.RegularExpressions.RegexOptions.None);
        var noLine = System.Text.RegularExpressions.Regex.Replace(noBlock,
            @"//[^\n]*", " ");
        return noLine;
    }

    private static string? TryFindSolutionRoot()
    {
        for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir is not null; dir = dir.Parent)
            if (File.Exists(Path.Combine(dir.FullName, "IdealBridge.sln")))
                return dir.FullName;
        return null;
    }

    private static string SolutionRoot() =>
        TryFindSolutionRoot() ?? throw new InvalidOperationException("IdealBridge.sln یافت نشد (اجرای Artifact-only).");

    [Fact]
    public void Repositories_Never_Return_Silent_Empty_Results()
    {
        // هیچ Repository نباید در مسیر خطا/عدم پشتیبانی، آرایهٔ خالی برگرداند — باید خطا پرتاب شود.
        var dir = Path.Combine(SolutionRoot(), "src", "IdealBridge.Infrastructure", "Repositories");
        var offenders = Directory.GetFiles(dir, "*.cs")
            .Where(f => Regex.IsMatch(File.ReadAllText(f), @"Array\.Empty\s*<|new\s+\w+\[\s*0\s*\]\s*;"))
            .Select(Path.GetFileName)
            .ToList();
        Assert.True(offenders.Count == 0,
            "Repositoryها نباید خروجی خالی بی‌صدا برگردانند (رفتار مجاز: پرتاب DataAccessUnavailableException). موارد: " + string.Join(", ", offenders));
    }

    [Fact]
    public void No_Stored_Procedure_Execution_Path_Exists_Anywhere()
    {
        // هیچ کدی در src نباید SP صدا بزند یا دستور از نوع StoredProcedure بسازد؛
        // تنها استثنا: ReadOnlyCommandGuard که CommandType.StoredProcedure را «رد» می‌کند.
        var srcDir = Path.Combine(SolutionRoot(), "src");
        var offenders = new List<string>();
        foreach (var file in Directory.GetFiles(srcDir, "*.cs", SearchOption.AllDirectories))
        {
            var name = Path.GetFileName(file);
            var src = StripComments(File.ReadAllText(file));
            if (name == "ReadOnlyCommandGuard.cs") continue;   // گارد SP را می‌بندد؛ نامش را می‌شناسد
            if (src.Contains("QuerySpAsync", StringComparison.Ordinal) ||
                src.Contains("CommandType.StoredProcedure", StringComparison.Ordinal))
                offenders.Add(name);
        }
        Assert.True(offenders.Count == 0,
            "مسیر اجرای SP باید به‌کلی حذف بماند. یافت‌شده در: " + string.Join(", ", offenders));
    }

    [Fact]
    public void Core_Repositories_All_Receive_Central_Policy()
    {
        // ۹ مخزن هسته (به‌جز BaseInfo که جداول مرجعش بیرون از نقشهٔ سیاست‌اند)
        // باید IDataAccessPolicy مرکزی را در سازنده بگیرند — نه منطق محلی حالت.
        var path = Path.Combine(SolutionRoot(), "src", "IdealBridge.Infrastructure", "Repositories", "Repositories.cs");
        var src = File.ReadAllText(path);
        var policyCtors = Regex.Matches(src, @"IDataAccessPolicy\s+policy").Count;
        // در Repositories.cs هشت مخزن policy می‌گیرند (شخص/کاربر/مکالمه/پروژه/یادآوری/انبار/محصول/سفارش)؛
        // CompanyRepository در فایل جداگانه است و BaseInfo عمداً بدون سیاست است.
        Assert.True(policyCtors >= 8,
            $"انتظار >=۸ سازندهٔ دارای policy در Repositories.cs، یافت شد: {policyCtors}");

        var company = File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(path)!, "CompanyRepository.cs"));
        Assert.Contains("IDataAccessPolicy", company, StringComparison.Ordinal);
        Assert.DoesNotContain("MapCompanyLegacy", company, StringComparison.Ordinal);
    }

    [Fact]
    public void IdealDb_Has_No_Sp_Path_And_Guard_Covers_All_Execution()
    {
        var idealDb = StripComments(File.ReadAllText(Path.Combine(
            SolutionRoot(), "src", "IdealBridge.Infrastructure", "Database", "IdealDb.cs")));
        Assert.DoesNotContain("QuerySpAsync", idealDb, StringComparison.Ordinal);
        Assert.DoesNotContain("CommandType.StoredProcedure", idealDb, StringComparison.Ordinal);
        // هر دو مسیر اجرا (QueryOnAsync + CountAsync) باید گارد شوند؛
        // QueryAsync به QueryOnAsync واگذار می‌کند (فقط یک مسیر اجرای واقعی برای کوئری سطری).
        var guardCalls = Regex.Matches(idealDb, @"if \(_enforceGuard\) ReadOnlyCommandGuard\.Validate").Count;
        Assert.True(guardCalls >= 2, $"Expected >=2 guard calls, found {guardCalls}");
    }
}
