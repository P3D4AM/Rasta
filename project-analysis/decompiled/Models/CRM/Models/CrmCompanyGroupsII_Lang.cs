using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsII_LangMetadata))]
public class CrmCompanyGroupsII_Lang
{
	public int CrmCompanyGroupsIILangID { get; set; }

	public int CompanyGroupIIID { get; set; }

	public int LanguageID { get; set; }

	public string GroupIIName { get; set; }

	public string GroupIIDesc { get; set; }

	public virtual CrmCompanyGroupsII CrmCompanyGroupsII { get; set; }

	public virtual Languages Languages { get; set; }
}
