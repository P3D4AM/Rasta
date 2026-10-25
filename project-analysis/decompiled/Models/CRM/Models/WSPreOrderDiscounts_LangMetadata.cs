using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSPreOrderDiscounts_LangMetadata
{
	[Key]
	public int WSPreOrderDiscountLangID { get; set; }

	public int PreOrderDiscountId { get; set; }

	public int LanguageID { get; set; }

	public string pordDisTitle { get; set; }
}
