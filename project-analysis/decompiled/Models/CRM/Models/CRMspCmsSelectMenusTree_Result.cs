namespace CRM.Models;

public class CRMspCmsSelectMenusTree_Result
{
	public int MenuId { get; set; }

	public string MenuTitle { get; set; }

	public int? ParentId { get; set; }

	public string ParentTitle { get; set; }
}
