using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmDyFormWorkflows_LangMetadata
{
	[Key]
	public int CrmDyFormWorkflowLangID { get; set; }

	public int FormWorkflowId { get; set; }

	public string WorkflowTitle { get; set; }

	public int LanguageID { get; set; }
}
