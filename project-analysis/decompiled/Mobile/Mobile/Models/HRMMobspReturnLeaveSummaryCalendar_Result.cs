using System;

namespace Mobile.Models;

public class HRMMobspReturnLeaveSummaryCalendar_Result
{
	public int? LeaveId { get; set; }

	public DateTime? SingleDate { get; set; }

	public int? LeaveTypeId { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }

	public int? DayCount { get; set; }

	public string FromTime { get; set; }

	public string ToTime { get; set; }

	public string HourCount { get; set; }

	public string SingleDateEN { get; set; }
}
