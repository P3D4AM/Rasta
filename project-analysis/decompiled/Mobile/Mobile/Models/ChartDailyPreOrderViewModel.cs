using System.Collections.Generic;

namespace Mobile.Models;

public class ChartDailyPreOrderViewModel
{
	public List<MobspChartDailyPreOrders_Result> ThisYear { get; set; }

	public List<MobspChartDailyPreOrders_Result> LastYear { get; set; }
}
