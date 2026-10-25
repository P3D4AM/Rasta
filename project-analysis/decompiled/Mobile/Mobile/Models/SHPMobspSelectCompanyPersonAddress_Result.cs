using System;

namespace Mobile.Models;

public class SHPMobspSelectCompanyPersonAddress_Result
{
	public int CompanyPersonID { get; set; }

	public int prsCompanyId { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public int? prsTitleId { get; set; }

	public string prsMobile { get; set; }

	public string prsEmail { get; set; }

	public string prsEmailII { get; set; }

	public int? prsCountryId { get; set; }

	public int? prsProvinceId { get; set; }

	public int? prsCityId { get; set; }

	public string prsAddress { get; set; }

	public string prsAddressDesc { get; set; }

	public string prsZipCode { get; set; }

	public string prsPostBox { get; set; }

	public string prsNationalCode { get; set; }

	public string prsCoordinateLatitude { get; set; }

	public string prsCoordinateLongitude { get; set; }

	public DateTime? prsCoordinateLastDate { get; set; }

	public string prsCoordinateLastDatePersian { get; set; }

	public int? prsCoordinateZoomLevel { get; set; }

	public int? prsCoordinateLastUserId { get; set; }

	public string PersonName { get; set; }

	public string prsCompany { get; set; }

	public string prsTitle { get; set; }

	public string prsCountry { get; set; }

	public string prsProvince { get; set; }

	public string prsCity { get; set; }

	public string prsBirthDate { get; set; }
}
