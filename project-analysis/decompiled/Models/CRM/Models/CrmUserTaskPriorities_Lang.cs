using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserTaskPriorities_LangMetadata))]
public class CrmUserTaskPriorities_Lang
{
	public int CrmUserTaskPrioritiesLangID { get; set; }

	public int UserTaskPriorityId { get; set; }

	public int LanguageID { get; set; }

	public string Priority { get; set; }

	public string PriorityDesc { get; set; }

	public virtual CrmUserTaskPriorities CrmUserTaskPriorities { get; set; }

	public virtual Languages Languages { get; set; }
}
