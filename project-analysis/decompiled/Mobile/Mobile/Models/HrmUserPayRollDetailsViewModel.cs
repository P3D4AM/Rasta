using System.Collections.Generic;

namespace Mobile.Models;

public class HrmUserPayRollDetailsViewModel
{
	public HRMMobPayRollspSelectUserCycle_Result Details { get; set; }

	public List<HRMMobPayRollspSelectUserPayments_Result> Payments { get; set; }

	public List<HRMMobPayRollspSelectUserCycleItemValues_Result> ItemsAdditive { get; set; }

	public List<HRMMobPayRollspSelectUserCycleItemValues_Result> ItemsReduction { get; set; }

	public HRMMobPayRollspReturnUserCycleFinalAmount_Result FinalAmount { get; set; }

	public List<HRMMobPayRollspSelectUserCycleOrderCommissions_Result> Commissions { get; set; }
}
