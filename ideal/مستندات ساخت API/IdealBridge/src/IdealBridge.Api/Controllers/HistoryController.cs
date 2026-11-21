using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Common;
using IdealBridge.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdealBridge.Api.Controllers;

/// <summary>مکالمات/پیگیری‌ها — اولویت ۳.</summary>
[ApiController]
[Route("api/v1/conversations")]
[Authorize]
public class ConversationsController : ControllerBase
{
    private readonly IConversationRepository _repo;
    public ConversationsController(IConversationRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ConversationListQuery q, CancellationToken ct)
    {
        var result = await _repo.GetConversationsAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<ConversationDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }
}

/// <summary>پروژه‌های مشتری — اولویت ۳.</summary>
[ApiController]
[Route("api/v1/projects")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _repo;
    public ProjectsController(IProjectRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ProjectListQuery q, CancellationToken ct)
    {
        var result = await _repo.GetProjectsAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<ProjectDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }
}

/// <summary>یادآوری‌ها/وظایف کارتبل — اولویت ۳.</summary>
[ApiController]
[Route("api/v1/reminders")]
[Authorize]
public class RemindersController : ControllerBase
{
    private readonly IReminderRepository _repo;
    public RemindersController(IReminderRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ReminderListQuery q, CancellationToken ct)
    {
        if (q.UserId <= 0)
            return BadRequest(ApiResponse<object>.Failed("پارامتر userId الزامی است (شناسهٔ کاربر Ideal).", ResultStatus.Fail));
        var result = await _repo.GetRemindersAsync(q, ct);
        return Ok(ApiResponse<IReadOnlyList<ReminderDto>>.Ok(result.Items,
            pagination: PaginationHelper.Build(result, q, Request)));
    }
}

/// <summary>اطلاعات پایه (شهر/استان/کشور/گروه/عنوان/...).</summary>
[ApiController]
[Route("api/v1/baseinfo")]
[Authorize]
public class BaseInfoController : ControllerBase
{
    private readonly IBaseInfoRepository _repo;
    public BaseInfoController(IBaseInfoRepository repo) => _repo = repo;

    private static readonly Dictionary<string, BaseInfoKind> Kinds =
        Enum.GetValues<BaseInfoKind>().ToDictionary(k => k.ToString().ToLowerInvariant(), k => k, StringComparer.Ordinal);

    [HttpGet("{kind}")]
    public async Task<IActionResult> List(string kind, CancellationToken ct)
    {
        if (!Kinds.TryGetValue(kind.ToLowerInvariant(), out var k))
            return BadRequest(ApiResponse<object>.Failed(
                $"نوع اطلاعات پایهٔ نامعتبر. مقادیر مجاز: {string.Join(", ", Kinds.Keys.OrderBy(x => x))}", ResultStatus.Fail));
        var items = await _repo.GetAsync(k, ct);
        return Ok(ApiResponse<IReadOnlyList<BaseInfoDto>>.Ok(items));
    }
}
