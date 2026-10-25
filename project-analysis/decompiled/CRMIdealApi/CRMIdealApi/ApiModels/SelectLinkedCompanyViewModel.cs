namespace CRMIdealApi.ApiModels;

public class SelectLinkedCompanyViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int CompanyId { get; set; }

	public int? LanguageId { get; set; }
}
