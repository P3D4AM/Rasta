namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCashViewModel : PublicParametersWithOutCenter
{
	public int ApiCashId { get; set; }

	public string ApiCashTitle { get; set; }

	public string ApiCashCode { get; set; }

	public string ApiCashLinkAccData { get; set; }
}
