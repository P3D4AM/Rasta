using System;

namespace CRM.Models;

public class CRMspSelectTimeAttendanceByDate_Result
{
	public int TimeAttendanceId { get; set; }

	public DateTime tmDate { get; set; }

	public string tmDatePersian { get; set; }

	public int tmTypeId { get; set; }

	public int tmUserId { get; set; }

	public DateTime? tmEntryBase { get; set; }

	public DateTime tmEntryTime { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public DateTime? tmExitBase { get; set; }

	public DateTime? tmExitTime { get; set; }

	public int? tmExitHurry { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public string tmExitRegisterIP { get; set; }

	public string tmDescription { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short tmYear1 { get; set; }

	public int tmDay { get; set; }

	public int tmDayOfWeek { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? tmEntryTimeVerifyUserId { get; set; }

	public DateTime? tmEntryTimeVerifyDate { get; set; }

	public string tmEntryTimeVerifyDatePersian { get; set; }

	public int? tmExitTimeVerifyUserId { get; set; }

	public DateTime? tmExitTimeVerifyDate { get; set; }

	public string tmExitTimeVerifyDatePersian { get; set; }

	public string tmUser { get; set; }

	public string tmEntryTimeVerifyUser { get; set; }

	public string tmExitTimeVerifyUser { get; set; }

	public int? tmShiftWorkingTimeId { get; set; }

	public int? tmLeaveId { get; set; }

	public int? tmLeaveTypeId { get; set; }

	public int? tmExitTimeLateAllowMin { get; set; }

	public int? tmEntryTimeSoonAllowMin { get; set; }

	public string tmTimeStr { get; set; }

	public string tmEntryBaseTimeStr { get; set; }

	public string tmEntryTimeStr { get; set; }

	public string tmEntryDelayStr { get; set; }

	public string tmEntryDelayAllowMinStr { get; set; }

	public string tmExitBaseTimeStr { get; set; }

	public string tmExitTimeStr { get; set; }

	public string tmExitHurryStr { get; set; }

	public string tmExitHurryAllowMinStr { get; set; }

	public int? tmEntryDelay { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public string tmShiftWorkingTime { get; set; }
}
