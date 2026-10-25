namespace CRMIdealApi.ApiModels;

public class DeleteBuyOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiBuyOrderId { get; set; }

	public int? LanguageId { get; set; }
}
