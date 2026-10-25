namespace CRMIdealApi.ApiModels;

public class SelectVerificationRequestDetailsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiVerificationRequestDetailId { get; set; }

	public int? ApiVerificationRequestId { get; set; }

	public int? ApiVerificationWorkFlowId { get; set; }

	public int? LanguageId { get; set; }
}
