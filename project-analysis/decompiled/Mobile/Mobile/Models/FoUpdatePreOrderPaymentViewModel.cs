namespace Mobile.Models;

public class FoUpdatePreOrderPaymentViewModel
{
	public int PreOrderId { get; set; }

	public int PayId { get; set; }

	public string DocDate { get; set; }

	public decimal PayAmount { get; set; }

	public string DocNumber { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
