using System;

namespace CRMIdealApi.ApiModels;

public class InsertCompanyPersonViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiCmpNumber { get; set; }

	public string ApiCmpCode { get; set; }

	public string ApiPrsLName { get; set; }

	public string ApiPrsFName { get; set; }

	public int? ApiPrsTitleId { get; set; }

	public int? ApiPrsJobId { get; set; }

	public int? ApiPrsTypeId { get; set; }

	public int? ApiPrsGroupId { get; set; }

	public int? ApiPrsSexId { get; set; }

	public int? ApiPrsEducationId { get; set; }

	public string ApiPrsPreTel { get; set; }

	public string ApiPrsTel { get; set; }

	public string ApiPrsTelUpTo { get; set; }

	public string ApiPrsTelDesc { get; set; }

	public string ApiPrsTelII { get; set; }

	public string ApiPrsFax { get; set; }

	public string ApiPrsFaxDesc { get; set; }

	public string ApiPrsMobile { get; set; }

	public string ApiPrsWebSite { get; set; }

	public string ApiPrsEmail { get; set; }

	public string ApiPrsEmailII { get; set; }

	public int? ApiPrsCountryId { get; set; }

	public int? ApiPrsProvinceId { get; set; }

	public int? ApiPrsCityId { get; set; }

	public string ApiPrsAddress { get; set; }

	public string ApiPrsAddressDesc { get; set; }

	public string ApiPrsZipCode { get; set; }

	public string ApiPrsPostBox { get; set; }

	public string ApiPrsNationalCode { get; set; }

	public string ApiPrsIdentityNumber { get; set; }

	public string ApiPrsFatherName { get; set; }

	public DateTime? ApiPrsBirthDateTime { get; set; }

	public string ApiPrsBirthPlace { get; set; }

	public bool? ApiPrsIsMarried { get; set; }

	public DateTime? ApiPrsMarriageDateTime { get; set; }

	public string ApiPrsEducationField { get; set; }

	public string ApiPrsSkill { get; set; }

	public string ApiPrsStudyField { get; set; }

	public string ApiPrsInteresting { get; set; }

	public string ApiPrsSpecialPoint { get; set; }

	public string ApiPrsDescription { get; set; }

	public int? ApiPrsDepartmentId { get; set; }

	public bool? ApiPrsStopSendSms { get; set; }

	public int? ApiPrsOrderView { get; set; }

	public bool? ApiPrsWorkingOut { get; set; }

	public int? ApiPrsTelegramId { get; set; }

	public bool? PrsTelNotDup { get; set; }

	public bool? PrsFaxNotDup { get; set; }

	public int? LanguageId { get; set; }
}
