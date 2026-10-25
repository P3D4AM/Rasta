namespace Mobile.Models;

public class MobspReturnPrdQuantityByIds_Result
{
	public double? QuantityRemain { get; set; }

	public double? QuantityIn { get; set; }

	public double? QuantityOut { get; set; }

	public int? PrdId { get; set; }

	public string PrdName { get; set; }

	public double? RemainCount { get; set; }

	public double? NetPreOrderCount { get; set; }

	public double? RemainCountAllWH { get; set; }

	public string RemainCurrAndAll { get; set; }

	public double? TracingRemainCount { get; set; }
}
