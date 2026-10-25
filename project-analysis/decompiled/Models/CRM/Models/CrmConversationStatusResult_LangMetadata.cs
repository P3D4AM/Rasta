using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmConversationStatusResult_LangMetadata
{
	[Key]
	public int CrmConversationStatusResultLangID { get; set; }

	public int ConversationStatusResultId { get; set; }

	public int LanguageID { get; set; }

	public string ResultTitle { get; set; }

	public string ResultDesc { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsReferDesc { get; set; }
}
