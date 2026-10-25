namespace CRMIdealApi.ApiModels;

public class CompanyMultiSelectViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int CenterId { get; set; }

	public string CenterCode { get; set; }

	public string ApiFieldName { get; set; }

	public string ApiFieldValue { get; set; }

	public int? ApiUserId { get; set; }

	public int? LanguageId { get; set; }
}
