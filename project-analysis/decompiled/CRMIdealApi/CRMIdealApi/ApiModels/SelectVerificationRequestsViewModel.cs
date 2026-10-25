using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class SelectVerificationRequestsViewModel
{
	public ApispSelectVerificationRequests_Result VerificationRequest { get; set; }

	public List<ApispSelectVerificationRequestDetails_Result> VerificationRequestDetails { get; set; }
}
