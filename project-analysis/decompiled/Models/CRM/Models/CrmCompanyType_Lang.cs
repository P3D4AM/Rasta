using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyType_LangMetadata))]
public class CrmCompanyType_Lang
{
	public int CrmCompanyTypeLangID { get; set; }

	public int CompanyTypeID { get; set; }

	public int LanguageID { get; set; }

	public string CompanyTypeName { get; set; }

	public virtual CrmCompanyType CrmCompanyType { get; set; }

	public virtual Languages Languages { get; set; }
}
