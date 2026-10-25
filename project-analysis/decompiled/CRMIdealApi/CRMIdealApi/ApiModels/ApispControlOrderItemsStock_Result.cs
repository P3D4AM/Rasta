namespace CRMIdealApi.ApiModels;

public class ApispControlOrderItemsStock_Result
{
	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public double? ordIQuantity { get; set; }

	public double? RemainStockWithordIQuantity { get; set; }
}
