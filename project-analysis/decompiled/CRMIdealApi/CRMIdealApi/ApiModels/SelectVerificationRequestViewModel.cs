namespace CRMIdealApi.ApiModels;

public class SelectVerificationRequestViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiObjectType { get; set; }

	public int? ApiVerificationRequestId { get; set; }

	public int? ApiObjectId { get; set; }

	public long? ApiObjectNumber { get; set; }

	public int? ApiDyFormId { get; set; }

	public int? LanguageId { get; set; }
}
