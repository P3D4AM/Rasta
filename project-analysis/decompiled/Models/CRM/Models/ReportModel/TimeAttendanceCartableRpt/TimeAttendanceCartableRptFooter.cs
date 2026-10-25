namespace CRM.Models.ReportModel.TimeAttendanceCartableRpt;

public class TimeAttendanceCartableRptFooter : CRMspResultsTimeAttendanceCartableFooter_Result
{
	public string tmUserName { get; set; }

	public string CalcEntryTimeDelayHour { get; set; }

	public string CalcSoonEntryTimeDelayHour { get; set; }

	public string CalcHurryExitTimeDelayHour { get; set; }

	public string CalcOvertimeHour { get; set; }

	public string CalcAllHourlyLeaveTimeMinutes { get; set; }

	public string CalcAllHourlyMissionTimeMinutes { get; set; }
}
