using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecificationFields_LangMetadata))]
public class WSProductSpecificationFields_Lang
{
	public int SpecificationFieldLangID { get; set; }

	public int? SpecificationFieldId { get; set; }

	public string specTitle { get; set; }

	public string specSHPTitle { get; set; }

	public string specMultiItemValues { get; set; }

	public int? LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductSpecificationFields WSProductSpecificationFields { get; set; }
}
