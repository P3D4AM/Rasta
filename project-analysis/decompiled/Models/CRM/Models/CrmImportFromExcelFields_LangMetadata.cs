using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmImportFromExcelFields_LangMetadata
{
	[Key]
	public int CrmImportFromExcelFieldLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string FieldCaption { get; set; }
}
