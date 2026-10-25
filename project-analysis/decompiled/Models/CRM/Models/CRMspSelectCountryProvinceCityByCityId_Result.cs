namespace CRM.Models;

public class CRMspSelectCountryProvinceCityByCityId_Result
{
	public int CityID { get; set; }

	public string City { get; set; }

	public int ProvinceId { get; set; }

	public string Province { get; set; }

	public int? CountryId { get; set; }

	public string Country { get; set; }
}
