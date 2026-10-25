using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLetterType_LangMetadata))]
public class SecLetterType_Lang
{
	public int SecLetterTypeLangID { get; set; }

	public int LetterTypeId { get; set; }

	public int LanguageID { get; set; }

	public string LetterTypeTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SecLetterType SecLetterType { get; set; }
}
