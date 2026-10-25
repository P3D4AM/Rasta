using System.Collections.Generic;

namespace Mobile.Models;

public class ChartDailyExtraOrderViewModel
{
	public List<MobspChartDailyOrdersExtra_Result> ThisYear { get; set; }

	public List<MobspChartDailyOrdersExtra_Result> LastYear { get; set; }
}
