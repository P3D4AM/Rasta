using System;

namespace CRM.Models;

public class CRMspSelectConversationStatusResultEventPolicyById_Result
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

	public bool? EventPolicySendTimeType { get; set; }

	public int? EventPolicySendTimeValue { get; set; }

	public bool? EventPolicyUserCheckBeforeSend { get; set; }

	public string EventPolicyShortDescription { get; set; }

	public string EventPolicyBigDescription { get; set; }

	public bool? DeActive { get; set; }

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

	public int? EventPolicySendTimeValueII { get; set; }
}
