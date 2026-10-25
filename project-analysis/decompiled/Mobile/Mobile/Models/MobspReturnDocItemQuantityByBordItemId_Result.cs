namespace Mobile.Models;

public class MobspReturnDocItemQuantityByBordItemId_Result
{
	public int BuyOrderItemId { get; set; }

	public int BuyOrderId { get; set; }

	public int bordIPrdId { get; set; }

	public double? bordIQuantity { get; set; }

	public int? bordIWHId { get; set; }

	public double? DocItemQuantity { get; set; }

	public double RemainedQuantity { get; set; }
}
