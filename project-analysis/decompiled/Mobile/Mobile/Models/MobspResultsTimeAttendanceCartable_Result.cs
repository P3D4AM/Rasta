using System;

namespace Mobile.Models;

public class MobspResultsTimeAttendanceCartable_Result
{
	public int? TimeAttendanceId { get; set; }

	public int? tmUserId { get; set; }

	public string tmUser { get; set; }

	public DateTime? tmDate { get; set; }

	public string tmDatePersian { get; set; }

	public int? tmTypeId { get; set; }

	public DateTime? tmEntryBase { get; set; }

	public DateTime? tmEntryTime { get; set; }

	public int? tmEntryDelay { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public DateTime? tmExitBase { get; set; }

	public DateTime? tmExitTime { get; set; }

	public int? tmExitHurry { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public string tmExitRegisterIP { get; set; }

	public string tmDescription { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? UserId { get; set; }

	public string User { get; set; }

	public short? Month1 { get; set; }

	public short? tmYear1 { get; set; }

	public int? tmDay { get; set; }

	public int? tmDayOfWeek { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? tmEntryTimeVerifyUserId { get; set; }

	public string tmEntryTimeVerifyUser { get; set; }

	public DateTime? tmEntryTimeVerifyDate { get; set; }

	public string tmEntryTimeVerifyDatePersian { get; set; }

	public int? tmExitTimeVerifyUserId { get; set; }

	public string tmExitTimeVerifyUser { get; set; }

	public DateTime? tmExitTimeVerifyDate { get; set; }

	public string tmExitTimeVerifyDatePersian { get; set; }

	public bool? IsClosed { get; set; }

	public string IsClosedDesc { get; set; }

	public bool? IsWeekend { get; set; }

	public int? DelayMinusAllow { get; set; }

	public string EntryDiff { get; set; }

	public int? EntryDiffMINUTE { get; set; }

	public int? EntryDiffSecond { get; set; }

	public string EntryDiffSign { get; set; }

	public int? HurryMinusAllow { get; set; }

	public string ExitDiff { get; set; }

	public int? ExitDiffMINUTE { get; set; }

	public int? ExitDiffSecond { get; set; }

	public string ExitDiffSign { get; set; }

	public string DayName { get; set; }

	public string MyDays_FA { get; set; }

	public string MyDays_AR { get; set; }

	public bool? IsNotArrivedDay { get; set; }

	public string HourlyLeaveIds { get; set; }

	public int? DailyLeaveId { get; set; }

	public string HourlyMissionIds { get; set; }

	public int? DailyMissionId { get; set; }

	public string HourlyLeaveInfoJs { get; set; }

	public string DailyLeaveInfoJs { get; set; }

	public string HourlyMissionInfoJs { get; set; }

	public string DailyMissionInfoJs { get; set; }

	public bool? IsAbsent { get; set; }
}
