namespace CRM.Models;

public class WSspControlOrderItemsStock_Result
{
	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public double? ordIQuantity { get; set; }

	public double? RemainStockWithordIQuantity { get; set; }
}
