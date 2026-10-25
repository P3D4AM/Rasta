namespace CRMIdealApi.ApiModels;

public class SelectCompanyPersonViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiCompanyId { get; set; }

	public int ApiCompanyPersonId { get; set; }

	public int? LanguageId { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }
}
