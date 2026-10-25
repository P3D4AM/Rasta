namespace CRMIdealApi.ApiModels;

public class DeleteOrderPaymentsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiOrderPaymentId { get; set; }

	public int? LanguageId { get; set; }
}
