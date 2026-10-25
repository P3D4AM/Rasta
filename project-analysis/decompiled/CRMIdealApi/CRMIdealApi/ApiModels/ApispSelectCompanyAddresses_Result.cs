using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyAddresses_Result
{
	public int ApiCompanyAddressId { get; set; }

	public int ApiCmpaddCompanyId { get; set; }

	public string ApiCmpaddCompany { get; set; }

	public int? ApiCmpaddCityId { get; set; }

	public string ApiCmpaddCity { get; set; }

	public string ApiCompanyAddress { get; set; }

	public string ApiCmpaddDesc { get; set; }

	public string ApiCmpaddZipCode { get; set; }

	public string ApiCmpaddPostBox { get; set; }

	public string ApiCmpaddCoordinateLatitude { get; set; }

	public string ApiCmpaddCoordinateLongitude { get; set; }

	public DateTime? ApiCmpaddCoordinateLastDate { get; set; }

	public int? ApiCmpaddCoordinateZoomLevel { get; set; }

	public int? ApiCmpaddCoordinateLastUserId { get; set; }

	public string ApiCmpaddCoordinateLastUser { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiCompanyAddressFull { get; set; }

	public int? ApiCmpaddTypeId { get; set; }

	public string ApiCmpaddType { get; set; }
}
