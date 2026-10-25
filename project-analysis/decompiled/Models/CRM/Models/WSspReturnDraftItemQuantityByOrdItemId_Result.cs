namespace CRM.Models;

public class WSspReturnDraftItemQuantityByOrdItemId_Result
{
	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public int? ordIWHId { get; set; }

	public double? DocItemQuantity { get; set; }

	public double RemainedQuantity { get; set; }
}
