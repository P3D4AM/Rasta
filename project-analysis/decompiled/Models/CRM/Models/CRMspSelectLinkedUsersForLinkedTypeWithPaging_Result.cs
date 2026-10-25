namespace CRM.Models;

public class CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result
{
	public int ID { get; set; }

	public int LinkedTypeId { get; set; }

	public int CrmUserId { get; set; }

	public string CrmUser { get; set; }

	public int LinkedUserId { get; set; }

	public string LinkedUserLName { get; set; }

	public string LinkedUser { get; set; }

	public int? LinkerPart { get; set; }

	public bool? IsLinked { get; set; }

	public bool? IsActive { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public string UserCIds { get; set; }

	public int? UserCId { get; set; }

	public int? PositionId { get; set; }

	public int? RollId { get; set; }

	public string LinkedUserAndActive { get; set; }
}
