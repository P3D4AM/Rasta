namespace Mobile.Models;

public class MobspReturnPrdQuantityAndValidCount_Result
{
	public double? QuantityRemain { get; set; }

	public double QuantityIn { get; set; }

	public double QuantityOut { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public double? RemainCount { get; set; }

	public double NetPreOrderCount { get; set; }

	public double RemainCountAllWH { get; set; }

	public string RemainCurrAndAll { get; set; }

	public double ValidpordQuantity { get; set; }

	public double? TracingRemainCount { get; set; }

	public double? ValidpordQuantityTotal { get; set; }
}
