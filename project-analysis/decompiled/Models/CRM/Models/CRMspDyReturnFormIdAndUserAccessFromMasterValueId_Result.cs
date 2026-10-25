namespace CRM.Models;

public class CRMspDyReturnFormIdAndUserAccessFromMasterValueId_Result
{
	public int FormFieldMasterValueId { get; set; }

	public int FormId { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public bool? FormUserAccess { get; set; }
}
