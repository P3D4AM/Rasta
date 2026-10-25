using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmDyFormFieldTypes_LangMetadata
{
	[Key]
	public int CrmDyFormFieldTypeLangID { get; set; }

	public int FieldTypeId { get; set; }

	public string TypeName { get; set; }

	public int LanguageID { get; set; }
}
