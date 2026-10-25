using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmConversationStatusResultEventPolicyLanguageViewModel
{
	[Key]
	public int ConversationStatusResultEventPolicyId { get; set; }

	public int ConversationStatusGroupId { get; set; }

	public int ConversationStatusId { get; set; }

	public int ConversationStatusResultId { get; set; }

	public int EventPolicyTypeId { get; set; }

	public string EventPolicyType { get; set; }

	public int? EventPolicyReceiverId { get; set; }

	public string EventPolicyReceiver { get; set; }

	public string EventPolicyReceiverUsers { get; set; }

	public string EventPolicyReceiverPrsJobs { get; set; }

	public string EventPolicySetting { get; set; }

	public int? EventPolicySendTimeType { get; set; }

	public int? EventPolicySendTimeValue { get; set; }

	public int? EventPolicySendTimeValueII { get; set; }

	public bool? EventPolicyUserCheckBeforeSend { get; set; }

	public string EventPolicyShortDescription { get; set; }

	public string EventPolicyBigDescription { get; set; }

	public bool? DeActive { get; set; }

	public int Mode { get; set; }

	public string PartName { get; set; }

	public bool HasSetting { get; set; }

	public int Row { get; set; }

	public string ActName { get; set; }

	public string EventPolicySetting_Lang { get; set; }

	public string EventPolicyShortDescription_Lang { get; set; }

	public string EventPolicyBigDescription_Lang { get; set; }

	public string EventPolicyDescription_Lang { get; set; }
}
