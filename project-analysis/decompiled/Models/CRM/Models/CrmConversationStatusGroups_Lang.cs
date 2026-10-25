using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusGroups_LangMetadata))]
public class CrmConversationStatusGroups_Lang
{
	public int CrmConversationStatusGroupsLangID { get; set; }

	public int ConversationStatusGroupID { get; set; }

	public int LanguageID { get; set; }

	public string ConversationStatusGroup { get; set; }

	public string ConversationStatusGroupDesc { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
