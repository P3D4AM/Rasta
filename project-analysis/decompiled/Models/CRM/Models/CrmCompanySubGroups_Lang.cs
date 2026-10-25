using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanySubGroups_LangMetadata))]
public class CrmCompanySubGroups_Lang
{
	public int CrmCompanySubGroupsLangID { get; set; }

	public int CompanySubGroupID { get; set; }

	public int LanguageID { get; set; }

	public string SubGroupName { get; set; }

	public string SubGroupDesc { get; set; }

	public virtual CrmCompanySubGroups CrmCompanySubGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
