using System;

namespace Mobile.Models;

public class ShpPersonAddress
{
	public int CompanyId { get; set; }

	public int CompanyPersonID { get; set; }

	public int prsCompanyId { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public string prsMobile { get; set; }

	public int? prsCountryId { get; set; }

	public int? prsProvinceId { get; set; }

	public int? prsCityId { get; set; }

	public string prsAddress { get; set; }

	public string prsZipCode { get; set; }

	public string prsEmail { get; set; }

	public string prsCoordinateLatitude { get; set; }

	public string prsCoordinateLongitude { get; set; }

	public int? prsCoordinateZoomLevel { get; set; }

	public string prsBirthDate { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	public int? CId { get; set; }

	public int? Ln { get; set; }
}
