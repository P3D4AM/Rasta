using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDiscountCode_LangMetadata
{
	[Key]
	public int WSDiscountCodeLangID { get; set; }

	public int DiscountCodeId { get; set; }

	public int LanguageID { get; set; }

	public string DisTitle { get; set; }
}
