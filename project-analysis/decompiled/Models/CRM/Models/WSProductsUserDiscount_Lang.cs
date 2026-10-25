using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductsUserDiscount_LangMetadata))]
public class WSProductsUserDiscount_Lang
{
	public int WSProductsUserDiscountLangID { get; set; }

	public int ProductsUserDiscountId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductsUserDiscount WSProductsUserDiscount { get; set; }
}
