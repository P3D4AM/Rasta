using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmDyFormFieldValues_LangMetadata
{
	[Key]
	public int CrmDyFormFieldValueLangID { get; set; }

	public int FieldValueId { get; set; }

	public string Value { get; set; }

	public int LanguageID { get; set; }
}
