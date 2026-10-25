using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsMulti_LangMetadata))]
public class CrmCompanyGroupsMulti_Lang
{
	public int CrmCompanyGroupsMultiLangID { get; set; }

	public int CompanyGroupsMultiID { get; set; }

	public int LanguageID { get; set; }

	public string CompanyGroupsMultiName { get; set; }

	public string CompanyGroupsMultiDesc { get; set; }

	public virtual CrmCompanyGroupsMulti CrmCompanyGroupsMulti { get; set; }

	public virtual Languages Languages { get; set; }
}
