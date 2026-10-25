namespace CRMIdealApi.ApiModels;

public class SelectProjectProductHistoryViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiCompanyId { get; set; }

	public int ApiProjectId { get; set; }

	public int? LanguageId { get; set; }
}
