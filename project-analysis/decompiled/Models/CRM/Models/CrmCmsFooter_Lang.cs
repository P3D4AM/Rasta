using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsFooter_LangMetadata))]
public class CrmCmsFooter_Lang
{
	public int CrmCmsFooterLangID { get; set; }

	public int FooterId { get; set; }

	public int LanguageID { get; set; }

	public string FooterBody { get; set; }

	public string FooterTitle { get; set; }

	public virtual CrmCmsFooter CrmCmsFooter { get; set; }

	public virtual Languages Languages { get; set; }
}
