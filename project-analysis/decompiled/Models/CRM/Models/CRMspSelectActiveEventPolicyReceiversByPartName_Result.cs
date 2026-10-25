namespace CRM.Models;

public class CRMspSelectActiveEventPolicyReceiversByPartName_Result
{
	public int EventPolicyReceiverId { get; set; }

	public string PartName { get; set; }

	public string ReceiverName { get; set; }

	public int? OrderView { get; set; }

	public bool? DeActive { get; set; }
}
