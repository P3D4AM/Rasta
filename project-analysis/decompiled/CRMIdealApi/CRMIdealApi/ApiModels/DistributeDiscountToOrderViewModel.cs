namespace CRMIdealApi.ApiModels;

public class DistributeDiscountToOrderViewModel : PublicParameters
{
	public string ApiDisCode { get; set; }

	public int ApiOrderId { get; set; }

	public string ApiOrderItemIds { get; set; }

	public bool? ApiAddToDiscount { get; set; }
}
