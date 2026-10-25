namespace CRM.Models;

public class CRMspSelectLinkedUsersForLinkedType_Result
{
	public int ID { get; set; }

	public int LinkedTypeId { get; set; }

	public int CrmUserId { get; set; }

	public string CrmUser { get; set; }

	public int LinkedUserId { get; set; }

	public string LinkedUser { get; set; }

	public int? LinkerPart { get; set; }
}
