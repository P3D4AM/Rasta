namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateBankingBranchViewModel : PublicParametersWithOutCenter
{
	public int ApiBankingBranchId { get; set; }

	public int? ApiBankId { get; set; }

	public string ApiBankCode { get; set; }

	public string ApiBranchName { get; set; }

	public string ApiBranchCode { get; set; }

	public string ApiBranchAddress { get; set; }

	public string ApiBranchTel { get; set; }

	public string ApiBranchTelII { get; set; }

	public string ApiBranchLinkAccData { get; set; }

	public string ApiBranchDesc { get; set; }
}
