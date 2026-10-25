using System.Collections.Generic;

namespace Mobile.Models;

public class TimeAttendanceHistoryResultViewModel
{
	public List<HRMMobspSelectTimeAttendance_Result> Result { get; set; }

	public HRMMobspSelectTimeAttendanceFooter_Result Footer { get; set; }
}
