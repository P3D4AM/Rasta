using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderItemSpecification_LangMetadata))]
public class WSPreOrderItemSpecification_Lang
{
	public int WSPreOrderItemSpecificationLangID { get; set; }

	public int PreOrderItemSpcflID { get; set; }

	public int LanguageID { get; set; }

	public string Specification { get; set; }

	public string SpecificationI { get; set; }

	public string SpecificationII { get; set; }

	public virtual Languages Languages { get; set; }
}
