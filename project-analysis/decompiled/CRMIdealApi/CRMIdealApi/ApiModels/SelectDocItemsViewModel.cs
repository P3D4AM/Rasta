namespace CRMIdealApi.ApiModels;

public class SelectDocItemsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiDocId { get; set; }

	public int? ApiDocItemId { get; set; }

	public int? LanguageId { get; set; }
}
