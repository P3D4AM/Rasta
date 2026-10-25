using System;

namespace CRM.Models;

public class ImportExcelUserViewModel
{
	public int? RowNum { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string PersCode { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public bool? IsActive { get; set; }

	public string Description { get; set; }

	public string IPAddress { get; set; }

	public string Tel { get; set; }

	public string TelDesc { get; set; }

	public int? RollId { get; set; }

	public int? PositionId { get; set; }

	public int? DepartmentId { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ComputerName { get; set; }

	public bool? CallreIdDeActive { get; set; }

	public string CallreIdDeActiveLines { get; set; }

	public bool? DisableInternalMessageAllarmVoice { get; set; }

	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public bool? UserIsActiveInFOSetting { get; set; }

	public bool? UserAccessDailyChrtAllUsers { get; set; }

	public bool? UserAccessSaleChrtAllUsers { get; set; }

	public string Mobile { get; set; }

	public string MobileII { get; set; }

	public string Address { get; set; }

	public string FatherName { get; set; }

	public string NationalCode { get; set; }

	public string IdentityNumber { get; set; }

	public string InsuranceCode { get; set; }

	public DateTime? StartDate { get; set; }

	public string StartDatePersian { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string ExpireDatePersian { get; set; }

	public int? UserGroupId { get; set; }

	public string UserGroup { get; set; }

	public string UserExtensions { get; set; }

	public bool? MobDeActiveAccessToLocation { get; set; }

	public string Nickname { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public bool? UserIsActiveInHRM { get; set; }

	public string AlternativeUserIds { get; set; }

	public bool? ActiveMobMovementTracking { get; set; }

	public float? MobMovementTrackingDistanceInterval { get; set; }

	public int? MobMovementTrackingTimeInterval { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public bool? MobDeActiveScreenshot { get; set; }

	public bool? MobCallerIdDeActive { get; set; }

	public int? MobUserAppUseCnt { get; set; }

	public int? MobHRMUserAppUseCnt { get; set; }

	public bool? UserIsActiveInCIC { get; set; }

	public int? MobCICUserAppUseCnt { get; set; }

	public bool? CallerIdDeActiveFromMobile { get; set; }

	public string ActiveDirectoryUser { get; set; }

	public bool? AccessAllLanguage { get; set; }

	public bool? AccessOtherUsersCmpInfo { get; set; }

	public bool? AccessOtherUsersPrsInfo { get; set; }

	public bool? AccessOtherUsersPrjInfo { get; set; }

	public bool? AccessOtherUsersCnvsInfo { get; set; }

	public int? UserCIds { get; set; }

	public string UserCenterCode { get; set; }
}
