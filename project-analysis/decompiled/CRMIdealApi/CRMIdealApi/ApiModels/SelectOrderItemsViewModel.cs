namespace CRMIdealApi.ApiModels;

public class SelectOrderItemsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiOrderId { get; set; }

	public int? ApiOrderItemId { get; set; }

	public int? LanguageId { get; set; }
}
