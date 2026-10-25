namespace CRM.Models;

public class CRMspSelectLeaveStepsWithTimeAttendance_Result
{
	public int LeaveStepID { get; set; }

	public int LeaveStepGroupId { get; set; }

	public string LeaveStepGroup { get; set; }

	public string lsTitle { get; set; }

	public bool? lsIsRequired { get; set; }

	public string TimeAttendanceDetailInfoJs { get; set; }
}
