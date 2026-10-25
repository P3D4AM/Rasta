using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompanyAddressesMetadata
{
	[Key]
	public int CompanyAddressId { get; set; }

	public int cmpaddCompanyId { get; set; }

	public int? cmpaddCityId { get; set; }

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

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
