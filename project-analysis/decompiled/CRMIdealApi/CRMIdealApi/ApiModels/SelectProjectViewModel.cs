namespace CRMIdealApi.ApiModels;

public class SelectProjectViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiCompanyId { get; set; }

	public int ApiProjectId { get; set; }

	public int? LanguageId { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }
}
