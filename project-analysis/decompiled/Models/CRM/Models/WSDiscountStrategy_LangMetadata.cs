using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDiscountStrategy_LangMetadata
{
	[Key]
	public int WSDiscountStrategyLangID { get; set; }

	public int DiscountStrategyId { get; set; }

	public int LanguageID { get; set; }

	public string DisStTitle { get; set; }
}
