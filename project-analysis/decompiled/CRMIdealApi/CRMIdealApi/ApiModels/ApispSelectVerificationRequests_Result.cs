using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectVerificationRequests_Result
{
	public int ApiVerificationRequestId { get; set; }

	public int ApiVerificationWorkFlowId { get; set; }

	public string ApiVerificationWorkFlowTitle { get; set; }

	public bool? ApiSequenceObservation { get; set; }

	public DateTime ApiVerificationReqDateTime { get; set; }

	public int VerificationReqUserId { get; set; }

	public string ApiVerificationReqUser { get; set; }

	public string ApiVerificationReqText { get; set; }

	public int ApiVerificationReqObjectId { get; set; }

	public int ApiVerificationReqObjectType { get; set; }

	public DateTime? ApiVerificationReqExpiredDateTime { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiFirstRegisterUser { get; set; }
}
