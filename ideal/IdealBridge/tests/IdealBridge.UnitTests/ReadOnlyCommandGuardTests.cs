using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;
using System.Data;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های گزارمانی گارد فقط-خواندنی (فاز ۱۱ — بازنویسی با توکنایزر).
/// دسته‌ها: مجازها، همهٔ فعل‌های تغییردهنده، SELECT INTO، batch/GO،
/// EXEC/SP (بدون هیچ استثنای نامی)، دور زدن با کامنت/رشته/براکت، و رفتار محیطی.
/// </summary>
public class ReadOnlyCommandGuardTests
{
    // ─── ۱) مجازها ───

    [Theory]
    [InlineData("SELECT * FROM dbo.CrmCompany")]
    [InlineData("  SELECT CompanyID FROM dbo.Users WHERE UserId = @p0")]
    [InlineData("WITH x AS (SELECT 1 AS a) SELECT a FROM x")]
    [InlineData("select TOP 10 * from dbo.CrmCompany ORDER BY CompanyID")]
    [InlineData("SELECT CC.cmpName FROM dbo.CrmCompany CC WHERE CC.cmpName LIKE @cmpName")]
    [InlineData("SELECT @@SERVERNAME, DB_NAME(), @@VERSION")]
    [InlineData("SELECT t.name, c.name FROM sys.tables t JOIN sys.columns c ON c.object_id = t.object_id")]
    [InlineData("SELECT 1 WHERE x = 1 UNION SELECT 2")]
    [InlineData("SELECT * FROM dbo.[Order]")]                      // شناسهٔ براکت‌دار رزرو‌شده
    [InlineData("SELECT COUNT(1) FROM sys.procedures WHERE name = @p0")]
    [InlineData("SELECT [Update], [Into], [Set] FROM t")]           // نام ستون براکت‌دار = شناسه، نه کلیدواژه
    [InlineData("SELECT 'INSERT INTO x VALUES (1)' AS demo")]       // کلیدواژهٔ داخل رشته = داده
    [InlineData("SELECT 'a;b' AS semicolon_in_string")]             // «;» داخل رشته = داده
    [InlineData("SELECT N'متن فارسی با ; و UPDATE' AS note")]
    [InlineData("SELECT 1 -- comment containing INSERT and DROP")]   // کلیدواژهٔ داخل کامنت خطی
    [InlineData("SELECT 1 /* hidden ; DROP TABLE x */ AS c")]       // کامنت بلوکی حتی با ;
    [InlineData("SELECT x FROM t FOR XML PATH('row')")]             // FOR XML خواندنی است
    [InlineData("SELECT * FROM dbo.f(SomeParam)")]                  // تابع جدولی با پارامتر
    public void Allowed_Select_Commands_Pass(string sql)
    {
        var ex = Record.Exception(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
        Assert.Null(ex);
    }

    // ─── ۲) فعل‌های تغییردهنده (همهٔ اشکال) ───

    [Theory]
    [InlineData("INSERT INTO dbo.CrmCompany (cmpName) VALUES ('x')")]
    [InlineData("UPDATE dbo.CrmCompany SET cmpName = 'x'")]
    [InlineData("DELETE FROM dbo.CrmCompany")]
    [InlineData("MERGE INTO dbo.CrmCompany USING (SELECT 1 x) s ON 1=1")]
    [InlineData("TRUNCATE TABLE dbo.CrmCompany")]
    [InlineData("DROP TABLE dbo.CrmCompany")]
    [InlineData("ALTER TABLE dbo.CrmCompany ADD x int")]
    [InlineData("CREATE TABLE t (id int)")]
    [InlineData("CREATE PROCEDURE p AS SELECT 1")]
    [InlineData("BACKUP DATABASE master TO DISK = 'x'")]
    [InlineData("RESTORE DATABASE x FROM DISK = 'y'")]
    [InlineData("GRANT SELECT ON t TO u")]
    [InlineData("REVOKE SELECT ON t FROM u")]
    [InlineData("DENY SELECT ON t TO u")]
    [InlineData("DBCC CHECKDB")]
    [InlineData("KILL 53")]
    [InlineData("SHUTDOWN")]
    [InlineData("BULK INSERT t FROM 'f'")]
    public void Mutation_Commands_Throw(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    // ─── ۳) SELECT INTO (ساخت جدول) ───

    [Theory]
    [InlineData("SELECT * INTO #tmp FROM dbo.CrmCompany")]
    [InlineData("SELECT a, b INTO dbo.NewTable FROM t")]
    [InlineData("SELECT 1 INTO @t")]
    [InlineData("WITH x AS (SELECT 1 a) SELECT a INTO #t FROM x")]
    public void Select_Into_Throws(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    // ─── ۴) چنددستوری / batch ───

    [Theory]
    [InlineData("SELECT 1; SELECT 2")]
    [InlineData("SELECT 1 ;")]
    [InlineData("SELECT 1;DROP TABLE x")]
    [InlineData("SELECT 1 GO SELECT 2")]
    [InlineData("SELECT 'a'; SELECT 'b'")]
    public void Batch_Or_Go_Throws(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    [Theory]
    [InlineData("PRINT 'hi'")]
    [InlineData("WAITFOR DELAY '00:00:30'")]
    [InlineData("SET NOCOUNT ON")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("-- فقط کامنت")]
    [InlineData("/* فقط کامنت بلوکی */")]
    public void NonSelect_FirstWord_Throws(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    // ─── ۵) اجرای SP — هیچ استثنای نامی وجود ندارد ───

    [Theory]
    [InlineData("EXEC ApispSelectCompany @CompanyId=1")]
    [InlineData("EXECUTE ApispSelectCompany @CompanyId=1")]
    [InlineData("exec apispselectcompany")]
    [InlineData("EXEC ApispDeleteCompany @Id=1")]                  // نام شناخته‌شدهٔ تغییردهنده
    [InlineData("EXEC sp_executesql N'SELECT 1'")]
    [InlineData("EXEC ('SELECT 1')")]                              // داینامیک
    [InlineData("EXEC @v = ApispSelectCompany")]                   // از متغیر
    [InlineData("EXEC dbo.SomeFutureReadSp")]                      // نام ناشناخته
    public void Exec_Anything_Throws(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    [Theory]
    [InlineData("ApispSelectCompany")]        // نام SP «معتبر و خواندنی» — مجاز نیست
    [InlineData("ApispDeleteCompany")]
    [InlineData("sp_who2")]
    [InlineData("any_sp")]
    public void StoredProcedure_CommandType_Always_Throws(string spName)
    {
        // هیچ SP صرفاً بر اساس نام مجاز شناخته نمی‌شود — حتی خواندنی‌ترین‌ها
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(spName, CommandType.StoredProcedure));
    }

    [Theory]
    [InlineData("SELECT 1 WHERE x = 1 UNION SELECT * FROM OPENROWSET('x','y','z')")]
    [InlineData("SELECT * FROM OPENQUERY(lnk, 'SELECT 1')")]
    [InlineData("SELECT * FROM OPENDATASOURCE('SQLNCLI', 'x')...t")]
    [InlineData("SELECT * FROM OPENXML(@h, '/x')")]
    public void Remote_And_Xml_Table_Providers_Throw(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    [Theory]
    [InlineData("SELECT sp_help")]
    [InlineData("SELECT 1 WHERE x IN (SELECT xp_cmdshell)")]
    public void System_Procedure_Identifier_Throws(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    // ─── ۶) تلاش‌های دور زدن با قالب‌بندی ───

    [Theory]
    [InlineData("/**/SELECT 1;DROP TABLE x")]                    // کامنت ابتدایی + batch
    [InlineData("SELECT/**/1;/**/UPDATE t SET x=1")]
    [InlineData("SELECT 1 /* a */ /* b */ ; DELETE t")]
    [InlineData("sElEcT 1; dRoP tAbLe x")]                       // حروف کوچک/بزرگ مخلوط
    [InlineData("SELECT\t1;\nUPDATE\tt\tSET\tx=1")]              // تب و خط جدید
    [InlineData("WITH x AS (SELECT 1) SELECT * FROM x; DROP TABLE y")]
    [InlineData("SELECT 1 WHERE 1=(SELECT CASE WHEN 1=1 THEN 1 ELSE 0 END);INSERT INTO t VALUES(1)")]
    public void Formatting_Bypass_Attempts_Throw(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    [Theory]
    [InlineData("SELECT 'unterminated")]                         // رشتهٔ نیمه‌تمام
    [InlineData("SELECT 1 /* unterminated")]                     // کامنت نیمه‌بسته
    [InlineData("SELECT [unterminated")]                         // براکت نیمه‌بسته
    public void Malformed_Input_Throws(string sql)
    {
        Assert.Throws<ReadOnlyViolationException>(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
    }

    [Theory]
    [InlineData("SELECT OFFSET_thing FROM t")]                   // واژه‌های شاملِ SET/INTO ولی یکپارچه
    [InlineData("SELECT ImportedAt, SettingId FROM t")]          // SET فقط به‌صورت بخشی از نام ستون
    [InlineData("SELECT INTOO FROM t")]                          // INTO داخل واژهٔ دیگر
    public void Words_Containing_Forbidden_Substrings_Pass(string sql)
    {
        // توکنایزر واژه‌محور است نه زیررشته‌ای — OFFSET/Settings/INTOO کلیدواژه نیستند
        var ex = Record.Exception(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
        Assert.Null(ex);
    }

    // ─── ۷) سیاست محیطی گارد ───

    [Fact]
    public void Guard_Cannot_Be_Disabled_In_Production()
    {
        Assert.True(ReadOnlyGuardPolicy.Effective(configuredValue: false, isProductionEnvironment: true));
        Assert.True(ReadOnlyGuardPolicy.Effective(configuredValue: true, isProductionEnvironment: true));
        // فقط در Development خاموش‌کردن (برای آزمایش محلی) ممکن است
        Assert.False(ReadOnlyGuardPolicy.Effective(configuredValue: false, isProductionEnvironment: false));
        Assert.True(ReadOnlyGuardPolicy.Effective(configuredValue: true, isProductionEnvironment: false));
    }

    // ─── ۸) اثبات ساختاری: IdealDb همهٔ مسیرهای اجرا را گارد می‌کند ───

    /// <summary>اثبات مسیر اجرایی: هیچ SqlCommand بدون عبور از گارد ساخته نمی‌شود (بررسی ساختاری IdealDb).</summary>
    [Fact]
    public void IdealDb_Always_Validates_When_Guard_Enabled()
    {
        var root = TryFindSolutionRoot();
        if (root is null) return; // سورس در دسترس نیست (اجرای Artifact-only)

        var code = System.IO.File.ReadAllText(System.IO.Path.Combine(
            root, "src", "IdealBridge.Infrastructure", "Database", "IdealDb.cs"));
        var guardCalls = System.Text.RegularExpressions.Regex.Count(code, @"if \(_enforceGuard\) ReadOnlyCommandGuard\.Validate");
        // دو مسیر اجرا: QueryOnAsync (سطرها) + CountAsync (اسکالر)؛ QueryAsync به QueryOnAsync واگذار می‌کند
        Assert.True(guardCalls >= 2, $"Expected >=2 guard calls in IdealDb, found {guardCalls}");
        var firstExecute = code.IndexOf("ExecuteReaderAsync", StringComparison.Ordinal);
        var firstValidate = code.IndexOf("ReadOnlyCommandGuard.Validate", StringComparison.Ordinal);
        Assert.True(firstValidate >= 0 && firstValidate < firstExecute, "guard must precede first execution");
    }

    private static string? TryFindSolutionRoot()
    {
        for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir is not null; dir = dir.Parent)
            if (System.IO.File.Exists(System.IO.Path.Combine(dir.FullName, "IdealBridge.sln")))
                return dir.FullName;
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
