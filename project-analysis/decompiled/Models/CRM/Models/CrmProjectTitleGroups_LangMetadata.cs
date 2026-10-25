using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmProjectTitleGroups_LangMetadata
{
	[Key]
	public int CrmProjectTitleGroupsLangID { get; set; }

	public int ProjectTitleGroupId { get; set; }

	public int LanguageID { get; set; }

	public string ProjectTitleGroup { get; set; }

	public string ProjectTitleGroupDesc { get; set; }

	public virtual CrmProjectTitleGroups CrmProjectTitleGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
