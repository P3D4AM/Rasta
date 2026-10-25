namespace CRM.Models;

public class WSspControlBuyOrderItemsSoldStock_Result
{
	public int? BuyOrderItemID { get; set; }

	public int? bordIPrdId { get; set; }

	public string PrdName { get; set; }

	public double? bordIQuantity { get; set; }

	public double? bordIFCR { get; set; }

	public double? bordIFCRI { get; set; }

	public int? bordIWHId { get; set; }

	public string bordITracing { get; set; }

	public string bordILinkAccWHIdStr { get; set; }

	public double? bordIQuantityTotal { get; set; }

	public double? RemainCountAllWH { get; set; }

	public double? QuantityRemain { get; set; }

	public double? SoldOrdQuantity { get; set; }

	public double? TracingRemainCount { get; set; }
}
