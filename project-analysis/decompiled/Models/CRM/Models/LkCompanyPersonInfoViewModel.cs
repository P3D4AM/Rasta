using System;

namespace CRM.Models;

public class LkCompanyPersonInfoViewModel
{
	public int CompanyPersonID { get; set; }

	public int PrsCompanyId { get; set; }

	public string PrsLName { get; set; }

	public string PrsFName { get; set; }

	public int? PrsTitleId { get; set; }

	public string PrsTitle { get; set; }

	public int? PrsJobId { get; set; }

	public int? PrsTypeId { get; set; }

	public int? PrsGroupId { get; set; }

	public int? PrsSexId { get; set; }

	public int? PrsEducationId { get; set; }

	public string PrsPreTel { get; set; }

	public string PrsTel { get; set; }

	public string PrsTelUpTo { get; set; }

	public string PrsTelDesc { get; set; }

	public string PrsTelII { get; set; }

	public string PrsFax { get; set; }

	public string PrsFaxDesc { get; set; }

	public string PrsMobile { get; set; }

	public string PrsWebSite { get; set; }

	public string PrsEmail { get; set; }

	public string PrsEmailII { get; set; }

	public int? PrsCountryId { get; set; }

	public int? PrsProvinceId { get; set; }

	public int? PrsCityId { get; set; }

	public string PrsAddress { get; set; }

	public string PrsAddressDesc { get; set; }

	public string PrsZipCode { get; set; }

	public string PrsPostBox { get; set; }

	public string PrsNationalCode { get; set; }

	public string PrsIdentityNumber { get; set; }

	public string PrsFatherName { get; set; }

	public string PrsBirthDate { get; set; }

	public DateTime? PrsBirthDateTime { get; set; }

	public string PrsBirthPlace { get; set; }

	public bool? PrsIsMarried { get; set; }

	public string PrsMarriageDate { get; set; }

	public DateTime? PrsMarriageDateTime { get; set; }

	public string PrsEducationField { get; set; }

	public string PrsSkill { get; set; }

	public string PrsStudyField { get; set; }

	public string PrsInteresting { get; set; }

	public string PrsSpecialPoint { get; set; }

	public string PrsDescription { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int AddType { get; set; }

	public string ImportDate { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public int? PrsFirstRegisterUserId { get; set; }

	public int? PrsDepartmentId { get; set; }

	public bool? PrsStopSendSms { get; set; }

	public int? PrsOrderView { get; set; }

	public bool? PrsWorkingOut { get; set; }

	public Guid? GUId { get; set; }

	public int? CompanyPersonTemplateID { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? PrsTelegramId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string PrsCoordinateLatitude { get; set; }

	public string PrsCoordinateLongitude { get; set; }

	public DateTime? PrsCoordinateLastDate { get; set; }

	public string PrsCoordinateLastDatePersian { get; set; }

	public int? PrsCoordinateZoomLevel { get; set; }

	public int? PrsCoordinateLastUserId { get; set; }

	public bool? Selected { get; set; }

	public int? InsertedId { get; set; }

	public string Message { get; set; }

	public bool? DoneWithError { get; set; }
}
