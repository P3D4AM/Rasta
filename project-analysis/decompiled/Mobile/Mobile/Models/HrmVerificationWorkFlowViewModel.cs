namespace Mobile.Models;

public class HrmVerificationWorkFlowViewModel
{
	public int VerificationWorkFlowId { get; set; }

	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int VerificationRequestId { get; set; }

	public int VerificationWorkFlowStepId { get; set; }

	public int VerificationReqUserId { get; set; }

	public int AlternateVerifyUserId { get; set; }

	public string MessageText { get; set; }

	public string FormName { get; set; }

	public int? CancellationStepId { get; set; }

	public string ReasonCancellation { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }

	public string VerifyText { get; set; }
}
