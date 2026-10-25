namespace CRM.Models;

public class CRMspSelectUnLinkedCentersForLinkedType_Result
{
	public int? CenterID { get; set; }

	public int? ParentId { get; set; }

	public string CenterName { get; set; }

	public string ParentCenterName { get; set; }

	public int? IsLinkedCenter { get; set; }

	public int? OrderView { get; set; }

	public int? ChildrenCnt { get; set; }
}
