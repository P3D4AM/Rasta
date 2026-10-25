namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertConversationPriorityViewModel : PublicParametersWithOutCenter
{
	public string ApiPriority { get; set; }

	public string ApiPriorityDesc { get; set; }

	public string ApiColor { get; set; }

	public int? ApiOrderView { get; set; }
}
