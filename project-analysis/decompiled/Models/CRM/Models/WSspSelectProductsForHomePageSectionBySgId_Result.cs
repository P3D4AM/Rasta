namespace CRM.Models;

public class WSspSelectProductsForHomePageSectionBySgId_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdGroup { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public bool? PrdInactiveInSale { get; set; }

	public bool? PrdInactiveInBuy { get; set; }
}
