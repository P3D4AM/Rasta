namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertCreditDurationViewModel : PublicParametersWithOutCenter
{
	public string ApiCreditDuration { get; set; }

	public int? ApiCreditDurationHours { get; set; }

	public int? ApiOrderView { get; set; }
}
