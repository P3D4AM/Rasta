using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecificationFieldGroups_LangMetadata))]
public class WSProductSpecificationFieldGroups_Lang
{
	public int SpecificationFieldGroupLangID { get; set; }

	public int? SpecificationFieldGroupId { get; set; }

	public string FieldGroupTitle { get; set; }

	public int? LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductSpecificationFieldGroups WSProductSpecificationFieldGroups { get; set; }
}
