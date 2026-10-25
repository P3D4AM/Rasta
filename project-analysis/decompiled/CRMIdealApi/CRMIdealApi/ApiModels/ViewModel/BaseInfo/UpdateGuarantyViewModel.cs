namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateGuarantyViewModel : PublicParametersWithOutCenter
{
	public int ApiGuarantyId { get; set; }

	public string ApiGuaranty { get; set; }

	public int? ApiOrderView { get; set; }
}
