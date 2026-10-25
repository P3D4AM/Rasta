namespace CRMIdealApi.ApiModels;

public class SelectConversationViewModel : PublicParameters
{
	public int ApiCompanyId { get; set; }

	public int ApiProjectId { get; set; }

	public int ApiConversationId { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }
}
