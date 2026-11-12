using System.Data.Common;
using IdealBridge.Application.Interfaces;
using IdealBridge.Domain.Dto;
using IdealBridge.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using IdealBridge.Domain.Common;

namespace IdealBridge.Infrastructure.Repositories;

/// <summary>
/// مخزن مشتریان — تنها مسیر اجرایی: SELECT پارامتری مستقیم روی CrmCompany + JOIN جدول‌های مرجع
/// (پایدارترین حالت بین نسخه‌های Ideal).
/// از فاز ۱۱: مسیر SP حذف شد — اجرای Stored Procedure در کل سرویس غیرفعال است و
/// سیاست دسترسی به‌صورت مرکزی توسط DataAccessPolicy اعمال می‌شود (Blocked = خطای شفاف، نه آرایهٔ خالی).
/// </summary>
public class CompanyRepository : ICompanyRepository
{
    private readonly IdealDb _db;
    private readonly ILogger<CompanyRepository> _logger;

    public CompanyRepository(IdealDb db, IDataAccessPolicy policy, ILogger<CompanyRepository> logger)
    {
        _db = db;
        _ = policy.Resolve("Companies");   // اگر Blocked باشد همین‌جا با خطای شفاف شکست می‌خورد
        _logger = logger;
    }

    public Task<PagedResult<CompanyDto>> GetCompaniesAsync(CompanyListQuery q, CancellationToken ct = default)
        => GetCompaniesTableAsync(q, ct);

    public Task<CompanyDto?> GetCompanyAsync(int id, CancellationToken ct = default)
        => GetCompanyTableAsync(id, ct);

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
