namespace CRM.Models;

public class CrmConversation_LangMetadata
{
	public int CrmConversationLangID { get; set; }

	public int ConversationID { get; set; }

	public int LanguageID { get; set; }

	public string cnvsSubject { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsReferDesc { get; set; }
}
