using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductSpecificationFieldTypes_LangMetadata
{
	[Key]
	public int SpecificationFieldTypeLangID { get; set; }

	public int? SpecificationFieldTypeId { get; set; }

	public string TypeName { get; set; }

	public int? LanguageID { get; set; }
}
