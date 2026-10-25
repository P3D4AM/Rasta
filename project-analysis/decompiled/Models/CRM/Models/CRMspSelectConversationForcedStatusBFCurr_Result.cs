namespace CRM.Models;

public class CRMspSelectConversationForcedStatusBFCurr_Result
{
	public int ConversationStatusId { get; set; }

	public short? StatusOrder { get; set; }

	public string Status { get; set; }

	public int? ProgressPercent { get; set; }

	public int? GroupId { get; set; }

	public bool? EventPolicyIsActive { get; set; }
}
