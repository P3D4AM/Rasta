using System;

namespace Mobile.Models;

public class HRMMobspSelectCrmsysSetting_Result
{
	public int ID { get; set; }

	public string CoName { get; set; }

	public bool? SmartTimeAttendance { get; set; }

	public string CoLatitude { get; set; }

	public string CoLongitude { get; set; }

	public int? CoZoom { get; set; }

	public double? UserLoginAccessDistance { get; set; }

	public bool? CheckLocForScanQR { get; set; }

	public bool? CheckLocForScanQRInMission { get; set; }

	public int? UserLoginAccessTimeDiffInMission { get; set; }

	public string CoLogoMobHRMAppPath { get; set; }

	public string CoNameMobHRMApp { get; set; }

	public bool? TimeAttendanceRecIsTemp { get; set; }

	public string TimeAttendanceRecTempVerifyUserIds { get; set; }

	public string TimeAttendanceRecTempVerifyRollId { get; set; }

	public DateTime? TimeAttendanceRecTempExpirDate { get; set; }

	public string LoginAuthUrl { get; set; }

	public string PublicNotice { get; set; }
}
