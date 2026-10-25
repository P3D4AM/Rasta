using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderDiscounts_LangMetadata))]
public class WSOrderDiscounts_Lang
{
	public int WSOrderDiscountLangID { get; set; }

	public int OrderDiscountId { get; set; }

	public int LanguageID { get; set; }

	public string ordDisTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderDiscounts WSOrderDiscounts { get; set; }
}
