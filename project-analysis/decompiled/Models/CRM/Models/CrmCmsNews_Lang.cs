using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsNews_LangMetadata))]
public class CrmCmsNews_Lang
{
	public int CrmCmsNewsLangID { get; set; }

	public int NewsId { get; set; }

	public int LanguageID { get; set; }

	public string HeadLine { get; set; }

	public string Title { get; set; }

	public string NewsSummery { get; set; }

	public string NewsBody { get; set; }

	public string NewsSeoTitle { get; set; }

	public string NewsSeoDescription { get; set; }

	public string NewsSeoKeywords { get; set; }

	public string NewsSeoFaq { get; set; }

	public string NewsSeoAuthor { get; set; }

	public string NewsSeoCopyright { get; set; }

	public virtual CrmCmsNews CrmCmsNews { get; set; }

	public virtual Languages Languages { get; set; }
}
