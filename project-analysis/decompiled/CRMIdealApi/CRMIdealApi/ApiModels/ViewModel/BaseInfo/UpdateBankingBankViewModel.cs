namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateBankingBankViewModel : PublicParametersWithOutCenter
{
	public int ApiBankingBankId { get; set; }

	public string ApiBankName { get; set; }

	public string ApiCode { get; set; }

	public string ApiBankDesc { get; set; }

	public string ApiBankLinkAccData { get; set; }
}
