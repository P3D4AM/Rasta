namespace CRM.Models;

public class CRMspSelectCentersTree_Result
{
	public int CenterID { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public bool? CenterInActive { get; set; }

	public int? ParentId { get; set; }

	public string ParentCenterName { get; set; }

	public string CenterCode { get; set; }

	public int? ChildrenCnt { get; set; }
}
