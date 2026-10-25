using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmDyFormWorkflowSteps_LangMetadata
{
	[Key]
	public int CrmDyFormWorkflowStepLangID { get; set; }

	public int FormWorkflowStepId { get; set; }

	public string WorkflowStepTitle { get; set; }

	public int LanguageID { get; set; }
}
