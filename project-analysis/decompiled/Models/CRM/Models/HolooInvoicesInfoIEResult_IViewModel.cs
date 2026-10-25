using System.Collections.Generic;

namespace CRM.Models;

public class HolooInvoicesInfoIEResult_IViewModel
{
	public string Header { get; set; }

	public List<HolooInvoiceInfoIESuccessResultViewModel> Success { get; set; }

	public HolooInvoiceInfoIEFailureResultViewModel Failure { get; set; }
}
