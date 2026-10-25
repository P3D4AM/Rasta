using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class SecLetterNumberCounter_LangMetadata
{
	[Key]
	public int SecLetterNumberCounterLangID { get; set; }

	public int LetterNumberCounterId { get; set; }

	public int LanguageID { get; set; }

	public string LtrNumCntTitle { get; set; }
}
