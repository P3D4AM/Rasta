namespace CRMIdealApi.ApiModels;

public class SelectVerificationWorkFlowWithObjectTypeViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiObjectType { get; set; }

	public int? LanguageId { get; set; }
}
