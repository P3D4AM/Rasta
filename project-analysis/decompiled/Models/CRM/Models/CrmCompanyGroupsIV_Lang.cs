using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsIV_LangMetadata))]
public class CrmCompanyGroupsIV_Lang
{
	public int CrmCompanyGroupsIVLangID { get; set; }

	public int CompanyGroupIVID { get; set; }

	public int LanguageID { get; set; }

	public string GroupIVName { get; set; }

	public string GroupIVDesc { get; set; }

	public virtual CrmCompanyGroupsIV CrmCompanyGroupsIV { get; set; }

	public virtual Languages Languages { get; set; }
}
