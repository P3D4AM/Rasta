using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PrintFormatType_LangMetadata))]
public class PrintFormatType_Lang
{
	public int PrintFormatTypeLangID { get; set; }

	public int PrintFormatTypeID { get; set; }

	public int LanguageID { get; set; }

	public string PrintFormatType { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormatType PrintFormatType1 { get; set; }
}
