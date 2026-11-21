using IdealBridge.Domain.Common;
using IdealBridge.Domain.Dto;

namespace IdealBridge.Application.Interfaces;
/// <summary>نتیجهٔ صفحه‌بندی‌شدهٔ عمومی.</summary>
public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();
    public long? TotalCount { get; init; }
    public bool HasMore { get; init; }
    public int? NextAfterId { get; init; }
}

public interface ICompanyRepository
{
    Task<PagedResult<CompanyDto>> GetCompaniesAsync(CompanyListQuery q, CancellationToken ct = default);
    Task<CompanyDto?> GetCompanyAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<CompanyAddressDto>> GetAddressesAsync(int companyId, CancellationToken ct = default);
}

public interface IPersonRepository
{
    Task<PagedResult<CompanyPersonDto>> GetPersonsAsync(PersonListQuery q, CancellationToken ct = default);
    Task<CompanyPersonDto?> GetPersonAsync(int id, CancellationToken ct = default);
}

public interface IUserRepository
{
    Task<PagedResult<CrmUserDto>> GetUsersAsync(PagedQuery q, CancellationToken ct = default);
    Task<CrmUserDto?> GetUserAsync(int id, CancellationToken ct = default);
}

public interface IConversationRepository
{
    Task<PagedResult<ConversationDto>> GetConversationsAsync(ConversationListQuery q, CancellationToken ct = default);
}

public interface IProjectRepository
{
    Task<PagedResult<ProjectDto>> GetProjectsAsync(ProjectListQuery q, CancellationToken ct = default);
}

public interface IReminderRepository
{
    Task<PagedResult<ReminderDto>> GetRemindersAsync(ReminderListQuery q, CancellationToken ct = default);
}

public interface IWarehouseRepository
{
    Task<PagedResult<WarehouseDto>> GetWarehousesAsync(bool includeDeactivated, CancellationToken ct = default);
}

public interface IProductRepository
{
    Task<PagedResult<ProductDto>> GetProductsAsync(ProductListQuery q, CancellationToken ct = default);
}

public interface IOrderRepository
{
    Task<PagedResult<OrderDto>> GetOrdersAsync(OrderListQuery q, CancellationToken ct = default);
    Task<PagedResult<PreOrderDto>> GetPreOrdersAsync(PreOrderListQuery q, CancellationToken ct = default);
}

/// <summary>اطلاعات پایهٔ عمومی (شهر/استان/کشور/گروه/عنوان/...).</summary>
public interface IBaseInfoRepository
{
    Task<IReadOnlyList<BaseInfoDto>> GetAsync(BaseInfoKind kind, CancellationToken ct = default);
}

public enum BaseInfoKind
{
    CompanyTitle, CompanyType, CompanyGroup, CompanySubGroup, CompanyGroupII, CompanyGroupIII, CompanyGroupIV,
    CompanyPresentation, CompanyAddressType, PersonTitle, PersonType, PersonJob, PersonDepartment, PersonGroup,
    Education, Sex, City, Province, Country, ProjectTitle, ProjectGroup, ProjectGrade, ProjectPriority
}

/// <summary>کاوشگر فرادادهٔ فقط-خواندنی دیتابیس Ideal (موجودی SP/جدول/ستون).</summary>
public interface ISchemaProbe
{
    Task<SchemaReport> ProbeAsync(CancellationToken ct = default);
}

/// <summary>گزارش سازگاری اسکیمای دیتابیس واقعی با انتظارات IdealBridge.</summary>
public class SchemaReport
{
    public bool ConnectionOk { get; set; }
    public string? ConnectionError { get; set; }
    public string? DatabaseName { get; set; }
    public string? ServerVersion { get; set; }
    public DateTime ProbedAt { get; set; } = DateTime.UtcNow;

    /// <summary>حالت مؤثر دسترسی هر موجودیت + دلیل (تعیین‌شده توسط DataAccessPolicy — هرگز Sp در این نسخه).</summary>
    public Dictionary<string, Domain.Common.EntityAccessInfo> EntityModes { get; set; } = new();

    /// <summary>SPهایی که وجود دارند با امضای موردانتظار.</summary>
    public List<string> SpAvailable { get; set; } = new();

    /// <summary>SPهایی که وجود ندارند یا امضایشان متفاوت است.</summary>
    public List<string> SpUnavailable { get; set; } = new();

    /// <summary>جدول‌های موجود از فهرست موردانتظار.</summary>
    public List<string> TablesAvailable { get; set; } = new();

    /// <summary>جدول‌ها/ستون‌های مفقود.</summary>
    public List<string> TablesMissing { get; set; } = new();
    public Dictionary<string, List<string>> ColumnsMissing { get; set; } = new();

    public bool IsUsable => ConnectionOk && (TablesAvailable.Count > 0 || SpAvailable.Count > 0);
}
