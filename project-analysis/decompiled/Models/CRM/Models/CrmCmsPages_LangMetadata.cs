namespace CRM.Models;

public class CrmCmsPages_LangMetadata
{
	public int CrmCmsPageLangID { get; set; }

	public int PageId { get; set; }

	public int LanguageID { get; set; }

	public string PageName { get; set; }

	public string PageTitle { get; set; }

	public string PageHeader { get; set; }

	public string PageBody { get; set; }

	public string PageFooter { get; set; }
}
