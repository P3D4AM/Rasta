using System.Collections.Generic;

namespace Mobile.Models;

public class HrmLoginResultViewModel
{
	public string Token { get; set; }

	public string FullName { get; set; }

	public int UserId { get; set; }

	public int RollId { get; set; }

	public string RollName { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ResponsibleUser { get; set; }

	public int? DepartmentId { get; set; }

	public string Department { get; set; }

	public string DepartmentInfo { get; set; }

	public string DefMapType { get; set; }

	public bool VBLeave { get; set; }

	public bool VBSmartTimeAttendance { get; set; }

	public List<string> MaliciousFileExtensions { get; set; }

	public int MaxFileSizeForUploadMb { get; set; }

	public int MaxFileCountForUpload { get; set; }

	public int FileDirectoryTitleLength { get; set; }

	public int MobHRMLoginMode { get; set; }

	public bool VBCenter { get; set; }

	public int? UserLastCId { get; set; }

	public string UserCIds { get; set; }

	public int? ShiftWorkingId { get; set; }

	public string TimeAttendanceLocation { get; set; }
}
