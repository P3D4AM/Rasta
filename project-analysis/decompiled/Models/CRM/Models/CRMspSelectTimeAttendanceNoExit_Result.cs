using System;

namespace CRM.Models;

public class CRMspSelectTimeAttendanceNoExit_Result
{
	public int TimeAttendanceId { get; set; }

	public int tmUserId { get; set; }

	public DateTime tmDate { get; set; }

	public string tmDatePersian { get; set; }

	public DateTime? tmEntryTime { get; set; }

	public string tmEntryTimePersian { get; set; }

	public DateTime? tmExitTime { get; set; }

	public string tmExitTimePersian { get; set; }
}
