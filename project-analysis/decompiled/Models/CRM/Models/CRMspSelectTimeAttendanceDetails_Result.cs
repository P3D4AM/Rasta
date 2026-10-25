using System;

namespace CRM.Models;

public class CRMspSelectTimeAttendanceDetails_Result
{
	public long TimeAttendanceDetailID { get; set; }

	public int? tmdUserId { get; set; }

	public string tmdUser { get; set; }

	public int? tmdTimeAttendanceId { get; set; }

	public int? tmdShiftWorkingTimeId { get; set; }

	public string tmdShiftWorkingTimeTitle { get; set; }

	public int? tmdLeaveId { get; set; }

	public int? tmdLeaveTypeId { get; set; }

	public int? tmdLeaveStepId { get; set; }

	public string tmdLat { get; set; }

	public string tmdLng { get; set; }

	public double? tmdZoom { get; set; }

	public DateTime? tmdDateTime { get; set; }

	public string tmdDateTimePersian { get; set; }

	public string tmdEntryRegisterIP { get; set; }

	public string tmdEntryBaseTime { get; set; }

	public string tmdEntryTime { get; set; }

	public int? tmdEntryTimeDelay { get; set; }

	public int? tmdEntryTimeDelayAllowMin { get; set; }

	public string tmdExitRegisterIP { get; set; }

	public string tmdExitBaseTime { get; set; }

	public string tmdExitTime { get; set; }

	public int? tmdExitTimeDelay { get; set; }

	public int? tmdExitTimeDelayAllowMin { get; set; }

	public string tmdEntryTimeDelayStr { get; set; }

	public string tmdExitTimeDelayStr { get; set; }

	public string tmdLeaveType { get; set; }

	public string tmdEntryLat { get; set; }

	public string tmdEntryLng { get; set; }

	public double? tmdEntryZoom { get; set; }

	public bool? tmdEntryIsTemp { get; set; }

	public string tmdExitLat { get; set; }

	public string tmdExitLng { get; set; }

	public double? tmdExitZoom { get; set; }

	public bool? tmdExitIsTemp { get; set; }
}
