namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateOrderCommissionPayTypeViewModel : PublicParametersWithOutCenter
{
	public int ApiOrderCommissionPayTypeId { get; set; }

	public string ApiCommPayTypeTitle { get; set; }

	public string ApiCommPayTypeDescription { get; set; }

	public int? ApiOrderView { get; set; }
}
