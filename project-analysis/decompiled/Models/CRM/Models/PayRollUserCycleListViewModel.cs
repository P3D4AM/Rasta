using System.Collections.Generic;

namespace CRM.Models;

public class PayRollUserCycleListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<PayRollspSelectUserCycleInMonth_Result> PayRollUserCycles { get; set; }
}
