using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyMetadata
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNumber")]
	public int? cmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNameEng")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpNameEng { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTitleId")]
	public int? cmpTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFame")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFame { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpActivityType")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupId")]
	public int? cmpGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSubGroupId")]
	public int? cmpSubGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdII")]
	public int? cmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIII")]
	public int? cmpGroupIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIV")]
	public int? cmpGroupIdIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTypeId")]
	public int? cmpTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public int? cmpPresentationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTel")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpTo")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTelII")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpToII")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelUpToII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelIIDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelIIDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFaxDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public int? cmpCountryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public int? cmpProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public int? cmpCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddressDesc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAddressDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPostBox")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpWebSite")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpWebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEmail")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpInteresting")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpInteresting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSpecialPoint")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpUserName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPassword")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[DataType(DataType.Password)]
	public string cmpPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFirstRegisterUserId")]
	public int? cmpFirstRegisterUserId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int AddType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpRegistrationNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpRegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEconomicCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpEconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNationalCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpBuyLimit")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpBuyLimit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAccountNumber")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAccInquiry")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAccInquiry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFreight")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFreight { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpInquiry")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpInquiry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cmpReferUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public string cmpSpecialWordForCI { get; set; }

	public string cmpCode { get; set; }

	public string cmpEffectiveDatePersian { get; set; }

	public DateTime? cmpEffectiveDateTime { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
