using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectPriority_LangMetadata))]
public class CrmProjectPriority_Lang
{
	public int CrmProjectPriorityLangID { get; set; }

	public int ProjectPriorityID { get; set; }

	public int LanguageID { get; set; }

	public string Priority { get; set; }

	public string PriorityDesc { get; set; }

	public virtual CrmProjectPriority CrmProjectPriority { get; set; }

	public virtual Languages Languages { get; set; }
}
