using System.Collections.Generic;

namespace Mobile.Models;

public class CompanyViewModel
{
	public int CompanyID { get; set; }

	public string cmpNameFull { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpTelFull { get; set; }

	public string cmpReferUser { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public string cmpCoordinateLastDate { get; set; }

	public string cmpCoordinateLastTime { get; set; }

	public string cmpCoordinateLastDatePersian { get; set; }

	public int cmpCoordinateZoomLevel { get; set; }

	public int CountPage { get; set; }
}
