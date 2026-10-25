namespace CRMIdealApi.ApiModels;

public class SelectBuyOrderViewModel : PublicParameters
{
	public int? BuyOrdId { get; set; }

	public long? BuyOrdNumber { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }
}
