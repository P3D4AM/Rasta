using System.Collections.Generic;

namespace Mobile.Models;

public class LeaveDetailsResultViewModel
{
	public MobspSelectLeave_Result Leave { get; set; }

	public LeaveSummaryViewModel Summary { get; set; }

	public List<MobspReturnLeaveSummaryCalendar_Result> SummaryCalendar { get; set; }

	public List<MobspSelectClosedCalendarEvents_Result> CalendarEvents { get; set; }

	public MobspSelectUsersById_Result RequestUser { get; set; }
}
