using System;

namespace CRM.Models;

public class CRMspSelectCompanyPersonAddressCoordinate_Result
{
	public int CompanyPersonID { get; set; }

	public int prsCompanyId { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public string PersonName { get; set; }

	public int? prsTitleId { get; set; }

	public string AppType { get; set; }

	public string prsCoordinateLatitude { get; set; }

	public string prsCoordinateLongitude { get; set; }

	public DateTime? prsCoordinateLastDate { get; set; }

	public string prsCoordinateLastDatePersian { get; set; }

	public int? prsCoordinateZoomLevel { get; set; }

	public int? prsCoordinateLastUserId { get; set; }

	public int? prsCountryId { get; set; }

	public string Address { get; set; }

	public string Country { get; set; }

	public int? prsProvinceId { get; set; }

	public string Province { get; set; }

	public int? prsCityId { get; set; }

	public string City { get; set; }

	public string prsAddress { get; set; }

	public string prsAddressDesc { get; set; }

	public string CoordinateLastUser { get; set; }
}
