using System.Collections.Generic;

namespace CRM.Models;

public class HolooInvoicesInfoIEResultViewModel
{
	public string Header { get; set; }

	public List<HolooInvoiceInfoIESuccessResultViewModel> Success { get; set; }

	public List<HolooInvoiceInfoIEFailureResultViewModel> Failure { get; set; }
}
