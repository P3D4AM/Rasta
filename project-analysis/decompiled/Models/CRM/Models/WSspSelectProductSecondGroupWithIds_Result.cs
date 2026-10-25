namespace CRM.Models;

public class WSspSelectProductSecondGroupWithIds_Result
{
	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string FirstGroup { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string SGDescription { get; set; }

	public string SGNameEn { get; set; }

	public bool? SGInactiveInSale { get; set; }

	public bool? SGInactiveInBuy { get; set; }

	public int? SGLinkAccGroupId { get; set; }

	public string SGLinkAccGroupCode { get; set; }

	public string SGLinkAccGroupIdStr { get; set; }

	public int? SGOrderView { get; set; }

	public bool? SGSHPIsActive { get; set; }

	public string SGLinkAccGroupName { get; set; }

	public string SGLinkAccGroups { get; set; }
}
