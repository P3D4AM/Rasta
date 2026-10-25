using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLetters_LangMetadata))]
public class SecLetters_Lang
{
	public int SecLettersLangID { get; set; }

	public int LetterId { get; set; }

	public int LanguageID { get; set; }

	public string LetterAnnex { get; set; }

	public string LettercmpNickName { get; set; }

	public string LettercmpPersonNickName { get; set; }

	public string LetterSubject { get; set; }

	public string LetterHeader { get; set; }

	public string LetterContext { get; set; }

	public string LetterFooter { get; set; }

	public string LetterSigningI { get; set; }

	public string LetterSigningII { get; set; }

	public string LetterSigningIII { get; set; }

	public string LetterSigningIV { get; set; }

	public string LetterContextRtf { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SecLetters SecLetters { get; set; }
}
