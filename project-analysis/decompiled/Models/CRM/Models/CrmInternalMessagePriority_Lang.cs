using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessagePriority_LangMetadata))]
public class CrmInternalMessagePriority_Lang
{
	public int CrmInternalMessagePriorityLangID { get; set; }

	public int InternalMessagePriorityID { get; set; }

	public int LanguageID { get; set; }

	public string InternalMessagePriority { get; set; }

	public virtual CrmInternalMessagePriority CrmInternalMessagePriority { get; set; }

	public virtual Languages Languages { get; set; }
}
