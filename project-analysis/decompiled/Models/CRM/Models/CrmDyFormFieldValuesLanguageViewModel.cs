using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmDyFormFieldValuesLanguageViewModel
{
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MsgErrorEnterRequireInformation")]
	public string ValueDetails { get; set; }

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

	public string ValueDetails_Lang { get; set; }

	public int? WdSubFormId { get; set; }

	public int? WorkflowStepId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmSendIntMsgForMultiReferUsers")]
	public bool SendIntMsgForMultiReferUsers { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFrmSendIntMsgForCheckerUsers")]
	public bool SendIntMsgForCheckerUsers { get; set; }

	public int? MasterValueDetailId { get; set; }

	public int? CurrWorkflowStepId { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

	public bool? CanSave { get; set; }

	public long? DyFormNumber { get; set; }

	public string CompanyName { get; set; }

	public int? TempDataId { get; set; }
}
