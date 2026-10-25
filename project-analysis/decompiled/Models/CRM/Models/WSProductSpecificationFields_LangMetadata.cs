using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductSpecificationFields_LangMetadata
{
	[Key]
	public int SpecificationFieldLangID { get; set; }

	public int? SpecificationFieldId { get; set; }

	public string specTitle { get; set; }

	public string specMultiItemValues { get; set; }

	public int? LanguageID { get; set; }
}
