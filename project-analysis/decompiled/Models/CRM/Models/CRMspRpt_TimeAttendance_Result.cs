using System;

namespace CRM.Models;

public class CRMspRpt_TimeAttendance_Result
{
	public DateTime? tmDate { get; set; }

	public string tmDatePersian { get; set; }

	public int tmUserId { get; set; }

	public string tmUser { get; set; }

	public int? ShiftWorkingID { get; set; }

	public string ShiftWorkingTitle { get; set; }

	public int? ShiftWorkingTimeID { get; set; }

	public string ShiftWorkingTimeTitle { get; set; }

	public bool? IsClosed { get; set; }

	public string IsClosedDesc { get; set; }

	public int? TimeAttendanceId { get; set; }

	public int? tmLeaveId { get; set; }

	public int? tmLeaveTypeId { get; set; }

	public string tmLeaveType { get; set; }

	public DateTime? tmEntryBase { get; set; }

	public string tmEntryBaseStr { get; set; }

	public DateTime? tmEntryTime { get; set; }

	public string tmEntryTimeStr { get; set; }

	public string tmEntryRegisterIP { get; set; }

	public int? tmEntryDelay { get; set; }

	public string tmEntryDelayStr { get; set; }

	public int? tmEntryDelayAllowMin { get; set; }

	public string tmEntryDelayAllowMinStr { get; set; }

	public DateTime? tmExitBase { get; set; }

	public string tmExitBaseStr { get; set; }

	public DateTime? tmExitTime { get; set; }

	public string tmExitTimeStr { get; set; }

	public string tmExitRegisterIP { get; set; }

	public int? tmExitHurry { get; set; }

	public string tmExitHurryStr { get; set; }

	public int? tmExitHurryAllowMin { get; set; }

	public string tmExitHurryAllowMinStr { get; set; }

	public int? IsAbsent { get; set; }

	public string tmDayName { get; set; }

	public string tmEntryLat { get; set; }

	public string tmEntryLng { get; set; }

	public double? tmEntryZoom { get; set; }

	public bool? tmEntryIsTemp { get; set; }

	public string tmExitLat { get; set; }

	public string tmExitLng { get; set; }

	public double? tmExitZoom { get; set; }

	public bool? tmExitIsTemp { get; set; }
}
