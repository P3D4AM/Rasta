using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecificationFieldTypes_LangMetadata))]
public class WSProductSpecificationFieldTypes_Lang
{
	public int SpecificationFieldTypeLangID { get; set; }

	public int? SpecificationFieldTypeId { get; set; }

	public string TypeName { get; set; }

	public int? LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductSpecificationFieldTypes WSProductSpecificationFieldTypes { get; set; }
}
