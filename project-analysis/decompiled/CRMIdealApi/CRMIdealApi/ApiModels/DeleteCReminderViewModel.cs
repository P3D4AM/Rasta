namespace CRMIdealApi.ApiModels;

public class DeleteCReminderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiUserTaskId { get; set; }

	public int? LanguageId { get; set; }
}
