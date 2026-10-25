using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectVerificationWorkFlowSteps_Result
{
	public int ApiVerificationWorkFlowStepId { get; set; }

	public int ApiVerificationWorkFlowId { get; set; }

	public string ApiVerificationWorkFlow { get; set; }

	public string ApiVerificationWorkFlowStepTitle { get; set; }

	public int? ApiVerifyUserId { get; set; }

	public int? ApiAlternateVerifyUserId { get; set; }

	public string ApiVerifyText { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiVerifyUser { get; set; }

	public string ApiAlternateVerifyUser { get; set; }

	public int? ApiOrderView { get; set; }
}
