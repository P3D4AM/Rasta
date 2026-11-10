using System.Data;
using System.Data.Common;
using IdealBridge.Application.Interfaces;
using IdealBridge.Infrastructure.Database;
using Microsoft.Extensions.Logging;

namespace IdealBridge.Infrastructure.Database;

/// <summary>
/// کاوشگر فرادادهٔ فقط-خواندنی (sys.tables / sys.columns / sys.parameters / sys.procedures).
/// گزارش می‌دهد کدام جدول‌ها/ستون‌های موردانتظار IdealBridge (بر اساس اسکیمای مرجع 3.1.18.187)
/// در دیتابیس واقعی (مثلاً 3.1.16) موجودند و کدام SPها با امضای موردانتظار در دسترس‌اند.
/// </summary>
public class SchemaProbe : ISchemaProbe
{
    private readonly IDbConnectionFactory _factory;
    private readonly ILogger<SchemaProbe> _logger;
    private readonly DataAccessModeSelector _modeSelector;

    /// <summary>ستون‌های موردنیاز هر جدول (فقط ستون‌هایی که IdealBridge در حالت Table می‌خواند).</summary>
    public static readonly Dictionary<string, string[]> RequiredTableColumns = new(StringComparer.OrdinalIgnoreCase)
    {
        ["CrmCompany"] = new[] { "CompanyID", "cmpNumber", "cmpCode", "cmpName", "cmpNameEng", "cmpTitleId", "cmpFame", "cmpActivityType", "cmpGroupId", "cmpSubGroupId", "cmpGroupIdII", "cmpGroupIdIII", "cmpGroupIdIV", "cmpTypeId", "cmpPresentationId", "cmpPreTel", "cmpTel", "cmpTelUpTo", "cmpTelDesc", "cmpPreTelII", "cmpTelII", "cmpTelUpToII", "cmpTelIIDesc", "cmpMobile", "cmpFax", "cmpFaxDesc", "cmpCountryId", "cmpProvinceId", "cmpCityId", "cmpAddress", "cmpAddressDesc", "cmpZipCode", "cmpPostBox", "cmpWebSite", "cmpEmail", "cmpInteresting", "cmpSpecialPoint", "cmpDescription", "RegisterDate", "RegisterDatePersian", "FirstRegisterDate", "UserId", "cmpReferUserId", "cmpRegistrationNumber", "cmpEconomicCode", "cmpNationalCode", "cmpBuyLimit", "cmpAccountNumber", "cmpCoordinateLatitude", "cmpCoordinateLongitude", "cmpCoordinateZoomLevel", "cmpCoordinateLastDate", "cmpIsDraft", "cmpKind", "cmpMainPersonId", "ImportDate", "ImportDateTime", "cmpNameOfficial" },
        ["CrmCompanyPersons"] = new[] { "CompanyPersonID", "prsCompanyId", "prsFName", "prsLName", "prsTitleId", "prsJobId", "prsTypeId", "prsGroupId", "prsSexId", "prsEducationId", "prsDepartmentId", "prsPreTel", "prsTel", "prsTelUpTo", "prsTelDesc", "prsTelII", "prsFax", "prsMobile", "prsWebSite", "prsEmail", "prsEmailII", "prsCountryId", "prsProvinceId", "prsCityId", "prsAddress", "prsZipCode", "prsPostBox", "prsNationalCode", "prsIdentityNumber", "prsFatherName", "prsBirthDate", "prsBirthPlace", "prsIsMarried", "prsMarriageDate", "prsSkill", "prsStudyField", "prsInteresting", "prsSpecialPoint", "prsDescription", "ImportDate", "prsStopSendSms", "prsWorkingOut" },
        ["Users"] = new[] { "UserId", "Row", "FName", "LName", "PersCode", "UserName", "IsAdmin", "IsActive", "UserIsActiveInWebApp", "Mobile", "MobileII", "Tel", "PositionId", "UserGroupId", "NationalCode", "StartDate", "ExpireDate", "Description" },
        ["CrmConversation"] = new[] { "ConversationID", "cnvsProjectId", "cnvsCompanyId", "cnvsDateTime", "cnvsDate", "cnvsDay", "cnvsTime", "cnvsTopicId", "cnvsSubject", "cnvsPersonId", "cnvsUserId", "cnvsReferUserId", "cnvsReferDesc", "cnvsStatusId", "cnvsPriorityId", "cnvsRemindDateTime", "cnvsRemindOk", "cnvsIsBookMark", "RegisterDate", "RegisterDatePersian", "FirstRegisterDate" },
        ["CrmProjects"] = new[] { "ProjectID", "prjCompanyId", "prjTitle", "prjDesc", "prjStartDateTime", "prjStartDate", "prjStartTime", "prjStarterUserId", "prjIsFinished", "prjFinishedStatusId", "prjFinishedDate", "prjFinishedDateTime", "prjFinishedUserId", "prjGradeId", "prjPriorityId", "prjGroupId", "prjcnvsStatusGroupId", "prjNumRef", "prjNumR", "prjPostFix", "RegisterDate", "RegisterDatePersian", "FirstRegisterDate", "UserId" },
        ["CrmUserTasks"] = new[] { "UserTaskId", "UserTaskDatePersian", "UserTaskDate", "UserTaskTime", "UserTaskTimeEnd", "UserTaskTitle", "UserTaskDescription", "UserTaskPriorityId", "UserTaskGroupId", "UserTaskShowAllarm", "UserTaskDidIt", "UserId", "UserTaskRemindDateTime", "UserTaskIsPublic", "ObjectTypeId", "ObjectId", "UserTaskCompanyIds", "UserTaskRepeatDaily", "UserTaskRepeatWeekly", "UserTaskRepeatMonthly", "UserTaskRepeatYearly", "RegisterDate", "UserTaskDidItDate" },
        ["WsWareHouse"] = new[] { "WareHouseID", "WrhsName", "WrhsCode", "WrhsAddress", "WrhsPreTel", "WrhsTel", "WrhsTelSecond", "WrhsTelThird", "WrhsFax", "WrhsArea", "WrhsPerson", "WrhsDescription", "WrhsDeActive", "OrderView", "RegisterDate" },
        ["WSProducts"] = new[] { "ProductID", "PrdGroupID", "PrdCode", "PrdName", "PrdLatinName", "PrdType", "PrdModel", "PrdColorId", "PrdUnitId", "PrdFirstBarcode", "PrdInActive", "PrdInactiveInSale", "PrdInactiveInBuy", "PrdMinQuantity", "PrdMaxQuantity", "PrdWeight", "RegisterDate", "FirstRegisterDate" },
        ["WSOrder"] = new[] { "OrderID", "OrderOprID", "ordNumber", "ordTitle", "ordDate", "ordDateTime", "ordCompanyId", "ordCompanyPersonId", "ordProjectId", "ordSubject", "ordItemCount", "ordItemsAmount", "ordDiscount", "ordSumAmount", "ordTax", "ordTotalAmount", "ordIsVerified", "ordStatusId", "ordReferUserId", "ordSellerId", "RegisterDate", "FirstRegisterDate" },
        ["WSPreOrder"] = new[] { "PreOrderID", "PreOrderOprID", "pordNumber", "pordTitle", "pordDate", "pordDateTime", "pordCompanyId", "pordCompanyPersonId", "pordProjectId", "pordSubject", "pordItemCount", "pordItemsAmount", "pordDiscount", "pordSumAmount", "pordTax", "pordTotalAmount", "pordIsVerified", "pordStatusId", "pordReferUserId", "RegisterDate", "FirstRegisterDate", "pordChangeStatusDate" },
        ["CrmCompanyAddresses"] = new[] { "CompanyAddressId", "cmpaddCompanyId", "cmpaddTypeId", "cmpaddCityId", "CompanyAddress", "cmpaddDesc", "cmpaddZipCode", "cmpaddPostBox", "cmpaddCoordinateLatitude", "cmpaddCoordinateLongitude", "cmpaddCoordinateZoomLevel", "cmpaddCoordinateLastDate", "RegisterDate" },
    };

    /// <summary>امضای موردانتظار SPها (نام → پارامترها به‌ترتیب) بر اساس CSDL نسخهٔ 3.1.18.187.</summary>
    public static readonly Dictionary<string, string[]> ExpectedSpSignatures = new(StringComparer.OrdinalIgnoreCase)
    {
        ["ApispSelectCompany"] = new[] { "CompanyId", "CmpCode", "CmpNumber", "FromRegisterDate", "ToRegisterDate", "FromFirstRegisterDate", "ToFirstRegisterDate", "LanguageID", "DefaultLanguageID", "CenterId", "CenterCode", "PageNumber", "PageSize" },
        ["ApispSelectCompanyPersons"] = new[] { "CompanyPersonID", "CompanyId", "LanguageID", "DefaultLanguageID", "PageNumber", "PageSize" },
        ["ApispSelectUsers"] = new[] { "UserId", "LanguageID", "DefaultLanguageID" },
        ["ApispSelectConversation"] = new[] { "ConversationID", "ProjectID", "CopmanyID", "LanguageID", "DefaultLanguageID", "CenterId", "CenterCode", "PageNumber", "PageSize" },
        ["ApispSelectProjects"] = new[] { "ProjectID", "CompanyId", "LanguageID", "DefaultLanguageID", "FromRegisterDate", "ToRegisterDate", "FromFirstRegisterDate", "ToFirstRegisterDate", "PageNumber", "PageSize" },
        ["ApispSelectWareHouse"] = new[] { "WrhsDeActive", "LanguageID", "DefaultLanguageID" },
        ["ApispSelectProducts"] = new[] { "ProductID", "PrdGroupID", "PrdCode", "FromRegisterDate", "ToRegisterDate", "FromFirstRegisterDate", "ToFirstRegisterDate", "LanguageID", "DefaultLanguageID", "PageNumber", "PageSize" },
        ["ApispSelectOrder"] = new[] { "OrderID", "ordNumber", "FromOrderDate", "ToOrderDate", "FromRegisterDate", "ToRegisterDate", "FromFirstRegisterDate", "ToFirstRegisterDate", "LanguageID", "DefaultLanguageID", "CenterId", "CenterCode", "PageNumber", "PageSize" },
        ["ApispSelectPreOrder"] = new[] { "PreOrderID", "pordNumber", "FromPreOrderDate", "ToPreOrderDate", "FromRegisterDate", "ToRegisterDate", "FromFirstRegisterDate", "ToFirstRegisterDate", "LanguageID", "DefaultLanguageID", "CenterId", "CenterCode", "PageNumber", "PageSize" },
    };

    public SchemaProbe(IDbConnectionFactory factory, ILogger<SchemaProbe> logger, DataAccessModeSelector modeSelector)
    {
        _factory = factory;
        _logger = logger;
        _modeSelector = modeSelector;
    }

    public async Task<SchemaReport> ProbeAsync(CancellationToken ct = default)
    {
        var report = new SchemaReport { ProbedAt = DateTime.UtcNow };
        try
        {
            await using var con = await _factory.OpenConnectionAsync(ct);

            // اطلاعات سرور/دیتابیس — فقط خواندن فراداده
            await using (var verCmd = con.CreateCommand())
            {
                verCmd.CommandText = "SELECT @@SERVERNAME, DB_NAME(), @@VERSION";
                verCmd.CommandType = CommandType.Text;
                ReadOnlyCommandGuard.Validate(verCmd.CommandText, verCmd.CommandType);
                await using var r = await verCmd.ExecuteReaderAsync(ct);
                if (await r.ReadAsync(ct))
                {
                    report.ConnectionOk = true;
                    report.DatabaseName = r.IsDBNull(1) ? null : r.GetString(1);
                    var ver = r.IsDBNull(2) ? "" : r.GetString(2);
                    report.ServerVersion = ver.Split('\n').FirstOrDefault()?.Trim();
                }
            }
            if (!report.ConnectionOk) return report;

            // جدول‌ها و ستون‌های موردانتظار
            var columnsByTable = await LoadColumnsAsync(con, ct);
            foreach (var (table, required) in RequiredTableColumns)
            {
                if (!columnsByTable.TryGetValue(table, out var cols))
                {
                    report.TablesMissing.Add(table);
                    continue;
                }
                report.TablesAvailable.Add(table);
                var missing = required.Where(c => !cols.Contains(c, StringComparer.OrdinalIgnoreCase)).ToList();
                if (missing.Count > 0) report.ColumnsMissing[table] = missing;
            }

            // SPها و امضاها
            foreach (var (sp, expected) in ExpectedSpSignatures)
            {
                var actual = await LoadSpParamsAsync(con, sp, ct);
                if (actual == null) { report.SpUnavailable.Add(sp); continue; }
                var matches = actual.Count == expected.Length
                              && !actual.Where((p, i) => !string.Equals(p, expected[i], StringComparison.OrdinalIgnoreCase)).Any();
                if (matches) report.SpAvailable.Add(sp);
                else report.SpUnavailable.Add($"{sp} (امضای متفاوت: {string.Join(",", actual)})");
            }

            // انتخاب حالت هر موجودیت
            report.EntityModes = _modeSelector.Decide(report);
        }
        catch (Exception ex)
        {
            report.ConnectionOk = false;
            report.ConnectionError = ex.GetType().Name;
            _logger.LogError(ex, "Schema probe failed");
        }
        return report;
    }

    private static async Task<Dictionary<string, HashSet<string>>> LoadColumnsAsync(DbConnection con, CancellationToken ct)
    {
        var map = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
        await using var cmd = con.CreateCommand();
        cmd.CommandText = @"SELECT t.name, c.name FROM sys.tables t JOIN sys.columns c ON c.object_id = t.object_id";
        cmd.CommandType = CommandType.Text;
        ReadOnlyCommandGuard.Validate(cmd.CommandText, cmd.CommandType);
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct))
        {
            var t = r.GetString(0);
            if (!map.TryGetValue(t, out var set)) map[t] = set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            set.Add(r.GetString(1));
        }
        return map;
    }

    private static async Task<List<string>?> LoadSpParamsAsync(DbConnection con, string spName, CancellationToken ct)
    {
        await using var exists = con.CreateCommand();
        exists.CommandText = @"SELECT COUNT(1) FROM sys.procedures WHERE name = @p0";
        exists.CommandType = CommandType.Text;
        ReadOnlyCommandGuard.Validate(exists.CommandText, exists.CommandType);
        var p0 = exists.CreateParameter();
        p0.ParameterName = "@p0";
        p0.Value = spName;
        exists.Parameters.Add(p0);
        var cnt = Convert.ToInt32(await exists.ExecuteScalarAsync(ct));
        if (cnt == 0) return null;

        await using var cmd = con.CreateCommand();
        cmd.CommandText = @"SELECT p.name FROM sys.procedures sp JOIN sys.parameters p ON p.object_id = sp.object_id WHERE sp.name = @p0 ORDER BY p.parameter_id";
        cmd.CommandType = CommandType.Text;
        ReadOnlyCommandGuard.Validate(cmd.CommandText, cmd.CommandType);
        var p = cmd.CreateParameter();
        p.ParameterName = "@p0";
        p.Value = spName;
        cmd.Parameters.Add(p);
        var list = new List<string>();
        await using var r = await cmd.ExecuteReaderAsync(ct);
        while (await r.ReadAsync(ct)) list.Add(r.GetString(0));
        return list;
    }
}

/// <summary>انتخاب حالت دسترسی (Auto/Table/Sp) بر اساس گزارش اسکیما.</summary>
public class DataAccessModeSelector
{
    private readonly string _configured;

    public DataAccessModeSelector(IdealBridgeOptions options) => _configured = options.DataAccessMode;

    /// <summary>برای هر موجودیت: Sp یا Table. در حالت Auto، SP فقط وقتی انتخاب می‌شود که هم SP موجود باشد هم جدول هسته سالم.</summary>
    public Dictionary<string, string> Decide(SchemaReport report)
    {
        var modes = new Dictionary<string, string>();
        bool CompanyOk() => report.TablesAvailable.Contains("CrmCompany", StringComparer.OrdinalIgnoreCase)
                            && !report.ColumnsMissing.ContainsKey("CrmCompany");
        bool PersonsOk() => report.TablesAvailable.Contains("CrmCompanyPersons", StringComparer.OrdinalIgnoreCase)
                            && !report.ColumnsMissing.ContainsKey("CrmCompanyPersons");
        bool UsersOk() => report.TablesAvailable.Contains("Users", StringComparer.OrdinalIgnoreCase)
                          && !report.ColumnsMissing.ContainsKey("Users");

        void Add(string entity, string table, string sp, bool tableOk)
        {
            switch (_configured.ToUpperInvariant())
            {
                case "TABLE":
                    modes[entity] = tableOk ? "Table" : "Blocked";
                    return;
                case "SP":
                    var spOk = report.SpAvailable.Contains(sp, StringComparer.OrdinalIgnoreCase);
                    modes[entity] = spOk ? "Sp" : "Blocked";
                    return;
                default: // Auto
                    var spAvail = report.SpAvailable.Contains(sp, StringComparer.OrdinalIgnoreCase);
                    if (tableOk && spAvail) modes[entity] = "Sp";
                    else if (tableOk) modes[entity] = "Table";
                    else if (spAvail) modes[entity] = "Sp";
                    else modes[entity] = "Blocked";
                    return;
            }
        }

        Add("Companies", "CrmCompany", "ApispSelectCompany", CompanyOk());
        Add("Persons", "CrmCompanyPersons", "ApispSelectCompanyPersons", PersonsOk());
        Add("Users", "Users", "ApispSelectUsers", UsersOk());
        Add("Conversations", "CrmConversation", "ApispSelectConversation",
            report.TablesAvailable.Contains("CrmConversation", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("CrmConversation"));
        Add("Projects", "CrmProjects", "ApispSelectProjects",
            report.TablesAvailable.Contains("CrmProjects", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("CrmProjects"));
        Add("Reminders", "CrmUserTasks", "ApispSelectReminderCartable",
            report.TablesAvailable.Contains("CrmUserTasks", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("CrmUserTasks"));
        Add("Warehouses", "WsWareHouse", "ApispSelectWareHouse",
            report.TablesAvailable.Contains("WsWareHouse", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("WsWareHouse"));
        Add("Products", "WSProducts", "ApispSelectProducts",
            report.TablesAvailable.Contains("WSProducts", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("WSProducts"));
        Add("Orders", "WSOrder", "ApispSelectOrder",
            report.TablesAvailable.Contains("WSOrder", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("WSOrder"));
        Add("PreOrders", "WSPreOrder", "ApispSelectPreOrder",
            report.TablesAvailable.Contains("WSPreOrder", StringComparer.OrdinalIgnoreCase) && !report.ColumnsMissing.ContainsKey("WSPreOrder"));
        return modes;
    }
}
