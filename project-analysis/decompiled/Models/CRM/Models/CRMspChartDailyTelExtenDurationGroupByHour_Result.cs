using System;

namespace CRM.Models;

public class CRMspChartDailyTelExtenDurationGroupByHour_Result
{
	public TimeSpan? ClockHour { get; set; }

	public string Phone { get; set; }

	public int? SumDuration { get; set; }

	public int? ExtenCnt { get; set; }
}
