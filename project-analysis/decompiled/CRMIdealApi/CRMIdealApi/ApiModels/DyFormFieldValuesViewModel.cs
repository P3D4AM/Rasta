namespace CRMIdealApi.ApiModels;

public class DyFormFieldValuesViewModel : PublicParameters
{
	public int RollId { get; set; }

	public string ValueDetails { get; set; }

	public string ValueDetails_Lang { get; set; }

	public int FormId { get; set; }

	public int Mode { get; set; }

	public int Position { get; set; }

	public string PartTitle { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public int MasterValueId { get; set; }

	public bool? CountFile { get; set; }

	public int? WdSubFormId { get; set; }

	public int? WorkflowStepId { get; set; }

	public bool SendIntMsgForMultiReferUsers { get; set; }

	public bool SendIntMsgForCheckerUsers { get; set; }

	public int? MasterValueDetailId { get; set; }

	public int? CurrWorkflowStepId { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

	public bool? CanSave { get; set; }

	public long? DyFormNumber { get; set; }

	public string CompanyName { get; set; }
}
