namespace CRM.Models;

public class nTreeItemViewModel
{
	public string ParentId { get; set; }

	public string KeyId { get; set; }

	public string KeyName { get; set; }

	public int? ChildsCnt { get; set; }
}
