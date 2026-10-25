namespace CRM.Models;

public class WSVerificationRequestsLanguageViewModel
{
	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int Mode { get; set; }

	public int Position { get; set; }

	public string FormName { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public int? VerificationRequestId { get; set; }

	public int? VerificationWorkFlowStepId { get; set; }

	public int? VerificationReqUserId { get; set; }

	public int? VerifyUserId { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string VerifyText { get; set; }

	public int? CancelVerificationRequestId { get; set; }

	public int? SendReqVerificationWorkflowId { get; set; }

	public string TabName { get; set; }

	public bool SequenceObservation { get; set; }

	public string VerifyRequestText { get; set; }

	public string ReasonCancellation { get; set; }

	public int? CancellationStepId { get; set; }

	public int? MsgId { get; set; }

	public string VerifyText_Lang { get; set; }

	public string VerifyRequestText_Lang { get; set; }

	public string ReasonCancellation_Lang { get; set; }
}
