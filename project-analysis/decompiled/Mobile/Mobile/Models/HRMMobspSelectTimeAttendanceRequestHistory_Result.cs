using System;

namespace Mobile.Models;

public class HRMMobspSelectTimeAttendanceRequestHistory_Result
{
	public long? RowNumber { get; set; }

	public int TimeAttendanceRequestId { get; set; }

	public int RequestTypeId { get; set; }

	public string RequestData { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int? AllPage { get; set; }
}
