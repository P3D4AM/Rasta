namespace CRM.Models;

public class CRMspSelectUnLinkedUserPositionsForLinkedType_Result
{
	public int? PositionId { get; set; }

	public int? ParentId { get; set; }

	public string PositionName { get; set; }

	public string PositionCode { get; set; }

	public string PositionNameWithCode { get; set; }

	public int? IsLinkedUserPosition { get; set; }

	public int? OrderView { get; set; }
}
