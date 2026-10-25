namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertVerificationWorkFlowStepViewModel : PublicParametersWithOutCenter
{
	public int ApiVerificationWorkFlowId { get; set; }

	public string ApiVerificationWorkFlowStepTitle { get; set; }

	public int ApiVerifyUserId { get; set; }

	public int? ApAlternateVerifyUserId { get; set; }

	public int? ApiOrderView { get; set; }

	public bool ApiVerificationWorkFlowStepCanBack { get; set; }

	public bool ApiVerificationWorkFlowStepObjCanEdit { get; set; }

	public string ApiVerifyText { get; set; }
}
