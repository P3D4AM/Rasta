namespace CRMIdealApi.ApiModels;

public class DeleteCompanyViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiCompanyId { get; set; }

	public int? LanguageId { get; set; }
}
