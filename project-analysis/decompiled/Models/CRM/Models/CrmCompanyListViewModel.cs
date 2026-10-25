using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyListViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpImportDate")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNumber")]
	public int? cmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTitleId")]
	public string cmpTitleIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpActivityType")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupId")]
	public string cmpGroupIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSubGroupId")]
	public string cmpSubGroupIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdII")]
	public string cmpGroupIdIITitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIII")]
	public string cmpGroupIdIIITitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIV")]
	public string cmpGroupIdIVTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTypeId")]
	public string cmpTypeIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public string cmpPresentationIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTel")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpTo")]
	public string cmpTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelDesc")]
	public string cmpTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTelII")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpToII")]
	public string cmpTelUpToII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelIIDesc")]
	public string cmpTelIIDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFaxDesc")]
	public string cmpFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public string cmpCountryIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public string cmpProvinceIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public string cmpCityIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddressDesc")]
	public string cmpAddressDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpZipCode")]
	public string cmpZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPostBox")]
	public string cmpPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSpecialPoint")]
	public string cmpSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpDescription")]
	public string cmpDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFirstRegisterUserId")]
	public string cmpFirstRegisterUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	public string cmpReferUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpUserId")]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpUserId")]
	public string UserIdTitle { get; set; }

	public DateTime RegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpRegisterDateStrVm")]
	public string RegisterDateStr { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFame")]
	public string cmpFame { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpRegistrationNumber")]
	public string cmpRegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEconomicCode")]
	public string cmpEconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNationalCode")]
	public string cmpNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpBuyLimit")]
	public string cmpBuyLimit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAccountNumber")]
	public string cmpAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAccInquiry")]
	public string cmpAccInquiry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFreight")]
	public string cmpFreight { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpInquiry")]
	public string cmpInquiry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNameEng")]
	public string cmpNameEng { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEmail")]
	public string cmpEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpWebSite")]
	public string cmpWebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpInteresting")]
	public string cmpInteresting { get; set; }
}
