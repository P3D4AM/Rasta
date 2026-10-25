using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmKnowledgeTankPriority_LangMetadata))]
public class CrmKnowledgeTankPriority_Lang
{
	public int CrmKnowledgeTankPriorityLangID { get; set; }

	public int KnowledgeTankPriorityId { get; set; }

	public int LanguageID { get; set; }

	public string KnowledgeTankPriorityTitle { get; set; }

	public string KnowledgeTankPriorityDesc { get; set; }

	public virtual CrmKnowledgeTankPriority CrmKnowledgeTankPriority { get; set; }

	public virtual Languages Languages { get; set; }
}
