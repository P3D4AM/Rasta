using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsNews_LangMetadata
{
	[Key]
	public int CrmCmsNewsLangID { get; set; }

	public int NewsId { get; set; }

	public int LanguageID { get; set; }

	public string HeadLine { get; set; }

	public string Title { get; set; }

	public string NewsSummery { get; set; }

	public string NewsBody { get; set; }
}
