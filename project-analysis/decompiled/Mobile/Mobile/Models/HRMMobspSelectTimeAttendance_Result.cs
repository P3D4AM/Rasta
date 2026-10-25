using System;

namespace Mobile.Models;

public class HRMMobspSelectTimeAttendance_Result
{
	public int? tmUserId { get; set; }

	public string tmUser { get; set; }

	public DateTime? tmDate { get; set; }

	public DateTime? tmEntryBase { get; set; }

	public DateTime? tmEntryTime { get; set; }

	public int? tmEntryDelay { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public int? DelayMinusAllow { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public DateTime? tmExitBase { get; set; }

	public DateTime? tmExitTime { get; set; }

	public int? tmExitHurry { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public int? HurryMinusAllow { get; set; }

	public string tmExitRegisterIP { get; set; }

	public string DayName { get; set; }

	public int? DayNum { get; set; }

	public bool? IsClosed { get; set; }

	public string IsClosedDesc { get; set; }

	public string AppType { get; set; }

	public int? TimeAttendanceId { get; set; }

	public bool IsAbsent { get; set; }

	public bool IsWeekend { get; set; }
}
