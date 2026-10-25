using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmPersonGroups_LangMetadata))]
public class CrmPersonGroups_Lang
{
	public int CrmPersonGroupsLangID { get; set; }

	public int PersonGroupID { get; set; }

	public int LanguageID { get; set; }

	public string PersonGroup { get; set; }

	public virtual CrmPersonGroups CrmPersonGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
