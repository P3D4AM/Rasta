using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsPages_LangMetadata))]
public class CrmCmsPages_Lang
{
	public int CrmCmsPageLangID { get; set; }

	public int PageId { get; set; }

	public int LanguageID { get; set; }

	public string PageName { get; set; }

	public string PageTitle { get; set; }

	public string PageHeader { get; set; }

	public string PageBody { get; set; }

	public string PageFooter { get; set; }

	public string PageSeoTitle { get; set; }

	public string PageSeoDescription { get; set; }

	public string PageSeoKeywords { get; set; }

	public string PageSeoFaq { get; set; }

	public string PageSeoAuthor { get; set; }

	public string PageSeoCopyright { get; set; }

	public virtual CrmCmsPages CrmCmsPages { get; set; }

	public virtual Languages Languages { get; set; }
}
