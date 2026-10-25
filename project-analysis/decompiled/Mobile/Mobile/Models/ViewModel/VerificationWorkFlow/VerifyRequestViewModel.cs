namespace Mobile.Models.ViewModel.VerificationWorkFlow;

public class VerifyRequestViewModel
{
	public int VerificationWorkFlowId { get; set; }

	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int VerificationRequestId { get; set; }

	public int VerificationWorkFlowStepId { get; set; }

	public string VerifyText { get; set; }

	public string FormName { get; set; }

	public int? LanguageId { get; set; }
}
