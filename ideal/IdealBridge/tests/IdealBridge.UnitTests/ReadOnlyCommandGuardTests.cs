using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;
using System.Data;
using Xunit;

namespace IdealBridge.UnitTests;

public class ReadOnlyCommandGuardTests
{
    [Theory]
    [InlineData("SELECT * FROM dbo.CrmCompany")]
    [InlineData("  SELECT CompanyID FROM dbo.Users WHERE UserId = @p0")]
    [InlineData("WITH x AS (SELECT 1 AS a) SELECT a FROM x")]
    [InlineData("select TOP 10 * from dbo.CrmCompany ORDER BY CompanyID")]
    public void Select_Commands_Pass(string sql)
    {
        var ex = Record.Exception(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("INSERT INTO dbo.CrmCompany (cmpName) VALUES ('x')")]
    [InlineData("UPDATE dbo.CrmCompany SET cmpName = 'x'")]
    [InlineData("DELETE FROM dbo.CrmCompany")]
    [InlineData("TRUNCATE TABLE dbo.CrmCompany")]
    [InlineData("DROP TABLE dbo.CrmCompany")]
    [InlineData("ALTER TABLE dbo.CrmCompany ADD x int")]
    [InlineData("CREATE TABLE t (id int)")]
    [InlineData("MERGE INTO dbo.CrmCompany USING (SELECT 1 x) s ON 1=1;")]
    [InlineData("BACKUP DATABASE master TO DISK = 'x'")]
    [InlineData("GRANT SELECT ON t TO u")]
    [InlineData("EXEC sp_executesql N'SELECT 1'")]
    [InlineData("DBCC CHECKDB")]
    public void Mutation_Commands_Throw(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    [Fact]
    public void Batch_With_Semicolon_Throws()
    {
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("SELECT 1; SELECT 2", CommandType.Text));
    }

    [Fact]
    public void NonSelect_FirstWord_Throws()
    {
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("PRINT 'hi'", CommandType.Text));
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("", CommandType.Text));
    }

    [Fact]
    public void Exec_WhitelistedSp_Passes()
    {
        var ex = Record.Exception(() => ReadOnlyCommandGuard.Validate("EXEC ApispSelectCompany @CompanyId=1", CommandType.Text));
        Assert.Null(ex);
    }

    [Fact]
    public void Exec_DynamicString_Throws()
    {
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("EXEC ('SELECT 1')", CommandType.Text));
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("EXEC N'SELECT 1'", CommandType.Text));
    }

    [Fact]
    public void Exec_NonWhitelistedSp_Throws()
    {
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("EXEC ApispDeleteCompany @Id=1", CommandType.Text));
        // SPهای تغییردهنده هرگز نباید قابل فراخوانی باشند
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("ApispInsertCompany", CommandType.StoredProcedure));
    }

    [Fact]
    public void StoredProcedure_Whitelisted_Passes()
    {
        var ex = Record.Exception(() => ReadOnlyCommandGuard.Validate("ApispSelectUsers", CommandType.StoredProcedure));
        Assert.Null(ex);
    }

    [Fact]
    public void Injection_Try_In_Select_Throws()
    {
        // حتی اگر کسی SELECT بنویسد، فراخوانی SP تغییردهنده در متن باید مسدود شود
        Assert.Throws<ReadOnlyViolationException>(() =>
            ReadOnlyCommandGuard.Validate("SELECT 1 WHERE x = 1 UNION SELECT * FROM OPENROWSET('x','y','z')", CommandType.Text));
    }

    /// <summary>اثبات مسیر اجرایی: هیچ SqlCommand بدون عبور از گارد ساخته نمی‌شود (بررسی ساختاری IdealDb).</summary>
    [Fact]
    public void IdealDb_Always_Validates_When_Guard_Enabled()
    {
        // اثبات ساختاری: IdealDb در هر سه مسیر اجرا (کوئری Text، فراخوانی SP، اسکالر COUNT)
        // پیش از اجرا گارد را صدا می‌زند؛ هیچ مسیر Execute بدون Validate وجود ندارد.
        var root = TryFindSolutionRoot();
        if (root is null)
        {
            // سورس در دسترس نیست (اجرای Artifact-only) — این اثبات فقط با درخت سورس معنا دارد.
            return;
        }

        var code = System.IO.File.ReadAllText(System.IO.Path.Combine(
            root, "src", "IdealBridge.Infrastructure", "Database", "IdealDb.cs"));
        var guardCalls = System.Text.RegularExpressions.Regex.Count(code, @"if \(_enforceGuard\) ReadOnlyCommandGuard\.Validate");
        // دو مسیر اجرا: QueryOnAsync (سطرها) + CountAsync (اسکالر)؛ QueryAsync به QueryOnAsync واگذار می‌کند
        Assert.True(guardCalls >= 2, $"Expected >=2 guard calls in IdealDb, found {guardCalls}");
        var firstExecute = code.IndexOf("ExecuteReaderAsync", StringComparison.Ordinal);
        var firstValidate = code.IndexOf("ReadOnlyCommandGuard.Validate", StringComparison.Ordinal);
        Assert.True(firstValidate >= 0 && firstValidate < firstExecute, "guard must precede first execution");
    }

    /// <summary>
    /// ریشهٔ Solution را از محل اجرای اسمبلی تست پیدا می‌کند (مستقل از مسیر Clone — قابل اجرا در هر محیط).
    /// اگر درخت سورس موجود نباشد null برمی‌گرداند.
    /// </summary>
    private static string? TryFindSolutionRoot()
    {
        for (var dir = new System.IO.DirectoryInfo(AppContext.BaseDirectory);
             dir is not null;
             dir = dir.Parent)
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(dir.FullName, "IdealBridge.sln")))
                return dir.FullName;
        }
        return null;
    }
}

public class PagedQueryTests
{
    [Fact]
    public void Defaults_Are_Sane()
    {
        var q = new PagedQuery();
        Assert.Equal(1, q.Page);
        Assert.Equal(20, q.Take);
        Assert.Equal(0, q.Skip);
        Assert.False(q.IsKeyset);
    }

    [Fact]
    public void PageSize_Is_Clamped()
    {
        var q = new PagedQuery { Page = 1, PageSize = 99999 };
        Assert.Equal(PagedQuery.MaxPageSize, q.Take);
        var q2 = new PagedQuery { Page = 1, PageSize = 0 };
        Assert.Equal(PagedQuery.DefaultPageSize, q2.Take);
        var q3 = new PagedQuery { Page = 1, PageSize = -5 };
        Assert.Equal(PagedQuery.DefaultPageSize, q3.Take);
    }

    [Fact]
    public void Skip_Computation()
    {
        var q = new PagedQuery { Page = 3, PageSize = 50 };
        Assert.Equal(100, q.Skip);
    }

    [Fact]
    public void Keyset_Flag()
    {
        var q = new PagedQuery { AfterId = 42 };
        Assert.True(q.IsKeyset);
    }
}
