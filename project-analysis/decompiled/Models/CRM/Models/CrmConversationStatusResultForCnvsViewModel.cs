namespace CRM.Models;

public class CrmConversationStatusResultForCnvsViewModel
{
	public int ConversationStatusResultId { get; set; }

	public string ResultTitle { get; set; }

	public bool? OTPSendActive { get; set; }

	public string OTPJson { get; set; }

	public string StatusResultUsedUserIds { get; set; }

	public string StatusResultUsedUserNames { get; set; }

	public bool? CnvsDoingTimeNotNull { get; set; }

	public bool? CnvsRemindDateNotNull { get; set; }

	public bool? CnvsRemindDateForAllarmNotNull { get; set; }

	public int? CnvsTopicId { get; set; }

	public int? CnvsReferUserId { get; set; }

	public bool? CnvsReferUserNoChange { get; set; }

	public int? CnvsRemindDay { get; set; }

	public string CnvsRemindDate { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsReferDesc { get; set; }

	public bool? IsDefault { get; set; }

	public bool? CnvsNoNeedRemindDateAlert { get; set; }

	public string ResultTitle_Lang { get; set; }

	public string CnvsDesc_Lang { get; set; }

	public string CnvsReferDesc_Lang { get; set; }
}
