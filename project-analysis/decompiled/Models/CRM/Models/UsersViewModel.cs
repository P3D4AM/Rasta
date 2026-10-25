using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UsersViewModel
{
	[Key]
	public int UserId { get; set; }

	public int? Row { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserFName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserPersCode")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PersCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string VmUName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string VmPword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserVerifyPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[Compare("VmPword", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorMismatchPassword")]
	public string VmVerifyPword { get; set; }

	public string IsAdmin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActive")]
	public bool UserIsActive
	{
		get
		{
			if (IsActive.HasValue)
			{
				return IsActive.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserDescription")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int? UserId1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string IPAddress { get; set; }

	public string Tel { get; set; }

	public string TelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserPositionIdI")]
	public int? PositionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserPositionIdI")]
	public string PositionIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserSignatureId")]
	public int? SignatureId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDepartmentI")]
	public int? DepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDepartmentI")]
	public string DepartmentIdTitle { get; set; }

	public string DepartmentInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserResponsibleName")]
	public int? ResponsibleUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserResponsibleName")]
	public string ResponsibleUserIdTitle { get; set; }

	public string ComputerName { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserCallreIdDeActive")]
	public bool? CallreIdDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserCallreIdDeActive")]
	public bool UserCallreIdDeActive
	{
		get
		{
			if (CallreIdDeActive.HasValue)
			{
				return CallreIdDeActive.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserCallreIdDeActiveLines")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CallreIdDeActiveLines { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDisableInternalMessageAllarmVoice")]
	public bool? DisableInternalMessageAllarmVoice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDisableInternalMessageAllarmVoice")]
	public bool UserDisableInternalMessageAllarmVoice
	{
		get
		{
			if (DisableInternalMessageAllarmVoice.HasValue)
			{
				return DisableInternalMessageAllarmVoice.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserDisableReceiveCNVSInfoAllarm")]
	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDisableReceiveCNVSInfoAllarm")]
	public bool UserDisableReceiveCNVSInfoAllarm
	{
		get
		{
			if (DisableReceiveCNVSInfoAllarm.HasValue)
			{
				return DisableReceiveCNVSInfoAllarm.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserEmailAttachFileLocation")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailAttachFileLocation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAllowCopyOtherLanguage")]
	public bool? AllowCopyOtherLanguage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAllowCopyOtherLanguage")]
	public bool UserAllowCopyOtherLanguage
	{
		get
		{
			if (AllowCopyOtherLanguage.HasValue)
			{
				return AllowCopyOtherLanguage.GetValueOrDefault();
			}
			return false;
		}
	}

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessAllLanguage")]
	public bool AccessAllLanguage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInWinApp")]
	public bool? UserIsActiveInWinApp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInWinApp")]
	public bool UsrIsActiveInWinApp
	{
		get
		{
			if (UserIsActiveInWinApp.HasValue)
			{
				return UserIsActiveInWinApp.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInWebApp")]
	public bool? UserIsActiveInWebApp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInWebApp")]
	public bool UsrIsActiveInWebApp
	{
		get
		{
			if (UserIsActiveInWebApp.HasValue)
			{
				return UserIsActiveInWebApp.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInMobApp")]
	public bool? UserIsActiveInMobApp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInMobApp")]
	public bool UsrIsActiveInMobApp
	{
		get
		{
			if (UserIsActiveInMobApp.HasValue)
			{
				return UserIsActiveInMobApp.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "AppLocationRequired")]
	public bool? AppLocationRequired { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmNotifDeactivInHrm")]
	public bool? CrmNotifDeactivInHrm { get; set; }

	public string FirstRegisterUser { get; set; }

	public string LastEditUser { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInFOSetting")]
	public bool? UserIsActiveInFOSetting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInFOSetting")]
	public bool UsrIsActiveInFOSetting
	{
		get
		{
			if (UserIsActiveInFOSetting.HasValue)
			{
				return UserIsActiveInFOSetting.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserAccessDailyChrtAllUsers")]
	public bool? UserAccessDailyChrtAllUsers { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessDailyChrtAllUsers")]
	public bool UsrAccessDailyChrtAllUsers
	{
		get
		{
			if (UserAccessDailyChrtAllUsers.HasValue)
			{
				return UserAccessDailyChrtAllUsers.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserAccessSaleChrtAllUsers")]
	public bool? UserAccessSaleChrtAllUsers { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessSaleChrtAllUsers")]
	public bool UsrAccessSaleChrtAllUsers
	{
		get
		{
			if (UserAccessSaleChrtAllUsers.HasValue)
			{
				return UserAccessSaleChrtAllUsers.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserMaxNumberCmpDraft")]
	public int? MaxNumberCmpDraft { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessOtherUsersCmpInfo")]
	public bool? AccessOtherUsersCmpInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessOtherUsersPrsInfo")]
	public bool? AccessOtherUsersPrsInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessOtherUsersPrjInfo")]
	public bool? AccessOtherUsersPrjInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessOtherUsersCnvsInfo")]
	public bool? AccessOtherUsersCnvsInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessPreOrderType")]
	public bool? AccessPreOrderType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessOrderOpr")]
	public bool? AccessOrderOpr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserAccessBuyOrderOpr")]
	public bool? AccessBuyOrderOpr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserStartDate")]
	public DateTime? StartDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserStartDate")]
	public string StartDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserExpireDate")]
	public DateTime? ExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserExpireDate")]
	public string ExpireDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserGroupId")]
	public int? UserGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserGroupId")]
	public string UserGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserExtensions")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserExtensions { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobDeActiveAccessToLocation")]
	public bool? MobDeActiveAccessToLocation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobDeActiveAccessToLocation")]
	public bool UsrMobDeActiveAccessToLocation
	{
		get
		{
			if (MobDeActiveAccessToLocation.HasValue)
			{
				return MobDeActiveAccessToLocation.GetValueOrDefault();
			}
			return false;
		}
	}

	public string LinkAccUserCode { get; set; }

	public string LinkAccUserIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserNickname")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Nickname { get; set; }

	public string FName_Lang { get; set; }

	public string LName_Lang { get; set; }

	public string Description_Lang { get; set; }

	public string Nickname_Lang { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string MobImeiCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInHRM")]
	public bool? UserIsActiveInHRM { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobHRMImeiCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string MobHRMImeiCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserActiveMobMovementTracking")]
	public bool? ActiveMobMovementTracking { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobMovementTrackingDistanceInterval")]
	public double? MobMovementTrackingDistanceInterval { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobMovementTrackingTimeInterval")]
	public int? MobMovementTrackingTimeInterval { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDefCmpPrjTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DefCmpPrjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobDeActiveScreenshot")]
	public bool? MobDeActiveScreenshot { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobCallerIdDeActive")]
	public bool? MobCallerIdDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobCallerIdDeActive")]
	public bool UserMobCallerIdDeActive
	{
		get
		{
			if (MobCallerIdDeActive.HasValue)
			{
				return MobCallerIdDeActive.GetValueOrDefault();
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "UserMobUserAppUseCnt")]
	public int? MobUserAppUseCnt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobHRMUserAppUseCnt")]
	public int? MobHRMUserAppUseCnt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserIsActiveInCIC")]
	public bool? UserIsActiveInCIC { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobCICUserAppUseCnt")]
	public int? MobCICUserAppUseCnt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserCallerIdDeActiveFromMobile")]
	public bool? CallerIdDeActiveFromMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserCallerIdDeActiveFromMobile")]
	public bool UserCallerIdDeActiveFromMobile
	{
		get
		{
			if (CallerIdDeActiveFromMobile.HasValue)
			{
				return CallerIdDeActiveFromMobile.GetValueOrDefault();
			}
			return false;
		}
	}

	public string DefCmpPrjTitle_Lang { get; set; }

	public string UserCIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserMobHRMLoginMode")]
	public int MobHRMLoginMode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginCheckLocationType")]
	public int UserLoginCheckLocationType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLoginCheckLocations")]
	public string UserLoginCheckLocations { get; set; }

	public string ActiveDirectoryUser { get; set; }

	public int? ShiftWorkingId { get; set; }

	public bool? ShowBtnEditAdmPassword { get; set; }

	public bool? CanEditAdmPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserDeActiveLoginWithoutShift")]
	public bool? DeActiveLoginWithoutShift { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserCallPreNumber")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CallPreNumber { get; set; }
}
