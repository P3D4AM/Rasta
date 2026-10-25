using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageType_LangMetadata))]
public class CrmInternalMessageType_Lang
{
	public int CrmInternalMessageTypeLangID { get; set; }

	public int InternalMessageTypeID { get; set; }

	public int LanguageID { get; set; }

	public string MessageType { get; set; }

	public virtual CrmInternalMessageType CrmInternalMessageType { get; set; }

	public virtual Languages Languages { get; set; }
}
