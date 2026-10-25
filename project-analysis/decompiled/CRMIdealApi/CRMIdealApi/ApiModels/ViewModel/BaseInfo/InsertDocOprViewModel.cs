namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertDocOprViewModel : PublicParametersWithOutCenter
{
	public string ApiName { get; set; }

	public int ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }
}
