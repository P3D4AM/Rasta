using System;

namespace CRM.Models;

public class CRMfnSelectPreOrderVerifiers_Result
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

	public int? LanguageID { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public DateTime? CoordinateLastDate { get; set; }

	public string CoordinateLastDatePersian { get; set; }

	public bool? MobAppBaseInfoNeedUpdate { get; set; }

	public bool? UserIsActiveInFOSetting { get; set; }

	public bool? UserAccessDailyChrtAllUsers { get; set; }

	public bool? UserAccessSaleChrtAllUsers { get; set; }

	public string MobAppBaseInfoNeedUpdateDetail { get; set; }
}
