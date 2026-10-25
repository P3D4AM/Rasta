namespace CRM.Models;

public class WSspCheckPreOrderItemHaveStockSupply_Result
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public int? pordIWHId { get; set; }

	public string pordIWrhsName { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string StockSupplyItemIds { get; set; }
}
