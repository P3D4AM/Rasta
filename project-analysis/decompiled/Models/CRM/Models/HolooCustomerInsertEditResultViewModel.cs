namespace CRM.Models;

public class HolooCustomerInsertEditResultViewModel
{
	public string Header { get; set; }

	public HolooCustomerInsertEditSuccessResultViewModel Success { get; set; }

	public HolooCustomerInsertEditFailureResultViewModel Failure { get; set; }
}
