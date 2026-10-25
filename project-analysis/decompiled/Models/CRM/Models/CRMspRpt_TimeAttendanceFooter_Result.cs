namespace CRM.Models;

public class CRMspRpt_TimeAttendanceFooter_Result
{
	public int? tmUserId { get; set; }

	public string tmUser { get; set; }

	public int? ShiftWorkingTimeID { get; set; }

	public string ShiftWorkingTimeTitle { get; set; }

	public int? AllDaysInMonth { get; set; }

	public int? IsAbsentCnt { get; set; }

	public int? UserLoginCnt { get; set; }

	public int? CalcEntrySoonTimeMin { get; set; }

	public string CalcEntrySoonTimeMinStr { get; set; }

	public int? CalcHurryTimeMin { get; set; }

	public string CalcHurryTimeMinStr { get; set; }

	public int? CalcOverTimeMin { get; set; }

	public string CalcOverTimeMinStr { get; set; }

	public int? DailyLeaveCnt { get; set; }

	public int? HourlyLeaveMin { get; set; }

	public string HourlyLeaveMinStr { get; set; }

	public int? HourlyLeaveDelayTimeMin { get; set; }

	public string HourlyLeaveDelayTimeMinStr { get; set; }

	public int? HourlyLeaveSoonEntryTimeMin { get; set; }

	public string HourlyLeaveSoonEntryTimeMinStr { get; set; }

	public int? HourlyLeaveHurryTimeMin { get; set; }

	public string HourlyLeaveHurryTimeMinStr { get; set; }

	public int? HourlyLeaveOverTimeMin { get; set; }

	public string HourlyLeaveOverTimeMinStr { get; set; }

	public int? DailyMissionCnt { get; set; }

	public int? HouryMissionMin { get; set; }

	public string HouryMissionMinStr { get; set; }

	public int? HourlyMissionDelayTimeMin { get; set; }

	public string HourlyMissionDelayTimeMinStr { get; set; }

	public int? HourlyMissionSoonEntryTimeMin { get; set; }

	public string HourlyMissionSoonEntryTimeMinStr { get; set; }

	public int? HourlyMissionHurryTimeMin { get; set; }

	public string HourlyMissionHurryTimeMinStr { get; set; }

	public int? HourlyMissionOverTimeMin { get; set; }

	public string HourlyMissionOverTimeMinStr { get; set; }

	public int? CalcDelayTimeMin { get; set; }

	public string CalcDelayTimeMinStr { get; set; }

	public int? IsClosedTimeMin { get; set; }

	public string IsClosedTimeMinStr { get; set; }
}
