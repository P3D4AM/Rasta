using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSystemParts_LangMetadata
{
	[Key]
	public int CrmSystemPartLangID { get; set; }

	public int SystemPartId { get; set; }

	public string PartTitle { get; set; }

	public int LanguageID { get; set; }
}
