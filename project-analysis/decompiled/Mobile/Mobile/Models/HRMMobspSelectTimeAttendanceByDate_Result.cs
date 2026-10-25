using System;

namespace Mobile.Models;

public class HRMMobspSelectTimeAttendanceByDate_Result
{
	public int TimeAttendanceId { get; set; }

	public DateTime tmDate { get; set; }

	public string tmDatePersian { get; set; }

	public int tmTypeId { get; set; }

	public int tmUserId { get; set; }

	public DateTime? tmEntryBase { get; set; }

	public DateTime? tmEntryTime { get; set; }

	public int? tmEntryDelay { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public DateTime? tmExitBase { get; set; }

	public DateTime? tmExitTime { get; set; }

	public int? tmExitHurry { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public string tmExitRegisterIP { get; set; }

	public string tmDescription { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short tmYear1 { get; set; }

	public int tmDay { get; set; }

	public int tmDayOfWeek { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string tmUser { get; set; }
}
