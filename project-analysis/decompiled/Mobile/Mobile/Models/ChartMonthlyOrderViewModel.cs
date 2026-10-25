using System.Collections.Generic;

namespace Mobile.Models;

public class ChartMonthlyOrderViewModel
{
	public List<MobspChartMonthlyOrders_Result> ThisYear { get; set; }

	public List<MobspChartMonthlyOrders_Result> LastYear { get; set; }
}
