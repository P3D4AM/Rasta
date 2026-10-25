namespace CRMIdealApi.ApiModels;

public class SelectPreOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiPreOrderId { get; set; }

	public long? ApiPordNumber { get; set; }

	public string FromPordDate { get; set; }

	public string ToPordDate { get; set; }

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
