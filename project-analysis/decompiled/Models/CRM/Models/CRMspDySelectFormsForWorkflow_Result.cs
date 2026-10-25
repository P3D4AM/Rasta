namespace CRM.Models;

public class CRMspDySelectFormsForWorkflow_Result
{
	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public int? ParentFormId { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

	public string CrmSysPartTitle { get; set; }

	public string CrmSysPart { get; set; }

	public string CrmSysPartType { get; set; }

	public string FOSysPartTitle { get; set; }

	public string FOSysPart { get; set; }

	public string FOSysPartType { get; set; }

	public string ParentForm { get; set; }

	public int? WorkflowId { get; set; }

	public string Workflow { get; set; }

	public string CrmSysPartShow { get; set; }

	public string FOSysPartShow { get; set; }
}
