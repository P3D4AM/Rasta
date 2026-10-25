using System;

namespace CRM.Models;

public class CRMspChartDailyPreOrders_Result
{
	public string Persiandate { get; set; }

	public string PDay { get; set; }

	public decimal? ordAmnt { get; set; }

	public int? pordCnt { get; set; }

	public string pordCntAmnt { get; set; }

	public DateTime? Miladidate { get; set; }

	public int? MDay { get; set; }
}
