using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>اشخاص مرتبط با مشتری — اولویت ۲.</summary>
[ApiController]
[Route("api/v1/persons")]
[Authorize]
public class PersonsController : ControllerBase
{
    private readonly IPersonRepository _persons;

    public PersonsController(IPersonRepository persons) => _persons = persons;

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PersonListQuery q, CancellationToken ct)
    {
        var result = await _persons.GetPersonsAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<CompanyPersonDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var person = await _persons.GetPersonAsync(id, ct);
        return person == null
            ? NotFound(ApiResponse<object>.Failed($"شخص با شناسهٔ {id} یافت نشد.", ResultStatus.Fail))
            : Ok(ApiResponse<CompanyPersonDto>.Ok(person));
    }
}

/// <summary>کاربران CRM — اولویت ۲ (بدون اطلاعات حساس).</summary>
[ApiController]
[Route("api/v1/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _users;

    public UsersController(IUserRepository users) => _users = users;

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PagedQuery q, CancellationToken ct)
    {
        var result = await _users.GetUsersAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<CrmUserDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var user = await _users.GetUserAsync(id, ct);
        return user == null
            ? NotFound(ApiResponse<object>.Failed($"کاربر با شناسهٔ {id} یافت نشد.", ResultStatus.Fail))
            : Ok(ApiResponse<CrmUserDto>.Ok(user));
    }
}
