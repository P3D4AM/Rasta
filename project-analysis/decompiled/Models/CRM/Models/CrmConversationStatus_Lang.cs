using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatus_LangMetadata))]
public class CrmConversationStatus_Lang
{
	public int CrmConversationStatusLangID { get; set; }

	public int ConversationStatusID { get; set; }

	public int LanguageID { get; set; }

	public string Status { get; set; }

	public string StatusDesc { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual Languages Languages { get; set; }
}
