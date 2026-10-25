namespace CRMIdealApi.ApiModels;

public class DeleteCompanyMoneyBagViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int MoneyBagId { get; set; }

	public int? LanguageId { get; set; }
}
