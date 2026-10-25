namespace CRM.Models;

public class CRMspSelectCentersTreeFullInfo_Result
{
	public int CenterID { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public bool? CenterInActive { get; set; }

	public int? ParentId { get; set; }

	public string ParentCenterName { get; set; }

	public string CenterCode { get; set; }

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
