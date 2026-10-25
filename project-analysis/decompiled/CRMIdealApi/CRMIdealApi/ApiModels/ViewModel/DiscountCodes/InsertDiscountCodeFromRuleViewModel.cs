namespace CRMIdealApi.ApiModels.ViewModel.DiscountCodes;

public class InsertDiscountCodeFromRuleViewModel : PublicParameters
{
	public int ApiCompanyId { get; set; }

	public int ApiRuleId { get; set; }
}
