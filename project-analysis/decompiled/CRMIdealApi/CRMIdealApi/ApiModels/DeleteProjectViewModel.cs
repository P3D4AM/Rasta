namespace CRMIdealApi.ApiModels;

public class DeleteProjectViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiProjectId { get; set; }

	public int? LanguageId { get; set; }
}
