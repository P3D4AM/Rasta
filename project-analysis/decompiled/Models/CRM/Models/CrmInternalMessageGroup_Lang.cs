using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageGroup_LangMetadata))]
public class CrmInternalMessageGroup_Lang
{
	public int CrmInternalMessageGroupLangID { get; set; }

	public int InternalMessageGroupID { get; set; }

	public int LanguageID { get; set; }

	public string InternalMessageGroup { get; set; }

	public virtual CrmInternalMessageGroup CrmInternalMessageGroup { get; set; }

	public virtual Languages Languages { get; set; }
}
