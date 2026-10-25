namespace CRMIdealApi.ApiModels;

public class SelectCompanyViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiCmpNumber { get; set; }

	public string ApiCmpCode { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }

	public int? LanguageId { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }
}
