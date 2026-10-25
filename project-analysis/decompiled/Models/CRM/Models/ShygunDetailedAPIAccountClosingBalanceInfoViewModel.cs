namespace CRM.Models;

public class ShygunDetailedAPIAccountClosingBalanceInfoViewModel
{
	public string AccountGuId { get; set; }

	public string AccountNumber { get; set; }

	public decimal? AmountDebit { get; set; }

	public decimal? AmountCredit { get; set; }
}
