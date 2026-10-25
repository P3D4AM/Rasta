using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyTitle_LangMetadata))]
public class CrmCompanyTitle_Lang
{
	public int CrmCompanyTitleLangID { get; set; }

	public int CompanyTitleID { get; set; }

	public int LanguageID { get; set; }

	public string CompanyTitle { get; set; }

	public virtual CrmCompanyTitle CrmCompanyTitle { get; set; }

	public virtual Languages Languages { get; set; }
}
