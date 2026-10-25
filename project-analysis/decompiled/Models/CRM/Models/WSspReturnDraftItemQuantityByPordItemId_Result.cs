namespace CRM.Models;

public class WSspReturnDraftItemQuantityByPordItemId_Result
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public int? pordIWHId { get; set; }

	public double? DocItemQuantity { get; set; }

	public double RemainedQuantity { get; set; }
}
