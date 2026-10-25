namespace CRM.Models;

public class CRMspSelectInternalMessageConversationLastStatus_Result
{
	public string CompanyName { get; set; }

	public string prjTitle { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string Status { get; set; }

	public string cnvsUser { get; set; }

	public string cnvsReferUser { get; set; }

	public int? cnvsReferUserId { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsStatusId { get; set; }

	public int? cnvsTopicId { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public bool? prjTicketStop { get; set; }
}
