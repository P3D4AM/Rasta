namespace CRM.Models;

public class BankCallBackViewModel
{
	public bool IsSuccess { get; set; }

	public string Message { get; set; }

	public string MaskedCardNumber { get; set; }

	public string HashedCardNumber { get; set; }

	public string ShaparakRefNumber { get; set; }

	public int orderId { get; set; }

	public decimal? Amount { get; set; }

	public int? CrmPreOrderId { get; set; }

	public string ShenasehNumber { get; set; }

	public long? RefId { get; set; }

	public int? CrmOrderId { get; set; }

	public long? CrmOrdNumber { get; set; }

	public long? CrmPordNumber { get; set; }

	public string RefNumber { get; set; }

	public string ReceiptDigital { get; set; }

	public string ErrorMessage { get; set; }

	public long? RRN { get; set; }

	public long? OrderIdI { get; set; }
}
