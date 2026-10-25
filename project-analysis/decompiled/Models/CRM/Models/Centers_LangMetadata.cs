using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class Centers_LangMetadata
{
	[Key]
	public int CenterLangID { get; set; }

	public int CenterId { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public int LanguageID { get; set; }
}
