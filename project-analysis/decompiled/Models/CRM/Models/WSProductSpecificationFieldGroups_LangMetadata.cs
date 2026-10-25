using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductSpecificationFieldGroups_LangMetadata
{
	[Key]
	public int SpecificationFieldGroupLangID { get; set; }

	public int? SpecificationFieldGroupId { get; set; }

	public string FieldGroupTitle { get; set; }

	public int? LanguageID { get; set; }
}
