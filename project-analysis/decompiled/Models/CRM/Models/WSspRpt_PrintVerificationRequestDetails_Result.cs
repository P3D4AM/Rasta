using System;

namespace CRM.Models;

public class WSspRpt_PrintVerificationRequestDetails_Result
{
	public int VerificationRequestDetailId { get; set; }

	public int VerificationRequestId { get; set; }

	public int ObjectId { get; set; }

	public int ObjectType { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlow { get; set; }

	public int VerificationWorkFlowStepId { get; set; }

	public string VerificationWorkFlowStep { get; set; }

	public int? VerifyUserId { get; set; }

	public string VerifyUser { get; set; }

	public DateTime? VerifyDateTime { get; set; }

	public string VerifyDatePersian { get; set; }

	public string VerifyText { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? VerificationReqDateTime { get; set; }

	public string VerificationReqDatePersian { get; set; }

	public int? VerificationReqUserId { get; set; }

	public string VerificationReqUser { get; set; }

	public string VerificationReqText { get; set; }

	public bool? VerificationReqExpired { get; set; }

	public DateTime? VerificationReqExpiredDateTime { get; set; }

	public string VerificationReqExpiredDatePersian { get; set; }

	public byte[] VerifyUserSignature { get; set; }

	public string VerifyUserSignatureStr { get; set; }
}
