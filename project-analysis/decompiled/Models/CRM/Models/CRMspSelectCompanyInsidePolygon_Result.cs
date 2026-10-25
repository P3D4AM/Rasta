namespace CRM.Models;

public class CRMspSelectCompanyInsidePolygon_Result
{
	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public int cmpReferUserId { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public string CompanyName { get; set; }
}
