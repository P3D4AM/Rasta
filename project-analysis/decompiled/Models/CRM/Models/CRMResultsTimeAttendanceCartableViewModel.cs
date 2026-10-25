using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMResultsTimeAttendanceCartableViewModel
{
	public int? TimeAttendanceId { get; set; }

	public string tmDateOnlyStr { get; set; }

	[Key]
	public int tmUserId { get; set; }

	public string tmUser { get; set; }

	public bool? IsClosed { get; set; }

	public string IsClosedDesc { get; set; }

	public bool? IsAbsent { get; set; }

	public bool? IsWeekend { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public DateTime? tmDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmDate")]
	public string tmDateStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryBase")]
	public DateTime? tmEntryBase { get; set; }

	public string tmEntryBaseStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryTime")]
	public DateTime? tmEntryTime { get; set; }

	public string tmEntryTimeStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryDelay")]
	public int tmEntryDelay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryDelay")]
	public string tmEntryDelayStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryDelayAllowMin")]
	public int tmEntryDelayAllowMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelayMinusAllow")]
	public int? DelayMinusAllow { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryRegisterIP")]
	public string tmEntryRegisterIP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitBase")]
	public DateTime? tmExitBase { get; set; }

	public string tmExitBaseStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitTime")]
	public DateTime? tmExitTime { get; set; }

	public string tmExitTimeStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitHurry")]
	public int? tmExitHurry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitHurryAllowMin")]
	public int? tmExitHurryAllowMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "HurryMinusAllow")]
	public int? HurryMinusAllow { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitRegisterIP")]
	public string tmExitRegisterIP { get; set; }

	public string tmDayName { get; set; }

	public string tmDateStrWithDayName { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmEntryChanges")]
	public string tmEntryChanges { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmExitChanges")]
	public string tmExitChanges { get; set; }

	public string EntryDiff { get; set; }

	public string EntryDiffSign { get; set; }

	public int? EntryDiffMinute { get; set; }

	public int? EntryDiffSecond { get; set; }

	public string ExitDiff { get; set; }

	public string ExitDiffSign { get; set; }

	public int? ExitDiffMinute { get; set; }

	public int? ExitDiffSecond { get; set; }

	public string HourlyLeaveInfoJs { get; set; }

	public string DailyLeaveInfoJs { get; set; }

	public string HourlyMissionInfoJs { get; set; }

	public string DailyMissionInfoJs { get; set; }

	public bool? IsNotArrivedDay { get; set; }

	public string tmLocalDate { get; set; }

	public int? CalcEntryTimeDelay { get; set; }

	public string CalcEntryTimeDelayStr { get; set; }

	public int? CalcSoonEntryTimeDelay { get; set; }

	public string CalcSoonEntryTimeDelayStr { get; set; }

	public int? CalcHurryExitTimeDelay { get; set; }

	public string CalcHurryExitTimeDelayStr { get; set; }

	public int? CalcOvertime { get; set; }

	public string CalcOvertimeStr { get; set; }

	public int? AllDayOFMonthCnt { get; set; }

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
