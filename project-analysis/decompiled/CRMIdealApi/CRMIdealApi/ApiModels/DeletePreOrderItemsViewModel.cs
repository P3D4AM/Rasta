namespace CRMIdealApi.ApiModels;

public class DeletePreOrderItemsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiPreOrderItemId { get; set; }

	public int? LanguageId { get; set; }
}
