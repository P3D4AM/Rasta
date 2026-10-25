namespace CRM.Models;

public class CRMspSelectFundGroupsTree_Result
{
	public int? FundGroupId { get; set; }

	public string GroupName { get; set; }

	public int? ParentId { get; set; }

	public int? Level { get; set; }

	public string Path { get; set; }
}
