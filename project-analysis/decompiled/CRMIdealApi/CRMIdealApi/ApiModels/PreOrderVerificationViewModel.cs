namespace CRMIdealApi.ApiModels;

public class PreOrderVerificationViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int ApiPreOrderId { get; set; }

	public int ApiRollId { get; set; }

	public int? LanguageId { get; set; }
}
