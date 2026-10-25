using System;

namespace Mobile.Models;

public class MobspSelectCompanyAddresses_Result
{
	public int CompanyAddressId { get; set; }

	public int cmpaddCompanyId { get; set; }

	public int? cmpaddCityId { get; set; }

	public string cmpaddCity { get; set; }

	public string CompanyAddress { get; set; }

	public string cmpaddDesc { get; set; }

	public string cmpaddZipCode { get; set; }

	public string cmpaddPostBox { get; set; }

	public string cmpaddCoordinateLatitude { get; set; }

	public string cmpaddCoordinateLongitude { get; set; }

	public DateTime? cmpaddCoordinateLastDate { get; set; }

	public string cmpaddCoordinateLastDatePersian { get; set; }

	public int? cmpaddCoordinateZoomLevel { get; set; }

	public int? cmpaddCoordinateLastUserId { get; set; }

	public string cmpaddCoordinateLastUser { get; set; }

	public int? cmpaddTypeId { get; set; }

	public string cmpaddType { get; set; }

	public string cmpaddCountry { get; set; }

	public string cmpaddProvince { get; set; }

	public string cmpaddCompanyName { get; set; }

	public int? cmpaddCountryId { get; set; }

	public int? cmpaddProvinceId { get; set; }
}
