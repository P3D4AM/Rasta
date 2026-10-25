namespace CRM.Models;

public class CrmConversationStatusResultEventPolicyJsonViewModel
{
	public int? ResultEventPolicyId { get; set; }

	public int? EventPolicyTypeId { get; set; }

	public int? EventPolicyReceiverId { get; set; }

	public bool? DeActive { get; set; }

	public string EventPolicyType { get; set; }

	public string EventPolicyReceiver { get; set; }
}
