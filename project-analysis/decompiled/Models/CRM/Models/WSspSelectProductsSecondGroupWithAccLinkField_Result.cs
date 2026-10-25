namespace CRM.Models;

public class WSspSelectProductsSecondGroupWithAccLinkField_Result
{
	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public int? SGLinkAccGroupId { get; set; }

	public string SGLinkAccGroupCode { get; set; }

	public string SGLinkAccGroupIdStr { get; set; }

	public string SGLinkAccGroupName { get; set; }

	public string SGLinkAccGroups { get; set; }
}
