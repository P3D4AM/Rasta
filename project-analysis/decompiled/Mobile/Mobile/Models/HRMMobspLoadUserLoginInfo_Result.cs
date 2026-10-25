using System;

namespace Mobile.Models;

public class HRMMobspLoadUserLoginInfo_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserRollId { get; set; }

	public string RollName { get; set; }

	public DateTime? ExpireDate { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public bool? UserIsActiveInHRM { get; set; }

	public string MobHRMImeiCode { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ResponsibleUser { get; set; }

	public int? MobHRMUserAppUseCnt { get; set; }

	public int? MobHRMLoginMode { get; set; }

	public int? UserLoginCheckLocationType { get; set; }

	public string UserLoginCheckLocations { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }

	public string DepartmentInfo { get; set; }

	public int? DepartmentId { get; set; }

	public string Department { get; set; }

	public int? ShiftWorkingId { get; set; }
}
