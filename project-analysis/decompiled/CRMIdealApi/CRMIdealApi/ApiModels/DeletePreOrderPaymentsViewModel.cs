namespace CRMIdealApi.ApiModels;

public class DeletePreOrderPaymentsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiPreOrderPaymentId { get; set; }

	public int? LanguageId { get; set; }
}
