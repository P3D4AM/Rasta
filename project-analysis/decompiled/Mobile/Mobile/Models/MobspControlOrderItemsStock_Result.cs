namespace Mobile.Models;

public class MobspControlOrderItemsStock_Result
{
	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public double? ordIQuantity { get; set; }

	public double? RemainStockWithordIQuantity { get; set; }
}
