using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormWorkflows_LangMetadata))]
public class CrmDyFormWorkflows_Lang
{
	public int CrmDyFormWorkflowLangID { get; set; }

	public int FormWorkflowId { get; set; }

	public string WorkflowTitle { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyFormWorkflows CrmDyFormWorkflows { get; set; }

	public virtual Languages Languages { get; set; }
}
