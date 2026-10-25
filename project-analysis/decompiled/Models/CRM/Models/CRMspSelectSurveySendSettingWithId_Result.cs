using System;

namespace CRM.Models;

public class CRMspSelectSurveySendSettingWithId_Result
{
	public int SurveySendSettingId { get; set; }

	public string surssTitle { get; set; }

	public bool? surssSmsSendByWeb { get; set; }

	public int? surssSmsProviderId { get; set; }

	public string surssSmsProvider { get; set; }

	public string surssSmsSendNumber { get; set; }

	public bool? surssSmsSendByGSM { get; set; }

	public string surssSmsSendGSMNmber { get; set; }

	public bool? surssSendByEmail { get; set; }

	public int? surssEmailSendUserInfoId { get; set; }

	public string surssEmailSendUserInfo { get; set; }

	public DateTime? surssSendStartDate { get; set; }

	public string surssSendStartDatePersian { get; set; }

	public DateTime? surssSendEndDate { get; set; }

	public string surssSendEndDatePersian { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
