using System;

namespace CRM.Models;

public class CRMspResultsTimeAttendanceCartable_Result
{
	public int? TimeAttendanceId { get; set; }

	public int? tmUserId { get; set; }

	public string tmUser { get; set; }

	public DateTime? tmDate { get; set; }

	public string MyDays_FA { get; set; }

	public string MyDays_AR { get; set; }

	public DateTime? tmEntryBase { get; set; }

	public DateTime? tmEntryTime { get; set; }

	public int? tmEntryDelay { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public int? DelayMinusAllow { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public DateTime? tmExitBase { get; set; }

	public DateTime? tmExitTime { get; set; }

	public int? tmExitHurry { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public int? HurryMinusAllow { get; set; }

	public string tmExitRegisterIP { get; set; }

	public int? tmEntryTimeVerifyUserId { get; set; }

	public DateTime? tmEntryTimeVerifyDate { get; set; }

	public string tmEntryTimeVerifyDatePersian { get; set; }

	public int? tmExitTimeVerifyUserId { get; set; }

	public DateTime? tmExitTimeVerifyDate { get; set; }

	public string tmExitTimeVerifyDatePersian { get; set; }

	public string tmEntryTimeVerifyUser { get; set; }

	public string tmExitTimeVerifyUser { get; set; }

	public string DayName { get; set; }

	public bool? IsClosed { get; set; }

	public string IsClosedDesc { get; set; }

	public string AppType { get; set; }

	public bool? IsAbsent { get; set; }

	public bool? IsWeekend { get; set; }

	public string EntryDiff { get; set; }

	public int? EntryDiffMinute { get; set; }

	public int? EntryDiffSecond { get; set; }

	public string EntryDiffSign { get; set; }

	public string ExitDiff { get; set; }

	public int? ExitDiffMinute { get; set; }

	public int? ExitDiffSecond { get; set; }

	public string ExitDiffSign { get; set; }

	public string HourlyLeaveInfoJs { get; set; }

	public string DailyLeaveInfoJs { get; set; }

	public string HourlyMissionInfoJs { get; set; }

	public string DailyMissionInfoJs { get; set; }

	public bool? IsNotArrivedDay { get; set; }

	public int? tmLeaveId { get; set; }

	public int? tmLeaveTypeId { get; set; }

	public int? tmExitTimeLateAllowMin { get; set; }

	public int? tmEntryTimeSoonAllowMin { get; set; }

	public string DailyLeaveIdJson { get; set; }

	public string DailyMissionIdJson { get; set; }

	public int? CalcEntryTimeDelay { get; set; }

	public string CalcEntryTimeDelayStr { get; set; }

	public int? CalcSoonEntryTimeDelay { get; set; }

	public string CalcSoonEntryTimeDelayStr { get; set; }

	public int? CalcHurryExitTimeDelay { get; set; }

	public string CalcHurryExitTimeDelayStr { get; set; }

	public int? CalcOvertime { get; set; }

	public string CalcOvertimeStr { get; set; }

	public int? UserLoginCnt { get; set; }

	public int? AbsenceDays { get; set; }

	public int? AllHourlyLeaveTimeMinutes { get; set; }

	public string AllHourlyLeaveTimeMinutesStr { get; set; }

	public int? AllDailyLeaveCnt { get; set; }

	public int? AllHourlyMissionTimeMinutes { get; set; }

	public string AllHourlyMissionTimeMinutesStr { get; set; }

	public int? AllDailyMissionCnt { get; set; }

	public int? tmShiftWorkingTimeId { get; set; }

	public int? tmShiftWorkingId { get; set; }

	public string tmEntryLat { get; set; }

	public string tmEntryLng { get; set; }

	public double? tmEntryZoom { get; set; }

	public bool? tmEntryIsTemp { get; set; }

	public string tmExitLat { get; set; }

	public string tmExitLng { get; set; }

	public double? tmExitZoom { get; set; }

	public bool? tmExitIsTemp { get; set; }

	public int? tmdEntryIsTempCnt { get; set; }

	public int? tmdExitIsTempCnt { get; set; }
}
