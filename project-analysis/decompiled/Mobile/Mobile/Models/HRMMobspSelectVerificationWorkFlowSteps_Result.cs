namespace Mobile.Models;

public class HRMMobspSelectVerificationWorkFlowSteps_Result
{
	public int VerificationWorkFlowStepId { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public string VerificationWorkFlowStepTitle { get; set; }

	public int? VerifyUserId { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string VerifyText { get; set; }

	public string VerifyUser { get; set; }

	public string AlternateVerifyUser { get; set; }

	public int? OrderView { get; set; }
}
