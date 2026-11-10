namespace IdealBridge.Domain.Dto;

/// <summary>
/// مشتری (Company) — نگاشت امنِ زیرمجموعهٔ میدان‌های CrmCompany / خروجی ApispSelectCompany.
/// هیچ فیلد رمز عبور (cmpPassword / Password) در این DTO وجود ندارد.
/// </summary>
public class CompanyDto
{
    public int Id { get; set; }                    // CompanyID
    public int? Number { get; set; }               // cmpNumber — شمارهٔ مشتری
    public string? Code { get; set; }              // cmpCode — کد مشتری
    public string Name { get; set; } = string.Empty;        // cmpName
    public string? NameEnglish { get; set; }       // cmpNameEng
    public string? NameOfficial { get; set; }      // cmpNameOfficial
    public string? Fame { get; set; }              // cmpFame — آوازه/نام تجاری
    public string? ActivityType { get; set; }      // cmpActivityType

    // دسته‌بندی
    public int? TitleId { get; set; }
    public string? Title { get; set; }
    public int? GroupId { get; set; }
    public string? Group { get; set; }
    public int? SubGroupId { get; set; }
    public string? SubGroup { get; set; }
    public int? GroupIiId { get; set; }
    public string? GroupIi { get; set; }
    public int? GroupIiiId { get; set; }
    public string? GroupIii { get; set; }
    public int? GroupIvId { get; set; }
    public string? GroupIv { get; set; }
    public int? TypeId { get; set; }
    public string? Type { get; set; }
    public int? PresentationId { get; set; }
    public string? Presentation { get; set; }

    // تماس
    public string? PreTel { get; set; }
    public string? Tel { get; set; }
    public string? TelUpTo { get; set; }           // داخلی
    public string? TelDesc { get; set; }
    public string? PreTel2 { get; set; }
    public string? Tel2 { get; set; }
    public string? Tel2UpTo { get; set; }
    public string? Tel2Desc { get; set; }
    public string? Mobile { get; set; }
    public string? Fax { get; set; }
    public string? FaxDesc { get; set; }
    public string? WebSite { get; set; }
    public string? Email { get; set; }

    // موقعیت
    public int? CountryId { get; set; }
    public string? Country { get; set; }
    public int? ProvinceId { get; set; }
    public string? Province { get; set; }
    public int? CityId { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? AddressDesc { get; set; }
    public string? ZipCode { get; set; }
    public string? PostBox { get; set; }

    // موقعیت جغرافیایی
    public string? Latitude { get; set; }          // cmpCoordinateLatitude (nvarchar در Ideal)
    public string? Longitude { get; set; }         // cmpCoordinateLongitude
    public int? CoordinateZoomLevel { get; set; }
    public DateTime? CoordinateLastDate { get; set; }

    // شناسه‌های ثبتی و مالی
    public string? RegistrationNumber { get; set; }
    public string? EconomicCode { get; set; }
    public string? NationalCode { get; set; }
    public string? BuyLimit { get; set; }
    public string? AccountNumber { get; set; }

    // مسئولان و کاربران
    public int? ReferUserId { get; set; }          // بازاریاب/معرف
    public string? ReferUser { get; set; }
    public int? LastEditUserId { get; set; }       // UserId — آخرین ویراستر
    public string? LastEditUser { get; set; }
    public int? FirstRegisterUserId { get; set; }
    public string? FirstRegisterUser { get; set; }
    public int? MainPersonId { get; set; }         // cmpMainPersonId — شخص اصلی
    public string? MainPersonName { get; set; }

    // وضعیت و تاریخ‌ها
    public bool? IsDraft { get; set; }             // cmpIsDraft
    public int? Kind { get; set; }                 // cmpKind (حقیقی/حقوقی در Ideal)
    public DateTime? RegisterDate { get; set; }    // RegisterDate — تاریخ ثبت (ایجاد)
    public string? RegisterDatePersian { get; set; }
    public DateTime? FirstRegisterDate { get; set; }
    public string? ImportDate { get; set; }        // ImportDate (nvarchar شمسی ۸ رقمی)
    public DateTime? ImportDateTime { get; set; }
    public string? Description { get; set; }
    public string? SpecialPoint { get; set; }
    public string? Interesting { get; set; }

    // سطر API قدیمی (فقط در حالت SP موجود است)
    public long? LegacyRowNumber { get; set; }
    public int? LegacyTotalCount { get; set; }
}
