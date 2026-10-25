using System.Collections.Generic;

namespace Mobile.Models;

public class ChartDailyOrderViewModel
{
	public List<MobspChartDailyOrders_Result> ThisYear { get; set; }

	public List<MobspChartDailyOrders_Result> LastYear { get; set; }
}
