using System;

namespace Mobile.Models;

public class HRMMobspSelectUsersById_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserRollId { get; set; }

	public string RollName { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public bool? UserIsActiveInHRM { get; set; }

	public string MobHRMImeiCode { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ResponsibleUser { get; set; }

	public int? DepartmentId { get; set; }

	public string Department { get; set; }

	public DateTime? StartDate { get; set; }

	public string Nickname { get; set; }

	public string PersCode { get; set; }

	public int? UserGroupId { get; set; }

	public string UserGroup { get; set; }

	public int? PositionId { get; set; }

	public string Position { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string Mobile { get; set; }

	public string MobileII { get; set; }

	public string NationalCode { get; set; }

	public string IdentityNumber { get; set; }

	public string FatherName { get; set; }

	public string InsuranceCode { get; set; }

	public string Address { get; set; }

	public string Tel { get; set; }

	public string TelDesc { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }
}
