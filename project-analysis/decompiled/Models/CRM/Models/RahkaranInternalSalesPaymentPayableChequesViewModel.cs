namespace CRM.Models;

public class RahkaranInternalSalesPaymentPayableChequesViewModel
{
	public long? AccountingOperationID { get; set; }

	public string AgreementDate { get; set; }

	public decimal? Amount { get; set; }

	public long? BankAccountID { get; set; }

	public string BaseCurrencyAbbreviation { get; set; }

	public decimal? BaseCurrencyExchangeRate { get; set; }

	public long? CashFlowFactorID { get; set; }

	public string ChequeNumber { get; set; }

	public string ChequeSeriesNumber { get; set; }

	public long? CityID { get; set; }

	public string CounterPartDLCode { get; set; }

	public string CurrencyAbbreviation { get; set; }

	public string Description { get; set; }

	public string Description_En { get; set; }

	public string DueDate { get; set; }

	public decimal? OperationalCurrencyExchangeRate { get; set; }
}
