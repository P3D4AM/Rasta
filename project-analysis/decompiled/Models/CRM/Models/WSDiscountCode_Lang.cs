using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDiscountCode_LangMetadata))]
public class WSDiscountCode_Lang
{
	public int WSDiscountCodeLangID { get; set; }

	public int DiscountCodeId { get; set; }

	public int LanguageID { get; set; }

	public string DisTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDiscountCode WSDiscountCode { get; set; }
}
