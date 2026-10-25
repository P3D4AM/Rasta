namespace Mobile.Models.ViewModel.VerificationWorkFlow;

public class VerificationRequestsLanguageViewModel
{
	public int Mode { get; set; }

	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public int? VerificationRequestId { get; set; }

	public int? VerificationWorkFlowStepId { get; set; }

	public int? VerificationReqUserId { get; set; }

	public int? VerifyUserId { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string VerifyText { get; set; }

	public int? CancelVerificationRequestId { get; set; }

	public int? SendReqVerificationWorkflowId { get; set; }

	public bool SequenceObservation { get; set; }

	public int? LanguageId { get; set; }

	public int? CancellationStepId { get; set; }

	public string ReasonCancellation { get; set; }

	public int? CenterId { get; set; }
}
