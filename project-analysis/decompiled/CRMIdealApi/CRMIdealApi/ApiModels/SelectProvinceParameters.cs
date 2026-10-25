namespace CRMIdealApi.ApiModels;

public class SelectProvinceParameters
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiCountryId { get; set; }

	public int? ApiProvinceId { get; set; }
}
