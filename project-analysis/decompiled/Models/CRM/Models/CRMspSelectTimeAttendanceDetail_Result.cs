using System;

namespace CRM.Models;

public class CRMspSelectTimeAttendanceDetail_Result
{
	public long TimeAttendanceDetailID { get; set; }

	public int? tmdUserId { get; set; }

	public int? tmdTimeAttendanceId { get; set; }

	public int? tmdShiftWorkingTimeId { get; set; }

	public int? tmdLeaveId { get; set; }

	public DateTime? tmdDateTime { get; set; }

	public string tmdDateTimePersian { get; set; }

	public string tmdEntryRegisterIP { get; set; }

	public string tmdEntryBaseTime { get; set; }

	public string tmdEntryTime { get; set; }

	public int? tmdEntryTimeDelay { get; set; }

	public string tmdExitRegisterIP { get; set; }

	public string tmdExitBaseTime { get; set; }

	public string tmdExitTime { get; set; }

	public int? tmdExitTimeDelay { get; set; }

	public int? tmdLeaveStepId { get; set; }

	public string tmdLeaveStep { get; set; }

	public string tmdLat { get; set; }

	public string tmdLng { get; set; }

	public double? tmdZoom { get; set; }

	public string tmdEntryTimeDelayStr { get; set; }

	public string tmdExitTimeDelayStr { get; set; }
}
