namespace IdealBridge.Domain.Dto;

/// <summary>شخصِ مرتبط با مشتری (CrmCompanyPersons) — بدون هیچ فیلد رمز عبور.</summary>
public class CompanyPersonDto
{
    public int Id { get; set; }                    // CompanyPersonID
    public int CompanyId { get; set; }             // prsCompanyId
    public string? CompanyName { get; set; }
    public string? FirstName { get; set; }         // prsFName
    public string? LastName { get; set; }          // prsLName
    public string? FullName { get; set; }
    public int? TitleId { get; set; }
    public string? Title { get; set; }             // prsTitle (جناب/خانم/آقای)
    public int? JobId { get; set; }
    public string? Job { get; set; }
    public int? TypeId { get; set; }
    public string? Type { get; set; }
    public int? GroupId { get; set; }
    public string? Group { get; set; }
    public int? SexId { get; set; }
    public string? Sex { get; set; }
    public int? EducationId { get; set; }
    public string? Education { get; set; }
    public int? DepartmentId { get; set; }
    public string? Department { get; set; }

    // تماس
    public string? PreTel { get; set; }
    public string? Tel { get; set; }
    public string? TelUpTo { get; set; }
    public string? TelDesc { get; set; }
    public string? Tel2 { get; set; }
    public string? Fax { get; set; }
    public string? Mobile { get; set; }
    public string? WebSite { get; set; }
    public string? Email { get; set; }
    public string? Email2 { get; set; }

    // موقعیت
    public int? CountryId { get; set; }
    public string? Country { get; set; }
    public int? ProvinceId { get; set; }
    public string? Province { get; set; }
    public int? CityId { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? PostBox { get; set; }

    // اطلاعات فردی
    public string? NationalCode { get; set; }
    public string? IdentityNumber { get; set; }
    public string? FatherName { get; set; }
    public string? BirthDate { get; set; }         // رشتهٔ شمسی در Ideal
    public string? BirthPlace { get; set; }
    public bool? IsMarried { get; set; }
    public string? MarriageDate { get; set; }
    public string? Skill { get; set; }
    public string? StudyField { get; set; }
    public string? Interesting { get; set; }
    public string? SpecialPoint { get; set; }
    public string? Description { get; set; }
    public bool? StopSendSms { get; set; }
    public bool? WorkingOut { get; set; }          // غیرفعال/خارج‌شده
    public string? ImportDate { get; set; }
}
