namespace CRM.Models;

public class MobParamViewModel : ParamViewModel
{
	public string Value { get; set; }

	public int? Ln { get; set; }

	public int? ShiftWorkingTimeId { get; set; }

	public int? LeaveId { get; set; }

	public string LeaveStepIds { get; set; }

	public string AddLeavesIds { get; set; }

	public bool? IsEntry { get; set; }

	public string AppType { get; set; }

	public string ClearTimeAttendanceIds { get; set; }
}
