namespace CRM.Models;

public class TSPInvoicePaymentRequest
{
	public string iinn { get; set; }

	public string acn { get; set; }

	public string trmn { get; set; }

	public int? pmt { get; set; }

	public string trn { get; set; }

	public string pcn { get; set; }

	public string pid { get; set; }

	public long pdt { get; set; }

	public decimal? pv { get; set; }
}
