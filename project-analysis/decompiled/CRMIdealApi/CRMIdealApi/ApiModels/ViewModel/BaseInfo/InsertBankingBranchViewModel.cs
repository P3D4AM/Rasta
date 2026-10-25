namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertBankingBranchViewModel : PublicParametersWithOutCenter
{
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
