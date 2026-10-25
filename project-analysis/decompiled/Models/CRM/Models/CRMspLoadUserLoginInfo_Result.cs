using System;

namespace CRM.Models;

public class CRMspLoadUserLoginInfo_Result
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

	public DateTime? ExpireDate { get; set; }

	public string ExpireDatePersian { get; set; }

	public string UserExtensions { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public string DefCmpPrjTitle_Lang { get; set; }

	public decimal? SumUserMoneyBagAmount { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }

	public int? MobHRMLoginMode { get; set; }

	public int? UserLoginCheckLocationType { get; set; }

	public string UserLoginCheckLocations { get; set; }

	public int? ShiftWorkingId { get; set; }

	public bool? DeActiveLoginWithoutShift { get; set; }

	public string CallPreNumber { get; set; }

	public string UserRollName { get; set; }
}
