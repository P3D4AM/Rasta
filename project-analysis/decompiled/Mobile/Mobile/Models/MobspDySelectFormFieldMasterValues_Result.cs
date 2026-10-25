using System;

namespace Mobile.Models;

public class MobspDySelectFormFieldMasterValues_Result
{
	public int FormFieldMasterValueId { get; set; }

	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public bool? IsDeleted { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public bool? IsChecked { get; set; }

	public int? CheckerUserId { get; set; }

	public DateTime? CheckedDate { get; set; }

	public string CheckedDatePersian { get; set; }

	public string CheckerUser { get; set; }

	public int? WorkflowId { get; set; }

	public string Workflow { get; set; }

	public int? WorkflowStepId { get; set; }

	public string WorkflowStep { get; set; }

	public long? DyFormNumber { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? DyFormVerificationWorkFlowId { get; set; }

	public bool? IsFixed { get; set; }

	public string EditAfterFixInfoJs { get; set; }

	public int? CId { get; set; }

	public string CenterName { get; set; }
}
