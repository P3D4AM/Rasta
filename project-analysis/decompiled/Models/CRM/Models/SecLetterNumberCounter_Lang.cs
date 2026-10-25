using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLetterNumberCounter_LangMetadata))]
public class SecLetterNumberCounter_Lang
{
	public int SecLetterNumberCounterLangID { get; set; }

	public int LetterNumberCounterId { get; set; }

	public int LanguageID { get; set; }

	public string LtrNumCntTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SecLetterNumberCounter SecLetterNumberCounter { get; set; }
}
