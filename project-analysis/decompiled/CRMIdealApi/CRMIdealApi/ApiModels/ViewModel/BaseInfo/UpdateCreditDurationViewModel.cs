namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCreditDurationViewModel : PublicParametersWithOutCenter
{
	public int ApiCreditDurationId { get; set; }

	public string ApiCreditDuration { get; set; }

	public int? ApiCreditDurationHours { get; set; }

	public int? ApiOrderView { get; set; }
}
