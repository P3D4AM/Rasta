namespace Mobile.Models;

public class MobspReturnOrderItemQuantityByPordItemId_Result
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public int? pordIWHId { get; set; }

	public double? OrdItemQuantity { get; set; }

	public double RemainedQuantity { get; set; }
}
