namespace CRM.Models;

public class WSspCheckDuplicateStockSupplyItemTracing_Result
{
	public int StockSupplyItemId { get; set; }

	public int StockSupplyId { get; set; }

	public long? stsupNumber { get; set; }

	public int stsupIPrdId { get; set; }

	public string PrdName { get; set; }
}
