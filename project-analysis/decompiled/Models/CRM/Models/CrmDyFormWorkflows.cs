using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormWorkflowsMetadata))]
public class CrmDyFormWorkflows
{
	public int FormWorkflowId { get; set; }

	public string WorkflowTitle { get; set; }

	public int DyFormId { get; set; }

	public bool? IsActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? WorkflowPanelShowType { get; set; }

	public bool? WorkflowPanelHide { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual CrmDyForms CrmDyForms1 { get; set; }

	public virtual ICollection<CrmDyFormWorkflows_Lang> CrmDyFormWorkflows_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmDyFormWorkflows()
	{
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyFormWorkflows_Lang = (ICollection<CrmDyFormWorkflows_Lang>)new HashSet<CrmDyFormWorkflows_Lang>();
		CrmDyFormWorkflowSteps = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
	}
}
