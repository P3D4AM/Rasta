namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateDocOprViewModel : PublicParametersWithOutCenter
{
	public int ApiDocOprId { get; set; }

	public string ApiName { get; set; }

	public int? ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }
}
