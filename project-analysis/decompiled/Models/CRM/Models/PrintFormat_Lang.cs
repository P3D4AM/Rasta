using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PrintFormat_LangMetadata))]
public class PrintFormat_Lang
{
	public int PrintFormatLangID { get; set; }

	public int PrintFormatID { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }
}
