using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyPersonViewModel
{
	[Key]
	public int CompanyPersonID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int prsCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsLName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsLName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTitleId")]
	public int? prsTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTitleId")]
	public string prsTitleIdStr { get; set; }

	public string prsPerson => prsTitleIdStr + " " + prsLName + " " + prsFName;

	[Display(ResourceType = typeof(Labels), Name = "prsJobId")]
	public int? prsJobId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsJobId")]
	public string prsJobIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDepartmentId")]
	public int? prsDepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDepartmentId")]
	public string prsDepartmentIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsPreTel")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelUpTo")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFaxDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEmail")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsAddressDesc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsAddressDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEmailII")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsEmailII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsImportDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFirstRegisterUserId")]
	public int? prsFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsWorkingOut")]
	public bool? prsWorkingOut { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsWorkingOut")]
	public string prsWorkingOutTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsOrderView")]
	public int? prsOrderView { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsAddType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int AddType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCompanyPersonTemplateID")]
	public int? CompanyPersonTemplateID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTypeId")]
	public int? prsTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTypeId")]
	public string prsTypeIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsGroupId")]
	public int? prsGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsGroupId")]
	public string prsGroupIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsSexId")]
	public int? prsSexId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsSexId")]
	public string prsSexIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEducationId")]
	public int? prsEducationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEducationId")]
	public string prsEducationIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsWebSite")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsWebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCountryId")]
	public int? prsCountryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCountryId")]
	public string prsCountryIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsProvinceId")]
	public int? prsProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsProvinceId")]
	public string prsProvinceIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCityId")]
	public int? prsCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCityId")]
	public string prsCityIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsPostBox")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsNationalCode")]
	[MaxLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsIdentityNumber")]
	[MaxLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsIdentityNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFatherName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFatherName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsBirthDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsBirthDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsBirthPlace")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsBirthPlace { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsIsMarried")]
	public bool? prsIsMarried { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsMarriageDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsMarriageDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsEducationField")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsEducationField { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsSkill")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsSkill { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsStudyField")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsStudyField { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsInteresting")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsInteresting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsSpecialPoint")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsStopSendSms")]
	public bool? prsStopSendSms { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsIsMarried")]
	public string prsIsMarriedStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFirstRegisterUserId")]
	public string prsFirstRegisterUserIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsUserId")]
	public string UserIdStr { get; set; }

	public string AppType { get; set; }

	public string prsUserName { get; set; }

	public string prsPassword { get; set; }

	public bool? prsFOIsActive { get; set; }

	public DateTime? prsFOActiveDate { get; set; }

	public string prsFOActiveDatePersian { get; set; }

	public int? prsFOActiveUserId { get; set; }

	public string prsFOActiveUser { get; set; }

	public DateTime? prsFOLoginExpireDate { get; set; }

	public string prsFOLoginExpireDatePersian { get; set; }

	public int? prsFOLoginExpireUserId { get; set; }

	public string prsFOLoginExpireUser { get; set; }

	public string prsCIds { get; set; }

	public string prsFOInfo { get; set; }

	public string prsFOInfoExtra { get; set; }

	public long? RowNumber { get; set; }
}
