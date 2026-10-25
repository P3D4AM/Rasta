namespace CRMIdealApi.ApiModels;

public class SelectUserViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiUserId { get; set; }

	public string ApiUserName { get; set; }

	public int? LanguageId { get; set; }
}
