namespace CRMIdealApi.ApiModels;

public class DeleteProductViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiProductId { get; set; }

	public int? LanguageId { get; set; }
}
