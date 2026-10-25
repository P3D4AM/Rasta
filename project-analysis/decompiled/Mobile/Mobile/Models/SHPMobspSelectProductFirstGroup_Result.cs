namespace Mobile.Models;

public class SHPMobspSelectProductFirstGroup_Result
{
	public int PrdFirstGroupID { get; set; }

	public string FGCode { get; set; }

	public string FGName { get; set; }

	public string FGDescription { get; set; }

	public string FGNameEn { get; set; }

	public bool? FGInactiveInSale { get; set; }

	public bool? FGInactiveInBuy { get; set; }

	public bool? PrdGroupMustExistInPreOrder { get; set; }

	public int? FGOrderView { get; set; }

	public string FGSHPName { get; set; }
}
