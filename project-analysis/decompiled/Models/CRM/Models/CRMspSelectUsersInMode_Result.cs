using System;

namespace CRM.Models;

public class CRMspSelectUsersInMode_Result
{
	public int UserId { get; set; }

	public int? Row { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string PersCode { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string IsAdmin { get; set; }

	public bool? IsActive { get; set; }

	public string Description { get; set; }

	public int? UserId1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string IPAddress { get; set; }

	public string Tel { get; set; }

	public string TelDesc { get; set; }

	public int? PositionId { get; set; }

	public int? SignatureId { get; set; }

	public int? DepartmentId { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ComputerName { get; set; }

	public Guid? GUId { get; set; }

	public bool? CallreIdDeActive { get; set; }

	public string CallreIdDeActiveLines { get; set; }

	public bool? DisableInternalMessageAllarmVoice { get; set; }

	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	public string EmailAttachFileLocation { get; set; }

	public string AppType { get; set; }

	public bool? CanSetFree { get; set; }

	public string UserCIPatternFormulaPopUp { get; set; }

	public bool? UseClientNameForNetworking { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public int? LanguageID { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string Department { get; set; }

	public string ResponsibleUser { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public DateTime? CoordinateLastDate { get; set; }

	public string CoordinateLastDatePersian { get; set; }

	public bool? MobAppBaseInfoNeedUpdate { get; set; }

	public bool? UserIsActiveInFOSetting { get; set; }

	public int? MaxNumberCmpDraft { get; set; }

	public string Mobile { get; set; }

	public string MobileII { get; set; }

	public string Address { get; set; }

	public string FatherName { get; set; }

	public string NationalCode { get; set; }

	public string IdentityNumber { get; set; }

	public string InsuranceCode { get; set; }

	public string PositionName { get; set; }

	public int? UserRollId { get; set; }

	public string UserRollName { get; set; }

	public DateTime? StartDate { get; set; }

	public string StartDatePersian { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string ExpireDatePersian { get; set; }

	public int? UserGroupId { get; set; }

	public string UserGroup { get; set; }

	public string UserExtensions { get; set; }

	public bool? MobDeActiveAccessToLocation { get; set; }

	public string LinkAccUserCode { get; set; }

	public string LinkAccUserIdStr { get; set; }

	public string Nickname { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public bool? UserIsActiveInHRM { get; set; }

	public string MobHRMImeiCode { get; set; }

	public string AlternativeUserIds { get; set; }

	public bool? ActiveMobMovementTracking { get; set; }

	public double? MobMovementTrackingDistanceInterval { get; set; }

	public int? MobMovementTrackingTimeInterval { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public bool? MobDeActiveScreenshot { get; set; }

	public bool? MobCallerIdDeActive { get; set; }

	public int? MobUserAppUseCnt { get; set; }

	public int? MobHRMUserAppUseCnt { get; set; }

	public bool? UserIsActiveInCIC { get; set; }

	public int? MobCICUserAppUseCnt { get; set; }

	public bool? CallerIdDeActiveFromMobile { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }

	public int? MobHRMLoginMode { get; set; }

	public int? UserLoginCheckLocationType { get; set; }

	public string UserLoginCheckLocations { get; set; }

	public string UserLoginCheckLocations_Lang { get; set; }

	public string UserCenterNames { get; set; }

	public int? UserCId { get; set; }

	public string UserCenterName { get; set; }

	public int? ShiftWorkingId { get; set; }

	public string ShiftWorkingTitle { get; set; }

	public bool? DeActiveLoginWithoutShift { get; set; }

	public bool? AppLocationRequired { get; set; }

	public bool? CrmNotifDeactivInHrm { get; set; }

	public string CallPreNumber { get; set; }
}
