namespace CRMIdealApi.ApiModels;

public class SearchCompanySmartViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }

	public string ApiVal { get; set; }

	public int? ApiSearchType { get; set; }

	public string ApiSearchConditionMode { get; set; }

	public int? LanguageId { get; set; }
}
