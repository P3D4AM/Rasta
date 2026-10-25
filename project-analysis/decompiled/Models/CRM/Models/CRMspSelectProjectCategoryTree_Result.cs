namespace CRM.Models;

public class CRMspSelectProjectCategoryTree_Result
{
	public int ProjectCategoryId { get; set; }

	public int ParentId { get; set; }

	public string ParentHistory { get; set; }

	public string CategoryName { get; set; }

	public int? Depth { get; set; }

	public bool? IsLeaf { get; set; }

	public string CategoryFullName { get; set; }
}
