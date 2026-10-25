namespace CRM.Models;

public class PasargadCallBackViewModel
{
	public int? TraceNumber { get; set; }

	public long? ReferenceNumber { get; set; }

	public string TransactionDate { get; set; }

	public string Action { get; set; }

	public string TransactionReferenceID { get; set; }

	public string InvoiceNumber { get; set; }

	public string InvoiceDate { get; set; }

	public int? MerchantCode { get; set; }

	public int? TerminalCode { get; set; }

	public decimal? Amount { get; set; }

	public bool IsSuccess { get; set; }

	public string Message { get; set; }
}
