namespace CRMIdealApi.ApiModels;

public class DeleteDocItemsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiDocItemId { get; set; }

	public int? LanguageId { get; set; }
}
