namespace CRMIdealApi.ApiModels;

public class ReturnCompanyPersonIdViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiCmpNumber { get; set; }

	public string ApiCmpCode { get; set; }

	public string ApiPrsMobile { get; set; }

	public string ApiPrsEmail { get; set; }

	public string ApiPrsNationalCode { get; set; }

	public int? LanguageId { get; set; }
}
