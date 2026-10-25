using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectTitleGroups_LangMetadata))]
public class CrmProjectTitleGroups_Lang
{
	public int CrmProjectTitleGroupsLangID { get; set; }

	public int ProjectTitleGroupId { get; set; }

	public int LanguageID { get; set; }

	public string ProjectTitleGroup { get; set; }

	public string ProjectTitleGroupDesc { get; set; }

	public string ProjectTitleGroupAgreementDesc { get; set; }

	public string ProjectTitleGroupSubjectDefaultContext { get; set; }

	public virtual CrmProjectTitleGroups CrmProjectTitleGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
