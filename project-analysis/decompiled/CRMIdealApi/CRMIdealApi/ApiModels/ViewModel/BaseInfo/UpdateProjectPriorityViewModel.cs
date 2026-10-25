namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateProjectPriorityViewModel : PublicParametersWithOutCenter
{
	public int ApiProjectPriorityId { get; set; }

	public string ApiPriority { get; set; }

	public string ApiColor { get; set; }

	public string ApiPriorityDesc { get; set; }
}
