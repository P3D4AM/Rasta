using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSOrderImportFromExcelFields_LangMetadata
{
	[Key]
	public int WSProductImportFromExcelFieldsLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string FieldCaption { get; set; }
}
