namespace CRM.Models;

public class HolooInvoiceInfoIEResultViewModel
{
	public string Header { get; set; }

	public HolooInvoiceInfoIESuccessResultViewModel Success { get; set; }

	public HolooInvoiceInfoIEFailureResultViewModel Failure { get; set; }
}
