using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectVerificationWorkFlows_Result
{
	public int ApiVerificationWorkFlowId { get; set; }

	public string ApiVerificationWorkFlowTitle { get; set; }

	public bool ApiSequenceObservation { get; set; }

	public bool ApiIsActive { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiObjectType { get; set; }

	public string ApiVerifyRequestText { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiFirstRegisterUser { get; set; }
}
