namespace CRM.Models;

public class CRMspSelectFODefaultCnvsStatusGroups_Result
{
	public int ConversationStatusGroupID { get; set; }

	public int? FOCnvsReferUserId { get; set; }

	public string FOCnvsReferUser { get; set; }

	public string FOCnvsReferMultiUser { get; set; }

	public string FOCnvsReferMultiUserName { get; set; }

	public int? FODefaultConversationStatusId { get; set; }

	public string FODefaultConversationStatus { get; set; }
}
