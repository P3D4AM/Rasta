namespace CRM.Models;

public class SamanBankViewModel
{
	public bool IsSuccess { get; set; }

	public string Message { get; set; }

	public string MaskedCardNumber { get; set; }

	public string HashedCardNumber { get; set; }

	public string RefNumber { get; set; }

	public string ReceiptDigital { get; set; }

	public int orderId { get; set; }

	public decimal? Amount { get; set; }

	public int? CrmPreOrderId { get; set; }
}
