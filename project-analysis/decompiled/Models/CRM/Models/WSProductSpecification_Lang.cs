using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecification_LangMetadata))]
public class WSProductSpecification_Lang
{
	public int WSProductSpecificationLangID { get; set; }

	public int ProductSpecificationID { get; set; }

	public int LanguageID { get; set; }

	public string Specification { get; set; }

	public string SpecificationI { get; set; }

	public string SpecificationII { get; set; }

	public string SpecificationValue { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductSpecification WSProductSpecification { get; set; }
}
