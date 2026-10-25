namespace CRM.Models;

public class ArianSystemSalePaymentWayResponseViewModel
{
	public int? PaymentWayID { get; set; }

	public string PaymentWayDesc { get; set; }

	public string PaymentWayCode { get; set; }

	public int? DurationPayDays { get; set; }

	public bool? IsBuy { get; set; }
}
