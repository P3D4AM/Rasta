namespace Mobile.Models;

public class UpdateOrderPaymentViewModel
{
	public string OrderPayment { get; set; }

	public int OrderPaymentId { get; set; }

	public int? LanguageId { get; set; }

	public string ErrorMessage { get; set; }

	public bool ModeVerify { get; set; }

	public int? CenterId { get; set; }
}
