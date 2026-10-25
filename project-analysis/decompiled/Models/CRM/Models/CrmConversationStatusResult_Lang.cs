using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusResult_LangMetadata))]
public class CrmConversationStatusResult_Lang
{
	public int CrmConversationStatusResultLangID { get; set; }

	public int ConversationStatusResultId { get; set; }

	public int LanguageID { get; set; }

	public string ResultTitle { get; set; }

	public string ResultDesc { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsReferDesc { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult { get; set; }

	public virtual Languages Languages { get; set; }
}
