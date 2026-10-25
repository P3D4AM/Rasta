using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsIII_LangMetadata))]
public class CrmCompanyGroupsIII_Lang
{
	public int CrmCompanyGroupsIIILangID { get; set; }

	public int CompanyGroupIIIID { get; set; }

	public int LanguageID { get; set; }

	public string GroupIIIName { get; set; }

	public string GroupIIIDesc { get; set; }

	public virtual CrmCompanyGroupsIII CrmCompanyGroupsIII { get; set; }

	public virtual Languages Languages { get; set; }
}
