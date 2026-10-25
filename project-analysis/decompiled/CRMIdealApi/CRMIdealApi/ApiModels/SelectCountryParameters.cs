namespace CRMIdealApi.ApiModels;

public class SelectCountryParameters
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiCountryId { get; set; }
}
