using System;

namespace CRMIdealApi.ApiModels;

public class InsertCompanyAddressViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiCmpNumber { get; set; }

	public string ApiCmpCode { get; set; }

	public int? ApiCmpaddCityId { get; set; }

	public string ApiCompanyAddress { get; set; }

	public string ApiCmpaddDesc { get; set; }

	public string ApiCmpaddZipCode { get; set; }

	public string ApiCmpaddPostBox { get; set; }

	public string ApiCmpaddCoordinateLatitude { get; set; }

	public string ApiCmpaddCoordinateLongitude { get; set; }

	public DateTime? ApiCmpaddCoordinateLastDate { get; set; }

	public int? ApiCmpaddCoordinateZoomLevel { get; set; }

	public int? ApiCmpaddCoordinateLastUserId { get; set; }

	public int? ApiCmpaddTypeId { get; set; }

	public string ApiCmpaddTypeName { get; set; }

	public int? LanguageId { get; set; }
}
