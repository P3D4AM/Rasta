namespace IdealBridge.Domain.Dto;

/// <summary>کاربر CRM (جدول Users) — فقط فیلدهای غیرحساس؛ Password هرگز نگاشت نمی‌شود.</summary>
public class CrmUserDto
{
    public int Id { get; set; }                    // UserId
    public int? Row { get; set; }                  // ردیف نمایش
    public string? FirstName { get; set; }         // FName
    public string? LastName { get; set; }          // LName
    public string? FullName { get; set; }
    public string? UserName { get; set; }          // نام کاربری Ideal
    public string? PersonnelCode { get; set; }     // PersCode
    public bool? IsAdmin { get; set; }             // IsAdmin (nvarchar در Ideal → تبدیل بولی)
    public bool? IsActive { get; set; }            // IsActive
    public bool? IsActiveInWinApp { get; set; }    // UserIsActiveInWinApp
    public bool? IsActiveInWebApp { get; set; }    // UserIsActiveInWebApp
    public bool? IsActiveInMobApp { get; set; }    // UserIsActiveInMobApp
    public string? Mobile { get; set; }
    public string? Mobile2 { get; set; }           // MobileII
    public string? Tel { get; set; }
    public int? PositionId { get; set; }           // PositionId
    public int? UserGroupId { get; set; }
    public string? NationalCode { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string? Description { get; set; }
}
