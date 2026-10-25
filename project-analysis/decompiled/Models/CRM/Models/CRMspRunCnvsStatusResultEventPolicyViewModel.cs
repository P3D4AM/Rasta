namespace CRM.Models;

public class CRMspRunCnvsStatusResultEventPolicyViewModel
{
	public int? ConversationStatusResultEventPolicyId { get; set; }

	public int? EventPolicyTypeId { get; set; }

	public int? EventPolicyReceiverId { get; set; }

	public int? EventPolicySendTimeType { get; set; }

	public int? EventPolicySendTimeValue { get; set; }

	public bool? EventPolicyUserCheckBeforeSend { get; set; }

	public string EventPolicySubjectText { get; set; }

	public string EventPolicyShortText { get; set; }

	public string EventPolicyBigText { get; set; }

	public string PartName { get; set; }

	public string ActName { get; set; }

	public string ActTitle { get; set; }

	public string EventPolicyReceiverName { get; set; }

	public int? PrsId { get; set; }

	public string PersonName { get; set; }

	public int? UserId { get; set; }

	public string UserName { get; set; }

	public string Mobile { get; set; }

	public string Email { get; set; }

	public string MessageError { get; set; }
}
