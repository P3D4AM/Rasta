using System;
using System.Collections.Generic;

namespace Mobile.Models;

public class UsersLocationAroundCompanyViewModel
{
	public int CompanyId { get; set; }

	public string CompanyName { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public DateTime? cmpCoordinateLastDate { get; set; }

	public string cmpCoordinateLastTime { get; set; }

	public string cmpCoordinateLastDatePersian { get; set; }

	public int cmpCoordinateZoomLevel { get; set; }

	public List<MobspSelectUsersCoordinateAroundCompany_Result> UsersCoordinate { get; set; }
}
