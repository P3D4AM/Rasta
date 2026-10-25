namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateConversationStatusGroupViewModel : PublicParametersWithOutCenter
{
	public int ApiConversationStatusGroupId { get; set; }

	public string ApiConversationStatusGroup { get; set; }

	public string ApiConversationStatusGroupDesc { get; set; }

	public bool? ApiDeActive { get; set; }

	public int? ApiFOCnvsReferUserId { get; set; }

	public string ApiFOCnvsReferMultiUser { get; set; }

	public bool? ApiNoRegCnvsOlderStatus { get; set; }

	public string ApiConversationStatusGroupColor { get; set; }
}
