using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductImportFromExcelFields_LangMetadata))]
public class WSProductImportFromExcelFields_Lang
{
	public int WSProductImportFromExcelFieldsLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string FieldCaption { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductImportFromExcelFields WSProductImportFromExcelFields { get; set; }
}
