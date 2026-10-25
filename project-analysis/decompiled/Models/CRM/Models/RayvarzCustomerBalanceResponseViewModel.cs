namespace CRM.Models;

public class RayvarzCustomerBalanceResponseViewModel
{
	public string text { get; set; }

	public decimal? creditAmount { get; set; }

	public decimal? debtTransaction { get; set; }

	public decimal? creditTransaction { get; set; }

	public decimal? debtRemain { get; set; }

	public decimal? creditRemain { get; set; }

	public decimal? totalCreditRemain { get; set; }

	public long? docType { get; set; }
}
