namespace Mobile.Models;

public class VerificationWorkFlowViewModel
{
	public int VerificationWorkFlowId { get; set; }

	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int VerificationRequestId { get; set; }

	public int VerificationWorkFlowStepId { get; set; }

	public int VerificationReqUserId { get; set; }

	public int AlternateVerifyUserId { get; set; }

	public string MessageText { get; set; }

	public string MessageText_Lang { get; set; }

	public string FormName { get; set; }

	public int? LanguageId { get; set; }

	public int? MsgId { get; set; }

	public int MsgTypeId { get; set; }

	public int? CancellationStepId { get; set; }

	public string ReasonCancellation { get; set; }

	public string VerifyText { get; set; }

	public int? CenterId { get; set; }
}
