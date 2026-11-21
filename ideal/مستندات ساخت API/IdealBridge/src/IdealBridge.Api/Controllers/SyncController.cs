using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Domain.Dto;
using IdealBridge.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>
/// همگام‌سازی MedPad — طراحی برای دریافت مستقل (سند ۱۰).
/// الگو: Keyset با afterId + پنجرهٔ ثبت (RegisteredFrom/To).
/// محدودیت مهم: دیتابیس Ideal ستون «آخرین تغییر» ندارد؛ پس:
///  - دریافت مشتریان جدید = پنجرهٔ RegisterDate
///  - تشخیص ویرایش/حذف = Snapshot دوره‌ای و مقایسه در سمت MedPad
/// </summary>
[ApiController]
[Route("api/v1/sync")]
[Authorize]
public class SyncController : ControllerBase
{
    private readonly ICompanyRepository _companies;
    private readonly IPersonRepository _persons;
    private readonly IConversationRepository _conversations;

    public SyncController(ICompanyRepository companies, IPersonRepository persons, IConversationRepository conversations)
    {
        _companies = companies;
        _persons = persons;
        _conversations = conversations;
    }

    /// <summary>
    /// بستهٔ همگام‌سازی مشتریان: از afterId ادامه بده یا از پنجرهٔ ثبت شروع کن.
    /// پاسخ شامل hasMore و nextAfterId برای ادامهٔ قطع‌شده است.
    /// </summary>
    [HttpGet("companies")]
    public async Task<IActionResult> Companies([FromQuery] SyncQuery s, CancellationToken ct)
    {
        var q = new CompanyListQuery
        {
            AfterId = s.AfterId,
            RegisteredFrom = s.RegisteredFrom,
            RegisteredTo = s.RegisteredTo,
            PageSize = Math.Clamp(s.Limit <= 0 ? 100 : s.Limit, 1, PagedQuery.MaxPageSize),
        };
        var result = await _companies.GetCompaniesAsync(q, ct);
        var pagination = new PaginationInfo
        {
            Page = 0,
            PageSize = q.Take,
            HasMore = result.HasMore,
            NextAfterId = result.NextAfterId,
        };
        if (result.HasMore && result.NextAfterId is int next)
            pagination.NextPageUrl = $"/api/v1/sync/companies?afterId={next}" +
                (s.RegisteredFrom.HasValue ? "&registeredFrom=" + s.RegisteredFrom.Value.ToString("yyyy-MM-dd") : "") +
                (s.RegisteredTo.HasValue ? "&registeredTo=" + s.RegisteredTo.Value.ToString("yyyy-MM-dd") : "");
        return Ok(ApiResponse<IReadOnlyList<CompanyDto>>.Ok(result.Items, pagination: pagination));
    }

    /// <summary>بستهٔ همگام‌سازی اشخاص (Keyset).</summary>
    [HttpGet("persons")]
    public async Task<IActionResult> Persons([FromQuery] SyncQuery s, [FromQuery] int? companyId, CancellationToken ct)
    {
        var q = new PersonListQuery
        {
            AfterId = s.AfterId,
            CompanyId = companyId,
            PageSize = Math.Clamp(s.Limit <= 0 ? 100 : s.Limit, 1, PagedQuery.MaxPageSize),
        };
        var result = await _persons.GetPersonsAsync(q, ct);
        var pagination = new PaginationInfo { PageSize = q.Take, HasMore = result.HasMore, NextAfterId = result.NextAfterId };
        if (result.HasMore && result.NextAfterId is int next)
            pagination.NextPageUrl = $"/api/v1/sync/persons?afterId={next}" + (companyId.HasValue ? "&companyId=" + companyId : "");
        return Ok(ApiResponse<IReadOnlyList<CompanyPersonDto>>.Ok(result.Items, pagination: pagination));
    }

    /// <summary>بستهٔ همگام‌سازی مکالمات (Keyset).</summary>
    [HttpGet("conversations")]
    public async Task<IActionResult> Conversations([FromQuery] SyncQuery s, [FromQuery] int? companyId, CancellationToken ct)
    {
        var q = new ConversationListQuery
        {
            AfterId = s.AfterId,
            CompanyId = companyId,
            PageSize = Math.Clamp(s.Limit <= 0 ? 100 : s.Limit, 1, PagedQuery.MaxPageSize),
        };
        var result = await _repoConversations(ct, q);
        var pagination = new PaginationInfo { PageSize = q.Take, HasMore = result.HasMore, NextAfterId = result.NextAfterId };
        if (result.HasMore && result.NextAfterId is int next)
            pagination.NextPageUrl = $"/api/v1/sync/conversations?afterId={next}" + (companyId.HasValue ? "&companyId=" + companyId : "");
        return Ok(ApiResponse<IReadOnlyList<ConversationDto>>.Ok(result.Items, pagination: pagination));
    }

    private Task<Application.Interfaces.PagedResult<ConversationDto>> _repoConversations(CancellationToken ct, ConversationListQuery q)
        => _conversations.GetConversationsAsync(q, ct);
}

/// <summary>سلامت سرویس و وضعیت اتصال/سازگاری اسکیما.</summary>
[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly ISchemaProbe _probe;
    private readonly IdealBridge.Infrastructure.Repositories.IDataAccessPolicy _policy;
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly ILogger<HealthController> _logger;

    public HealthController(ISchemaProbe probe, IdealBridge.Infrastructure.Repositories.IDataAccessPolicy policy,
        IDbConnectionFactory connectionFactory, ILogger<HealthController> logger)
    {
        _probe = probe;
        _policy = policy;
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    /// <summary>سلامت زندهٔ سرویس (بدون احراز هویت — فقط بالا/پایین بودن).</summary>
    [HttpGet("live")]
    [AllowAnonymous]
    public IActionResult Live() => Ok(new { status = "alive", service = "IdealBridge", time = DateTime.UtcNow });

    /// <summary>
    /// کاوش زندهٔ دیتابیس Ideal (نیازمند توکن): اتصال + جدول‌ها/ستون‌های موجود + حالت مؤثر هر موجودیت.
    /// پس از هر بار فراخوانی، سیاست دسترسی هم تازه می‌شود (مثلاً پس از تغییر اسکیما یا restore).
    /// </summary>
    [HttpGet("db")]
    [Authorize]
    public async Task<IActionResult> Db(CancellationToken ct)
    {
        // فاز ۱۱.۱: در حالت Unconfigured پیام دقیق و کنترل‌شده — نه خطای عمومی
        if (_connectionFactory.State == ConnectionStateKind.Unconfigured)
            return StatusCode(StatusCodes.Status503ServiceUnavailable,
                ApiResponse<object>.Failed(
                    "تنظیمات اتصال دیتابیس Ideal تنظیم نشده است (Unconfigured) — وضعیت را از /api/v1/admin/connection ببینید.",
                    ResultStatus.Error));

        var report = await _probe.ProbeAsync(ct);
        _policy.ApplySchemaReport(report);
        report.EntityModes = new Dictionary<string, IdealBridge.Domain.Common.EntityAccessInfo>(_policy.CurrentModes());
        if (!report.ConnectionOk)
            return StatusCode(StatusCodes.Status503ServiceUnavailable,
                ApiResponse<object>.Failed("اتصال به دیتابیس Ideal برقرار نیست.", ResultStatus.Error));
        return Ok(ApiResponse<SchemaReport>.Ok(report));
    }
}
