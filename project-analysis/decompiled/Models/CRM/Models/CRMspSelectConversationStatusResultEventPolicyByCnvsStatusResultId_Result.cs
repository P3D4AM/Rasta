namespace CRM.Models;

public class CRMspSelectConversationStatusResultEventPolicyByCnvsStatusResultId_Result
{
	public int ConversationStatusResultEventPolicyId { get; set; }

	public int ConversationStatusGroupId { get; set; }

	public string ConversationStatusGroup { get; set; }

	public int ConversationStatusId { get; set; }

	public string ConversationStatus { get; set; }

	public int ConversationStatusResultId { get; set; }

	public string ConversationStatusResult { get; set; }

	public int EventPolicyTypeId { get; set; }

	public string EventPolicyTypePartName { get; set; }

	public string EventPolicyTypeActName { get; set; }

	public string EventPolicyTypeActTitle { get; set; }

	public string EventPolicyTypeJsonSetting { get; set; }

	public int? EventPolicyReceiverId { get; set; }

	public string EventPolicyReceiver { get; set; }

	public string EventPolicySetting { get; set; }

	public int? EventPolicySendTimeType { get; set; }

	public int? EventPolicySendTimeValue { get; set; }

	public bool? EventPolicyUserCheckBeforeSend { get; set; }

	public string EventPolicyShortDescription { get; set; }

	public string EventPolicyBigDescription { get; set; }

	public bool? DeActive { get; set; }

	public string ConversationStatusResultEventPolicyLang { get; set; }

	public int? EventPolicySendTimeValueII { get; set; }
}
