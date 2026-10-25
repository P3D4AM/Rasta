namespace CRMIdealApi.ApiModels;

public class DistributeDiscountToPreOrderViewModel : PublicParameters
{
	public int ApiPreOrderId { get; set; }

	public string ApiPreOrderItemIds { get; set; }

	public bool? ApiAddToDiscount { get; set; }

	public string ApiDisCode { get; set; }
}
