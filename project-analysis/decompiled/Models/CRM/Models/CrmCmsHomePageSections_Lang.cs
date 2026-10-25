using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsHomePageSections_LangMetadata))]
public class CrmCmsHomePageSections_Lang
{
	public int CrmCmsHomePageSectionLangID { get; set; }

	public int HomePageSectionId { get; set; }

	public int LanguageID { get; set; }

	public string SectionTitle { get; set; }

	public string SectionHeader { get; set; }

	public string SectionSeoTitle { get; set; }

	public string SectionSeoDescription { get; set; }

	public string SectionSeoAuthor { get; set; }

	public string SectionSeoCopyright { get; set; }

	public string SectionSeoKeywords { get; set; }

	public string SectionSeoFAQ { get; set; }

	public virtual CrmCmsHomePageSections CrmCmsHomePageSections { get; set; }

	public virtual Languages Languages { get; set; }
}
