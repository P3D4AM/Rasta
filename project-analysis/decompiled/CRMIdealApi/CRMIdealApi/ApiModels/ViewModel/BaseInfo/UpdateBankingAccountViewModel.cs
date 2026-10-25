namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateBankingAccountViewModel : PublicParametersWithOutCenter
{
	public int ApiBankingAccountId { get; set; }

	public int? ApiBankId { get; set; }

	public string ApiBankCode { get; set; }

	public int? ApiBranchId { get; set; }

	public string ApiBranchCode { get; set; }

	public int? ApiAccountTypeId { get; set; }

	public string ApiAccountNumber { get; set; }

	public string ApiAccountType { get; set; }

	public string ApiAccountOwner { get; set; }

	public int? ApiCrmUserId { get; set; }

	public string ApiAccountTitle { get; set; }

	public string ApiAccountShabaNumber { get; set; }

	public string ApiAccountCardNumber { get; set; }

	public string ApiAccountDesc { get; set; }

	public bool? ApiIsDefault { get; set; }

	public bool? ApiIsDefaultII { get; set; }

	public bool? ApiMobHRMVisible { get; set; }

	public string ApiAccountLinkAccData { get; set; }
}
