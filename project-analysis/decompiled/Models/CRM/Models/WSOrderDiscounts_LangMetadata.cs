using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSOrderDiscounts_LangMetadata
{
	[Key]
	public int WSOrderDiscountLangID { get; set; }

	public int OrderDiscountId { get; set; }

	public int LanguageID { get; set; }

	public string ordDisTitle { get; set; }
}
