namespace CRMIdealApi.ApiModels;

public class DeleteMasterValueViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int MasterValueId { get; set; }

	public int? LanguageId { get; set; }

	public int? UserId { get; set; }
}
