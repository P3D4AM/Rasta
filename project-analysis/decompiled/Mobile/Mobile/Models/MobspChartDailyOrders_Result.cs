using System;

namespace Mobile.Models;

public class MobspChartDailyOrders_Result
{
	public string Persiandate { get; set; }

	public string PDay { get; set; }

	public decimal? ordAmnt { get; set; }

	public int? ordCnt { get; set; }

	public DateTime? Miladidate { get; set; }

	public int? MDay { get; set; }
}
