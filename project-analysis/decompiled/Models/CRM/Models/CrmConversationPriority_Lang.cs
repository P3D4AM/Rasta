using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationPriority_LangMetadata))]
public class CrmConversationPriority_Lang
{
	public int CrmConversationPriorityLangID { get; set; }

	public int ConversationPriorityID { get; set; }

	public int LanguageID { get; set; }

	public string Priority { get; set; }

	public string PriorityDesc { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority { get; set; }

	public virtual Languages Languages { get; set; }
}
