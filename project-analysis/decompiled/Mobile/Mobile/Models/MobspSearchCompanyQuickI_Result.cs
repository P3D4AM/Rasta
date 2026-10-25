namespace Mobile.Models;

public class MobspSearchCompanyQuickI_Result
{
	public int CompanyID { get; set; }

	public int? CompanyPersonID { get; set; }

	public int? ProjectID { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string FullText { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpAddress { get; set; }

	public int? cmpCountryId { get; set; }

	public int? cmpProvinceId { get; set; }

	public int? cmpCityId { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	public int? cmpGroupIdII { get; set; }
}
