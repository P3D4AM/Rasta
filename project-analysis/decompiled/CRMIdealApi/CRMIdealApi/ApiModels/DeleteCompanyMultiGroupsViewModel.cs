namespace CRMIdealApi.ApiModels;

public class DeleteCompanyMultiGroupsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiCompanyId { get; set; }

	public int ApiCompanyGroupsMultiId { get; set; }

	public int? LanguageId { get; set; }
}
