using System;

namespace CRM.Models;

public class CRMspSelectTimeAttendanceByLeaveDate_Result
{
	public long TimeAttendanceDetailID { get; set; }

	public int? tmdUserId { get; set; }

	public string tmdUser { get; set; }

	public int? tmdTimeAttendanceId { get; set; }

	public int? tmdShiftWorkingTimeId { get; set; }

	public string tmdShiftWorkingTime { get; set; }

	public int? tmdLeaveId { get; set; }

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

	public string tmdExitRegisterIP { get; set; }

	public string tmdExitBaseTime { get; set; }

	public string tmdExitTime { get; set; }

	public int? tmdExitTimeDelay { get; set; }

	public int? tmdLeaveTypeId { get; set; }

	public string tmdLeaveType { get; set; }

	public int? tmdEntryTimeDelayAllowMin { get; set; }

	public int? tmdExitTimeDelayAllowMin { get; set; }

	public DateTime? LeaveFromDateTime { get; set; }

	public string LeaveFromDate { get; set; }

	public string LeaveFromTime { get; set; }

	public DateTime? LeaveToDateTime { get; set; }

	public string LeaveToDate { get; set; }

	public string LeaveToTime { get; set; }

	public int? LeaveCompanyId { get; set; }

	public string LeaveCompany { get; set; }
}
