using System;

namespace CRMIdealApi.ApiModels;

public class InsertUserViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public string ApiFName { get; set; }

	public string ApiLName { get; set; }

	public string ApiPersCode { get; set; }

	public string ApiUserName { get; set; }

	public string ApiPassword { get; set; }

	public bool? ApiIsActive { get; set; }

	public string ApiDescription { get; set; }

	public string ApiIPAddress { get; set; }

	public string ApiTel { get; set; }

	public string ApiTelDesc { get; set; }

	public int? ApiPositionId { get; set; }

	public int? ApiSignatureId { get; set; }

	public int? ApiDepartmentId { get; set; }

	public int? ApiResponsibleUserId { get; set; }

	public string ApiComputerName { get; set; }

	public bool? ApiCallreIdDeActive { get; set; }

	public string ApiCallreIdDeActiveLines { get; set; }

	public bool? ApiDisableInternalMessageAllarmVoice { get; set; }

	public bool? ApiDisableReceiveCNVSInfoAllarm { get; set; }

	public string ApiEmailAttachFileLocation { get; set; }

	public string ApiUserCIPatternFormulaPopUp { get; set; }

	public bool? ApiUseClientNameForNetworking { get; set; }

	public bool? ApiAllowCopyOtherLanguage { get; set; }

	public bool? ApiUserIsActiveInWinApp { get; set; }

	public bool? ApiUserIsActiveInWebApp { get; set; }

	public bool? ApiUserIsActiveInMobApp { get; set; }

	public string ApiCoordinateLatitude { get; set; }

	public string ApiCoordinateLongitude { get; set; }

	public DateTime? ApiCoordinateLastDate { get; set; }

	public bool? ApiUserIsActiveInFOSetting { get; set; }

	public bool? ApiUserAccessDailyChrtAllUsers { get; set; }

	public bool? ApiUserAccessSaleChrtAllUsers { get; set; }

	public int? ApiMaxNumberCmpDraft { get; set; }

	public string ApiMobile { get; set; }

	public string ApiMobileII { get; set; }

	public string ApiAddress { get; set; }

	public string ApiFatherName { get; set; }

	public string ApiNationalCode { get; set; }

	public string ApiIdentityNumber { get; set; }

	public string ApiInsuranceCode { get; set; }

	public DateTime? ApiStartDate { get; set; }

	public DateTime? ApiExpireDate { get; set; }

	public int? ApiUserGroupId { get; set; }

	public string ApiUserExtensions { get; set; }

	public bool? ApiMobDeActiveAccessToLocation { get; set; }

	public string ApiNickname { get; set; }

	public bool? ApiDeActiveSmartTimeAttendance { get; set; }

	public string ApiMobImeiCode { get; set; }

	public bool? ApiUserIsActiveInHRM { get; set; }

	public string ApiMobHRMImeiCode { get; set; }

	public bool? ApiAccessAllLanguage { get; set; }

	public bool? ApiAccessOtherUsersCmpInfo { get; set; }

	public bool? ApiAccessOtherUsersPrsInfo { get; set; }

	public bool? ApiAccessOtherUsersPrjInfo { get; set; }

	public bool? ApiAccessOtherUsersCnvsInfo { get; set; }

	public string ApiRollName { get; set; }

	public int? ApiRollId { get; set; }

	public int? LanguageId { get; set; }
}
