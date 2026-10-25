namespace CRMIdealApi.ApiModels;

public class DeleteConversationViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiConversationId { get; set; }

	public int? LanguageId { get; set; }
}
