namespace CRMIdealApi.ApiModels;

public class ApispSelectBankingAccounts_Result
{
	public int ApiBankingAccountId { get; set; }

	public int ApiBranchId { get; set; }

	public string ApiBranchName { get; set; }

	public int? ApiCompanyId { get; set; }

	public string ApiCompanyName { get; set; }

	public int ApiAccTypeId { get; set; }

	public string ApiAccType { get; set; }

	public string ApiAccountNumber { get; set; }

	public string ApiAccountType { get; set; }

	public string ApiAccountOwner { get; set; }

	public int? ApiCrmUserId { get; set; }

	public string ApiCrmUser { get; set; }

	public int? ApiBankId { get; set; }

	public string ApiBankName { get; set; }

	public string ApiAccountTitle { get; set; }

	public string ApiAccountShabaNumber { get; set; }

	public string ApiAccountCardNumber { get; set; }

	public string ApiAccountDesc { get; set; }

	public bool? ApiIsDefault { get; set; }

	public bool? ApiIsDefaultII { get; set; }

	public bool? ApiMobHRMVisible { get; set; }

	public string ApiAccountLinkAccData { get; set; }
}
