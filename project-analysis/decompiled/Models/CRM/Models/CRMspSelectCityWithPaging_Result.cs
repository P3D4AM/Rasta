namespace CRM.Models;

public class CRMspSelectCityWithPaging_Result
{
	public int CityID { get; set; }

	public string CityName { get; set; }

	public int? TotalCount { get; set; }

	public string ProvinceName { get; set; }
}
