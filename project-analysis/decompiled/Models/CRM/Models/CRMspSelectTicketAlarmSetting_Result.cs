using System;

namespace CRM.Models;

public class CRMspSelectTicketAlarmSetting_Result
{
	public int TicketAlarmSettingID { get; set; }

	public int tasTypeId { get; set; }

	public bool? tasIsActive { get; set; }

	public string tasProjectTitleGroup { get; set; }

	public int? tasDelayAlarmDay { get; set; }

	public string tasDelayAlarmTime { get; set; }

	public int? tasBusyAllMsgCnt { get; set; }

	public int? tasBusyUserRepCnt { get; set; }

	public int? tasUnhappyMinVote { get; set; }

	public string tasReceiverIds { get; set; }

	public string tasReceivers { get; set; }

	public string tasMessage { get; set; }

	public bool? tasSendSMS { get; set; }

	public int? tasSendSMSProviderId { get; set; }

	public string tasSendSMSProvider { get; set; }

	public string tasSendSMSNumber { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
