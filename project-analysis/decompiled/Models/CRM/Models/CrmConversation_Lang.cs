using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversation_LangMetadata))]
public class CrmConversation_Lang
{
	public int CrmConversationLangID { get; set; }

	public int ConversationID { get; set; }

	public int LanguageID { get; set; }

	public string cnvsSubject { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsReferDesc { get; set; }

	public virtual CrmConversation CrmConversation { get; set; }

	public virtual Languages Languages { get; set; }
}
