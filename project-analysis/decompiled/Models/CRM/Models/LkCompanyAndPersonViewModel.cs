using System;

namespace CRM.Models;

public class LkCompanyAndPersonViewModel
{
	public long RowNumber { get; set; }

	public int CompanyId { get; set; }

	public string cmpName { get; set; }

	public string cmpNameEng { get; set; }

	public string cmpActivityType { get; set; }

	public string cmpPreTel { get; set; }

	public string cmpTel { get; set; }

	public string cmpTelUpTo { get; set; }

	public string cmpTelDesc { get; set; }

	public string cmpPreTelII { get; set; }

	public string cmpTelII { get; set; }

	public string cmpTelUpToII { get; set; }

	public string cmpTelIIDesc { get; set; }

	public string cmpFax { get; set; }

	public string cmpFaxDesc { get; set; }

	public string cmpAddress { get; set; }

	public string cmpAddressDesc { get; set; }

	public string cmpZipCode { get; set; }

	public string cmpWebSite { get; set; }

	public string cmpDescription { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public int? cmpKind { get; set; }

	public int? TspCmpTob { get; set; }

	public string cmpCode { get; set; }

	public string cmpPostBox { get; set; }

	public string cmpLinkAccData { get; set; }

	public string cmpNameAlias { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public string CompanyTitle { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelUpTo { get; set; }

	public string prsTelDesc { get; set; }

	public string prsTelII { get; set; }

	public string prsFax { get; set; }

	public string prsFaxDesc { get; set; }

	public string prsMobile { get; set; }

	public string prsEmail { get; set; }

	public string prsEmailII { get; set; }

	public string prsAddress { get; set; }

	public string prsNationalCode { get; set; }

	public string prsIdentityNumber { get; set; }

	public string prsFatherName { get; set; }

	public string prsBirthDate { get; set; }

	public string prsBirthPlace { get; set; }

	public string prsDescription { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	public string prsMarriageDate { get; set; }

	public DateTime? prsMarriageDateTime { get; set; }

	public string LinkAccCountryIdStr { get; set; }

	public string CountryName { get; set; }

	public string LinkAccProvinceIdStr { get; set; }

	public string ProvinceName { get; set; }

	public string LinkAccCityIdStr { get; set; }

	public string CityName { get; set; }

	public string LinkAccCmpTypeIdStr { get; set; }

	public string CmpTypeTitle { get; set; }

	public string cmpReferFName { get; set; }

	public string cmpReferLName { get; set; }

	public string cmpReferLinkAccUserIdStr { get; set; }

	public string cmpReferLinkAccUserCode { get; set; }

	public string cmpSuppUserFName { get; set; }

	public string cmpSuppUserLName { get; set; }

	public string cmpSuppUserLinkAccUserIdStr { get; set; }

	public string cmpSuppUserLinkAccUserCode { get; set; }

	public string CompanyGroupsMulti { get; set; }

	public string AddressIds { get; set; }

	public string CompanyGroupName { get; set; }

	public string LinkAccGroupIdStr { get; set; }

	public string CompanySubGroupName { get; set; }

	public string LinkAccSubGroupIdStr { get; set; }

	public string CompanyGroupIIName { get; set; }

	public string LinkAccCmpGroupIIIdStr { get; set; }

	public string ListItemRecords { get; set; }
}
