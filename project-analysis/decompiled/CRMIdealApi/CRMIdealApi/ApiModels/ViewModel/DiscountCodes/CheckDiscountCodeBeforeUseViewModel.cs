namespace CRMIdealApi.ApiModels.ViewModel.DiscountCodes;

public class CheckDiscountCodeBeforeUseViewModel : PublicParameters
{
	public int ApiCompanyId { get; set; }

	public int? ApiOrderId { get; set; }

	public int? ApiPreOrderId { get; set; }

	public string ApiDisCode { get; set; }
}
