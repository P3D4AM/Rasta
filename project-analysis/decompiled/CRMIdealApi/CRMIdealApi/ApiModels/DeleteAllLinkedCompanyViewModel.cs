namespace CRMIdealApi.ApiModels;

public class DeleteAllLinkedCompanyViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int CompanyId { get; set; }

	public int? LanguageId { get; set; }
}
