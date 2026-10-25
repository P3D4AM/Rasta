using System.Collections.Generic;

namespace CRM.Models;

public class PayRollOrderCommissionListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<PayRollspSelectOrderCommissions_Result> OrderCommissions { get; set; }
}
