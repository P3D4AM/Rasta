using System;

namespace Mobile.Models;

public class MobspDySelectCompanyMasterValues_Result
{
	public int FormFieldMasterValueId { get; set; }

	public int FormId { get; set; }

	public string FormName { get; set; }

	public int? CrmSysPartId { get; set; }

	public string CrmSysPart { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsChecked { get; set; }

	public int? CheckerUserId { get; set; }

	public DateTime? CheckedDate { get; set; }

	public string CheckedDatePersian { get; set; }

	public int? WorkflowId { get; set; }

	public int? WorkflowStepId { get; set; }

	public long? DyFormNumber { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
