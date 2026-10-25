using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductPriceGroup_LangMetadata))]
public class WSProductPriceGroup_Lang
{
	public int WSProductPriceGroupLangID { get; set; }

	public int ProductPriceGroupID { get; set; }

	public int LanguageID { get; set; }

	public string ProductPriceGroupName { get; set; }

	public string ProductPriceGroupDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }
}
