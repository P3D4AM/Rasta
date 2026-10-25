namespace CRMIdealApi.ApiModels;

public class SearchProductViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiPrdFGId { get; set; }

	public int? ApiPrdSGId { get; set; }

	public string ApiPrdBarcode { get; set; }

	public int? ApiPrdId { get; set; }

	public string ApiVal { get; set; }

	public int? ApiShowMode { get; set; }

	public int? LanguageId { get; set; }
}
