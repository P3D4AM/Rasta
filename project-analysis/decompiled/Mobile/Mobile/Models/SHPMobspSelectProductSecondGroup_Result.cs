namespace Mobile.Models;

public class SHPMobspSelectProductSecondGroup_Result
{
	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string FGName { get; set; }

	public string SGDescription { get; set; }

	public string SGNameEn { get; set; }

	public bool? SGInactiveInSale { get; set; }

	public bool? SGInactiveInBuy { get; set; }

	public int? SGOrderView { get; set; }

	public string SGSHPName { get; set; }
}
