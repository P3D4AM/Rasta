namespace CRM.Models;

public class WSspProductsTreeByLevel_Result
{
	public int KeyId { get; set; }

	public string Name { get; set; }

	public int? OrderView { get; set; }

	public int Level { get; set; }

	public bool? HasChildren { get; set; }

	public int? ParentId { get; set; }

	public string Code { get; set; }

	public int PageNumber { get; set; }

	public int? ChildrenCount { get; set; }
}
