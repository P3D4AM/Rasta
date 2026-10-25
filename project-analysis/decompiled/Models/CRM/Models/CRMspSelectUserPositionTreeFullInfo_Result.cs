namespace CRM.Models;

public class CRMspSelectUserPositionTreeFullInfo_Result
{
	public int PositionId { get; set; }

	public int ParentId { get; set; }

	public string PositionName { get; set; }

	public string PositionCode { get; set; }

	public string PositionNameWithCode { get; set; }

	public string ParentName { get; set; }

	public int? ChildrenCnt { get; set; }

	public int? AllChildrenCnt { get; set; }

	public string AllChildrenIds { get; set; }

	public string AllChildrenNames { get; set; }

	public string AllChildrenIds_OrderByDesc { get; set; }

	public string AllChildrenNames_OrderByDesc { get; set; }

	public int? AllParentCnt { get; set; }

	public string AllParentIds { get; set; }

	public string AllParentNames { get; set; }

	public string AllParentIds_OrderByDesc { get; set; }

	public string AllParentNames_OrderByDesc { get; set; }
}
