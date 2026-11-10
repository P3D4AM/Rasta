using System.Data.Common;
using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Dto;
using IdealBridge.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using IdealBridge.Domain.Common;

namespace IdealBridge.Infrastructure.Repositories;

/// <summary>
/// مخزن مشتریان — دو حالت:
///  - Table: SELECT پارامتری مستقیم روی CrmCompany + JOIN جدول‌های مرجع (پایدارترین حالت بین نسخه‌ها)
///  - Sp: فراخوانی ApispSelectCompany (خروجی غنی‌تر؛ فقط وقتی کاوش امضا تأیید کند)
/// انتخاب حالت توسط DataAccessModeSelector (Auto/Sp/Table) در DI تزریق می‌شود.
/// </summary>
public class CompanyRepository : ICompanyRepository
{
    private readonly IdealDb _db;
    private readonly string _mode;   // "Table" یا "Sp"
    private readonly ILogger<CompanyRepository> _logger;

    public CompanyRepository(IdealDb db, SchemaModeProvider modeProvider, ILogger<CompanyRepository> logger)
    {
        _db = db;
        _mode = modeProvider.Get("Companies");
        _logger = logger;
    }

    public Task<PagedResult<CompanyDto>> GetCompaniesAsync(CompanyListQuery q, CancellationToken ct = default)
        => _mode == "Sp" && !q.IsKeyset
            ? GetCompaniesSpAsync(q, ct)
            : GetCompaniesTableAsync(q, ct);

    public Task<CompanyDto?> GetCompanyAsync(int id, CancellationToken ct = default)
        => _mode == "Sp" ? GetCompanySpAsync(id, ct) : GetCompanyTableAsync(id, ct);

    // ---------------- حالت Table ----------------

    private const string CompanySelectBase = @"
SELECT CC.CompanyID, CC.cmpNumber, CC.cmpCode, CC.cmpName, CC.cmpNameEng, CC.cmpNameOfficial,
       CC.cmpFame, CC.cmpActivityType,
       CC.cmpTitleId, CT.CompanyTitle,
       CC.cmpGroupId,  CG.GroupName,
       CC.cmpSubGroupId, CSG.SubGroupName,
       CC.cmpGroupIdII, CG2.GroupIIName,
       CC.cmpGroupIdIII, CG3.GroupIIIName,
       CC.cmpGroupIdIV, CG4.GroupIVName,
       CC.cmpTypeId, CTy.CompanyTypeName,
       CC.cmpPresentationId, CP.Presentation,
       CC.cmpPreTel, CC.cmpTel, CC.cmpTelUpTo, CC.cmpTelDesc,
       CC.cmpPreTelII, CC.cmpTelII, CC.cmpTelUpToII, CC.cmpTelIIDesc,
       CC.cmpMobile, CC.cmpFax, CC.cmpFaxDesc,
       CC.cmpCountryId, CO.Country, CC.cmpProvinceId, PR.Province, CC.cmpCityId, CI.City,
       CC.cmpAddress, CC.cmpAddressDesc, CC.cmpZipCode, CC.cmpPostBox,
       CC.cmpWebSite, CC.cmpEmail,
       CC.cmpCoordinateLatitude, CC.cmpCoordinateLongitude, CC.cmpCoordinateZoomLevel, CC.cmpCoordinateLastDate,
       CC.cmpRegistrationNumber, CC.cmpEconomicCode, CC.cmpNationalCode, CC.cmpBuyLimit, CC.cmpAccountNumber,
       CC.cmpReferUserId, RU.FName + N' ' + RU.LName AS ReferUser,
       CC.UserId AS LastEditUserId, LU.FName + N' ' + LU.LName AS LastEditUser,
       CC.FirstRegisterUserId, FU.FName + N' ' + FU.LName AS FirstRegisterUser,
       CC.cmpMainPersonId,
       (SELECT TOP 1 PT.PersonTitle + N' ' + P.prsFName + N' ' + P.prsLName
          FROM dbo.CrmCompanyPersons P LEFT JOIN dbo.CrmPersonTitle PT ON PT.PersonTitleID = P.prsTitleId
         WHERE P.CompanyPersonID = CC.cmpMainPersonId) AS MainPersonName,
       CC.cmpIsDraft, CC.cmpKind,
       CC.RegisterDate, CC.RegisterDatePersian, CC.FirstRegisterDate, CC.ImportDate, CC.ImportDateTime,
       CC.cmpInteresting, CC.cmpSpecialPoint, CC.cmpDescription
FROM dbo.CrmCompany CC
LEFT JOIN dbo.CrmCompanyTitle CT ON CT.CompanyTitleID = CC.cmpTitleId
LEFT JOIN dbo.CrmCompanyGroups CG ON CG.CompanyGroupID = CC.cmpGroupId
LEFT JOIN dbo.CrmCompanySubGroups CSG ON CSG.CompanySubGroupID = CC.cmpSubGroupId
LEFT JOIN dbo.CrmCompanyGroupsII CG2 ON CG2.CompanyGroupIIID = CC.cmpGroupIdII
LEFT JOIN dbo.CrmCompanyGroupsIII CG3 ON CG3.CompanyGroupIIIID = CC.cmpGroupIdIII
LEFT JOIN dbo.CrmCompanyGroupsIV CG4 ON CG4.CompanyGroupIVID = CC.cmpGroupIdIV
LEFT JOIN dbo.CrmCompanyType CTy ON CTy.CompanyTypeID = CC.cmpTypeId
LEFT JOIN dbo.CrmCompanyPresentation CP ON CP.CompanyPresentationID = CC.cmpPresentationId
LEFT JOIN dbo.Country CO ON CO.CountryID = CC.cmpCountryId
LEFT JOIN dbo.Province PR ON PR.ProvinceID = CC.cmpProvinceId
LEFT JOIN dbo.City CI ON CI.CityID = CC.cmpCityId
LEFT JOIN dbo.Users RU ON RU.UserId = CC.cmpReferUserId
LEFT JOIN dbo.Users LU ON LU.UserId = CC.UserId
LEFT JOIN dbo.Users FU ON FU.UserId = CC.FirstRegisterUserId
WHERE 1 = 1 ";

    private async Task<PagedResult<CompanyDto>> GetCompaniesTableAsync(CompanyListQuery q, CancellationToken ct)
    {
        var where = new List<string>();
        void Bind(DbParameterCollection p)
        {
            if (q.Number.HasValue) p.Add("@cmpNumber", q.Number);
            if (!string.IsNullOrWhiteSpace(q.Code)) p.Add("@cmpCode", q.Code.Trim());
            if (!string.IsNullOrWhiteSpace(q.Name)) p.Add("@cmpName", "%" + q.Name.Trim() + "%");
            if (q.RegisteredFrom.HasValue) p.Add("@regFrom", q.RegisteredFrom);
            if (q.RegisteredTo.HasValue) p.Add("@regTo", q.RegisteredTo);
            if (q.FirstRegisteredFrom.HasValue) p.Add("@fregFrom", q.FirstRegisteredFrom);
            if (q.FirstRegisteredTo.HasValue) p.Add("@fregTo", q.FirstRegisteredTo);
            if (q.ReferUserId.HasValue) p.Add("@referUid", q.ReferUserId);
            if (q.IsDraft.HasValue) p.Add("@isDraft", q.IsDraft);
            if (q.IsKeyset) p.Add("@afterId", q.AfterId!.Value);
            p.Add("@skip", q.Skip);
            p.Add("@take", q.Take + 1);   // یکی اضافه برای تشخیص HasMore
        }

        if (q.Number.HasValue) where.Add("AND CC.cmpNumber = @cmpNumber");
        if (!string.IsNullOrWhiteSpace(q.Code)) where.Add("AND CC.cmpCode = @cmpCode");
        if (!string.IsNullOrWhiteSpace(q.Name)) where.Add("AND CC.cmpName LIKE @cmpName");
        if (q.RegisteredFrom.HasValue) where.Add("AND CC.RegisterDate >= @regFrom");
        if (q.RegisteredTo.HasValue) where.Add("AND CC.RegisterDate <= @regTo");
        if (q.FirstRegisteredFrom.HasValue) where.Add("AND CC.FirstRegisterDate >= @fregFrom");
        if (q.FirstRegisteredTo.HasValue) where.Add("AND CC.FirstRegisterDate <= @fregTo");
        if (q.ReferUserId.HasValue) where.Add("AND CC.cmpReferUserId = @referUid");
        if (q.IsDraft.HasValue) where.Add("AND CC.cmpIsDraft = @isDraft");
        if (q.IsKeyset) where.Add("AND CC.CompanyID > @afterId");

        var whereSql = string.Join(" ", where);
        var paging = q.IsKeyset
            ? "ORDER BY CC.CompanyID OFFSET 0 ROWS FETCH NEXT @take ROWS ONLY"
            : "ORDER BY CC.CompanyID OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";

        var rows = await _db.QueryAsync(CompanySelectBase + whereSql + " " + paging, Bind, MapCompany, ct);
        return Finalize(rows, q);
    }

    private async Task<CompanyDto?> GetCompanyTableAsync(int id, CancellationToken ct)
    {
        var rows = await _db.QueryAsync(CompanySelectBase + " AND CC.CompanyID = @id ORDER BY CC.CompanyID",
            p => p.Add("@id", id), MapCompany, ct);
        return rows.FirstOrDefault();
    }

    // ---------------- حالت SP ----------------

    private async Task<PagedResult<CompanyDto>> GetCompaniesSpAsync(CompanyListQuery q, CancellationToken ct)
    {
        // فقط با پارامترهای خواندنی فراخوانی می‌شود؛ صفحه‌بندی SP برای پایداری به همان شکل پاس داده می‌شود
        var rows = await _db.QuerySpAsync("ApispSelectCompany", p =>
        {
            p.Add("@CompanyId", null);
            p.Add("@CmpCode", string.IsNullOrWhiteSpace(q.Code) ? null : q.Code.Trim());
            p.Add("@CmpNumber", (object?)q.Number ?? DBNull.Value);
            p.Add("@FromRegisterDate", q.RegisteredFrom);
            p.Add("@ToRegisterDate", q.RegisteredTo);
            p.Add("@FromFirstRegisterDate", q.FirstRegisteredFrom);
            p.Add("@ToFirstRegisterDate", q.FirstRegisteredTo);
            p.Add("@LanguageID", null);
            p.Add("@DefaultLanguageID", null);
            p.Add("@CenterId", null);
            p.Add("@CenterCode", null);
            p.Add("@PageNumber", q.Page);
            p.Add("@PageSize", q.PageSize);
        }, MapCompanyLegacy, ct);
        return Finalize(rows, q);
    }

    private async Task<CompanyDto?> GetCompanySpAsync(int id, CancellationToken ct)
    {
        var rows = await _db.QuerySpAsync("ApispSelectCompany", p =>
        {
            p.Add("@CompanyId", id);
            p.Add("@CmpCode", null);
            p.Add("@CmpNumber", DBNull.Value);
            p.Add("@FromRegisterDate", null);
            p.Add("@ToRegisterDate", null);
            p.Add("@FromFirstRegisterDate", null);
            p.Add("@ToFirstRegisterDate", null);
            p.Add("@LanguageID", null);
            p.Add("@DefaultLanguageID", null);
            p.Add("@CenterId", null);
            p.Add("@CenterCode", null);
            p.Add("@PageNumber", 0);
            p.Add("@PageSize", 0);
        }, MapCompanyLegacy, ct);
        return rows.FirstOrDefault();
    }

    // ---------------- آدرس‌ها ----------------

    public Task<IReadOnlyList<CompanyAddressDto>> GetAddressesAsync(int companyId, CancellationToken ct = default)
        => _db.QueryAsync(@"
SELECT A.CompanyAddressId, A.cmpaddCompanyId, A.cmpaddTypeId, T.CompanyAddressType,
       A.cmpaddCityId, C.City, A.CompanyAddress, A.cmpaddDesc, A.cmpaddZipCode, A.cmpaddPostBox,
       A.cmpaddCoordinateLatitude, A.cmpaddCoordinateLongitude, A.cmpaddCoordinateZoomLevel,
       A.cmpaddCoordinateLastDate, A.RegisterDate
FROM dbo.CrmCompanyAddresses A
LEFT JOIN dbo.CrmCompanyAddressType T ON T.CompanyAddressTypeID = A.cmpaddTypeId
LEFT JOIN dbo.City C ON C.CityID = A.cmpaddCityId
WHERE A.cmpaddCompanyId = @companyId
ORDER BY A.CompanyAddressId",
            p => p.Add("@companyId", companyId),
            r => new CompanyAddressDto
            {
                Id = Reader.GetInt(r, "CompanyAddressId"),
                CompanyId = Reader.GetInt(r, "cmpaddCompanyId"),
                TypeId = Reader.GetIntN(r, "cmpaddTypeId"),
                Type = Reader.GetStr(r, "CompanyAddressType"),
                CityId = Reader.GetIntN(r, "cmpaddCityId"),
                City = Reader.GetStr(r, "City"),
                Address = Reader.GetStr(r, "CompanyAddress"),
                Description = Reader.GetStr(r, "cmpaddDesc"),
                ZipCode = Reader.GetStr(r, "cmpaddZipCode"),
                PostBox = Reader.GetStr(r, "cmpaddPostBox"),
                Latitude = Reader.GetStr(r, "cmpaddCoordinateLatitude"),
                Longitude = Reader.GetStr(r, "cmpaddCoordinateLongitude"),
                CoordinateZoomLevel = Reader.GetIntN(r, "cmpaddCoordinateZoomLevel"),
                CoordinateLastDate = Reader.GetDateN(r, "cmpaddCoordinateLastDate"),
                RegisterDate = Reader.GetDateN(r, "RegisterDate"),
            }, ct);

    // ---------------- نگاشت ----------------

    /// <summary>نگاشت حالت Table (ستون‌های جدول CrmCompany + JOINها).</summary>
    private static CompanyDto MapCompany(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "CompanyID"),
        Number = Reader.GetIntN(r, "cmpNumber"),
        Code = Reader.GetStr(r, "cmpCode"),
        Name = Reader.GetStr(r, "cmpName") ?? string.Empty,
        NameEnglish = Reader.GetStr(r, "cmpNameEng"),
        NameOfficial = Reader.GetStr(r, "cmpNameOfficial"),
        Fame = Reader.GetStr(r, "cmpFame"),
        ActivityType = Reader.GetStr(r, "cmpActivityType"),
        TitleId = Reader.GetIntN(r, "cmpTitleId"),
        Title = Reader.GetStr(r, "CompanyTitle"),
        GroupId = Reader.GetIntN(r, "cmpGroupId"),
        Group = Reader.GetStr(r, "GroupName"),
        SubGroupId = Reader.GetIntN(r, "cmpSubGroupId"),
        SubGroup = Reader.GetStr(r, "SubGroupName"),
        GroupIiId = Reader.GetIntN(r, "cmpGroupIdII"),
        GroupIi = Reader.GetStr(r, "GroupIIName"),
        GroupIiiId = Reader.GetIntN(r, "cmpGroupIdIII"),
        GroupIii = Reader.GetStr(r, "GroupIIIName"),
        GroupIvId = Reader.GetIntN(r, "cmpGroupIdIV"),
        GroupIv = Reader.GetStr(r, "GroupIVName"),
        TypeId = Reader.GetIntN(r, "cmpTypeId"),
        Type = Reader.GetStr(r, "CompanyTypeName"),
        PresentationId = Reader.GetIntN(r, "cmpPresentationId"),
        Presentation = Reader.GetStr(r, "Presentation"),
        PreTel = Reader.GetStr(r, "cmpPreTel"),
        Tel = Reader.GetStr(r, "cmpTel"),
        TelUpTo = Reader.GetStr(r, "cmpTelUpTo"),
        TelDesc = Reader.GetStr(r, "cmpTelDesc"),
        PreTel2 = Reader.GetStr(r, "cmpPreTelII"),
        Tel2 = Reader.GetStr(r, "cmpTelII"),
        Tel2UpTo = Reader.GetStr(r, "cmpTelUpToII"),
        Tel2Desc = Reader.GetStr(r, "cmpTelIIDesc"),
        Mobile = Reader.GetStr(r, "cmpMobile"),
        Fax = Reader.GetStr(r, "cmpFax"),
        FaxDesc = Reader.GetStr(r, "cmpFaxDesc"),
        CountryId = Reader.GetIntN(r, "cmpCountryId"),
        Country = Reader.GetStr(r, "Country"),
        ProvinceId = Reader.GetIntN(r, "cmpProvinceId"),
        Province = Reader.GetStr(r, "Province"),
        CityId = Reader.GetIntN(r, "cmpCityId"),
        City = Reader.GetStr(r, "City"),
        Address = Reader.GetStr(r, "cmpAddress"),
        AddressDesc = Reader.GetStr(r, "cmpAddressDesc"),
        ZipCode = Reader.GetStr(r, "cmpZipCode"),
        PostBox = Reader.GetStr(r, "cmpPostBox"),
        WebSite = Reader.GetStr(r, "cmpWebSite"),
        Email = Reader.GetStr(r, "cmpEmail"),
        Latitude = Reader.GetStr(r, "cmpCoordinateLatitude"),
        Longitude = Reader.GetStr(r, "cmpCoordinateLongitude"),
        CoordinateZoomLevel = Reader.GetIntN(r, "cmpCoordinateZoomLevel"),
        CoordinateLastDate = Reader.GetDateN(r, "cmpCoordinateLastDate"),
        RegistrationNumber = Reader.GetStr(r, "cmpRegistrationNumber"),
        EconomicCode = Reader.GetStr(r, "cmpEconomicCode"),
        NationalCode = Reader.GetStr(r, "cmpNationalCode"),
        BuyLimit = Reader.GetStr(r, "cmpBuyLimit"),
        AccountNumber = Reader.GetStr(r, "cmpAccountNumber"),
        ReferUserId = Reader.GetIntN(r, "cmpReferUserId"),
        ReferUser = Reader.GetStr(r, "ReferUser"),
        LastEditUserId = Reader.GetIntN(r, "LastEditUserId"),
        LastEditUser = Reader.GetStr(r, "LastEditUser"),
        FirstRegisterUserId = Reader.GetIntN(r, "FirstRegisterUserId"),
        FirstRegisterUser = Reader.GetStr(r, "FirstRegisterUser"),
        MainPersonId = Reader.GetIntN(r, "cmpMainPersonId"),
        MainPersonName = Reader.GetStr(r, "MainPersonName"),
        IsDraft = Reader.GetBoolN(r, "cmpIsDraft"),
        Kind = Reader.GetIntN(r, "cmpKind"),
        RegisterDate = Reader.GetDateN(r, "RegisterDate"),
        RegisterDatePersian = Reader.GetStr(r, "RegisterDatePersian"),
        FirstRegisterDate = Reader.GetDateN(r, "FirstRegisterDate"),
        ImportDate = Reader.GetStr(r, "ImportDate"),
        ImportDateTime = Reader.GetDateN(r, "ImportDateTime"),
        Interesting = Reader.GetStr(r, "cmpInteresting"),
        SpecialPoint = Reader.GetStr(r, "cmpSpecialPoint"),
        Description = Reader.GetStr(r, "cmpDescription"),
    };

    /// <summary>
    /// نگاشت حالت SP (ستون‌های Api* خروجی ApispSelectCompany).
    /// توجه: ApiCmpUserName/ApiCmpPassword عمداً نگاشت نمی‌شوند — سیاست حذف اطلاعات حساس.
    /// </summary>
    private static CompanyDto MapCompanyLegacy(DbDataReader r) => new()
    {
        Id = Reader.GetInt(r, "ApiCompanyID"),
        Number = Reader.GetIntN(r, "ApiCmpNumber"),
        Code = Reader.GetStr(r, "ApiCmpCode"),
        Name = Reader.GetStr(r, "ApiCmpName") ?? string.Empty,
        NameEnglish = Reader.GetStr(r, "ApiCmpNameEng"),
        NameOfficial = Reader.GetStr(r, "ApiCmpNameOfficial"),
        Fame = Reader.GetStr(r, "ApiCmpFame"),
        ActivityType = Reader.GetStr(r, "ApiCmpActivityType"),
        TitleId = Reader.GetIntN(r, "ApiCmpTitleId"),
        Title = Reader.GetStr(r, "ApiCmpTitle"),
        GroupId = Reader.GetIntN(r, "ApiCmpGroupId"),
        Group = Reader.GetStr(r, "ApiCmpGroup"),
        SubGroupId = Reader.GetIntN(r, "ApiCmpSubGroupId"),
        SubGroup = Reader.GetStr(r, "ApiCmpSubGroup"),
        GroupIiId = Reader.GetIntN(r, "ApiCmpGroupIdII"),
        GroupIi = Reader.GetStr(r, "ApiCmpGroupII"),
        GroupIiiId = Reader.GetIntN(r, "ApiCmpGroupIdIII"),
        GroupIii = Reader.GetStr(r, "ApiCmpGroupIII"),
        GroupIvId = Reader.GetIntN(r, "ApiCmpGroupIdIV"),
        GroupIv = Reader.GetStr(r, "ApiCmpGroupIV"),
        TypeId = Reader.GetIntN(r, "ApiCmpTypeId"),
        Type = Reader.GetStr(r, "ApiCmpType"),
        PresentationId = Reader.GetIntN(r, "ApiCmpPresentationId"),
        Presentation = Reader.GetStr(r, "ApiCmpPresentation"),
        PreTel = Reader.GetStr(r, "ApiCmpPreTel"),
        Tel = Reader.GetStr(r, "ApiCmpTel"),
        TelUpTo = Reader.GetStr(r, "ApiCmpTelUpTo"),
        TelDesc = Reader.GetStr(r, "ApiCmpTelDesc"),
        PreTel2 = Reader.GetStr(r, "ApiCmpPreTelII"),
        Tel2 = Reader.GetStr(r, "ApiCmpTelII"),
        Tel2UpTo = Reader.GetStr(r, "ApiCmpTelUpToII"),
        Tel2Desc = Reader.GetStr(r, "ApiCmpTelIIDesc"),
        Mobile = Reader.GetStr(r, "ApiCmpMobile"),
        Fax = Reader.GetStr(r, "ApiCmpFax"),
        FaxDesc = Reader.GetStr(r, "ApiCmpFaxDesc"),
        CountryId = Reader.GetIntN(r, "ApiCmpCountryId"),
        Country = Reader.GetStr(r, "ApiCmpCountry"),
        ProvinceId = Reader.GetIntN(r, "ApiCmpProvinceId"),
        Province = Reader.GetStr(r, "ApiCmpProvince"),
        CityId = Reader.GetIntN(r, "ApiCmpCityId"),
        City = Reader.GetStr(r, "ApiCmpCity"),
        Address = Reader.GetStr(r, "ApiCmpAddress"),
        AddressDesc = Reader.GetStr(r, "ApiCmpAddressDesc"),
        ZipCode = Reader.GetStr(r, "ApiCmpZipCode"),
        PostBox = Reader.GetStr(r, "ApiCmpPostBox"),
        WebSite = Reader.GetStr(r, "ApiCmpWebSite"),
        Email = Reader.GetStr(r, "ApiCmpEmail"),
        Latitude = Reader.GetStr(r, "ApiCmpCoordinateLatitude"),
        Longitude = Reader.GetStr(r, "ApiCmpCoordinateLongitude"),
        CoordinateZoomLevel = Reader.GetIntN(r, "ApiCmpCoordinateZoomLevel"),
        CoordinateLastDate = Reader.GetDateN(r, "ApiCmpCoordinateLastDate"),
        RegistrationNumber = Reader.GetStr(r, "ApiCmpRegistrationNumber"),
        EconomicCode = Reader.GetStr(r, "ApiCmpEconomicCode"),
        NationalCode = Reader.GetStr(r, "ApiCmpNationalCode"),
        BuyLimit = Reader.GetStr(r, "ApiCmpBuyLimit"),
        AccountNumber = Reader.GetStr(r, "ApiCmpAccountNumber"),
        ReferUserId = Reader.GetIntN(r, "ApiCmpReferUserId"),
        ReferUser = Reader.GetStr(r, "ApiCmpReferUser"),
        LastEditUserId = Reader.GetIntN(r, "ApiUserId"),
        LastEditUser = Reader.GetStr(r, "ApiEditUser"),
        FirstRegisterUserId = Reader.GetIntN(r, "ApiFirstRegisterUserId"),
        FirstRegisterUser = Reader.GetStr(r, "ApiFirstRegisterUser"),
        MainPersonId = Reader.GetIntN(r, "ApiCmpMainPersonId"),
        MainPersonName = Reader.GetStr(r, "ApiCmpMainPerson"),
        IsDraft = Reader.GetBoolN(r, "ApiCmpIsDraft"),
        Kind = Reader.GetIntN(r, "ApiCmpKind"),
        RegisterDate = GetDateLikeN(r, "ApiCmpRegisterDate"),
        FirstRegisterDate = Reader.GetDateN(r, "ApiFirstRegisterDate"),
        ImportDate = Reader.GetStr(r, "ApiCmpImportDate"),
        ImportDateTime = Reader.GetDateN(r, "ApiCmpImportDateTime"),
        Interesting = Reader.GetStr(r, "ApiCmpInteresting"),
        SpecialPoint = Reader.GetStr(r, "ApiCmpSpecialPoint"),
        Description = Reader.GetStr(r, "ApiCmpDescription"),
        LegacyRowNumber = Reader.GetLongN(r, "ApiRowNumber"),
        LegacyTotalCount = Reader.GetIntN(r, "ApiTotalCount"),
    };

    /// <summary>ApiCmpRegisterDate در SP قدیمی گاهی DateTime و گاهی رشته است — خواندن امن.</summary>
    private static DateTime? GetDateLikeN(DbDataReader r, string col)
    {
        var i = r.GetOrdinal(col);
        if (r.IsDBNull(i)) return null;
        return r.GetFieldType(i) == typeof(DateTime) ? r.GetDateTime(i) : DateTime.TryParse(r.GetValue(i)?.ToString(), out var d) ? d : null;
    }

    // ---------------- صفحه‌بندی ----------------

    private static PagedResult<T> Finalize<T>(IReadOnlyList<T> rows, PagedQuery q) where T : class
    {
        // چون یکی بیشتر واکشی کرده‌ایم، HasMore قابل تشخیص است بدون COUNT اضافه
        var hasMore = rows.Count > q.Take;
        var page = rows.Count > q.Take ? rows.Take(q.Take).ToList() : rows.ToList();
        var nextAfter = page.Count > 0 ? (int?)GetPropertyId(page[^1]) : null;
        return new PagedResult<T>
        {
            Items = page,
            HasMore = hasMore,
            NextAfterId = nextAfter,
        };
    }

    private static object GetPropertyId<T>(T item) where T : class
        => typeof(T).GetProperty("Id")?.GetValue(item) ?? 0;
}
