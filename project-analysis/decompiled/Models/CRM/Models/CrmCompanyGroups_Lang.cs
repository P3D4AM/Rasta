using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroups_LangMetadata))]
public class CrmCompanyGroups_Lang
{
	public int CrmCompanyGroupsLangID { get; set; }

	public int CompanyGroupID { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }

	public string GroupDesc { get; set; }

	public virtual CrmCompanyGroups CrmCompanyGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
