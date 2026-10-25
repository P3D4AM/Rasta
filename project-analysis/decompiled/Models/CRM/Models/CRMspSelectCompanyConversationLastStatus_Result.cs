namespace CRM.Models;

public class CRMspSelectCompanyConversationLastStatus_Result
{
	public string Status { get; set; }

	public string cnvsUser { get; set; }

	public string cnvsReferUser { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string CompanyName { get; set; }

	public int? cnvsCompanyId { get; set; }

	public string prjTitle { get; set; }

	public string ProjectTitle { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public int? cnvsProjectId { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public bool? prjTicketStop { get; set; }

	public int? cnvsPersonId { get; set; }

	public string cnvsPerson { get; set; }
}
