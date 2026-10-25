using System;

namespace Mobile.Models;

public class MobspLoadUserLoginInfo_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public bool? IsActive { get; set; }

	public string IsAdmin { get; set; }

	public string IPAddress { get; set; }

	public string ComputerName { get; set; }

	public bool? CallreIdDeActive { get; set; }

	public string CallreIdDeActiveLines { get; set; }

	public bool? DisableInternalMessageAllarmVoice { get; set; }

	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	public string EmailAttachFileLocation { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public bool? CanSetFree { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public int UserRollId { get; set; }

	public string RollName { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public DateTime? CoordinateLastDate { get; set; }

	public string CoordinateLastDatePersian { get; set; }

	public int? MaxNumberCmpDraft { get; set; }

	public bool? MobDeActiveAccessToLocation { get; set; }

	public bool? UserAccessDailyChrtAllUsers { get; set; }

	public bool? UserAccessSaleChrtAllUsers { get; set; }

	public DateTime? ExpireDate { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public bool? UserIsActiveInHRM { get; set; }

	public bool? ActiveMobMovementTracking { get; set; }

	public double? MobMovementTrackingDistanceInterval { get; set; }

	public int? MobMovementTrackingTimeInterval { get; set; }

	public bool LimitPreOrderDiscountActive { get; set; }

	public decimal LimitPreOrderDiscountPercent { get; set; }

	public bool LimitOrderDiscountActive { get; set; }

	public decimal LimitOrderDiscountPercent { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ResponsibleUser { get; set; }

	public bool? MobDeActiveScreenshot { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public bool? MobCallerIdDeActive { get; set; }

	public string MobAppDevSetting { get; set; }

	public int? MobUserAppUseCnt { get; set; }

	public int? MobHRMLoginMode { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }

	public string DepartmentInfo { get; set; }

	public bool? AppLocationRequired { get; set; }

	public int? ShiftWorkingId { get; set; }

	public string UserExtensions { get; set; }

	public int? UserLoginCheckLocationType { get; set; }

	public string UserLoginCheckLocations { get; set; }
}
