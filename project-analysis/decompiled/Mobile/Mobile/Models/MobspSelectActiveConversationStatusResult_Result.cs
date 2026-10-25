namespace Mobile.Models;

public class MobspSelectActiveConversationStatusResult_Result
{
	public int? ConversationStatusResultId { get; set; }

	public int? ConversationStatusGroupId { get; set; }

	public string ConversationStatusGroup { get; set; }

	public int? ConversationStatusId { get; set; }

	public string ConversationStatus { get; set; }

	public string ResultTitle { get; set; }

	public string ResultDesc { get; set; }

	public bool? EventPolicyActive { get; set; }

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

	public bool? IsDefault { get; set; }

	public bool? DeActive { get; set; }

	public int? OrderView { get; set; }

	public bool? CnvsNoNeedRemindDateAlert { get; set; }
}
