namespace CRMIdealApi.ApiModels;

public class SelectBuyOrderItemsViewModel : PublicParameters
{
	public int? BuyOrderId { get; set; }

	public int? BuyOrderItemId { get; set; }
}
