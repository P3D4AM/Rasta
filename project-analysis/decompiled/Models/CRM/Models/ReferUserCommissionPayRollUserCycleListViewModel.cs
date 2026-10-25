using System.Collections.Generic;

namespace CRM.Models;

public class ReferUserCommissionPayRollUserCycleListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<WSspSelectPayOrderCommissionPayRollUserCycle_Result> PayRollUserCycles { get; set; }
}
