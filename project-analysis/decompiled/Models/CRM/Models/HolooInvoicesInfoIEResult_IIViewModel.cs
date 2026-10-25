using System.Collections.Generic;

namespace CRM.Models;

public class HolooInvoicesInfoIEResult_IIViewModel
{
	public string Header { get; set; }

	public HolooInvoiceInfoIESuccessResultViewModel Success { get; set; }

	public List<HolooInvoiceInfoIEFailureResultViewModel> Failure { get; set; }
}
