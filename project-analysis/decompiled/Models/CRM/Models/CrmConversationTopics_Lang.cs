using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationTopics_LangMetadata))]
public class CrmConversationTopics_Lang
{
	public int CrmConversationTopicsLangID { get; set; }

	public int ConversationTopicsID { get; set; }

	public int LanguageID { get; set; }

	public string Topic { get; set; }

	public string TopicDesc { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics { get; set; }

	public virtual Languages Languages { get; set; }
}
