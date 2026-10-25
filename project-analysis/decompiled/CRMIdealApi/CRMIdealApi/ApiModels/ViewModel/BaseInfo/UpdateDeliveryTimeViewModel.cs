namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateDeliveryTimeViewModel : PublicParametersWithOutCenter
{
	public int ApiDeliveryTimeId { get; set; }

	public string ApiDeliveryTime { get; set; }

	public int ApiOrderView { get; set; }
}
