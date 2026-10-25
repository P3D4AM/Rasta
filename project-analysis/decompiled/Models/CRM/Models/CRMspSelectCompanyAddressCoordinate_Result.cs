using System;

namespace CRM.Models;

public class CRMspSelectCompanyAddressCoordinate_Result
{
	public int? cmpNumber { get; set; }

	public string Company { get; set; }

	public int? cmpTitleId { get; set; }

	public string cmpTitle { get; set; }

	public string cmpName { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	public DateTime? cmpCoordinateLastDate { get; set; }

	public string cmpCoordinateLastDatePersian { get; set; }

	public int? cmpCountryId { get; set; }

	public string Address { get; set; }

	public string Country { get; set; }

	public int? cmpProvinceId { get; set; }

	public string Province { get; set; }

	public int? cmpCityId { get; set; }

	public string City { get; set; }

	public string cmpAddress { get; set; }

	public string cmpAddressDesc { get; set; }

	public int? cmpCoordinateLastUserId { get; set; }

	public string CoordinateLastUser { get; set; }
}
