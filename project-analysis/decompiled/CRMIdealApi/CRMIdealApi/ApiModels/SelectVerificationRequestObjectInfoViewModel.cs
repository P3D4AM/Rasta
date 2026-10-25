namespace CRMIdealApi.ApiModels;

public class SelectVerificationRequestObjectInfoViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }

	public int ApiObjectId { get; set; }

	public int ApiObjectType { get; set; }

	public int? LanguageId { get; set; }
}
