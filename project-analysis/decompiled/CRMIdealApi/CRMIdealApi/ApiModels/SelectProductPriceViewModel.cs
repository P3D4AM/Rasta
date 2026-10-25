namespace CRMIdealApi.ApiModels;

public class SelectProductPriceViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiPrdPriceId { get; set; }

	public int? ApiProductId { get; set; }

	public int? ApiPrdPriceGroupId { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }

	public int? LanguageId { get; set; }
}
