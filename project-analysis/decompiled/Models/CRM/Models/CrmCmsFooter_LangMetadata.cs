using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsFooter_LangMetadata
{
	[Key]
	public int CrmCmsFooterLangID { get; set; }

	public int FooterId { get; set; }

	public int LanguageID { get; set; }

	public string FooterBody { get; set; }
}
