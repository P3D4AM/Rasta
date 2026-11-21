using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Infrastructure.Database;
using IdealBridge.Infrastructure.Repositories;
using Xunit;

namespace IdealBridge.UnitTests;

/// <summary>
/// تست‌های سیاست مرکزی دسترسی به داده (فاز ۱۱):
/// پیش‌فرض Table، غیرفعال‌بودن ساختاری SP، رد واضح حالت Sp،
/// و Blocked با خطای شفاف به‌جای آرایهٔ خالی بی‌صدا.
/// </summary>
public class DataAccessPolicyTests
{
    private static IdealBridgeOptions Options(string mode) => new() { DataAccessMode = mode };

    private static SchemaReport HealthyReport() => new()
    {
        ConnectionOk = true,
        TablesAvailable = DataAccessPolicyEntityTables(),
    };

    private static List<string> DataAccessPolicyEntityTables() => new()
    {
        "CrmCompany", "CrmCompanyPersons", "Users", "CrmConversation", "CrmProjects", "CrmUserTasks",
        "WsWareHouse", "WSProducts", "WSOrder", "WSPreOrder",
    };

    [Fact]
    public void Default_Mode_Is_Table()
    {
        Assert.Equal("Table", new IdealBridgeOptions().DataAccessMode);
        Assert.Equal("table", new DataAccessPolicy(new IdealBridgeOptions()).ConfiguredMode);
    }

    [Fact]
    public void Stored_Procedures_Are_Structurally_Unsupported()
    {
        // ثابت ساختاری این نسخه: هیچ مسیر اجرای SP وجود ندارد (حتی اگر پیکربندی هم بخواهد)
        Assert.False(new DataAccessPolicy(Options("Table")).StoredProceduresSupported);
        Assert.False(DataAccessPolicy.SpExecutionSupported);
    }

    [Theory]
    [InlineData("Sp")]
    [InlineData("sp")]
    [InlineData("SP")]
    public void Sp_Mode_Is_Rejected_At_Construction(string mode)
    {
        // پیکربندی Sp باید در راه‌اندازی با پیام واضح شکست بخورد — نه سقوط بی‌صدا به حالت دیگر
        var ex = Assert.Throws<InvalidOperationException>(() => new DataAccessPolicy(Options(mode)));
        Assert.Contains("Stored Procedure", ex.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("غیرفعال", ex.Message, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("Everything")]
    [InlineData("")]
    [InlineData("  ")]
    public void Invalid_Mode_Is_Rejected(string mode)
    {
        Assert.Throws<InvalidOperationException>(() => new DataAccessPolicy(Options(mode)));
    }

    [Fact]
    public void Auto_Is_Accepted_And_Equivalent_To_Table()
    {
        var policy = new DataAccessPolicy(Options("Auto"));
        Assert.Equal("auto", policy.ConfiguredMode);
        policy.ApplySchemaReport(HealthyReport());
        Assert.Equal(DataAccessMode.Table, policy.Resolve("Companies"));
        // Auto هرگز Sp برنمی‌گرداند — در این نسخه حتی اگر SP موجود هم باشد
        Assert.All(policy.CurrentModes().Values, m => Assert.NotEqual(DataAccessMode.Sp, m.Mode));
    }

    [Fact]
    public void Resolve_Returns_Table_Before_First_Probe_Conservatively()
    {
        var policy = new DataAccessPolicy(Options("Table"));
        Assert.Equal(DataAccessMode.Table, policy.Resolve("Companies"));
    }

    [Fact]
    public void Missing_Table_Blocks_Entity_With_Clear_Reason()
    {
        var policy = new DataAccessPolicy(Options("Table"));
        var report = HealthyReport();
        report.TablesAvailable.Remove("CrmCompany");

        policy.ApplySchemaReport(report);

        var ex = Assert.Throws<DataAccessUnavailableException>(() => policy.Resolve("Companies"));
        Assert.Equal("Companies", ex.Entity);
        Assert.Contains("CrmCompany", ex.Message, StringComparison.Ordinal);
        Assert.Contains("یافت نشد", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void Missing_Columns_Block_Entity_With_Column_Names()
    {
        var policy = new DataAccessPolicy(Options("Table"));
        var report = HealthyReport();
        report.ColumnsMissing["CrmCompany"] = new List<string> { "cmpName", "cmpCode" };

        policy.ApplySchemaReport(report);

        var ex = Assert.Throws<DataAccessUnavailableException>(() => policy.Resolve("Companies"));
        Assert.Contains("cmpName", ex.Message, StringComparison.Ordinal);
        Assert.Contains("cmpCode", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void ApplySchemaReport_Replaces_Previous_State()
    {
        var policy = new DataAccessPolicy(Options("Table"));
        policy.ApplySchemaReport(HealthyReport());
        Assert.Equal(DataAccessMode.Table, policy.Resolve("Companies"));

        // پس از تغییر اسکیما (مثلاً /health/db تازه) وضعیت تازه جایگزین می‌شود
        var broken = HealthyReport();
        broken.TablesAvailable.Remove("Users");
        policy.ApplySchemaReport(broken);
        Assert.Throws<DataAccessUnavailableException>(() => policy.Resolve("Users"));
        Assert.Equal(DataAccessMode.Table, policy.Resolve("Companies"));
    }

    [Fact]
    public void All_Ten_Core_Entities_Are_Covered()
    {
        var policy = new DataAccessPolicy(Options("Table"));
        policy.ApplySchemaReport(HealthyReport());
        Assert.Equal(10, policy.CurrentModes().Count);
        Assert.All(policy.CurrentModes().Values, m => Assert.Equal(DataAccessMode.Table, m.Mode));
    }
}
