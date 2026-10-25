namespace CRMIdealApi.ApiModels;

public class SelectOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiOrderId { get; set; }

	public long? ApiOrdNumber { get; set; }

	public string FromOrdDate { get; set; }

	public string ToOrdDate { get; set; }

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
