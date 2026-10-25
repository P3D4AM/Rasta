namespace CRM.Models;

public class WSIssueOrderPaymentsCompleteViewModel
{
	public string ImportDate { get; set; }

	public int ordpayTypeId { get; set; }

	public decimal ordpayAmount { get; set; }

	public string ordpayDocNumber { get; set; }

	public string ordpayDocDate { get; set; }

	public string ordpayDescription { get; set; }

	public string ImportDateTime { get; set; }

	public string ordpayDocDateTime { get; set; }

	public decimal ordpayDocAmount { get; set; }

	public decimal ordpayAmountTemp { get; set; }

	public string ordpayCardNumber { get; set; }

	public string ordpay_Lang { get; set; }
}
