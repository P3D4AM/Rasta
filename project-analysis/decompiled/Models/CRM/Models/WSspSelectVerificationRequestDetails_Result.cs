using System;

namespace CRM.Models;

public class WSspSelectVerificationRequestDetails_Result
{
	public int? VerificationRequestDetailId { get; set; }

	public int? VerificationRequestId { get; set; }

	public int? ObjectId { get; set; }

	public int? ObjectType { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public int? VerificationWorkFlowStepId { get; set; }

	public string VerificationWorkFlowStepTitle { get; set; }

	public int? VerifyUserId { get; set; }

	public string VerifyUser { get; set; }

	public DateTime? VerifyDateTime { get; set; }

	public string VerifyText { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? AlternateVerifyUserId { get; set; }

	public string AlternateVerifyUser { get; set; }

	public int? OrderView { get; set; }

	public int? WorkFlowStepVerifyUserId { get; set; }

	public string WorkFlowStepVerifyUser { get; set; }

	public string VerifyText_Lang { get; set; }

	public int? VerifyReqResultId { get; set; }

	public string VerifyDateTimePersian { get; set; }
}
