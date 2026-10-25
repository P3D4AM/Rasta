namespace CRM.Models;

public class WSspControlOrderItemsSoldStock_Result
{
	public int? OrderItemID { get; set; }

	public int? ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public double? ordIQuantity { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public int? ordIWHId { get; set; }

	public string ordITracing { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public double? RemainCountAllWH { get; set; }

	public double? QuantityRemain { get; set; }

	public double? SoldOrdQuantity { get; set; }

	public double? TracingRemainCount { get; set; }
}
