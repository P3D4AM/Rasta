using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyPresentation_LangMetadata))]
public class CrmCompanyPresentation_Lang
{
	public int CrmCompanyPresentationLangID { get; set; }

	public int CompanyPresentationID { get; set; }

	public int LanguageID { get; set; }

	public string Presentation { get; set; }

	public virtual CrmCompanyPresentation CrmCompanyPresentation { get; set; }

	public virtual Languages Languages { get; set; }
}
