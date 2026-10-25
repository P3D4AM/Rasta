using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsFiles_LangMetadata
{
	[Key]
	public int CrmCmsFileLangID { get; set; }

	public int FileId { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }
}
