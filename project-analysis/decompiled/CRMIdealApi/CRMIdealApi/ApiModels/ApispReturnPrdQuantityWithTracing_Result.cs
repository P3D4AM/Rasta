namespace CRMIdealApi.ApiModels;

public class ApispReturnPrdQuantityWithTracing_Result
{
	public int? ApiProductId { get; set; }

	public string ApiProduct { get; set; }

	public int? ApiWarehouseId { get; set; }

	public string ApiWarehouse { get; set; }

	public int? ApiCenterId { get; set; }

	public string ApiCenter { get; set; }

	public double? ApiQuantityIn { get; set; }

	public double? ApiQuantityOut { get; set; }

	public double? ApiQuantityRemain { get; set; }

	public double? ApiNetPreOrderCount { get; set; }

	public double? ApiTracingRemainCount { get; set; }
}
