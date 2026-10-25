namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateConversationPriorityViewModel : PublicParametersWithOutCenter
{
	public int ApiConversationPriorityId { get; set; }

	public string ApiPriority { get; set; }

	public string ApiPriorityDesc { get; set; }

	public string ApiColor { get; set; }

	public int? ApiOrderView { get; set; }
}
