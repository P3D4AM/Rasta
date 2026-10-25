using System;

namespace CRM.Models;

public class mct_CRMspSelectCompanyLocationFromRptFilterData_Result
{
	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpReferUser { get; set; }

	public string CompanyName { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public DateTime? cmpCoordinateLastDate { get; set; }

	public string cmpCoordinateLastDatePerWithSlash { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	public string cmpAddressDesc { get; set; }

	public string CompanyAddress { get; set; }
}
