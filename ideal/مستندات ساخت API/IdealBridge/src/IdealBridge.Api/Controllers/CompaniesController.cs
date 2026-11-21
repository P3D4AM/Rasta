
using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>مشتریان Ideal CRM — اولویت ۱ مأموریت.</summary>
[ApiController]
[Route("api/v1/companies")]
[Authorize]
[Produces("application/json")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyRepository _companies;

    public CompaniesController(ICompanyRepository companies) => _companies = companies;

    /// <summary>فهرست مشتریان با فیلتر و صفحه‌بندی (page/pageSize یا afterId برای Keyset).</summary>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<CompanyDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List([FromQuery] CompanyListQuery q, CancellationToken ct)
    {
        var result = await _companies.GetCompaniesAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<CompanyDto>>.Ok(
            result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }

    /// <summary>مشتری با شناسهٔ پایدار CompanyID.</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<CompanyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var company = await _companies.GetCompanyAsync(id, ct);
        return company == null
            ? NotFound(ApiResponse<object>.Failed($"مشتری با شناسهٔ {id} یافت نشد.", ResultStatus.Fail))
            : Ok(ApiResponse<CompanyDto>.Ok(company));
    }

    /// <summary>تماس‌های اضافهٔ ثبت‌شدهٔ مشتری (جدول CrmCompanyAddresses).</summary>
    [HttpGet("{id:int}/addresses")]
    public async Task<IActionResult> Addresses(int id, CancellationToken ct)
    {
        var items = await _companies.GetAddressesAsync(id, ct);
        return Ok(ApiResponse<IReadOnlyList<CompanyAddressDto>>.Ok(items));
    }
}

/// <summary>کمکی ساخت PaginationInfo از PagedResult.</summary>
public static class PaginationHelper
{
    public static PaginationInfo Build<T>(PagedResult<T> result, PagedQuery q, HttpRequest request) where T : class
    {
        var info = new PaginationInfo
        {
            Page = q.IsKeyset ? 0 : q.Page,
            PageSize = q.Take,
            HasMore = result.HasMore,
            NextAfterId = result.NextAfterId,
        };
        if (result.HasMore && result.NextAfterId is int next)
        {
            var qb = new QueryBuilder();
            foreach (var (k, v) in request.Query.Where(kv => kv.Key != "afterId" && kv.Key != "page"))
                qb.Add(k, v.ToString());
            qb.Add("afterId", next.ToString());
            info.NextPageUrl = request.Path + qb.ToQueryString();
        }
        return info;
    }
}

/// <summary>ساخت QueryString بدون وابستگی اضافه.</summary>
internal class QueryBuilder
{
    private readonly List<KeyValuePair<string, string>> _items = new();
    public void Add(string key, string value) => _items.Add(new(key, value));
    public string ToQueryString()
    {
        if (_items.Count == 0) return string.Empty;
        return "?" + string.Join("&", _items.Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
    }
}
