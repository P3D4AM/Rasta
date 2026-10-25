namespace CRM.Models;

public class ShygunCompanyClosingBalanceViewModel
{
	public string AccountGuId { get; set; }

	public string AccountNumber { get; set; }

	public decimal? AmountDebit { get; set; }

	public decimal? AmountCredit { get; set; }
}
