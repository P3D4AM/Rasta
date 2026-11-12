using System.Data.Common;
using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Dto;
using IdealBridge.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using IdealBridge.Domain.Common;

namespace IdealBridge.Infrastructure.Repositories;

// ═══════════════════════ اشخاص مرتبط با مشتری ═══════════════════════
public class PersonRepository : IPersonRepository
{
    private readonly IdealDb _db;

    public PersonRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Persons"); }

    private const string Base = @"
SELECT P.CompanyPersonID, P.prsCompanyId, CC.cmpName AS CompanyName,
       P.prsFName, P.prsLName,
       P.prsTitleId, PT.PersonTitle, P.prsJobId, J.Job, P.prsTypeId, PTy.PersonType,
       P.prsGroupId, PG.GroupName AS PersonGroup, P.prsSexId, SX.Sex,
       P.prsEducationId, ED.Education, P.prsDepartmentId, DP.Department,
       P.prsPreTel, P.prsTel, P.prsTelUpTo, P.prsTelDesc, P.prsTelII, P.prsFax,
       P.prsMobile, P.prsWebSite, P.prsEmail, P.prsEmailII,
       P.prsCountryId, CO.Country, P.prsProvinceId, PR.Province, P.prsCityId, CI.City,
       P.prsAddress, P.prsZipCode, P.prsPostBox,
       P.prsNationalCode, P.prsIdentityNumber, P.prsFatherName, P.prsBirthDate, P.prsBirthPlace,
       P.prsIsMarried, P.prsMarriageDate, P.prsSkill, P.prsStudyField,
       P.prsInteresting, P.prsSpecialPoint, P.prsDescription,
       P.ImportDate, P.prsStopSendSms, P.prsWorkingOut
FROM dbo.CrmCompanyPersons P
LEFT JOIN dbo.CrmCompany CC ON CC.CompanyID = P.prsCompanyId
LEFT JOIN dbo.CrmPersonTitle PT ON PT.PersonTitleID = P.prsTitleId
LEFT JOIN dbo.CrmPersonJob J ON J.JobID = P.prsJobId
LEFT JOIN dbo.CrmPersonType PTy ON PTy.PersonTypeID = P.prsTypeId
LEFT JOIN dbo.CrmPersonGroups PG ON PG.PersonGroupID = P.prsGroupId
LEFT JOIN dbo.Sex SX ON SX.SexID = P.prsSexId
LEFT JOIN dbo.Education ED ON ED.EducationID = P.prsEducationId
LEFT JOIN dbo.CrmPersonDepartments DP ON DP.DepartmentID = P.prsDepartmentId
LEFT JOIN dbo.Country CO ON CO.CountryID = P.prsCountryId
LEFT JOIN dbo.Province PR ON PR.ProvinceID = P.prsProvinceId
LEFT JOIN dbo.City CI ON CI.CityID = P.prsCityId
WHERE 1 = 1 ";

    public async Task<PagedResult<CompanyPersonDto>> GetPersonsAsync(PersonListQuery q, CancellationToken ct = default)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (q.CompanyId.HasValue) p.Add("@cid", q.CompanyId);
            if (!string.IsNullOrWhiteSpace(q.Name)) p.Add("@name", "%" + q.Name.Trim() + "%");
            if (!string.IsNullOrWhiteSpace(q.Mobile)) p.Add("@mob", "%" + q.Mobile.Trim() + "%");
            if (q.WorkingOut.HasValue) p.Add("@wout", q.WorkingOut);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (q.CompanyId.HasValue) where.Add("AND P.prsCompanyId = @cid");
        if (!string.IsNullOrWhiteSpace(q.Name)) where.Add("AND (P.prsFName LIKE @name OR P.prsLName LIKE @name)");
        if (!string.IsNullOrWhiteSpace(q.Mobile)) where.Add("AND P.prsMobile LIKE @mob");
        if (q.WorkingOut.HasValue) where.Add("AND P.prsWorkingOut = @wout");
        if (q.IsKeyset) where.Add("AND P.CompanyPersonID > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY P.CompanyPersonID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY P.CompanyPersonID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var rows = await Query(Base + string.Join(' ', where) + " " + paging, Bind, ct);
        return ConversationRepository.Finalize(rows, q);
    }

    public async Task<CompanyPersonDto?> GetPersonAsync(int id, CancellationToken ct = default)
    {
        var rows = await Query(Base + " AND P.CompanyPersonID = @id ORDER BY P.CompanyPersonID", p => p.Add("@id", id), ct);
        return rows.FirstOrDefault();
    }

    private Task<IReadOnlyList<CompanyPersonDto>> Query(string sql, Action<DbParameterCollection> bind, CancellationToken ct)
        => _db.QueryAsync(sql, bind, Map, ct);

    private static CompanyPersonDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "CompanyPersonID"),
        CompanyId = Reader.GetInt(r, "prsCompanyId"),
        CompanyName = Reader.GetStr(r, "CompanyName"),
        FirstName = Reader.GetStr(r, "prsFName"),
        LastName = Reader.GetStr(r, "prsLName"),
        FullName = ((Reader.GetStr(r, "prsFName") ?? "") + " " + (Reader.GetStr(r, "prsLName") ?? "")).Trim(),
        TitleId = Reader.GetIntN(r, "prsTitleId"),
        Title = Reader.GetStr(r, "PersonTitle"),
        JobId = Reader.GetIntN(r, "prsJobId"),
        Job = Reader.GetStr(r, "Job"),
        TypeId = Reader.GetIntN(r, "prsTypeId"),
        Type = Reader.GetStr(r, "PersonType"),
        GroupId = Reader.GetIntN(r, "prsGroupId"),
        Group = Reader.GetStr(r, "PersonGroup"),
        SexId = Reader.GetIntN(r, "prsSexId"),
        Sex = Reader.GetStr(r, "Sex"),
        EducationId = Reader.GetIntN(r, "prsEducationId"),
        Education = Reader.GetStr(r, "Education"),
        DepartmentId = Reader.GetIntN(r, "prsDepartmentId"),
        Department = Reader.GetStr(r, "Department"),
        PreTel = Reader.GetStr(r, "prsPreTel"),
        Tel = Reader.GetStr(r, "prsTel"),
        TelUpTo = Reader.GetStr(r, "prsTelUpTo"),
        TelDesc = Reader.GetStr(r, "prsTelDesc"),
        Tel2 = Reader.GetStr(r, "prsTelII"),
        Fax = Reader.GetStr(r, "prsFax"),
        Mobile = Reader.GetStr(r, "prsMobile"),
        WebSite = Reader.GetStr(r, "prsWebSite"),
        Email = Reader.GetStr(r, "prsEmail"),
        Email2 = Reader.GetStr(r, "prsEmailII"),
        CountryId = Reader.GetIntN(r, "prsCountryId"),
        Country = Reader.GetStr(r, "Country"),
        ProvinceId = Reader.GetIntN(r, "prsProvinceId"),
        Province = Reader.GetStr(r, "Province"),
        CityId = Reader.GetIntN(r, "prsCityId"),
        City = Reader.GetStr(r, "City"),
        Address = Reader.GetStr(r, "prsAddress"),
        ZipCode = Reader.GetStr(r, "prsZipCode"),
        PostBox = Reader.GetStr(r, "prsPostBox"),
        NationalCode = Reader.GetStr(r, "prsNationalCode"),
        IdentityNumber = Reader.GetStr(r, "prsIdentityNumber"),
        FatherName = Reader.GetStr(r, "prsFatherName"),
        BirthDate = Reader.GetStr(r, "prsBirthDate"),
        BirthPlace = Reader.GetStr(r, "prsBirthPlace"),
        IsMarried = Reader.GetBoolN(r, "prsIsMarried"),
        MarriageDate = Reader.GetStr(r, "prsMarriageDate"),
        Skill = Reader.GetStr(r, "prsSkill"),
        StudyField = Reader.GetStr(r, "prsStudyField"),
        Interesting = Reader.GetStr(r, "prsInteresting"),
        SpecialPoint = Reader.GetStr(r, "prsSpecialPoint"),
        Description = Reader.GetStr(r, "prsDescription"),
        ImportDate = Reader.GetStr(r, "ImportDate"),
        StopSendSms = Reader.GetBoolN(r, "prsStopSendSms"),
        WorkingOut = Reader.GetBoolN(r, "prsWorkingOut"),
    };
}

// ═══════════════════════ کاربران CRM ═══════════════════════
public class UserRepository : IUserRepository
{
    private readonly IdealDb _db;

    public UserRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Users"); }

    private const string Base = @"
SELECT U.UserId, U.Row, U.FName, U.LName, U.PersCode, U.UserName,
       U.IsAdmin, U.IsActive, U.UserIsActiveInWinApp, U.UserIsActiveInWebApp, U.UserIsActiveInMobApp,
       U.Mobile, U.MobileII, U.Tel, U.PositionId, U.UserGroupId,
       U.NationalCode, U.StartDate, U.ExpireDate, U.Description
FROM dbo.Users U
WHERE 1 = 1 ";
    // توجه: ستون Password عمداً در SELECT نیست — سیاست حذف اطلاعات حساس حتی در سطح کوئری.

    public async Task<PagedResult<CrmUserDto>> GetUsersAsync(PagedQuery q, CancellationToken ct = default)
    {
        var rows = q.IsKeyset
            ? await Query(Base + " AND U.UserId > @afterId ORDER BY U.UserId OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY",
                p => { p.Add("@afterId", q.AfterId!.Value); p.Add("@take", q.Take + 1); }, ct)
            : await Query(Base + " ORDER BY U.UserId OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY",
                p => { p.Add("@skip", q.Skip); p.Add("@take", q.Take + 1); }, ct);
        return ConversationRepository.Finalize(rows, q);
    }

    public async Task<CrmUserDto?> GetUserAsync(int id, CancellationToken ct = default)
        => (await Query(Base + " AND U.UserId = @id ORDER BY U.UserId", p => p.Add("@id", id), ct)).FirstOrDefault();

    private Task<IReadOnlyList<CrmUserDto>> Query(string sql, Action<DbParameterCollection> bind, CancellationToken ct)
        => _db.QueryAsync(sql, bind, Map, ct);

    private static async Task<CrmUserDto?> MapFirst(Task<IReadOnlyList<CrmUserDto>> t) => (await t).FirstOrDefault();

    private static CrmUserDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "UserId"),
        Row = r.IsDBNull(r.GetOrdinal("Row")) ? null : Convert.ToInt32(r.GetValue(r.GetOrdinal("Row"))),
        FirstName = Reader.GetStr(r, "FName"),
        LastName = Reader.GetStr(r, "LName"),
        FullName = ((Reader.GetStr(r, "FName") ?? "") + " " + (Reader.GetStr(r, "LName") ?? "")).Trim(),
        UserName = Reader.GetStr(r, "UserName"),
        PersonnelCode = Reader.GetStr(r, "PersCode"),
        IsAdmin = Reader.GetBoolLikeN(r, "IsAdmin"),
        IsActive = Reader.GetBoolN(r, "IsActive"),
        IsActiveInWinApp = Reader.GetBoolN(r, "UserIsActiveInWinApp"),
        IsActiveInWebApp = Reader.GetBoolN(r, "UserIsActiveInWebApp"),
        IsActiveInMobApp = Reader.GetBoolN(r, "UserIsActiveInMobApp"),
        Mobile = Reader.GetStr(r, "Mobile"),
        Mobile2 = Reader.GetStr(r, "MobileII"),
        Tel = Reader.GetStr(r, "Tel"),
        PositionId = Reader.GetIntN(r, "PositionId"),
        UserGroupId = Reader.GetIntN(r, "UserGroupId"),
        NationalCode = Reader.GetStr(r, "NationalCode"),
        StartDate = Reader.GetDateN(r, "StartDate"),
        ExpireDate = Reader.GetDateN(r, "ExpireDate"),
        Description = Reader.GetStr(r, "Description"),
    };
}

// ═══════════════════════ مکالمات/پیگیری‌ها ═══════════════════════
public class ConversationRepository : IConversationRepository
{
    private readonly IdealDb _db;

    public ConversationRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Conversations"); }

    public Task<PagedResult<ConversationDto>> GetConversationsAsync(ConversationListQuery q, CancellationToken ct = default)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (q.CompanyId.HasValue) p.Add("@cid", q.CompanyId);
            if (q.ProjectId.HasValue) p.Add("@pid", q.ProjectId);
            if (q.UserId.HasValue) p.Add("@uid", q.UserId);
            if (q.FromDate.HasValue) p.Add("@from", q.FromDate);
            if (q.ToDate.HasValue) p.Add("@to", q.ToDate);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (q.CompanyId.HasValue) where.Add("AND C.cnvsCompanyId = @cid");
        if (q.ProjectId.HasValue) where.Add("AND C.cnvsProjectId = @pid");
        if (q.UserId.HasValue) where.Add("AND C.cnvsUserId = @uid");
        if (q.FromDate.HasValue) where.Add("AND C.cnvsDateTime >= @from");
        if (q.ToDate.HasValue) where.Add("AND C.cnvsDateTime <= @to");
        if (q.IsKeyset) where.Add("AND C.ConversationID > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY C.ConversationID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY C.ConversationID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var sql = @"
SELECT C.ConversationID, C.cnvsProjectId, C.cnvsCompanyId, CC.cmpName AS CompanyName,
       C.cnvsDateTime, C.cnvsDate, C.cnvsDay, C.cnvsTime,
       C.cnvsTopicId, T.TopicName, C.cnvsSubject, C.cnvsPersonId,
       C.cnvsUserId, (U.FName + N' ' + U.LName) AS UserName,
       C.cnvsReferUserId, (RU.FName + N' ' + RU.LName) AS ReferUserName,
       C.cnvsReferDesc, C.cnvsStatusId, S.ConversationStatus,
       C.cnvsPriorityId, C.cnvsRemindDateTime, C.cnvsRemindOk,
       C.cnvsIsBookMark, C.cnvsIsTicket, C.cnvsIsTicketNew,
       C.RegisterDate, C.RegisterDatePersian, C.FirstRegisterDate
FROM dbo.CrmConversation C
LEFT JOIN dbo.CrmCompany CC ON CC.CompanyID = C.cnvsCompanyId
LEFT JOIN dbo.CrmConversationTopics T ON T.TopicID = C.cnvsTopicId
LEFT JOIN dbo.Users U ON U.UserId = C.cnvsUserId
LEFT JOIN dbo.Users RU ON RU.UserId = C.cnvsReferUserId
LEFT JOIN dbo.CrmConversationStatus S ON S.ConversationStatusID = C.cnvsStatusId
WHERE 1 = 1 " + string.Join(' ', where) + " " + paging;
        return _db.QueryAsync(sql, Bind, Map, ct).ContinueWith(t => Finalize(t.Result, q), TaskScheduler.Default);
    }

    private static ConversationDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "ConversationID"),
        ProjectId = Reader.GetIntN(r, "cnvsProjectId"),
        CompanyId = Reader.GetIntN(r, "cnvsCompanyId"),
        CompanyName = Reader.GetStr(r, "CompanyName"),
        DateTimeUtcLike = Reader.GetDateN(r, "cnvsDateTime"),
        Date = Reader.GetStr(r, "cnvsDate"),
        Day = Reader.GetStr(r, "cnvsDay"),
        Time = Reader.GetStr(r, "cnvsTime"),
        TopicId = Reader.GetIntN(r, "cnvsTopicId"),
        Topic = Reader.GetStr(r, "TopicName"),
        Subject = Reader.GetStr(r, "cnvsSubject"),
        PersonId = Reader.GetIntN(r, "cnvsPersonId"),
        UserId = Reader.GetIntN(r, "cnvsUserId"),
        User = Reader.GetStr(r, "UserName"),
        ReferUserId = Reader.GetIntN(r, "cnvsReferUserId"),
        ReferUser = Reader.GetStr(r, "ReferUserName"),
        ReferDesc = Reader.GetStr(r, "cnvsReferDesc"),
        StatusId = Reader.GetIntN(r, "cnvsStatusId"),
        Status = Reader.GetStr(r, "ConversationStatus"),
        PriorityId = Reader.GetIntN(r, "cnvsPriorityId"),
        RemindDateTime = Reader.GetDateN(r, "cnvsRemindDateTime"),
        RemindOk = Reader.GetBoolN(r, "cnvsRemindOk"),
        IsBookMark = Reader.GetBoolN(r, "cnvsIsBookMark"),
        IsTicket = Reader.GetBoolN(r, "cnvsIsTicket"),
        IsTicketRead = Reader.GetBoolN(r, "cnvsIsTicketNew"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
        RegisterDatePersian = Reader.GetStr(r, "RegisterDatePersian"),
        FirstRegisterDate = Reader.GetDateN(r, "FirstRegisterDate"),
    };

    internal static PagedResult<T> Finalize<T>(IReadOnlyList<T> rows, PagedQuery q) where T : class
    {
        var hasMore = rows.Count > q.Take;
        var page = rows.Count > q.Take ? rows.Take(q.Take).ToList() : rows.ToList();
        var nextAfter = page.Count > 0 ? (int?)(typeof(T).GetProperty("Id")?.GetValue(page[^1]) ?? 0) : null;
        return new PagedResult<T> { Items = page, HasMore = hasMore, NextAfterId = nextAfter };
    }
}

// ═══════════════════════ پروژه‌ها ═══════════════════════
public class ProjectRepository : IProjectRepository
{
    private readonly IdealDb _db;

    public ProjectRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Projects"); }

    public Task<PagedResult<ProjectDto>> GetProjectsAsync(ProjectListQuery q, CancellationToken ct = default)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (q.CompanyId.HasValue) p.Add("@cid", q.CompanyId);
            if (!string.IsNullOrWhiteSpace(q.Title)) p.Add("@title", "%" + q.Title.Trim() + "%");
            if (q.RegisteredFrom.HasValue) p.Add("@from", q.RegisteredFrom);
            if (q.RegisteredTo.HasValue) p.Add("@to", q.RegisteredTo);
            if (q.IsFinished.HasValue) p.Add("@fin", q.IsFinished);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (q.CompanyId.HasValue) where.Add("AND P.prjCompanyId = @cid");
        if (!string.IsNullOrWhiteSpace(q.Title)) where.Add("AND P.prjTitle LIKE @title");
        if (q.RegisteredFrom.HasValue) where.Add("AND P.RegisterDate >= @from");
        if (q.RegisteredTo.HasValue) where.Add("AND P.RegisterDate <= @to");
        if (q.IsFinished.HasValue) where.Add("AND P.prjIsFinished = @fin");
        if (q.IsKeyset) where.Add("AND P.ProjectID > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY P.ProjectID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY P.ProjectID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var sql = @"
SELECT P.ProjectID, P.prjCompanyId, CC.cmpName AS CompanyName,
       P.prjTitle, P.prjSubject, P.prjDesc,
       P.prjStartDateTime, P.prjStartDate, P.prjStartTime, P.prjStarterUserId,
       P.prjIsFinished, P.prjFinishedStatusId, P.prjFinishedDate, P.prjFinishedDateTime, P.prjFinishedUserId,
       P.prjGradeId, G.GradeName, P.prjPriorityId, PR.Priority, P.prjGroupId, PG.GroupName,
       P.prjNumRef, P.prjNumR, P.prjPostFix,
       P.RegisterDate, P.RegisterDatePersian, P.FirstRegisterDate, P.UserId AS LastEditUserId
FROM dbo.CrmProjects P
LEFT JOIN dbo.CrmCompany CC ON CC.CompanyID = P.prjCompanyId
LEFT JOIN dbo.CrmProjectGrade G ON G.ProjectGradeID = P.prjGradeId
LEFT JOIN dbo.CrmProjectPriority PR ON PR.ProjectPriorityID = P.prjPriorityId
LEFT JOIN dbo.CrmProjectGroups PG ON PG.ProjectGroupID = P.prjGroupId
WHERE 1 = 1 " + string.Join(' ', where) + " " + paging;
        return _db.QueryAsync(sql, Bind, Map, ct).ContinueWith(t => ConversationRepository.Finalize(t.Result, q), TaskScheduler.Default);
    }

    private static ProjectDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "ProjectID"),
        CompanyId = Reader.GetIntN(r, "prjCompanyId"),
        CompanyName = Reader.GetStr(r, "CompanyName"),
        Title = Reader.GetStr(r, "prjTitle"),
        Subject = Reader.GetStr(r, "prjSubject"),
        Description = Reader.GetStr(r, "prjDesc"),
        StartDateTime = Reader.GetDateN(r, "prjStartDateTime"),
        StartDate = Reader.GetStr(r, "prjStartDate"),
        StartTime = Reader.GetStr(r, "prjStartTime"),
        StarterUserId = Reader.GetIntN(r, "prjStarterUserId"),
        IsFinished = Reader.GetBoolN(r, "prjIsFinished"),
        FinishedStatusId = Reader.GetIntN(r, "prjFinishedStatusId"),
        FinishedDate = Reader.GetStr(r, "prjFinishedDate"),
        FinishedDateTime = Reader.GetDateN(r, "prjFinishedDateTime"),
        FinishedUserId = Reader.GetIntN(r, "prjFinishedUserId"),
        GradeId = Reader.GetIntN(r, "prjGradeId"),
        Grade = Reader.GetStr(r, "GradeName"),
        PriorityId = Reader.GetIntN(r, "prjPriorityId"),
        Priority = Reader.GetStr(r, "Priority"),
        GroupId = Reader.GetIntN(r, "prjGroupId"),
        Group = Reader.GetStr(r, "GroupName"),
        NumRef = Reader.GetStr(r, "prjNumRef"),
        NumR = Reader.GetLongN(r, "prjNumR"),
        PostFix = Reader.GetStr(r, "prjPostFix"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
        RegisterDatePersian = Reader.GetStr(r, "RegisterDatePersian"),
        FirstRegisterDate = Reader.GetDateN(r, "FirstRegisterDate"),
        LastEditUserId = Reader.GetIntN(r, "LastEditUserId"),
    };
}

// ═══════════════════════ یادآوری‌ها/وظایف کارتبل ═══════════════════════
public class ReminderRepository : IReminderRepository
{
    private readonly IdealDb _db;

    public ReminderRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Reminders"); }

    public Task<PagedResult<ReminderDto>> GetRemindersAsync(ReminderListQuery q, CancellationToken ct = default)
    {
        var where = new List<string> { "AND T.UserId = @uid" };
        void Bind(DbParameterCollection p)
        {
            p.Add("@uid", q.UserId);
            if (!q.IncludeDone.GetValueOrDefault(false)) p.Add("@didIt", false);
            if (q.FromDate.HasValue) p.Add("@from", q.FromDate);
            if (q.ToDate.HasValue) p.Add("@to", q.ToDate);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (!q.IncludeDone.GetValueOrDefault(false)) where.Add("AND ISNULL(T.UserTaskDidIt, 0) = @didIt");
        if (q.FromDate.HasValue) where.Add("AND T.UserTaskDate >= @from");
        if (q.ToDate.HasValue) where.Add("AND T.UserTaskDate <= @to");
        if (q.IsKeyset) where.Add("AND T.UserTaskId > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY T.UserTaskId OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY T.UserTaskId OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var sql = @"
SELECT T.UserTaskId, T.UserId, (U.FName + N' ' + U.LName) AS UserName,
       T.UserTaskDatePersian, T.UserTaskDate, T.UserTaskTime, T.UserTaskTimeEnd,
       T.UserTaskTitle, T.UserTaskDescription, T.UserTaskPriorityId, PR.PriorityName,
       T.UserTaskGroupId, G.GroupName, T.UserTaskDidIt, T.UserTaskDidItDate,
       T.UserTaskRemindDate, T.UserTaskRemindTime, T.UserTaskRemindDateTime, T.UserTaskIsPublic,
       T.ObjectTypeId, T.ObjectId, T.UserTaskCompanyIds, T.UserTaskRepeatDaily, T.UserTaskRepeatWeekly,
       T.UserTaskRepeatMonthly, T.UserTaskRepeatYearly, T.RegisterDate
FROM dbo.CrmUserTasks T
LEFT JOIN dbo.Users U ON U.UserId = T.UserId
LEFT JOIN dbo.CrmUserTaskPriorities PR ON PR.UserTaskPriorityId = T.UserTaskPriorityId
LEFT JOIN dbo.CrmUserTaskGroups G ON G.UserTaskGroupId = T.UserTaskGroupId
WHERE 1 = 1 " + string.Join(' ', where) + " " + paging;
        return _db.QueryAsync(sql, Bind, Map, ct).ContinueWith(t => ConversationRepository.Finalize(t.Result, q), TaskScheduler.Default);
    }

    private static ReminderDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "UserTaskId"),
        UserId = Reader.GetInt(r, "UserId"),
        User = Reader.GetStr(r, "UserName"),
        DatePersian = Reader.GetStr(r, "UserTaskDatePersian"),
        Date = Reader.GetDateN(r, "UserTaskDate"),
        Time = Reader.GetStr(r, "UserTaskTime"),
        TimeEnd = Reader.GetStr(r, "UserTaskTimeEnd"),
        Title = Reader.GetStr(r, "UserTaskTitle"),
        Description = Reader.GetStr(r, "UserTaskDescription"),
        PriorityId = Reader.GetIntN(r, "UserTaskPriorityId"),
        Priority = Reader.GetStr(r, "PriorityName"),
        GroupId = Reader.GetIntN(r, "UserTaskGroupId"),
        Group = Reader.GetStr(r, "GroupName"),
        DidIt = Reader.GetBoolN(r, "UserTaskDidIt"),
        DidItDate = Reader.GetDateN(r, "UserTaskDidItDate"),
        RemindDate = Reader.GetStr(r, "UserTaskRemindDate"),
        RemindTime = Reader.GetStr(r, "UserTaskRemindTime"),
        RemindDateTime = Reader.GetDateN(r, "UserTaskRemindDateTime"),
        IsPublic = Reader.GetBoolN(r, "UserTaskIsPublic"),
        ObjectTypeId = Reader.GetIntN(r, "ObjectTypeId"),
        ObjectId = Reader.GetIntN(r, "ObjectId"),
        CompanyIds = Reader.GetStr(r, "UserTaskCompanyIds"),
        RepeatDaily = Reader.GetBoolN(r, "UserTaskRepeatDaily"),
        RepeatWeekly = Reader.GetBoolN(r, "UserTaskRepeatWeekly"),
        RepeatMonthly = Reader.GetBoolN(r, "UserTaskRepeatMonthly"),
        RepeatYearly = Reader.GetBoolN(r, "UserTaskRepeatYearly"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
    };
}

// ═══════════════════════ انبارها ═══════════════════════
public class WarehouseRepository : IWarehouseRepository
{
    private readonly IdealDb _db;

    public WarehouseRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Warehouses"); }

    public Task<PagedResult<WarehouseDto>> GetWarehousesAsync(bool includeDeactivated, CancellationToken ct = default)
        => _db.QueryAsync(@"
SELECT W.WareHouseID, W.WrhsName, W.WrhsCode, W.WrhsAddress, W.WrhsPreTel, W.WrhsTel,
       W.WrhsTelSecond, W.WrhsTelThird, W.WrhsFax, W.WrhsArea, W.WrhsPerson,
       W.WrhsDescription, W.WrhsDeActive, W.OrderView, W.RegisterDate
FROM dbo.WsWareHouse W
WHERE (@includeDeActive = 1 OR ISNULL(W.WrhsDeActive, 0) = 0)
ORDER BY W.WareHouseID",
            p => p.Add("@includeDeActive", includeDeactivated),
            r => new WarehouseDto
            {
                Id = Reader.GetInt(r, "WareHouseID"),
                Name = Reader.GetStr(r, "WrhsName"),
                Code = Reader.GetStr(r, "WrhsCode"),
                Address = Reader.GetStr(r, "WrhsAddress"),
                PreTel = Reader.GetStr(r, "WrhsPreTel"),
                Tel = Reader.GetStr(r, "WrhsTel"),
                Tel2 = Reader.GetStr(r, "WrhsTelSecond"),
                Tel3 = Reader.GetStr(r, "WrhsTelThird"),
                Fax = Reader.GetStr(r, "WrhsFax"),
                Area = Reader.GetStr(r, "WrhsArea"),
                Person = Reader.GetStr(r, "WrhsPerson"),
                Description = Reader.GetStr(r, "WrhsDescription"),
                DeActive = Reader.GetBoolN(r, "WrhsDeActive"),
                OrderView = r.IsDBNull(r.GetOrdinal("OrderView")) ? null : Convert.ToInt32(r.GetValue(r.GetOrdinal("OrderView"))),
                RegisterDate = Reader.GetDateN(r, "RegisterDate"),
            }, ct).ContinueWith(t => new PagedResult<WarehouseDto> { Items = t.Result, HasMore = false }, TaskScheduler.Default);
}

// ═══════════════════════ محصولات ═══════════════════════
public class ProductRepository : IProductRepository
{
    private readonly IdealDb _db;

    public ProductRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Products"); }

    public Task<PagedResult<ProductDto>> GetProductsAsync(ProductListQuery q, CancellationToken ct = default)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (!string.IsNullOrWhiteSpace(q.Code)) p.Add("@code", q.Code.Trim());
            if (!string.IsNullOrWhiteSpace(q.Name)) p.Add("@name", "%" + q.Name.Trim() + "%");
            if (q.GroupId.HasValue) p.Add("@gid", q.GroupId);
            if (q.RegisteredFrom.HasValue) p.Add("@from", q.RegisteredFrom);
            if (q.RegisteredTo.HasValue) p.Add("@to", q.RegisteredTo);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (!string.IsNullOrWhiteSpace(q.Code)) where.Add("AND P.PrdCode = @code");
        if (!string.IsNullOrWhiteSpace(q.Name)) where.Add("AND P.PrdName LIKE @name");
        if (q.GroupId.HasValue) where.Add("AND P.PrdGroupID = @gid");
        if (q.RegisteredFrom.HasValue) where.Add("AND P.RegisterDate >= @from");
        if (q.RegisteredTo.HasValue) where.Add("AND P.RegisterDate <= @to");
        if (q.IsKeyset) where.Add("AND P.ProductID > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY P.ProductID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY P.ProductID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var sql = @"
SELECT P.ProductID, P.PrdGroupID, G.GroupName, P.PrdCode, P.PrdName, P.PrdLatinName,
       P.PrdType, P.PrdModel, P.PrdColorId, CL.Color, P.PrdUnitId, UN.UnitName,
       P.PrdFirstBarcode, P.PrdInActive, P.PrdInactiveInSale, P.PrdInactiveInBuy,
       P.PrdMinQuantity, P.PrdMaxQuantity, P.PrdWeight,
       P.RegisterDate, P.FirstRegisterDate
FROM dbo.WSProducts P
LEFT JOIN dbo.WSProductFirstGroup G ON G.ProductFirstGroupID = P.PrdGroupID
LEFT JOIN dbo.WSProductColor CL ON CL.ProductColorID = P.PrdColorId
LEFT JOIN dbo.WSProductUnit UN ON UN.ProductUnitID = P.PrdUnitId
WHERE 1 = 1 " + string.Join(' ', where) + " " + paging;
        return _db.QueryAsync(sql, Bind, Map, ct).ContinueWith(t => ConversationRepository.Finalize(t.Result, q), TaskScheduler.Default);
    }

    private static ProductDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "ProductID"),
        GroupId = Reader.GetIntN(r, "PrdGroupID"),
        GroupName = Reader.GetStr(r, "GroupName"),
        Code = Reader.GetStr(r, "PrdCode"),
        Name = Reader.GetStr(r, "PrdName"),
        LatinName = Reader.GetStr(r, "PrdLatinName"),
        Type = Reader.GetStr(r, "PrdType"),
        Model = Reader.GetStr(r, "PrdModel"),
        ColorId = Reader.GetIntN(r, "PrdColorId"),
        Color = Reader.GetStr(r, "Color"),
        UnitId = Reader.GetIntN(r, "PrdUnitId"),
        Unit = Reader.GetStr(r, "UnitName"),
        FirstBarcode = Reader.GetStr(r, "PrdFirstBarcode"),
        InActive = Reader.GetBoolN(r, "PrdInActive"),
        InactiveInSale = Reader.GetBoolN(r, "PrdInactiveInSale"),
        InactiveInBuy = Reader.GetBoolN(r, "PrdInactiveInBuy"),
        MinQuantity = r.IsDBNull(r.GetOrdinal("PrdMinQuantity")) ? null : Convert.ToInt32(r.GetValue(r.GetOrdinal("PrdMinQuantity"))),
        MaxQuantity = r.IsDBNull(r.GetOrdinal("PrdMaxQuantity")) ? null : Convert.ToInt32(r.GetValue(r.GetOrdinal("PrdMaxQuantity"))),
        Weight = Reader.GetDoubleN(r, "PrdWeight"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
        FirstRegisterDate = Reader.GetDateN(r, "FirstRegisterDate"),
    };
}

// ═══════════════════════ سفارش‌ها و پیش‌سفارش‌ها ═══════════════════════
public class OrderRepository : IOrderRepository
{
    private readonly IdealDb _db;

    public OrderRepository(IdealDb db, IDataAccessPolicy policy) { _db = db; _ = policy.Resolve("Orders"); _ = policy.Resolve("PreOrders"); }

    public Task<PagedResult<OrderDto>> GetOrdersAsync(OrderListQuery q, CancellationToken ct = default)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (q.Number.HasValue) p.Add("@num", q.Number);
            if (q.CompanyId.HasValue) p.Add("@cid", q.CompanyId);
            if (q.FromDate.HasValue) p.Add("@from", q.FromDate);
            if (q.ToDate.HasValue) p.Add("@to", q.ToDate);
            if (q.RegisteredFrom.HasValue) p.Add("@rfrom", q.RegisteredFrom);
            if (q.RegisteredTo.HasValue) p.Add("@rto", q.RegisteredTo);
            if (q.IsVerified.HasValue) p.Add("@ver", q.IsVerified);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (q.Number.HasValue) where.Add("AND O.ordNumber = @num");
        if (q.CompanyId.HasValue) where.Add("AND O.ordCompanyId = @cid");
        if (q.FromDate.HasValue) where.Add("AND O.ordDateTime >= @from");
        if (q.ToDate.HasValue) where.Add("AND O.ordDateTime <= @to");
        if (q.RegisteredFrom.HasValue) where.Add("AND O.RegisterDate >= @rfrom");
        if (q.RegisteredTo.HasValue) where.Add("AND O.RegisterDate <= @rto");
        if (q.IsVerified.HasValue) where.Add("AND O.ordIsVerified = @ver");
        if (q.IsKeyset) where.Add("AND O.OrderID > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY O.OrderID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY O.OrderID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var sql = @"
SELECT O.OrderID, O.OrderOprID, OP.Name AS OprName, O.ordNumber, O.ordTitle,
       O.ordDate, O.ordDateTime, O.ordCompanyId, CC.cmpName AS CompanyName,
       O.ordCompanyPersonId, O.ordProjectId, O.ordSubject, O.ordItemCount,
       O.ordItemsAmount, O.ordDiscount, O.ordSumAmount, O.ordTax, O.ordTotalAmount,
       O.ordIsVerified, O.ordStatusId, O.ordReferUserId, (RU.FName + N' ' + RU.LName) AS ReferUserName,
       O.RegisterDate, O.FirstRegisterDate
FROM dbo.WSOrder O
LEFT JOIN dbo.CrmCompany CC ON CC.CompanyID = O.ordCompanyId
LEFT JOIN dbo.WSOrderOpr OP ON OP.OrderOprID = O.OrderOprID
LEFT JOIN dbo.Users RU ON RU.UserId = O.ordReferUserId
WHERE 1 = 1 " + string.Join(' ', where) + " " + paging;
        return _db.QueryAsync(sql, Bind, Map, ct).ContinueWith(t => ConversationRepository.Finalize(t.Result, q), TaskScheduler.Default);
    }

    private static OrderDto Map(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "OrderID"),
        OprId = Reader.GetIntN(r, "OrderOprID"),
        Opr = Reader.GetStr(r, "OprName"),
        Number = Reader.GetLongN(r, "ordNumber"),
        Title = Reader.GetStr(r, "ordTitle"),
        Date = Reader.GetStr(r, "ordDate"),
        DateTime = Reader.GetDateN(r, "ordDateTime"),
        CompanyId = Reader.GetIntN(r, "ordCompanyId"),
        CompanyName = Reader.GetStr(r, "CompanyName"),
        CompanyPersonId = Reader.GetIntN(r, "ordCompanyPersonId"),
        ProjectId = Reader.GetIntN(r, "ordProjectId"),
        Subject = Reader.GetStr(r, "ordSubject"),
        ItemCount = Reader.GetIntN(r, "ordItemCount"),
        ItemsAmount = Reader.GetDecN(r, "ordItemsAmount"),
        Discount = Reader.GetDecN(r, "ordDiscount"),
        SumAmount = Reader.GetDecN(r, "ordSumAmount"),
        Tax = Reader.GetDecN(r, "ordTax"),
        TotalAmount = Reader.GetDecN(r, "ordTotalAmount"),
        IsVerified = Reader.GetBoolN(r, "ordIsVerified"),
        StatusId = Reader.GetIntN(r, "ordStatusId"),
        ReferUserId = Reader.GetIntN(r, "ordReferUserId"),
        ReferUser = Reader.GetStr(r, "ReferUserName"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
        FirstRegisterDate = Reader.GetDateN(r, "FirstRegisterDate"),
    };

    public Task<PagedResult<PreOrderDto>> GetPreOrdersAsync(PreOrderListQuery q, CancellationToken ct = default)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (q.Number.HasValue) p.Add("@num", q.Number);
            if (q.CompanyId.HasValue) p.Add("@cid", q.CompanyId);
            if (q.FromDate.HasValue) p.Add("@from", q.FromDate);
            if (q.ToDate.HasValue) p.Add("@to", q.ToDate);
            if (q.IsVerified.HasValue) p.Add("@ver", q.IsVerified);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);
        }
        if (q.Number.HasValue) where.Add("AND O.pordNumber = @num");
        if (q.CompanyId.HasValue) where.Add("AND O.pordCompanyId = @cid");
        if (q.FromDate.HasValue) where.Add("AND O.pordDateTime >= @from");
        if (q.ToDate.HasValue) where.Add("AND O.pordDateTime <= @to");
        if (q.IsVerified.HasValue) where.Add("AND O.pordIsVerified = @ver");
        if (q.IsKeyset) where.Add("AND O.PreOrderID > @afterId");
        var paging = q.IsKeyset
            ? "ORDER BY O.PreOrderID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY O.PreOrderID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
        var sql = @"
SELECT O.PreOrderID, O.PreOrderOprID, OP.Name AS OprName, O.pordNumber, O.pordTitle,
       O.pordDate, O.pordDateTime, O.pordCompanyId, CC.cmpName AS CompanyName,
       O.pordCompanyPersonId, O.pordProjectId, O.pordSubject, O.pordItemCount,
       O.pordItemsAmount, O.pordDiscount, O.pordSumAmount, O.pordTax, O.pordTotalAmount,
       O.pordIsVerified, O.pordStatusId, O.pordReferUserId, (RU.FName + N' ' + RU.LName) AS ReferUserName,
       O.RegisterDate, O.FirstRegisterDate, O.pordChangeStatusDate
FROM dbo.WSPreOrder O
LEFT JOIN dbo.CrmCompany CC ON CC.CompanyID = O.pordCompanyId
LEFT JOIN dbo.WSOrderOpr OP ON OP.OrderOprID = O.PreOrderOprID
LEFT JOIN dbo.Users RU ON RU.UserId = O.pordReferUserId
WHERE 1 = 1 " + string.Join(' ', where) + " " + paging;
        return _db.QueryAsync(sql, Bind, MapPre, ct).ContinueWith(t => ConversationRepository.Finalize(t.Result, q), TaskScheduler.Default);
    }

    private static PreOrderDto MapPre(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "PreOrderID"),
        OprId = Reader.GetIntN(r, "PreOrderOprID"),
        Opr = Reader.GetStr(r, "OprName"),
        Number = Reader.GetLongN(r, "pordNumber"),
        Title = Reader.GetStr(r, "pordTitle"),
        Date = Reader.GetStr(r, "pordDate"),
        DateTime = Reader.GetDateN(r, "pordDateTime"),
        CompanyId = Reader.GetIntN(r, "pordCompanyId"),
        CompanyName = Reader.GetStr(r, "CompanyName"),
        CompanyPersonId = Reader.GetIntN(r, "pordCompanyPersonId"),
        ProjectId = Reader.GetIntN(r, "pordProjectId"),
        Subject = Reader.GetStr(r, "pordSubject"),
        ItemCount = Reader.GetIntN(r, "pordItemCount"),
        ItemsAmount = Reader.GetDecN(r, "pordItemsAmount"),
        Discount = Reader.GetDecN(r, "pordDiscount"),
        SumAmount = Reader.GetDecN(r, "pordSumAmount"),
        Tax = Reader.GetDecN(r, "pordTax"),
        TotalAmount = Reader.GetDecN(r, "pordTotalAmount"),
        IsVerified = Reader.GetBoolN(r, "pordIsVerified"),
        StatusId = Reader.GetIntN(r, "pordStatusId"),
        ReferUserId = Reader.GetIntN(r, "pordReferUserId"),
        ReferUser = Reader.GetStr(r, "ReferUserName"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
        FirstRegisterDate = Reader.GetDateN(r, "FirstRegisterDate"),
        ChangeStatusDate = Reader.GetDateN(r, "pordChangeStatusDate"),
    };
}

// ═══════════════════════ اطلاعات پایه ═══════════════════════
public class BaseInfoRepository : IBaseInfoRepository
{
    private readonly IdealDb _db;

    // جداول مرجع BaseInfo در نقشهٔ سیاست نیستند؛ اگر جدولی مفقود باشد خطای SQL شفاف (503) برمی‌گردد.
    public BaseInfoRepository(IdealDb db) { _db = db; }

    private static readonly Dictionary<BaseInfoKind, (string table, string id, string name)> Map = new()
    {
        [BaseInfoKind.CompanyTitle] = ("CrmCompanyTitle", "CompanyTitleID", "CompanyTitle"),
        [BaseInfoKind.CompanyType] = ("CrmCompanyType", "CompanyTypeID", "CompanyTypeName"),
        [BaseInfoKind.CompanyGroup] = ("CrmCompanyGroups", "CompanyGroupID", "GroupName"),
        [BaseInfoKind.CompanySubGroup] = ("CrmCompanySubGroups", "CompanySubGroupID", "SubGroupName"),
        [BaseInfoKind.CompanyGroupII] = ("CrmCompanyGroupsII", "CompanyGroupIIID", "GroupIIName"),
        [BaseInfoKind.CompanyGroupIII] = ("CrmCompanyGroupsIII", "CompanyGroupIIIID", "GroupIIIName"),
        [BaseInfoKind.CompanyGroupIV] = ("CrmCompanyGroupsIV", "CompanyGroupIVID", "GroupIVName"),
        [BaseInfoKind.CompanyPresentation] = ("CrmCompanyPresentation", "CompanyPresentationID", "Presentation"),
        [BaseInfoKind.CompanyAddressType] = ("CrmCompanyAddressType", "CompanyAddressTypeID", "CompanyAddressType"),
        [BaseInfoKind.PersonTitle] = ("CrmPersonTitle", "PersonTitleID", "PersonTitle"),
        [BaseInfoKind.PersonType] = ("CrmPersonType", "PersonTypeID", "PersonType"),
        [BaseInfoKind.PersonJob] = ("CrmPersonJob", "JobID", "Job"),
        [BaseInfoKind.PersonDepartment] = ("CrmPersonDepartments", "DepartmentID", "Department"),
        [BaseInfoKind.PersonGroup] = ("CrmPersonGroups", "PersonGroupID", "GroupName"),
        [BaseInfoKind.Education] = ("Education", "EducationID", "Education"),
        [BaseInfoKind.Sex] = ("Sex", "SexID", "Sex"),
        [BaseInfoKind.City] = ("City", "CityID", "City"),
        [BaseInfoKind.Province] = ("Province", "ProvinceID", "Province"),
        [BaseInfoKind.Country] = ("Country", "CountryID", "Country"),
        [BaseInfoKind.ProjectTitle] = ("CrmProjectTitles", "ProjectTitleID", "ProjectTitle"),
        [BaseInfoKind.ProjectGroup] = ("CrmProjectGroups", "ProjectGroupID", "GroupName"),
        [BaseInfoKind.ProjectGrade] = ("CrmProjectGrade", "ProjectGradeID", "GradeName"),
        [BaseInfoKind.ProjectPriority] = ("CrmProjectPriority", "ProjectPriorityID", "Priority"),
    };

    public Task<IReadOnlyList<BaseInfoDto>> GetAsync(BaseInfoKind kind, CancellationToken ct = default)
    {
        if (!Map.TryGetValue(kind, out var spec))
            throw new ArgumentOutOfRangeException(nameof(kind));
        var (table, idCol, nameCol) = spec;
        var parentCol = kind switch
        {
            BaseInfoKind.City => "ProvinceId",
            BaseInfoKind.Province => "CountryId",
            BaseInfoKind.CompanySubGroup => "CompanyGroupID",
            _ => null
        };
        var parentSel = parentCol != null ? $", {parentCol} AS ParentId" : ", NULL AS ParentId";
        var sql = $"SELECT {idCol} AS Id, {nameCol} AS Name{parentSel}, NULL AS Code, NULL AS Description, NULL AS IsActive, NULL AS OrderView FROM dbo.{table} ORDER BY {idCol}";
        return _db.QueryAsync(sql, null, r => new BaseInfoDto
        {
            Id = Reader.GetInt(r, "Id"),
            Name = Reader.GetStr(r, "Name"),
            ParentId = Reader.GetIntN(r, "ParentId"),
        }, ct);
    }
}
