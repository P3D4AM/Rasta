using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmImportFromExcelFields_LangMetadata))]
public class CrmImportFromExcelFields_Lang
{
	public int CrmImportFromExcelFieldLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string FieldCaption { get; set; }

	public virtual CrmImportFromExcelFields CrmImportFromExcelFields { get; set; }

	public virtual Languages Languages { get; set; }
}
