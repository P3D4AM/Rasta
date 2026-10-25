namespace CRM.Models;

public class RahkaranInternalSalesReceiptDepositsViewModel
{
	public long? AccountingOperationID { get; set; }

	public decimal? Amount { get; set; }

	public long? BankAccountID { get; set; }

	public string BaseCurrencyAbbreviation { get; set; }

	public decimal? BaseCurrencyExchangeRate { get; set; }

	public long? CashFlowFactorID { get; set; }

	public string CounterPartDLCode { get; set; }

	public string Date { get; set; }

	public string Description { get; set; }

	public string Description_En { get; set; }

	public string Number { get; set; }

	public decimal? OperationalCurrencyExchangeRate { get; set; }
}
