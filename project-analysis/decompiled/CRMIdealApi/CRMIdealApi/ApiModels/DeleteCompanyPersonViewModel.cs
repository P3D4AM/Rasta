namespace CRMIdealApi.ApiModels;

public class DeleteCompanyPersonViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiCompanyPersonId { get; set; }

	public int? LanguageId { get; set; }
}
