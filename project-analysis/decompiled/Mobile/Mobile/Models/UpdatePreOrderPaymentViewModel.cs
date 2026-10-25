namespace Mobile.Models;

public class UpdatePreOrderPaymentViewModel
{
	public string PreOrderPayment { get; set; }

	public int PreOrderPaymentId { get; set; }

	public int? LanguageId { get; set; }

	public bool ModeVerify { get; set; }

	public int? CenterId { get; set; }
}
