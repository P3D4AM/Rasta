using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmMenuModel_LangMetadata
{
	[Key]
	public int MenuModelLangID { get; set; }

	public int LanguageID { get; set; }

	public int MenuModelID { get; set; }

	public string Title { get; set; }
}
