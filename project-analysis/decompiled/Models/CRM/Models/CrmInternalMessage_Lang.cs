using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessage_LangMetadata))]
public class CrmInternalMessage_Lang
{
	public int CrmInternalMessageLangID { get; set; }

	public int InternalMessageID { get; set; }

	public int LanguageID { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public virtual CrmInternalMessage CrmInternalMessage { get; set; }

	public virtual Languages Languages { get; set; }
}
