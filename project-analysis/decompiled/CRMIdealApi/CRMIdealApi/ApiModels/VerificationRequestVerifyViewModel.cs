namespace CRMIdealApi.ApiModels;

public class VerificationRequestVerifyViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int ApiUserId { get; set; }

	public int ApiRollId { get; set; }

	public int ApiFPId { get; set; }

	public int? LanguageId { get; set; }

	public int ApiObjectId { get; set; }

	public int ApiVerificationWorkFlowId { get; set; }

	public int ApiVerificationRequestId { get; set; }

	public int ApiVerificationWorkFlowStepId { get; set; }

	public string ApiVerifyText { get; set; }

	public string ApiVerifyTextLang { get; set; }

	public string ApiMsgSubject { get; set; }

	public string ApiVerifiedMsgSubject { get; set; }

	public decimal ApiMaxDiscountPercent { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public int? VerificationRequestId { get; set; }

	public int? VerificationWorkFlowStepId { get; set; }

	public int? VerificationReqUserId { get; set; }

	public int? VerifyUserId { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string VerifyText { get; set; }

	public int? CancelVerificationRequestId { get; set; }

	public int? SendReqVerificationWorkflowId { get; set; }

	public int Mode { get; set; }

	public int Position { get; set; }

	public string TabName { get; set; }

	public bool SequenceObservation { get; set; }

	public string VerifyRequestText { get; set; }

	public string ReasonCancellation { get; set; }

	public int? CancellationStepId { get; set; }

	public int? MsgId { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }
}
