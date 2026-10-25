namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertVerificationWorkFlowViewModel : PublicParametersWithOutCenter
{
	public int ApiObjectType { get; set; }

	public string ApiVerificationWorkFlowTitle { get; set; }

	public string VerifyRequestText { get; set; }

	public bool ApiSequenceObservation { get; set; }

	public bool ApiIsActive { get; set; }
}
