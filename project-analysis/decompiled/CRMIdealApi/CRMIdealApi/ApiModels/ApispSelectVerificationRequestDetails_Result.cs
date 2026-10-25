using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectVerificationRequestDetails_Result
{
	public int? ApiVerificationRequestDetailId { get; set; }

	public int? ApiVerificationRequestId { get; set; }

	public int? ApiObjectId { get; set; }

	public int? ApiObjectType { get; set; }

	public int? ApiVerificationWorkFlowId { get; set; }

	public string ApiVerificationWorkFlowTitle { get; set; }

	public int? ApiVerificationWorkFlowStepId { get; set; }

	public string ApiVerificationWorkFlowStepTitle { get; set; }

	public int? ApiVerifyUserId { get; set; }

	public string ApiVerifyUser { get; set; }

	public int? ApiWorkFlowStepVerifyUserId { get; set; }

	public string ApiWorkFlowStepVerifyUser { get; set; }

	public int? ApiAlternateVerifyUserId { get; set; }

	public string ApiAlternateVerifyUser { get; set; }

	public DateTime? ApiVerifyDateTime { get; set; }

	public string ApiVerifyText { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiUserId { get; set; }

	public DateTime? ApiRegisterDate { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public int? ApiOrderView { get; set; }
}
