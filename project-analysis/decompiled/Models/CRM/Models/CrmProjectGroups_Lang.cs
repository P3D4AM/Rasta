using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGroups_LangMetadata))]
public class CrmProjectGroups_Lang
{
	public int ProjectGroupsLangID { get; set; }

	public int ProjectGroupID { get; set; }

	public int LanguageID { get; set; }

	public string ProjectGroup { get; set; }

	public virtual CrmProjectGroups CrmProjectGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
