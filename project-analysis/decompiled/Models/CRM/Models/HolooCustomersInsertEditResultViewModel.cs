using System.Collections.Generic;

namespace CRM.Models;

public class HolooCustomersInsertEditResultViewModel
{
	public string Header { get; set; }

	public List<HolooCustomerInsertEditSuccessResultViewModel> Success { get; set; }

	public List<HolooCustomerInsertEditFailureResultViewModel> Failure { get; set; }
}
