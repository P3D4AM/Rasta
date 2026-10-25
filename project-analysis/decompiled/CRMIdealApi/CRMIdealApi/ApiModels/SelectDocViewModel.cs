namespace CRMIdealApi.ApiModels;

public class SelectDocViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiDocId { get; set; }

	public int? ApiDocNumber { get; set; }

	public int? ApiDocOprId { get; set; }

	public string FromDocDate { get; set; }

	public string ToDocDate { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }
}
