namespace CRMIdealApi.ApiModels;

public class SelectProductViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiProductId { get; set; }

	public int? ApiPrdGroupId { get; set; }

	public string ApiPrdCode { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }

	public int? LanguageId { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }
}
