namespace CRM.Models;

public class ShygunDetailedAPIItemGroupInfoViewModel
{
	public string GroupNumber { get; set; }

	public string GroupName { get; set; }

	public string ParentGroupNumber { get; set; }

	public string ParentGroupName { get; set; }

	public string ParentGroupGuId { get; set; }

	public bool? IsMainGroup { get; set; }

	public string GroupGuid { get; set; }
}
