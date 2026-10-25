namespace CRMIdealApi.ApiModels;

public class DeletePreOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiPreOrderId { get; set; }

	public int? LanguageId { get; set; }
}
