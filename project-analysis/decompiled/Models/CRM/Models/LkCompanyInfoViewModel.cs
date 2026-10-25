using System;
using System.Collections.Generic;

namespace CRM.Models;

public class LkCompanyInfoViewModel
{
	public int CompanyID { get; set; }

	public string ImportDate { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public int? CmpNumber { get; set; }

	public string CmpName { get; set; }

	public string CmpNameEng { get; set; }

	public int? CmpTitleId { get; set; }

	public string CmpTitle { get; set; }

	public string CmpFame { get; set; }

	public string CmpActivityType { get; set; }

	public int? CmpGroupId { get; set; }

	public int? CmpSubGroupId { get; set; }

	public int? CmpGroupIdII { get; set; }

	public int? CmpGroupIdIII { get; set; }

	public int? CmpGroupIdIV { get; set; }

	public int? CmpTypeId { get; set; }

	public int? CmpPresentationId { get; set; }

	public string CmpPreTel { get; set; }

	public string CmpTel { get; set; }

	public string CmpTelUpTo { get; set; }

	public string CmpTelDesc { get; set; }

	public string CmpPreTelII { get; set; }

	public string CmpTelII { get; set; }

	public string CmpTelUpToII { get; set; }

	public string CmpTelIIDesc { get; set; }

	public string CmpMobile { get; set; }

	public string CmpFax { get; set; }

	public string CmpFaxDesc { get; set; }

	public int? CmpCountryId { get; set; }

	public string CmpCountry { get; set; }

	public string LkCountryIdStr { get; set; }

	public int? CmpProvinceId { get; set; }

	public string CmpProvince { get; set; }

	public string LkProvinceIdStr { get; set; }

	public int? CmpCityId { get; set; }

	public string CmpCity { get; set; }

	public string LkpCityIdStr { get; set; }

	public string CmpAddress { get; set; }

	public string CmpAddressDesc { get; set; }

	public string CmpZipCode { get; set; }

	public string CmpPostBox { get; set; }

	public string CmpWebSite { get; set; }

	public string CmpEmail { get; set; }

	public string CmpInteresting { get; set; }

	public string CmpSpecialPoint { get; set; }

	public string CmpDescription { get; set; }

	public string CmpUserName { get; set; }

	public string CmpPassword { get; set; }

	public int? CmpFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int AddType { get; set; }

	public string CmpRegistrationNumber { get; set; }

	public string CmpEconomicCode { get; set; }

	public string CmpNationalCode { get; set; }

	public Guid? GUId { get; set; }

	public string CmpBuyLimit { get; set; }

	public string CmpAccountNumber { get; set; }

	public string CmpAccInquiry { get; set; }

	public string CmpFreight { get; set; }

	public string CmpInquiry { get; set; }

	public int CmpReferUserId { get; set; }

	public string AppType { get; set; }

	public string CmpSpecialWordForCI { get; set; }

	public string CmpCode { get; set; }

	public string CmpEffectiveDatePersian { get; set; }

	public DateTime? CmpEffectiveDateTime { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string CmpCoordinateLatitude { get; set; }

	public string CmpCoordinateLongitude { get; set; }

	public DateTime? CmpCoordinateLastDate { get; set; }

	public string CmpCoordinateLastDatePersian { get; set; }

	public int? CmpCoordinateZoomLevel { get; set; }

	public int? CmpCoordinateLastUserId { get; set; }

	public bool? CmpFOAccessLinkedCompany { get; set; }

	public int? CmpLinkAccCodeId { get; set; }

	public string CmpLinkAccCode { get; set; }

	public int? CmpLinkAccCustomerId { get; set; }

	public string CmpLinkAccCustomerIdStr { get; set; }

	public bool? CmpIsDraft { get; set; }

	public int? CmpKindId { get; set; }

	public string CmpKind { get; set; }

	public int? CmpMainPersonId { get; set; }

	public string CmpNameOfficial { get; set; }

	public int? CmpTicketAllowInCurrntCount { get; set; }

	public int? CmpTicketAllowAddBeforeAnswerCount { get; set; }

	public string CmpIVRLinkRule { get; set; }

	public string CmpCampaignIds { get; set; }

	public bool? CmpTicketCountCurrentWithStop { get; set; }

	public string CmpFOManagers { get; set; }

	public int? CmpSuppUserId { get; set; }

	public List<LkCompanyPersonInfoViewModel> PersonsList { get; set; }

	public bool? Selected { get; set; }

	public int? InsertedId { get; set; }

	public string Message { get; set; }
}
