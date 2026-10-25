using System.Collections.Generic;

namespace Mobile.Models;

public class UserOrderCommissionsChartResultViewModel
{
	public List<MobspSelectUserOrderCommissionsChartByUser_Result> UserChart { get; set; }

	public List<MobspSelectUserOrderCommissionsChartByCmp_Result> CmpChart { get; set; }
}
