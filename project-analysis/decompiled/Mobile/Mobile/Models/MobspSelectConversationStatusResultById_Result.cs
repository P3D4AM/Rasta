using System;

namespace Mobile.Models;

public class MobspSelectConversationStatusResultById_Result
{
	public int ConversationStatusResultId { get; set; }

	public int ConversationStatusGroupId { get; set; }

	public string ConversationStatusGroup { get; set; }

	public int ConversationStatusId { get; set; }

	public string ConversationStatus { get; set; }

	public string ResultTitle { get; set; }

	public string ResultDesc { get; set; }

	public bool? EventPolicyActive { get; set; }

	public string EventPolicyActTitles { get; set; }

	public string EventPolicyJson { get; set; }

	public bool? OTPSendActive { get; set; }

	public bool? IssuePordActive { get; set; }

	public bool? IssueOrdActive { get; set; }

	public bool? IssueDyFormActive { get; set; }

	public bool? NeedDyFormChecked { get; set; }

	public int? NeedDyFormCheckedFormId { get; set; }

	public string NeedDyFormCheckedForm { get; set; }

	public bool? PrjFinished { get; set; }

	public bool? NoCnvsDup { get; set; }

	public string StatusResultUsedUserIds { get; set; }

	public string StatusResultUsedUserNames { get; set; }

	public string StatusResultUsedUsersJson { get; set; }

	public int? DoingTimeEndDeadlineMin { get; set; }

	public int? DoingTimeEndCnvsStatusId { get; set; }

	public string DoingTimeEndCnvsStatus { get; set; }

	public string DoingTimeEndCnvsStatusGroup { get; set; }

	public int? DoingTimeEndCnvsStatusResultId { get; set; }

	public string DoingTimeEndCnvsStatusResult { get; set; }

	public string DoingTimeEndCallerCnvsStatusResultIds { get; set; }

	public int? CnvsCountLimit { get; set; }

	public int? CnvsDoingTimeLimit { get; set; }

	public bool? CnvsDoingTimeNotNull { get; set; }

	public bool? CnvsRemindDateNotNull { get; set; }

	public bool? CnvsRemindDateForAllarmNotNull { get; set; }

	public int? CnvsTopicId { get; set; }

	public string CnvsTopic { get; set; }

	public int? CnvsReferUserId { get; set; }

	public string CnvsReferUser { get; set; }

	public bool? CnvsReferUserNoChange { get; set; }

	public int? CnvsRemindDay { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsReferDesc { get; set; }

	public bool? UpdateCmpGroupActive { get; set; }

	public string UpdateCmpGroupActiveJson { get; set; }

	public string UpdateCmpGroupActiveJsonByName { get; set; }

	public bool? IsDefault { get; set; }

	public bool? DeActive { get; set; }

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

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public bool? AddPrjActive { get; set; }

	public bool? CnvsNoNeedRemindDateAlert { get; set; }
}
