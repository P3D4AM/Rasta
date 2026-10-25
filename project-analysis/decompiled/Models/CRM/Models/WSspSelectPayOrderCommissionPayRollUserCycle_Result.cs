using System;

namespace CRM.Models;

public class WSspSelectPayOrderCommissionPayRollUserCycle_Result
{
	public int PayRollUserCycleId { get; set; }

	public int CrmUserId { get; set; }

	public string CycleTitle { get; set; }

	public DateTime CycleDate { get; set; }

	public string CycleDatePersian { get; set; }

	public string CrmUser { get; set; }

	public string PayRollUserCycleItemValuesJson { get; set; }
}
