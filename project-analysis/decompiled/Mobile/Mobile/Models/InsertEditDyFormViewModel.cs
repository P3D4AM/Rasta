namespace Mobile.Models;

public class InsertEditDyFormViewModel
{
	public int FormId { get; set; }

	public int MasterValueId { get; set; }

	public int? MasterValueDetailId { get; set; }

	public int? WorkflowStepId { get; set; }

	public int? WdSubFormId { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public long? DyFormNumber { get; set; }

	public string ValueDetails { get; set; }

	public string ValueDetails_Lang { get; set; }

	public int? LanguageId { get; set; }

	public bool SendIntMsgForMultiReferUsers { get; set; }

	public bool SendIntMsgForCheckerUsers { get; set; }

	public int? CenterId { get; set; }
}
