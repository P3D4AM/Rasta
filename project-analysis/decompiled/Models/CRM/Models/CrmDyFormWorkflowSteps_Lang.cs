using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormWorkflowSteps_LangMetadata))]
public class CrmDyFormWorkflowSteps_Lang
{
	public int CrmDyFormWorkflowStepLangID { get; set; }

	public int FormWorkflowStepId { get; set; }

	public string WorkflowStepTitle { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyFormWorkflowSteps CrmDyFormWorkflowSteps { get; set; }

	public virtual Languages Languages { get; set; }
}
