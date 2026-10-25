using System.Collections.Generic;

namespace Mobile.Models;

public class TimeAttendanceResultViewModel
{
	public List<MobspResultsTimeAttendanceCartable_Result> Result { get; set; }

	public MobspResultsTimeAttendanceCartableFooter_Result Footer { get; set; }
}
