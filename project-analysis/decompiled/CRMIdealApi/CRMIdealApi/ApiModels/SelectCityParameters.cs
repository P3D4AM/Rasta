namespace CRMIdealApi.ApiModels;

public class SelectCityParameters
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiProvinceId { get; set; }

	public int? ApiCityId { get; set; }
}
