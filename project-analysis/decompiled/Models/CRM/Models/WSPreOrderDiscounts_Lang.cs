using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderDiscounts_LangMetadata))]
public class WSPreOrderDiscounts_Lang
{
	public int WSPreOrderDiscountLangID { get; set; }

	public int PreOrderDiscountId { get; set; }

	public int LanguageID { get; set; }

	public string pordDisTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderDiscounts WSPreOrderDiscounts { get; set; }
}
