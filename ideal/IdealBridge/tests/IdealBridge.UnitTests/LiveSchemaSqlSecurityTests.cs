using System.Data;
using System.Text.RegularExpressions;
using IdeaSchemaDump;
using IdealBridge.Infrastructure.Database;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های امنیتی ساختاری فاز ۱۲.۵ — روی «کل مجموعه» کوئری‌های فراداده
/// (LiveSchemaSql.All) اعمال می‌شوند، نه فقط چند نمونه. هر کوئری جدید
/// باید خودکار از همین تست‌ها بگذرد:
///   ۱) تک‌دستوری SELECT خواندنی — تأیید مستقل با ReadOnlyCommandGuard؛
///   ۲) هیچ «متن تعریف ماژول» (sys.sql_modules / OBJECT_DEFINITION / sp_helptext)؛
///   ۳) هیچ محدودیت به یک Schema خاص (schema_id = 1 / SCHEMA_ID('dbo'))؛
///   ۴) منبع هر FROM/JOIN فقط نمای کاتالوگ sys.* است (صفر خواندن جدول/ویوی
///      کسب‌وکار = صفر دادهٔ واقعی)؛
///   ۵) هیچ نمای DMV/آماری (sys.dm_*) — یعنی بدون شمارش سطر/توزیع داده؛
///   ۶) هیچ خواندن مستقیم جداول CDC (cdc.change_tables) و هیچ cdc.fn_*؛
///   ۷) تمام کوئری‌ها در فهرست‌های All و Named ثبت‌اند (قفل ثبت).
/// </summary>
public class LiveSchemaSqlSecurityTests
{
    private static string? NameOf(string sql)
    {
        foreach (var (key, s) in LiveSchemaSql.Named)
            if (ReferenceEquals(s, sql) || s == sql) return key;
        return null;
    }

    // ─── ۱) گارد مشترک با سرویس — همهٔ کوئری‌ها فقط-خواندنی‌اند ───

    [Fact]
    public void Every_Query_Passes_The_Shared_ReadOnlyCommandGuard()
    {
        foreach (var sql in LiveSchemaSql.All)
        {
            var name = NameOf(sql) ?? "<unregistered>";
            var ex = Record.Exception(() => ReadOnlyCommandGuard.Validate(sql, CommandType.Text));
            Assert.Null(ex);   // اگر شکست خورد، نام کوئری در پیام تست می‌آید
            if (ex is not null) _ = name; // نگه‌دارندهٔ نام برای پیام خطا در شکست
        }
    }

    [Fact]
    public void Every_Query_Starts_With_Select_And_Has_No_Batch_Separator()
    {
        foreach (var sql in LiveSchemaSql.All)
        {
            Assert.StartsWith("SELECT", sql.TrimStart(), StringComparison.OrdinalIgnoreCase);
            Assert.DoesNotContain(";\n", sql, StringComparison.Ordinal);
            Assert.DoesNotContain(";\r", sql, StringComparison.Ordinal);
        }
    }

    // ─── ۲) صفر متن تعریف ماژول (الزام فاز ۱۲.۵) ───

    [Theory]
    [InlineData("sql_modules")]
    [InlineData("OBJECT_DEFINITION")]
    [InlineData("sp_helptext")]
    public void No_Sql_Module_Definition_Is_Ever_Queried(string forbidden)
    {
        foreach (var sql in LiveSchemaSql.All)
            Assert.DoesNotContain(forbidden, sql, StringComparison.OrdinalIgnoreCase);
    }

    // ─── ۳) همهٔ Schemaها — نه فقط dbo ───

    [Theory]
    [InlineData("schema_id = 1")]
    [InlineData("schema_id=1")]
    [InlineData("SCHEMA_ID('dbo')")]
    [InlineData("SCHEMA_ID(N'dbo')")]
    [InlineData("schema_name = N'dbo'")]
    public void No_Query_Is_Restricted_To_A_Single_Schema(string pattern)
    {
        foreach (var sql in LiveSchemaSql.All)
            Assert.DoesNotContain(pattern, sql, StringComparison.OrdinalIgnoreCase);
    }

    // ─── ۴) منبع‌ها فقط نمای کاتالوگ sys.* ───

    private static readonly Regex SourcePattern =
        new(@"(?is)\b(?:FROM|JOIN)\s+([^\s(\r\n]+)", RegexOptions.Compiled);

    [Fact]
    public void Every_From_Or_Join_Source_Is_A_System_Catalog_View()
    {
        foreach (var sql in LiveSchemaSql.All)
        {
            foreach (Match m in SourcePattern.Matches(sql))
            {
                var target = m.Groups[1].Value;
                Assert.True(
                    target.StartsWith("sys.", StringComparison.OrdinalIgnoreCase),
                    $"منبع غیرسیستمی: «{target}» — فقط sys.* مجاز است");
            }
        }
    }

    [Fact]
    public void No_Business_Table_Is_Ever_Read()
    {
        // نمونه‌های جدول کسب‌وکار Ideal — هیچ‌کدام نباید منبع FROM/JOIN باشند
        // (تست sys.* بودن را کلی قفل کرده؛ این تست شاهد صریح برای حساس‌ترین‌هاست)
        var businessTables = new[]
        {
            "CrmCompany", "CrmCompanyPersons", "Users", "CrmConversation", "CrmProjects",
            "WSOrder", "WSPreOrder", "WSProducts", "WsWareHouse", "CrmUserTasks",
        };
        foreach (var sql in LiveSchemaSql.All)
            foreach (Match m in SourcePattern.Matches(sql))
            {
                var target = m.Groups[1].Value;
                foreach (var b in businessTables)
                    Assert.False(
                        target.StartsWith(b, StringComparison.OrdinalIgnoreCase),
                        $"منبع غیرمجاز شامل جدول کسب‌وکار: «{target}» (شبیه {b})");
            }
    }

    // ─── ۵) بدون آمار/شمارش سطر/توزیع داده ───

    [Theory]
    [InlineData("sys.dm_")]
    [InlineData("COUNT(*)")]
    [InlineData("partition_stats")]
    [InlineData("sysindexes")]
    [InlineData("sp_spaceused")]
    public void No_Row_Count_Or_Data_Distribution_Is_Queried(string forbidden)
    {
        foreach (var sql in LiveSchemaSql.All)
            Assert.DoesNotContain(forbidden, sql, StringComparison.OrdinalIgnoreCase);
    }

    // ─── ۶) CDC فقط از فراداده — نه جداول تغییرات و نه توابع Enumerate ───

    [Theory]
    [InlineData("cdc.change_tables")]
    [InlineData("cdc.fn_")]
    [InlineData("sys.fn_cdc")]
    public void Cdc_Is_Inspected_Only_Via_Object_Metadata(string forbidden)
    {
        foreach (var sql in LiveSchemaSql.All)
            Assert.DoesNotContain(forbidden, sql, StringComparison.OrdinalIgnoreCase);
    }

    // ─── ۷) قفل ثبت — کوئری جدید باید به هر دو فهرست برسد ───

    [Fact]
    public void All_Queries_Are_Registered_In_Both_Lists()
    {
        Assert.Equal(LiveSchemaSql.Named.Length, LiveSchemaSql.All.Length);
        foreach (var (key, sql) in LiveSchemaSql.Named)
        {
            Assert.False(string.IsNullOrWhiteSpace(key));
            Assert.Contains(sql, LiveSchemaSql.All);
        }
    }

    [Fact]
    public void Block_Coverage_Meets_Phase_12_5_Minimum()
    {
        // فاز ۱۲.۵ حداقل ۲۰ بلوک JSON می‌خواهد؛ کوئری‌های فراداده باید
        // دست‌کم همهٔ حوزه‌های لازم را پوشش دهند (۲۴+ مورد ثبت‌شده).
        Assert.True(LiveSchemaSql.All.Length >= 24,
            $"پوشش ناکافی: {LiveSchemaSql.All.Length} کوئری — حداقل ۲۴");
    }
}
