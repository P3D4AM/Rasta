namespace CRMIdealApi.ApiModels;

public class DeleteOrderItemsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiOrderItemId { get; set; }

	public int? LanguageId { get; set; }
}
