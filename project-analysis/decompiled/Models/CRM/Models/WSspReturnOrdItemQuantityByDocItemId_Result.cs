namespace CRM.Models;

public class WSspReturnOrdItemQuantityByDocItemId_Result
{
	public int DocItemID { get; set; }

	public int DocId { get; set; }

	public int PrdId { get; set; }

	public double? Quantity { get; set; }

	public int? WHId { get; set; }

	public double? SumOrdIQuantity { get; set; }

	public double? DocItemQuantity { get; set; }

	public double? SumPordIQuantity { get; set; }

	public double? PordDocItemQuantity { get; set; }
}
