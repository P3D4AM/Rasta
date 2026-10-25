namespace CRMIdealApi.ApiModels;

public class DeleteOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiOrderId { get; set; }

	public int? LanguageId { get; set; }
}
