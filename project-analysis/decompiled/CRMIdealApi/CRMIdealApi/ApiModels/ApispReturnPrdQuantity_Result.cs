namespace CRMIdealApi.ApiModels;

public class ApispReturnPrdQuantity_Result
{
	public double? ApiQuantityRemain { get; set; }

	public double? ApiQuantityIn { get; set; }

	public double? ApiQuantityOut { get; set; }

	public int? ApiPrdId { get; set; }

	public string ApiPrdName { get; set; }

	public double? ApiRemainCount { get; set; }

	public double? ApiNetPreOrderCount { get; set; }

	public double? ApiRemainCountAllWH { get; set; }

	public string ApiRemainCurrAndAll { get; set; }

	public double? ApiTracingRemainCount { get; set; }
}
