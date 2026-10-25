using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDiscountStrategy_LangMetadata))]
public class WSDiscountStrategy_Lang
{
	public int WSDiscountStrategyLangID { get; set; }

	public int DiscountStrategyId { get; set; }

	public int LanguageID { get; set; }

	public string DisStTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDiscountStrategy WSDiscountStrategy { get; set; }
}
